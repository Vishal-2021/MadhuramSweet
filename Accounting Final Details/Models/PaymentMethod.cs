using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class PaymentMethod
    {
        [Key]
        public int PayMId { get; set; }

        public string PayMName { get; set; }
    }
}