using System;

namespace JonLong.CRM.Models
{
    public class ArrivedModel
    {
        public int Id { get; set; }
        public string CustomerCode { get; set; }
        public DateTime SendDate { get; set; }
        public string BundleNo { get; set; }
        public string ContainerNo { get; set; }
        public string Container { get; set; }
        public decimal Filled { get; set; }
        public int SumPairs { get; set; }
        public string Confirm { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public string ContractNo { get; set; }
        public string InvoiceName { get; set; }
        public string Invoice { get; set; }
        public string PackingList { get; set; }
        public string BL { get; set; }
        public string CustomerName { get; set; }

    }
}
