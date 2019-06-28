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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnTables.Visible = false;
            btnSettings.Visible = false;
            btnAction.Visible = false;
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
            AuthForm f = new AuthForm();
            if (f.ShowDialog() == DialogResult.OK)
            {
                ChangeUser();
            }
        }

        private void OrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new TableForm(DAL.user == "manager" ? "UsersOrders" :
                "GetUserOrders(" + DAL.idUser + ")" );
            f.Text = "Заказы";
            f.MdiParent = this;
            f.Show();
        }

        private void MenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new TableForm("ShortMenu");
            f.Text = "Меню";
            f.MdiParent = this;
            f.Show();
        }

        private void ChangeSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new SettingsForm();
            f.Text = "Настройки";
            f.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnTables.Visible = false;
            btnSettings.Visible = false;
            ChangeUser();
            this.Focus();
        }

        private void ChangeUser()
        {
            if (DAL.user == "admin")
            {
                btnSettings.Visible = true;
                btnAction.Visible = false;
            }
            else
            {
                btnTables.Visible = true;
                if (DAL.user == "manager")
                {
                    btnClients.Visible = true;
                    btnAction.Visible = true;
                }
                else
                {
                    btnClients.Visible = false;
                    btnAction.Visible = false;
                }
            }
        }


        private void queryToDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new QueryForm();
            f.Text = "Запросы к БД";
            f.ShowDialog();
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new TableForm("ClientsInfo");
            f.Text = "Клиенты";
            f.MdiParent = this;
            f.Show();
        }

        private void btnNewClient_Click(object sender, EventArgs e)
        {
            Form f = new UserForm();
            f.MdiParent = this;
            f.Show();
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            Form f = new OrderForm();
            f.Text = "Новый заказ";
            f.MdiParent = this;
            f.Show();
        }

        private void новоеСпецпредложениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new TableForm("AvailableOffers");
            f.Text = "Активные спец предложения";
            f.MdiParent = this;
            f.Show();
        }
    }
}
