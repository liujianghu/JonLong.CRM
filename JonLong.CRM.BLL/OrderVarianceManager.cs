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
            string containerNo,
            string container)
        {
            return OrderVarianceDataProvider.LoadDetail(customerCode, sendDate, bundleNo, containerNo, container);
        }

        public VarianceDetail LoadById(int id)
        {
            return OrderVarianceDataProvider.LoadById(id);
        }

        public List<VarianceOrderModel> LoadOrder(bool isSuperAdmin,string customerCode)
        {
            return OrderVarianceDataProvider.LoadOrder(isSuperAdmin,customerCode);
        }

        public List<VarianceDetail> LoadOrderDetail(string customerCode,
            DateTime sendDate,
            string bundleNo,
            string containerNo,
            string container)
        {
            return OrderVarianceDataProvider.LoadOrderDetail(customerCode,
                sendDate
                , bundleNo
                , containerNo
                , container);
        }

        public List<Shipment> LoadShipments(string customerCode)
        {
            return OrderVarianceDataProvider.LoadShipments(customerCode);
        }

        public List<VarianceDetail> LoadShipmentDetail(string customerCode,
                DateTime sendDate,
                string bundleNo,
                string containerNo,
                string container)
        {
            return OrderVarianceDataProvider.LoadShipmentDetail(customerCode,
                sendDate
                , bundleNo
                , containerNo
                , container);
        }

    }
}
