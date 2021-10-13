using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class PurchaseOldRate
    {
        [Key]
        public int PORID { get; set; }

        [Required]
        [DisplayName("Product Name")]
        public int PName { get; set; }   // Product Name
        [Required]
        [DisplayName("Old Rate")]
        public decimal OldPRate { get; set; }
        [Required]
        [DisplayName("New Rate")]
        public decimal NewPRate { get; set; }
        [Required]
        [DisplayName("Bill No.")]
        public string BillNo { get; set; }
        [Required]
        [DisplayName("Supplier Name")]
        public int SupplierName { get; set; }
        [Required]
        [DisplayName("Date")]
        public DateTime  PDate { get; set; }



}
}