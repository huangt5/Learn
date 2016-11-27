using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5Practice.Models
{
    public class ProductViewModel
    {
        public string ProductName { get; set; }
        public DateTime SellStartDate { get; set; }

        public SampleProductViewModel[] Samples { get; set; }
    }

    public class SampleProductViewModel {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductNumber { get; set; }
        public decimal ListPrice { get; set; }
        public DateTime Date { get; set; }
    }
}