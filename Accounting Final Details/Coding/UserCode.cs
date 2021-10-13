using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Accounting_Final_Details.Models;
using System.IO;
using System.Web.Mvc;

namespace Accounting_Final_Details.Coding
{
    public class UserCode
    {


        SqlConnection Mycon = new SqlConnection(ConfigurationManager.ConnectionStrings["AccountDetailsDBContext"].ConnectionString);

        public void Deactive_Document(int? UpID)
        {

            string Query = "update UploadFiles set Status_ID = 2 where UpID = @UpID";

            SqlCommand cmd = new SqlCommand(Query, Mycon);

            cmd.Parameters.AddWithValue("@UpID", UpID);
        
            Mycon.Open();

            cmd.ExecuteNonQuery();

            Mycon.Close();
        }


        public List<UploadFiles> ReceivedList(DateTime? Fdate, DateTime? Ldate, int? RID)
        {
            List<UploadFiles> lst = new List<UploadFiles>();

      

            SqlCommand cmd = new SqlCommand("select * from UploadFiles as uf left join Registrations as r on uf.Uploader_Name_ID = r.RID  where uf.RID = @RID and uf.Status_ID = 1 and uf.UpDates between @Fdate  and @Ldate ", Mycon);

            cmd.Parameters.AddWithValue("@RID", RID);
            cmd.Parameters.AddWithValue("@Fdate",Fdate);
            cmd.Parameters.AddWithValue("@Ldate", Ldate);

            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {


                UploadFiles UF = new UploadFiles();

                UF.UpID = Convert.ToInt32(dr["UpID"]);
                UF.Notes = dr["Notes"].ToString();

                UF.UpDates = Convert.ToDateTime(dr["UpDates"]);

                UF.Uploader_Name_ID = Convert.ToInt32(dr["Uploader_Name_ID"]);

                UF.Uploader_Name = dr["Name"].ToString();
              


                lst.Add(UF);
            }
            return lst;
        }

        public List<UploadFiles> ReceivedList(int? RID)
        {
            List<UploadFiles> lst = new List<UploadFiles>();



            SqlCommand cmd = new SqlCommand("select * from UploadFiles as uf left join Registrations as r on uf.Uploader_Name_ID = r.RID  where uf.RID = @RID and  uf.Status_ID = 1", Mycon);

            cmd.Parameters.AddWithValue("@RID",RID);

            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {


                UploadFiles UF = new UploadFiles();

                UF.UpID = Convert.ToInt32(dr["UpID"]);
                UF.Notes = dr["Notes"].ToString();

                UF.UpDates = Convert.ToDateTime(dr["UpDates"]);

                UF.Uploader_Name_ID = Convert.ToInt32(dr["Uploader_Name_ID"]);

                UF.Uploader_Name = dr["Name"].ToString();



                lst.Add(UF);
            }
            return lst;
        }





        public List<UploadFiles> UploadedList(int? RID)
        {
            List<UploadFiles> lst = new List<UploadFiles>();




            SqlCommand cmd = new SqlCommand("select * from UploadFiles as uf left join Registrations as r on uf.RID = r.RID where uf.Uploader_Name_ID = @RID", Mycon);

            cmd.Parameters.AddWithValue("@RID", RID);

            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {


                UploadFiles UF = new UploadFiles();

                UF.UpID = Convert.ToInt32(dr["UpID"]);
                UF.Notes = dr["Notes"].ToString();

                UF.UpDates = Convert.ToDateTime(dr["UpDates"]);

                UF.RID = Convert.ToInt32(dr["RID"]);

                UF.User_Name = dr["Name"].ToString();


                //  UF.Uploader_Name_ID = Convert.ToInt32(dr["Uploader_Name_ID"]);

                lst.Add(UF);
            }
            return lst;
        }












    } // Class End
} // Class End