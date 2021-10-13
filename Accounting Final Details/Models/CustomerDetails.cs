    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class CustomerDetails
    {
        [Key]
        [DisplayName("ID")]
        public int CustID { get; set; }
        [DisplayName("Customer Name")]
        [Required]
        public string CustName { get; set; }
        [DisplayName("Contact")]
        [Required]
        public string CustContact { get; set; }
        [DisplayName("EmailID")]
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string CustEmail { get; set; }
        [DisplayName("Address")]
        [Required]
        public string CustAddress { get; set; }
        [DisplayName("Pin Code")]
        [Required]
        public int CustPinCode { get; set; }
        [DisplayName("State")]
        [Required]
        public int CustState { get; set; }

        [DisplayName("District")]
        [Required]
        public int CustDistrict { get; set; }

        [DisplayName("Fssi No.")]
        [Required]
        public string CustFssaiNumber { get; set; }
        [DisplayName("GST No.")]
        [Required]
        public string CustGstNumber { get; set; }
        [DisplayName("Status")]
        public int CustStatus { get; set; }

       


    }
}