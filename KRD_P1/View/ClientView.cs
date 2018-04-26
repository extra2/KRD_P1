using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KRD_P1.View
{
    public partial class ClientView : Form
    {
        public ClientView(int clientID)
        {
            InitializeComponent();
            Reload(clientID);
        }

        private void Reload(int clientID)
        { 
            if (!File.Exists("packages.xml")) File.Create("packages.xml");
            List<Package> packagesFromXML = new XMLProvider().XMLToPackages();
            packagesFromXML = packagesFromXML.Where(e => e.IdUser == clientID).ToList();
            dataGridViewPackages.Rows.Clear();
            if (packagesFromXML != null)
                foreach (var pack in packagesFromXML)
                {
                    dataGridViewPackages.Rows.Add(pack.ID, pack.Status, pack.StatusChangedDate.ToString("g"));
                }
        }
    }
}
