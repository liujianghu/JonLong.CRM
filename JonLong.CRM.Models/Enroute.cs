using System;

namespace JonLong.CRM.Models
{
    public class Enroute
    {
        public int Id { get; set; }
        public string KHJC { get; set; }
        public DateTime ETD { get; set; }
        public string BundleNo { get; set; }
        public string Container { get; set; }
        public string ContainerNo { get; set; }
        public decimal Filled { get; set; }
        public int SumPairs { get; set; }
        public string Receive { get; set; }
        public string ContractNo { get; set; }
        public string InvoiceName { get; set; }
        public string Invoice { get; set; }
        public string PackingList { get; set; }
        public string BL { get; set; }

    }
}
