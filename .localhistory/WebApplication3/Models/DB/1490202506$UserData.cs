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
    
    public partial class UserData
    {
        public UserData()
        {
            this.PolygonGeoJsons = new HashSet<PolygonGeoJson>();
            this.PostQuestions = new HashSet<PostQuestion>();
            this.PostAnswers = new HashSet<PostAnswer>();
            this.UserImages = new HashSet<UserImage>();
            this.NewPolygonGeoJsons = new HashSet<NewPolygonGeoJson>();
        }
    
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string UserCategory { get; set; }
        public string Password { get; set; }
    
        public virtual ICollection<PolygonGeoJson> PolygonGeoJsons { get; set; }
        public virtual ICollection<PostQuestion> PostQuestions { get; set; }
        public virtual ICollection<PostAnswer> PostAnswers { get; set; }
        public virtual ICollection<UserImage> UserImages { get; set; }
        public virtual ICollection<NewPolygonGeoJson> NewPolygonGeoJsons { get; set; }
    }
}
