namespace Menu_Coffee
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сменаПользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTables = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClients = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.btnChangeSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.btnqueryToDB = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAction = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNewOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNewClient = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOffer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.btnTables,
            this.btnSettings,
            this.btnAction});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1056, 26);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сменаПользователяToolStripMenuItem,
            this.toolStripSeparator1,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(56, 22);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // сменаПользователяToolStripMenuItem
            // 
            this.сменаПользователяToolStripMenuItem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.сменаПользователяToolStripMenuItem.Name = "сменаПользователяToolStripMenuItem";
            this.сменаПользователяToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.сменаПользователяToolStripMenuItem.Text = "Смена пользователя";
            this.сменаПользователяToolStripMenuItem.Click += new System.EventHandler(this.ChangeUserToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(226, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // btnTables
            // 
            this.btnTables.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMenu,
            this.btnOrders,
            this.btnClients});
            this.btnTables.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTables.Name = "btnTables";
            this.btnTables.Size = new System.Drawing.Size(82, 22);
            this.btnTables.Text = "Таблицы";
            // 
            // btnMenu
            // 
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(180, 22);
            this.btnMenu.Text = "Меню";
            this.btnMenu.Click += new System.EventHandler(this.MenuToolStripMenuItem_Click);
            // 
            // btnOrders
            // 
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(180, 22);
            this.btnOrders.Text = "Заказы";
            this.btnOrders.Click += new System.EventHandler(this.OrdersToolStripMenuItem_Click);
            // 
            // btnClients
            // 
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(180, 22);
            this.btnClients.Text = "Клиенты";
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnChangeSettings,
            this.btnqueryToDB});
            this.btnSettings.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(96, 22);
            this.btnSettings.Text = "Настройки";
            // 
            // btnChangeSettings
            // 
            this.btnChangeSettings.Name = "btnChangeSettings";
            this.btnChangeSettings.Size = new System.Drawing.Size(180, 22);
            this.btnChangeSettings.Text = "Изменить";
            this.btnChangeSettings.Click += new System.EventHandler(this.ChangeSettingsToolStripMenuItem_Click);
            // 
            // btnqueryToDB
            // 
            this.btnqueryToDB.Name = "btnqueryToDB";
            this.btnqueryToDB.Size = new System.Drawing.Size(180, 22);
            this.btnqueryToDB.Text = "Запросы к БД";
            this.btnqueryToDB.Click += new System.EventHandler(this.btnQueryToDB_Click);
            // 
            // btnAction
            // 
            this.btnAction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewOrder,
            this.btnNewClient,
            this.btnOffer});
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(89, 22);
            this.btnAction.Text = "Действия";
            // 
            // btnNewOrder
            // 
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Size = new System.Drawing.Size(329, 22);
            this.btnNewOrder.Text = "Новый заказ";
            this.btnNewOrder.Click += new System.EventHandler(this.btnNewOrder_Click);
            // 
            // btnNewClient
            // 
            this.btnNewClient.Name = "btnNewClient";
            this.btnNewClient.Size = new System.Drawing.Size(329, 22);
            this.btnNewClient.Text = "Новый клиент";
            this.btnNewClient.Click += new System.EventHandler(this.btnNewClient_Click);
            // 
            // btnOffer
            // 
            this.btnOffer.Name = "btnOffer";
            this.btnOffer.Size = new System.Drawing.Size(329, 22);
            this.btnOffer.Text = "Редактирование спецпредложений";
            this.btnOffer.Click += new System.EventHandler(this.btnNewOffer_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImage = global::Menu_Coffee.Properties.Resources.coffee;
            this.ClientSize = new System.Drawing.Size(1056, 623);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Меню кофейни";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сменаПользователяToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnTables;
        private System.Windows.Forms.ToolStripMenuItem btnOrders;
        private System.Windows.Forms.ToolStripMenuItem btnMenu;
        private System.Windows.Forms.ToolStripMenuItem btnSettings;
        private System.Windows.Forms.ToolStripMenuItem btnChangeSettings;
        private System.Windows.Forms.ToolStripMenuItem btnqueryToDB;
        private System.Windows.Forms.ToolStripMenuItem btnClients;
        private System.Windows.Forms.ToolStripMenuItem btnAction;
        private System.Windows.Forms.ToolStripMenuItem btnNewOrder;
        private System.Windows.Forms.ToolStripMenuItem btnNewClient;
        private System.Windows.Forms.ToolStripMenuItem btnOffer;
    }
}

