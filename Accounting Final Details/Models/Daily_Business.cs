using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class Daily_Business
    {
        [Key]
        public int DB_ID { get; set; }
  
        public decimal Cash { get; set; }

        public decimal Gpay { get; set; }
  
        public decimal Zomato { get; set; }
      
        public decimal Card { get; set; }
      
        public decimal Paytm { get; set; }
       
        public decimal Swiggy { get; set; }

        public DateTime Dates { get; set; }


    }
}