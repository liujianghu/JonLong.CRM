using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JonLong.CRM.Models
{
    public class Shipment
    {
        public int Id { get; set; }
        public DateTime ETD { get; set; }
        public string BundleNo { get; set; }
        public string ContainerType { get; set; }
        public string ContainerNo { get; set; }
        public decimal Variance { get; set; }
        public int SumPairs { get; set; }
        public string ContractNo { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
    }
}
