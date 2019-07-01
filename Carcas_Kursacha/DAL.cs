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
        /// <summary>
        /// Свойство содержащее в себе строку подключения к БД
        /// </summary>
        public static string ConnString
        {
            get
            {
                //Объявляет конструктор строки подключения
                SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
                
                sb.DataSource = Properties.Settings.Default.server; //Имя сервера
                sb.InitialCatalog = Properties.Settings.Default.db; //Имя БД
                sb.UserID = Properties.Settings.Default.login;      //Имя пользователя
                sb.Password = Properties.Settings.Default.password; //Пароль пользователя
                sb.PersistSecurityInfo = true;                      //Сохранить настройки
                return sb.ConnectionString;                         //Возвращает строку подключения
            }
        }

        /// <summary>
        /// Метод возвращающий таблицу из БД по ее названию
        /// </summary>
        /// <param name="tableName">Имя таблицы</param>
        /// <returns>Таблица из БД</returns>
        public static DataTable GetTable(string tableName)
        {
            DataTable dt = new DataTable();             //Создает таблицу
            dt = Select("SELECT * FROM " + tableName);  //Получает выборку всех строк из таблицы
            dt.TableName = tableName;                   //Указывает имя таблицы
            return dt;                                  //Возвращает таблицу 
        }

        /// <summary>
        /// Метод возвращающий выборку по команде SELECT
        /// </summary>
        /// <param name="select">Строка выборки</param>
        /// <returns>Выборка из БД</returns>
        public static DataTable Select(string select)
        {
            DataTable dt = new DataTable();         //Создает таблицу

            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                try
                {
                    conn.Open();        //Открывает соединение с БД
                    //Создает связь между БД и DataTable
                    SqlDataAdapter da = new SqlDataAdapter(select, conn);   
                    da.Fill(dt);    //Заполняет таблицу данными
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);    //Выводит сообщение об ошибке

                }
            }
            return dt;  //Возвращает таблицу
        }

        /// <summary>
        /// Метод выполняющий SQL - команду 
        /// </summary>
        /// <param name="cmdText">Текст команды</param>
        public static void ExecuteCommand(string cmdText)
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                try
                {
                    conn.Open();            //Открывает соединение с БД
                    SqlCommand cmd = new SqlCommand(cmdText, conn); //Создает SqlCommand
                    cmd.ExecuteNonQuery();  //Выполняет Sql - команду 
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);    //Выводит сообщение об ошибке
                }
            }
        }

        /// <summary>
        /// Метод добавляющий нового клиента в БД и возврат результата команды
        /// </summary>
        /// <param name="FN">Имя</param>
        /// <param name="SN">Фамилия</param>
        /// <param name="Log">Логин</param>
        /// <param name="Bonuses">Количество бонусов</param>
        /// <param name="Phone">Номер телефона</param>
        /// <returns>Успех выполения команды</returns>
        public static bool AddClient(string FN, string SN, string Log, int Bonuses, string Phone)
        {
            //Создает таблицу которая будет содержать в себе пользователей с 
            //указанным именем, фамилией и номером телефона
            DataTable dt = DAL.Select("SELECT * FROM Clients WHERE [FirstName] = '" + FN + "' AND [SecondName] = '" +
                SN + "' AND [TelephoneNumber] = '" + Phone + "'");

            //Если такого пользователя нет, то регестрирует нового
            if (dt.Rows.Count == 0)         
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    try
                    {
                        conn.Open();        //Открывает соединение с БД

                        //Создает SqlCommand
                        SqlCommand cmd = new SqlCommand("AddClient", conn);
                        //Указывает, что команда является хранимой процедурой
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Создает параметр команды
                        SqlParameter firstName = new SqlParameter("@FN", FN);
                        //Создает параметр команды
                        SqlParameter secondName = new SqlParameter("@SN", SN);
                        //Создает параметр команды
                        SqlParameter login = new SqlParameter("@Log", Log);
                        //Создает параметр команды
                        SqlParameter bonuses = new SqlParameter("@Bonuses", Bonuses);
                        //Создает параметр команды
                        SqlParameter phone = new SqlParameter("@Phone", Phone);
                        //Добавляет параметры к команде
                        cmd.Parameters.AddRange(new[] { firstName, secondName, login, bonuses, phone });
                        //Выполняет команду
                        cmd.ExecuteNonQuery();
                        //Возвращет успех выполнения команды
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);        //Выводит сообщение об ошибке
                    }
                }
           return false;    //Команда не была выполнена
        }

        /// <summary>
        /// Метод добавляющий новый заказ и возвращающий код заказа
        /// </summary>
        /// <param name="idClient">Код клиента</param>
        /// <param name="Bonus">Количество бонусов</param>
        /// <returns>Код заказа</returns>
        public static int AddOrder(int idClient, int Bonus)
        {
            //Код заказа
            int exit = -1;
            try
            {
                //Создает строку содержащую текст команды
                string cmd = String.Format("INSERT INTO Orders (BonusPayed, idClient) " +
                                "VALUES ({0}, {1})", Bonus, idClient);

                //Выполняет Sql - команду
                ExecuteCommand(cmd);

                //Получает таблицу "Заказы" 
                DataTable dt = GetTable("Orders");

                //Получает код последнего заказа
                exit = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["idOrder"]);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);    //Выводит сообщение об ошибке
            }
            return exit;    //Возвращает номер последнего заказа
        }

        /// <summary>
        /// Метод добавляющий состав заказа в БД
        /// </summary>
        /// <param name="comp">Список из позиций и их количества</param>
        /// <param name="idOrder">Код заказа</param>
        /// <param name="table">Имя таблицы</param>
        public static void AddOrderItem(Dictionary<int, int> comp, int idOrder, string table)
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                try
                {
                    conn.Open();    //Открывает соединение с БД

                    //Создает строку содержащую команду на вставку
                    string insert = "INSERT INTO " + table + " VALUES ";

                    foreach (int idItem in comp.Keys)
                    {
                        //Добавляет строку в БД
                        ExecuteCommand(insert + "(" + idItem + ", " + idOrder + ", " + comp[idItem] + ")");
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);    //Выводит сообщение об ошибке
                }
            }
        }

        /// <summary>
        /// Обновление или Сохранение таблицы
        /// </summary>
        /// <param name="isSelect">Обновлять таблицу</param>
        /// <param name="dt">Таблица</param>
        public static void UpdateTable(bool isSelect, DataTable dt)
        { 
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                try
                {
                    conn.Open();    //Открывает соединение с БД

                    //Создает DataAdapter
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM " + dt.TableName, conn);

                    //Если не обновлять таблицу, значит сохранять
                    if (!isSelect)
                    {
                        //Создает конструктор команд
                        SqlCommandBuilder scb = new SqlCommandBuilder(da);
                        //Сохраняем таблицу
                        da.Update(dt);
                    }
                    
                    dt.Clear();     //Очищаем старые данные из таблицу
                    da.Fill(dt);    //Заполняем таблицу данными из БД
                }
                catch(SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        

        /// <summary>
        /// Поле содержащее в себе роль пользователя
        /// </summary>
        public static string user;

        /// <summary>
        /// Поле содержащее в себе Код пользователя
        /// </summary>
        public static string idUser;
    }
}