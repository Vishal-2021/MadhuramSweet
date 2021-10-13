using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class ProductDetails
    {
        [Key]
        [DisplayName("ID")]
        public int PDID { get; set; }


        [DisplayName("Barcode No")]
        public string BarcodeNo { get; set; }


        [DisplayName("Product Name")]
        [Required]
        public string ProductName { get; set; }
    
        [DisplayName("Sale Rate")]
        [Required]
        public decimal ProductSaleRate { get; set; }
        [DisplayName("Purchase Rate")]
        [Required]
        public decimal ProductPurchaseRate { get; set; }
        [DisplayName("Measurement")]
        [Required]
        public int PDMeasurement { get; set; }
        [DisplayName("Good Type")]
        [Required]
        public int PDTypeGoods { get; set; }
        [DisplayName("Gst %")]
        [Required]
        public int GstPercent { get; set; }

        [DisplayName("HSN Code")]
        public string HSM_Code  { get; set; }

        [DisplayName("Opening Stock Qty.")]
        [Required]
        public Decimal Opening_Stock_Qty { get; set; }
       
        [Required]
        public int Category_ID  { get; set; }

        public string Tax { get; set; }

        [ForeignKey("Wearhouse")]
        [Required]
        public int? WearhouseRefId { get; set; }
        public Wearhouse Wearhouse { get; set; }

    }
}