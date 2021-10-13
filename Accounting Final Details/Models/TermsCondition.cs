using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class TermsCondition
    {
        [Key]
        public int TCID { get; set; }
        [Required]
        public string TurCon { get; set; }
        [Required]
        public int BTID { get; set; }

    }
}