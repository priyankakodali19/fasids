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
        public string PostQuestion(string qa) 
        {
           //string  QAContent = "x0yz";
            var x = qa;
            string UserName = User.Identity.Name;
            if (ModelState.IsValid)
            {
                QAManager QAM = new QAManager();
                if (UserName!=null)
                {
                   // QAM.AddQuestion(qa.QASubject, qa.QAContent, UserName);
                    return RedirectToAction("QAIndex", "QA");

                }
                else
                    ModelState.AddModelError("", "Login Name already taken.");
            }
            return View();

            
        }

    }
}
