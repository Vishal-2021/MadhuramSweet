using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class CreditNotes
    {

        [Key]
        public int CreditNotes_ID { get; set; }
        public int CreditNotes_SuppCustId { get; set; }   //id of customer / Supplier
        public int CreditNotes_BillNo { get; set; }
        public string CreditNotes_SaleWithGSTBillNo { get; set; }
        public decimal CreditNotes_ProductRate { get; set; }
        public int CreditNotes_ProductID { get; set; }     //it is use for Type of Goods and Procuct Id
        public decimal CreditNotes_PDiscount { get; set; } //product Discount
        public decimal CreditNotes_Quantity { get; set; }
        public decimal CreditNotes_GstRs { get; set; }
        public decimal CreditNotes_Total { get; set; }
        public decimal TempSaleGST_DiscRs { get; set; }
        public decimal TempSaleGST_DiscPer { get; set; }
        public string TempSaleGST_ChargesName { get; set; } 
        public decimal TempSaleGST_ChargesAmt { get; set; }
        public string TempSaleGST_Notes { get; set; } 
        public decimal TempSaleGST_GrandTot { get; set; }  
        public decimal TempSaleGST_FTotalAmt { get; set; }
        public DateTime CreditNotes_Date { get; set; }




        [NotMapped]
        public string Update_Status_Msg { get; set; }
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