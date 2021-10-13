using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class Feedback
    {
        [Key]
        public int F_ID { get; set; }
        public string F_CustName { get; set; }
        public string F_Experiece { get; set; }
        public string F_Comments { get; set; }
        public string F_Images { get; set; }
        public int F_Rating { get; set; }
        public DateTime F_Date { get; set; }

    }
}