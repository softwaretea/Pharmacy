using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PahramcyOnline.Models
{
    [MetadataType(typeof(AdminMetaData))]
    public  partial class Admin
    {
    }
    public class AdminMetaData
    {
        public int Id_admin { get; set; }
        [Display(Name="Email")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email_Admin { get; set; }
        [Display(Name = "Password")]
        //[StringLength(10, MinimumLength = 4, ErrorMessage = "Short Password")]
        //[RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W]).{8,64})",ErrorMessage ="weak password")]
        [Required]
        public string Password_Admin { get; set; }
        [Display(Name = "First Name")]
        //[StringLength(10, MinimumLength = 4, ErrorMessage = "Too short name")]
        [Required]
        public string First_Name { get; set; }
        [Display(Name = "Last Name")]
        //[StringLength(10, MinimumLength = 4, ErrorMessage = "Too short name")]
        [Required]
        public string Last_Name { get; set; }
    }
}