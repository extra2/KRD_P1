using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KRD_P1.View;

namespace KRD_P1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonManageUsers_Click(object sender, EventArgs e)
        {
            var manageUsersForm = new UserManageForm();
            manageUsersForm.Show();
        }

        private void buttonPackageControl_Click(object sender, EventArgs e)
        {
            new PackagesManageForm().Show();
        }
    }
}
