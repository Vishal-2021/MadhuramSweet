using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class PurchaseReportBill  // It's for Charges and discount
    {
        [Key]
        public int PrRBillID { get; set; }
        [Required]
        public decimal PrRBDiscountRs { get; set; }
        [Required]
        public decimal PrRBDiscountPer { get; set; }
        [Required]
        public decimal PrRBCharges { get; set; }
        [Required]
        public string PrRBBillNo { get; set; }
        [Required]
        public string PrRBNote { get; set; }


    }
}