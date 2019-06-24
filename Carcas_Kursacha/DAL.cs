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
            DataTable dt = new DataTable();
            dt = Select("SELECT * FROM " + tableName);
            dt.TableName = tableName;
            return dt;
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
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static void AddClient(string FN, string SN, string Log, int Bonuses, string Phone)
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("AddClient", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter firstName = new SqlParameter("@FN", FN);
                    SqlParameter secondName = new SqlParameter("@SN", SN);
                    SqlParameter login = new SqlParameter("@Log", Log);
                    SqlParameter bonuses = new SqlParameter("@Bonuses", Bonuses);
                    SqlParameter phone = new SqlParameter("@Phone", Phone);
                    cmd.Parameters.AddRange(new[] { firstName, secondName, login, bonuses, phone });
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static int AddOrder(int idClient, int Bonus)
        {
            string cmd = String.Format("INSERT INTO Orders (BonusPayed, idClient) " +
                            "VALUES ({0}, {1})", Bonus, idClient);
            ExecuteCommand(cmd);
            DataTable dt = GetTable("Orders");
            return Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["idOrder"]);
        }

        public static void AddOrderItem(Dictionary<int, int> comp, int idOrder, string table)
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                try
                {
                    conn.Open();
                    string insert = "INSERT INTO " + table + " VALUES ";
                    foreach(int idItem in comp.Keys)
                    {
                        insert += "(" + idItem + ", " + idOrder + ", " + comp[idItem] + "),";
                    }
                    insert = insert.Substring(0, insert.Length - 1);
                    ExecuteCommand(insert);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        
        public static string user; 
        public static string idUser;
    }
}