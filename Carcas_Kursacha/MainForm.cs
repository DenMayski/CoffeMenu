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
            if (!FormOpen("Заказы"))
            {
                Form f = new TableForm((DAL.user == "manager" ? "UsersOrders" :
                "GetUserOrders(" + DAL.idUser + ")"));
                f.Text = "Заказы";
                f.MdiParent = this;
                f.Show();
            }
        }

        private void MenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormOpen("Меню"))
            {
                Form f = new TableForm("ShortMenu");
                f.Text = "Меню";
                f.MdiParent = this;
                f.Show();
            }
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


        private void btnQueryToDB_Click(object sender, EventArgs e)
        {
            if (!FormOpen("Запросы к БД"))
            {
                Form f = new QueryForm();
                f.MdiParent = this;
                f.Show();
            }

        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            if (!FormOpen("Клиенты"))
            {
                Form f = new TableForm("ClientsInfo");
                f.Text = "Клиенты";
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnNewClient_Click(object sender, EventArgs e)
        {
            Form f = new UserForm();
            f.ShowDialog();
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            if (!FormOpen("Новый заказ"))
            {
                Form f = new OrderForm();
                f.Text = "Новый заказ";
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnNewOffer_Click(object sender, EventArgs e)
        {
            if (!FormOpen("Спецпредложения"))
            {
                Form f = new TableForm("AvailableOffers");
                f.Text = "Спецпредложения";
                f.MdiParent = this;
                f.Show();
            }
        }

        private bool FormOpen(string formName)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Text == formName)
                {
                    f.Activate();
                    return true;
                }
            }
            return false;
        }

    }
}