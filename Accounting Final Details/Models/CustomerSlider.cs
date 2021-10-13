using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class CustomerSlider
    {
        [Key]
        public int CS_ID { get; set; }

        [Required]
        public string CS_ProductName { get; set; }
        [Required]
        public string CS_ProductDesc { get; set; }
       
        public string CS_ImgPath { get; set; }
    }
}