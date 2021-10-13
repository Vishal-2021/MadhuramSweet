using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class CustSuppPayment
    {
        [Key]
        public int SupCustPayID { get; set; }
        public int SupCustID { get; set; }
        public string SupCustBillNo { get; set; }
        public decimal SupCustPaidAmt { get; set; }
        


        [NotMapped]
        public decimal SupCustBillAmt { get; set; }
        [NotMapped]
        public decimal SupCustoutstanding { get; set; }
        [NotMapped]
        public int SupCustStatus { get; set; }
        [NotMapped]
        public string Existance { get; set; }


        [NotMapped]
        public string CustName { get; set; }

    }
}