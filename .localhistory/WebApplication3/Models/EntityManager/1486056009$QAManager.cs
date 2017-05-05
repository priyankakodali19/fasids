﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models.DB;
using WebApplication3.Models.ViewModel;

namespace WebApplication3.Models.EntityManager
{
    public class QAManager
    {
        public void AddQuestion(string subject, string content, string user_name)
        {
            UserManager UM = new UserManager();
            int user_id = UM.GetUserID(user_name);

            using (FASIDSEntities4 db = new FASIDSEntities4())
            {
                try
                {
                    PostQuestion PQ = new PostQuestion();
                    PQ.UserId = user_id;
                    PQ.QuestionSubject = subject;
                    PQ.QuestionContent = content;
                    PQ.QuestionAuthor = user_name;
                    PQ.PostDate = DateTime.Now;

                    db.PostQuestions.Add(PQ);
                    db.SaveChanges();
                }
                catch (Exception e) 
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    
                }
            }
        }


        public List<QuestionInfo> GetAllQuestionsInfo()
        {
            List<QuestionInfo> questions = new List<QuestionInfo>();
            using (FASIDSEntities4 db = new FASIDSEntities4())
            {
                QuestionInfo QI;
                //var users = db.ProductDatas.ToList();

                foreach (PostQuestion u in db.PostQuestions)
                {
                    QI = new QuestionInfo();
                    QI.Subject = u.QuestionSubject;
                    QI.Content = u.QuestionSubject;
                    QI.PostedDate = u.QuestionSubject;
                    QI.UserId = u.QuestionSubject;
                    QI.QuestionId = u.QuestionSubject;
                    QI.QuestionAuthor
                    questions.Add(QI);
                }
            }
            System.Diagnostics.Debug.WriteLine("productpv=" + products);

            return products;
        }


        public ProductDataView GetProductDataView()
        {
            ProductDataView PDV = new ProductDataView();
            List<QuestionInfo> products = GetAllProductsInfo();

            PDV.Products = products;
            System.Diagnostics.Debug.WriteLine("productpdvv=" + PDV.Products);
            return PDV;
        }




    }
}