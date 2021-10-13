using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class BillTypes
    {
        [Key]
        public int BTID { get; set; }
        public string BillTypeName { get; set; }
        
    }
}