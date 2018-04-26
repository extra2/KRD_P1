using System;

namespace KRD_P1.View
{
    public class Package
    {
        public int ID { get; set; }
        public int IdUser { get; set; }
        public string Status { get; set; }
        public DateTime StatusChangedDate { get; set; }
    }
}