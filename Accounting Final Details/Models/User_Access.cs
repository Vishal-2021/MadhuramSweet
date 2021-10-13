using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class User_Access
    {
        [Key]
        public int UA_ID { get; set; }
        public string UA_Name { get; set; }
        public string UA_Url { get; set; }

        [NotMapped]
        public int UserID { get; set; }

    }
}