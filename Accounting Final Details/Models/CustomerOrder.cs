using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class CustomerOrder
    {
        [Key]
        public int OrderID { get; set; }
        public int CustID { get; set; }
        public string CustNumber { get; set; }

        public int CustPincode { get; set; }
        public string CustAddress { get; set; }
        public string CustPaymentMode { get; set; }
        public string CustStatus { get; set; }
        public DateTime CustOrdDate { get; set; }

        public string DeliTime { get; set; }

        public decimal DeliveryCharges { get; set; }

        public int DeliveryStatus { get; set; }

        // edit 
        public decimal Ftotal { get; set; }




        [NotMapped]
        public string Cust_Name { get; set; }
        [NotMapped]
        public string CDS_Name { get; set; }

        
    }
}