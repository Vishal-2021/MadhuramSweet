using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models.ViewModels
{
    public class SaleWithoutGstVM
    {
        public TempSalesBillWithoutGstDtl TempSalesBillWithoutGstDtl { get; set; }
        public CustomerDetails CustDtl { get; set; }
        public ProductDetails ProductDetails { get; set; }
        public ProductGST ProductGST { get; set; }
        public Wearhouse Wearhouse { get; set; }
    }
}