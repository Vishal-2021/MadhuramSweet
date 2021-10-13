using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class SalesGST_Report
    {

        [Key]
        public int SalesGST_Rpt_ID { get; set; }
        public string SalesGST_Rpt_BillNo { get; set; }
        public DateTime SalesGST_Rpt_date { get; set; }
        public int SalesGST_Rpt_GrandTotal { get; set; }
        public int SalesGST_Rpt_FinalTotal { get; set; }
     //   public string SalesGST_Rpt_BillType { get; set; }

    }
}