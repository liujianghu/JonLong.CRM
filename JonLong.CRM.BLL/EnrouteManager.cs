using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonLong.CRM.Models;
using JonLong.CRM.DAL;

namespace JonLong.CRM.BLL
{
    public class EnrouteManager
    {
        protected EnrouteManager() { }

        public static readonly EnrouteManager Instance = new EnrouteManager();

        public List<Enroute> LoadList(
                string customerCode,
                DateTime sendDate)
        {
            return EnrouteDataProvider.LoadList(customerCode, sendDate);
        }

        public void Receive(string loginName, string bundleNo, int id)
        {
            EnrouteDataProvider.Receive(loginName, bundleNo, id);
        }

        public List<EnrouteDetail> LoadDetail(string customerCode,
            DateTime sendDate
            , string bundleNo
            , string containerNo
            , string container)
        {
            return EnrouteDataProvider.LoadDetail(customerCode, sendDate
                , bundleNo
                , containerNo
                , container);
        }
    }
}
