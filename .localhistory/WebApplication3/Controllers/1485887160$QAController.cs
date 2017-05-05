using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models.ViewModel;
using WebApplication3.Models.EntityManager;

namespace WebApplication3.Controllers
{
    public class QAController : Controller
    {
        public ActionResult QAIndex()
        {
            return View();
        }

        public ActionResult PostQuestion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PostQuestion(Question q) 
        {

            return View();
        }

    }
}
