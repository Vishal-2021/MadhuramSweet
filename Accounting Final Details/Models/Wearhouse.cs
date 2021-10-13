using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
   
        public class Wearhouse
        {
            public int Id { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string Address { get; set; }
            public bool Status { get; set; }
        }
    
}