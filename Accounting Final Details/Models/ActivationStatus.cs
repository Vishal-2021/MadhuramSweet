using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class ActivationStatus
    {
        [Key]
        public int ActStsID { get; set; }

        public string ActStsName { get; set; }
    }
}