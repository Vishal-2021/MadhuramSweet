using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class Registration
    {
        [Key]
        public int RID { get; set; }

        [Required]
        [DisplayName("Full Name")]
        [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Not a valid First Name")]
        public string Name { get; set; }
        [DisplayName("Email Address")]
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailID { get; set; }
        [DisplayName("Contact")]
        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Contact { get; set; }
        [DisplayName("User Name")]
        [Required]
        public string UserName { get; set; }
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [NotMapped]
        [Required(ErrorMessage = "Confirm Password required")]
        [CompareAttribute("Password", ErrorMessage = "Password doesn't match.")]
        public string ConfirmPassword { get; set; }

      //  public int UserStatus { get; set; }
        [DisplayName("Date")]
        public DateTime RegisteredDate { get; set; }
        [DisplayName("Status")]
        public int ActiveStatus { get; set; }

    

        [Display(Name = "Accepted Terms Of Service")]
        [Range(typeof(bool), "true", "true")]
        [NotMapped]
        public bool AcceptsTerms { get; set; }



     
      

    }
}