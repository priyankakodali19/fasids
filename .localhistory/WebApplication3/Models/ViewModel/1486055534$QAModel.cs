using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.ViewModel
{
    public class Question
    {
       
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime PostedDate { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public string QuestionAuthor { get; set; }
        
    }
}