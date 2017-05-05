using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication3.Models.ViewModel;
using WebApplication3.Models.EntityManager;
using System.Web.Script.Serialization;
using WebApplication3.Security; 

namespace WebApplication3.Controllers
{
    public class ProductController : Controller
    {
        
        public ActionResult ProductIndex()
        {
            string user_name = User.Identity.Name;
            UserManager UM = new UserManager();
            string user_role = UM.GetUserRole(user_name);

            if (user_role.Equals("admin")) // TODO: Remove magic string
            {
                return RedirectToAction("ProductAdminView", "Product");
            }
            else
            {
                return RedirectToAction("ProductUserView", "Product");
            }
        }
        

        public ActionResult ProductAdminView()
        {
            ProductManager PM = new ProductManager();
            ProductDataView2 PDV = PM.GetProductDataView2();
            return View(PDV);

        }
        public ActionResult ProductUserView()
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

        public ActionResult DeleteProduct(int ProductId)
        {
            if (ModelState.IsValid)
            {
                ProductManager PM = new ProductManager();
                PM.DeleteProduct(ProductId);
            }

            return RedirectToAction("ProductIndex", "Product");
        }

    }
}