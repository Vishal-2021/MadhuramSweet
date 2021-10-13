using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class SalesBillWithoutGstDtl
    {

        [Key]
        public int SalBilWiGSTID { get; set; }
        public int SalBilWiGSTSuppCustId { get; set; } // id of customer / Supplier
        public string SalBilWiGSTBillNo { get; set; }

        public int SalBilWiGSTBillNo_Int { get; set; }

        public decimal SalBilWiGSTProductRate { get; set; }

        public int SalBilWiGSTProductID { get; set; } // it is use for Type of Goods and Procuct Id
                                                      //    public Decimal SalBilWiGSTDiscount { get; set; } // product Discount
        public decimal SalBilWiGSTQuantity { get; set; }

        public decimal SalBilWiGSTGstRs { get; set; }
        public decimal SalBilWiGSTTotal { get; set; }
        public DateTime SalBilWiGSTDate { get; set; }
     
        [ForeignKey("Wearhouse")]
        public int? WearhouseRefId { get; set; }
        public Wearhouse Wearhouse  { get; set; }



        [NotMapped]
        public string SaleBiWiGstSuppCustName { get; set; }
    }
}