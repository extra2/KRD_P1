using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KRD_P1.View
{
    public partial class AddPackageForm : Form
    {
        public AddPackageForm()
        {
            InitializeComponent();
        }
        public AddPackageForm(string packageID, int clientID, string status)
        {
            InitializeComponent();
            textBoxPackageNumber.Text = packageID;
            textBoxPackageNumber.Enabled = false;
            textBoxClientID.Text = clientID.ToString();
            textBoxClientID.Enabled = false;
            textBoxStatus.Text = status;
        }
        private void buttonAddPackage_Click(object sender, EventArgs e)
        {
            var packages = new XMLProvider().XMLToPackages();
            var packageNumber = textBoxPackageNumber.Text;
            var clientID = textBoxClientID.Text;
            var status = textBoxStatus.Text;
            var time = DateTime.Now;
            if (packages.FirstOrDefault(n => n.PackageNumber == packageNumber) == null)
                packages.Add(new Package()
                {
                    ID_User = Int32.Parse(clientID),
                    PackageNumber = packageNumber,
                    Status = status,
                    StatusChangedDate = time
                });
            else
            {
                packages.FirstOrDefault(n => n.PackageNumber == packageNumber).Status = status;
                packages.FirstOrDefault(n => n.PackageNumber == packageNumber).StatusChangedDate = time;
            }
            new XMLProvider().PackageToXML(packages);
            this.Close();
        }
    }
}
