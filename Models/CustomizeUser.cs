using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace PahramcyOnline.Models
{
    [MetadataType(typeof(UserMetaData))]
    public  partial class User
    {
    }
    public class UserMetaData { 
    public int Id_user { get; set; }
    [Display(Name = "First Name")]
    [Required]
    [StringLength(10,MinimumLength =4,ErrorMessage ="Short Name")]
    public string fisrt_name { get; set; }
    [Display(Name = "Last Name")]
    [Required]
    [StringLength(10, MinimumLength = 4, ErrorMessage = "Short Name")]
    public string last_name { get; set; }
    [Display(Name = "Email")]
    [DataType(DataType.EmailAddress)]
    //[RegularExpression(@"\b[\w\.-]+@[\w\.-]+\.\w{2,4}\b",ErrorMessage ="Invalid Email Format")]
    [Required]
    [StringLength(10, MinimumLength = 4, ErrorMessage = "Short Email")]
    public string email_user { get; set; }
    [Display(Name = "Password")]
    [Required]
    [StringLength(10, MinimumLength = 4, ErrorMessage = "Short Password")]
    [RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W]).{8,64})", ErrorMessage = "weak password")]
    public string password { get; set; }
    [Display(Name = "Phone Number")]
    [Required]
    public int phone_number { get; set; }
    [Display(Name = "Address")]
    [RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W]).{8,64})",ErrorMessage ="Invalid")]
    [Required]
    public string address { get; set; }
    [Display(Name = "User Name")]
    [StringLength(10, MinimumLength = 4, ErrorMessage = "Too short User Name")]
    [Required]
    public string User_Name { get; set; }
    }

}