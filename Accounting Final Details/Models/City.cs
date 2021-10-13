using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class AutoDropdown
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}