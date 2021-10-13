using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class TempCreditNotes
    {
        [Key]
        public int TempCreditNotes_ID { get; set; }
        public int TempCreditNotes_SuppCustId { get; set; } // id of customer / Supplier
        public string TempCreditNotes_BillNo { get; set; }
        public decimal TempCreditNotes_ProductRate { get; set; }

        public int TempCreditNotes_ProductID { get; set; } // it is use for Type of Goods and Procuct Id

        public decimal TempCreditNotes_PDiscount { get; set; } // product Discount
        public decimal TempCreditNotes_Quantity { get; set; }

        public decimal TempCreditNotes_GstRs { get; set; }
        public decimal TempCreditNotes_Total { get; set; }
        public DateTime TempCreditNotes_Date { get; set; }







        [NotMapped]
        public string TempSaleGST_dateInStrFormate { get; set; }  // type of Goods


        // for Charges n Discount
        [NotMapped]
        public decimal TempSaleGST_DiscRs { get; set; }

        [NotMapped]
        public decimal TempSaleGST_DiscPer { get; set; }

        [NotMapped]
        public string TempSaleGST_ChargesName { get; set; }


        [NotMapped]
        public decimal TempSaleGST_ChargesAmt { get; set; }

        // end

        [NotMapped]
        public string Update_Status_Msg { get; set; }

        [NotMapped]
        public decimal TempSaleGST_GrandTot { get; set; }  // type of Goods


        [NotMapped]
        public int TempSaleGST_Goodtypes { get; set; }  // type of Goods

        [NotMapped]
        public string TempSaleGST_SplrCustName { get; set; }
        [NotMapped]
        public string TempSaleGST_ProductSelection { get; set; }  // Product list
        [NotMapped]
        public decimal TempSaleGST_ProductRates { get; set; }
        [NotMapped]
        public decimal TempSaleGST_ProductGst { get; set; }






        // Its for final TotalAmount
        [NotMapped]
        public decimal TempSaleGST_TotalAmt { get; set; } // Final Total





        // for popup open Modal 
        [NotMapped]
        public string TempSaleGST_Existance { get; set; }


        [NotMapped]
        public int TempSaleGST_TCID { get; set; } // Terms & Condition 



        [NotMapped]
        public decimal QtySum { get; set; }



        [NotMapped]
        public decimal OpeningStock { get; set; }

    }
}