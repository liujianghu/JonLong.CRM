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

        public List<Warehouse> LoadCustomerList(string customerCode, string shoe)
        {
            return WarehouseDataProvider.LoadCustomerList(customerCode, shoe);
        }

        public Warehouse LoadById(int id)
        {
            return WarehouseDataProvider.LoadById(id);
        }

        public  void Insert(Warehouse info, string customerCode)
        {
             WarehouseDataProvider.Insert(info, customerCode);
        }

        public  void Update(Warehouse info, string customerCode)
        {
             WarehouseDataProvider.Update(info, customerCode);
        }

        public  void Delete(int id)
        {
             WarehouseDataProvider.Delete(id);
        }

    }
}
