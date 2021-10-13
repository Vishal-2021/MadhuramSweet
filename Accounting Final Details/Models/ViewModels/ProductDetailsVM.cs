using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Accounting_Final_Details.Models.ViewModels
{
    public class ProductDetailsVM
    {
        public ProductDetails ProductDetails { get; set; }

        public Mesurement Mesurement { get; set; }
        public TypesOfGoods TypesOfGoods { get; set; }
        public ProductGST ProductGST { get; set; }
      
        public Product_Catagory Product_Catagory { get; set; }
      
        public Wearhouse Wearhouse { get; set; }
     
        
        public TempDataPurchase TempDataPurchase { get; set; }
        public CustomerDetails CustomerDetails { get; set; }



    }
}