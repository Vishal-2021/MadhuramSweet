using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class CreditNotesTnC
    {
        [Key]
        public int CreditNotesTnC_ID { get; set; }
        public string CreditNotesTnC_BillNo { get; set; }
        public int CreditNotesTnC_TCID { get; set; }
    }
}