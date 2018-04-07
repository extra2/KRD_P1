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
            int selectedRow = getSelectedItem();
            if (selectedRow == -1) return;

            if (!File.Exists("packages.xml")) File.Create("packages.xml");
            var usersInXml = File.ReadAllText("packages.xml");
            List<Package> packagesFromXML = new XMLProvider().XMLToPackages();

            if (selectedRow >= packagesFromXML.Count || selectedRow < 0) return;
            var packageToEdit = packagesFromXML.FirstOrDefault(i => i.PackageNumber == dataGridViewPackages.Rows[selectedRow].Cells[0].Value.ToString());
            new AddPackageForm(packageToEdit.PackageNumber, packageToEdit.ID_User, packageToEdit.Status).Show();
            Reload();
        }

        public int getSelectedItem()
        {
            try
            {
                return dataGridViewPackages.SelectedRows[0].Index;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        private void buttonDeletePackage_Click(object sender, EventArgs e)
        {
            List<Package> packagesFromXML = getPackages();

            int selectedRow = getSelectedItem();
            if (selectedRow == -1) return;

            if (selectedRow >= packagesFromXML.Count || selectedRow < 0) return;
            var packageToRemove = packagesFromXML.FirstOrDefault(i => i.PackageNumber == dataGridViewPackages.Rows[selectedRow].Cells[0].Value.ToString());
            packagesFromXML.Remove(packageToRemove);
            new XMLProvider().PackageToXML(packagesFromXML);
            Reload();
        }

        private void textBoxPackageNumber_TextChanged(object sender, EventArgs e)
        {
            var searchOption = textBoxPackageNumber.Text;

            List<Package> packagesFromXML = getPackages();
            packagesFromXML = packagesFromXML.Where(f => f.PackageNumber.Contains(searchOption)).ToList();

            dataGridViewPackages.Rows.Clear();
            if (packagesFromXML != null)
                foreach (var pack in packagesFromXML)
                {
                    dataGridViewPackages.Rows.Add(pack.PackageNumber, pack.Status, pack.StatusChangedDate.ToString("g"));
                }
        }

        public List<Package> getPackages()
        {
            if (!File.Exists("packages.xml")) File.Create("packages.xml");
            return new XMLProvider().XMLToPackages();
        }
        private void Reload()
        {
            List<Package> packagesFromXML = getPackages();

            dataGridViewPackages.Rows.Clear();
            if (packagesFromXML != null)
                foreach (var pack in packagesFromXML)
                {
                    dataGridViewPackages.Rows.Add(pack.PackageNumber, pack.Status, pack.StatusChangedDate.ToString("g"));
                }
        }
    }
}
