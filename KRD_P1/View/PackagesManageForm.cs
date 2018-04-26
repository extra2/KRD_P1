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
using KRD_P1.Controller;

namespace KRD_P1.View
{
    public partial class PackagesManageForm : Form
    {
        private PackageController _pc = new PackageController();
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

            var packagesFromDB = getPackages();

            if (selectedRow >= packagesFromDB.Count || selectedRow < 0) return;
            var packageToEdit = packagesFromDB.FirstOrDefault(i => i.ID == Int32.Parse(dataGridViewPackages.Rows[selectedRow].Cells[0].Value.ToString()));
            new AddPackageForm(packageToEdit.ID, packageToEdit.IdUser, packageToEdit.Status).Show();
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
            List<Package> packagesFromDB = getPackages();

            int selectedRow = getSelectedItem();
            if (selectedRow == -1) return;

            if (selectedRow >= packagesFromDB.Count || selectedRow < 0) return;
            var packageToRemove = packagesFromDB.FirstOrDefault(i => i.ID == Int32.Parse(dataGridViewPackages.Rows[selectedRow].Cells[0].Value.ToString()));


            _pc.DeletePackage(packageToRemove.ID);
            Reload();
        }

        private void textBoxPackageNumber_TextChanged(object sender, EventArgs e)
        {
            var searchOption = textBoxPackageNumber.Text;

            List<Package> packagesFromDB = getPackages();
            packagesFromDB = packagesFromDB.Where(f => f.ID.ToString().Contains(searchOption)).ToList();

            dataGridViewPackages.Rows.Clear();
            if (packagesFromDB != null)
                foreach (var pack in packagesFromDB)
                {
                    dataGridViewPackages.Rows.Add(pack.ID, pack.Status, pack.StatusChangedDate.ToString("g"));
                }
        }

        public List<Package> getPackages()
        {
            return _pc.GetPackages();
        }
        private void Reload()
        {
            List<Package> packagesFromXML = getPackages();

            dataGridViewPackages.Rows.Clear();
            if (packagesFromXML != null)
                foreach (var pack in packagesFromXML)
                {
                    dataGridViewPackages.Rows.Add(pack.ID, pack.Status, pack.StatusChangedDate.ToString("g"));
                }
        }
    }
}
