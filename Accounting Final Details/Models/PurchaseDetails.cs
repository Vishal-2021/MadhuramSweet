using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class PurchaseDetails
    {
        [Key]
        public int PrchsDtlID { get; set; }
        [Required]
        [DisplayName("Customer/Supplier Name")]
        public string SplrCustName { get; set; }
        [Required]
        [DisplayName("Bill No.")]
        public string BillNo { get; set; }
        [Required]
        [DisplayName("Date")]
        public DateTime PurchaseDate { get; set; }
        [Required]
        [DisplayName("Product")]
        
        public string ProductSelection { get; set; }
        // Add product to data table (Multiproduct)
        [NotMapped]
        public int ProductType { get; set; }
        [NotMapped]
        public Decimal ProductDiscount { get; set; }
        [NotMapped]
        public decimal ProductRate { get; set; }
        [NotMapped]
        public decimal ProductGst { get; set; }


        [NotMapped]
        public int ProductID { get; set; }

        [NotMapped]
        public int CustSuppID { get; set; }








        [Required]
        public int ProductQuntity { get; set; }

        public int NumberOfItems { get; set; }









        [Required]
        [DisplayName("Discount %")]
        public decimal PrchsOnTotalDiscountPer { get; set; } //% wise on grand total
        [Required]
        [DisplayName("Discount Rs.")]
        public decimal PrchsDiscountRs  { get; set; } // on grand total
        
        [Required]
        [DisplayName("Charges")]
        public decimal Charges { get; set; } // on grand total






        // Display purpose only



        [Required]
        [DisplayName("Grand Total")]
        public decimal PrchsDtlGrandTotal { get; set; }
        [Required]
        [DisplayName("Total Gst Amt.")]
        public decimal PrchsDtlTotalGstAmount { get; set; }
        [Required]
        [DisplayName("Final Amt.")]
        public decimal PrchsDtlFinalPurchaseAmt { get; set; }
    }
}