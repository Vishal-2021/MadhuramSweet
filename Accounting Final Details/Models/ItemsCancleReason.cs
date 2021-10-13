using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class ItemsCancleReason
    {
        [Key]
        public int ICR_ID { get; set; }
        public int ICR_OrdID { get; set; }
        public string ICR_Reason { get; set; }
    }
}