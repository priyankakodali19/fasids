//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication3.Models.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class PostQuestion
    {
        public PostQuestion()
        {
            this.PostAnswers = new HashSet<PostAnswer>();
        }
    
        public string UserId { get; set; }
        public int QuestionId { get; set; }
        public string QuestionSubject { get; set; }
        public string QuestionContent { get; set; }
        public string QuestionAuthor { get; set; }
        public System.DateTime PostDate { get; set; }
    
        public virtual ICollection<PostAnswer> PostAnswers { get; set; }
        public virtual UserData UserData { get; set; }
    }
}
