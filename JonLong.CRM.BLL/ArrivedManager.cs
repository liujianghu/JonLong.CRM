using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonLong.CRM.DAL;
using JonLong.CRM.Models;

namespace JonLong.CRM.BLL
{
    public class ArrivedManager
    {
        protected ArrivedManager() { }
        public static readonly ArrivedManager Instance = new ArrivedManager();

        public List<ArrivedModel> LoadList(string customerCode, DateTime startETD
            , DateTime endETD, string bundleNo, string container)
        {
            return ArrivedDataProvider.LoadList(customerCode, startETD, endETD, bundleNo, container);
        }

        public List<ArrivedDetail> LoadDetail(string customerCode,
            DateTime sendDate
            , string bundleNo
            , string containerNo
            , string container)
        {
            return ArrivedDataProvider.LoadDetail(customerCode
                , sendDate
                , bundleNo
                , containerNo
                , container);
        }
    }
}
