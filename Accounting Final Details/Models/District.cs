using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class District
    {
        [Key]
        public int DistId { get; set; }
        public string DistName { get; set; }

        public int SId { get; set; }

    }
}