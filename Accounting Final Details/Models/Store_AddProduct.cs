using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class Store_AddProduct
    {
        [Key]
        public int Sp_ID { get; set; }
        public string Sp_ProductName { get; set; }
        public decimal Sp_Rate { get; set; }
        public int Sp_Category { get; set; }

        [NotMapped]
        public byte[] Sp_PImage { get; set; }

        public string Sp_PImageName { get; set; }
        public string Sp_Description { get; set; }
        public int Sp_Status { get; set; }
        [NotMapped]
        public string ImgString { get; set; }
        [NotMapped]
        public string CategoryName { get; set; }

    }
}