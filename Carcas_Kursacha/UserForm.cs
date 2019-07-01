using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Menu_Coffee
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        

        private static string FormatName(string name)
        {
            name = Char.ToUpper(name[0]) + name.Substring(1);
            int x = name.IndexOf('-');
            while (x > 0)
            {
                name = name.Substring(0, x + 1) + Char.ToUpper(name[x + 1]) +
                    name.Substring(x + 2);
                x = name.IndexOf('-', x + 1);
            }
            return name;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult == DialogResult.OK)
            {
                Regex reg = new Regex("^([а-яё]+)(-[а-яё]+)*$", RegexOptions.IgnoreCase);
                string name = tbFirstName.Text.Trim().ToLower();
                string surname = tbSecondName.Text.Trim().ToLower();

                if (reg.IsMatch(name) && reg.IsMatch(surname)
                    && name.Length > 1 && surname.Length > 1)
                {
                    name = FormatName(name);
                    surname = FormatName(surname);
                    if (!String.IsNullOrWhiteSpace(tbLogin.Text) && mtbPhone.MaskCompleted)
                    {
                        try
                        {
                            if (DAL.AddClient(name, surname, tbLogin.Text,
                                Convert.ToInt32(nudBonuses.Value), mtbPhone.Text))
                            {
                                MessageBox.Show("Пользователь добавлен");
                            }
                            else
                            {
                                MessageBox.Show("Пользователь уже существует");
                                e.Cancel = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите логин и номер телефона");
                        e.Cancel = true;
                    }
                }
                else
                {
                    e.Cancel = true;
                    MessageBox.Show("Имя и фамлия должны быть введены на русском языке");
                }
            }
        }
    }
}
