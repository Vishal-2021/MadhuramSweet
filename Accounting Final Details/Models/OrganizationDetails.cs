using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class OrganizationDetails
    {
        [Key]
        public int OrgID { get; set; }
        [DisplayName("Organization Name")]
        [Required]
        public string OrgName { get; set; }
        [DisplayName("Contact")]
        [Required]
        public string OrgContact { get; set; }
        [DisplayName("EmailID")]
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string OrgEmailID { get; set; }
        [DisplayName("Address")]
        [Required]
        public string OrgAddress { get; set; }
        [DisplayName("Fssai No.")]
        [Required]
        public string OrgFssaiNumber { get; set; }
        [DisplayName("Gst No.")]
        [Required]
        public string OrgGstNumber { get; set; }
        [DisplayName("Pin Code")]
        [Required]
        public string OrgPinCode { get; set; }
        [DisplayName("State")]
        [Required]
        public int OrgState { get; set; }
        [DisplayName("Image")]
        [Required]
        public byte[] OrgImage { get; set; }
        [DisplayName("Status")]
        [Required]
        public int OrgStatus { get; set; }

        [DisplayName("Signature")]
        [Required]
        public byte[] OrgDegitalSignature { get; set; }



    }
}