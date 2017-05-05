﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication3.Models.ViewModel;
using WebApplication3.Models.EntityManager;

namespace WebApplication3.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ProductIndex()
        {
            ProductManager PM = new ProductManager();
            ProductDataView2 PDV = PM.GetProductDataView2();
            return View(PDV);
        }

        public Boolean AddProduct(String product_details)
        {
            Boolean x = 0;
            if (ModelState.IsValid)
            {
                ProductManager PM = new ProductManager();
                x = PM.AddProductDetails(product_details);
            }
            return x;

        }

    }
}