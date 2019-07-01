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

namespace Menu_Coffee
{
    public partial class QueryForm : Form
    {
        public QueryForm()
        {
            InitializeComponent();
        }

        private void tsExecute_Click(object sender, EventArgs e)
        {
            List<string> commands = new List<string>();
            commands.AddRange(tbCmdText.Text.Split(';'));
            for (int i = 0; i < commands.Count; i++)
            {
                commands[i] = commands[i].Trim();
                if (commands[i] != "" && commands[i].Split(' ').Length > 1)
                {
                    string first = commands[i].Substring(0, commands[i].IndexOf(' ')).ToLower();
                    string second = commands[i].Substring(
                        commands[i].IndexOf(first) + 1, commands[i].IndexOf(' ')).ToLower();
                    try
                    {
                        if (first == "select" && second != "into")
                            dgv.DataSource = DAL.Select(commands[i]);
                        else
                            DAL.ExecuteCommand(commands[i]);
                        tsslbl.Text = "Команда выполнена";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        tsslbl.Text = "Команда содержит ошибки";
                    }
                }
            }
        }

        private void tsmiNew_Click(object sender, EventArgs e)
        {
            tbCmdText.Text = "";
            dgv.Columns.Clear();
            tsslbl.Text = "Файл создан";
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "sql file|*.sql|text file|*.txt|All|*.*";
            if (ofd.ShowDialog() != DialogResult.Cancel)
            {
                tbCmdText.Text = File.ReadAllText(ofd.FileName);
                dgv.Columns.Clear();
                tsslbl.Text = "Файл открыт";
            }
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "sql file|*.sql|text file|*.txt|All|*.*";
            if (sfd.ShowDialog() != DialogResult.Cancel)
            {
                File.WriteAllText(sfd.FileName, tbCmdText.Text);
                tsslbl.Text = "Файл сохранен";
            }
        }
    }
}