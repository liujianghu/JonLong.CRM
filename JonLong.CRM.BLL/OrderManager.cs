using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonLong.CRM.DAL;
using JonLong.CRM.Models;

namespace JonLong.CRM.BLL
{
    public class OrderManager
    {
        protected OrderManager()
        {
        }
        public static readonly OrderManager Instance = new OrderManager();

        public List<OrderStatistics> LoadOrderStatistics(
              string customerCode
            , DateTime? sendDateFrom
            , DateTime? sendDateTo
            , string banderNo
            , string containerNo)
        {
            if (String.IsNullOrEmpty(customerCode))
            {
                customerCode = "";
            }
            if (sendDateFrom == null || !sendDateFrom.HasValue)
            {
                sendDateFrom = DateTime.MinValue;
            }

            if (sendDateTo == null || !sendDateTo.HasValue)
            {
                sendDateTo = new DateTime(2099, 1, 1);
            }

            if (String.IsNullOrEmpty(banderNo))
            {
                banderNo = "";
            }

            if (String.IsNullOrEmpty(containerNo))
            {
                containerNo = "";
            }

            return OrderDataProvider.LoadOrderStatistics(
                  customerCode
                , sendDateFrom.Value
                , sendDateTo.Value
                , banderNo
                , containerNo).Where(t=>t.SendDate>=DateTime.Now.Date 
                    || (t.SendDate < DateTime.Now.Date && t.Complete == 0)
                    ).ToList();
        }

        public List<Order> LoadStatisticsDetail(
              DateTime sendDate
            , string customerCode
            , string bundlerNo
            , string containerType
            , string container)
        {
            return OrderDataProvider.LoadStatisticsDetail(
                  sendDate
                , customerCode
                , bundlerNo
                , containerType
                , container);
        }

        public Order LoadOrderStatisticsById(int id)
        {
            return OrderDataProvider.LoadOrderById(id);
        }

        public string UpdateOrder(Order order, string loginName)
        {
            return OrderDataProvider.UpdateOrder(order, loginName);
        }

        public string Delete(int id, string loginName)
        {
            return OrderDataProvider.Delete(id, loginName);
        }

        public List<string> LoadBundleNo(string customerCode)
        {
            return OrderDataProvider.LoadBundleNos(customerCode);
        }

        public string LoadContainer(string customerCode, string bundleNo)
        {
            return OrderDataProvider.LoadContainerType(customerCode, bundleNo);
        }

        public string Create(Order order, string loginName)
        {
            return OrderDataProvider.Create(order, loginName);
        }

        public string ConverToModel(string bundleNo)
        {
            return OrderDataProvider.ConvertToOrder(bundleNo);
        }
    }
}
