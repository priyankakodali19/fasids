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


        public List<DisplayQuestionInfo> GetAllQuestionsInfo()
        {
            List<DisplayQuestionInfo> questions = new List<DisplayQuestionInfo>();
            using (FASIDSEntities4 db = new FASIDSEntities4())
            {
                DisplayQuestionInfo QI;
                //var users = db.ProductDatas.ToList();

                foreach (PostQuestion u in db.PostQuestions)
                {
                    QI = new DisplayQuestionInfo();
                    QI.Subject = u.QuestionSubject;
                    QI.Content = u.QuestionContent;
                    QI.PostedDate = u.PostDate;
                    QI.UserId = u.UserId;
                    QI.QuestionId = u.QuestionId;
                    QI.QuestionAuthor = u.QuestionAuthor;
                    QI.AnswersCount = GetAnswersCount(u.QuestionId);
                    questions.Add(QI);
                }
            }
            System.Diagnostics.Debug.WriteLine("productpv=" + questions);

            return questions;
        }

        public int GetAnswersCount(int qid)
        {
            int count = 0;
            using (FASIDSEntities4 db = new FASIDSEntities4())
            {
                var a = db.PostAnswers.Where(o => o.QuestionId.Equals(qid));
                if (a.Any())
                {
                   
                    //var users = db.ProductDatas.ToList();

                    foreach (PostAnswer u in db.PostAnswers)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        public QuestionDataView GetQuestionDataView()
        {
            QuestionDataView QDV = new QuestionDataView();
            List<DisplayQuestionInfo> questions = GetAllQuestionsInfo();

            QDV.Questions = questions;

            return QDV;
        }

        public List<AnswerInfo> GetAllAnswersInfo(int quest_id)
        {
            List<AnswerInfo> answers = new List<AnswerInfo>();
            using (FASIDSEntities4 db = new FASIDSEntities4())
            {
                var a = db.PostAnswers.Where(o => o.QuestionId.Equals(quest_id));
                if (a.Any())
                {
                    AnswerInfo AI;
                    //var users = db.ProductDatas.ToList();

                    foreach (PostAnswer u in db.PostAnswers)
                    {
                        AI = new AnswerInfo();

                        AI.Content = u.AnswerContent;
                        AI.PostedDate = u.AnswerPostDate;
                        AI.UserId = u.UserId;
                        AI.QuestionId = u.QuestionId;
                        AI.AnswerAuthor = u.AnswerAuthor;
                        answers.Add(AI);
                    }
                }
                
            }
           

            return answers;
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
                QA.Answers = answers;
            }
            return QA;
        }

        public void AddAnswer(int ques_id, string content, string user_name)
        {
            UserManager UM = new UserManager();
            int user_id = UM.GetUserID(user_name);

            using (FASIDSEntities4 db = new FASIDSEntities4())
            {
                try
                {
                    PostAnswer PA = new PostAnswer();
                    PA.UserId = user_id;
                    PA.QuestionId = ques_id;
                    PA.AnswerAuthor = user_name;
                    PA.AnswerContent = content;
                    PA.AnswerPostDate = DateTime.Now;

                    db.PostAnswers.Add(PA);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);

                }
            }
        }
    }
}