namespace KRD_P1
{
    partial class AddUserForm
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.textBoxStreet = new System.Windows.Forms.TextBox();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.comboBoxRole = new System.Windows.Forms.ComboBox();
            this.checkBoxFirst = new System.Windows.Forms.CheckBox();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(8, 12);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(230, 20);
            this.textBoxName.TabIndex = 0;
            this.textBoxName.Text = "Imię";
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Location = new System.Drawing.Point(8, 38);
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(230, 20);
            this.textBoxSurname.TabIndex = 1;
            this.textBoxSurname.Text = "Nazwisko";
            // 
            // textBoxStreet
            // 
            this.textBoxStreet.Location = new System.Drawing.Point(8, 64);
            this.textBoxStreet.Name = "textBoxStreet";
            this.textBoxStreet.Size = new System.Drawing.Size(230, 20);
            this.textBoxStreet.TabIndex = 2;
            this.textBoxStreet.Text = "Ulica";
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Location = new System.Drawing.Point(8, 206);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(230, 42);
            this.buttonAddUser.TabIndex = 3;
            this.buttonAddUser.Text = "Dodaj";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // comboBoxRole
            // 
            this.comboBoxRole.FormattingEnabled = true;
            this.comboBoxRole.Items.AddRange(new object[] {
            "Item 1",
            "Item 2",
            "Item 3"});
            this.comboBoxRole.Location = new System.Drawing.Point(8, 179);
            this.comboBoxRole.Name = "comboBoxRole";
            this.comboBoxRole.Size = new System.Drawing.Size(230, 21);
            this.comboBoxRole.TabIndex = 4;
            // 
            // checkBoxFirst
            // 
            this.checkBoxFirst.AutoSize = true;
            this.checkBoxFirst.Location = new System.Drawing.Point(8, 156);
            this.checkBoxFirst.Name = "checkBoxFirst";
            this.checkBoxFirst.Size = new System.Drawing.Size(75, 17);
            this.checkBoxFirst.TabIndex = 5;
            this.checkBoxFirst.Text = "CheckBox";
            this.checkBoxFirst.UseVisualStyleBackColor = true;
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(8, 91);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(230, 20);
            this.textBoxLogin.TabIndex = 6;
            this.textBoxLogin.Text = "Login";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(8, 117);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(230, 20);
            this.textBoxPassword.TabIndex = 7;
            this.textBoxPassword.Text = "Password";
            // 
            // AddUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 272);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.checkBoxFirst);
            this.Controls.Add(this.comboBoxRole);
            this.Controls.Add(this.buttonAddUser);
            this.Controls.Add(this.textBoxStreet);
            this.Controls.Add(this.textBoxSurname);
            this.Controls.Add(this.textBoxName);
            this.Name = "AddUserForm";
            this.Text = "AddUserForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.TextBox textBoxStreet;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.ComboBox comboBoxRole;
        private System.Windows.Forms.CheckBox checkBoxFirst;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
    }
}