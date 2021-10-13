using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class NormalIncomeExpense
    {
        [Key]
        public int NIE_ID { get; set; }

        public string NIE_Name { get; set; }

        public string NIE_Category { get; set; }
     
        public decimal NIE_Amt { get; set; }

        public string NIE_Note { get; set; }

        public DateTime NIE_Date { get; set; }

    }
}