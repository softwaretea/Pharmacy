using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PahramcyOnline.Models
{
    [MetadataType(typeof(UsertMetaData))]
    public partial class User
    {
    }
    public class UsertMetaData
    {
        public int Id_user { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string fisrt_name { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string last_name { get; set; }
        [Display(Name = "Email")]
        [Required]
        public string email_user { get; set; }
        [Display(Name = "Password")]
        [Required]
        public string password { get; set; }
        [Display(Name = "Phone Number")]
        [Required]
        public int phone_number { get; set; }
        [Display(Name = "Address")]
        [Required]
        public string address { get; set; }
        [Display(Name = "User Name")]
        [Required]
        public string User_Name { get; set; }


    }
}