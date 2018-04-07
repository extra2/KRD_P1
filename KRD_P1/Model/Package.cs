using System;

namespace KRD_P1.View
{
    public class Package
    {
        public string PackageNumber { get; set; } // as ID
        public int ID_User { get; set; }
        public string Status { get; set; }
        public DateTime StatusChangedDate { get; set; }
    }
}