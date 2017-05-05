using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.ViewModel
{
    public class QuestionInfo
    {
       
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime PostedDate { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public string QuestionAuthor { get; set; }
        
    }

    public class AnswerInfo
    {

        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime PostedDate { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public string QuestionAuthor { get; set; }

    }

    public class QuestionDataView
    {
        public IEnumerable<QuestionInfo> Questions { get; set; }
    }

    public class QuestionAnswer
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime PostedDate { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public string QuestionAuthor { get; set; }
        public IEnumerable<AnswerInfo> Answers { get; set; }
    
    }
}