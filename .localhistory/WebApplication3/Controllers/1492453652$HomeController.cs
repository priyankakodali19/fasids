using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models.ViewModel;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult OfficialBlog()
        {
            return View();
        }

        public ActionResult AntActivity()
        {
            return View();
        }

        public ActionResult QA()
        {
            return View();
        }


        public ActionResult AntDistribution()
        {
            return View();
        }






    }
}