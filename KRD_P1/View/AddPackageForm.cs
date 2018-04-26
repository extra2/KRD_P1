using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KRD_P1.Model;

namespace KRD_P1.View
{
    public partial class AddPackageForm : Form
    {
        public PackagesFromDB _packageProvider = new PackagesFromDB();
        public AddPackageForm()
        {
            InitializeComponent();
            textBoxClientID.Text = "Pole zostanie wygenerowane";
            textBoxClientID.Enabled = false;
        }
        public AddPackageForm(int packageID, int clientID, string status)
        {
            InitializeComponent();
            textBoxPackageNumber.Text = packageID.ToString();
            textBoxPackageNumber.Enabled = false;
            textBoxClientID.Text = clientID.ToString();
            textBoxClientID.Enabled = false;
            textBoxStatus.Text = status;
        }
        private void buttonAddPackage_Click(object sender, EventArgs e)
        {
            var packages = _packageProvider.GetPackages();
            var packageNumber = Int32.Parse(textBoxPackageNumber.Text);
            var clientID = textBoxClientID.Text;
            var status = textBoxStatus.Text;
            var time = DateTime.Now;
            if (packages.FirstOrDefault(n => n.ID == packageNumber) == null)
                _packageProvider.AddPackage(new Package()
                {
                    IdUser = Int32.Parse(clientID),
                    Status = status,
                    StatusChangedDate = time
                });
            else
            {
                var currPackage = packages.FirstOrDefault(n => n.ID == packageNumber);
                currPackage.Status = status;
                currPackage.StatusChangedDate = time;
                _packageProvider.UpdatePackage(currPackage);
            }
            Close();
        }
    }
}
