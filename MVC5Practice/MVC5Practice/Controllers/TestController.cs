using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Practice.Models;

namespace MVC5Practice.Controllers
{
    public class TestController : Controller
    {
        public JsonResult GetProductNames()
        {
            AdventureWorks2008R2Entities db = new AdventureWorks2008R2Entities();
            return Json(from em in db.Products
                select em.Name, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProductNamesWithId()
        {
            AdventureWorks2008R2Entities db = new AdventureWorks2008R2Entities();
            return Json(from em in db.Products
                        select new {label=em.Name, desc=em.ProductID}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JQueryUI()
        {
            ProductViewModel model = new ProductViewModel();

            AdventureWorks2008R2Entities db = new AdventureWorks2008R2Entities();
            model.Samples = (from prod in db.Products 
                             where prod.ListPrice > 0
                select new SampleProductViewModel() {
                    ProductId = prod.ProductID,
                    ProductName = prod.Name,
                    ProductNumber = prod.ProductNumber,
                    ListPrice = prod.ListPrice
                }).Take(5).ToArray();

            return View(model);
        }

        public ActionResult ItemsTable() {
            ProductViewModel model = new ProductViewModel();

            AdventureWorks2008R2Entities db = new AdventureWorks2008R2Entities();
            model.Samples = (from prod in db.Products
                             select new SampleProductViewModel()
                             {
                                 ProductId = prod.ProductID,
                                 ProductName = prod.Name,
                                 ProductNumber = prod.ProductNumber,
                                 ListPrice = prod.ListPrice
                             }).Take(5).ToArray();

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveProduct(ProductViewModel model) {
            return View("JQueryUI", model);
        }
	}
}