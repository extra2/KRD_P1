namespace KRD_P1.View
{
    partial class PackagesManageForm
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
            this.dataGridViewPackages = new System.Windows.Forms.DataGridView();
            this.PackageNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackageStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackageTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAddPackage = new System.Windows.Forms.Button();
            this.buttonEditPackage = new System.Windows.Forms.Button();
            this.buttonDeletePackage = new System.Windows.Forms.Button();
            this.textBoxPackageNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPackages)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPackages
            // 
            this.dataGridViewPackages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPackages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PackageNumber,
            this.PackageStatus,
            this.PackageTime});
            this.dataGridViewPackages.Location = new System.Drawing.Point(12, 81);
            this.dataGridViewPackages.Name = "dataGridViewPackages";
            this.dataGridViewPackages.Size = new System.Drawing.Size(346, 479);
            this.dataGridViewPackages.TabIndex = 0;
            // 
            // ID
            // 
            this.PackageNumber.HeaderText = "Numer Paczki";
            this.PackageNumber.Name = "PackageNumber";
            // 
            // PackageStatus
            // 
            this.PackageStatus.HeaderText = "Status";
            this.PackageStatus.Name = "PackageStatus";
            // 
            // PackageTime
            // 
            this.PackageTime.HeaderText = "Godzina";
            this.PackageTime.Name = "PackageTime";
            // 
            // buttonAddPackage
            // 
            this.buttonAddPackage.Location = new System.Drawing.Point(12, 12);
            this.buttonAddPackage.Name = "buttonAddPackage";
            this.buttonAddPackage.Size = new System.Drawing.Size(91, 36);
            this.buttonAddPackage.TabIndex = 1;
            this.buttonAddPackage.Text = "Dodaj";
            this.buttonAddPackage.UseVisualStyleBackColor = true;
            this.buttonAddPackage.Click += new System.EventHandler(this.buttonAddPackage_Click);
            // 
            // buttonEditPackage
            // 
            this.buttonEditPackage.Location = new System.Drawing.Point(109, 12);
            this.buttonEditPackage.Name = "buttonEditPackage";
            this.buttonEditPackage.Size = new System.Drawing.Size(91, 36);
            this.buttonEditPackage.TabIndex = 2;
            this.buttonEditPackage.Text = "Edytuj";
            this.buttonEditPackage.UseVisualStyleBackColor = true;
            this.buttonEditPackage.Click += new System.EventHandler(this.buttonEditPackage_Click);
            // 
            // buttonDeletePackage
            // 
            this.buttonDeletePackage.Location = new System.Drawing.Point(206, 12);
            this.buttonDeletePackage.Name = "buttonDeletePackage";
            this.buttonDeletePackage.Size = new System.Drawing.Size(91, 36);
            this.buttonDeletePackage.TabIndex = 3;
            this.buttonDeletePackage.Text = "Usuń";
            this.buttonDeletePackage.UseVisualStyleBackColor = true;
            this.buttonDeletePackage.Click += new System.EventHandler(this.buttonDeletePackage_Click);
            // 
            // textBoxPackageNumber
            // 
            this.textBoxPackageNumber.Location = new System.Drawing.Point(76, 55);
            this.textBoxPackageNumber.Name = "textBoxPackageNumber";
            this.textBoxPackageNumber.Size = new System.Drawing.Size(282, 20);
            this.textBoxPackageNumber.TabIndex = 4;
            this.textBoxPackageNumber.TextChanged += new System.EventHandler(this.textBoxPackageNumber_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nr paczki:";
            // 
            // PackagesManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(378, 572);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPackageNumber);
            this.Controls.Add(this.buttonDeletePackage);
            this.Controls.Add(this.buttonEditPackage);
            this.Controls.Add(this.buttonAddPackage);
            this.Controls.Add(this.dataGridViewPackages);
            this.Name = "PackagesManageForm";
            this.Text = "Zarządzaj paczkami";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPackages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPackages;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackageNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackageStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackageTime;
        private System.Windows.Forms.Button buttonAddPackage;
        private System.Windows.Forms.Button buttonEditPackage;
        private System.Windows.Forms.Button buttonDeletePackage;
        private System.Windows.Forms.TextBox textBoxPackageNumber;
        private System.Windows.Forms.Label label1;
    }
}