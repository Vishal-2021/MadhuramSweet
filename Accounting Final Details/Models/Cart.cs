using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class Cart
    {
        [Key]
        public int Crt_Id { get; set; }
        public int Crt_CustId { get; set; }
        public int Crt_ProdId { get; set; }
        public decimal Crt_PQty { get; set; }


        [NotMapped]
        public string Sp_ProductName { get; set; }
        [NotMapped]
        public decimal Sp_Rate { get; set; }
        [NotMapped]
        public string CategoryName { get; set; }
        [NotMapped]
        public string Sp_Description { get; set; }
        [NotMapped]
        public string Sp_PImageName { get; set; }




        [NotMapped]
        public string Sp_PImageStr { get; set; }

        [NotMapped]
        public string Cust_Name { get; set; }









    }
}