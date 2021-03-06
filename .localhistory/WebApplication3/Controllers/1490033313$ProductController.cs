﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication3.Models.ViewModel;
using WebApplication3.Models.EntityManager;
using System.Web.Script.Serialization;

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

        public Boolean AddProduct(String ProductDetails)
        {
            TempData["Value"] = 0;
            Boolean x = false;
            if (ModelState.IsValid)
            {
                ProductManager PM = new ProductManager();
                x = PM.AddProductDetails(ProductDetails);
            }

            if (x == true)
            {
                TempData["Value"] = 1;
            }
            return x;

        }

        public ActionResult EditProduct(String ProductDetails)
        {
            Boolean x = false;
            if (ModelState.IsValid)
            {
                ProductManager PM = new ProductManager();
                x = PM.EditProductDetails(ProductDetails);
            }

            return RedirectToAction("ProductIndex", "Product");
        }

    }
}