using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

       public CheckOrderForm(Dictionary<int,int> Menu, Dictionary<int, int> Offer):this()
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
            foreach (int x in Menu.Keys)
            {
                dgv["count", id].Value = Menu[x];
                dgv["cost", id].Value = string.Format("{0:0.00}", Convert.ToInt32(dgv["count", id].Value) *
                    Convert.ToDouble(dgv["Цена", id].Value));
                id++;
            }

            foreach (int x in Offer.Keys)
            {
                dgv["count", id].Value = Offer[x];
                dgv["cost", id].Value = string.Format("{0:0.00}", Convert.ToInt32(dgv["count", id].Value) *
                    Convert.ToDouble(dgv["Цена", id].Value));
                id++;
            }
        }

        private void CheckOrderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                e.Cancel = true;
                MessageBox.Show(maskedTextBox1.MaskFull.ToString());
                MessageBox.Show(maskedTextBox1.Text);
            }
        }
    }
}
