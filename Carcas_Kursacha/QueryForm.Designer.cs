namespace Menu_Coffee
{
    partial class QueryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.tbCmdText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsExecute = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgv, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbCmdText, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(584, 362);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(3, 176);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(578, 183);
            this.dgv.TabIndex = 3;
            // 
            // tbCmdText
            // 
            this.tbCmdText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCmdText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCmdText.Location = new System.Drawing.Point(3, 23);
            this.tbCmdText.Multiline = true;
            this.tbCmdText.Name = "tbCmdText";
            this.tbCmdText.Size = new System.Drawing.Size(578, 147);
            this.tbCmdText.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(578, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Введите SQL команды, разделяя их точкой с запятой \";\"";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFile,
            this.tsExecute});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 29);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // tsFile
            // 
            this.tsFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsNew,
            this.tsOpen,
            this.tsSave});
            this.tsFile.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tsFile.Image = ((System.Drawing.Image)(resources.GetObject("tsFile.Image")));
            this.tsFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFile.Name = "tsFile";
            this.tsFile.Size = new System.Drawing.Size(74, 22);
            this.tsFile.Text = "Запрос";
            // 
            // tsNew
            // 
            this.tsNew.Name = "tsNew";
            this.tsNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsNew.Size = new System.Drawing.Size(206, 22);
            this.tsNew.Text = "Новый";
            this.tsNew.Click += new System.EventHandler(this.tsmiNew_Click);
            // 
            // tsOpen
            // 
            this.tsOpen.Name = "tsOpen";
            this.tsOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tsOpen.Size = new System.Drawing.Size(206, 22);
            this.tsOpen.Text = "Открыть";
            this.tsOpen.Click += new System.EventHandler(this.tsmiOpen_Click);
            // 
            // tsSave
            // 
            this.tsSave.Name = "tsSave";
            this.tsSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsSave.Size = new System.Drawing.Size(206, 22);
            this.tsSave.Text = "Сохранить";
            this.tsSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // tsExecute
            // 
            this.tsExecute.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tsExecute.Name = "tsExecute";
            this.tsExecute.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.tsExecute.Size = new System.Drawing.Size(100, 25);
            this.tsExecute.Text = "Выполнить";
            this.tsExecute.Click += new System.EventHandler(this.tsExecute_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslbl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 340);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(584, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslbl
            // 
            this.tsslbl.Name = "tsslbl";
            this.tsslbl.Size = new System.Drawing.Size(0, 17);
            // 
            // QueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "QueryForm";
            this.Text = "Запросы к БД";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox tbCmdText;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripDropDownButton tsFile;
        private System.Windows.Forms.ToolStripMenuItem tsNew;
        private System.Windows.Forms.ToolStripMenuItem tsOpen;
        private System.Windows.Forms.ToolStripMenuItem tsSave;
        private System.Windows.Forms.ToolStripMenuItem tsExecute;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslbl;
        private System.Windows.Forms.Label label1;
    }
}