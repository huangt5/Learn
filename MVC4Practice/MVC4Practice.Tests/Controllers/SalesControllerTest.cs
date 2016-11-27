using System;
using MVC4Practice.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TLib.Web.Mvc;

namespace MVC4Practice.Tests.Controllers
{
    [TestClass]
    public class SalesControllerTest
    {
        private SalesController _controller = new SalesController();

        [TestMethod]
        public void TestGetSalesOrderList()
        {
            var result = _controller.GetSalesOrderList(DateTime.Parse("2012-1-1"), DateTime.Now);
            Console.WriteLine(result.ToJsonString());
        }
    }
}
