using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class PurchaseDtl
    {
        [Key]
        public int PurID { get; set; }

        public int PurSuppCustId { get; set; } // id of customer
        public string PurBillNo { get; set; }
        public decimal PurProductRate { get; set; }


        public int PurProductID { get; set; } // it is use for Type of Goods and Procuct Id
        public Decimal PurDiscount { get; set; } // product Discount
        public decimal PurQuantity { get; set; }

        public decimal PurGstRs { get; set; }
        public decimal PurTotal { get; set; }
        public DateTime PurDate { get; set; }

        [ForeignKey("wearhouse")]
        public int? WearhouseRefID { get; set; }
        public Wearhouse wearhouse { get; set; }





        [NotMapped]
        public string dateInStrFormate { get; set; }  // type of Goods

        // for Reporting
        [NotMapped]
        public decimal DiscRs { get; set; }  // type of Goods

        [NotMapped]
        public decimal DiscPer { get; set; }  // type of Goods

        [NotMapped]
        public decimal Charges { get; set; }  // type of Goods

        // end




        [NotMapped]
        public decimal GrandTot { get; set; }  // type of Goods






        [NotMapped]
        public int  Goodtypes { get; set; }  // type of Goods

        [NotMapped]
        public string SplrCustName { get; set; }
        [NotMapped]
        public string ProductSelection { get; set; }  // Product list
        [NotMapped]
        public decimal ProductRate { get; set; }
        [NotMapped]
        public decimal ProductGst { get; set; }

        [NotMapped]
        public decimal DiscProductRate { get; set; }
      




        // Its for final TotalAmount
        [NotMapped]
        public decimal TotalAmt { get; set; }





        // for popup open Modal 
        [NotMapped]
        public string Existance { get; set; }
        [NotMapped]
        public decimal QtySum { get; internal set; }
    }
}