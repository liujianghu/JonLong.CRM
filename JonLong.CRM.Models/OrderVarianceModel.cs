
using System;
namespace JonLong.CRM.Models
{
    public class OrderVarianceModel
    {
        public int Id { get; set; }
        public DateTime ETD { get; set; }
        public string BundleNo { get; set; }
        public string ContainerType { get; set; }
        public string ContainerNo { get; set; }
        public decimal Variance { get; set; }
        public int SumPairs { get; set; }
        public string ContractNo { get; set; }

        public string TGuid { get; set; }
        public string KHJC { get; set; }
        public string CustomerCode { get; set; }

    }
}
