using System;
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
                    QI.Content = u.QuestionContent;
                    QI.PostedDate = u.PostDate;
                    QI.UserId = u.UserId;
                    QI.QuestionId = u.QuestionId;
                    QI.QuestionAuthor = u.QuestionAuthor;
                    questions.Add(QI);
                }
            }
            System.Diagnostics.Debug.WriteLine("productpv=" + questions);

            return questions;
        }


        public QuestionDataView GetQuestionDataView()
        {
            QuestionDataView QDV = new QuestionDataView();
            List<QuestionInfo> questions = GetAllQuestionsInfo();

            QDV.Questions = questions;

            return QDV;
        }

        public List<AnswerInfo> GetAllAnswersInfo()
        {
            List<AnswerInfo> answers = new List<AnswerInfo>();
            using (FASIDSEntities4 db = new FASIDSEntities4())
            {
                QuestionInfo QI;
                //var users = db.ProductDatas.ToList();

                foreach (PostQuestion u in db.PostQuestions)
                {
                    QI = new QuestionInfo();
                    QI.Subject = u.QuestionSubject;
                    QI.Content = u.QuestionContent;
                    QI.PostedDate = u.PostDate;
                    QI.UserId = u.UserId;
                    QI.QuestionId = u.QuestionId;
                    QI.QuestionAuthor = u.QuestionAuthor;
                    questions.Add(QI);
                }
            }
            System.Diagnostics.Debug.WriteLine("productpv=" + questions);

            return questions;
        }

        public QuestionAnswer GetQuestionAnswerInfo(int quest_id)
        {
            QuestionAnswer QA = new QuestionAnswer();
            using (FASIDSEntities4 db = new FASIDSEntities4())
            {
                var q = db.PostQuestions.Where(o => o.QuestionId.Equals(quest_id));
                if (q.Any())
                {
                    QA.QuestionId = q.FirstOrDefault().QuestionId;
                    QA.UserId = q.FirstOrDefault().UserId;
                    QA.Subject = q.FirstOrDefault().QuestionSubject;
                    QA.Content = q.FirstOrDefault().QuestionContent;
                    QA.PostedDate = q.FirstOrDefault().PostDate;
                    QA.QuestionAuthor = q.FirstOrDefault().QuestionAuthor;
                }
                List<AnswerInfo> answers = GetAllAnswersInfo(QA.QuestionId);
            }
            return QA;
        }


    }
}