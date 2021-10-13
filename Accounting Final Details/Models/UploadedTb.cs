using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class UploadedTb
    {
        [Key]
        public int Utb_ID { get; set; }

        public string Utb_Name { get; set; }

        public string Utb_FileExtension { get; set; }

        public DateTime Utb_Dates { get; set; }

        public int UpID { get; set; }

        public int Uploader_Name_ID { get; set; }

    }
}