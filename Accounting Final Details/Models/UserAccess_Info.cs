using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class UserAccess_Info
    {
        [Key]
        public int uai_ID { get; set; }
        public int uai_Reg_ID { get; set; }
        public int uai_Url_ID { get; set; }
        [NotMapped]
        public bool isCheck { get; set; } = false;
    }
}