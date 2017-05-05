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
    }
}