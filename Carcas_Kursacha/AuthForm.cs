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
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();

        }

        private void chbViewPassword_CheckedChanged(object sender, EventArgs e)
        {
            mtbPassword.PasswordChar = chbViewPassword.Checked ? '\0' : '*';
        }

        private void AuthForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (tbLogin.Text == "admin" &&
                    mtbPassword.Text ==
                    Properties.Settings.Default.passwordAdmin)
                {
                    DAL.user = "admin";
                    SettingsForm f = new SettingsForm();
                    f.ShowDialog();
                }
                else
                {
                    System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(DAL.ConnString);
                    try
                    {
                        DAL.user = chbClient.Checked ? "client" : "manager";
                        conn.Open();
                        string select = "Select * from ";
                        select += chbClient.Checked ? " Clients " : " Managers ";
                        select += "WHERE Login = '" + tbLogin.Text + "' " +
                                "AND " + (chbClient.Checked ? "TelephoneNumber " : " Password ")
                                + "= '" + mtbPassword.Text + "'";
                        DataTable dt = DAL.Select(select);
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("Добро пожаловать " + dt.Rows[0]["FirstName"].ToString() +
                               " " + dt.Rows[0]["SecondName"].ToString());
                            DAL.idUser = dt.Rows[0][0].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Данный пользователь отсутствует");
                            e.Cancel = true;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void tbLoginAndPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch != 8 && ch <= 33 && ch >= 127)
                e.Handled = true;
        }

        private void chbClient_CheckedChanged(object sender, EventArgs e)
        {
            mtbPassword.Clear();
            if (chbClient.Checked)
            {
                mtbPassword.Mask = "+7(000) 000-00-00";
                mtbPassword.PasswordChar = '\0';
                chbViewPassword.Enabled = false;
                lblPassword.Text = "Номер\nтелефона";
            }
            else
            {
                mtbPassword.Mask = "";
                chbViewPassword.Enabled = true;
                mtbPassword.PasswordChar = chbViewPassword.Checked ? '\0' : '*';
                lblPassword.Text = "Пароль";
            }
            mtbPassword.Focus();
        }
    }
}