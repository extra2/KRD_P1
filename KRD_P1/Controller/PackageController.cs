using KRD_P1.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KRD_P1.Model;

namespace KRD_P1.Controller
{
    public delegate void AddUser(User user);
    class PackageController
    {
        public PackagesFromDB _packageProvider = new PackagesFromDB();
        public List<Package> GetPackages()
        {
            return _packageProvider.GetPackages();
        }

        public void DeletePackage(int id)
        {
            _packageProvider.DeletePackage(id);
        }
    }
}
