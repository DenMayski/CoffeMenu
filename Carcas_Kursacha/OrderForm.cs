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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnCheckOrder.Enabled = true;
            int key, count;
            key = Convert.ToInt32(dgv.CurrentRow.Cells[0].Value.ToString());
            count = (int)nudCount.Value;
            if (dgv.CurrentRow.Cells[dgv.ColumnCount - 1].Value.ToString() == "Обычное меню")
            {
                InsertInto(Menu, key, count);
            }
            else
            {
                InsertInto(Offer, key, count);
            }
        }

        private void InsertInto(Dictionary<int, int> Dict, int key, int count)
        {
            if (Dict.ContainsKey(key))
                Dict[key] += count;
            else
                Dict.Add(key, count);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form f = new CheckOrderForm(Menu, Offer);
            f.ShowDialog();
            this.Close();
        }
    }
}
