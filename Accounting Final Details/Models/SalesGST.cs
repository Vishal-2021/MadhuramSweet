using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class SalesGST
    {

        [Key]
        public int SaleGST_ID { get; set; }
        public int SaleGST_SuppCustId { get; set; } // id of customer / Supplier
        public string SaleGST_BillNo { get; set; }

        public int SaleGST_BillNo_Int { get; set; }



        public decimal SaleGST_ProductRate { get; set; }
        public int SaleGST_ProductID { get; set; } // it is use for Type of Goods and Procuct Id
        public decimal SaleGST_Discount { get; set; } // product Discount
                                                 //    public Decimal SalBilWiGSTDiscount { get; set; } // product Discount
        public decimal SaleGST_Quantity { get; set; }
        public decimal SaleGST_GstRs { get; set; }
        public decimal SaleGST_Total { get; set; }
        public DateTime SaleGST_Date { get; set; }

        [NotMapped]
        public string SaleGST_SuppCustName { get; set; }



        [NotMapped]
        public decimal ProductGst { get; set; }

    }
}