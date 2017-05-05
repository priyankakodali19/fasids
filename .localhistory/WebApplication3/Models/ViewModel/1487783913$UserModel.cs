using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.ViewModel
{
    public class UserSignUp
    {
        [Required(ErrorMessage = "Please enter user name")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The password must be atleast of 6 characters long")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter valid Email Id")]
        [EmailAddress]
        [Display(Name = "EmailId")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Please choose User Category")]
        [Display(Name = "User Category")]
        public string UserCategory { get; set; }

    }

    public class UserSignIn
    {

        public int UserId { get; set; }
        [Required(ErrorMessage = "Please enter valid username")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter valid password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    public class UserProfileView
    {

        public int UserId { get; set; }
        [Required(ErrorMessage = "User Name not found")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "First Name not found")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name not found")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string UserCategory { get; set; }
        [Required(ErrorMessage = "Email Id not found")]
        [EmailAddress]
        [Display(Name = "EmailId")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Please enter old password")]
        [DataType(DataType.Password)]
        //[StringLength(20, MinimumLength = 6, ErrorMessage = "The password must be atleast 6 characters long")]
        [Display(Name = "Old Password")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Please enter new password")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The password must be atleast 6 characters long")]
        [Display(Name = "New Password")]
        [Compare("Password", ErrorMessage = "The new password must be different from old password")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Please re-enter new password")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The password must be atleast 6 characters long")]
        [Display(Name = "New Password")]
        [Compare("Password", ErrorMessage = "The new password and confirmation password do not match")]
        public string ConfirmNewPassword { get; set; }
    }

    public class ResetPassword
    {

      

        [Required(ErrorMessage = "Please enter old password")]
        [DataType(DataType.Password)]
        //[StringLength(20, MinimumLength = 6, ErrorMessage = "The password must be atleast 6 characters long")]
        [Display(Name = "Old Password")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Please enter new password")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The password must be atleast 6 characters long")]
        [Display(Name = "New Password")]
        [Compare("Password", ErrorMessage = "The new password must be different from old password")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Please re-enter new password")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The password must be atleast 6 characters long")]
        [Display(Name = "New Password")]
        [Compare("Password", ErrorMessage = "The new password and confirmation password do not match")]
        public string ConfirmNewPassword { get; set; }

    }

    public class UserSavedPolygonsInfo
    {
        
        public string GeoJsonId { get; set; }
        public string PolygonName { get; set; }
    }

    public class UserSavedPolygonsView
    {
        public IEnumerable<UserSavedPolygonsInfo> UserPolygons { get; set; }
    }

    public class EmailModel
    {
        
        public string EmailId { get; set; }
        
    }
}