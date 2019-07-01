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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            tbServer.Text = Properties.Settings.Default.server;
            tbLogin.Text = Properties.Settings.Default.login;
            tbPassword.Text = Properties.Settings.Default.password;
            tbDataBase.Text = Properties.Settings.Default.db;
            tbAdmin.Text = Properties.Settings.Default.passwordAdmin;
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (MessageBox.Show("Вы уверены, что хотите сохранить?",
                    "Сохранить", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Properties.Settings.Default.server = tbServer.Text;
                    Properties.Settings.Default.login = tbLogin.Text;
                    Properties.Settings.Default.password = tbPassword.Text;
                    Properties.Settings.Default.db = tbDataBase.Text;
                    Properties.Settings.Default.passwordAdmin = tbAdmin.Text;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void tbAdmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch != 8 && ch <= 33 && ch >= 127)
                e.Handled = true;
        }
    }
}