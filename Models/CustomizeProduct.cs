using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PahramcyOnline.Models
{
   [MetadataType(typeof(productMetaData))]
    public partial class product
    {
           //add new properties
    }
    public class productMetaData
    {
        //edit properties of product
        public int Id { get; set; }
        [Display(Name = "Product Name")]
        [Required]
        public string pro_TradName { get; set; }
        [Display(Name = "Price")]
        [Required]
        [Range(1,1000000,ErrorMessage="Invalid Value")]
        public double pro_prices { get; set; }
        [Display(Name = "Quantity")]
        [Required]
        
        [Range(1,100000000,ErrorMessage="Invalid Value")]
        public int pro_quantity { get; set; }
        [Display(Name = "Company")]
        [Required]
        public string pro_company { get; set; }
        [Display(Name = "Pharmacology")]
        [Required]
        public string pro_pharmacology { get; set; }
        [Display(Name = "Type")]
        [Required]
        public string pro_type { get; set; }
        [Display(Name = "Generic Name")]
        [Required]
        public string pro_GenericName { get; set; }
        [Display(Name = "Image")]
        
        public string pro_image { get; set; }

    }
}