using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class SaleWiGstTnC
    {
        [Key]
        public int SaleWiGstTnC_ID { get; set; }

        public string SaleWiGstTnC_BillNo { get; set; }
        public int SaleWiGstTnC_TCID { get; set; }
    }
}