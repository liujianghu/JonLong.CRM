using JonLong.CRM.DAL;
using JonLong.CRM.Models;
using System;
using System.Collections.Generic;

namespace JonLong.CRM.BLL
{
    public class OrderVarianceManager
    {
        public static readonly OrderVarianceManager Instance = new OrderVarianceManager();

        public List<OrderVarianceModel> LoadOrderVariance(bool isSuperAdmin, string customerCode = "")
        {
            return OrderVarianceDataProvider.LoadOrderVariance(isSuperAdmin, customerCode);
        }

        public string Edit(VarianceEditModel model)
        {
            return OrderVarianceDataProvider.Edit(model);
        }

        public List<VarianceDetail> LoadDetail(
            string customerCode,
            DateTime sendDate,
            string bundleNo,
            string containerType,
            string containerNo)
        {
            return OrderVarianceDataProvider.LoadDetail(customerCode, sendDate, bundleNo, containerType, containerNo);
        }

        public VarianceDetail LoadById(int id)
        {
            return OrderVarianceDataProvider.LoadById(id);
        }

    }
}
