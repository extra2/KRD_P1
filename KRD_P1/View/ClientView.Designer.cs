namespace KRD_P1.View
{
    partial class ClientView
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
            this.PackageTIme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPackages)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPackages
            // 
            this.dataGridViewPackages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPackages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PackageNumber,
            this.PackageStatus,
            this.PackageTIme});
            this.dataGridViewPackages.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewPackages.Name = "dataGridViewPackages";
            this.dataGridViewPackages.Size = new System.Drawing.Size(368, 426);
            this.dataGridViewPackages.TabIndex = 0;
            // 
            // ID
            // 
            this.PackageNumber.HeaderText = "Numer Paczki";
            this.PackageNumber.Name = "PackageNumber";
            // 
            // PackageStatus
            // 
            this.PackageStatus.HeaderText = "Status Paczki";
            this.PackageStatus.Name = "PackageStatus";
            // 
            // PackageTIme
            // 
            this.PackageTIme.HeaderText = "Godzina zmiany";
            this.PackageTIme.Name = "PackageTIme";
            this.PackageTIme.Width = 120;
            // 
            // ClientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 450);
            this.Controls.Add(this.dataGridViewPackages);
            this.Name = "ClientView";
            this.Text = "Moje zamównienia";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPackages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPackages;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackageNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackageStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackageTIme;
    }
}