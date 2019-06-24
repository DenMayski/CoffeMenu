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

namespace Carcas_Kursacha
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            tbFirstName.Text.Trim();
            tbSecondName.Text.Trim();
            tbLogin.Text.Trim();
            Regex reg = new Regex("^([а-яА-Я]+)(-[а-яА-Я]+)*$", RegexOptions.IgnoreCase);

            if (reg.IsMatch(tbFirstName.Text) && reg.IsMatch(tbSecondName.Text))
            {
                if (tbLogin.Text != "" && mtbPhone.MaskCompleted)
                {
                    try
                    {
                        DAL.AddClient(tbFirstName.Text, tbSecondName.Text,
                            tbLogin.Text, Convert.ToInt32(nudBonuses.Value), mtbPhone.Text);
                        MessageBox.Show("Пользователь добавлен");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                    MessageBox.Show("Введите логин и номер телефона");
            }
            else
            {
                MessageBox.Show("Имя и фамлия должны быть введены на русском языке");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
