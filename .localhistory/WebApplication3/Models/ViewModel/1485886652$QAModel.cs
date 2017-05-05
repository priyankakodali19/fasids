using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.ViewModel
{
    public class PostQuestion
    {
        int UserId { get; set; }
        string QuestionSubject { get; set; }
        string QuestionContent { get; set; }
        string QuestionAuthor { get; set; }
        DateTime PostDate { get; set; }
    }
}