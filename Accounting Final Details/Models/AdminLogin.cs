using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class AdminLogin
    {
        [Key]
        public int A_Id { get; set; }
        public string A_UserName { get; set; }
        public string A_Password { get; set; }
    }
}