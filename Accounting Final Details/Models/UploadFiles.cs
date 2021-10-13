using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Accounting_Final_Details.Models
{
    public class UploadFiles
    {
        [Key]
        public int UpID { get; set; }
        public int RID { get; set; }
        public string Notes { get; set; }
        public DateTime UpDates { get; set; }
        public int Status_ID { get; set; }

        public int Uploader_Name_ID { get; set; }

        [NotMapped]
        public HttpPostedFileBase[] files { get; set; }


        [NotMapped]
        public string Uploader_Name { get; set; }


        [NotMapped]
        public string User_Name { get; set; }


    }
}