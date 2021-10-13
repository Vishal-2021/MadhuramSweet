using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class OrderedProducts
    {
        [Key]
        public int OP_ID { get; set; }
        public int OP_OrderId { get; set; }
        public string OP_Img { get; set; }
        public string OP_Name { get; set; }
        public string OP_Desc { get; set; }
        public decimal OP_Qty { get; set; }
        public decimal OP_Rate { get; set; }
       
    }
}