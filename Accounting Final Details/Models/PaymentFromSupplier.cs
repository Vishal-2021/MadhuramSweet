using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class PaymentFromSupplier
    {
        [DisplayName("ID")]
        [Key]
        public int PFSID { get; set; }
        [DisplayName("Supplier Name")]
        [Required]
        public int PFSName { get; set; }
        [DisplayName("Bill Number")]
        [Required]
        public string PFSBillNumber { get; set; }
        [DisplayName("Bill Amount")]
        [Required]
        public decimal PFSBillAmount { get; set; }
        [DisplayName("Payment Method")]
        [Required]
        public int PFSPaymentMethod { get; set; }
        [DisplayName("Payable Amt.")]
        [Required]
        public decimal PFSAmountPayable { get; set; }
        [DisplayName("Outstanding Amt.")]
        [Required]
        public decimal PFSOutStandingAmount { get; set; }
        [DisplayName("Status")]
        [Required]
        public int PFSStatus { get; set; }
        [DisplayName("Note")]
        [Required]
        public string PFSNote { get; set; }
        [DisplayName("Payment Date")]
        [Required]
        public DateTime PFSDateOfPayment { get; set; }



    }
}