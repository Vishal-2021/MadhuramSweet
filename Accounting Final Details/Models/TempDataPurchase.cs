using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class TempDataPurchase
    {
        [Key]
        public int TempPurID { get; set; }
        public int TempPurSuppCustName { get; set; }
        public string TempPurBillNo { get; set; }
        public int TempPurProductID { get; set; }
        public Decimal TempPurProductRate { get; set; } // Rate of the product
        public Decimal TempPurDiscount { get; set; } 
        public decimal TempPurQuantity { get; set; }
        public decimal TempPurGstRs { get; set; }
        public Decimal TempPurTotal { get; set; } // Total of Purchase data
        public DateTime TempPurDate { get; set; }
       
        [ForeignKey("wearhouse")]
        public int? WearhouseRefID { get; set; }
        public Wearhouse wearhouse { get; set; }

        
    }
}