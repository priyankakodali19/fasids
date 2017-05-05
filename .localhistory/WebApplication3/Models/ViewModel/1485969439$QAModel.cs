using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.ViewModel
{
    public class Question
    {
       public string QuestionSubject { get; set; }
        [AllowHtml]
       public string QuestionContent { get; set; }
        
    }
}