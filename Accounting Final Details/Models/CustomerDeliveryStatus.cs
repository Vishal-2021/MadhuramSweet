using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class CustomerDeliveryStatus
    {
        [Key]
        public int CDS_ID { get; set; }

        public string CDS_Name { get; set; }
    }
}