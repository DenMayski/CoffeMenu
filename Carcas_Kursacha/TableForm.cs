using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Menu_Coffee
{
    public partial class TableForm : Form
    {
        string tableName;
        DataTable dt;
        DataSet ds = new DataSet();

        public TableForm()
        {
            InitializeComponent();
        }

        public TableForm(string table) : this()
        {
            tableName = table;
        }

        private void TableForm_Load(object sender, EventArgs e)
        {
            dt = DAL.GetTable(tableName);

            bs.DataSource = dt;

            dgv.DataSource = dt;
            bn.BindingSource = bs;
            dgv.Columns[0].Visible = false;
            if (tableName == "AvailableOffers")
            {
                dgv.ReadOnly = false;
                dgv.AllowUserToAddRows = true;
                dgv.AllowUserToDeleteRows = true;
                btnSave.Visible = true;
            }
        }

        /// <summary>
        /// Метод экспорта данных из таблицы в CSV файл
        /// </summary>
        /// <returns>CSV строка</returns>
        private string DataGridToCSV()
        {
            //Создает конструктор строки
            StringBuilder sb = new StringBuilder();
            //Циклом заносит в первую строку названия столбцов
            for (int i = 0; i < dgv.ColumnCount; i++)
                sb.Append(dgv.Columns[i].HeaderText + ";");
            //Отделяет заголовки от строк
            sb.AppendLine();
            //Заносит данные из таблицы в строку
            for (int i = 0; i < dgv.RowCount; i++)
            {
                for (int j = 0; j < dgv.ColumnCount; j++)
                {
                    //разделяя столбцы точкой с запятой
                    sb.Append(dgv[j, i].Value + ";");
                }
                sb.AppendLine();
            }
            //Возвращает строку содержащую таблицу в CSV формате
            return sb.ToString();
        }

        /// <summary>
        /// Формирует строку с HTML таблицей
        /// </summary>
        /// <returns>HTML строка</returns>
        private string DataGridToHTML()
        {
            //Создает конструктор строки
            StringBuilder sb = new StringBuilder();
            //Заносит HTML разметку в строку
            sb.AppendLine("<html><body><center><table border = '1' cellspasing = '0'>");
            //Создает строку HTML - таблицы с заголовками таблицы
            sb.AppendLine("<tr>");
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                sb.AppendLine("<th align = 'center' valign = 'middle'>"
                    + dgv.Columns[i].HeaderText + "</th>");
            }
            sb.AppendLine("</tr>");
            //Заполняет таблицу данными
            for (int i = 0; i < dgv.RowCount - 1; i++)
            {
                sb.AppendLine("<tr>");
                foreach (DataGridViewCell dc in dgv.Rows[i].Cells)
                    sb.AppendLine("<td align = 'center' valign = 'middle'>" + dc.Value + "</td>");
                sb.AppendLine("</tr>");
            }
            sb.AppendLine("<caption align = 'bottom'><br>Table: " +
                tableName + "</caption>");
            sb.AppendLine("</table></center></body></html>");
            //Возвращает строку содержащую таблицу в HTML формате
            return sb.ToString();
        }

        /// <summary>
        /// Записывает данные из таблицы в XML формат
        /// </summary>
        /// <param name="path">путь к файлу</param>
        private void DataGridToXML(string path)
        {
            //Записывает текущее содержимое таблицы DataTable в формате XML
            dt.WriteXml(path, XmlWriteMode.IgnoreSchema);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //Создает диалоговое окно для сохранения
            SaveFileDialog sfd = new SaveFileDialog();
            //устанавливает фильтры на сохранение
            sfd.Filter = "В CSV файл (*.csv)|*.csv|В HTML файл (*.HTML)|*.html|В XML файл (*.xml)|*.xml";
            //Если не произошла отмена сохранения, то
            if (sfd.ShowDialog() != DialogResult.Cancel)
            {
                //Выбор метода на сохранение
                switch (sfd.FilterIndex)
                {
                    case 1:
                        File.WriteAllText(sfd.FileName, DataGridToCSV(), Encoding.UTF8);
                        break;
                    case 2:
                        File.WriteAllText(sfd.FileName, DataGridToHTML());
                        break;
                    case 3:
                        DataGridToXML(sfd.FileName);
                        break;
                }
                //Сообщение об успешном сохранении
                MessageBox.Show("Данные успешно экспортированны");
            }
        }

        private void TsbtnSave_Click(object sender, EventArgs e)
        {
            if (tableName == "AvailableOffers")
                DAL.UpdateTable(false, dt);
        }


        private void btnUpd_Click(object sender, EventArgs e)
        {
            DAL.UpdateTable(true, dt);
        }

        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Введите цифры");
        }
    }
}