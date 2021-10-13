using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class SalesGST_Transactions
    {
   
        [Key]
        public int SGstTran_TranID { get; set; }
        public int SGstTran_CustSupID { get; set; }
        public decimal SGstTran_TranReciAmt { get; set; }
        public int SGstTran_TranPayMethod { get; set; }
        public string SGstTran_Cheque { get; set; }
        public string SGstTran_TransactionNote { get; set; }
        public DateTime SGstTran_Date { get; set; }
        public string SGstTran_BillNo { get; set; }

        [NotMapped]
        public string SGstTran_PayMethName { get; set; }



        [NotMapped]
        public string CustName { get; set; }
        [NotMapped]
        public decimal SalesGST_Rpt_FinalTotal { get; set; }
        [NotMapped]
        public DateTime SaleGST_Date { get; set; }







    }
}