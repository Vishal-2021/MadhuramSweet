using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class TempSalesBillWithoutGstDtl
    {


        [Key]
        public int SalBilWiGSTID { get; set; }
        public int SalBilWiGSTSuppCustId { get; set; } // id of customer / Supplier
        public string SalBilWiGSTBillNo { get; set; }
        public decimal SalBilWiGSTProductRate { get; set; }

        public int SalBilWiGSTProductID { get; set; } // it is use for Type of Goods and Procuct Id
   
        //  public Decimal SalBilWiGSTDiscount { get; set; } // product Discount
        public decimal SalBilWiGSTQuantity { get; set; }

        public decimal SalBilWiGSTGstRs { get; set; }
        public decimal SalBilWiGSTTotal { get; set; }
        public DateTime SalBilWiGSTDate { get; set; }
      
        [ForeignKey("Wearhouse")]
        public int? WearhouseRefId { get; set; }
        public Wearhouse Wearhouse { get; set; }




        [NotMapped]
        public string SalBilWiGSTdateInStrFormate { get; set; }  // type of Goods




        // for Charges n Discount
        [NotMapped]
        public decimal SalBilWiGSTDiscRs { get; set; }  

        [NotMapped]
        public decimal SalBilWiGSTDiscPer { get; set; }

        [NotMapped]
        public string SalBilWiGSTChargesName { get; set; }


        [NotMapped]
        public decimal SalBilWiGSTChargesAmt { get; set; } 

        // end




        [NotMapped]
        public decimal SalBilWiGSTGrandTot { get; set; }  // type of Goods






        [NotMapped]
        public int SalBilWiGSTGoodtypes { get; set; }  // type of Goods

        [NotMapped]
        public string SalBilWiGSTSplrCustName { get; set; }
        [NotMapped]
        public string SalBilWiGSTProductSelection { get; set; }  // Product list
        [NotMapped]
        public decimal SalBilWiGSTProductRates { get; set; }
        [NotMapped]
        public decimal SalBilWiGSTProductGst { get; set; }






        // Its for final TotalAmount
        [NotMapped]
        public decimal SalBilWiGSTTotalAmt { get; set; }





        // for popup open Modal 
        [NotMapped]
        public string SalBilWiGSTExistance { get; set; }


        

        [NotMapped]
        public string SalBiWiGst_Note { get; set; }

        [NotMapped]
        public int SalBiWiGst_Status { get; set; }


        [NotMapped]
        public int SalBilWiGSTTCID { get; set; } // Terms & Condition 



        [NotMapped]
        public string Update_Status { get; set; }




        [NotMapped]
        public decimal OpeningStock { get; set; }

        [NotMapped]
        public decimal QtySum { get; set; }









    }
}