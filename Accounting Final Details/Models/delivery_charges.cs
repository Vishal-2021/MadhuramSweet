using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class delivery_charges
    {
        [Key]
        public int DC_ID { get; set; }
        public int Pincode { get; set; }
        public decimal DC_Charges { get; set; }

    }
}