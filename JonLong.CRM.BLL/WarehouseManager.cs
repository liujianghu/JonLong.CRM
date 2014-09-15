using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonLong.CRM.Models;
using JonLong.CRM.DAL;

namespace JonLong.CRM.BLL
{
    public class WarehouseManager
    {
        protected WarehouseManager() { }
        public static readonly WarehouseManager Instance = new WarehouseManager();

        public List<Warehouse> LoadList(string customerCode, string shoe)
        {
            return WarehouseDataProvider.LoadList(customerCode, shoe);
        }
    }
}
