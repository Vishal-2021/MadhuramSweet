using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class State
    {
        [Key]
        public int SId { get; set; }
        public string SName { get; set; }
    }
}