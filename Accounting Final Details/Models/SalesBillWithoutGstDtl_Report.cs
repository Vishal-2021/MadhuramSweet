using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class SalesBillWithoutGstDtl_Report
    {
        [Key]
        public int SalBiWiGst_Rpt_ID { get; set; }
        public string SalBiWiGst_Rpt_BillNo { get; set; }
        public DateTime SalBiWiGst_Rpt_date { get; set; }
        public int SalBiWiGst_Rpt_GrandTotal { get; set; }
        public int SalBiWiGst_Rpt_FinalTotal { get; set; }
    }
}