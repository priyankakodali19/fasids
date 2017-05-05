using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication3.Models.ViewModel;
using WebApplication3.Models.EntityManager;
using WebApplication3.Security; 

namespace WebApplication3.Controllers
{
    public class QAController : Controller
    {
        public ActionResult QAIndex()
        {
            QAManager QAM = new QAManager();
            QuestionDataView QDV = QAM.GetQuestionDataView();
            return View(QDV);
        }

        [AuthorizeRoles(Roles = "user,admin")]
        public ActionResult PostQuestion()
        {
            return View();
        }

        [AuthorizeRoles(Roles = "user,admin")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult PostQuestion(string qa_subject, string qa_content) 
        {
            string UserName = User.Identity.Name;
            if (ModelState.IsValid)
            {
                QAManager QAM = new QAManager();
                if (UserName!=null)
                {
                    QAM.AddQuestion(qa_subject, qa_content, UserName);
                    return RedirectToAction("QAIndex", "QA");

                }
                else
                    ModelState.AddModelError("", "User Name does not exist.");
            }
            return View();  
        }


        
        public ActionResult PostAnswer(int Qid)
        {
            if (User.Identity.IsAuthenticated)
            {
                TempData["Value"] = 0;
            }
            else
            {
                TempData["Value"] = 1;
            }

            QAManager QAM = new QAManager();
            QuestionAnswer QA = QAM.GetQuestionAnswerInfo(Qid);

            return View(QA);
        }

        [AuthorizeRoles(Roles = "user,admin")]
        [HttpPost]
        [ValidateInput(false)]
        public int PostAnswerToDb(string qa_content, int q_id)
        {
            string UserName = User.Identity.Name;
           // dynamic dynObj = JsonConvert.DeserializeObject(qa);
            if (ModelState.IsValid)
            {
                QAManager QAM = new QAManager();
                if (UserName != null)
                {
                    QAM.AddAnswer(q_id, qa_content, UserName);
                    return q_id;

                }
                else
                    ModelState.AddModelError("", "User Name does not exist.");
            }
            return q_id;
        }

        public ActionResult UnAuthorized()
        {
            TempData["Value"] = 1 ;
            return RedirectToAction("QAIndex", "QA");
        }

    }
}
