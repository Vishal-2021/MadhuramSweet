using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class ProductGST
    {
        [Key]
        public int ProdGstID { get; set; }
        public decimal ProdGst { get; set; }
    }
}