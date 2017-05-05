﻿using System;
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
            QAManager QAM = new QAManager();
            QuestionDataView QDV = QAM.GetQuestionDataView();
            return View(QDV);
        }

        public ActionResult PostQuestion()
        {
            return View();
        }

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



        public ActionResult GetQA(int Qid)
        {
            QAManager QAM = new QAManager();
            QuestionAnswer QA = QAM.GetQuestionAnswerInfo(Qid);

            return PostAnswer(QA);
        }

        public ActionResult PostAnswer(QuestionAnswer QA)
        {
            return View(QA);
        }

    }
}
