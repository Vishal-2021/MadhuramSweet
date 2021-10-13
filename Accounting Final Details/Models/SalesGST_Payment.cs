using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class SalesGST_Payment
    {
        [Key]
        public int SaleGstPay_ID { get; set; }
        public int SaleGstPay_SupCustID { get; set; }
        public string SaleGstPay_CustSuppBillNo { get; set; }
        public decimal SaleGstPay_SuppCustPaidAmt { get; set; }




        [NotMapped]
        public string CustName { get; set; }

        [NotMapped]
        public decimal FinalTotal { get; set; }

        [NotMapped]
        public decimal SaleGstPay_SupCustBillAmt { get; set; }
        [NotMapped]
        public decimal SaleGstPay_SupCustoutstanding { get; set; }
        [NotMapped]
        public int SaleGstPay_SupCustStatus { get; set; }
        [NotMapped]
        public string SaleGstPay_Existance { get; set; }
    }
}