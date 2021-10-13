using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class PaymentStatus
    {
        [Key]
        public int PayStId { get; set; }
        public string PayStName { get; set; }
    }
}