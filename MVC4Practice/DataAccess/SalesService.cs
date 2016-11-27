using System;
using System.Linq;

namespace DataAccess
{
    public class SalesService
    {
        private AdventureWorks2008R2Entities data = new AdventureWorks2008R2Entities();

        public SalesOrderHeader CreateOrder()
        {
            SalesOrderHeader so = new SalesOrderHeader();
            so.Status = 0;
            so.OrderDate = DateTime.Now;
            so.DueDate = DateTime.Now;
            so.ShipDate = DateTime.Now;
            // hard code for testing purpose
            so.AccountNumber = "1234";
            so.CustomerID = 29672;
            so.ShipToAddressID = 985;
            so.BillToAddressID = 985;
            so.ShipMethodID = 5;
            so.rowguid = Guid.NewGuid();
            return so;
        }

        public void SaveSalesOrder(SalesOrderHeader so)
        {
            if (so.SalesOrderID == 0)
            {
                data.SalesOrderHeaders.Add(so);
            }
            so.ModifiedDate = DateTime.Now;
            data.SaveChanges();
        }

        public SalesOrderHeader GetSalesOrder(int id)
        {
            return data.SalesOrderHeaders.Single(x => x.SalesOrderID == id);
        }

        public SalesOrderHeader[] GetSalesOrderList(DateTime date1, DateTime date2)
        {
            var orders = data.SalesOrderHeaders.Where(x => x.OrderDate >= date1 && x.OrderDate <= date2);
            return orders.ToArray();
        }
    }
}
