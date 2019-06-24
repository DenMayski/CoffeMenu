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

namespace Carcas_Kursacha
{
    public partial class TableForm : Form
    {
        string tableName;
        DataTable dt;

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
            dgv.DataSource = bs;
            bn.BindingSource = bs;
            if (tableName == "Orders")
            {
                tstbFilter.Visible = false;
                tsSep.Visible = false;
                tslblFilter.Visible = false;
            }
        }

        private string DataGridToCSV()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dgv.ColumnCount; i++)
                sb.Append(dgv.Columns[i].HeaderText + ";");
            sb.AppendLine();

            for (int i = 0; i < dgv.RowCount; i++)
            {
                for (int j = 0; j < dgv.ColumnCount; j++)
                {
                    sb.Append(dgv[j, i].Value + ";");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        private string DataGridToHTML()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<html><body><center><table border = '1' cellspasing = '0'>");
            sb.AppendLine("<tr>");
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                sb.AppendLine("<th align = 'center' valign = 'middle'>"
                    + dgv.Columns[i].HeaderText + "</th>");
            }
            sb.AppendLine("</tr>");

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
            return sb.ToString();
        }

        private void DataGridToXML(string path)
        {
            dt.WriteXml(path, XmlWriteMode.IgnoreSchema);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "В CSV файл (*.csv)|*.csv|В HTML файл (*.HTML)|*.html|В XML файл (*.xml)|*.xml";

            if (sfd.ShowDialog() != DialogResult.Cancel)
            {
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
                MessageBox.Show("Данные успешно экспортированны");
            }
        }

        private void tstbFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (tstbFilter.Text == "")
                    bs.Filter = string.Empty;
                else if (dt.Columns[0].DataType.ToString() == "System.String")
                    bs.Filter = dt.Columns[0].ColumnName +
                        " LIKE '%" + tstbFilter.Text + "%'";
                else
                    bs.Filter = dt.Columns[0].ColumnName + " = " + tstbFilter.Text;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}