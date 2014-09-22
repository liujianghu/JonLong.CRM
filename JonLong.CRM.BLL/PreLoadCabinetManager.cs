using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonLong.CRM.Models;
using JonLong.CRM.DAL;

namespace JonLong.CRM.BLL
{
    public class PreLoadCabinetManager
    {
        protected PreLoadCabinetManager() { }

        public static readonly PreLoadCabinetManager Instance = new PreLoadCabinetManager();

        public  List<PreLoadCabinet> LoadAviailable(string customerCode)
        {
            return PreLoadCabinetDataProvider.LoadAviailable(customerCode);
        }

        public  void Insert(PreLoadCabinet cabinet)
        {
            PreLoadCabinetDataProvider.Insert(cabinet);
        }

        public decimal GetFilled(string customerCode, string guid, string containerNo)
        {
            return PreLoadCabinetDataProvider.GetFilled(customerCode, guid, containerNo);
        }

    }
}
