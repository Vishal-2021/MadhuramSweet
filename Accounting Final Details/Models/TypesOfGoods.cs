using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class TypesOfGoods
    {
        [Key]
        public int TOGID { get; set; }
        public string TypeOfGoodsName { get; set; }
    }
}