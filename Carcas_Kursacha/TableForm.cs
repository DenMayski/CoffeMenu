﻿using System;
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

namespace Carcas_Kursacha
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
            System.Data.SqlClient.SqlDataAdapter da =
                new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM " + tableName, DAL.ConnString);
            da.Fill(ds);

            bs.DataSource = dt;

            dgv.DataSource = ds.Tables[0];
            bn.BindingSource = bs;
            dgv.Columns[0].Visible = false;
            if (tableName == "AvailableOffers")
            {
                dgv.ReadOnly = false;
                dgv.AllowUserToAddRows = true;
                dgv.AllowUserToDeleteRows = true;
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

        private void TableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Validate();
            this.bs.EndEdit();
            if (tableName == "AvailableOffers")
                DAL.UpdateTable(ds);
        }
    }
}