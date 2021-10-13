using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class SalesBillWithoutGstDtl_ChargesDisc
    {
        [Key]
        public int SalBiWiGst_BillID { get; set; }
        [Required]
        public decimal SalBiWiGst_DiscountRs { get; set; }
        [Required]
        public decimal SalBiWiGst_DiscountPer { get; set; }
        [Required]
        public string SalBiWiGst_ChargesName { get; set; }
        [Required]
        public decimal SalBiWiGst_ChargesAmt { get; set; }
        [Required]
        public string SalBiWiGst_BillNo { get; set; }
        [Required]
        public string SalBiWiGst_Note { get; set; }

        [Required]
        public int  SalBiWiGst_Status { get; set; }

    }
}