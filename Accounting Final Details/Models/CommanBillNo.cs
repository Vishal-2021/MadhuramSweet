using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class CommanBillNo
    {
        [Key]
        public int ComBiNo_ID { get; set; }
        public string ComBiNo_BillNo { get; set; }
        public decimal ComBiNo_FinalAmt { get; set; }
        public int ComBiNo_CustSuppID { get; set; }
        public string ComBiNo_BillID { get; set; }
        public int DispStatus { get; set; }




        [NotMapped]
        public string Notes { get; set; }
        [NotMapped]
        public DateTime Fdate { get; set; }
        [NotMapped]
        public DateTime Ldate { get; set; }
        [NotMapped]
        public DateTime Sale_date { get; set; }
        [NotMapped]
        public string CustSupp_Name { get; set; }





    }
}