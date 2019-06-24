using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.IO;

namespace Carcas_Kursacha
{
    public partial class CheckOrderForm : Form
    {
        DataTable dt;
        Dictionary<int, int> Menu;
        Dictionary<int, int> Offer;

        public CheckOrderForm()
        {
            InitializeComponent();
        }

        public CheckOrderForm(Dictionary<int, int> Menu, Dictionary<int, int> Offer) : this()
        {
            this.Menu = Menu;
            this.Offer = Offer;
        }

        private void CheckOrderForm_Load(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn count = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn cost = new DataGridViewTextBoxColumn();
            count.Name = "Count";
            cost.Name = "Cost";
            count.HeaderText = "Количество";
            cost.HeaderText = "Стоимость";

            string select = "";
            if (Menu.Keys.Count > 0)
            {
                select = "select itemname as [Название], itemprice as [Цена]  from menu " +
                "where idItem IN (";

                foreach (int x in Menu.Keys)
                    select += x + ", ";

                select = select.Remove(select.LastIndexOf(',')) + ")";
            }

            if (Offer.Keys.Count > 0)
            {
                select = select != "" ? select + " union " : select;
                select += "select [Название], [Цена] from " +
                "AvailableOffers  where [Код предложения] IN (";
                foreach (int x in Offer.Keys)
                    select += x + ", ";

                select = select.Remove(select.LastIndexOf(',')) + ")";
            }

            dt = DAL.Select(select);
            dgv.DataSource = dt;
            dgv.Columns.Add(count);
            dgv.Columns.Add(cost);
            int id = 0;
            double sum = 0;

            foreach (int x in Menu.Keys)
            {
                dgv["count", id].Value = Menu[x];
                dgv["cost", id].Value = string.Format("{0:0.00}", Convert.ToInt32(dgv["count", id].Value) *
                    Convert.ToDouble(dgv["Цена", id].Value));
                sum += Convert.ToDouble(dgv["Cost", id].Value);
                id++;
            }

            foreach (int x in Offer.Keys)
            {
                dgv["count", id].Value = Offer[x];
                dgv["cost", id].Value = string.Format("{0:0.00}", Convert.ToInt32(dgv["count", id].Value) *
                    Convert.ToDouble(dgv["Цена", id].Value));
                sum += Convert.ToDouble(dgv["Cost", id].Value);
                id++;
            }

            lblCost.Text = String.Format("{0:0.00}", sum);
        }

        private void CheckOrderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (mtbPhone.MaskFull)
                {
                    string select = "Select * from Clients WHERE TelephoneNumber "
                            + "= '" + mtbPhone.Text + "'";
                    DataTable dt = DAL.Select(select);
                    if (dt.Rows.Count > 0)
                    {
                        int Bonus = Convert.ToInt32(dt.Rows[0]["NumberOfBonuses"]);
                        if (Bonus > Convert.ToDouble(lblCost.Text) * 0.40)
                            Bonus = Convert.ToInt32(
                                        Math.Round(Convert.ToDouble(lblCost.Text) * 0.40));
                        if (MessageBox.Show("Для списания доступно: " + Bonus.ToString() +
                            " бонусов", "Списать бонусы?", MessageBoxButtons.YesNo)
                            == DialogResult.No)
                            Bonus = 0;
                        int idOrder = DAL.AddOrder(Convert.ToInt32(dt.Rows[0]["idClient"]), Bonus);
                        if (Menu.Keys.Count > 0)
                            DAL.AddOrderItem(Menu, idOrder, "ItemInOrder");
                        if (Offer.Keys.Count > 0)
                            DAL.AddOrderItem(Offer, idOrder, "OfferInOrder");
                        //CreateDocument(@"Заказ_" + idOrder + ".docx", idOrder, Bonus);
                    }
                    else
                    {
                        MessageBox.Show("Пользователь не найден");
                    }
                }
                else
                {
                    MessageBox.Show("Введите номер телефона ");
                    e.Cancel = true;
                }
            }
            //CreateDocument(@"c:\Заказ_" + 22 + ".docx", 22, 30);
            
        }

        private void CreateDocument(object fileName, int idOrder, int Bonus)
        {
            try
            {
                string patternName = "";

                File.Copy(patternName, fileName.ToString(), true);
                Word.Application word = new Word.Application();
                Word.Document doc = word.Documents.Open(ref fileName);

                Dictionary<string, string> replace = new Dictionary<string, string>();
                replace.Add("%idOrder%", idOrder.ToString());
                replace.Add("%date%", DateTime.Today.ToShortDateString());
                replace.Add("%res%", lblCost.Text);
                replace.Add("%bon%", Bonus.ToString());
                replace.Add("%tot%", (Convert.ToDouble(lblCost.Text) - Bonus).ToString());
                replace.Add("%n%", dgv.RowCount.ToString());
                replace.Add("%fulldate%", DateTime.Now.ToString());

                foreach (string key in replace.Keys)
                    FindReplace(key, replace[key], 1, doc);
                FindReplace("%tot%", replace["%tot%"], 1, doc);

                Word.Table table = doc.Tables[1];
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    table.Cell(i + 2, 1).Range.Text = (i + 1).ToString();
                    for (int j = 0; j < dgv.ColumnCount; j++)
                    {
                        table.Cell(i + 2, j + 1).Range.Text = dgv[j, i].Value.ToString();
                    }
                    table.Rows.Add();
                }
                table.Rows[table.Rows.Count].Delete();

                doc.Close();
                word.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void FindReplace(string oldString, string newString, int countReplace, Word.Document doc)
        {
            Word.Range rng = doc.Range();

            for (int i = 0; i < oldString.Length; i++)
            {
                rng.Find.ClearFormatting();
                rng.Find.Execute(oldString);
                rng.Text = newString;
            }
        }
    }
}
