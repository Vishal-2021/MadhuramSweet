using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class Mesurement
    {
        [Key]
        public int MID { get; set; }

        public string MesureType { get; set; }
    }
}