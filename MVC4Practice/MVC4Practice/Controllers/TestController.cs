using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using MVC4Practice.Models;

namespace MVC4Practice.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Knockout_jqGridBinding()
        {
            int orderid = 48730;

            SalesService _salesService = new SalesService();
            EditSalesOrderViewModel viewModel = new EditSalesOrderViewModel();
            viewModel.IsEdit = true;
            SalesOrderHeader so = _salesService.GetSalesOrder(orderid);
            viewModel.SO = SalesModelConverter.ConverToModel(so);
            viewModel.OrderDetails = new List<dynamic>();
            foreach (var detail in so.SalesOrderDetails)
            {
                viewModel.OrderDetails.Add(new
                {
                    productId = detail.ProductID,
                    specialOfferId = detail.SpecialOfferID,
                    price = detail.UnitPrice,
                    qty = detail.OrderQty
                });
            }

            return View(viewModel);
        }

    }
}
