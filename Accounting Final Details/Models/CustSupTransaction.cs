using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class CustSupTransaction
    {
        [Key]
        public int TranId { get; set; }
        public int CustSuppId { get; set; }
        public decimal TranReciAmt { get; set; }
        public int TranPayMethod { get; set; }
       
        public string ChequeNo { get; set; }
        public string TranNote { get; set; }
        public DateTime TranDate { get; set; }
        public string TranBillNo { get; set; }



        [NotMapped]
        public DateTime PurDate { get; set; }

        [NotMapped]
        public decimal BillAmt { get; set; }


        [NotMapped]
        public string CustName { get; set; }

        [NotMapped]
        public string PayMethod { get; set; }






    }
}