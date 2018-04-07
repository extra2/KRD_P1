using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KRD_P1.View
{
    public partial class PackagesManageForm : Form
    {
        public PackagesManageForm()
        {
            InitializeComponent();
            Reload();
        }

        private void buttonAddPackage_Click(object sender, EventArgs e)
        {
            new AddPackageForm().Show();
            Reload();
        }

        private void buttonEditPackage_Click(object sender, EventArgs e)
        {
            if (!File.Exists("packages.xml")) File.Create("packages.xml");
            var usersInXml = File.ReadAllText("packages.xml");
            List<Package> packagesFromXML = new XMLProvider().XMLToPackages();
            int selectedRow;
            try
            {
                selectedRow = dataGridViewPackages.SelectedRows[0].Index;
            }
            catch (Exception)
            {
                return;
            }

            if (selectedRow >= packagesFromXML.Count || selectedRow < 0) return;
            var packageToEdit = packagesFromXML.FirstOrDefault(i => i.PackageNumber == dataGridViewPackages.Rows[selectedRow].Cells[0].Value.ToString());
            new AddPackageForm(packageToEdit.PackageNumber,packageToEdit.ID_User, packageToEdit.Status).Show();
            Reload();
        }

        private void buttonDeletePackage_Click(object sender, EventArgs e)
        {
            if (!File.Exists("packages.xml")) File.Create("packages.xml");
            var usersInXml = File.ReadAllText("packages.xml");
            List<Package> packagesFromXML = new XMLProvider().XMLToPackages();
            int selectedRow;
            try
            {
                selectedRow = dataGridViewPackages.SelectedRows[0].Index;
            }
            catch (Exception)
            {
                return;
            }

            if (selectedRow >= packagesFromXML.Count || selectedRow < 0) return;
            var packageToRemove = packagesFromXML.FirstOrDefault(i => i.PackageNumber == dataGridViewPackages.Rows[selectedRow].Cells[0].Value.ToString());
            packagesFromXML.Remove(packageToRemove);
            new XMLProvider().PackageToXML(packagesFromXML);
            Reload();
        }

        private void textBoxPackageNumber_TextChanged(object sender, EventArgs e)
        {
            var searchOption = textBoxPackageNumber.Text;
            if (!File.Exists("packages.xml")) File.Create("packages.xml");
            List<Package> packagesFromXML = new XMLProvider().XMLToPackages();
            packagesFromXML = packagesFromXML.Where(f => f.PackageNumber.Contains(searchOption)).ToList();
            dataGridViewPackages.Rows.Clear();
            if (packagesFromXML != null)
                foreach (var pack in packagesFromXML)
                {
                    dataGridViewPackages.Rows.Add(pack.PackageNumber, pack.Status, pack.StatusChangedDate.ToString("g"));
                }
        }

        private void Reload()
        {
                if (!File.Exists("packages.xml")) File.Create("packages.xml");
                List<Package> packagesFromXML = new XMLProvider().XMLToPackages();
                dataGridViewPackages.Rows.Clear();
                if (packagesFromXML != null)
                    foreach (var pack in packagesFromXML)
                    {
                        dataGridViewPackages.Rows.Add(pack.PackageNumber, pack.Status, pack.StatusChangedDate.ToString("g"));
                    }
            //dataGridViewPackages
        }
    }
}
