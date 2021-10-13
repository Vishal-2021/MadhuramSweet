using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class SaleWiGstTransactions
    {
        [Key]
        public int SalwiGst_TranID { get; set; }
        public int SalwiGst_CustSupID { get; set; }
        public decimal SalwiGst_TranReciAmt { get; set; }
        public int SalwiGst_TranPayMethod { get; set; }
        public string SalwiGst_Cheque { get; set; }
        public string SalwiGst_TransactionNote { get; set; }
        public DateTime SalwiGst_Date { get; set; }
        public string SalwiGst_BillNo { get; set; }

    }
}