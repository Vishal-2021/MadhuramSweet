using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class SalesGst_Tnc
    {
        [Key]
        public int SalesGst_ID { get; set; }
        public string SalesGst_BillNo { get; set; }
        public int SalesGst_TCID { get; set; }

    }
}