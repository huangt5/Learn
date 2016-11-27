using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using MVC4Practice.Models;

namespace MVC4Practice.Controllers
{
    public class SalesController : Controller
    {
        private SalesService _salesService = new SalesService();
        //
        // GET: /Sales/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            EditSalesOrderViewModel viewModel = new EditSalesOrderViewModel();
            SalesOrderHeader so = _salesService.CreateOrder();
            viewModel.SO = SalesModelConverter.ConverToModel(so);
            return View("EditSalesOrder", viewModel);
        }

        public ViewResult Edit(int id)
        {
            EditSalesOrderViewModel viewModel = new EditSalesOrderViewModel();
            viewModel.IsEdit = true;
            SalesOrderHeader so = _salesService.GetSalesOrder(id);
            viewModel.SO = SalesModelConverter.ConverToModel(so);

            // details
            viewModel.SODetails = SalesModelConverter.ConverToModel(so.SalesOrderDetails);
            
            return View("EditSalesOrder", viewModel);
        }

        [HttpPost]
        public ActionResult SaveSalesOrder(EditSalesOrderViewModel viewModel)
        {
            SalesOrderHeader so;
            if (viewModel.SO.SalesOrderID == 0)
            {
                so = _salesService.CreateOrder();
            }
            else
            {
               so = _salesService.GetSalesOrder(viewModel.SO.SalesOrderID);
            }
            SalesModelConverter.ApplyFromModel(so, viewModel.SO);
            _salesService.SaveSalesOrder(so);
            return View("Index");
        }

        [HttpPost]
        public JsonResult GetSalesman()
        {
            return Json(new {
                firstName = "terry",
                lastName = "huang"
            });
        }

        [HttpGet]
        public ViewResult SalesOrderList()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetSalesOrderList(DateTime date1, DateTime date2)
        {
            var rows = from so in _salesService.GetSalesOrderList(date1, date2)
                      select new {
                          id = so.SalesOrderID,
                          orderDate = so.OrderDate.ToString("yyyy-MM-dd"),
                          isOnline = so.OnlineOrderFlag ? "Yes" : ""
                      };
            return Json(new {
                page=Request["page"],
                rows,
                sidx=Request["sidx"],
                sord=Request["sord"],
            });
        }
    }
}
