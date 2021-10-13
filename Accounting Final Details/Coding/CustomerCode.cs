using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Accounting_Final_Details.Models;

namespace Accounting_Final_Details.Coding
{
    public class CustomerCode
    {
      SqlConnection Mycon = new SqlConnection(ConfigurationManager.ConnectionStrings["AccountDetailsDBContext"].ConnectionString);


        public void Cust_Regist(Customer_Registration custReg)
        {
           

            SqlCommand cmd = new SqlCommand("Insert into Customer_Registration values(@Cust_Name,@Cust_Contact,@Cust_EmailID,@Password,@Cust_RegisteredDate)", Mycon);

            cmd.Parameters.AddWithValue("@Cust_Name", custReg.Cust_Name);
            cmd.Parameters.AddWithValue("@Cust_Contact", custReg.Cust_Contact);
            cmd.Parameters.AddWithValue("@Cust_EmailID", custReg.Cust_EmailID);
            cmd.Parameters.AddWithValue("@Password", custReg.Password);
            cmd.Parameters.AddWithValue("@Cust_RegisteredDate", custReg.Cust_RegisteredDate);



            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();


        }

        public List<Store_AddProduct> TrendingProducts()
        {
     
            List<Store_AddProduct> lst = new List<Store_AddProduct>();


            SqlCommand cmd = new SqlCommand("select * from Store_AddProduct as p join Product_Catagory as pc on pc.C_ID=p.Sp_Category  where  P.Sp_Status = 1 order by P.Sp_ID desc", Mycon);

     //       string Cat = "'1','2'";
     //       SqlCommand cmd = new SqlCommand("select * from Store_AddProduct as p join Product_Catagory as pc on pc.C_ID = p.Sp_Category  where P.Sp_Status = 1 and P.Sp_Category IN("+ Cat + ") order by P.Sp_ID desc", Mycon);


          



            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Store_AddProduct p = new Store_AddProduct();

                p.Sp_ID = Convert.ToInt32(dr["Sp_ID"]);
                p.Sp_ProductName = dr["Sp_ProductName"].ToString();
                p.Sp_Rate = Convert.ToDecimal(dr["Sp_Rate"]);
                p.CategoryName = dr["Category_Name"].ToString();

                p.Sp_Description = dr["Sp_Description"].ToString();

                p.Sp_PImageName = dr["Sp_PImageName"].ToString();



                // p.Sp_PImage = (Byte[])dr["Sp_PImage"];
                //  p.ImgString = Convert.ToBase64String(p.Sp_PImage);


                lst.Add(p);
            }
            Mycon.Close();
            return lst;
        }




        public List<Store_AddProduct> TrendingProducts(string Cat)
        {

            List<Store_AddProduct> lst = new List<Store_AddProduct>();


            //    SqlCommand cmd = new SqlCommand("select * from Store_AddProduct as p join Product_Catagory as pc on pc.C_ID=p.Sp_Category  where  P.Sp_Status = 1 order by P.Sp_ID desc", Mycon);

           // string Cat = "'1','2'";

            SqlCommand cmd = new SqlCommand("select * from Store_AddProduct as p join Product_Catagory as pc on pc.C_ID=p.Sp_Category  where  P.Sp_Status = 1 and P.Sp_Category IN("+Cat+") order by P.Sp_ID desc", Mycon);






            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Store_AddProduct p = new Store_AddProduct();

                p.Sp_ID = Convert.ToInt32(dr["Sp_ID"]);
                p.Sp_ProductName = dr["Sp_ProductName"].ToString();
                p.Sp_Rate = Convert.ToDecimal(dr["Sp_Rate"]);
                p.CategoryName = dr["Category_Name"].ToString();

                p.Sp_Description = dr["Sp_Description"].ToString();

                p.Sp_PImageName = dr["Sp_PImageName"].ToString();


                //p.Sp_PImage = (Byte[])dr["Sp_PImage"];
                //  p.ImgString = Convert.ToBase64String(p.Sp_PImage);

                lst.Add(p);
            }
            Mycon.Close();
            return lst;
        }








        public void AddToCartWithLogin(int custID, int PID, decimal PQty,string msg)
        {

            string SqlQuery = "";

            if (msg == "update")
            {
                SqlQuery = "Update Carts set Crt_PQty = @Crt_PQty where Crt_ProdId = @Crt_ProdId and Crt_CustId = @Crt_CustId";
            }
            else
            {
                SqlQuery = "Insert into Carts values(@Crt_CustId,@Crt_ProdId,@Crt_PQty)";
            }

            SqlCommand cmd = new SqlCommand(SqlQuery, Mycon);


            cmd.Parameters.AddWithValue("@Crt_CustId", custID);
            cmd.Parameters.AddWithValue("@Crt_ProdId", PID);
            cmd.Parameters.AddWithValue("@Crt_PQty", PQty);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }

        public List<Cart> FetchCartList(int? custID)
        {

            List<Cart> lst = new List<Cart>();


            SqlCommand cmd = new SqlCommand("select * from Carts as crt join Customer_Registration as cr on cr.Cust_RID = crt.Crt_CustId join Store_AddProduct as sap on sap.Sp_ID = crt.Crt_ProdId join Product_Catagory as pc on pc.C_ID = sap.Sp_Category where crt.Crt_CustId = @custID", Mycon);

            if (custID != null)
            {
                cmd.Parameters.AddWithValue("@custID", custID);
            }
            else
            {
                cmd.Parameters.AddWithValue("@custID", 1);
            }

            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Cart crt = new Cart();

                crt.Crt_Id = Convert.ToInt32(dr["Crt_Id"]);
               crt.Cust_Name = dr["Cust_Name"].ToString();
               crt.Crt_PQty = Convert.ToDecimal(dr["Crt_PQty"]);
               crt.Crt_CustId = Convert.ToInt32(dr["Sp_ID"]);
               crt.Sp_ProductName = dr["Sp_ProductName"].ToString();
               crt.Sp_Rate = Convert.ToDecimal(dr["Sp_Rate"]);
               crt.CategoryName = dr["Category_Name"].ToString();
               crt.Sp_Description = dr["Sp_Description"].ToString();
               crt.Sp_PImageName = dr["Sp_PImageName"].ToString();


                //   crt.Sp_PImage = (Byte[])dr["Sp_PImage"];

                //   crt.Sp_PImageStr = "data:image/jpg;base64," + Convert.ToBase64String(Imgbyte);



                lst.Add(crt);
            }
            Mycon.Close();



            return lst;
        }




        public void EditQtyCart(int CrtID, decimal PQty)
        {

 
            string  SqlQuery = "Update Carts set Crt_PQty = @Crt_PQty where Crt_Id = @Crt_Id";

            SqlCommand cmd = new SqlCommand(SqlQuery, Mycon);

            cmd.Parameters.AddWithValue("@Crt_Id", CrtID);
            cmd.Parameters.AddWithValue("@Crt_PQty", PQty);
      

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }








        public void DeleteCart(int CustID)
        {

            string SqlQuery = "delete Carts where Crt_CustId = @Crt_CustId";

            SqlCommand cmd = new SqlCommand(SqlQuery, Mycon);

            cmd.Parameters.AddWithValue("@Crt_CustId", CustID);


            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }














    }

}