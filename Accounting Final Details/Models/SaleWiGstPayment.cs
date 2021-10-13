using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class SaleWiGstPayment
    {
        [Key]
        public int SaleWiGstPayment_ID { get; set; }
        public int PaySalWiGst_SupCustID { get; set; }
        public string PaySalWiGst_CustSuppBillNo { get; set; }
        public decimal PaySalWiGst_SuppCustPaidAmt { get; set; }




        [NotMapped]
        public decimal PaySalWiGst_SupCustBillAmt { get; set; }
        [NotMapped]
        public decimal PaySalWiGst_SupCustoutstanding { get; set; }
        [NotMapped]
        public int PaySalWiGst_SupCustStatus { get; set; }
        [NotMapped]
        public string PaySalWiGst_Existance { get; set; }

    }
}