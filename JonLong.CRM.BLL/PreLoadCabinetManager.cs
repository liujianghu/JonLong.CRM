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

        public Tuple<List<PreLoadCabinet>, List<PreLoadCabinet>> LoadAviailable(string customerCode)
        {
            return PreLoadCabinetDataProvider.LoadAviailable(customerCode);
        }

        public int Insert(PreLoadCabinet cabinet)
        {
            return PreLoadCabinetDataProvider.Insert(cabinet);
        }

        public void Update(PreLoadCabinet cabinet)
        {
            if (cabinet == null ||cabinet.Id <=0 || cabinet.Total <=0)
            {
                return;
            }
            PreLoadCabinetDataProvider.Update(cabinet);
        }

        public void Delete(int id)
        {
            if (id <=0)
            {
                return;
            }
            PreLoadCabinetDataProvider.Delete(id);
        }

        public float GetFilled(string customerCode, string guid, string containerNo)
        {
            return PreLoadCabinetDataProvider.GetFilled(customerCode, guid, containerNo) ;
        }

        public CabinetTitle LoadTitle(string khbh)
        {
            return PreLoadCabinetDataProvider.LoadTitle(khbh);
        }

    }
}
