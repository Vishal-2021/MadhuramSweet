using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class PurchaseForReport
    {
        [Key]
        public int PrID { get; set; }
        public string PrBillNo { get; set; }
        public DateTime Prdate { get; set; }
        public int PrGrandTotal { get; set; }
        public int PrFinalTotal { get; set; }
     
    }
}