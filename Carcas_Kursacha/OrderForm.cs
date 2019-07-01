using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu_Coffee
{
    public partial class OrderForm : Form
    {
        DataTable dt;

        public OrderForm()
        {
            InitializeComponent();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            dt = DAL.GetTable("ShortMenu");
            bs.DataSource = dt;
            bn.BindingSource = bs;
            dgv.DataSource = bs;
            dgv.Columns[0].Visible = false;
        }

        int id;
        private void bnPosItem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                id = Convert.ToInt32(bnPosItem.Text.ToString() ) - 1;
                id = id > -1 ? id : 0;
                lblName.Text = dt.Rows[id][1].ToString();
                lblComposit.Text = dt.Rows[id][2].ToString();
                lblPrice.Text = dt.Rows[id][3].ToString();
                nudCount.Value = 1;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Dictionary<int, int> Menu = new Dictionary<int, int>();
        public Dictionary<int, int> Offer = new Dictionary<int, int>();
        public Dictionary<string, int> Composit = new Dictionary<string, int>();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int key, count;
            key = Convert.ToInt32(dgv.CurrentRow.Cells[0].Value.ToString());
            count = (int)nudCount.Value;
            string name = dgv.CurrentRow.Cells[1].Value.ToString();
                //Если элемент находится в таблице и количество больше 0
                if (Composit.ContainsKey(name) && count > 0)
                    Composit[name] = count; //измени количество на новое значение
                else if (count == 0)        //иначе если количество 0
                    Composit.Remove(name);  //удали
                else
                    Composit.Add(name, count);//иначе добавь
            if (dgv.CurrentRow.Cells[dgv.ColumnCount - 1].Value.ToString() == "Обычное меню")
            {
                InsertInto(Menu, key, count);   
            }
            else
            {
                InsertInto(Offer, key, count);
            }
            string comp = "";
            foreach(string namePos in Composit.Keys)
                comp += String.Format("{0} - {1} шт;  ", namePos, Composit[namePos]);
            tbComp.Text = comp;
            
            btnCheckOrder.Enabled = tbComp.Text.Length > 0;
        }

        private void InsertInto(Dictionary<int, int> Dict, int key, int count)
        {
            if (Dict.ContainsKey(key) && count > 0)
                Dict[key] = count;
            else if (count == 0)
                Dict.Remove(key);
            else
                Dict.Add(key, count);
        }

        private void CheckOrdbtn_Click(object sender, EventArgs e)
        {
            Form f = new CheckOrderForm(Menu, Offer);
            if (f.ShowDialog() == DialogResult.OK)
                this.Close();
        }
    }
}
