using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.ViewModel
{
    public class ProductInfo
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductManufacturer { get; set; }
        public string PhysicalForm { get; set; }
        public string ProductControlMethod { get; set; }
        public string ProductUsage { get; set; }
        public string ProductCoverage { get; set; }
        public string ProductUrl { get; set; }
        public string ImageUrl { get; set; }
    }

    public class ProductDataView
    {
        public IEnumerable<ProductInfo> Products { get; set; }
    }
}