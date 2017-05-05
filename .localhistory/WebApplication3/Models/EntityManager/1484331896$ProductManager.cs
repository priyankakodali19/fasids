using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models.DB;
using WebApplication3.Models.ViewModel;

namespace WebApplication3.Models.EntityManager
{
    public class ProductManager
    {
        public List<ProductInfo> GetAllProductsInfo()
        {
            List<ProductInfo> products = new List<ProductInfo>();
            using (FASIDSEntities3 db = new FASIDSEntities3())
            {
                ProductInfo PI;
                //var users = db.ProductDatas.ToList();

                foreach (ProductData u in db.ProductDatas)
                {
                    PI = new ProductInfo();
                    PI.ProductId = u.ProductId;
                    PI.ProductName = u.ProductName;
                    PI.ProductManufacturer = u.ProductManufacturer;
                    PI.PhysicalForm = u.PhysicalForm;
                    PI.ProductControlMethod = u.ProductControlMethod;
                    PI.ProductUsage = u.ProductUsage;
                    PI.ProductUrl = u.ProductUrl;
                    PI.ImageUrl = u.ImageUrl;
                    PI.ProductCoverage = u.ProductCoverage;
                    System.Diagnostics.Debug.WriteLine("productpv=" + PI.ProductId);
                    products.Add(PI);
                }
            }
            System.Diagnostics.Debug.WriteLine("productpv=" + products);

            return products;
        }


        public ProductDataView GetProductDataView()
        {
            ProductDataView PDV = new ProductDataView();
            List<ProductInfo> products = GetAllProductsInfo();

            PDV.Products = products;
            System.Diagnostics.Debug.WriteLine("productpdvv=" + PDV.Products);
            return PDV;
        }
    }
}