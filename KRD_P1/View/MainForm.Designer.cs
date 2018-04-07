namespace KRD_P1
{
    partial class MainForm
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
            this.buttonManageUsers = new System.Windows.Forms.Button();
            this.buttonPackageControl = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonManageUsers
            // 
            this.buttonManageUsers.Location = new System.Drawing.Point(12, 98);
            this.buttonManageUsers.Name = "buttonManageUsers";
            this.buttonManageUsers.Size = new System.Drawing.Size(261, 23);
            this.buttonManageUsers.TabIndex = 0;
            this.buttonManageUsers.Text = "Zarzadzaj uzytkownikami";
            this.buttonManageUsers.UseVisualStyleBackColor = true;
            this.buttonManageUsers.Click += new System.EventHandler(this.buttonManageUsers_Click);
            // 
            // buttonPackageControl
            // 
            this.buttonPackageControl.Location = new System.Drawing.Point(12, 128);
            this.buttonPackageControl.Name = "buttonPackageControl";
            this.buttonPackageControl.Size = new System.Drawing.Size(261, 23);
            this.buttonPackageControl.TabIndex = 1;
            this.buttonPackageControl.Text = "Zarządzanie Paczkami";
            this.buttonPackageControl.UseVisualStyleBackColor = true;
            this.buttonPackageControl.Click += new System.EventHandler(this.buttonPackageControl_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 302);
            this.Controls.Add(this.buttonPackageControl);
            this.Controls.Add(this.buttonManageUsers);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonManageUsers;
        private System.Windows.Forms.Button buttonPackageControl;
    }
}