using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CRUDWITHJSONINWCF_Client.Models
{
    public class Product
    {[Display (Name="Id")]
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
       
    }
}