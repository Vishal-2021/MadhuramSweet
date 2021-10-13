using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class SalesGST_ChargeDisc
    {
        [Key]
        public int SalesGST_BillID { get; set; }
        [Required]
        public decimal SalesGST_DiscountRs { get; set; }
        [Required]
        public decimal SalesGST_DiscountPer { get; set; }
        [Required]
        public string SalesGST_ChargesName { get; set; }
        [Required]
        public decimal SalesGST_ChargesAmt { get; set; }
        [Required]
        public string SalesGST_BillNo { get; set; }
        [Required]
        public string SalesGST_Note { get; set; }
    }
}