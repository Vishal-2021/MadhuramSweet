using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class Product_Catagory
    {
        [Key]
        public int C_ID { get; set; }
        public string Category_Name { get; set; }
    }
}