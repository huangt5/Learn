using System;
using System.Collections.Generic;
using DataAccess;
using TLib.Core.ObjectUtil;

namespace MVC4Practice.Models
{
    public class EditSalesOrderViewModel
    {
        public SalesOrderModel SO { get; set; }
        public List<SalesOrderDetailModel> SODetails { get; set; }
        public List<dynamic> OrderDetails { get; set; }
        public bool IsEdit { get; set; }
    }

    public class SalesOrderModel
    {
        public int SalesOrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string AccountNumber { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public int CustomerID { get; set; }
        public bool OnlineOrderFlag { get; set; }
        public int BillToAddressID { get; set; }
        public int ShipToAddressID { get; set; }
        public int ShipMethodID { get; set; }
    }

    public class SalesOrderDetailModel
    {
        public int SalesOrderDetailID { get; set; }
        public int ProductID { get; set; }
        public int SpecialOfferID { get; set; }
        public decimal UnitPrice { get; set; }
        public short OrderQty { get; set; }
    }

    public static class SalesModelConverter
    {
        public static SalesOrderModel ConverToModel(SalesOrderHeader so)
        {
            PrimitiveCloner cloner = new PrimitiveCloner(typeof(SalesOrderHeader), typeof(SalesOrderModel));
            SalesOrderModel model = new SalesOrderModel();
            cloner.Clone(so, model);
            return model;
        }

        public static void ApplyFromModel(SalesOrderHeader so, SalesOrderModel model)
        {
            PrimitiveCloner cloner = new PrimitiveCloner(typeof(SalesOrderModel), typeof(SalesOrderHeader));
            cloner.Clone(model, so);
        }

        public static List<SalesOrderDetailModel> ConverToModel(ICollection<SalesOrderDetail> salesOrderDetails)
        {
            List<SalesOrderDetailModel> detailsModel = new List<SalesOrderDetailModel>();
            PrimitiveCloner cloner = new PrimitiveCloner(typeof(SalesOrderDetail), typeof(SalesOrderDetailModel));
            foreach (var detail in salesOrderDetails)
            {
                SalesOrderDetailModel model = new SalesOrderDetailModel();
                cloner.Clone(detail, model);
                detailsModel.Add(model);
            }
            return detailsModel;
        }
    }
}