namespace Carcas_Kursacha
{
    partial class AuthForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthForm));
            this.label1 = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.chbViewPassword = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.chbClient = new System.Windows.Forms.CheckBox();
            this.mtbPassword = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(20, 63);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(45, 13);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Пароль";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(101, 19);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(221, 20);
            this.tbLogin.TabIndex = 2;
            this.tbLogin.Text = "Elena";
            this.tbLogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLoginAndPassword_KeyPress);
            // 
            // chbViewPassword
            // 
            this.chbViewPassword.AutoSize = true;
            this.chbViewPassword.Location = new System.Drawing.Point(23, 97);
            this.chbViewPassword.Name = "chbViewPassword";
            this.chbViewPassword.Size = new System.Drawing.Size(114, 17);
            this.chbViewPassword.TabIndex = 4;
            this.chbViewPassword.Text = "Показать пароль";
            this.chbViewPassword.UseVisualStyleBackColor = true;
            this.chbViewPassword.CheckedChanged += new System.EventHandler(this.chbViewPassword_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(198, 120);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(23, 120);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(124, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Войти";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // chbClient
            // 
            this.chbClient.AutoSize = true;
            this.chbClient.Location = new System.Drawing.Point(207, 97);
            this.chbClient.Name = "chbClient";
            this.chbClient.Size = new System.Drawing.Size(115, 17);
            this.chbClient.TabIndex = 5;
            this.chbClient.Text = "Войти как клиент";
            this.chbClient.UseVisualStyleBackColor = true;
            this.chbClient.CheckedChanged += new System.EventHandler(this.chbClient_CheckedChanged);
            // 
            // mtbPassword
            // 
            this.mtbPassword.Location = new System.Drawing.Point(101, 59);
            this.mtbPassword.Name = "mtbPassword";
            this.mtbPassword.PasswordChar = '*';
            this.mtbPassword.Size = new System.Drawing.Size(221, 20);
            this.mtbPassword.TabIndex = 3;
            this.mtbPassword.Text = "123456";
            this.mtbPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLoginAndPassword_KeyPress);
            // 
            // AuthForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(334, 156);
            this.Controls.Add(this.mtbPassword);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chbClient);
            this.Controls.Add(this.chbViewPassword);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 190);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 190);
            this.Name = "AuthForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AuthForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.CheckBox chbViewPassword;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox chbClient;
        private System.Windows.Forms.MaskedTextBox mtbPassword;
    }
}