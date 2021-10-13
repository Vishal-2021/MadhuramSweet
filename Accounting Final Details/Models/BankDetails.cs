using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class BankDetails
    {
        [Key]
        [DisplayName("ID")]
        public int BnkDID { get; set; }

        [DisplayName("Bank Name")]
        [Required]
        public string BnkName { get; set; }
        [DisplayName("Branch Name")]
        [Required]
        public string BnkBranchName { get; set; }
        [Required]
        [DisplayName("Address")]
        public string BnkAddress { get; set; }
        [Required]
        [DisplayName("IFSC Number")]
        public string BnkIFSCNumber { get; set; }
        [Required]
        [DisplayName("Account Number")]
        public string BnkAccountNumber { get; set; }

        public int OrgID { get; set; }

        [NotMapped]
        public string OrgName { get; set; }

    }
}