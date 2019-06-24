using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Carcas_Kursacha
{
    class DAL
    {
        public static string ConnString
        {
            get
            {
                SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
                sb.DataSource = Properties.Settings.Default.server;
                sb.InitialCatalog = Properties.Settings.Default.db;
                sb.UserID = Properties.Settings.Default.login;
                sb.Password = Properties.Settings.Default.password;
                sb.PersistSecurityInfo = true;
                return sb.ConnectionString;
            }
        }

        public static DataTable GetTable(string tableName)
        {
            return Select("SELECT * FROM " + tableName);
        }

        public static DataTable Select(string select)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(select, conn);
                    da.Fill(dt);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return dt;
        }

        public static void ExecuteCommand(string cmdText)
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(cmdText,conn);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static string user;  //НАЧАЛ ОТ СЮДА ЗАКОНЧИЛ НА ВКЛАДКЕ НАСТРОЙКА
        public static string idUser;
    }
}