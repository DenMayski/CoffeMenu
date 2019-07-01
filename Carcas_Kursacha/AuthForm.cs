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
            //Если галочка стоит, то показать пароль иначе скрыть
            mtbPassword.PasswordChar = chbViewPassword.Checked ? '\0' : '*';
        }

        private void AuthForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Если нажата клавиша "ОК"
            if (this.DialogResult == DialogResult.OK)
            {
                //Если введенный логин и пароль принадлежат администратору, то 
                if (tbLogin.Text == "admin" &&
                    mtbPassword.Text ==
                    Properties.Settings.Default.passwordAdmin)
                {
                    DAL.user = "admin";     //Роль пользователя - администратор
                    SettingsForm f = new SettingsForm();    //Создать форму настроек
                    f.ShowDialog();         //Отобразить форму настроек
                }
                else
                {
                    //Иначе если выбран флажок, то Роль - клиент, иначе менеджер
                    DAL.user = chbClient.Checked ? "client" : "manager";
                    //Формирует строку выборки из таблицы Клиентов или Менеджеров из БД
                    string select = "Select * from " + (chbClient.Checked ? " Clients " : " Managers");
                    //где логин и пароль совпадает с введенным
                    select += " WHERE Login = '" + tbLogin.Text + "' " +
                            "AND " + (chbClient.Checked ? "TelephoneNumber " : " Password ")
                            + "= '" + mtbPassword.Text + "'";
                    //Выполняет запрос на выборку и заполняет таблицу
                    DataTable dt = DAL.Select(select);
                    //Если количество строк таблицы больше 0 и 
                    //регистр паролей у менеджера совпал или это клиент, то 
                    if (dt.Rows.Count > 0 && (DAL.user == "manager" &&
                            dt.Rows[0][4].ToString() == mtbPassword.Text
                            || DAL.user == "client"))
                    {
                        //Вывести приветствие пользоваетеля
                        MessageBox.Show("Добро пожаловать " + dt.Rows[0]["FirstName"].ToString() +
                           " " + dt.Rows[0]["SecondName"].ToString());
                        //Код пользователя из таблицы
                        DAL.idUser = dt.Rows[0][0].ToString();
                    }
                    //Иначе вывести сообщение об отсутсвие пользоваетля и не закрывать форму
                    else
                    {
                        MessageBox.Show("Данный пользователь отсутствует");
                        e.Cancel = true;
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