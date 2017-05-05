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
        public void AddQuestion(Question q, string user_name)
        {
            UserManager UM = new UserManager();
            int user_id = UM.GetUserID(user_name);

            using (FASIDSEntities4 db = new FASIDSEntities4())
            {
                PostQuestion PQ = new PostQuestion();
                PQ.UserId = user_id;
                PQ.QuestionSubject = q.QuestionSubject;
                PQ.QuestionContent = q.QuestionContent;
                PQ.QuestionAuthor = user_name;
                PQ.PostDate = DateTime.Now;

                db.PostQuestions.Add(PQ);
                db.SaveChanges();
            }
        }
    }
}