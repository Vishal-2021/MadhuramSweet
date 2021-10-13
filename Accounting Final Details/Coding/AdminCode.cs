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
    public class AdminCode
    {
        string Cnstr = ConfigurationManager.ConnectionStrings["AccountDetailsDBContext"].ConnectionString;


        // @@@@@@@@@@   Dashboard  @@@@@@@@@



        public object TotalProduct()
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM ProductDetails", Mycon);
            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }




        public object DaliveryOrderNow()
        {

            object rslt = 0;
            DateTime dt = DateTime.Now;

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT count(*) FROM CustomerOrders where DeliveryStatus = 5 and CustOrdDate = @date", Mycon);
            cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dt).ToString("yyyy-MM-dd"));
            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;

        }

        public object DaliveryOrderWeekly()
        {

            object rslt = 0;
            DateTime dt = DateTime.Now;

            DateTime Past_Dt = DateTime.Today.AddDays(-7);

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT count(*) FROM CustomerOrders where DeliveryStatus = 5 and CustOrdDate between @Past_Dt and @date", Mycon);

            cmd.Parameters.AddWithValue("@Past_Dt", Convert.ToDateTime(Past_Dt).ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dt).ToString("yyyy-MM-dd"));

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;

        }

        public object DaliveryOrderMonthly()
        {

            object rslt = 0;
            DateTime dt = DateTime.Now;

            DateTime Past_Dt = DateTime.Today.AddDays(-30);

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT count(*) FROM CustomerOrders where DeliveryStatus = 5 and CustOrdDate between @Past_Dt and @date", Mycon);

            cmd.Parameters.AddWithValue("@Past_Dt", Convert.ToDateTime(Past_Dt).ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dt).ToString("yyyy-MM-dd"));

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;

        }



        public object DaliveryOrderNowSale()
        {

            object rslt = 0;
            DateTime dt = DateTime.Now;

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT sum(Ftotal) FROM CustomerOrders where DeliveryStatus = 5 and CustOrdDate = @date", Mycon);
            cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dt).ToString("yyyy-MM-dd"));
            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;

        }

        public object DaliveryOrderWeeklySale()
        {

            object rslt = 0;
            DateTime dt = DateTime.Now;

            DateTime Past_Dt = DateTime.Today.AddDays(-7);

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT sum(Ftotal) FROM CustomerOrders where DeliveryStatus = 5 and CustOrdDate between @Past_Dt and @date", Mycon);

            cmd.Parameters.AddWithValue("@Past_Dt", Convert.ToDateTime(Past_Dt).ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dt).ToString("yyyy-MM-dd"));

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;

        }

        public object DaliveryOrderMonthlySale()
        {

            object rslt = 0;
            DateTime dt = DateTime.Now;

            DateTime Past_Dt = DateTime.Today.AddDays(-30);

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT sum(Ftotal) FROM CustomerOrders where DeliveryStatus = 5 and CustOrdDate between @Past_Dt and @date", Mycon);

            cmd.Parameters.AddWithValue("@Past_Dt", Convert.ToDateTime(Past_Dt).ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dt).ToString("yyyy-MM-dd"));

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;

        }











        public object TotalUsers()
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Registrations where ActiveStatus = 1", Mycon);
            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }
        public object TotalCustomers()
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM CustomerDetails where CustStatus = 1", Mycon);
            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }



        public object TotalDailyPurchase()
        {
            object rslt = 0;
            DateTime dt = DateTime.Now;


            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT sum(PrFinalTotal) FROM PurchaseForReports where Prdate = @date", Mycon);
            cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dt).ToString("yyyy-MM-dd"));
            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }
        public object TotalWeeklyPurchase()
        {
            object rslt = 0;
            DateTime dt = DateTime.Now;

            DateTime Past_Dt = DateTime.Today.AddDays(-7);

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT sum(PrFinalTotal) FROM PurchaseForReports where Prdate between @Past_Dt and @date", Mycon);

            cmd.Parameters.AddWithValue("@Past_Dt", Convert.ToDateTime(Past_Dt).ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dt).ToString("yyyy-MM-dd"));

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }

        public object TotalMonthlyPurchase()
        {
            object rslt = 0;
            DateTime dt = DateTime.Now;

            DateTime Past_Dt = DateTime.Today.AddDays(-30);

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT sum(PrFinalTotal) FROM PurchaseForReports where Prdate between @Past_Dt and @date", Mycon);

            cmd.Parameters.AddWithValue("@Past_Dt", Convert.ToDateTime(Past_Dt).ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dt).ToString("yyyy-MM-dd"));

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }

        public object TotalYearlyPurchase()
        {
            object rslt = 0;
            DateTime dt = DateTime.Now;

            DateTime Past_Dt = DateTime.Today.AddDays(-365);

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT sum(PrFinalTotal) FROM PurchaseForReports where Prdate between @Past_Dt and @date", Mycon);

            cmd.Parameters.AddWithValue("@Past_Dt", Convert.ToDateTime(Past_Dt).ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dt).ToString("yyyy-MM-dd"));

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }

        public object TotalAllPurchase()
        {
            object rslt = 0;
            //  decimal rt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT sum(PrFinalTotal) as FinalTotal FROM PurchaseForReports", Mycon);

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            // rslt = Convert.ToDecimal(dr["FinalTotal"]);

            Mycon.Close();


            return rslt;
        }



        public object TotalDailyPurchase_Received()
        {
            object rslt = 0;
            DateTime dt = DateTime.Now;

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select sum(TranReciAmt) from CustSupTransactions where TranDate = @date", Mycon);

            cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dt).ToString("yyyy-MM-dd"));

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }

        public void CancleOrder(int OrdID)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("Update CustomerOrders set DeliveryStatus = 0 where OrderID = @CustID", Mycon);

            cmd.Parameters.AddWithValue("@CustID", OrdID);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }

        public object TotalWeeklyPurchase_Received()
        {
            object rslt = 0;
            DateTime dt = DateTime.Now;

            DateTime Past_Dt = DateTime.Today.AddDays(-7);

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select sum(TranReciAmt) from CustSupTransactions where TranDate between @Past_Dt and @date", Mycon);

            cmd.Parameters.AddWithValue("@Past_Dt", Convert.ToDateTime(Past_Dt).ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dt).ToString("yyyy-MM-dd"));

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }

        public object TotalMonthlyPurchase_Received()
        {
            object rslt = 0;
            DateTime dt = DateTime.Now;

            DateTime Past_Dt = DateTime.Today.AddDays(-30);

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select sum(TranReciAmt) from CustSupTransactions where TranDate between @Past_Dt and @date", Mycon);

            cmd.Parameters.AddWithValue("@Past_Dt", Convert.ToDateTime(Past_Dt).ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dt).ToString("yyyy-MM-dd"));

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }

        public object TotalYearlyPurchase_Received()
        {
            object rslt = 0;
            DateTime dt = DateTime.Now;

            DateTime Past_Dt = DateTime.Today.AddDays(-365);

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select sum(TranReciAmt) from CustSupTransactions where TranDate between @Past_Dt and @date", Mycon);

            cmd.Parameters.AddWithValue("@Past_Dt", Convert.ToDateTime(Past_Dt).ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dt).ToString("yyyy-MM-dd"));

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }

        public object TotalAllPurchase_Received()
        {
            object rslt = 0;
            //  decimal rt = 0;

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select sum(TranReciAmt) as TranReceiveAmt from CustSupTransactions", Mycon);

            Mycon.Open();
            rslt = cmd.ExecuteScalar();


            Mycon.Close();


            return rslt;
        }

        public object TotalBills()
        {
            object rslt = 0;


            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select count(*) from PurchaseForReports", Mycon);


            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }












        public object TotalDaily_SaleWithoutGst()
        {
            object rslt = 0;
            DateTime dt = DateTime.Now;


            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select sum(SalBiWiGst_Rpt_FinalTotal) from SalesBillWithoutGstDtl_Report as sr join SalesBillWithoutGstDtl_ChargesDisc as sc on sc.SalBiWiGst_BillNo = sr.SalBiWiGst_Rpt_BillNo   where sc.SalBiWiGst_Status = 1  and  SalBiWiGst_Rpt_date = @date", Mycon);
            cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dt).ToString("yyyy-MM-dd"));
            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }
        public object TotalWeekly_SaleWithoutGst()
        {
            object rslt = 0;
            DateTime dt = DateTime.Now;

            DateTime Past_Dt = DateTime.Today.AddDays(-7);

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select sum(SalBiWiGst_Rpt_FinalTotal) from SalesBillWithoutGstDtl_Report as sr join SalesBillWithoutGstDtl_ChargesDisc as sc on sc.SalBiWiGst_BillNo = sr.SalBiWiGst_Rpt_BillNo   where sc.SalBiWiGst_Status = 1  and SalBiWiGst_Rpt_date between @Past_Dt and @date", Mycon);

            cmd.Parameters.AddWithValue("@Past_Dt", Convert.ToDateTime(Past_Dt).ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dt).ToString("yyyy-MM-dd"));

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }

        public object TotalMonthly_SaleWithoutGst()
        {
            object rslt = 0;
            DateTime dt = DateTime.Now;

            DateTime Past_Dt = DateTime.Today.AddDays(-30);

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select sum(SalBiWiGst_Rpt_FinalTotal) from SalesBillWithoutGstDtl_Report as sr join SalesBillWithoutGstDtl_ChargesDisc as sc on sc.SalBiWiGst_BillNo = sr.SalBiWiGst_Rpt_BillNo   where sc.SalBiWiGst_Status = 1  and SalBiWiGst_Rpt_date between @Past_Dt and @date", Mycon);

            cmd.Parameters.AddWithValue("@Past_Dt", Convert.ToDateTime(Past_Dt).ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dt).ToString("yyyy-MM-dd"));

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }

        public object TotalYearly_SaleWithoutGst()
        {
            object rslt = 0;
            DateTime dt = DateTime.Now;

            DateTime Past_Dt = DateTime.Today.AddDays(-365);

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select sum(SalBiWiGst_Rpt_FinalTotal) from SalesBillWithoutGstDtl_Report as sr join SalesBillWithoutGstDtl_ChargesDisc as sc on sc.SalBiWiGst_BillNo = sr.SalBiWiGst_Rpt_BillNo   where sc.SalBiWiGst_Status = 1  and SalBiWiGst_Rpt_date between @Past_Dt and @date", Mycon);

            cmd.Parameters.AddWithValue("@Past_Dt", Convert.ToDateTime(Past_Dt).ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dt).ToString("yyyy-MM-dd"));
            Mycon.Close();
            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }

        public object TotalAll_SaleWithoutGst()
        {
            object rslt = 0;

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select sum(SalBiWiGst_Rpt_FinalTotal) from SalesBillWithoutGstDtl_Report", Mycon);

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }


        public object Outsand_SaleWithoutGst()
        {
            object rslt = 0;

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select count(*) from SalesBillWithoutGstDtl_ChargesDisc where SalBiWiGst_Status = 2", Mycon);


            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }










        // use for sale gst







        public object TotalDaily_SaleWithGst()
        {
            object rslt = 0;
            DateTime dt = DateTime.Now;

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT sum(SalesGST_Rpt_FinalTotal) FROM SalesGST_Report where SalesGST_Rpt_date = @date", Mycon);
            cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dt).ToString("yyyy-MM-dd"));
            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }

        public object TotalWeekly_SaleWithGst()
        {
            object rslt = 0;
            DateTime dt = DateTime.Now;

            DateTime Past_Dt = DateTime.Today.AddDays(-7);

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT sum(SalesGST_Rpt_FinalTotal) FROM SalesGST_Report where SalesGST_Rpt_date between @Past_Dt and @date", Mycon);

            cmd.Parameters.AddWithValue("@Past_Dt", Convert.ToDateTime(Past_Dt).ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dt).ToString("yyyy-MM-dd"));

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }

        public object TotalMonthly_SaleWithGst()
        {
            object rslt = 0;
            DateTime dt = DateTime.Now;

            DateTime Past_Dt = DateTime.Today.AddDays(-30);

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT sum(SalesGST_Rpt_FinalTotal) FROM SalesGST_Report where SalesGST_Rpt_date between @Past_Dt and @date", Mycon);

            cmd.Parameters.AddWithValue("@Past_Dt", Convert.ToDateTime(Past_Dt).ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dt).ToString("yyyy-MM-dd"));

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }

        public object TotalYearly_SaleWithGst()
        {
            object rslt = 0;
            DateTime dt = DateTime.Now;

            DateTime Past_Dt = DateTime.Today.AddDays(-365);

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT sum(SalesGST_Rpt_FinalTotal) FROM SalesGST_Report where SalesGST_Rpt_date between @Past_Dt and @date", Mycon);

            cmd.Parameters.AddWithValue("@Past_Dt", Convert.ToDateTime(Past_Dt).ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dt).ToString("yyyy-MM-dd"));

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }

        public object TotalAll_SaleWithGst()
        {
            object rslt = 0;

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT sum(SalesGST_Rpt_FinalTotal) FROM SalesGST_Report", Mycon);

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }













        public object TotalDailySaleWithGst_Received()
        {
            object rslt = 0;
            DateTime dt = DateTime.Now;

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select sum(SGstTran_TranReciAmt) from SalesGST_Transactions where SGstTran_Date =  @date", Mycon);

            cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dt).ToString("yyyy-MM-dd"));

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }

        public object TotalWeeklySaleWithGst_Received()
        {
            object rslt = 0;
            DateTime dt = DateTime.Now;

            DateTime Past_Dt = DateTime.Today.AddDays(-7);

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select sum(SGstTran_TranReciAmt) from SalesGST_Transactions where SGstTran_Date between @Past_Dt and @date", Mycon);

            cmd.Parameters.AddWithValue("@Past_Dt", Convert.ToDateTime(Past_Dt).ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dt).ToString("yyyy-MM-dd"));

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }

        public object TotalMonthlySaleWithGst_Received()
        {
            object rslt = 0;
            DateTime dt = DateTime.Now;

            DateTime Past_Dt = DateTime.Today.AddDays(-30);

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select sum(SGstTran_TranReciAmt) from SalesGST_Transactions where SGstTran_Date between @Past_Dt and @date", Mycon);

            cmd.Parameters.AddWithValue("@Past_Dt", Convert.ToDateTime(Past_Dt).ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dt).ToString("yyyy-MM-dd"));

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }

        public object TotalYearlySaleWithGst_Received()
        {
            object rslt = 0;
            DateTime dt = DateTime.Now;

            DateTime Past_Dt = DateTime.Today.AddDays(-365);

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select sum(SGstTran_TranReciAmt) from SalesGST_Transactions where SGstTran_Date between @Past_Dt and @date", Mycon);

            cmd.Parameters.AddWithValue("@Past_Dt", Convert.ToDateTime(Past_Dt).ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dt).ToString("yyyy-MM-dd"));

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }

        public void EditProductsdtl(ProductDetails pd)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("Update ProductDetails set Category_ID = @Category_ID,ProductName = @ProductName,ProductSaleRate = @ProductSaleRate,ProductPurchaseRate = @ProductPurchaseRate,PDMeasurement = @PDMeasurement,PDTypeGoods = @PDTypeGoods,GstPercent = @GstPercent,HSM_Code = @HSM_Code,Opening_Stock_Qty = @Opening_Stock_Qty,Tax = @Tax,WearhouseRefID = @WearhouseRefID where PDID = @PDID ", Mycon);

            cmd.Parameters.AddWithValue("@PDID", pd.PDID);



            cmd.Parameters.AddWithValue("@Category_ID", pd.Category_ID);
            cmd.Parameters.AddWithValue("@ProductName", pd.ProductName);
            cmd.Parameters.AddWithValue("@ProductSaleRate", pd.ProductSaleRate);
            cmd.Parameters.AddWithValue("@ProductPurchaseRate", pd.ProductPurchaseRate);
            cmd.Parameters.AddWithValue("@PDMeasurement", pd.PDMeasurement);
            cmd.Parameters.AddWithValue("@PDTypeGoods", pd.PDTypeGoods);
            cmd.Parameters.AddWithValue("@GstPercent", pd.GstPercent);
            cmd.Parameters.AddWithValue("@HSM_Code", pd.HSM_Code ?? Convert.DBNull);
            cmd.Parameters.AddWithValue("@Opening_Stock_Qty", pd.Opening_Stock_Qty);
            cmd.Parameters.AddWithValue("@Tax", pd.Tax);
            cmd.Parameters.AddWithValue("@WearhouseRefID", pd.WearhouseRefId);


            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }

        public object TotalAllSaleWithGst_Received()
        {
            object rslt = 0;

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select sum(SGstTran_TranReciAmt) from SalesGST_Transactions", Mycon);

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }




        // next

        public object TotalBills_SaleWithGst()
        {
            object rslt = 0;


            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select count(*) from SalesGST_Report", Mycon);


            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }



        public object TotalBills_SaleWithoutGst()
        {
            object rslt = 0;


            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select count(*) from SalesBillWithoutGstDtl_Report", Mycon);


            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }





        public List<SalesGST_Transactions> OustStand()
        {
            List<SalesGST_Transactions> lst = new List<SalesGST_Transactions>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("select SGstTran_BillNo, SalesGST_Rpt_FinalTotal, Sum(SGstTran_TranReciAmt) as ReceivedAmt  from SalesGST_Transactions join SalesGST_Report on SalesGST_Rpt_BillNo = SGstTran_BillNo group by SGstTran_BillNo, SalesGST_Rpt_FinalTotal", Mycon);

            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                SalesGST_Transactions pd = new SalesGST_Transactions();


                pd.SGstTran_BillNo = dr["SGstTran_BillNo"].ToString();
                pd.SalesGST_Rpt_FinalTotal = Convert.ToDecimal(dr["SalesGST_Rpt_FinalTotal"]);
                pd.SGstTran_TranReciAmt = Convert.ToDecimal(dr["ReceivedAmt"]);


                lst.Add(pd);
            }
            Mycon.Close();
            return lst;
        }









        // @@@@@@@@@@@  End Dashboard @@@@@@@@@

















        // @@@@@@@@@@ User Access @@@@@@@@
        public void Add_UserAccess(int UA_ID, int User_Ids)
        {


            SqlConnection Mycon = new SqlConnection(Cnstr);
            string Query;

            Query = "insert into UserAccess_Info values(@uai_Reg_ID, @uai_Url_ID)";

            SqlCommand cmd = new SqlCommand(Query, Mycon);

            cmd.Parameters.AddWithValue("@uai_Reg_ID", User_Ids);
            cmd.Parameters.AddWithValue("@uai_Url_ID", UA_ID);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }

        public void Delete_UserAccess(int User_Ids)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            string Query;

            Query = "delete UserAccess_Info where uai_Reg_ID = @uai_Reg_ID";

            SqlCommand cmd = new SqlCommand(Query, Mycon);

            cmd.Parameters.AddWithValue("@uai_Reg_ID", User_Ids);


            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }

        // <--------- End user access -------->

        // @@@@@@ Registration Details @@@@@@@@@

        public List<ComboPack> PDShow()
        {
            List<ComboPack> lst = new List<ComboPack>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("select * from PurchaseDtls", Mycon);

            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ComboPack pd = new ComboPack();

                //   PurchaseDtl pds = new PurchaseDtl();
                //
                //   pds.PurBillNo = dr["PurBillNo"].ToString();


                //pd.PurchaseDtl.PurBillNo = dr["PurBillNo"].ToString();

                pd.PurchaseDtl.PurBillNo = "PurBillNo";

                //  pd.PurchaseDtl.ProductSelection = dr["ProductSelection"].ToString();


                //  pd.PurchaseDtl.PurSuppCustId = Convert.ToInt32(dr["PurSuppCustId"]);



                lst.Add(pd);
            }


            Mycon.Close();
            return lst;
        }

        public List<PurchaseDtl> ListPurchaseDtl()
        {
            List<PurchaseDtl> lst = new List<PurchaseDtl>();


            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("SELECT PurchaseDtls.PurBillNo, CustomerDetails.CustName,PurchaseDtls.PurDate   FROM PurchaseDtls LEFT JOIN CustomerDetails ON PurchaseDtls.PurSuppCustId = CustomerDetails.CustID GROUP BY PurchaseDtls.PurBillNo, CustomerDetails.CustName,PurchaseDtls.PurDate", Mycon);

            Mycon.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                PurchaseDtl pd = new PurchaseDtl();

                pd.PurBillNo = Convert.ToString(dr["PurBillNo"]);
                pd.SplrCustName = Convert.ToString(dr["CustName"]);
                pd.PurDate = Convert.ToDateTime(dr["PurDate"]);

                //    string vals = dr["PurchaseDtls.PurBillNo"].ToString();
                lst.Add(pd);
            }
            Mycon.Close();
            return lst;
        }

        // gabage table of above

        public void ActiveStatusRgst(int id, string ActionMethodName)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);

            string Query1 = "", Query2 = "";
            if (ActionMethodName == "Registration")
            {
                Query1 = "Select * from Registrations where RID = @ID";
            }
            else if (ActionMethodName == "CustomerSupplier")
            {
                Query1 = "Select * from CustomerDetails where CustID = @ID";
            }
            else if (ActionMethodName == "Org")
            {
                Query1 = "Select * from OrganizationDetails where OrgID = @ID";

            }

            SqlCommand cmd = new SqlCommand(Query1, Mycon);

            cmd.Parameters.AddWithValue("@ID", id);
            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            int AId = 0;

            if (ActionMethodName == "Registration")
            {
                AId = Convert.ToInt32(dr["ActiveStatus"]);
            }
            else if (ActionMethodName == "CustomerSupplier")
            {
                AId = Convert.ToInt32(dr["CustStatus"]);
            }
            else if (ActionMethodName == "Org")
            {
                AId = Convert.ToInt32(dr["OrgStatus"]);
            }
            int i = AId;
            while (i <= 2)
            {
                if (i == 2)
                {
                    i = 1;
                    break;
                }
                i++;
                break;
            }
            dr.Close();
            if (ActionMethodName == "Registration")
            {
                Query2 = "Update Registrations set ActiveStatus = @Status where RID = @ID";
            }
            else if (ActionMethodName == "CustomerSupplier")
            {
                Query2 = "Update CustomerDetails set CustStatus = @Status where CustID = @ID";

            }
            else if (ActionMethodName == "Org")
            {
                Query2 = "Update OrganizationDetails set OrgStatus = @Status where OrgID = @ID";
            }
            SqlCommand cmd2 = new SqlCommand(Query2, Mycon);
            cmd2.Parameters.AddWithValue("@ID", id);
            cmd2.Parameters.AddWithValue("@Status", i);
            cmd2.ExecuteNonQuery();

            Mycon.Close();

        }
        // This is User Name Exist or Not
        public object EmailExistOrNot(Registration reg)
        {


            SqlConnection Mycon = new SqlConnection(Cnstr);
            string RegInsrt = "select * from Registrations where UserName = @UserName";
            SqlCommand cmd = new SqlCommand(RegInsrt, Mycon);
            cmd.Parameters.AddWithValue("@UserName", reg.UserName);
            Mycon.Open();
            object counts = cmd.ExecuteScalar();

            Mycon.Close();
            //if (counts == null)
            //{
            //    string RegInsrt1 = "select * from Admin where EmailId = @emailid";
            //    SqlCommand cmd1 = new SqlCommand(RegInsrt1, Mycon);
            //    cmd1.Parameters.AddWithValue("@emailid", Emailid);

            //    counts = cmd1.ExecuteScalar();
            //}

            return counts;
        } // method close
          // End User Name Exist or Not
        public object EmailExistOrNots(Registration reg)
        {


            SqlConnection Mycon = new SqlConnection(Cnstr);
            string RegInsrt = "select * from Registrations where EmailID = @EmailID";
            SqlCommand cmd = new SqlCommand(RegInsrt, Mycon);
            cmd.Parameters.AddWithValue("@EmailID", reg.EmailID);
            Mycon.Open();
            object counts = cmd.ExecuteScalar();

            //if (counts == null)
            //{
            //    string RegInsrt1 = "select * from Admin where EmailId = @emailid";
            //    SqlCommand cmd1 = new SqlCommand(RegInsrt1, Mycon);
            //    cmd1.Parameters.AddWithValue("@emailid", Emailid);

            //    counts = cmd1.ExecuteScalar();
            //}
            Mycon.Close();
            return counts;
        } // method close

        public object OrgNameExistOrNot(OrganizationDetails org)
        {


            SqlConnection Mycon = new SqlConnection(Cnstr);
            string OrgInsrt = "select * from OrganizationDetails where OrgName = @OrgName";
            SqlCommand cmd = new SqlCommand(OrgInsrt, Mycon);
            cmd.Parameters.AddWithValue("@OrgName", org.OrgName);
            Mycon.Open();
            object counts = cmd.ExecuteScalar();

            Mycon.Close();

            return counts;
        } // method close

        public object CategoryNameExistOrNot(Product_Catagory pc)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            string RegInsrt = "select * from Product_Catagory where Category_Name = @Category_Name";
            SqlCommand cmd = new SqlCommand(RegInsrt, Mycon);
            cmd.Parameters.AddWithValue("@Category_Name", pc.Category_Name);
            Mycon.Open();
            object counts = cmd.ExecuteScalar();

            Mycon.Close();

            return counts;
        } // method close









        public object ProductNameExistOrNot(ProductDetails pd)
        {


            SqlConnection Mycon = new SqlConnection(Cnstr);
            string OrgInsrt = "select * from ProductDetails where ProductName = @ProductName";
            SqlCommand cmd = new SqlCommand(OrgInsrt, Mycon);
            cmd.Parameters.AddWithValue("@ProductName", pd.ProductName);
            Mycon.Open();
            object counts = cmd.ExecuteScalar();
            Mycon.Close();


            return counts;
        } // method close

        public void AddRegistration(Registration reg)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("insert into Registrations values(@Name,@EmailID,@Contact,@UserName,@Password,@RegisteredDate,@ActiveStatus)", Mycon);
            cmd.Parameters.AddWithValue("@Name", reg.Name);
            cmd.Parameters.AddWithValue("@EmailID", reg.EmailID);
            cmd.Parameters.AddWithValue("@Contact", reg.Contact);
            cmd.Parameters.AddWithValue("@UserName", reg.UserName);
            cmd.Parameters.AddWithValue("@Password", reg.Password);
            cmd.Parameters.AddWithValue("@RegisteredDate", DateTime.Now.ToString("MM-dd-yyyy"));
            cmd.Parameters.AddWithValue("@ActiveStatus", 1);


            Mycon.Open();
            cmd.ExecuteNonQuery();

            Mycon.Close();
        }
        public void EditRegistration(Registration reg)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("Update Registrations set Name = @Name, EmailID = @EmailID,Contact = @Contact,ActiveStatus = @ActiveStatus where RID = @RID", Mycon);
            cmd.Parameters.AddWithValue("@RID", reg.RID);
            cmd.Parameters.AddWithValue("@Name", reg.Name);
            cmd.Parameters.AddWithValue("@EmailID", reg.EmailID);
            cmd.Parameters.AddWithValue("@Contact", reg.Contact);
            cmd.Parameters.AddWithValue("@ActiveStatus", reg.ActiveStatus);


            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }
        public void DeleteRegistration(int id)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("Delete Registrations where RID = @RID", Mycon);
            cmd.Parameters.AddWithValue("@RID", id);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }

        // <--------- End Registration Details ----------->

        // @@@@@@@@@@@@@  Customer Details @@@@@@@@@@@@

        public void AddCustomerSupplier(CustomerDetails reg)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("insert into CustomerDetails values(@CustName,@CustContact,@CustEmail,@CustAddress,@CustPinCode,@CustState,@CustDistrict,@CustFssaiNumber,@CustGstNumber,@CustStatus)", Mycon);

            cmd.Parameters.AddWithValue("@CustName", reg.CustName);
            cmd.Parameters.AddWithValue("@CustContact", reg.CustContact);
            cmd.Parameters.AddWithValue("@CustEmail", reg.CustEmail);
            cmd.Parameters.AddWithValue("@CustAddress", reg.CustAddress);
            cmd.Parameters.AddWithValue("@CustPinCode", reg.CustPinCode);
            cmd.Parameters.AddWithValue("@CustState", reg.CustState);
            cmd.Parameters.AddWithValue("@CustDistrict", reg.CustDistrict);
            cmd.Parameters.AddWithValue("@CustFssaiNumber", reg.CustFssaiNumber);
            cmd.Parameters.AddWithValue("@CustGstNumber", reg.CustGstNumber);
            cmd.Parameters.AddWithValue("@CustStatus", 1);




            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();


        }
        public void EditCustomerSupplier(CustomerDetails reg)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("update CustomerDetails set CustName = @CustName, CustContact = @CustContact,CustEmail = @CustEmail, CustAddress = @CustAddress, CustPinCode = @CustPinCode,CustState = @CustState,CustDistrict = @CustDistrict,CustFssaiNumber = @CustFssaiNumber, CustGstNumber = @CustGstNumber,CustStatus = @CustStatus where CustID = @CustID ", Mycon);

            cmd.Parameters.AddWithValue("@CustID", reg.CustID);
            cmd.Parameters.AddWithValue("@CustName", reg.CustName);
            cmd.Parameters.AddWithValue("@CustContact", reg.CustContact);
            cmd.Parameters.AddWithValue("@CustEmail", reg.CustEmail);
            cmd.Parameters.AddWithValue("@CustAddress", reg.CustAddress);
            cmd.Parameters.AddWithValue("@CustPinCode", reg.CustPinCode);
            cmd.Parameters.AddWithValue("@CustState", reg.CustState);
            cmd.Parameters.AddWithValue("@CustDistrict", reg.CustDistrict);
            cmd.Parameters.AddWithValue("@CustFssaiNumber", reg.CustFssaiNumber);
            cmd.Parameters.AddWithValue("@CustGstNumber", reg.CustGstNumber);
            cmd.Parameters.AddWithValue("@CustStatus", reg.CustStatus);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }
        public void DeleteCustomerSupplier(int id)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("Delete CustomerDetails where CustID = @CustID", Mycon);
            cmd.Parameters.AddWithValue("@CustID", id);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }

        // <--------- Customer Details ----------->

        public List<District> DistList(int Sid)
        {

            List<District> lstDist = new List<District>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            string sqlSelect = "select * from Districts where SId = @SId";
            SqlCommand cmd = new SqlCommand(sqlSelect, Mycon);

            cmd.Parameters.AddWithValue("@SId", Sid);
            try
            {
                Mycon.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    District dist = new District();

                    dist.DistId = Convert.ToInt32(reader["DistId"]);
                    dist.DistName = reader["DistName"].ToString();
                    lstDist.Add(dist);
                }
                Mycon.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return lstDist;
        }


        // @@@@@@ Delete Product Details @@@@@

        public void DeleteProduct(int id)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("Delete ProductDetails where PDID = @PDID", Mycon);
            cmd.Parameters.AddWithValue("@PDID", id);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }

        //<--------- Delete Product Details --------->

        // @@@@@@ Organization Details @@@@@@@

        public void AddOrgnizationDetails(OrganizationDetails Org, HttpPostedFileBase OrgImg, HttpPostedFileBase SignatureImg)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("insert into OrganizationDetails values(@OrgName,@OrgContact,@OrgEmailID,@OrgAddress,@OrgFssaiNumber,@OrgGstNumber,@OrgPinCode,@OrgState,@OrgImage,@OrgStatus,@OrgDegitalSignature)", Mycon);


            if (OrgImg != null && OrgImg.ContentLength > 0)
            {
                string filename = Path.GetFileName(OrgImg.FileName);
                string filext = Path.GetExtension(filename);

                if (filext == ".jpg" || filext == ".png" || filext == ".jpeg" || filext == ".JPG" || filext == ".PNG" || filext == ".JPEG")
                {

                    Byte[] OrgImgbytes = null;

                    Stream fs = OrgImg.InputStream;

                    BinaryReader br = new BinaryReader(fs);

                    OrgImgbytes = br.ReadBytes((Int32)fs.Length);


                    Byte[] SignatureImgbytes2 = null;

                    Stream fs2 = SignatureImg.InputStream;

                    BinaryReader br2 = new BinaryReader(fs2);

                    SignatureImgbytes2 = br2.ReadBytes((Int32)fs2.Length);







                    cmd.Parameters.AddWithValue("@OrgName", Org.OrgName);
                    cmd.Parameters.AddWithValue("@OrgContact", Org.OrgContact);
                    cmd.Parameters.AddWithValue("@OrgEmailID", Org.OrgEmailID);
                    cmd.Parameters.AddWithValue("@OrgAddress", Org.OrgAddress);
                    cmd.Parameters.AddWithValue("@OrgFssaiNumber", Org.OrgFssaiNumber);
                    cmd.Parameters.AddWithValue("@OrgGstNumber", Org.OrgGstNumber);
                    cmd.Parameters.AddWithValue("@OrgPinCode", Org.OrgPinCode);
                    cmd.Parameters.AddWithValue("@OrgState", Org.OrgState);

                    //string filepath = Path.Combine(HttpContext.Current.Server.MapPath("~/image/"), filename);
                    //file.SaveAs(HttpContext.Current.Server.MapPath("~/images/" + DateTime.Now.ToString("MM/dd/yyyy HH/mm/ss") + file.FileName));



                    //  cmd.Parameters.AddWithValue("@Img", );

                    cmd.Parameters.AddWithValue("@OrgDegitalSignature", SignatureImgbytes2);
                    cmd.Parameters.AddWithValue("@OrgImage", OrgImgbytes /*Org.OrgImage*/);

                    cmd.Parameters.AddWithValue("@OrgStatus", 1);





                    try
                    {

                        Mycon.Open();
                        cmd.ExecuteNonQuery();
                        Mycon.Close();


                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                else
                {
                    //  conts = 2;


                }

            } // if condition close


        }
        public void EditOrgnizationDetails(OrganizationDetails Org, HttpPostedFileBase OrgImg, HttpPostedFileBase SignatureImg)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);


            string Query = "";

            if (OrgImg != null)
            {
                Query = "Update OrganizationDetails set OrgName = @OrgName,OrgContact = @OrgContact,OrgEmailID = @OrgEmailID,OrgAddress = @OrgAddress,OrgFssaiNumber = @OrgFssaiNumber,OrgGstNumber = @OrgGstNumber,OrgPinCode = @OrgPinCode,OrgState = @OrgState,OrgImage = @OrgImage,OrgStatus = @OrgStatus where OrgID = @OrgID";
            }

            if (SignatureImg != null)
            {
                Query = "Update OrganizationDetails set OrgName = @OrgName,OrgContact = @OrgContact,OrgEmailID = @OrgEmailID,OrgAddress = @OrgAddress,OrgFssaiNumber = @OrgFssaiNumber,OrgGstNumber = @OrgGstNumber,OrgPinCode = @OrgPinCode,OrgState = @OrgState,OrgStatus = @OrgStatus,OrgDegitalSignature = @OrgDegitalSignature where OrgID = @OrgID";
            }

            if (OrgImg != null && SignatureImg != null)
            {
                Query = "Update OrganizationDetails set OrgName = @OrgName,OrgContact = @OrgContact,OrgEmailID = @OrgEmailID,OrgAddress = @OrgAddress,OrgFssaiNumber = @OrgFssaiNumber,OrgGstNumber = @OrgGstNumber,OrgPinCode = @OrgPinCode,OrgState = @OrgState,OrgImage = @OrgImage,OrgStatus = @OrgStatus,OrgDegitalSignature = @OrgDegitalSignature where OrgID = @OrgID";
            }

            if (OrgImg == null && SignatureImg == null)
            {
                Query = "Update OrganizationDetails set OrgName = @OrgName,OrgContact = @OrgContact,OrgEmailID = @OrgEmailID,OrgAddress = @OrgAddress,OrgFssaiNumber = @OrgFssaiNumber,OrgGstNumber = @OrgGstNumber,OrgPinCode = @OrgPinCode,OrgState = @OrgState,OrgStatus = @OrgStatus where OrgID = @OrgID";
            }

            SqlCommand cmd = new SqlCommand(Query, Mycon);

            //    string filename = Path.GetFileName(OrgImg.FileName);
            //  
            //    string filext = Path.GetExtension(filename);




            cmd.Parameters.AddWithValue("@OrgID", Org.OrgID);
            cmd.Parameters.AddWithValue("@OrgName", Org.OrgName);
            cmd.Parameters.AddWithValue("@OrgContact", Org.OrgContact);
            cmd.Parameters.AddWithValue("@OrgEmailID", Org.OrgEmailID);
            cmd.Parameters.AddWithValue("@OrgAddress", Org.OrgAddress);
            cmd.Parameters.AddWithValue("@OrgFssaiNumber", Org.OrgFssaiNumber);
            cmd.Parameters.AddWithValue("@OrgGstNumber", Org.OrgGstNumber);
            cmd.Parameters.AddWithValue("@OrgPinCode", Org.OrgPinCode);
            cmd.Parameters.AddWithValue("@OrgState", Org.OrgState);





            if (OrgImg != null)
            {

                // Convert to Byte
                Byte[] OrgImgbytes = null;
                Stream fs = OrgImg.InputStream;
                BinaryReader br = new BinaryReader(fs);
                OrgImgbytes = br.ReadBytes((Int32)fs.Length);
                // Convert to Byte


                cmd.Parameters.AddWithValue("@OrgImage", OrgImgbytes /*Org.OrgImage*/);
            }

            if (SignatureImg != null)
            {
                // Convert to Byte
                Byte[] SignatureImgbytes2 = null;
                Stream fs2 = SignatureImg.InputStream;
                BinaryReader br2 = new BinaryReader(fs2);
                SignatureImgbytes2 = br2.ReadBytes((Int32)fs2.Length);
                // Convert to Byte

                cmd.Parameters.AddWithValue("@OrgDegitalSignature", SignatureImgbytes2);
            }

            if (OrgImg != null && SignatureImg != null)
            {
                // Convert to Byte
                Byte[] OrgImgbytes = null;
                Stream fs = OrgImg.InputStream;
                BinaryReader br = new BinaryReader(fs);
                OrgImgbytes = br.ReadBytes((Int32)fs.Length);

                Byte[] SignatureImgbytes2 = null;
                Stream fs2 = SignatureImg.InputStream;
                BinaryReader br2 = new BinaryReader(fs2);
                SignatureImgbytes2 = br2.ReadBytes((Int32)fs2.Length);
                // Convert to Byte

                cmd.Parameters.AddWithValue("@OrgDegitalSignature", SignatureImgbytes2);
                cmd.Parameters.AddWithValue("@OrgImage", OrgImgbytes /*Org.OrgImage*/);
            }
            cmd.Parameters.AddWithValue("@OrgStatus", 1);


            try
            {
                Mycon.Open();
                cmd.ExecuteNonQuery();
                Mycon.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void DeleteOrganization(int id)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("Delete OrganizationDetails where OrgID = @OrgID", Mycon);
            cmd.Parameters.AddWithValue("@OrgID", id);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }
        // <------- End Organization Details ---------->

        // @@@@@@@@@ Bank Details @@@@@@@@
        public void AddBankDeatils(BankDetails Bd)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("insert into BankDetails values(@BnkName,@BnkBranchName,@BnkAddress,@BnkIFSCNumber,@BnkAccountNumber,@OrgID)", Mycon);

            cmd.Parameters.AddWithValue("@BnkName", Bd.BnkName);
            cmd.Parameters.AddWithValue("@BnkBranchName", Bd.BnkBranchName);
            cmd.Parameters.AddWithValue("@BnkAddress", Bd.BnkAddress);
            cmd.Parameters.AddWithValue("@BnkIFSCNumber", Bd.BnkIFSCNumber);
            cmd.Parameters.AddWithValue("@BnkAccountNumber", Bd.BnkAccountNumber);
            cmd.Parameters.AddWithValue("@OrgID", Bd.OrgID);
            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }
        public void EditBankDeatils(BankDetails Bd)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("Update BankDetails set BnkName = @BnkName,BnkBranchName = @BnkBranchName,BnkAddress = @BnkAddress,BnkIFSCNumber = @BnkIFSCNumber,BnkAccountNumber = @BnkAccountNumber,OrgID = @OrgID where BnkDID = @BnkDID", Mycon);
            cmd.Parameters.AddWithValue("@BnkDID", Bd.BnkDID);
            cmd.Parameters.AddWithValue("@BnkName", Bd.BnkName);
            cmd.Parameters.AddWithValue("@BnkBranchName", Bd.BnkBranchName);
            cmd.Parameters.AddWithValue("@BnkAddress", Bd.BnkAddress);
            cmd.Parameters.AddWithValue("@BnkIFSCNumber", Bd.BnkIFSCNumber);
            cmd.Parameters.AddWithValue("@BnkAccountNumber", Bd.BnkAccountNumber);
            cmd.Parameters.AddWithValue("@OrgID", Bd.OrgID);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }
        public void DeleteBankDetails(int id)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("Delete BankDetails where BnkDID = @BnkDID", Mycon);
            cmd.Parameters.AddWithValue("@BnkDID", id);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }

        //<-------- End Bank Details -------->


        // @@@@@@@@ Temp Purchase Details @@@@@@@@@

        public void AddPurchaseForReports(PurchaseDtl pd, int id)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            string QueryPurRep;

            if (id == 0)
            {
                QueryPurRep = "insert into PurchaseForReports values(@PrBillNo,@Prdate,@PrGrandTotal,@PrFinalTotal)";
            }
            else
            {
                QueryPurRep = "update PurchaseForReports set Prdate = @Prdate, PrGrandTotal = @PrGrandTotal, PrFinalTotal = @PrFinalTotal where PrBillNo = @PrBillNo";
            }


            SqlCommand cmd = new SqlCommand(QueryPurRep, Mycon);
            cmd.Parameters.AddWithValue("@PrBillNo", pd.PurBillNo);
            cmd.Parameters.AddWithValue("@Prdate", pd.PurDate);
            cmd.Parameters.AddWithValue("@PrGrandTotal", pd.GrandTot);
            cmd.Parameters.AddWithValue("@PrFinalTotal", pd.TotalAmt);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }

        //public void CheckBillNoExist_In_PurchaseReport(string Billno)
        //{

        //    SqlConnection Mycon = new SqlConnection(Cnstr);

        //    string AddPurForRepo = ")";
        //    SqlCommand cmd = new SqlCommand(AddPurForRepo, Mycon);
        //    cmd.Parameters.AddWithValue("@PrBillNo", pd.PurBillNo);
        //    cmd.Parameters.AddWithValue("@Prdate", pd.PurDate);
        //    cmd.Parameters.AddWithValue("@PrGrandTotal", pd.GrandTot);
        //    cmd.Parameters.AddWithValue("@PrFinalTotal", pd.TotalAmt);

        //    Mycon.Open();
        //    cmd.ExecuteNonQuery();

        //}




        public void AddPurchaseReportBill(PurchaseDtl pd)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);



            string checkbillno = "select * from PurchaseReportBills where PrRBBillNo = @PrRBBillNo";
            SqlCommand cmd1 = new SqlCommand(checkbillno, Mycon);
            cmd1.Parameters.AddWithValue("@PrRBBillNo", pd.PurBillNo);
            Mycon.Open();
            object counts = cmd1.ExecuteScalar();
            Mycon.Close();


            SqlCommand cmd;

            if (counts != null)
            {
                cmd = new SqlCommand("update PurchaseReportBills set PrRBDiscountRs = @PrRBDiscountRs, PrRBDiscountPer = @PrRBDiscountPer, PrRBCharges = @PrRBCharges,PrRBNote = @PrRBNote where PrRBBillNo = @PrRBBillNo", Mycon);
            }
            else
            {
                cmd = new SqlCommand("insert into PurchaseReportBills values(@PrRBDiscountRs,@PrRBDiscountPer,@PrRBCharges,@PrRBBillNo,@PrRBNote)", Mycon);
            }


            cmd.Parameters.AddWithValue("@PrRBBillNo", pd.PurBillNo);
            cmd.Parameters.AddWithValue("@PrRBDiscountRs", Convert.ToDecimal(pd.DiscRs));
            cmd.Parameters.AddWithValue("@PrRBDiscountPer", Convert.ToDecimal(pd.DiscPer));
            cmd.Parameters.AddWithValue("@PrRBCharges", Convert.ToDecimal(pd.Charges));
            cmd.Parameters.AddWithValue("@PrRBNote", "Good");


            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();


        }
        public void AddTempPurchaseDeatils(PurchaseDtl pd)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("insert into TempDataPurchases values(@TempPurSuppCustName,@TempPurBillNo,@TempPurProductID,@TempPurProductRate,@TempPurDiscount,@TempPurQuantity,@TempPurGstRs,@TempPurTotal,@TempPurDate,@WearhouseRefID)", Mycon);
            cmd.Parameters.AddWithValue("@TempPurSuppCustName", Convert.ToInt32(pd.PurSuppCustId));
            cmd.Parameters.AddWithValue("@TempPurBillNo", pd.PurBillNo);
            cmd.Parameters.AddWithValue("@TempPurProductID", Convert.ToInt32(pd.PurProductID));
            cmd.Parameters.AddWithValue("@TempPurProductRate", Convert.ToDecimal(pd.ProductRate));

            cmd.Parameters.AddWithValue("@TempPurDiscount", pd.PurDiscount);
            cmd.Parameters.AddWithValue("@TempPurQuantity", pd.PurQuantity);

            decimal Prorate, ProQunt;
            Prorate = Convert.ToDecimal(pd.ProductRate);
            ProQunt = pd.PurQuantity;


            decimal GrandTotal = Prorate * ProQunt;
            decimal gst = pd.ProductGst;

            decimal GstRs = GrandTotal * gst / 100;


            cmd.Parameters.AddWithValue("@TempPurGstRs", GstRs);

            cmd.Parameters.AddWithValue("@TempPurTotal", GrandTotal);

            cmd.Parameters.AddWithValue("@TempPurDate", Convert.ToDateTime(pd.PurDate).ToString("MM-dd-yyyy"));

            cmd.Parameters.AddWithValue("@WearhouseRefID", pd.WearhouseRefID);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }
        public void AddPurchaseDeatils(PurchaseDtl pd)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("insert into PurchaseDtls values(@PurSuppCustName,@PurBillNo,@PurProductRate,@PurProductID,@PurDiscount,@PurQuantity,@PurGstRs,@PurTotal,@PurDate,@WearhouseRefID)", Mycon);

            cmd.Parameters.AddWithValue("@PurSuppCustName", Convert.ToInt32(pd.PurSuppCustId));
            cmd.Parameters.AddWithValue("@PurBillNo", pd.PurBillNo);
            cmd.Parameters.AddWithValue("@PurProductRate", pd.PurProductRate);
            cmd.Parameters.AddWithValue("@PurProductID", Convert.ToInt32(pd.PurProductID));
            cmd.Parameters.AddWithValue("@PurDiscount", pd.PurDiscount);
            cmd.Parameters.AddWithValue("@PurQuantity", pd.PurQuantity);
            cmd.Parameters.AddWithValue("@PurGstRs", pd.PurGstRs);
            cmd.Parameters.AddWithValue("@PurTotal", pd.PurTotal);
            cmd.Parameters.AddWithValue("@PurDate", Convert.ToDateTime(pd.PurDate).ToString("MM-dd-yyyy"));
            cmd.Parameters.AddWithValue("@WearhouseRefID", pd.WearhouseRefID);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }

        // if we click on update Button in purchaseList Form then automatically function call and insert the data
        public void AddTempPurchaseIntoPurchase(TempDataPurchase pd)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("insert into TempDataPurchases values(@TempPurSuppCustName,@TempPurBillNo,@TempPurProductID,@TempPurProductRate,@TempPurDiscount,@TempPurQuantity,@TempPurGstRs,@TempPurTotal,@TempPurDate,@WearhouseRefID)", Mycon);
            cmd.Parameters.AddWithValue("@TempPurSuppCustName", Convert.ToInt32(pd.TempPurSuppCustName));
            cmd.Parameters.AddWithValue("@TempPurBillNo", pd.TempPurBillNo);
            cmd.Parameters.AddWithValue("@TempPurProductID", Convert.ToInt32(pd.TempPurProductID));
            cmd.Parameters.AddWithValue("@TempPurProductRate", Convert.ToDecimal(pd.TempPurProductRate));
            cmd.Parameters.AddWithValue("@TempPurDiscount", pd.TempPurDiscount);
            cmd.Parameters.AddWithValue("@TempPurQuantity", pd.TempPurQuantity);

            decimal Prorate, ProQunt;
            Prorate = Convert.ToDecimal(pd.TempPurProductRate);
            ProQunt = pd.TempPurQuantity;

            cmd.Parameters.AddWithValue("@TempPurGstRs", pd.TempPurGstRs);
            cmd.Parameters.AddWithValue("@TempPurTotal", Prorate * ProQunt);
            cmd.Parameters.AddWithValue("@TempPurDate", Convert.ToDateTime(pd.TempPurDate).ToString("MM-dd-yyyy"));
            cmd.Parameters.AddWithValue("@WearhouseRefID", pd.WearhouseRefID);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }
        // End of 
        public void DeletePurchaseDeatils() // this is temp data delete function
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("Truncate table TempDataPurchases", Mycon);
            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }
        public void DeletePurchaseForReports(string BillNo) // this is temp data delete function
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("delete  PurchaseForReports where PrBillNo = @PrBillNo", Mycon);
            cmd.Parameters.AddWithValue("@PrBillNo", BillNo);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }

        public void DeletePurchaseReportBills(string BillNo) // this is temp data delete function
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("delete  PurchaseReportBills where PrRBBillNo = @PrRBBillNo", Mycon);
            cmd.Parameters.AddWithValue("@PrRBBillNo", BillNo);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }

        //DeletePurchaseForReports(BillNo)

        public void DeletePurchaseDeatils(string BillNo)  // This is purchase data delete function
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("delete PurchaseDtls where PurBillNo = @PurBillNo", Mycon);
            cmd.Parameters.AddWithValue("@PurBillNo", BillNo);
            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }
        // cal Gst

        public object TotalDiscountPurchaseDtl()
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT SUM(TempPurDiscount) FROM TempDataPurchases", Mycon);
            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }
        public object SumOfQuntPurchaseDtl()
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT SUM(TempPurQuantity) FROM TempDataPurchases", Mycon);
            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }
        public object SumOfProductRatePurchaseDtl()
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT SUM(ProductDetails.ProductPurchaseRate) FROM TempDataPurchases inner join ProductDetails on TempDataPurchases.TempPurProductID = ProductDetails.PDID", Mycon);


            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }
        public object SumOfProductGSTPurchaseDtl()
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            // SqlCommand cmd = new SqlCommand("SELECT SUM(ProductGSTs.ProdGst) FROM TempDataPurchases inner join ProductDetails on TempDataPurchases.TempPurProductID = ProductDetails.PDID inner join ProductGSTs on ProductDetails.GstPercent = ProductGSTs.ProdGstID", Mycon);
            SqlCommand cmd = new SqlCommand("SELECT SUM(TempPurGstRs) FROM TempDataPurchases", Mycon);
            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }
        public object SumOfPurTotalDtl()
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT SUM(TempPurTotal) FROM TempDataPurchases", Mycon);

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }
        public object RowCountPurchaseDtl()
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM TempDataPurchases", Mycon);
            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }








        // end

        public void EditTempPurchaseDeatils(PurchaseDtl pd)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("Update TempDataPurchases set TempPurSuppCustName = @TempPurSuppCustName, TempPurBillNo = @TempPurBillNo,TempPurProductID = @TempPurProductID,TempPurProductRate = @TempPurProductRate,TempPurDiscount = @TempPurDiscount,TempPurQuantity = @TempPurQuantity,TempPurGstRs = @TempPurGstRs, TempPurTotal = @TempPurTotal,TempPurDate = @TempPurDate, WearhouseRefID = @WearhouseRefID where TempPurID = @TempPurID", Mycon);

            cmd.Parameters.AddWithValue("@TempPurID", Convert.ToInt32(pd.PurID));
            cmd.Parameters.AddWithValue("@TempPurSuppCustName", Convert.ToInt32(pd.PurSuppCustId));
            cmd.Parameters.AddWithValue("@TempPurBillNo", pd.PurBillNo);
            cmd.Parameters.AddWithValue("@TempPurProductID", Convert.ToInt32(pd.PurProductID));

            cmd.Parameters.AddWithValue("@TempPurProductRate", Convert.ToInt32(pd.ProductRate));


            cmd.Parameters.AddWithValue("@TempPurDiscount", pd.PurDiscount);
            cmd.Parameters.AddWithValue("@TempPurQuantity", pd.PurQuantity);

            decimal Prorate, ProQunt;
            Prorate = Convert.ToDecimal(pd.ProductRate);
            ProQunt = pd.PurQuantity;






            decimal GrandTotal = Prorate * ProQunt;
            decimal gst = pd.ProductGst;

            decimal GstRs = GrandTotal * gst / 100;


            cmd.Parameters.AddWithValue("@TempPurGstRs", GstRs);

            cmd.Parameters.AddWithValue("@TempPurTotal", GrandTotal);
            cmd.Parameters.AddWithValue("@TempPurDate", Convert.ToDateTime(pd.PurDate).ToString("MM-dd-yyyy"));
            cmd.Parameters.AddWithValue("@WearhouseRefID", pd.WearhouseRefID);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }
        public void DeleteTempData(int id)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("delete TempDataPurchases where TempPurID = @TempPurID", Mycon);

            cmd.Parameters.AddWithValue("@TempPurID", Convert.ToInt32(id));
            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }

        public void Delete_PurchaseDtls(string BillNo)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("delete PurchaseDtls where PurBillNo = @PurBillNo", Mycon);
            cmd.Parameters.AddWithValue("@PurBillNo", BillNo);
            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }

        public int Count_PurchaseDtls(string BillNo)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("select count(*) from PurchaseDtls where PurBillNo = @PurBillNo", Mycon);
            cmd.Parameters.AddWithValue("@PurBillNo", BillNo);
            Mycon.Open();
            int Rslt = Convert.ToInt32(cmd.ExecuteScalar());
            Mycon.Close();
            return Rslt;

        }

        public List<PurchaseDtl> QuantitySum_TempPurchaseDtl(string BillNo) // This is purchasedtl 
        {


            List<PurchaseDtl> lstQty = new List<PurchaseDtl>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            string sqlSelect = "select tdp.PurProductID as TempPurProductID, pd.ProductName, sum(tdp.PurQuantity) as QtySum from PurchaseDtls as tdp join ProductDetails as pd on pd.PDID = tdp.PurProductID  where tdp.PurBillNo = @PurBillNo group by tdp.PurProductID, pd.ProductName";

            SqlCommand cmd = new SqlCommand(sqlSelect, Mycon);
            cmd.Parameters.AddWithValue("@PurBillNo", BillNo);

            try
            {
                Mycon.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PurchaseDtl pdtl = new PurchaseDtl();

                    pdtl.PurProductID = Convert.ToInt32(reader["TempPurProductID"]);
                    pdtl.SplrCustName = reader["ProductName"].ToString();
                    pdtl.QtySum = Convert.ToDecimal(reader["QtySum"]);


                    lstQty.Add(pdtl);
                }
                Mycon.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return lstQty;
        }

        public List<PurchaseDtl> QuantitySum_TempPurchaseDtl()
        {

            List<PurchaseDtl> lstQty = new List<PurchaseDtl>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            string sqlSelect = "select tdp.TempPurProductID, pd.ProductName, sum(tdp.TempPurQuantity) as QtySum from TempDataPurchases as tdp join ProductDetails as pd on pd.PDID = tdp.TempPurProductID group by tdp.TempPurProductID, pd.ProductName";

            SqlCommand cmd = new SqlCommand(sqlSelect, Mycon);
            try
            {
                Mycon.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PurchaseDtl pdtl = new PurchaseDtl();

                    pdtl.PurProductID = Convert.ToInt32(reader["TempPurProductID"]);
                    pdtl.SplrCustName = reader["ProductName"].ToString();
                    pdtl.QtySum = Convert.ToDecimal(reader["QtySum"]);


                    lstQty.Add(pdtl);
                }
                Mycon.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return lstQty;
        }


        public void Add_Sub_ProductQty(int PdId, decimal PdQty, string action)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);


            string SqlQuery = "";

            if (action == "Add")
            {
                SqlQuery = "UPDATE ProductDetails  SET Opening_Stock_Qty = Opening_Stock_Qty + @Opening_Stock_Qty where PDID = @PDID";
            }

            if (action == "Sub")
            {
                SqlQuery = "UPDATE ProductDetails  SET Opening_Stock_Qty = Opening_Stock_Qty - @Opening_Stock_Qty where PDID = @PDID";
            }


            SqlCommand cmd = new SqlCommand(SqlQuery, Mycon);

            cmd.Parameters.AddWithValue("@Opening_Stock_Qty", Convert.ToDecimal(PdQty));
            cmd.Parameters.AddWithValue("@PDID", Convert.ToInt32(PdId));


            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }







        // <---------  Temp Purchase Details  --------->

        // @@@@@@@@ Temp Purchase Details @@@@@@@@@


        public void DeletePurchaseDetails(string BillNo)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("delete PurchaseDtls where PurBillNo = @PurBillNo", Mycon);
            cmd.Parameters.AddWithValue("@PurBillNo", BillNo);
            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }




        public void EditPurchaseDeatils(PurchaseDtl pd)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("Update PurchaseDtls set PurSuppCustId = @PurSuppCustId, PurBillNo = @PurBillNo,PurProductID = @PurProductID,PurDiscount = @PurDiscount,PurQuantity = @PurQuantity,PurDate = @PurDate where PurID = @PurID", Mycon);



            cmd.Parameters.AddWithValue("@PurID", Convert.ToInt32(pd.PurID));
            cmd.Parameters.AddWithValue("@PurSuppCustId", Convert.ToInt32(pd.PurSuppCustId));
            cmd.Parameters.AddWithValue("@PurBillNo", pd.PurBillNo);
            cmd.Parameters.AddWithValue("@PurProductID", Convert.ToInt32(pd.PurProductID));
            cmd.Parameters.AddWithValue("@PurDiscount", pd.PurDiscount);
            cmd.Parameters.AddWithValue("@PurQuantity", pd.PurQuantity);
            cmd.Parameters.AddWithValue("@PurDate", Convert.ToDateTime(pd.PurDate).ToString("MM-dd-yyyy"));
            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();


        }
        public object BillnoExistorNot(string PurBillNo)
        {


            SqlConnection Mycon = new SqlConnection(Cnstr);
            string RegInsrt = "select * from PurchaseDtls where PurBillNo = @PurBillNo";
            SqlCommand cmd = new SqlCommand(RegInsrt, Mycon);
            cmd.Parameters.AddWithValue("@PurBillNo", PurBillNo);
            Mycon.Open();
            object counts = cmd.ExecuteScalar();
            Mycon.Close();
            return counts;
        }
        public object BillnoExistorNotInTempData(string PurBillNo)
        {


            SqlConnection Mycon = new SqlConnection(Cnstr);
            string RegInsrt = "select * from TempDataPurchases where TempPurBillNo = @TempPurBillNo";
            SqlCommand cmd = new SqlCommand(RegInsrt, Mycon);
            cmd.Parameters.AddWithValue("@TempPurBillNo", PurBillNo);
            Mycon.Open();
            object counts = cmd.ExecuteScalar();
            Mycon.Close();
            return counts;
        }

        public object TempOrgNameExistorNot(int id)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);
            string RegInsrt = "select * from TempDataPurchases where TempPurSuppCustName = @TempPurSuppCustName";
            SqlCommand cmd = new SqlCommand(RegInsrt, Mycon);
            cmd.Parameters.AddWithValue("@TempPurSuppCustName", id);
            Mycon.Open();
            object counts = cmd.ExecuteScalar();
            Mycon.Close();
            return counts;
        }
        public object CustSuppExistOrNot(int id)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);
            string RegInsrt = "select * from CustomerDetails where CustID = @CustID";
            SqlCommand cmd = new SqlCommand(RegInsrt, Mycon);
            cmd.Parameters.AddWithValue("@CustID", id);
            Mycon.Open();
            object counts = cmd.ExecuteScalar();
            Mycon.Close();
            return counts;
        }

        // <--------- Purchase Details  --------->




        // @@@@@@@@@@@@@@ Payment from Supplier @@@@@@@@@@

        // Payment from Supplier
        public void AddPaymentfromSupplier(CustSuppPayment csp)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("insert into CustSuppPayments values(@SupCustID,@SupCustBillNo,@SupCustPaidAmt)", Mycon);

            cmd.Parameters.AddWithValue("@SupCustID", Convert.ToInt32(csp.SupCustID));
            cmd.Parameters.AddWithValue("@SupCustBillNo", csp.SupCustBillNo);
            cmd.Parameters.AddWithValue("@SupCustPaidAmt", 0);


            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }






        public List<CustSuppPayment> ListCustSuppPayments()
        {
            List<CustSuppPayment> lst = new List<CustSuppPayment>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("select * from CustSuppPayments as c join CustomerDetails as cd on c.SupCustID = cd.CustID left join PurchaseForReports as pr on pr.PrBillNo = c.SupCustBillNo", Mycon);

            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                CustSuppPayment cp = new CustSuppPayment();


                cp.SupCustPayID = Convert.ToInt32(dr["SupCustPayID"]);
                cp.CustName = dr["CustName"].ToString();
                cp.SupCustBillNo = dr["SupCustBillNo"].ToString();

                if (!(dr["PrFinalTotal"] is DBNull))
                {
                    cp.SupCustBillAmt = Convert.ToDecimal(dr["PrFinalTotal"]);
                }




                lst.Add(cp);
            }
            Mycon.Close();
            return lst;
        }





        public void UpdatePaymentfromSupplier(CustSuppPayment csp)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("update CustSuppPayments set SupCustID = @SupCustID,SupCustBillNo = @SupCustBillNo,SupCustBillAmt = @SupCustBillAmt,SupCustPaidAmt = @SupCustPaidAmt,SupCustoutstanding = @SupCustoutstanding,SupCustStatus = @SupCustStatus where SupCustPayID = @SupCustPayID", Mycon);

            cmd.Parameters.AddWithValue("@SupCustPayID", Convert.ToInt32(csp.SupCustPayID));
            cmd.Parameters.AddWithValue("@SupCustID", Convert.ToInt32(csp.SupCustID));
            cmd.Parameters.AddWithValue("@SupCustBillNo", csp.SupCustBillNo);
            cmd.Parameters.AddWithValue("@SupCustBillAmt", Convert.ToInt32(csp.SupCustBillAmt));
            cmd.Parameters.AddWithValue("@SupCustPaidAmt", Convert.ToInt32(csp.SupCustPaidAmt));
            cmd.Parameters.AddWithValue("@SupCustoutstanding", csp.SupCustoutstanding);
            cmd.Parameters.AddWithValue("@SupCustStatus", csp.SupCustStatus);


            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }
        public void DeletePaymentfromSupplier(int id)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("Delete CustSuppPayments where SupCustPayID = @SupCustPayID", Mycon);

            cmd.Parameters.AddWithValue("@SupCustPayID", id);


            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }


        public void Delete_Transaction_Purchase(string BillNo)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("Delete CustSupTransactions where TranBillNo = @TranBillNo", Mycon);

            cmd.Parameters.AddWithValue("@TranBillNo", BillNo);


            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }

        // End

        // Transaction
        public object SumOfReciAmt(string BillNo)
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT SUM(TranReciAmt) FROM CustSupTransactions where TranBillNo = @TranBillNo", Mycon);
            cmd.Parameters.AddWithValue("@TranBillNo", BillNo);
            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }
        // Add Recived Amt Sum inside the Payment Table
        public void TraReciAmtGet(string BillNo)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("select sum(TranReciAmt) from CustSupTransactions where TranBillNo = @TranBillNo", Mycon);
            cmd.Parameters.AddWithValue("@TranBillNo", BillNo);
            Mycon.Open();
            object obj = cmd.ExecuteScalar();
            Mycon.Close();
            decimal TraReciAmtSum = Convert.ToDecimal(obj);
            SuppCustPaidAmtUpdate(TraReciAmtSum, BillNo);

        }
        public void SuppCustPaidAmtUpdate(decimal TraReciAmtSum, string BillNo)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("Update CustSuppPayments set SupCustPaidAmt = @SupCustPaidAmt where SupCustBillNo = @SupCustBillNo", Mycon);
            cmd.Parameters.AddWithValue("@SupCustPaidAmt", TraReciAmtSum);
            cmd.Parameters.AddWithValue("@TranBillNo", BillNo);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }
        // End Payment Table

        public void AddTransaction(CustSupTransaction csp)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("insert into CustSupTransactions values(@CustSuppId,@TranReciAmt,@TranPayMethod,@ChequeNo,@TranNote,@TranDate,@TranBillNo)", Mycon);

            cmd.Parameters.AddWithValue("@CustSuppId", Convert.ToInt32(csp.CustSuppId));
            cmd.Parameters.AddWithValue("@TranReciAmt", csp.TranReciAmt);
            cmd.Parameters.AddWithValue("@TranPayMethod", Convert.ToInt32(csp.TranPayMethod));
            if (csp.ChequeNo == null)
            {
                cmd.Parameters.AddWithValue("@ChequeNo", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ChequeNo", csp.ChequeNo);
            }
            cmd.Parameters.AddWithValue("@TranNote", csp.TranNote);
            cmd.Parameters.AddWithValue("@TranDate", csp.TranDate);
            cmd.Parameters.AddWithValue("@TranBillNo", csp.TranBillNo);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }
        public void UpdateTransaction(CustSupTransaction csp)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("update CustSupTransactions set CustSuppId = @CustSuppId,TranReciAmt = @TranReciAmt,TranPayMethod = @TranPayMethod,ChequeNo = @ChequeNo,TranNote = @TranNote,TranDate = @TranDate,TranBillNo = @TranBillNo where TranId = @TranId", Mycon);

            cmd.Parameters.AddWithValue("@TranId", Convert.ToInt32(csp.TranId));
            cmd.Parameters.AddWithValue("@CustSuppId", Convert.ToInt32(csp.CustSuppId));
            cmd.Parameters.AddWithValue("@TranReciAmt", csp.TranReciAmt);
            cmd.Parameters.AddWithValue("@TranPayMethod", Convert.ToInt32(csp.TranPayMethod));

            if (csp.ChequeNo == null)
            {
                cmd.Parameters.AddWithValue("@ChequeNo", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ChequeNo", csp.ChequeNo);
            }


            cmd.Parameters.AddWithValue("@TranNote", csp.TranNote);
            cmd.Parameters.AddWithValue("@TranDate", csp.TranDate);
            cmd.Parameters.AddWithValue("@TranBillNo", csp.TranBillNo);


            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }
        public void DeleteTransaction(int id)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("Delete CustSupTransactions where TranId = @TranId", Mycon);

            cmd.Parameters.AddWithValue("@TranId", id);


            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }

        // End


        public object SumOfQuntPurchaseDtl(string BillNo)
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT SUM(PurQuantity) FROM PurchaseDtls where PurBillNo = @PurBillNo", Mycon);
            cmd.Parameters.AddWithValue("@PurBillNo", BillNo);
            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }
        public object SumOfProductRatePurchaseDtl(string BillNo)
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT SUM(ProductDetails.ProductPurchaseRate) FROM PurchaseDtls inner join ProductDetails on PurchaseDtls.PurProductID = ProductDetails.PDID where PurchaseDtls.PurBillNo = @PurBillNo", Mycon);

            cmd.Parameters.AddWithValue("@PurBillNo", BillNo);

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();


            return rslt;
        }
        public object SumOfProductGSTPurchaseDtl(string BillNo)
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT SUM(PurGstRs) FROM PurchaseDtls where PurBillNo = @PurBillNo", Mycon);
            cmd.Parameters.AddWithValue("@PurBillNo", BillNo);

            try
            {
                Mycon.Open();
                rslt = cmd.ExecuteScalar();
                Mycon.Close();
            }
            catch (Exception ex)
            {
                string exstr = ex.Message;
            }


            return rslt;
        }
        public object TotalDiscountPurchaseDtl(string BillNo)
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT SUM(PurDiscount) FROM PurchaseDtls where PurBillNo = @PurBillNo", Mycon);
            cmd.Parameters.AddWithValue("@PurBillNo", BillNo);

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }
        public object SumOfPurTotalDtl(string BillNo)
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT SUM(PurTotal) FROM PurchaseDtls where PurBillNo = @PurBillNo", Mycon);
            cmd.Parameters.AddWithValue("@PurBillNo", BillNo);

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }
        public object RowCountPurchaseDtl(string BillNo)
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM PurchaseDtls where PurBillNo = @PurBillNo", Mycon);

            cmd.Parameters.AddWithValue("@PurBillNo", BillNo);
            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }

        //<------------- End Payment form Supplier ------------>

        // @@@@@@@@@@@@@@  Old Purchase Rate @@@@@@@@@@

        public void AddOldPurchaseRate(PurchaseOldRate por)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("insert into PurchaseOldRates values(@PName,@OldPRate,@NewPRate,@BillNo,@SupplierName,@PDate)", Mycon);

            cmd.Parameters.AddWithValue("@PName", Convert.ToInt32(por.PName));
            cmd.Parameters.AddWithValue("@OldPRate", por.OldPRate);
            cmd.Parameters.AddWithValue("@NewPRate", Convert.ToInt32(por.NewPRate));
            cmd.Parameters.AddWithValue("@BillNo", por.BillNo);
            cmd.Parameters.AddWithValue("@SupplierName", por.SupplierName);
            cmd.Parameters.AddWithValue("@PDate", Convert.ToDateTime(por.PDate).ToString("MM-dd-yyyy"));



            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

            SqlCommand cmd1 = new SqlCommand("update ProductDetails set ProductPurchaseRate = @ProductPurchaseRate where PDID = @PDID", Mycon);
            cmd1.Parameters.AddWithValue("@PDID", por.PName);
            cmd1.Parameters.AddWithValue("@ProductPurchaseRate", por.NewPRate);
            Mycon.Open();
            cmd1.ExecuteNonQuery();
            Mycon.Close();

        }
        public void EditOldPurchaseRate(PurchaseOldRate por)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("Update PurchaseOldRates set PName = @PName, OldPRate = @OldPRate, NewPRate = @NewPRate,BillNo = @BillNo,SupplierName = @SupplierName, PDate = @PDate where PORID = @PORID", Mycon);

            cmd.Parameters.AddWithValue("@PORID", Convert.ToInt32(por.PORID));
            cmd.Parameters.AddWithValue("@PName", Convert.ToInt32(por.PName));
            cmd.Parameters.AddWithValue("@OldPRate", por.OldPRate);
            cmd.Parameters.AddWithValue("@NewPRate", Convert.ToInt32(por.NewPRate));
            cmd.Parameters.AddWithValue("@BillNo", por.BillNo);
            cmd.Parameters.AddWithValue("@SupplierName", por.SupplierName);
            cmd.Parameters.AddWithValue("@PDate", Convert.ToDateTime(por.PDate).ToString("MM-dd-yyyy"));


            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
            SqlCommand cmd1 = new SqlCommand("update ProductDetails set ProductPurchaseRate = @ProductPurchaseRate where PDID = @PDID", Mycon);
            cmd1.Parameters.AddWithValue("@PDID", por.PName);
            cmd1.Parameters.AddWithValue("@ProductPurchaseRate", por.NewPRate);
            cmd1.ExecuteNonQuery();
        }
        public void DeleteOldPurchaseRate(int id)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("Delete PurchaseOldRates where PORID = @PORID", Mycon);

            cmd.Parameters.AddWithValue("@PORID", Convert.ToInt32(id));


            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }

        //<-------------- End Old Purchase Rate ------------->


        // @@@@@@@@@@@@@  Terms and Conditons @@@@@@@@
        public void AddEditTermsnConditions(TermsCondition TnC)
        {
            string SqlQuery;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            if (TnC.TCID == 0)
            {
                SqlQuery = "insert into TermsConditions values(@TurCon,@BTID)";
            }
            else
            {
                SqlQuery = "update TermsConditions set TurCon = @TurCon, BTID = @BTID where TCID = @TCID ";
            }

            SqlCommand cmd = new SqlCommand(SqlQuery, Mycon);

            cmd.Parameters.AddWithValue("@TCID", TnC.TCID);
            cmd.Parameters.AddWithValue("@TurCon", TnC.TurCon);
            cmd.Parameters.AddWithValue("@BTID", TnC.BTID);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }
        public void DeleteTnC(int id)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("Delete TermsConditions where TCID = @TCID", Mycon);

            cmd.Parameters.AddWithValue("@TCID", Convert.ToInt32(id));


            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }

        // <------------  End Terms and Conditons --------->


        // @@@_________________  Sales Bill Without GST ___________________@@@

        // DropdownList T&C
        public List<TermsCondition> ListTnC()
        {
            List<TermsCondition> lst = new List<TermsCondition>();
            string SqlQuery;
            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlQuery = "select TCID,TurCon from TermsConditions where BTID = 2";
            SqlCommand cmd = new SqlCommand(SqlQuery, Mycon);

            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                TermsCondition TC = new TermsCondition();
                TC.TCID = Convert.ToInt32(dr["TCID"]);
                TC.TurCon = dr["TurCon"].ToString();

                lst.Add(TC);
            }
            Mycon.Close();
            return lst;
        }




        public string BarcodeGenrator()
        {
            string BarcodeNo;

            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 SalBilWiGSTBillNo FROM SalesBillWithoutGstDtls ORDER BY SalBilWiGSTBillNo_Int DESC", Mycon);
            Mycon.Open();
            try
            {
                rslt = cmd.ExecuteScalar();
                Mycon.Close();
            }
            catch (Exception)
            {

                throw;
            }


            BarcodeNo = Convert.ToString(rslt);
            return BarcodeNo;
        }
        public void AddEdit_SaleWiGstTnc(int id, string Bill_No)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);


            string query = "insert into SaleWiGstTnCs values(@SaleWiGstTnC_BillNo,@SaleWiGstTnC_TCID)";



            SqlCommand cmd = new SqlCommand(query, Mycon);


            cmd.Parameters.AddWithValue("@SaleWiGstTnC_BillNo", Bill_No);
            cmd.Parameters.AddWithValue("@SaleWiGstTnC_TCID", id);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }
        public void AddEditTempSalesBillWithoutGstDtls(TempSalesBillWithoutGstDtl TSal)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);

            string query;

            if (TSal.SalBilWiGSTID != 0)
            {
                query = "update TempSalesBillWithoutGstDtls set SalBilWiGSTSuppCustId = @SalBilWiGSTSuppCustId, SalBilWiGSTBillNo = @SalBilWiGSTBillNo, SalBilWiGSTProductRate = @SalBilWiGSTProductRate,SalBilWiGSTProductID = @SalBilWiGSTProductID, SalBilWiGSTQuantity = @SalBilWiGSTQuantity, SalBilWiGSTGstRs = @SalBilWiGSTGstRs,SalBilWiGSTTotal = @SalBilWiGSTTotal,SalBilWiGSTDate = @SalBilWiGSTDate, WearhouseRefId = @WearhouseRefId where SalBilWiGSTID = @SalBilWiGSTID";

            }
            else
            {
                query = "insert into TempSalesBillWithoutGstDtls values(@SalBilWiGSTSuppCustId,@SalBilWiGSTBillNo,@SalBilWiGSTProductRate,@SalBilWiGSTProductID,@SalBilWiGSTQuantity,@SalBilWiGSTGstRs,@SalBilWiGSTTotal,@SalBilWiGSTDate,@WearhouseRefId)";
            }



            SqlCommand cmd = new SqlCommand(query, Mycon);


            cmd.Parameters.AddWithValue("@SalBilWiGSTID", Convert.ToInt32(TSal.SalBilWiGSTID));
            cmd.Parameters.AddWithValue("@SalBilWiGSTSuppCustId", Convert.ToInt32(TSal.SalBilWiGSTSuppCustId));
            cmd.Parameters.AddWithValue("@SalBilWiGSTBillNo", TSal.SalBilWiGSTBillNo);
            cmd.Parameters.AddWithValue("@SalBilWiGSTProductRate", Convert.ToInt32(TSal.SalBilWiGSTProductRate));
            cmd.Parameters.AddWithValue("@SalBilWiGSTProductID", Convert.ToDecimal(TSal.SalBilWiGSTProductID));
            cmd.Parameters.AddWithValue("@SalBilWiGSTQuantity", TSal.SalBilWiGSTQuantity);

            decimal Prorate, ProQunt;
            Prorate = Convert.ToDecimal(TSal.SalBilWiGSTProductRate);
            ProQunt = TSal.SalBilWiGSTQuantity;

            decimal GrandTotal = Prorate * ProQunt;
            decimal gst = TSal.SalBilWiGSTProductGst;
            decimal GstRs = GrandTotal * gst / 100;


            cmd.Parameters.AddWithValue("@SalBilWiGSTGstRs", GstRs);
            cmd.Parameters.AddWithValue("@SalBilWiGSTTotal", GrandTotal);
            cmd.Parameters.AddWithValue("@SalBilWiGSTDate", TSal.SalBilWiGSTDate);
            cmd.Parameters.AddWithValue("@WearhouseRefId", TSal.WearhouseRefId);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }
        public void DeleteTempSalesBillWithoutGstDtls(int SalID)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("delete  TempSalesBillWithoutGstDtls where SalBilWiGSTID = @SalBilWiGSTID", Mycon);
            cmd.Parameters.AddWithValue("@SalBilWiGSTID", SalID);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }
        public void AddSaleReports(TempSalesBillWithoutGstDtl tsb)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);



            string AddPurForRepo = "insert into SalesBillWithoutGstDtl_Report values(@SalBiWiGst_Rpt_BillNo,@SalBiWiGst_Rpt_date,@SalBiWiGst_Rpt_GrandTotal,@SalBiWiGst_Rpt_FinalTotal)";
            SqlCommand cmd = new SqlCommand(AddPurForRepo, Mycon);

            cmd.Parameters.AddWithValue("@SalBiWiGst_Rpt_BillNo", tsb.SalBilWiGSTBillNo);
            cmd.Parameters.AddWithValue("@SalBiWiGst_Rpt_date", tsb.SalBilWiGSTDate);
            cmd.Parameters.AddWithValue("@SalBiWiGst_Rpt_GrandTotal", tsb.SalBilWiGSTGrandTot);
            cmd.Parameters.AddWithValue("@SalBiWiGst_Rpt_FinalTotal", tsb.SalBilWiGSTTotalAmt);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }
        public void AddSaleWiGstReportBill(TempSalesBillWithoutGstDtl Tsb)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            string checkbillno = "select * from SalesBillWithoutGstDtl_ChargesDisc where SalBiWiGst_BillNo = @SalBiWiGst_BillNo";
            SqlCommand cmd1 = new SqlCommand(checkbillno, Mycon);
            cmd1.Parameters.AddWithValue("@SalBiWiGst_BillNo", Tsb.SalBilWiGSTBillNo);
            Mycon.Open();
            object counts = cmd1.ExecuteScalar();
            Mycon.Close();


            SqlCommand cmd;

            if (counts != null)
            {
                cmd = new SqlCommand("update SalesBillWithoutGstDtl_ChargesDisc set SalBiWiGst_DiscountRs = @SalBiWiGst_DiscountRs, SalBiWiGst_DiscountPer = @SalBiWiGst_DiscountPer,SalBiWiGst_ChargesName = @SalBiWiGst_ChargesName, SalBiWiGst_ChargesAmt = @SalBiWiGst_ChargesAmt,SalBiWiGst_Note = @SalBiWiGst_Note, SalBiWiGst_Status = @SalBiWiGst_Status  where SalBiWiGst_BillNo = @SalBiWiGst_BillNo", Mycon);
            }
            else
            {
                cmd = new SqlCommand("insert into SalesBillWithoutGstDtl_ChargesDisc values(@SalBiWiGst_DiscountRs,@SalBiWiGst_DiscountPer,@SalBiWiGst_ChargesName,@SalBiWiGst_ChargesAmt,@SalBiWiGst_BillNo,@SalBiWiGst_Note,@SalBiWiGst_Status)", Mycon);
            }


            cmd.Parameters.AddWithValue("@SalBiWiGst_BillNo", Tsb.SalBilWiGSTBillNo);
            cmd.Parameters.AddWithValue("@SalBiWiGst_DiscountRs", Convert.ToDecimal(Tsb.SalBilWiGSTDiscRs));
            cmd.Parameters.AddWithValue("@SalBiWiGst_DiscountPer", Convert.ToDecimal(Tsb.SalBilWiGSTDiscPer));

            if (Tsb.SalBilWiGSTChargesName != null)
            {
                cmd.Parameters.AddWithValue("@SalBiWiGst_ChargesName", Tsb.SalBilWiGSTChargesName);
            }
            else
            {
                cmd.Parameters.AddWithValue("@SalBiWiGst_ChargesName", " ");

            }

            cmd.Parameters.AddWithValue("@SalBiWiGst_ChargesAmt", Convert.ToDecimal(Tsb.SalBilWiGSTChargesAmt));

            if (Tsb.SalBiWiGst_Note != null)
            {
                cmd.Parameters.AddWithValue("@SalBiWiGst_Note", Tsb.SalBiWiGst_Note);
            }
            else
            {
                cmd.Parameters.AddWithValue("@SalBiWiGst_Note", " ");

            }
            cmd.Parameters.AddWithValue("@SalBiWiGst_Status", Convert.ToDecimal(Tsb.SalBiWiGst_Status));

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }
        public void DeleteTempSaleDeatils() // this is temp data delete function
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("Truncate table TempSalesBillWithoutGstDtls", Mycon);
            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }
        public void AddSaleWiGstDeatils(SalesBillWithoutGstDtl TSal)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("insert into SalesBillWithoutGstDtls values(@SalBilWiGSTSuppCustId,@SalBilWiGSTBillNo,@SalBilWiGSTProductRate,@SalBilWiGSTProductID,@SalBilWiGSTQuantity,@SalBilWiGSTGstRs,@SalBilWiGSTTotal,@SalBilWiGSTDate,@SalBilWiGSTBillNo_Int,@WearhouseRefId)", Mycon);

            cmd.Parameters.AddWithValue("@SalBilWiGSTID", Convert.ToInt32(TSal.SalBilWiGSTID));
            cmd.Parameters.AddWithValue("@SalBilWiGSTSuppCustId", Convert.ToInt32(TSal.SalBilWiGSTSuppCustId));
            cmd.Parameters.AddWithValue("@SalBilWiGSTBillNo", TSal.SalBilWiGSTBillNo);
            cmd.Parameters.AddWithValue("@SalBilWiGSTProductRate", Convert.ToInt32(TSal.SalBilWiGSTProductRate));
            cmd.Parameters.AddWithValue("@SalBilWiGSTProductID", Convert.ToDecimal(TSal.SalBilWiGSTProductID));
            cmd.Parameters.AddWithValue("@SalBilWiGSTQuantity", TSal.SalBilWiGSTQuantity);
            cmd.Parameters.AddWithValue("@SalBilWiGSTGstRs", TSal.SalBilWiGSTGstRs);
            cmd.Parameters.AddWithValue("@SalBilWiGSTTotal", TSal.SalBilWiGSTTotal);
            cmd.Parameters.AddWithValue("@SalBilWiGSTDate", TSal.SalBilWiGSTDate);
            cmd.Parameters.AddWithValue("@SalBilWiGSTBillNo_Int", TSal.SalBilWiGSTBillNo_Int);
        
            cmd.Parameters.AddWithValue("@WearhouseRefId", TSal.WearhouseRefId);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }









        public List<SalesBillWithoutGstDtl> ListSaleWiGstDtl()
        {
            List<SalesBillWithoutGstDtl> lst = new List<SalesBillWithoutGstDtl>();


            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("SELECT SalesBillWithoutGstDtls.SalBilWiGSTBillNo, CustomerDetails.CustName,SalesBillWithoutGstDtls.SalBilWiGSTDate   FROM SalesBillWithoutGstDtls LEFT JOIN CustomerDetails ON SalesBillWithoutGstDtls.SalBilWiGSTSuppCustId = CustomerDetails.CustID GROUP BY SalesBillWithoutGstDtls.SalBilWiGSTBillNo, CustomerDetails.CustName,SalesBillWithoutGstDtls.SalBilWiGSTDate", Mycon);

            Mycon.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SalesBillWithoutGstDtl SWiGst = new SalesBillWithoutGstDtl();

                SWiGst.SalBilWiGSTBillNo = Convert.ToString(dr["SalBilWiGSTBillNo"]);
                SWiGst.SaleBiWiGstSuppCustName = Convert.ToString(dr["CustName"]);
                SWiGst.SalBilWiGSTDate = Convert.ToDateTime(dr["SalBilWiGSTDate"]);

                //    string vals = dr["PurchaseDtls.PurBillNo"].ToString();


                lst.Add(SWiGst);
            }


            Mycon.Close();

            return lst;

        }




        public int Count_SaleWithoutGST(string BillNo)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("select count(*) from SalesBillWithoutGstDtls where SalBilWiGSTBillNo = @SalBilWiGSTBillNo", Mycon);
            cmd.Parameters.AddWithValue("@SalBilWiGSTBillNo", BillNo);
            Mycon.Open();
            int Rslt = Convert.ToInt32(cmd.ExecuteScalar());
            Mycon.Close();

            return Rslt;
        }

        public List<TempSalesBillWithoutGstDtl> QuantitySum_Temp_SaleWithoutGST()
        {

            List<TempSalesBillWithoutGstDtl> lstQty = new List<TempSalesBillWithoutGstDtl>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            string sqlSelect = "select tdp.SalBilWiGSTProductID, pd.ProductName, sum(tdp.SalBilWiGSTQuantity) as QtySum from TempSalesBillWithoutGstDtls as tdp join ProductDetails as pd on pd.PDID = tdp.SalBilWiGSTProductID group by tdp.SalBilWiGSTProductID, pd.ProductName";

            SqlCommand cmd = new SqlCommand(sqlSelect, Mycon);
            try
            {
                Mycon.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TempSalesBillWithoutGstDtl tsbwgst = new TempSalesBillWithoutGstDtl();

                    tsbwgst.SalBilWiGSTProductID = Convert.ToInt32(reader["SalBilWiGSTProductID"]);
                    tsbwgst.SalBilWiGSTSplrCustName = reader["ProductName"].ToString();
                    tsbwgst.QtySum = Convert.ToDecimal(reader["QtySum"]);

                    lstQty.Add(tsbwgst);
                }
                Mycon.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return lstQty;
        }

        public List<TempSalesBillWithoutGstDtl> QuantitySum_Temp_SaleWithoutGST(string BillNo)
        {

            List<TempSalesBillWithoutGstDtl> lstQty = new List<TempSalesBillWithoutGstDtl>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            string sqlSelect = "select tdp.SalBilWiGSTProductID, pd.ProductName, sum(tdp.SalBilWiGSTQuantity) as QtySum from SalesBillWithoutGstDtls as tdp join ProductDetails as pd on pd.PDID = tdp.SalBilWiGSTProductID where tdp.SalBilWiGSTBillNo = @SalBilWiGSTBillNo group by tdp.SalBilWiGSTProductID, pd.ProductName";

            SqlCommand cmd = new SqlCommand(sqlSelect, Mycon);
            cmd.Parameters.AddWithValue("@SalBilWiGSTBillNo", BillNo);

            try
            {
                Mycon.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TempSalesBillWithoutGstDtl tsbwgst = new TempSalesBillWithoutGstDtl();

                    tsbwgst.SalBilWiGSTProductID = Convert.ToInt32(reader["SalBilWiGSTProductID"]);
                    tsbwgst.SalBilWiGSTSplrCustName = reader["ProductName"].ToString();
                    tsbwgst.QtySum = Convert.ToDecimal(reader["QtySum"]);

                    lstQty.Add(tsbwgst);
                }
                Mycon.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return lstQty;
        }


        public void DeleteSaleWiGstDetails(string BillNo)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("delete SalesBillWithoutGstDtls where SalBilWiGSTBillNo = @SalBilWiGSTBillNo", Mycon);
            cmd.Parameters.AddWithValue("@SalBilWiGSTBillNo", BillNo);
            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }

        public void DeleteSalesBillWithoutGstDtl_Report(string BillNo) // this is temp data delete function
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("delete  SalesBillWithoutGstDtl_Report where SalBiWiGst_Rpt_BillNo = @SalBiWiGst_Rpt_BillNo", Mycon);
            cmd.Parameters.AddWithValue("@SalBiWiGst_Rpt_BillNo", BillNo);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }

        public void Delete_SaleWiGst(string BillNo) // this is temp data delete function
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("delete  SalesBillWithoutGstDtl_ChargesDisc where SalBiWiGst_BillNo = @SalBiWiGst_BillNo", Mycon);
            cmd.Parameters.AddWithValue("@SalBiWiGst_BillNo", BillNo);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }

        // if we click on update Button in purchaseList Form then automatically function call and insert the data
        public void AddTempSaleWiGst(TempSalesBillWithoutGstDtl TSal)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            string query = "insert into TempSalesBillWithoutGstDtls values(@SalBilWiGSTSuppCustId,@SalBilWiGSTBillNo,@SalBilWiGSTProductRate,@SalBilWiGSTProductID,@SalBilWiGSTQuantity,@SalBilWiGSTGstRs,@SalBilWiGSTTotal,@SalBilWiGSTDate,@WearhouseRefId)";

            SqlCommand cmd = new SqlCommand(query, Mycon);


            cmd.Parameters.AddWithValue("@SalBilWiGSTID", Convert.ToInt32(TSal.SalBilWiGSTID));
            cmd.Parameters.AddWithValue("@SalBilWiGSTSuppCustId", Convert.ToInt32(TSal.SalBilWiGSTSuppCustId));
            cmd.Parameters.AddWithValue("@SalBilWiGSTBillNo", TSal.SalBilWiGSTBillNo);
            cmd.Parameters.AddWithValue("@SalBilWiGSTProductRate", Convert.ToInt32(TSal.SalBilWiGSTProductRate));
            cmd.Parameters.AddWithValue("@SalBilWiGSTProductID", Convert.ToDecimal(TSal.SalBilWiGSTProductID));
            cmd.Parameters.AddWithValue("@SalBilWiGSTQuantity", TSal.SalBilWiGSTQuantity);

            decimal Prorate, ProQunt;
            Prorate = Convert.ToDecimal(TSal.SalBilWiGSTProductRate);
            ProQunt = TSal.SalBilWiGSTQuantity;

            decimal GrandTotal = Prorate * ProQunt;
            decimal gst = TSal.SalBilWiGSTProductGst;
            decimal GstRs = GrandTotal * gst / 100;


            cmd.Parameters.AddWithValue("@SalBilWiGSTGstRs", GstRs);
            cmd.Parameters.AddWithValue("@SalBilWiGSTTotal", GrandTotal);


            cmd.Parameters.AddWithValue("@SalBilWiGSTDate", TSal.SalBilWiGSTDate);
            cmd.Parameters.AddWithValue("@WearhouseRefId", TSal.WearhouseRefId);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }
        // End of 






        // Gst Cal 

        public object CountProduct_SaleWiGST(string BillNo)
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select count(*) from SalesBillWithoutGstDtls as swgst join ProductDetails as pd on pd.PDID = swgst.SalBilWiGSTProductID where NOT  HSM_Code = '' and SalBilWiGSTBillNo = @SalBilWiGSTBillNo", Mycon);
            cmd.Parameters.AddWithValue("@SalBilWiGSTBillNo", BillNo);

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }

        public object CountProduct_SaleGST(string BillNo)
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select count(*) from SalesGSTs as swgst join ProductDetails as pd on pd.PDID = swgst.SaleGST_ProductID where NOT HSM_Code = '' and SaleGST_BillNo = @SaleGST_BillNo", Mycon);
            cmd.Parameters.AddWithValue("@SaleGST_BillNo", BillNo);
            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }






        public object SumOfQuntSaleWiGST()
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT SUM(SalBilWiGSTQuantity) FROM TempSalesBillWithoutGstDtls", Mycon);
            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }
        public object SumOfProductRateSaleWiGST()
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            //   SqlCommand cmd = new SqlCommand("SELECT SUM(ProductDetails.ProductPurchaseRate) FROM TempSalesBillWithoutGstDtls inner join ProductDetails on TempSalesBillWithoutGstDtls.SalBilWiGSTProductID = ProductDetails.PDID", Mycon);

            SqlCommand cmd = new SqlCommand("SELECT SUM(SalBilWiGSTProductRate) FROM TempSalesBillWithoutGstDtls", Mycon);


            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }
        public object SumOfProductGSTSaleWiGST()
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            // SqlCommand cmd = new SqlCommand("SELECT SUM(ProductGSTs.ProdGst) FROM TempDataPurchases inner join ProductDetails on TempDataPurchases.TempPurProductID = ProductDetails.PDID inner join ProductGSTs on ProductDetails.GstPercent = ProductGSTs.ProdGstID", Mycon);
            SqlCommand cmd = new SqlCommand("SELECT SUM(SalBilWiGSTGstRs) FROM TempSalesBillWithoutGstDtls", Mycon);



            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }
        public object SumOfPSaleWiGSTTotalDtl()
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT SUM(SalBilWiGSTTotal) FROM TempSalesBillWithoutGstDtls", Mycon);

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }
        public object RowCountSaleWiGst()
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM TempSalesBillWithoutGstDtls", Mycon);
            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }
        //End Gst cal



        // sale Payment
        public object SumOfReciAmt_Sale(string BillNo)
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT SUM(SGstTran_TranReciAmt) FROM SalesGST_Transactions where SGstTran_BillNo = @SGstTran_BillNo", Mycon);
            cmd.Parameters.AddWithValue("@SGstTran_BillNo", BillNo);
            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }

        public void AddEditSalesGst_Payment(SalesGST_Payment SGstP)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("insert into SalesGST_Payment values(@SaleGstPay_SupCustID,@SaleGstPay_CustSuppBillNo,@SaleGstPay_SuppCustPaidAmt)", Mycon);
            cmd.Parameters.AddWithValue("@SaleGstPay_SupCustID", Convert.ToInt32(SGstP.SaleGstPay_SupCustID));
            cmd.Parameters.AddWithValue("@SaleGstPay_CustSuppBillNo", SGstP.SaleGstPay_CustSuppBillNo);
            cmd.Parameters.AddWithValue("@SaleGstPay_SuppCustPaidAmt", 0 /*SGstP.PaySalWiGst_SuppCustPaidAmt*/);
            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }


        public List<SalesGST_Payment> ListSalesGst_Payment()
        {
            List<SalesGST_Payment> lst = new List<SalesGST_Payment>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("select * from SalesGST_Payment as sp join CustomerDetails as cd on sp.SaleGstPay_SupCustID = cd.CustID left join SalesGST_Report as sr on sr.SalesGST_Rpt_BillNo = sp.SaleGstPay_CustSuppBillNo", Mycon);

            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                SalesGST_Payment sp = new SalesGST_Payment();


                sp.SaleGstPay_ID = Convert.ToInt32(dr["SaleGstPay_ID"]);
                sp.CustName = dr["CustName"].ToString();
                sp.SaleGstPay_CustSuppBillNo = dr["SaleGstPay_CustSuppBillNo"].ToString();

                if (!(dr["SalesGST_Rpt_FinalTotal"] is DBNull))
                {
                    sp.FinalTotal = Convert.ToDecimal(dr["SalesGST_Rpt_FinalTotal"]);
                }

                lst.Add(sp);
            }
            Mycon.Close();
            return lst;
        }



        public void DeleteSaleGst_Payment(int id)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("Delete SalesGST_Payment where SaleGstPay_ID = @SaleGstPay_ID", Mycon);

            cmd.Parameters.AddWithValue("@SaleGstPay_ID", id);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }

        public void DeleteSaleGst_Transactions(string BillNo)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("Delete SalesGST_Transactions where SGstTran_BillNo = @SGstTran_BillNo", Mycon);

            cmd.Parameters.AddWithValue("@SGstTran_BillNo", BillNo);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }


        // End sale Payment





        // Terms and Conditions without Gst
        public void DeleteTermsNconditonsWiGst(string BillNo)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("delete SaleWiGstTnCs where SaleWiGstTnC_BillNo = @SaleWiGstTnC_BillNo", Mycon);
            cmd.Parameters.AddWithValue("@SaleWiGstTnC_BillNo", BillNo);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }

        public void AddSaleGst_Transaction(SalesGST_Transactions St)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd;
            if (St.SGstTran_TranID == 0)
            {
                cmd = new SqlCommand("insert into SalesGST_Transactions values(@SGstTran_CustSupID,@SGstTran_TranReciAmt,@SGstTran_TranPayMethod,@SGstTran_Cheque,@SGstTran_TransactionNote,@SGstTran_Date,@SGstTran_BillNo)", Mycon);
            }
            else
            {
                cmd = new SqlCommand("Update SalesGST_Transactions set SGstTran_CustSupID = @SGstTran_CustSupID,SGstTran_TranReciAmt = @SGstTran_TranReciAmt, SGstTran_TranPayMethod = @SGstTran_TranPayMethod, SGstTran_Cheque = @SGstTran_Cheque, SGstTran_TransactionNote = @SGstTran_TransactionNote, SGstTran_Date = @SGstTran_Date,SGstTran_BillNo = @SGstTran_BillNo where SGstTran_TranID = @SGstTran_TranID", Mycon);
            }

            cmd.Parameters.AddWithValue("@SGstTran_TranID", Convert.ToInt32(St.SGstTran_TranID));
            cmd.Parameters.AddWithValue("@SGstTran_CustSupID", Convert.ToInt32(St.SGstTran_CustSupID));
            cmd.Parameters.AddWithValue("@SGstTran_TranReciAmt", St.SGstTran_TranReciAmt);
            cmd.Parameters.AddWithValue("@SGstTran_TranPayMethod", Convert.ToInt32(St.SGstTran_TranPayMethod));

            if (St.SGstTran_TranPayMethod != 2)
            {
                cmd.Parameters.AddWithValue("@SGstTran_Cheque", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("@SGstTran_Cheque", St.SGstTran_Cheque);
            }

            cmd.Parameters.AddWithValue("@SGstTran_TransactionNote", St.SGstTran_TransactionNote);
            cmd.Parameters.AddWithValue("@SGstTran_Date", St.SGstTran_Date);
            cmd.Parameters.AddWithValue("@SGstTran_BillNo", St.SGstTran_BillNo);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }

        // End
        // <-------------  End Sales Bill Without GST ------------->



        // @@@____________ Sale With Gst _____________@@@

        // List of Terms and conditions
        public List<TermsCondition> ListTnC_Gst()
        {
            List<TermsCondition> lst = new List<TermsCondition>();
            string SqlQuery;
            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlQuery = "select TCID,TurCon from TermsConditions where BTID = 1";
            SqlCommand cmd = new SqlCommand(SqlQuery, Mycon);
            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                TermsCondition TC = new TermsCondition();
                TC.TCID = Convert.ToInt32(dr["TCID"]);
                TC.TurCon = dr["TurCon"].ToString();

                lst.Add(TC);
            }
            Mycon.Close();
            return lst;
        }

        // End Terms and Conditonns

        // if we click on update Button in purchaseList Form then automatically function call and insert the data
        public void AddTempSaleGst(TempSalesBillWithoutGstDtl TSal)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            string query = "insert into TempSaleGSTs values(@TempSaleGST_SuppCustId,@TempSaleGST_BillNo,@TempSaleGST_ProductRate,@TempSaleGST_ProductID,@TempSaleGST_Quantity,@TempSaleGST_GstRs,@TempSaleGST_Total,@TempSaleGST_Date,@TempSaleGST_PDiscount)";

            SqlCommand cmd = new SqlCommand(query, Mycon);


            //cmd.Parameters.AddWithValue("@SalBilWiGSTID", Convert.ToInt32(TSal.SalBilWiGSTID));
            cmd.Parameters.AddWithValue("@TempSaleGST_SuppCustId", Convert.ToInt32(TSal.SalBilWiGSTSuppCustId));
            cmd.Parameters.AddWithValue("@TempSaleGST_BillNo", TSal.SalBilWiGSTBillNo);
            cmd.Parameters.AddWithValue("@TempSaleGST_ProductRate", Convert.ToInt32(TSal.SalBilWiGSTProductRate));
            cmd.Parameters.AddWithValue("@TempSaleGST_ProductID", Convert.ToDecimal(TSal.SalBilWiGSTProductID));
            cmd.Parameters.AddWithValue("@TempSaleGST_Quantity", TSal.SalBilWiGSTQuantity);

            decimal Prorate, ProQunt;
            Prorate = Convert.ToDecimal(TSal.SalBilWiGSTProductRate);
            ProQunt = TSal.SalBilWiGSTQuantity;

            decimal GrandTotal = Prorate * ProQunt;
            decimal gst = TSal.SalBilWiGSTGstRs;
            decimal GstRs = GrandTotal * gst / 100;



            cmd.Parameters.AddWithValue("@TempSaleGST_GstRs", GstRs);
            cmd.Parameters.AddWithValue("@TempSaleGST_Total", GrandTotal);
            cmd.Parameters.AddWithValue("@TempSaleGST_Date", TSal.SalBilWiGSTDate);

            cmd.Parameters.AddWithValue("@TempSaleGST_PDiscount", 0);


            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }
        // End of 



        public int Count_SaleWithGST(string BillNo)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("select count(*) from SalesGSTs where SaleGST_BillNo = @SaleGST_BillNo", Mycon);
            cmd.Parameters.AddWithValue("@SaleGST_BillNo", BillNo);
            Mycon.Open();
            int Rslt = Convert.ToInt32(cmd.ExecuteScalar());
            Mycon.Close();

            return Rslt;
        }
        public List<TempSaleGST> QuantitySum_Temp_SaleWithGST()
        {

            List<TempSaleGST> lstQty = new List<TempSaleGST>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            string sqlSelect = "select tdp.TempSaleGST_ProductID, pd.ProductName, sum(tdp.TempSaleGST_Quantity) as QtySum from TempSaleGSTs as tdp join ProductDetails as pd on pd.PDID = tdp.TempSaleGST_ProductID group by tdp.TempSaleGST_ProductID, pd.ProductName";

            SqlCommand cmd = new SqlCommand(sqlSelect, Mycon);
            try
            {
                Mycon.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TempSaleGST TSG = new TempSaleGST();

                    TSG.TempSaleGST_ProductID = Convert.ToInt32(reader["TempSaleGST_ProductID"]);
                    TSG.TempSaleGST_SplrCustName = reader["ProductName"].ToString();
                    TSG.QtySum = Convert.ToDecimal(reader["QtySum"]);

                    lstQty.Add(TSG);
                }
                Mycon.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return lstQty;
        }

        public List<TempSaleGST> QuantitySum_Temp_SaleWithGST(string BillNo)
        {

            List<TempSaleGST> lstQty = new List<TempSaleGST>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            string sqlSelect = "select tdp.SaleGST_ProductID, pd.ProductName, sum(tdp.SaleGST_Quantity) as QtySum from SalesGSTs as tdp join ProductDetails as pd on pd.PDID = tdp.SaleGST_ProductID where tdp.SaleGST_BillNo = @SaleGST_BillNo group by tdp.SaleGST_ProductID, pd.ProductName";

            SqlCommand cmd = new SqlCommand(sqlSelect, Mycon);
            cmd.Parameters.AddWithValue("@SaleGST_BillNo", BillNo);
            try
            {
                Mycon.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TempSaleGST TSG = new TempSaleGST();

                    TSG.TempSaleGST_ProductID = Convert.ToInt32(reader["SaleGST_ProductID"]);
                    TSG.TempSaleGST_SplrCustName = reader["ProductName"].ToString();
                    TSG.QtySum = Convert.ToDecimal(reader["QtySum"]);

                    lstQty.Add(TSG);
                }
                Mycon.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return lstQty;
        }




        public void Delete_SaleGstList(string BillNo)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("delete SalesGSTs where SaleGST_BillNo = @SaleGST_BillNo", Mycon);
            cmd.Parameters.AddWithValue("@SaleGST_BillNo", BillNo);
            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }

        public void Delete_SaleGst_Report(string BillNo)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("delete  SalesGST_Report where SalesGST_Rpt_BillNo = @SalesGST_Rpt_BillNo", Mycon);
            cmd.Parameters.AddWithValue("@SalesGST_Rpt_BillNo", BillNo);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }

        public void Delete_SaleGst_ChargeDisc(string BillNo)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("delete  SalesGST_ChargeDisc where SalesGST_BillNo = @SalesGST_BillNo", Mycon);
            cmd.Parameters.AddWithValue("@SalesGST_BillNo", BillNo);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }



        public void DeleteTermsNconditons_SalesGst(string BillNo)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("delete SalesGst_Tnc where SalesGst_BillNo = @SalesGst_BillNo", Mycon);
            cmd.Parameters.AddWithValue("@SalesGst_BillNo", BillNo);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }


        // Transaction Details
        public void DeleteSaleGst_Transaction(int id)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("Delete SalesGST_Transactions where SGstTran_TranID = @SGstTran_TranID", Mycon);

            cmd.Parameters.AddWithValue("@SGstTran_TranID", id);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }

        // End Transaction dtl

        public object RowCount_SaleGst_Report(string BillNo)
        {

            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM SalesGST_Report where SalesGST_Rpt_BillNo = @SalesGST_Rpt_BillNo", Mycon);

            cmd.Parameters.AddWithValue("@SalesGST_Rpt_BillNo", BillNo);
            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }







        public List<SalesGST> ListSaleGst()
        {
            List<SalesGST> lst = new List<SalesGST>();

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT SalesGSTs.SaleGST_BillNo, CustomerDetails.CustName, SalesGSTs.SaleGST_Date   FROM SalesGSTs LEFT JOIN CustomerDetails ON SalesGSTs.SaleGST_SuppCustId = CustomerDetails.CustID GROUP BY SalesGSTs.SaleGST_BillNo, CustomerDetails.CustName, SalesGSTs.SaleGST_Date", Mycon);

            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SalesGST SalGst = new SalesGST();

                SalGst.SaleGST_BillNo = Convert.ToString(dr["SaleGST_BillNo"]);
                SalGst.SaleGST_SuppCustName = Convert.ToString(dr["CustName"]);
                SalGst.SaleGST_Date = Convert.ToDateTime(dr["SaleGST_Date"]);
                //    string vals = dr["PurchaseDtls.PurBillNo"].ToString();
                lst.Add(SalGst);
            }
            Mycon.Close();
            return lst;

        }

        // if we click on update Button in purchaseList Form then automatically function call and insert the data
        public void Add_TempSalesGst(TempSaleGST TSG)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            string query = "insert into TempSaleGSTs values(@TempSaleGST_SuppCustId,@TempSaleGST_BillNo,@TempSaleGST_ProductRate,@TempSaleGST_ProductID,@TempSaleGST_Quantity,@TempSaleGST_GstRs,@TempSaleGST_Total,@TempSaleGST_Date,@TempSaleGST_PDiscount)";

            SqlCommand cmd = new SqlCommand(query, Mycon);


            cmd.Parameters.AddWithValue("@TempSaleGST_SuppCustId", Convert.ToInt32(TSG.TempSaleGST_SuppCustId));
            cmd.Parameters.AddWithValue("@TempSaleGST_BillNo", TSG.TempSaleGST_BillNo);
            cmd.Parameters.AddWithValue("@TempSaleGST_ProductRate", Convert.ToInt32(TSG.TempSaleGST_ProductRate));
            cmd.Parameters.AddWithValue("@TempSaleGST_ProductID", Convert.ToDecimal(TSG.TempSaleGST_ProductID));
            cmd.Parameters.AddWithValue("@TempSaleGST_Quantity", TSG.TempSaleGST_Quantity);

            //decimal Prorate, ProQunt;
            //Prorate = Convert.ToDecimal(TSG.TempSaleGST_ProductRate);
            //ProQunt = TSG.TempSaleGST_Quantity;
            //decimal GrandTotal = Prorate * ProQunt;
            //decimal gst = TSG.TempSaleGST_ProductGst;
            //decimal GstRs = GrandTotal * gst / 100;


            cmd.Parameters.AddWithValue("@TempSaleGST_GstRs", TSG.TempSaleGST_GstRs);
            cmd.Parameters.AddWithValue("@TempSaleGST_Total", TSG.TempSaleGST_Total);

            cmd.Parameters.AddWithValue("@TempSaleGST_Date", TSG.TempSaleGST_Date);
            cmd.Parameters.AddWithValue("@TempSaleGST_PDiscount", TSG.TempSaleGST_PDiscount);



            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }
        // End of 




        public object CountProduct_CreditNotes(string BillNo)
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select count(*) from CreditNotes as CN join ProductDetails as pd on pd.PDID = CN.CreditNotes_ProductID where NOT HSM_Code = '' and CN.CreditNotes_SaleWithGSTBillNo = @CreditNotes_SaleWithGSTBillNo", Mycon);
            cmd.Parameters.AddWithValue("@CreditNotes_SaleWithGSTBillNo", BillNo);
            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }



        public string BarcodeGenrator_CreditNotes()
        {
            string BarcodeNo;

            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 CreditNotes_BillNo FROM CreditNotes ORDER BY CreditNotes_BillNo DESC", Mycon);
            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            BarcodeNo = Convert.ToString(rslt);
            return BarcodeNo;
        }





        // Add Sale Gst Form
        public string BarcodeGenrator_WithGst()
        {
            string BarcodeNo;

            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 SaleGST_BillNo FROM SalesGSTs ORDER BY SaleGST_BillNo_Int DESC", Mycon);
            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            BarcodeNo = Convert.ToString(rslt);
            return BarcodeNo;
        }

        public void AddEditTempSaleGst(TempSaleGST TSal)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);

            string query;


            if (TSal.TempSaleGST_ID != 0)
            {
                query = "update TempSaleGSTs set TempSaleGST_SuppCustId = @TempSaleGST_SuppCustId, TempSaleGST_BillNo = @TempSaleGST_BillNo, TempSaleGST_ProductRate = @TempSaleGST_ProductRate, TempSaleGST_ProductID = @TempSaleGST_ProductID, TempSaleGST_Quantity = @TempSaleGST_Quantity, TempSaleGST_GstRs = @TempSaleGST_GstRs, TempSaleGST_Total = @TempSaleGST_Total, TempSaleGST_Date = @TempSaleGST_Date, TempSaleGST_PDiscount = @TempSaleGST_PDiscount where TempSaleGST_ID = @TempSaleGST_ID";
            }
            else
            {
                query = "insert into TempSaleGSTs values(@TempSaleGST_SuppCustId,@TempSaleGST_BillNo,@TempSaleGST_ProductRate,@TempSaleGST_ProductID,@TempSaleGST_Quantity,@TempSaleGST_GstRs,@TempSaleGST_Total,@TempSaleGST_Date,@TempSaleGST_PDiscount)";
            }

            SqlCommand cmd = new SqlCommand(query, Mycon);

            cmd.Parameters.AddWithValue("@TempSaleGST_ID", Convert.ToInt32(TSal.TempSaleGST_ID));
            cmd.Parameters.AddWithValue("@TempSaleGST_SuppCustId", Convert.ToInt32(TSal.TempSaleGST_SuppCustId));
            cmd.Parameters.AddWithValue("@TempSaleGST_BillNo", TSal.TempSaleGST_BillNo);
            cmd.Parameters.AddWithValue("@TempSaleGST_ProductRate", Convert.ToInt32(TSal.TempSaleGST_ProductRate));
            cmd.Parameters.AddWithValue("@TempSaleGST_ProductID", Convert.ToDecimal(TSal.TempSaleGST_ProductID));
            cmd.Parameters.AddWithValue("@TempSaleGST_Quantity", TSal.TempSaleGST_Quantity);

            decimal Prorate, ProQunt;
            Prorate = Convert.ToDecimal(TSal.TempSaleGST_ProductRate);
            ProQunt = TSal.TempSaleGST_Quantity;

            decimal GrandTotal = Prorate * ProQunt;
            decimal gst = TSal.TempSaleGST_ProductGst;
            decimal GstRs = GrandTotal * gst / 100;

            cmd.Parameters.AddWithValue("@TempSaleGST_GstRs", GstRs);
            cmd.Parameters.AddWithValue("@TempSaleGST_Total", GrandTotal);
            cmd.Parameters.AddWithValue("@TempSaleGST_Date", TSal.TempSaleGST_Date);
            cmd.Parameters.AddWithValue("@TempSaleGST_PDiscount", TSal.TempSaleGST_PDiscount);


            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }

        public void ProductSlider_Update(CustomerSlider CS)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);

            string SqlQuery = "";

            if (CS.CS_ImgPath == null)
            {
                SqlQuery = "Update CustomerSliders set CS_ProductName = @CS_ProductName,CS_ProductDesc = @CS_ProductDesc where CS_ID = @CS_ID";
            }
            else
            {
                SqlQuery = "Update CustomerSliders set CS_ProductName = @CS_ProductName,CS_ProductDesc = @CS_ProductDesc,CS_ImgPath = @CS_ImgPath where CS_ID = @CS_ID";
            }

            SqlCommand cmd = new SqlCommand(SqlQuery, Mycon);

            cmd.Parameters.AddWithValue("@CS_ID", CS.CS_ID);
            cmd.Parameters.AddWithValue("@CS_ProductName", CS.CS_ProductName);
            cmd.Parameters.AddWithValue("@CS_ProductDesc", CS.CS_ProductDesc);

            if (CS.CS_ImgPath != null)
            {
                cmd.Parameters.AddWithValue("@CS_ImgPath", CS.CS_ImgPath);
            }


            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }

        public void DeleteTempSalesGst(int SalID)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("delete  TempSaleGSTs where TempSaleGST_ID = @TempSaleGST_ID", Mycon);
            cmd.Parameters.AddWithValue("@TempSaleGST_ID", SalID);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }
        public void AddSaleGst_ChargeDis(TempSaleGST TSG)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            string checkbillno = "select * from SalesGST_ChargeDisc where SalesGST_BillNo = @SalesGST_BillNo";
            SqlCommand cmd1 = new SqlCommand(checkbillno, Mycon);
            cmd1.Parameters.AddWithValue("@SalesGST_BillNo", TSG.TempSaleGST_BillNo);
            Mycon.Open();
            object counts = cmd1.ExecuteScalar();
            Mycon.Close();


            SqlCommand cmd;

            if (counts != null)
            {
                cmd = new SqlCommand("update SalesGST_ChargeDisc set SalesGST_DiscountRs = @SalesGST_DiscountRs, SalesGST_DiscountPer = @SalesGST_DiscountPer,SalesGST_ChargesName = @SalesGST_ChargesName, SalesGST_ChargesAmt = @SalesGST_ChargesAmt,SalesGST_Note = @SalesGST_Note where SalesGST_BillNo = @SalesGST_BillNo", Mycon);
            }
            else
            {
                cmd = new SqlCommand("insert into SalesGST_ChargeDisc values(@SalesGST_DiscountRs,@SalesGST_DiscountPer,@SalesGST_ChargesName,@SalesGST_ChargesAmt,@SalesGST_BillNo,@SalesGST_Note)", Mycon);
            }


            cmd.Parameters.AddWithValue("@SalesGST_BillNo", TSG.TempSaleGST_BillNo);
            cmd.Parameters.AddWithValue("@SalesGST_DiscountRs", Convert.ToDecimal(TSG.TempSaleGST_DiscRs));
            cmd.Parameters.AddWithValue("@SalesGST_DiscountPer", Convert.ToDecimal(TSG.TempSaleGST_DiscPer));

            if (TSG.TempSaleGST_ChargesName != null)
            {
                cmd.Parameters.AddWithValue("@SalesGST_ChargesName", TSG.TempSaleGST_ChargesName);
            }
            else
            {
                cmd.Parameters.AddWithValue("@SalesGST_ChargesName", " ");

            }

            cmd.Parameters.AddWithValue("@SalesGST_ChargesAmt", Convert.ToDecimal(TSG.TempSaleGST_ChargesAmt));
            cmd.Parameters.AddWithValue("@SalesGST_Note", "Good");


            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }
        public void AddEdit_SaleGst_Tnc(int id, string Bill_No)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);

            string query = "insert into SalesGst_Tnc values(@SalesGst_BillNo,@SalesGst_TCID)";

            SqlCommand cmd = new SqlCommand(query, Mycon);

            cmd.Parameters.AddWithValue("@SalesGst_BillNo", Bill_No);
            cmd.Parameters.AddWithValue("@SalesGst_TCID", id);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }
        public void Add_SaleGst_Reports(TempSaleGST tsb)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);



            string AddPurForRepo = "insert into SalesGST_Report values(@SalesGST_Rpt_BillNo,@SalesGST_Rpt_date,@SalesGST_Rpt_GrandTotal,@SalesGST_Rpt_FinalTotal)";
            SqlCommand cmd = new SqlCommand(AddPurForRepo, Mycon);

            cmd.Parameters.AddWithValue("@SalesGST_Rpt_BillNo", tsb.TempSaleGST_BillNo);
            cmd.Parameters.AddWithValue("@SalesGST_Rpt_date", tsb.TempSaleGST_Date);
            cmd.Parameters.AddWithValue("@SalesGST_Rpt_GrandTotal", tsb.TempSaleGST_GrandTot);
            cmd.Parameters.AddWithValue("@SalesGST_Rpt_FinalTotal", tsb.TempSaleGST_TotalAmt);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }
        public void Add_SalesGst(SalesGST sg)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("insert into SalesGSTs values(@SaleGST_SuppCustId,@SaleGST_BillNo,@SaleGST_ProductRate,@SaleGST_ProductID,@SaleGST_Discount,@SaleGST_Quantity,@SaleGST_GstRs,@SaleGST_Total,@SaleGST_Date,@SaleGST_BillNo_Int)", Mycon);

            //   cmd.Parameters.AddWithValue("@SalBilWiGSTID", Convert.ToInt32(TSal.SalBilWiGSTID));

            cmd.Parameters.AddWithValue("@SaleGST_SuppCustId", Convert.ToInt32(sg.SaleGST_SuppCustId));
            cmd.Parameters.AddWithValue("@SaleGST_BillNo", sg.SaleGST_BillNo);
            cmd.Parameters.AddWithValue("@SaleGST_ProductRate", Convert.ToInt32(sg.SaleGST_ProductRate));
            cmd.Parameters.AddWithValue("@SaleGST_ProductID", Convert.ToDecimal(sg.SaleGST_ProductID));
            cmd.Parameters.AddWithValue("@SaleGST_Discount", sg.SaleGST_Discount);
            cmd.Parameters.AddWithValue("@SaleGST_Quantity", sg.SaleGST_Quantity);
            cmd.Parameters.AddWithValue("@SaleGST_GstRs", sg.SaleGST_GstRs);
            cmd.Parameters.AddWithValue("@SaleGST_Total", sg.SaleGST_Total);

            cmd.Parameters.AddWithValue("@SaleGST_Date", sg.SaleGST_Date);
            cmd.Parameters.AddWithValue("@SaleGST_BillNo_Int", sg.SaleGST_BillNo_Int);



            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }



        public void Truncate_TempSaleGst() // this is temp data delete function
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("Truncate table TempSaleGSTs", Mycon);
            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }





        //  Gst Cal
        public object SumOfQuntSaleGST()
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT SUM(TempSaleGST_Quantity) FROM TempSaleGSTs", Mycon);
            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }
        public object SumOfProductRateSaleGST()
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT SUM(ProductDetails.ProductPurchaseRate) FROM TempSaleGSTs inner join ProductDetails on TempSaleGSTs.TempSaleGST_ProductID = ProductDetails.PDID", Mycon);


            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }
        public object SumOfProductGSTSaleGST()
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            // SqlCommand cmd = new SqlCommand("SELECT SUM(ProductGSTs.ProdGst) FROM TempDataPurchases inner join ProductDetails on TempDataPurchases.TempPurProductID = ProductDetails.PDID inner join ProductGSTs on ProductDetails.GstPercent = ProductGSTs.ProdGstID", Mycon);
            SqlCommand cmd = new SqlCommand("SELECT SUM(TempSaleGST_GstRs) FROM TempSaleGSTs", Mycon);


            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }


        public List<CustomerOrder> PastCustOrderList()
        {


            List<CustomerOrder> Lst = new List<CustomerOrder>();
            SqlConnection Mycon = new SqlConnection(Cnstr);

            //"select SalesBillWithoutGstDtls.SalBilWiGSTBillNo, SUM(SaleWiGstTransactions.SalwiGst_TranReciAmt) as SalwiGst_TranReciAmt, SalesBillWithoutGstDtl_Report.SalBiWiGst_Rpt_FinalTotal from SalesBillWithoutGstDtls join SaleWiGstTransactions on SalesBillWithoutGstDtls.SalBilWiGSTBillNo = SaleWiGstTransactions.SalwiGst_BillNo join SalesBillWithoutGstDtl_Report on SalesBillWithoutGstDtl_Report.SalBiWiGst_Rpt_BillNo = SaleWiGstTransactions.SalwiGst_BillNo where SalesBillWithoutGstDtls.SalBilWiGSTSuppCustId = @SalBilWiGSTSuppCustId GROUP BY SalesBillWithoutGstDtls.SalBilWiGSTBillNo, SalesBillWithoutGstDtl_Report.SalBiWiGst_Rpt_FinalTotal";

            string Sqlquery = "select * from CustomerOrders as co join Customer_Registration as cr on  cr.Cust_RID = co.CustID left join CustomerDeliveryStatus as cs on cs.CDS_ID = co.DeliveryStatus where not co.DeliveryStatus = 5 and co.CustOrdDate between @Pdate and @currentdate ORDER BY OrderID DESC";

            SqlCommand cmd = new SqlCommand(Sqlquery, Mycon);

            DateTime Past_Dt = DateTime.Today.AddDays(-30);

            cmd.Parameters.AddWithValue("@Pdate", Convert.ToDateTime(Past_Dt).ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@currentdate", Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd"));

            try
            {
                Mycon.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerOrder CO = new CustomerOrder();

                    CO.OrderID = Convert.ToInt32(reader["OrderID"]);
                    CO.Cust_Name = reader["Cust_Name"].ToString();

                    CO.CustNumber = reader["CustNumber"].ToString();
                    CO.CustAddress = reader["CustAddress"].ToString();
                    CO.CustStatus = reader["CustStatus"].ToString();

                    CO.CustPaymentMode = reader["CustPaymentMode"].ToString();

                    CO.DeliveryStatus = Convert.ToInt32(reader["DeliveryStatus"]);



                    CO.CustOrdDate = Convert.ToDateTime(reader["CustOrdDate"]);
                    CO.DeliTime = reader["DeliTime"].ToString();
                    CO.CDS_Name = reader["CDS_Name"].ToString();


                    //  CO.ComBiNo_FinalAmt = Convert.ToDecimal(reader["SalBiWiGst_Rpt_FinalTotal"]);
                    // CO.Notes = reader["SalBiWiGst_Note"].ToString();
                    // CO.Sale_date = Convert.ToDateTime(reader["SalBilWiGSTDate"]);

                    Lst.Add(CO);
                }
                Mycon.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return Lst;


        }

        public List<CustomerOrder> PastCustOrderList(DateTime? Fdate, DateTime? Ldate)
        {


            List<CustomerOrder> Lst = new List<CustomerOrder>();
            SqlConnection Mycon = new SqlConnection(Cnstr);

            //"select SalesBillWithoutGstDtls.SalBilWiGSTBillNo, SUM(SaleWiGstTransactions.SalwiGst_TranReciAmt) as SalwiGst_TranReciAmt, SalesBillWithoutGstDtl_Report.SalBiWiGst_Rpt_FinalTotal from SalesBillWithoutGstDtls join SaleWiGstTransactions on SalesBillWithoutGstDtls.SalBilWiGSTBillNo = SaleWiGstTransactions.SalwiGst_BillNo join SalesBillWithoutGstDtl_Report on SalesBillWithoutGstDtl_Report.SalBiWiGst_Rpt_BillNo = SaleWiGstTransactions.SalwiGst_BillNo where SalesBillWithoutGstDtls.SalBilWiGSTSuppCustId = @SalBilWiGSTSuppCustId GROUP BY SalesBillWithoutGstDtls.SalBilWiGSTBillNo, SalesBillWithoutGstDtl_Report.SalBiWiGst_Rpt_FinalTotal";

            string Sqlquery = "select * from CustomerOrders as co join Customer_Registration as cr on  cr.Cust_RID = co.CustID left join CustomerDeliveryStatus as cs on cs.CDS_ID = co.DeliveryStatus where co.CustOrdDate between @Pdate and @currentdate ORDER BY OrderID DESC";

            SqlCommand cmd = new SqlCommand(Sqlquery, Mycon);



            cmd.Parameters.AddWithValue("@Pdate", Convert.ToDateTime(Fdate).ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@currentdate", Convert.ToDateTime(Ldate).ToString("yyyy-MM-dd"));

            try
            {
                Mycon.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerOrder CO = new CustomerOrder();

                    CO.OrderID = Convert.ToInt32(reader["OrderID"]);
                    CO.Cust_Name = reader["Cust_Name"].ToString();

                    CO.CustNumber = reader["CustNumber"].ToString();
                    CO.CustAddress = reader["CustAddress"].ToString();
                    CO.CustStatus = reader["CustStatus"].ToString();

                    CO.CustPaymentMode = reader["CustPaymentMode"].ToString();

                    CO.DeliveryStatus = Convert.ToInt32(reader["DeliveryStatus"]);



                    CO.CustOrdDate = Convert.ToDateTime(reader["CustOrdDate"]);
                    CO.DeliTime = reader["DeliTime"].ToString();
                    CO.CDS_Name = reader["CDS_Name"].ToString();


                    //  CO.ComBiNo_FinalAmt = Convert.ToDecimal(reader["SalBiWiGst_Rpt_FinalTotal"]);
                    // CO.Notes = reader["SalBiWiGst_Note"].ToString();
                    // CO.Sale_date = Convert.ToDateTime(reader["SalBilWiGSTDate"]);

                    Lst.Add(CO);
                }
                Mycon.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return Lst;


        }




        public List<CustomerOrder> CustOrderList()
        {


            List<CustomerOrder> Lst = new List<CustomerOrder>();
            SqlConnection Mycon = new SqlConnection(Cnstr);

            //"select SalesBillWithoutGstDtls.SalBilWiGSTBillNo, SUM(SaleWiGstTransactions.SalwiGst_TranReciAmt) as SalwiGst_TranReciAmt, SalesBillWithoutGstDtl_Report.SalBiWiGst_Rpt_FinalTotal from SalesBillWithoutGstDtls join SaleWiGstTransactions on SalesBillWithoutGstDtls.SalBilWiGSTBillNo = SaleWiGstTransactions.SalwiGst_BillNo join SalesBillWithoutGstDtl_Report on SalesBillWithoutGstDtl_Report.SalBiWiGst_Rpt_BillNo = SaleWiGstTransactions.SalwiGst_BillNo where SalesBillWithoutGstDtls.SalBilWiGSTSuppCustId = @SalBilWiGSTSuppCustId GROUP BY SalesBillWithoutGstDtls.SalBilWiGSTBillNo, SalesBillWithoutGstDtl_Report.SalBiWiGst_Rpt_FinalTotal";

            string Sqlquery = "select * from CustomerOrders as co join Customer_Registration as cr on  cr.Cust_RID = co.CustID left join CustomerDeliveryStatus as cs on cs.CDS_ID = co.DeliveryStatus where not co.DeliveryStatus = 5 and co.CustOrdDate = @currentdate ORDER BY OrderID DESC";

            SqlCommand cmd = new SqlCommand(Sqlquery, Mycon);


            cmd.Parameters.AddWithValue("@currentdate", Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd"));
            try
            {
                Mycon.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerOrder CO = new CustomerOrder();

                    CO.OrderID = Convert.ToInt32(reader["OrderID"]);
                    CO.Cust_Name = reader["Cust_Name"].ToString();

                    CO.CustNumber = reader["CustNumber"].ToString();
                    CO.CustAddress = reader["CustAddress"].ToString();
                    CO.CustStatus = reader["CustStatus"].ToString();

                    CO.CustPaymentMode = reader["CustPaymentMode"].ToString();

                    CO.DeliveryStatus = Convert.ToInt32(reader["DeliveryStatus"]);



                    CO.CustOrdDate = Convert.ToDateTime(reader["CustOrdDate"]);
                    CO.DeliTime = reader["DeliTime"].ToString();
                    CO.CDS_Name = reader["CDS_Name"].ToString();


                    //  CO.ComBiNo_FinalAmt = Convert.ToDecimal(reader["SalBiWiGst_Rpt_FinalTotal"]);
                    // CO.Notes = reader["SalBiWiGst_Note"].ToString();
                    // CO.Sale_date = Convert.ToDateTime(reader["SalBilWiGSTDate"]);

                    Lst.Add(CO);
                }
                Mycon.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return Lst;


        }

        public void CustomerStatusUpdate(int ordId, int statusId)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("update CustomerOrders set DeliveryStatus  = @DeliveryStatus where OrderID = @OrderID", Mycon);

            cmd.Parameters.AddWithValue("@OrderID", ordId);
            cmd.Parameters.AddWithValue("@DeliveryStatus", statusId);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }

        public object SumOfPSaleGSTTotalDtl()
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT SUM(TempSaleGST_Total) FROM TempSaleGSTs", Mycon);

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }
        public object RowCountSaleGst()
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM TempSaleGSTs", Mycon);
            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }
        public object RowCountSaleGst_Report(string BillNo)
        {

            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM SalesBillWithoutGstDtl_Report where SalBiWiGst_Rpt_BillNo = @SalBiWiGst_Rpt_BillNo", Mycon);

            cmd.Parameters.AddWithValue("@SalBiWiGst_Rpt_BillNo", BillNo);
            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        } // later use
          //End Gst cal



        // <-------------- End Sale With Gst ------------>


        // <-------------- Common Bill No Generator ---------->
        public void AddCommonBillNo(string BillNo, string BillID)
        {
            int rslt = BillNoExistOrNo_CommonBillId(BillNo);

            if (rslt == 0)
            {

                SqlConnection Mycon = new SqlConnection(Cnstr);
                //"select SalesBillWithoutGstDtls.SalBilWiGSTBillNo, SUM(SaleWiGstTransactions.SalwiGst_TranReciAmt) as SalwiGst_TranReciAmt, SalesBillWithoutGstDtl_Report.SalBiWiGst_Rpt_FinalTotal, SalesBillWithoutGstDtls.SalBilWiGSTSuppCustId  from SalesBillWithoutGstDtls join SaleWiGstTransactions on SalesBillWithoutGstDtls.SalBilWiGSTBillNo = SaleWiGstTransactions.SalwiGst_BillNo join SalesBillWithoutGstDtl_Report on SalesBillWithoutGstDtl_Report.SalBiWiGst_Rpt_BillNo = SaleWiGstTransactions.SalwiGst_BillNo where SalesBillWithoutGstDtls.SalBilWiGSTBillNo = @SalBilWiGSTBillNo GROUP BY SalesBillWithoutGstDtls.SalBilWiGSTBillNo, SalesBillWithoutGstDtl_Report.SalBiWiGst_Rpt_FinalTotal, SalesBillWithoutGstDtls.SalBilWiGSTSuppCustId";
                string sqlSelect = "select sd.SalBilWiGSTBillNo,sr.SalBiWiGst_Rpt_FinalTotal, sc.SalBiWiGst_Note,sd.SalBilWiGSTDate, sd.SalBilWiGSTSuppCustId from SalesBillWithoutGstDtls as sd join SalesBillWithoutGstDtl_Report as sr on sr.SalBiWiGst_Rpt_BillNo = sd.SalBilWiGSTBillNo join SalesBillWithoutGstDtl_ChargesDisc as sc on sc.SalBiWiGst_BillNo = sr.SalBiWiGst_Rpt_BillNo where sd.SalBilWiGSTBillNo = @SalBilWiGSTBillNo  group by sd.SalBilWiGSTBillNo,sr.SalBiWiGst_Rpt_FinalTotal, sc.SalBiWiGst_Note, sd.SalBilWiGSTDate, sd.SalBilWiGSTSuppCustId";
                SqlCommand cmd = new SqlCommand(sqlSelect, Mycon);
                cmd.Parameters.AddWithValue("@SalBilWiGSTBillNo", BillNo);
                Mycon.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                CommanBillNo custsupp = new CommanBillNo();
                //    custsupp.ComBiNo_BillNo   =   reader["SalBilWiGSTBillNo"].ToString();
                ////    custsupp.ComBiNo_PaidAmt  =  Convert.ToDecimal(reader["SalwiGst_TranReciAmt"]);
                //    custsupp.ComBiNo_FinalAmt = Convert.ToDecimal(reader["SalBiWiGst_Rpt_FinalTotal"]);
                //    custsupp.ComBiNo_CustSuppID = Convert.ToInt32(reader["SalBilWiGSTSuppCustId"]);

                custsupp.ComBiNo_BillNo = reader["SalBilWiGSTBillNo"].ToString();
                custsupp.ComBiNo_FinalAmt = Convert.ToDecimal(reader["SalBiWiGst_Rpt_FinalTotal"]);
                custsupp.Notes = reader["SalBiWiGst_Note"].ToString();
                custsupp.Sale_date = Convert.ToDateTime(reader["SalBilWiGSTDate"]);
                custsupp.ComBiNo_CustSuppID = Convert.ToInt32(reader["SalBilWiGSTSuppCustId"]);




                Mycon.Close();

                reader.Close();



                string query = "insert into CommanBillNoes values(@ComBiNo_BillNo,@ComBiNo_FinalAmt,@ComBiNo_BillID,@DispStatus,@ComBiNo_CustSuppID)";
                SqlCommand cmd1 = new SqlCommand(query, Mycon);

                cmd1.Parameters.AddWithValue("@ComBiNo_BillNo", custsupp.ComBiNo_BillNo);
                cmd1.Parameters.AddWithValue("@ComBiNo_FinalAmt", Convert.ToDecimal(custsupp.ComBiNo_FinalAmt));

                cmd1.Parameters.AddWithValue("@ComBiNo_BillID", BillID); // BillID
                cmd1.Parameters.AddWithValue("@DispStatus", 1);
                cmd1.Parameters.AddWithValue("@ComBiNo_CustSuppID", custsupp.ComBiNo_CustSuppID); // CustID

                Mycon.Open();

                cmd1.ExecuteNonQuery();

                Mycon.Close();
            }

        }
        public int BillNoExistOrNo_CommonBillId(string BillNo)
        {
            int rslt = 0;

            SqlConnection Mycon = new SqlConnection(Cnstr);
            string sqlSelect = "select* from CommanBillNoes where ComBiNo_BillNo = @ComBiNo_BillNo";
            SqlCommand cmd = new SqlCommand(sqlSelect, Mycon);
            cmd.Parameters.AddWithValue("@ComBiNo_BillNo", BillNo);
            Mycon.Open();
            object rslts = cmd.ExecuteScalar();
            Mycon.Close();
            rslt = Convert.ToInt32(rslts);

            return rslt;
        }


        public void DeleteCommonBillNo(int ID)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);

            string query = "delete CommanBillNoes where ComBiNo_ID = @ComBiNo_ID";

            SqlCommand cmd = new SqlCommand(query, Mycon);

            cmd.Parameters.AddWithValue("@ComBiNo_ID", ID);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }
        public object CommonBillNo_FinalAmt(string BillNo)
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT SalBiWiGst_Rpt_FinalTotal FROM SalesBillWithoutGstDtl_Report where SalBiWiGst_Rpt_BillNo = @SalBiWiGst_Rpt_BillNo", Mycon);

            cmd.Parameters.AddWithValue("@SalBiWiGst_Rpt_BillNo", BillNo);

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }

        public object CommonBillNo_PaidAmt(string BillNo)
        {

            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT SUM(SalwiGst_TranReciAmt) FROM SaleWiGstTransactions where SalwiGst_BillNo = @SalwiGst_BillNo", Mycon);

            cmd.Parameters.AddWithValue("@SalwiGst_BillNo", BillNo);

            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }


        // Search Functionality
        public List<CommanBillNo> BillNoList_AccordingName(int CustSuppID)
        {
            List<CommanBillNo> Lst = new List<CommanBillNo>();
            SqlConnection Mycon = new SqlConnection(Cnstr);

            //"select SalesBillWithoutGstDtls.SalBilWiGSTBillNo, SUM(SaleWiGstTransactions.SalwiGst_TranReciAmt) as SalwiGst_TranReciAmt, SalesBillWithoutGstDtl_Report.SalBiWiGst_Rpt_FinalTotal from SalesBillWithoutGstDtls join SaleWiGstTransactions on SalesBillWithoutGstDtls.SalBilWiGSTBillNo = SaleWiGstTransactions.SalwiGst_BillNo join SalesBillWithoutGstDtl_Report on SalesBillWithoutGstDtl_Report.SalBiWiGst_Rpt_BillNo = SaleWiGstTransactions.SalwiGst_BillNo where SalesBillWithoutGstDtls.SalBilWiGSTSuppCustId = @SalBilWiGSTSuppCustId GROUP BY SalesBillWithoutGstDtls.SalBilWiGSTBillNo, SalesBillWithoutGstDtl_Report.SalBiWiGst_Rpt_FinalTotal";

            string sqlSelect = "select sd.SalBilWiGSTBillNo,sr.SalBiWiGst_Rpt_FinalTotal, sc.SalBiWiGst_Note,sd.SalBilWiGSTDate from SalesBillWithoutGstDtls as sd join SalesBillWithoutGstDtl_Report as sr on sr.SalBiWiGst_Rpt_BillNo = sd.SalBilWiGSTBillNo join SalesBillWithoutGstDtl_ChargesDisc as sc on sc.SalBiWiGst_BillNo = sr.SalBiWiGst_Rpt_BillNo where SalBilWiGSTSuppCustId = @SalBilWiGSTSuppCustId and sc.SalBiWiGst_Status = 2 group by sd.SalBilWiGSTBillNo,sr.SalBiWiGst_Rpt_FinalTotal, sc.SalBiWiGst_Note,sd.SalBilWiGSTDate";

            SqlCommand cmd = new SqlCommand(sqlSelect, Mycon);
            cmd.Parameters.AddWithValue("@SalBilWiGSTSuppCustId", CustSuppID);
            try
            {
                Mycon.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CommanBillNo custsupp = new CommanBillNo();

                    custsupp.ComBiNo_BillNo = reader["SalBilWiGSTBillNo"].ToString();
                    custsupp.ComBiNo_FinalAmt = Convert.ToDecimal(reader["SalBiWiGst_Rpt_FinalTotal"]);
                    custsupp.Notes = reader["SalBiWiGst_Note"].ToString();
                    custsupp.Sale_date = Convert.ToDateTime(reader["SalBilWiGSTDate"]);

                    Lst.Add(custsupp);
                }
                Mycon.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return Lst;
        }
        public List<CommanBillNo> BillNoList_AccordingName_BetDate(CommanBillNo comBillNo)
        {
            List<CommanBillNo> Lst = new List<CommanBillNo>();
            SqlConnection Mycon = new SqlConnection(Cnstr);
            //"select SalesBillWithoutGstDtls.SalBilWiGSTBillNo, SUM(SaleWiGstTransactions.SalwiGst_TranReciAmt) as SalwiGst_TranReciAmt, SalesBillWithoutGstDtl_Report.SalBiWiGst_Rpt_FinalTotal from SalesBillWithoutGstDtls join SaleWiGstTransactions on SalesBillWithoutGstDtls.SalBilWiGSTBillNo = SaleWiGstTransactions.SalwiGst_BillNo join SalesBillWithoutGstDtl_Report on SalesBillWithoutGstDtl_Report.SalBiWiGst_Rpt_BillNo = SaleWiGstTransactions.SalwiGst_BillNo where SalesBillWithoutGstDtls.SalBilWiGSTSuppCustId = @SalBilWiGSTSuppCustId GROUP BY SalesBillWithoutGstDtls.SalBilWiGSTBillNo, SalesBillWithoutGstDtl_Report.SalBiWiGst_Rpt_FinalTotal";

            string sqlSelect = "select sd.SalBilWiGSTBillNo,sr.SalBiWiGst_Rpt_FinalTotal, sc.SalBiWiGst_Note,sd.SalBilWiGSTDate from SalesBillWithoutGstDtls as sd join SalesBillWithoutGstDtl_Report as sr on sr.SalBiWiGst_Rpt_BillNo = sd.SalBilWiGSTBillNo join SalesBillWithoutGstDtl_ChargesDisc as sc on sc.SalBiWiGst_BillNo = sr.SalBiWiGst_Rpt_BillNo where SalBilWiGSTSuppCustId = @SalBilWiGSTSuppCustId and sc.SalBiWiGst_Status = 2 and sd.SalBilWiGSTDate BETWEEN @Fdate and @Ldate group by sd.SalBilWiGSTBillNo,sr.SalBiWiGst_Rpt_FinalTotal, sc.SalBiWiGst_Note, sd.SalBilWiGSTDate";

            SqlCommand cmd = new SqlCommand(sqlSelect, Mycon);
            cmd.Parameters.AddWithValue("@SalBilWiGSTSuppCustId", comBillNo.ComBiNo_CustSuppID);
            cmd.Parameters.AddWithValue("@Fdate", comBillNo.Fdate);
            cmd.Parameters.AddWithValue("@Ldate", comBillNo.Ldate);


            try
            {
                Mycon.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CommanBillNo custsupp = new CommanBillNo();

                    custsupp.ComBiNo_BillNo = reader["SalBilWiGSTBillNo"].ToString();
                    custsupp.ComBiNo_FinalAmt = Convert.ToDecimal(reader["SalBiWiGst_Rpt_FinalTotal"]);
                    custsupp.Notes = reader["SalBiWiGst_Note"].ToString();
                    custsupp.Sale_date = Convert.ToDateTime(reader["SalBilWiGSTDate"]);


                    Lst.Add(custsupp);
                }
                Mycon.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return Lst;
        }
        // End Search Functionality

        public string CommanBill_BarcodeGenrator()
        {
            string BarcodeNo;

            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 ComBiNo_BillID FROM CommanBillNoes where DispStatus = 0 ORDER BY ComBiNo_ID DESC", Mycon);
            Mycon.Open();
            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            BarcodeNo = Convert.ToString(rslt);
            return BarcodeNo;
        }
        public void CommonBillUpdateStatus()
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("Update CommanBillNoes set DispStatus = 0   where DispStatus = 1", Mycon);
            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }

        public void CommonBill_Edit(string BillID)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("Update CommanBillNoes set DispStatus = 1 where ComBiNo_BillID = @ComBiNo_BillID", Mycon);
            cmd.Parameters.AddWithValue("@ComBiNo_BillID", BillID);
            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }


        public void CommonBill_Delete(string BillID)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("Delete CommanBillNoes where ComBiNo_BillID = @ComBiNo_BillID", Mycon);
            cmd.Parameters.AddWithValue("@ComBiNo_BillID", BillID);
            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }


        public List<CommanBillNo> CommonBillNo_GroupBy()
        {
            List<CommanBillNo> lst = new List<CommanBillNo>();

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT ComBiNo_BillID, CustName FROM CommanBillNoes join CustomerDetails on CommanBillNoes.ComBiNo_CustSuppID = CustomerDetails.CustID where CommanBillNoes.DispStatus = 0  GROUP BY CommanBillNoes.ComBiNo_BillID,CustomerDetails.CustName", Mycon);
            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                CommanBillNo Com = new CommanBillNo();

                Com.ComBiNo_BillID = dr["ComBiNo_BillID"].ToString();
                Com.CustSupp_Name = dr["CustName"].ToString();

                lst.Add(Com);
            }

            Mycon.Close();
            return lst;

        }

        public List<CommanBillNo> CommonBillNo_GroupBy(string BillID)
        {
            List<CommanBillNo> lst = new List<CommanBillNo>();

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("SELECT ComBiNo_BillNo FROM CommanBillNoes where DispStatus = 0 and ComBiNo_BillID = @ComBiNo_BillID", Mycon);
            cmd.Parameters.AddWithValue("@ComBiNo_BillID", BillID);

            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                CommanBillNo Com = new CommanBillNo();
                Com.ComBiNo_BillNo = dr["ComBiNo_BillNo"].ToString();

                lst.Add(Com);
            }
            Mycon.Close();
            return lst;
        }

        public List<SalesBillWithoutGstDtl> SalewithoutGstList(string BillID)
        {
            List<SalesBillWithoutGstDtl> lst = new List<SalesBillWithoutGstDtl>();

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select * from SalesBillWithoutGstDtls  join ProductDetails on SalesBillWithoutGstDtls.SalBilWiGSTProductID = ProductDetails.PDID  join ProductGSTs on ProductGSTs.ProdGstID = ProductDetails.GstPercent where SalesBillWithoutGstDtls.SalBilWiGSTBillNo = @SalBilWiGSTBillNo", Mycon);
            cmd.Parameters.AddWithValue("@SalBilWiGSTBillNo", BillID);

            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                SalesBillWithoutGstDtl SaleGst = new SalesBillWithoutGstDtl();

                SaleGst.SalBilWiGSTSuppCustId = Convert.ToInt32(dr["SalBilWiGSTSuppCustId"]);
                SaleGst.SalBilWiGSTBillNo = dr["SalBilWiGSTBillNo"].ToString();
                SaleGst.SalBilWiGSTProductRate = Convert.ToDecimal(dr["SalBilWiGSTProductRate"]);
                SaleGst.SalBilWiGSTProductID = Convert.ToInt32(dr["SalBilWiGSTProductID"]);
                SaleGst.SalBilWiGSTQuantity = Convert.ToDecimal(dr["SalBilWiGSTQuantity"]);

                SaleGst.SalBilWiGSTGstRs = Convert.ToDecimal(dr["ProdGst"]);

                SaleGst.SalBilWiGSTTotal = Convert.ToDecimal(dr["SalBilWiGSTTotal"]);
                SaleGst.SalBilWiGSTDate = Convert.ToDateTime(dr["SalBilWiGSTDate"]);

                lst.Add(SaleGst);
            }
            Mycon.Close();
            return lst;
        }



        // <-------------- End Common Bill No Generator ---------->













        // @@@@@@@@@@@@@@@@@@  Report Section Code @@@@@@@@@@@@@@

        // <-------------------- purchase Report ------------------>

        public List<PurchaseDetails> Purchase_FromDate_Report(DateTime? Fdate, DateTime? LDate)
        {
            List<PurchaseDetails> lst = new List<PurchaseDetails>();

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select p.PurBillNo, cd.CustName, p.PurDate, pr.PrFinalTotal from PurchaseDtls as p join CustomerDetails as cd on p.PurSuppCustId = cd.CustID join PurchaseForReports as pr on p.PurBillNo = pr.PrBillNo where p.PurDate BETWEEN @FDate AND @LDate group by p.PurBillNo, cd.CustName, p.PurDate, pr.PrFinalTotal", Mycon);
            cmd.Parameters.AddWithValue("@FDate", Fdate);
            cmd.Parameters.AddWithValue("@LDate", LDate);


            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                PurchaseDetails Pd = new PurchaseDetails();

                Pd.BillNo = dr["PurBillNo"].ToString();
                Pd.SplrCustName = dr["CustName"].ToString();
                Pd.PurchaseDate = Convert.ToDateTime(dr["PurDate"]);
                Pd.PrchsDtlFinalPurchaseAmt = Convert.ToDecimal(dr["PrFinalTotal"]);

                lst.Add(Pd);
            }

            Mycon.Close();

            return lst;
        }
        public decimal Sum_FinalTotl_In_Puchase(DateTime? Fdate, DateTime? LDate)
        {

            int rslt = Count_FinalTotl_In_Puchase(Fdate, LDate);
            decimal FTot = 0;
            if (rslt != 0)
            {
                SqlConnection Mycon = new SqlConnection(Cnstr);
                SqlCommand cmd = new SqlCommand("select sum(PrFinalTotal) from PurchaseForReports where Prdate BETWEEN @FDate AND @LDate", Mycon);
                cmd.Parameters.AddWithValue("@FDate", Fdate);
                cmd.Parameters.AddWithValue("@LDate", LDate);

                Mycon.Open();
                object obj = cmd.ExecuteScalar();
                Mycon.Close();
                FTot = Convert.ToDecimal(obj);

            }
            return FTot;
        }

        public int Count_FinalTotl_In_Puchase(DateTime? Fdate, DateTime? LDate)
        {

            int counts = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand(" select count(*) from PurchaseForReports where Prdate BETWEEN @FDate AND @LDate", Mycon);
            cmd.Parameters.AddWithValue("@FDate", Fdate);
            cmd.Parameters.AddWithValue("@LDate", LDate);

            Mycon.Open();

            object obj = cmd.ExecuteScalar();
            Mycon.Close();
            counts = Convert.ToInt32(obj);



            return counts;
        }





        // <-------------------- End purchase Report ------------------>

        public object SumGstRs(string Billno)
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            // SqlCommand cmd = new SqlCommand("SELECT SUM(ProductGSTs.ProdGst) FROM TempDataPurchases inner join ProductDetails on TempDataPurchases.TempPurProductID = ProductDetails.PDID inner join ProductGSTs on ProductDetails.GstPercent = ProductGSTs.ProdGstID", Mycon);
            SqlCommand cmd = new SqlCommand("select sum(PurGstRs) from PurchaseDtls where PurBillNo = @PurBillNo", Mycon);
            cmd.Parameters.AddWithValue("@PurBillNo", Billno);
            Mycon.Open();

            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }
        public object SumGstRs(DateTime? Fdate, DateTime? LDate, int? CustId)
        {
            object rslt = 0;
            SqlConnection Mycon = new SqlConnection(Cnstr);
            // SqlCommand cmd = new SqlCommand("SELECT SUM(ProductGSTs.ProdGst) FROM TempDataPurchases inner join ProductDetails on TempDataPurchases.TempPurProductID = ProductDetails.PDID inner join ProductGSTs on ProductDetails.GstPercent = ProductGSTs.ProdGstID", Mycon);
            SqlCommand cmd = new SqlCommand("select sum(PurGstRs) from PurchaseDtls where PurSuppCustId = @CustID and PurDate BETWEEN @FDate AND @LDate", Mycon);
            cmd.Parameters.AddWithValue("@CustID", CustId);
            cmd.Parameters.AddWithValue("@FDate", Fdate);
            cmd.Parameters.AddWithValue("@LDate", LDate);

            Mycon.Open();

            rslt = cmd.ExecuteScalar();
            Mycon.Close();
            return rslt;
        }




        //@@@@@@@@@  FDate LDate CustName  @@@@@@@@@



        // < ------------   Purchase Report (Info , Products, Discount, Charges) ------------->
        public List<PurchaseDtl> CustInfo(DateTime? Fdate, DateTime? LDate, int? CustId)
        {
            List<PurchaseDtl> Lst = new List<PurchaseDtl>();


            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("select p.PurBillNo, c.CustName, p.PurDate from PurchaseDtls as p join CustomerDetails as c on c.CustID = p.PurSuppCustId where p.PurSuppCustId = @CustID and p.PurDate between @FDate and @LDate group by p.PurBillNo, c.CustName, p.PurDate", Mycon);
            cmd.Parameters.AddWithValue("@CustID", CustId);
            cmd.Parameters.AddWithValue("@FDate", Fdate);
            cmd.Parameters.AddWithValue("@LDate", LDate);

            Mycon.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                PurchaseDtl Pd = new PurchaseDtl();

                Pd.PurBillNo = dr["PurBillNo"].ToString();
                Pd.SplrCustName = dr["CustName"].ToString();
                Pd.PurDate = Convert.ToDateTime(dr["PurDate"]);

                Lst.Add(Pd);
            }

            Mycon.Close();

            return Lst;
        }
        public List<PurchaseDtl> Product_Report(DateTime? Fdate, DateTime? LDate, int? CustId)
        {
            List<PurchaseDtl> Lst = new List<PurchaseDtl>();


            SqlConnection Mycon = new SqlConnection(Cnstr);

            // SqlCommand cmd = new SqlCommand("select p.PurBillNo, pd.ProductName, pd.ProductPurchaseRate, p.PurDiscount, p.PurProductRate , p.PurQuantity, pd.GstPercent , p.PurGstRs, p.PurTotal from PurchaseDtls as p join ProductDetails as pd on pd.PDID = p.PurProductID where p.PurSuppCustId = @CustID and p.PurDate between @FDate and @LDate", Mycon);


            SqlCommand cmd = new SqlCommand("select p.PurBillNo, pd.ProductName, sum(pd.ProductPurchaseRate) as ProductPurchaseRate, sum(p.PurDiscount) as PurDiscount, sum(p.PurProductRate) as PurProductRate, sum(p.PurQuantity) as PurQuantity, sum(pd.GstPercent) as GstPercent, sum(p.PurGstRs) as PurGstRs, sum(p.PurTotal) as PurTotal from PurchaseDtls as p join ProductDetails as pd on pd.PDID = p.PurProductID where p.PurSuppCustId = @CustID and p.PurDate between @FDate and @LDate group by p.PurBillNo, pd.ProductName", Mycon);

            cmd.Parameters.AddWithValue("@CustID", CustId);
            cmd.Parameters.AddWithValue("@FDate", Fdate);
            cmd.Parameters.AddWithValue("@LDate", LDate);

            Mycon.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                PurchaseDtl Pd = new PurchaseDtl();

                Pd.PurBillNo = dr["PurBillNo"].ToString();
                Pd.ProductSelection = dr["ProductName"].ToString();
                Pd.PurProductRate = Convert.ToDecimal(dr["ProductPurchaseRate"]);
                Pd.PurDiscount = Convert.ToDecimal(dr["PurDiscount"]);
                Pd.DiscProductRate = Convert.ToDecimal(dr["PurProductRate"]);
                Pd.PurQuantity = Convert.ToInt32(dr["PurQuantity"]);
                Pd.ProductGst = Convert.ToInt32(dr["GstPercent"]);
                Pd.PurGstRs = Convert.ToDecimal(dr["PurGstRs"]);
                Pd.PurTotal = Convert.ToDecimal(dr["PurTotal"]);

                Lst.Add(Pd);
            }

            Mycon.Close();

            return Lst;
        }
        public List<PurchaseDtl> DiscCharge_Report(DateTime? Fdate, DateTime? LDate, int? CustId)
        {
            List<PurchaseDtl> Lst = new List<PurchaseDtl>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("select pr.PrRBBillNo, pr.PrRBDiscountPer, pr.PrRBDiscountRs, pr.PrRBCharges from PurchaseDtls as p join PurchaseReportBills as pr on p.PurBillNo = pr.PrRBBillNo where p.PurSuppCustId = @CustID and p.PurDate between @FDate and @LDate group by pr.PrRBBillNo, pr.PrRBDiscountPer, pr.PrRBDiscountRs, pr.PrRBCharges", Mycon);
            cmd.Parameters.AddWithValue("@CustID", CustId);
            cmd.Parameters.AddWithValue("@FDate", Fdate);
            cmd.Parameters.AddWithValue("@LDate", LDate);

            Mycon.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                PurchaseDtl Pd = new PurchaseDtl();

                Pd.PurBillNo = dr["PrRBBillNo"].ToString();
                Pd.DiscPer = Convert.ToDecimal(dr["PrRBDiscountPer"]);
                Pd.DiscRs = Convert.ToDecimal(dr["PrRBDiscountRs"]);
                Pd.Charges = Convert.ToDecimal(dr["PrRBCharges"]);

                Lst.Add(Pd);
            }

            Mycon.Close();

            return Lst;
        }
        public List<PurchaseDtl> GrandTotalFinalTotal_Report(DateTime? Fdate, DateTime? LDate, int? CustId)
        {
            List<PurchaseDtl> Lst = new List<PurchaseDtl>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("select p.PurBillNo, sum(p.PurGstRs) as GstTotal, pr.PrGrandTotal, pr.PrFinalTotal from PurchaseDtls as p join PurchaseForReports as pr on pr.PrBillNo = p.PurBillNo where p.PurSuppCustId = @CustID and p.PurDate between @FDate and @LDate group by p.PurBillNo, pr.PrGrandTotal, pr.PrFinalTotal", Mycon);

            cmd.Parameters.AddWithValue("@CustID", CustId);
            cmd.Parameters.AddWithValue("@FDate", Fdate);
            cmd.Parameters.AddWithValue("@LDate", LDate);

            Mycon.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                PurchaseDtl Pd = new PurchaseDtl();

                Pd.PurBillNo = dr["PurBillNo"].ToString();
                Pd.PurGstRs = Convert.ToDecimal(dr["GstTotal"]);
                Pd.GrandTot = Convert.ToDecimal(dr["PrGrandTotal"]);
                Pd.TotalAmt = Convert.ToDecimal(dr["PrFinalTotal"]);

                Lst.Add(Pd);
            }

            Mycon.Close();

            return Lst;
        }


        public List<PurchaseDtl> CustInfo(string Billno)
        {
            List<PurchaseDtl> Lst = new List<PurchaseDtl>();
            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("select p.PurBillNo, c.CustName, p.PurDate from PurchaseDtls as p join CustomerDetails as c on c.CustID = p.PurSuppCustId where p.PurBillNo = @PurBillNo  group by p.PurBillNo, c.CustName, p.PurDate", Mycon);
            cmd.Parameters.AddWithValue("@PurBillNo", Billno);
            Mycon.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                PurchaseDtl Pd = new PurchaseDtl();

                Pd.PurBillNo = dr["PurBillNo"].ToString();
                Pd.SplrCustName = dr["CustName"].ToString();
                Pd.PurDate = Convert.ToDateTime(dr["PurDate"]);

                Lst.Add(Pd);
            }

            Mycon.Close();

            return Lst;
        }
        public List<PurchaseDtl> Product_Report(string Billno)
        {
            List<PurchaseDtl> Lst = new List<PurchaseDtl>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            // SqlCommand cmd = new SqlCommand("select p.PurBillNo, pd.ProductName, pd.ProductPurchaseRate, p.PurDiscount, p.PurProductRate , p.PurQuantity, pd.GstPercent , p.PurGstRs, p.PurTotal from PurchaseDtls as p join ProductDetails as pd on pd.PDID = p.PurProductID where p.PurSuppCustId = @CustID and p.PurDate between @FDate and @LDate", Mycon);


            SqlCommand cmd = new SqlCommand("select p.PurBillNo, pd.ProductName, sum(pd.ProductPurchaseRate) as ProductPurchaseRate, sum(p.PurDiscount) as PurDiscount, sum(p.PurProductRate) as PurProductRate, sum(p.PurQuantity) as PurQuantity, sum(pd.GstPercent) as GstPercent, sum(p.PurGstRs) as PurGstRs, sum(p.PurTotal) as PurTotal from PurchaseDtls as p join ProductDetails as pd on pd.PDID = p.PurProductID where p.PurBillNo = @PurBillNo group by p.PurBillNo, pd.ProductName", Mycon);

            cmd.Parameters.AddWithValue("@PurBillNo", Billno);


            Mycon.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                PurchaseDtl Pd = new PurchaseDtl();

                Pd.PurBillNo = dr["PurBillNo"].ToString();
                Pd.ProductSelection = dr["ProductName"].ToString();
                Pd.PurProductRate = Convert.ToDecimal(dr["ProductPurchaseRate"]);
                Pd.PurDiscount = Convert.ToDecimal(dr["PurDiscount"]);
                Pd.DiscProductRate = Convert.ToDecimal(dr["PurProductRate"]);
                Pd.PurQuantity = Convert.ToInt32(dr["PurQuantity"]);
                Pd.ProductGst = Convert.ToInt32(dr["GstPercent"]);
                Pd.PurGstRs = Convert.ToDecimal(dr["PurGstRs"]);
                Pd.PurTotal = Convert.ToDecimal(dr["PurTotal"]);

                Lst.Add(Pd);
            }

            Mycon.Close();

            return Lst;
        }
        public List<PurchaseDtl> DiscCharge_Report(string Billno)
        {
            List<PurchaseDtl> Lst = new List<PurchaseDtl>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("select pr.PrRBBillNo, pr.PrRBDiscountPer, pr.PrRBDiscountRs, pr.PrRBCharges from PurchaseDtls as p join PurchaseReportBills as pr on p.PurBillNo = pr.PrRBBillNo where pr.PrRBBillNo = @PrRBBillNo group by pr.PrRBBillNo, pr.PrRBDiscountPer, pr.PrRBDiscountRs, pr.PrRBCharges", Mycon);
            cmd.Parameters.AddWithValue("@PrRBBillNo", Billno);


            Mycon.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                PurchaseDtl Pd = new PurchaseDtl();

                Pd.PurBillNo = dr["PrRBBillNo"].ToString();
                Pd.DiscPer = Convert.ToDecimal(dr["PrRBDiscountPer"]);
                Pd.DiscRs = Convert.ToDecimal(dr["PrRBDiscountRs"]);
                Pd.Charges = Convert.ToDecimal(dr["PrRBCharges"]);

                Lst.Add(Pd);
            }

            Mycon.Close();

            return Lst;
        }
        public List<PurchaseDtl> GrandTotalFinalTotal_Report(string Billno)
        {
            List<PurchaseDtl> Lst = new List<PurchaseDtl>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("select p.PurBillNo, sum(p.PurGstRs) as GstTotal, pr.PrGrandTotal, pr.PrFinalTotal from PurchaseDtls as p join PurchaseForReports as pr on pr.PrBillNo = p.PurBillNo where p.PurBillNo = @PurBillNo group by p.PurBillNo, pr.PrGrandTotal, pr.PrFinalTotal", Mycon);

            cmd.Parameters.AddWithValue("@PurBillNo", Billno);


            Mycon.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                PurchaseDtl Pd = new PurchaseDtl();

                Pd.PurBillNo = dr["PurBillNo"].ToString();
                Pd.PurGstRs = Convert.ToDecimal(dr["GstTotal"]);
                Pd.GrandTot = Convert.ToDecimal(dr["PrGrandTotal"]);
                Pd.TotalAmt = Convert.ToDecimal(dr["PrFinalTotal"]);

                Lst.Add(Pd);
            }

            Mycon.Close();

            return Lst;
        }

        // <------------  End Purchase Report (Info , Products, Discount, Charges) ------------->



        // <------------ Transaction History ---------------->

        public List<CustSupTransaction> Payment_CustInfo(string Billno)
        {
            List<CustSupTransaction> Lst = new List<CustSupTransaction>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("select p.PurBillNo, cd.CustName, p.PurDate, pr.PrFinalTotal from  PurchaseDtls as p  left join CustSupTransactions as ct on ct.TranBillNo = p.PurBillNo  join CustomerDetails as cd on cd.CustID = p.PurSuppCustId join PurchaseForReports as pr on pr.PrBillNo = p.PurBillNo where p.PurBillNo = @PurBillNo group by p.PurBillNo, cd.CustName, p.PurDate, pr.PrFinalTotal", Mycon);
            cmd.Parameters.AddWithValue("@PurBillNo", Billno);
            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                CustSupTransaction cst = new CustSupTransaction();
                cst.TranBillNo = dr["PurBillNo"].ToString();
                cst.CustName = dr["CustName"].ToString();
                cst.BillAmt = Convert.ToDecimal(dr["PrFinalTotal"]);
                cst.PurDate = Convert.ToDateTime(dr["PurDate"]);

                Lst.Add(cst);
            }

            Mycon.Close();

            return Lst;
        }
        public List<CustSupTransaction> Payment_Transaction_Report(string Billno)
        {
            List<CustSupTransaction> Lst = new List<CustSupTransaction>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("select ct.TranId, ct.TranReciAmt, pm.PayMName, ct.ChequeNo, ct.TranNote, ct.TranDate, ct.TranBillNo from CustSupTransactions as ct join PaymentMethods as pm on pm.PayMId = ct.TranPayMethod where ct.TranBillNo = @TranBillNo", Mycon);
            cmd.Parameters.AddWithValue("@TranBillNo", Billno);
            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                CustSupTransaction cst = new CustSupTransaction();

                cst.TranId = Convert.ToInt32(dr["TranId"]);
                cst.TranReciAmt = Convert.ToDecimal(dr["TranReciAmt"]);
                cst.PayMethod = dr["PayMName"].ToString();
                cst.ChequeNo = dr["ChequeNo"].ToString();
                cst.TranNote = dr["TranNote"].ToString();
                cst.TranDate = Convert.ToDateTime(dr["TranDate"]);
                cst.TranBillNo = dr["TranBillNo"].ToString();

                Lst.Add(cst);
            }

            Mycon.Close();

            return Lst;
        }
        public List<CustSupTransaction> Payment_Outstanding_Report(string Billno)
        {
            List<CustSupTransaction> Lst = new List<CustSupTransaction>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("select ct.TranBillNo, sum(ct.TranReciAmt) as TranSum, pr.PrFinalTotal from CustSupTransactions as ct join PurchaseForReports as pr on pr.PrBillNo = ct.TranBillNo where ct.TranBillNo = @TranBillNo  group by ct.TranBillNo, pr.PrFinalTotal", Mycon);
            cmd.Parameters.AddWithValue("@TranBillNo", Billno);
            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                CustSupTransaction cst = new CustSupTransaction();

                cst.TranBillNo = dr["TranBillNo"].ToString();
                cst.TranReciAmt = Convert.ToDecimal(dr["TranSum"]);
                cst.BillAmt = Convert.ToDecimal(dr["PrFinalTotal"]);

                Lst.Add(cst);
            }

            Mycon.Close();

            return Lst;
        }


        public List<CustSupTransaction> Payment_CustInfo(DateTime? Fdate, DateTime? LDate, int? CustId)
        {
            List<CustSupTransaction> Lst = new List<CustSupTransaction>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand(" select p.PurBillNo, cd.CustName, p.PurDate, pr.PrFinalTotal from  PurchaseDtls as p  left join CustSupTransactions as ct on ct.TranBillNo = p.PurBillNo  join CustomerDetails as cd on cd.CustID = p.PurSuppCustId join PurchaseForReports as pr on pr.PrBillNo = p.PurBillNo where  p.PurSuppCustId = @PurSuppCustId and p.PurDate BETWEEN @Fdate AND @LDate group by p.PurBillNo, cd.CustName, p.PurDate, pr.PrFinalTotal", Mycon);
            cmd.Parameters.AddWithValue("@PurSuppCustId", CustId);
            cmd.Parameters.AddWithValue("@Fdate", Fdate);
            cmd.Parameters.AddWithValue("@LDate", LDate);

            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                CustSupTransaction cst = new CustSupTransaction();
                cst.TranBillNo = dr["PurBillNo"].ToString();
                cst.CustName = dr["CustName"].ToString();
                cst.BillAmt = Convert.ToDecimal(dr["PrFinalTotal"]);
                cst.PurDate = Convert.ToDateTime(dr["PurDate"]);

                Lst.Add(cst);
            }

            Mycon.Close();

            return Lst;
        }
        public List<CustSupTransaction> Payment_Transaction_Report(DateTime? Fdate, DateTime? LDate, int? CustId)
        {
            List<CustSupTransaction> Lst = new List<CustSupTransaction>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("select ct.TranId, ct.TranReciAmt, pm.PayMName, ct.ChequeNo, ct.TranNote, ct.TranDate, ct.TranBillNo, pd.PurBillNo from CustSupTransactions as ct join PaymentMethods as pm on pm.PayMId = ct.TranPayMethod join PurchaseDtls as pd on pd.PurBillNo = ct.TranBillNo where ct.CustSuppId = @CustSuppId and pd.PurDate BETWEEN @Fdate AND @LDate group by ct.TranId, ct.TranReciAmt, pm.PayMName, ct.ChequeNo, ct.TranNote, ct.TranDate, ct.TranBillNo, pd.PurBillNo", Mycon);
            cmd.Parameters.AddWithValue("@CustSuppId", CustId);
            cmd.Parameters.AddWithValue("@Fdate", Fdate);
            cmd.Parameters.AddWithValue("@LDate", LDate);

            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                CustSupTransaction cst = new CustSupTransaction();

                cst.TranId = Convert.ToInt32(dr["TranId"]);
                cst.TranReciAmt = Convert.ToDecimal(dr["TranReciAmt"]);
                cst.PayMethod = dr["PayMName"].ToString();
                cst.ChequeNo = dr["ChequeNo"].ToString();
                cst.TranNote = dr["TranNote"].ToString();
                cst.TranDate = Convert.ToDateTime(dr["TranDate"]);
                cst.TranBillNo = dr["TranBillNo"].ToString();

                Lst.Add(cst);
            }

            Mycon.Close();

            return Lst;
        }
        public List<CustSupTransaction> Payment_Outstanding_Report(int? CustId)
        {
            List<CustSupTransaction> Lst = new List<CustSupTransaction>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("select ct.TranBillNo, sum(ct.TranReciAmt) as TranSum, pr.PrFinalTotal from CustSupTransactions as ct join PurchaseForReports as pr on pr.PrBillNo = ct.TranBillNo  where CustSuppId = @CustSuppId  group by TranBillNo, pr.PrFinalTotal", Mycon);
            cmd.Parameters.AddWithValue("@CustSuppId", CustId);

            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                CustSupTransaction cst = new CustSupTransaction();

                cst.TranBillNo = dr["TranBillNo"].ToString();
                cst.TranReciAmt = Convert.ToDecimal(dr["TranSum"]);
                cst.BillAmt = Convert.ToDecimal(dr["PrFinalTotal"]);

                Lst.Add(cst);
            }

            Mycon.Close();

            return Lst;
        }


        public List<CustSupTransaction> Payment_CustInfo_TransactionDtl_Report(DateTime? Fdate, DateTime? Ldate)
        {
            List<CustSupTransaction> Lst = new List<CustSupTransaction>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("select ct.TranBillNo, cd.CustName,pr.PrFinalTotal, pd.PurDate from CustSupTransactions as ct join CustomerDetails as cd on cd.CustID = ct.CustSuppId join PurchaseForReports as pr on pr.PrBillNo = ct.TranBillNo join PurchaseDtls as pd on pd.PurBillNo = ct.TranBillNo where ct.TranDate between @FDate and @LDate group by  cd.CustName,pr.PrFinalTotal, ct.TranBillNo, pd.PurDate", Mycon);

            cmd.Parameters.AddWithValue("@FDate", Fdate);
            cmd.Parameters.AddWithValue("@LDate", Ldate);

            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                CustSupTransaction cst = new CustSupTransaction();
                cst.TranBillNo = dr["TranBillNo"].ToString();
                cst.CustName = dr["CustName"].ToString();
                cst.BillAmt = Convert.ToDecimal(dr["PrFinalTotal"]);
                cst.PurDate = Convert.ToDateTime(dr["PurDate"]);

                Lst.Add(cst);
            }

            Mycon.Close();
            return Lst;
        }
        public List<CustSupTransaction> Payment_TransactionDtl_Report(DateTime? Fdate, DateTime? Ldate)
        {
            List<CustSupTransaction> Lst = new List<CustSupTransaction>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("select ct.TranId, ct.TranReciAmt, pm.PayMName, ct.ChequeNo, ct.TranNote, ct.TranDate, ct.TranBillNo from CustSupTransactions as ct join PaymentMethods as pm on pm.PayMId = ct.TranPayMethod join PurchaseDtls as pd on pd.PurBillNo = ct.TranBillNo where ct.TranDate BETWEEN @Fdate AND @Ldate group by ct.TranId, ct.TranReciAmt, pm.PayMName, ct.ChequeNo, ct.TranNote, ct.TranDate, ct.TranBillNo", Mycon);
            cmd.Parameters.AddWithValue("@Fdate", Fdate);
            cmd.Parameters.AddWithValue("@Ldate", Ldate);

            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                CustSupTransaction cst = new CustSupTransaction();

                cst.TranId = Convert.ToInt32(dr["TranId"]);
                cst.TranReciAmt = Convert.ToDecimal(dr["TranReciAmt"]);
                cst.PayMethod = dr["PayMName"].ToString();
                cst.ChequeNo = dr["ChequeNo"].ToString();
                cst.TranNote = dr["TranNote"].ToString();
                cst.TranDate = Convert.ToDateTime(dr["TranDate"]);
                cst.TranBillNo = dr["TranBillNo"].ToString();

                Lst.Add(cst);
            }

            Mycon.Close();

            return Lst;
        }


        public List<CustSupTransaction> Payment_CustInfo_TransactionDtl_Report(DateTime? Fdate, DateTime? Ldate, int? CustId)
        {
            List<CustSupTransaction> Lst = new List<CustSupTransaction>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("select ct.TranBillNo, cd.CustName,pr.PrFinalTotal, pd.PurDate from CustSupTransactions as ct join CustomerDetails as cd on cd.CustID = ct.CustSuppId join PurchaseForReports as pr on pr.PrBillNo = ct.TranBillNo join PurchaseDtls as pd on pd.PurBillNo = ct.TranBillNo where pd.PurSuppCustId = @CustId and pd.PurDate between @FDate and @LDate group by  cd.CustName,pr.PrFinalTotal, ct.TranBillNo, pd.PurDate", Mycon);
            cmd.Parameters.AddWithValue("@CustId", CustId);
            cmd.Parameters.AddWithValue("@FDate", Fdate);
            cmd.Parameters.AddWithValue("@LDate", Ldate);

            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                CustSupTransaction cst = new CustSupTransaction();
                cst.TranBillNo = dr["TranBillNo"].ToString();
                cst.CustName = dr["CustName"].ToString();
                cst.BillAmt = Convert.ToDecimal(dr["PrFinalTotal"]);
                cst.PurDate = Convert.ToDateTime(dr["PurDate"]);

                Lst.Add(cst);
            }

            Mycon.Close();

            return Lst;
        }
        public List<CustSupTransaction> Payment_TransactionDtl_Report(DateTime? Fdate, DateTime? Ldate, int? CustId)
        {
            List<CustSupTransaction> Lst = new List<CustSupTransaction>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("select ct.TranId, ct.TranReciAmt, pm.PayMName, ct.ChequeNo, ct.TranNote, ct.TranDate, ct.TranBillNo from CustSupTransactions as ct join PaymentMethods as pm on pm.PayMId = ct.TranPayMethod join PurchaseDtls as pd on pd.PurBillNo = ct.TranBillNo where pd.PurSuppCustId = @CustId and pd.PurDate between @FDate and @LDate group by ct.TranId, ct.TranReciAmt, pm.PayMName, ct.ChequeNo, ct.TranNote, ct.TranDate, ct.TranBillNo", Mycon);
            cmd.Parameters.AddWithValue("@CustId", CustId);
            cmd.Parameters.AddWithValue("@FDate", Fdate);
            cmd.Parameters.AddWithValue("@LDate", Ldate);

            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                CustSupTransaction cst = new CustSupTransaction();

                cst.TranId = Convert.ToInt32(dr["TranId"]);
                cst.TranReciAmt = Convert.ToDecimal(dr["TranReciAmt"]);
                cst.PayMethod = dr["PayMName"].ToString();
                cst.ChequeNo = dr["ChequeNo"].ToString();
                cst.TranNote = dr["TranNote"].ToString();
                cst.TranDate = Convert.ToDateTime(dr["TranDate"]);
                cst.TranBillNo = dr["TranBillNo"].ToString();

                Lst.Add(cst);
            }

            Mycon.Close();

            return Lst;
        }


        public List<CustSupTransaction> Payment_CustInfo_TransactionDtl_Report(string BillNo)
        {
            List<CustSupTransaction> Lst = new List<CustSupTransaction>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("select ct.TranBillNo, cd.CustName,pr.PrFinalTotal, pd.PurDate from CustSupTransactions as ct join CustomerDetails as cd on cd.CustID = ct.CustSuppId join PurchaseForReports as pr on pr.PrBillNo = ct.TranBillNo join PurchaseDtls as pd on pd.PurBillNo = ct.TranBillNo where pd.PurBillNo = @PurBillNo group by  cd.CustName,pr.PrFinalTotal, ct.TranBillNo, pd.PurDate", Mycon);
            cmd.Parameters.AddWithValue("@PurBillNo", BillNo);

            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                CustSupTransaction cst = new CustSupTransaction();
                cst.TranBillNo = dr["TranBillNo"].ToString();
                cst.CustName = dr["CustName"].ToString();
                cst.BillAmt = Convert.ToDecimal(dr["PrFinalTotal"]);
                cst.PurDate = Convert.ToDateTime(dr["PurDate"]);

                Lst.Add(cst);
            }

            Mycon.Close();

            return Lst;
        }
        public List<CustSupTransaction> Payment_TransactionDtl_Report(string BillNo)
        {
            List<CustSupTransaction> Lst = new List<CustSupTransaction>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("select ct.TranId, ct.TranReciAmt, pm.PayMName, ct.ChequeNo, ct.TranNote, ct.TranDate, ct.TranBillNo from CustSupTransactions as ct join PaymentMethods as pm on pm.PayMId = ct.TranPayMethod join PurchaseDtls as pd on pd.PurBillNo = ct.TranBillNo where pd.PurBillNo = @PurBillNo group by ct.TranId, ct.TranReciAmt, pm.PayMName, ct.ChequeNo, ct.TranNote, ct.TranDate, ct.TranBillNo", Mycon);
            cmd.Parameters.AddWithValue("@PurBillNo", BillNo);

            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                CustSupTransaction cst = new CustSupTransaction();

                cst.TranId = Convert.ToInt32(dr["TranId"]);
                cst.TranReciAmt = Convert.ToDecimal(dr["TranReciAmt"]);
                cst.PayMethod = dr["PayMName"].ToString();
                cst.ChequeNo = dr["ChequeNo"].ToString();
                cst.TranNote = dr["TranNote"].ToString();
                cst.TranDate = Convert.ToDateTime(dr["TranDate"]);
                cst.TranBillNo = dr["TranBillNo"].ToString();

                Lst.Add(cst);
            }

            Mycon.Close();

            return Lst;
        }






        // <------------ End Transaction History ------------>








        // @@@@@@@@@@ End  FDate LDate CustName @@@@@@@@@@@@@








        public List<PurchaseDtl> Purchase_NameBillDate_Report(DateTime? Fdate, DateTime? LDate, int? CustId)
        {
            List<PurchaseDtl> lst = new List<PurchaseDtl>();

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select p.PurBillNo, C.CustName, p.PurDate from PurchaseDtls as p join CustomerDetails as c on c.CustID = p.PurSuppCustId where p.PurSuppCustId = @CustId and p.PurDate BETWEEN @FDate AND @LDate group by  p.PurBillNo, C.CustName, p.PurDate", Mycon);

            cmd.Parameters.AddWithValue("@CustId", CustId);
            cmd.Parameters.AddWithValue("@FDate", Fdate);
            cmd.Parameters.AddWithValue("@LDate", LDate);


            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                PurchaseDtl Pd = new PurchaseDtl();

                Pd.PurBillNo = dr["PurBillNo"].ToString();
                Pd.SplrCustName = dr["CustName"].ToString();
                Pd.PurDate = Convert.ToDateTime(dr["PurDate"]);

                //  Pd.PrchsDtlFinalPurchaseAmt = Convert.ToDecimal(dr["PrFinalTotal"]);

                lst.Add(Pd);
            }

            Mycon.Close();

            return lst;
        }

        public List<PurchaseDtl> Purchase_NameBillDate_Report(string BillNo)
        {
            List<PurchaseDtl> lst = new List<PurchaseDtl>();

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select p.PurBillNo, C.CustName, p.PurDate from PurchaseDtls as p join CustomerDetails as c on c.CustID = p.PurSuppCustId where p.PurBillNo = @PurBillNo group by  p.PurBillNo, C.CustName, p.PurDate", Mycon);

            //   cmd.Parameters.AddWithValue("@PurBillNo", CustId);



            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                PurchaseDtl Pd = new PurchaseDtl();

                Pd.PurBillNo = dr["PurBillNo"].ToString();
                Pd.SplrCustName = dr["CustName"].ToString();
                Pd.PurDate = Convert.ToDateTime(dr["PurDate"]);

                //  Pd.PrchsDtlFinalPurchaseAmt = Convert.ToDecimal(dr["PrFinalTotal"]);

                lst.Add(Pd);
            }

            Mycon.Close();

            return lst;
        }

        public List<PurchaseDtl> Purchase_Product_Report(DateTime? Fdate, DateTime? LDate, int? CustId)
        {
            List<PurchaseDtl> lst = new List<PurchaseDtl>();

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select p.PurBillNo, cd.CustName , sum(p.PurProductRate) as ProductRateSum, sum(p.PurQuantity) as QuantitySum, sum(pgst.ProdGst) as GstSum, sum(p.PurDiscount) as DiscountSum, sum(p.PurGstRs) as GstRsSum, sum(p.PurTotal) as TotalSum  from PurchaseDtls as p join ProductDetails as pd on p.PurSuppCustId = pd.PDID join ProductGSTs as pgst on pgst.ProdGstID = pd.GstPercent join CustomerDetails as cd on cd.CustID = p.PurSuppCustId where p.PurSuppCustId = @CustId and p.PurDate BETWEEN @FDate AND @LDate  group by  p.PurBillNo, cd.CustName", Mycon);

            cmd.Parameters.AddWithValue("@CustId", CustId);
            cmd.Parameters.AddWithValue("@FDate", Fdate);
            cmd.Parameters.AddWithValue("@LDate", LDate);


            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                PurchaseDtl Pd = new PurchaseDtl();

                //   PurBillNo,  ProductRateSum, QuantitySum,  GstSum, DiscountSum, GstRsSum, TotalSum

                Pd.PurBillNo = dr["PurBillNo"].ToString();
                Pd.SplrCustName = dr["CustName"].ToString();
                Pd.ProductRate = Convert.ToDecimal(dr["ProductRateSum"]);
                Pd.PurQuantity = Convert.ToInt32(dr["QuantitySum"]);
                Pd.ProductGst = Convert.ToDecimal(dr["GstSum"]);
                Pd.PurDiscount = Convert.ToDecimal(dr["DiscountSum"]);
                Pd.PurGstRs = Convert.ToDecimal(dr["GstRsSum"]);
                Pd.PurTotal = Convert.ToDecimal(dr["TotalSum"]);

                //  Pd.PrchsDtlFinalPurchaseAmt = Convert.ToDecimal(dr["PrFinalTotal"]);

                lst.Add(Pd);
            }

            Mycon.Close();

            return lst;
        }





        public object AllFinalTotalAmt()
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            string RegInsrt = "select sum(PrFinalTotal) as FinalTotal from PurchaseForReports";
            SqlCommand cmd = new SqlCommand(RegInsrt, Mycon);
            Mycon.Open();
            object counts = cmd.ExecuteScalar();
            Mycon.Close();
            return counts;
        } // method close

        public object TotalTransactionAmt()
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            string RegInsrt = "select sum(TranReciAmt) as ReceivedAmt from CustSupTransactions";
            SqlCommand cmd = new SqlCommand(RegInsrt, Mycon);
            Mycon.Open();
            object counts = cmd.ExecuteScalar();
            Mycon.Close();
            return counts;
        } // method close

        public List<PurchaseDtl> GST_Bifercation_Report(DateTime? Fdate, DateTime? LDate, int? CustId)
        {
            List<PurchaseDtl> lst = new List<PurchaseDtl>();

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select  sum(p.PurTotal) as purTotalSum, sum(p.PurGstRs) as purGstRsSum, ProdGst from PurchaseDtls as p  join ProductDetails as pd on pd.PDID = p.PurProductID  join ProductGSTs as pg on pg.ProdGstID = pd.GstPercent where p.PurSuppCustId = @CustId and p.PurDate between @FDate and @LDate group by pg.ProdGst", Mycon);

            cmd.Parameters.AddWithValue("@CustId", CustId);
            cmd.Parameters.AddWithValue("@FDate", Fdate);
            cmd.Parameters.AddWithValue("@LDate", LDate);


            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                PurchaseDtl Pd = new PurchaseDtl();

                Pd.PurTotal = Convert.ToDecimal(dr["purTotalSum"]);
                Pd.PurGstRs = Convert.ToDecimal(dr["purGstRsSum"]);
                Pd.ProductGst = Convert.ToDecimal(dr["ProdGst"]);

                lst.Add(Pd);
            }

            Mycon.Close();

            return lst;
        }

        public List<PurchaseDtl> GST_Bifercation_Report(DateTime? Fdate, DateTime? LDate)
        {
            List<PurchaseDtl> lst = new List<PurchaseDtl>();

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select  sum(p.PurTotal) as purTotalSum, sum(p.PurGstRs) as purGstRsSum, ProdGst from PurchaseDtls as p  join ProductDetails as pd on pd.PDID = p.PurProductID  join ProductGSTs as pg on pg.ProdGstID = pd.GstPercent where p.PurDate between @FDate and @LDate group by pg.ProdGst", Mycon);

            cmd.Parameters.AddWithValue("@FDate", Fdate);
            cmd.Parameters.AddWithValue("@LDate", LDate);

            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                PurchaseDtl Pd = new PurchaseDtl();

                Pd.PurTotal = Convert.ToDecimal(dr["purTotalSum"]);
                Pd.PurGstRs = Convert.ToDecimal(dr["purGstRsSum"]);
                Pd.ProductGst = Convert.ToDecimal(dr["ProdGst"]);

                lst.Add(Pd);
            }

            Mycon.Close();

            return lst;
        }






        public List<SalesBillWithoutGstDtl> List_BillNosSaleBilWiGst(DateTime? Fdate, DateTime? Ldate)
        {
            List<SalesBillWithoutGstDtl> lst = new List<SalesBillWithoutGstDtl>();

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select SalBilWiGSTBillNo from SalesBillWithoutGstDtls where SalBilWiGSTDate between @Fdate and @Ldate group by SalBilWiGSTBillNo", Mycon);
            cmd.Parameters.AddWithValue("@Fdate", Fdate);
            cmd.Parameters.AddWithValue("@Ldate", Ldate);

            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                SalesBillWithoutGstDtl SaleBiWiGst = new SalesBillWithoutGstDtl();

                SaleBiWiGst.SalBilWiGSTBillNo = dr["SalBilWiGSTBillNo"].ToString();


                lst.Add(SaleBiWiGst);
            }

            Mycon.Close();

            return lst;
        }



        public List<SalesBillWithoutGstDtl> List_BillNosSaleBilWiGst(DateTime? Fdate, DateTime? Ldate, string BillNo, int? CustId)
        {
            List<SalesBillWithoutGstDtl> lst = new List<SalesBillWithoutGstDtl>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            string Query = "";

            if (Fdate != null && Ldate != null && CustId != null && BillNo == "")
            {
                Query = "select SalBilWiGSTBillNo from SalesBillWithoutGstDtls where SalBilWiGSTSuppCustId = @SalBilWiGSTSuppCustId and SalBilWiGSTDate between @Fdate and @Ldate group by SalBilWiGSTBillNo";
            }

            if (BillNo != "" && Fdate == null && Ldate == null && CustId == null)
            {
                Query = "select SalBilWiGSTBillNo from SalesBillWithoutGstDtls where SalBilWiGSTBillNo = @BillNo  group by SalBilWiGSTBillNo";
            }



            SqlCommand cmd = new SqlCommand(Query, Mycon);

            if (Fdate != null && Ldate != null && CustId != null && BillNo == "")
            {
                cmd.Parameters.AddWithValue("@SalBilWiGSTSuppCustId", CustId);
                cmd.Parameters.AddWithValue("@Fdate", Fdate);
                cmd.Parameters.AddWithValue("@Ldate", Ldate);
            }
            if (BillNo != "" && Fdate == null && Ldate == null && CustId == null)
            {
                cmd.Parameters.AddWithValue("@BillNo", BillNo);
            }
            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                SalesBillWithoutGstDtl SaleBiWiGst = new SalesBillWithoutGstDtl();

                SaleBiWiGst.SalBilWiGSTBillNo = dr["SalBilWiGSTBillNo"].ToString();


                lst.Add(SaleBiWiGst);
            }

            Mycon.Close();

            return lst;
        }



        public List<SalesBillWithoutGstDtl> List_BillNosSaleBilWiGst(DateTime? Fdate, DateTime? Ldate, int? CustId, int? PayStId)
        {
            List<SalesBillWithoutGstDtl> lst = new List<SalesBillWithoutGstDtl>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            string Query = "";

            if (Fdate != null && Ldate != null && CustId != null && PayStId != null)
            {
                Query = "select sd.SalBilWiGSTBillNo from SalesBillWithoutGstDtls as sd join SalesBillWithoutGstDtl_ChargesDisc as cd on cd.SalBiWiGst_BillNo = sd.SalBilWiGSTBillNo  where sd.SalBilWiGSTSuppCustId = @SalBilWiGSTSuppCustId and sd.SalBilWiGSTDate between @Fdate and @Ldate and cd.SalBiWiGst_Status = @PayStId  group by sd.SalBilWiGSTBillNo, cd.SalBiWiGst_Status";
            }

            if (Fdate != null && Ldate != null && CustId == null && PayStId != null)
            {
                Query = "select sd.SalBilWiGSTBillNo from SalesBillWithoutGstDtls as sd join SalesBillWithoutGstDtl_ChargesDisc as cd on cd.SalBiWiGst_BillNo = sd.SalBilWiGSTBillNo  where  sd.SalBilWiGSTDate between @Fdate and @Ldate and cd.SalBiWiGst_Status = @PayStId  group by sd.SalBilWiGSTBillNo, cd.SalBiWiGst_Status";
            }


            SqlCommand cmd = new SqlCommand(Query, Mycon);

            if (Fdate != null && Ldate != null && CustId != null && PayStId != null)
            {
                cmd.Parameters.AddWithValue("@SalBilWiGSTSuppCustId", CustId);
                cmd.Parameters.AddWithValue("@Fdate", Fdate);
                cmd.Parameters.AddWithValue("@Ldate", Ldate);
                cmd.Parameters.AddWithValue("@PayStId", PayStId);
            }
            if (Fdate != null && Ldate != null && CustId == null && PayStId != null)
            {
                cmd.Parameters.AddWithValue("@Fdate", Fdate);
                cmd.Parameters.AddWithValue("@Ldate", Ldate);
                cmd.Parameters.AddWithValue("@PayStId", PayStId);
            }


            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                SalesBillWithoutGstDtl SaleBiWiGst = new SalesBillWithoutGstDtl();

                SaleBiWiGst.SalBilWiGSTBillNo = dr["SalBilWiGSTBillNo"].ToString();


                lst.Add(SaleBiWiGst);
            }

            Mycon.Close();

            return lst;
        }





        public List<SalesBillWithoutGstDtl> TotalAmt_BillNosSaleBilWiGst(DateTime? Fdate, DateTime? Ldate, int? CustId)
        {
            List<SalesBillWithoutGstDtl> lst = new List<SalesBillWithoutGstDtl>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            string Query = "";

            if (Fdate != null && Ldate != null && CustId != null)
            {
                Query = "select sd.SalBilWiGSTBillNo, sr.SalBiWiGst_Rpt_FinalTotal from SalesBillWithoutGstDtls as sd join  SalesBillWithoutGstDtl_Report  as sr on sd.SalBilWiGSTBillNo = sr.SalBiWiGst_Rpt_BillNo where sd.SalBilWiGSTSuppCustId = @SalBilWiGSTSuppCustId and sd.SalBilWiGSTDate between @Fdate and @Ldate  group by sd.SalBilWiGSTBillNo, sr.SalBiWiGst_Rpt_FinalTotal";
            }

            if (Fdate != null && Ldate != null && CustId == null)
            {
                Query = "select sd.SalBilWiGSTBillNo, sr.SalBiWiGst_Rpt_FinalTotal from SalesBillWithoutGstDtls as sd join  SalesBillWithoutGstDtl_Report  as sr on sd.SalBilWiGSTBillNo = sr.SalBiWiGst_Rpt_BillNo where sd.SalBilWiGSTDate between @Fdate and @Ldate  group by sd.SalBilWiGSTBillNo, sr.SalBiWiGst_Rpt_FinalTotal";
            }


            SqlCommand cmd = new SqlCommand(Query, Mycon);

            if (Fdate != null && Ldate != null && CustId != null)
            {
                cmd.Parameters.AddWithValue("@SalBilWiGSTSuppCustId", CustId);
                cmd.Parameters.AddWithValue("@Fdate", Fdate);
                cmd.Parameters.AddWithValue("@Ldate", Ldate);

            }
            if (Fdate != null && Ldate != null && CustId == null)
            {
                cmd.Parameters.AddWithValue("@Fdate", Fdate);
                cmd.Parameters.AddWithValue("@Ldate", Ldate);

            }


            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                SalesBillWithoutGstDtl SaleBiWiGst = new SalesBillWithoutGstDtl();

                SaleBiWiGst.SalBilWiGSTBillNo = dr["SalBilWiGSTBillNo"].ToString();
                SaleBiWiGst.SalBilWiGSTTotal = Convert.ToDecimal(dr["SalBiWiGst_Rpt_FinalTotal"]);

                lst.Add(SaleBiWiGst);
            }

            Mycon.Close();

            return lst;
        }








        //  <---------------- @@@  Sale report With Gst @@@ ------------>

        public List<SalesGST> List_BillNosSaleBilGst(DateTime? Fdate, DateTime? Ldate)
        {
            List<SalesGST> lst = new List<SalesGST>();

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("select SaleGST_BillNo, SaleGST_Date from SalesGSTs where SaleGST_Date between @Fdate and @Ldate group by SaleGST_BillNo, SaleGST_Date", Mycon);
            cmd.Parameters.AddWithValue("@Fdate", Fdate);
            cmd.Parameters.AddWithValue("@Ldate", Ldate);
            Mycon.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                SalesGST SaleBiGst = new SalesGST();
                SaleBiGst.SaleGST_BillNo = dr["SaleGST_BillNo"].ToString();
                lst.Add(SaleBiGst);
            }
            Mycon.Close();

            return lst;
        }



        public List<SalesGST> List_BillNosSaleBilGst(DateTime? Fdate, DateTime? Ldate, string BillNo, int? CustId)
        {
            List<SalesGST> lst = new List<SalesGST>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            string Query = "";

            if (Fdate != null && Ldate != null && CustId != null && BillNo == "")
            {
                Query = "select SaleGST_BillNo, SaleGST_Date from SalesGSTs where SaleGST_Date between @Fdate and @Ldate and SaleGST_SuppCustId = @SaleGST_SuppCustId group by SaleGST_BillNo, SaleGST_Date";
            }

            if (BillNo != "" && Fdate == null && Ldate == null && CustId == null)
            {
                Query = "select SaleGST_BillNo, SaleGST_Date from SalesGSTs where SaleGST_BillNo = @SaleGST_BillNo  group by SaleGST_BillNo, SaleGST_Date";
            }



            SqlCommand cmd = new SqlCommand(Query, Mycon);

            if (Fdate != null && Ldate != null && CustId != null && BillNo == "")
            {
                cmd.Parameters.AddWithValue("@SaleGST_SuppCustId", CustId);
                cmd.Parameters.AddWithValue("@Fdate", Fdate);
                cmd.Parameters.AddWithValue("@Ldate", Ldate);
            }
            if (BillNo != "" && Fdate == null && Ldate == null && CustId == null)
            {
                cmd.Parameters.AddWithValue("@SaleGST_BillNo", BillNo);
            }
            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                SalesGST SaleBiGst = new SalesGST();

                SaleBiGst.SaleGST_BillNo = dr["SaleGST_BillNo"].ToString();


                lst.Add(SaleBiGst);
            }

            Mycon.Close();

            return lst;
        }

        public List<SalesGST> TotalAmt_BillNosSaleBilGst(DateTime? Fdate, DateTime? Ldate)
        {
            List<SalesGST> lst = new List<SalesGST>();

            SqlConnection Mycon = new SqlConnection(Cnstr);



            string Query = "select sd.SaleGST_BillNo, sr.SalesGST_Rpt_FinalTotal from SalesGSTs as sd join  SalesGST_Report  as sr on sd.SaleGST_BillNo = sr.SalesGST_Rpt_BillNo where  sd.SaleGST_Date between @Fdate and @Ldate  group by sd.SaleGST_BillNo, sr.SalesGST_Rpt_FinalTotal";


            SqlCommand cmd = new SqlCommand(Query, Mycon);

            cmd.Parameters.AddWithValue("@Fdate", Fdate);
            cmd.Parameters.AddWithValue("@Ldate", Ldate);

            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                SalesGST SaleBiGst = new SalesGST();

                SaleBiGst.SaleGST_BillNo = dr["SaleGST_BillNo"].ToString();
                SaleBiGst.SaleGST_Total = Convert.ToDecimal(dr["SalesGST_Rpt_FinalTotal"]);

                lst.Add(SaleBiGst);
            }

            Mycon.Close();

            return lst;
        }

        public List<SalesGST_Transactions> AllInOne_Transaction_WtGST_Report(DateTime? Fdate, DateTime? LDate, int? CustId)
        {
            List<SalesGST_Transactions> Lst = new List<SalesGST_Transactions>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            string SqlQuery = "";

            if (Fdate != null && LDate != null && CustId != null)
            {
                SqlQuery = "select St.SGstTran_TranID, St.SGstTran_TranReciAmt, pm.PayMName, St.SGstTran_Cheque, St.SGstTran_TransactionNote, St.SGstTran_Date, St.SGstTran_BillNo, Sg.SaleGST_BillNo from SalesGST_Transactions as St join PaymentMethods as pm on pm.PayMId = St.SGstTran_TranPayMethod join SalesGSTs as Sg on Sg.SaleGST_BillNo = St.SGstTran_BillNo where St.SGstTran_CustSupID = @CustSuppId and Sg.SaleGST_Date BETWEEN @Fdate AND @LDate group by St.SGstTran_TranID, St.SGstTran_TranReciAmt, pm.PayMName, St.SGstTran_Cheque, St.SGstTran_TransactionNote, St.SGstTran_Date, St.SGstTran_BillNo, Sg.SaleGST_BillNo";
            }


            if (Fdate != null && LDate != null && CustId == null)
            {
                SqlQuery = "select St.SGstTran_TranID, St.SGstTran_TranReciAmt, pm.PayMName, St.SGstTran_Cheque, St.SGstTran_TransactionNote, St.SGstTran_Date, St.SGstTran_BillNo, Sg.SaleGST_BillNo from SalesGST_Transactions as St join PaymentMethods as pm on pm.PayMId = St.SGstTran_TranPayMethod join SalesGSTs as Sg on Sg.SaleGST_BillNo = St.SGstTran_BillNo where Sg.SaleGST_Date BETWEEN @Fdate AND @LDate group by St.SGstTran_TranID, St.SGstTran_TranReciAmt, pm.PayMName, St.SGstTran_Cheque, St.SGstTran_TransactionNote, St.SGstTran_Date, St.SGstTran_BillNo, Sg.SaleGST_BillNo";
            }


            SqlCommand cmd = new SqlCommand(SqlQuery, Mycon);

            if (Fdate != null && LDate != null && CustId == null)
            {
                cmd.Parameters.AddWithValue("@Fdate", Fdate);
                cmd.Parameters.AddWithValue("@LDate", LDate);
            }

            if (Fdate != null && LDate != null && CustId != null)
            {
                cmd.Parameters.AddWithValue("@CustSuppId", CustId);
                cmd.Parameters.AddWithValue("@Fdate", Fdate);
                cmd.Parameters.AddWithValue("@LDate", LDate);
            }

            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                SalesGST_Transactions cst = new SalesGST_Transactions();

                cst.SGstTran_TranID = Convert.ToInt32(dr["SGstTran_TranID"]);
                cst.SGstTran_TranReciAmt = Convert.ToDecimal(dr["SGstTran_TranReciAmt"]);
                cst.SGstTran_PayMethName = dr["PayMName"].ToString();
                cst.SGstTran_Cheque = dr["SGstTran_Cheque"].ToString();
                cst.SGstTran_TransactionNote = dr["SGstTran_TransactionNote"].ToString();
                cst.SGstTran_Date = Convert.ToDateTime(dr["SGstTran_Date"]);
                cst.SGstTran_BillNo = dr["SGstTran_BillNo"].ToString();

                Lst.Add(cst);
            }

            Mycon.Close();

            return Lst;
        }

        public List<SalesGST_Transactions> AllInOne_Transaction_WtGST_Report(string BillNo)
        {
            List<SalesGST_Transactions> Lst = new List<SalesGST_Transactions>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            string SqlQuery = "select St.SGstTran_TranID, St.SGstTran_TranReciAmt, pm.PayMName, St.SGstTran_Cheque, St.SGstTran_TransactionNote, St.SGstTran_Date, St.SGstTran_BillNo, Sg.SaleGST_BillNo from SalesGST_Transactions as St join PaymentMethods as pm on pm.PayMId = St.SGstTran_TranPayMethod join SalesGSTs as Sg on Sg.SaleGST_BillNo = St.SGstTran_BillNo where St.SGstTran_BillNo = @BillNo group by St.SGstTran_TranID, St.SGstTran_TranReciAmt, pm.PayMName, St.SGstTran_Cheque, St.SGstTran_TransactionNote, St.SGstTran_Date, St.SGstTran_BillNo, Sg.SaleGST_BillNo";

            SqlCommand cmd = new SqlCommand(SqlQuery, Mycon);

            cmd.Parameters.AddWithValue("@BillNo", BillNo);


            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                SalesGST_Transactions cst = new SalesGST_Transactions();

                cst.SGstTran_TranID = Convert.ToInt32(dr["SGstTran_TranID"]);
                cst.SGstTran_TranReciAmt = Convert.ToDecimal(dr["SGstTran_TranReciAmt"]);
                cst.SGstTran_PayMethName = dr["PayMName"].ToString();
                cst.SGstTran_Cheque = dr["SGstTran_Cheque"].ToString();
                cst.SGstTran_TransactionNote = dr["SGstTran_TransactionNote"].ToString();
                cst.SGstTran_Date = Convert.ToDateTime(dr["SGstTran_Date"]);
                cst.SGstTran_BillNo = dr["SGstTran_BillNo"].ToString();

                Lst.Add(cst);
            }

            Mycon.Close();

            return Lst;
        }

        public List<SalesGST> List_BillNosSaleBilGst(DateTime? Fdate, DateTime? Ldate, int? CustId, string BillNo)
        {
            List<SalesGST> lst = new List<SalesGST>();
            SqlConnection Mycon = new SqlConnection(Cnstr);

            string Query = "";

            if (Fdate != null && Ldate != null && CustId != null && BillNo == "")
            {
                Query = "select SaleGST_BillNo, SaleGST_Date from SalesGSTs where SaleGST_Date between @Fdate and @Ldate and SaleGST_SuppCustId = @SaleGST_SuppCustId group by SaleGST_BillNo, SaleGST_Date";
            }

            if (Fdate != null && Ldate != null && CustId == null && BillNo == "")
            {
                Query = "select SaleGST_BillNo, SaleGST_Date from SalesGSTs where SaleGST_Date between @Fdate and @Ldate group by SaleGST_BillNo, SaleGST_Date";
            }

            if (Fdate == null && Ldate == null && CustId == null && BillNo != "")
            {
                Query = "select SaleGST_BillNo, SaleGST_Date from SalesGSTs where SaleGST_BillNo = @SaleGST_BillNo group by SaleGST_BillNo, SaleGST_Date";
            }

            SqlCommand cmd = new SqlCommand(Query, Mycon);

            if (Fdate != null && Ldate != null && CustId != null && BillNo == "")
            {
                cmd.Parameters.AddWithValue("@SaleGST_SuppCustId", CustId);
                cmd.Parameters.AddWithValue("@Fdate", Fdate);
                cmd.Parameters.AddWithValue("@Ldate", Ldate);
            }
            if (Fdate != null && Ldate != null && CustId == null && BillNo == "")
            {
                cmd.Parameters.AddWithValue("@Fdate", Fdate);
                cmd.Parameters.AddWithValue("@Ldate", Ldate);
            }
            if (Fdate == null && Ldate == null && CustId == null && BillNo != "")
            {
                cmd.Parameters.AddWithValue("@SaleGST_BillNo", BillNo);
            }



            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                SalesGST SaleBiGst = new SalesGST();
                SaleBiGst.SaleGST_BillNo = dr["SaleGST_BillNo"].ToString();
                lst.Add(SaleBiGst);
            }

            Mycon.Close();

            return lst;
        }





        public List<SalesGST_Transactions> Payment_CustInfo_TransactionDtl_SalesGst_Report(DateTime? Fdate, DateTime? Ldate, int? CustId)
        {
            List<SalesGST_Transactions> Lst = new List<SalesGST_Transactions>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            string SqlQuery = "";

            if (Fdate != null && Ldate != null && CustId != null)
            {
                SqlQuery = "select ct.SGstTran_BillNo, cd.CustName,pr.SalesGST_Rpt_FinalTotal, pd.SaleGST_Date from SalesGST_Transactions as ct join CustomerDetails as cd on cd.CustID = ct.SGstTran_CustSupID join SalesGST_Report as pr on pr.SalesGST_Rpt_BillNo = ct.SGstTran_BillNo join SalesGSTs as pd on pd.SaleGST_BillNo = ct.SGstTran_BillNo where pd.SaleGST_SuppCustId = @CustId and pd.SaleGST_Date between @FDate and @LDate group by  cd.CustName,pr.SalesGST_Rpt_FinalTotal, ct.SGstTran_BillNo, pd.SaleGST_Date";

            }
            if (Fdate != null && Ldate != null && CustId == null)
            {
                SqlQuery = "select ct.SGstTran_BillNo, cd.CustName,pr.SalesGST_Rpt_FinalTotal, pd.SaleGST_Date from SalesGST_Transactions as ct join CustomerDetails as cd on cd.CustID = ct.SGstTran_CustSupID join SalesGST_Report as pr on pr.SalesGST_Rpt_BillNo = ct.SGstTran_BillNo join SalesGSTs as pd on pd.SaleGST_BillNo = ct.SGstTran_BillNo where  pd.SaleGST_Date between @FDate and @LDate group by  cd.CustName,pr.SalesGST_Rpt_FinalTotal, ct.SGstTran_BillNo, pd.SaleGST_Date";

            }




            SqlCommand cmd = new SqlCommand(SqlQuery, Mycon);

            if (Fdate != null && Ldate != null && CustId != null)
            {

                cmd.Parameters.AddWithValue("@CustId", CustId);
                cmd.Parameters.AddWithValue("@FDate", Fdate);
                cmd.Parameters.AddWithValue("@LDate", Ldate);

            }

            if (Fdate != null && Ldate != null && CustId == null)
            {
                cmd.Parameters.AddWithValue("@FDate", Fdate);
                cmd.Parameters.AddWithValue("@LDate", Ldate);
            }



            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                SalesGST_Transactions cst = new SalesGST_Transactions();

                cst.SGstTran_BillNo = dr["SGstTran_BillNo"].ToString();
                cst.CustName = dr["CustName"].ToString();
                cst.SalesGST_Rpt_FinalTotal = Convert.ToDecimal(dr["SalesGST_Rpt_FinalTotal"]);
                cst.SaleGST_Date = Convert.ToDateTime(dr["SaleGST_Date"]);

                Lst.Add(cst);
            }

            Mycon.Close();

            return Lst;
        }


        public List<SalesGST_Transactions> Payment_TransactionDtl_SaleGst_Report(DateTime? Fdate, DateTime? Ldate, int? CustId)
        {
            List<SalesGST_Transactions> Lst = new List<SalesGST_Transactions>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            string SqlQuery = "";

            if (Fdate != null && Ldate != null && CustId != null)
            {
                SqlQuery = "select ct.SGstTran_TranID, ct.SGstTran_TranReciAmt, pm.PayMName, ct.SGstTran_Cheque, ct.SGstTran_TransactionNote, ct.SGstTran_Date, ct.SGstTran_BillNo from SalesGST_Transactions as ct join PaymentMethods as pm on pm.PayMId = ct.SGstTran_TranPayMethod join SalesGSTs as pd on pd.SaleGST_BillNo = ct.SGstTran_BillNo where pd.SaleGST_SuppCustId = @CustId and pd.SaleGST_Date between @FDate and @LDate group by ct.SGstTran_TranID, ct.SGstTran_TranReciAmt, pm.PayMName, ct.SGstTran_Cheque, ct.SGstTran_TransactionNote, ct.SGstTran_Date, ct.SGstTran_BillNo";
            }
            if (Fdate != null && Ldate != null && CustId == null)
            {
                SqlQuery = "select ct.SGstTran_TranID, ct.SGstTran_TranReciAmt, pm.PayMName, ct.SGstTran_Cheque, ct.SGstTran_TransactionNote, ct.SGstTran_Date, ct.SGstTran_BillNo from SalesGST_Transactions as ct join PaymentMethods as pm on pm.PayMId = ct.SGstTran_TranPayMethod join SalesGSTs as pd on pd.SaleGST_BillNo = ct.SGstTran_BillNo where  pd.SaleGST_Date between @FDate and @LDate group by ct.SGstTran_TranID, ct.SGstTran_TranReciAmt, pm.PayMName, ct.SGstTran_Cheque, ct.SGstTran_TransactionNote, ct.SGstTran_Date, ct.SGstTran_BillNo";
            }

            SqlCommand cmd = new SqlCommand(SqlQuery, Mycon);


            if (Fdate != null && Ldate != null && CustId != null)
            {
                cmd.Parameters.AddWithValue("@CustId", CustId);
                cmd.Parameters.AddWithValue("@FDate", Fdate);
                cmd.Parameters.AddWithValue("@LDate", Ldate);
            }

            if (Fdate != null && Ldate != null && CustId == null)
            {
                cmd.Parameters.AddWithValue("@FDate", Fdate);
                cmd.Parameters.AddWithValue("@LDate", Ldate);
            }


            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                SalesGST_Transactions cst = new SalesGST_Transactions();

                cst.SGstTran_TranID = Convert.ToInt32(dr["SGstTran_TranID"]);
                cst.SGstTran_TranReciAmt = Convert.ToDecimal(dr["SGstTran_TranReciAmt"]);
                cst.SGstTran_PayMethName = dr["PayMName"].ToString();
                cst.SGstTran_Cheque = dr["SGstTran_Cheque"].ToString();
                cst.SGstTran_TransactionNote = dr["SGstTran_TransactionNote"].ToString();
                cst.SGstTran_Date = Convert.ToDateTime(dr["SGstTran_Date"]);
                cst.SGstTran_BillNo = dr["SGstTran_BillNo"].ToString();

                Lst.Add(cst);
            }

            Mycon.Close();

            return Lst;
        }






        //public List<PurchaseDtl> GST_Bifercation_Sale_Report(DateTime? Fdate, DateTime? LDate, int? CustId)
        //{
        //    List<PurchaseDtl> lst = new List<PurchaseDtl>();

        //    SqlConnection Mycon = new SqlConnection(Cnstr);
        //    SqlCommand cmd = new SqlCommand("select  sum(p.PurTotal) as purTotalSum, sum(p.PurGstRs) as purGstRsSum, ProdGst from PurchaseDtls as p  join ProductDetails as pd on pd.PDID = p.PurProductID  join ProductGSTs as pg on pg.ProdGstID = pd.GstPercent where p.PurSuppCustId = @CustId and p.PurDate between @FDate and @LDate group by pg.ProdGst", Mycon);

        //    cmd.Parameters.AddWithValue("@CustId", CustId);
        //    cmd.Parameters.AddWithValue("@FDate", Fdate);
        //    cmd.Parameters.AddWithValue("@LDate", LDate);


        //    Mycon.Open();
        //    SqlDataReader dr = cmd.ExecuteReader();

        //    while (dr.Read())
        //    {
        //        PurchaseDtl Pd = new PurchaseDtl();

        //        Pd.PurTotal = Convert.ToDecimal(dr["purTotalSum"]);
        //        Pd.PurGstRs = Convert.ToDecimal(dr["purGstRsSum"]);
        //        Pd.ProductGst = Convert.ToDecimal(dr["ProdGst"]);

        //        lst.Add(Pd);
        //    }

        //    Mycon.Close();

        //    return lst;
        //}

        public List<SalesGST> GST_Bifercation_Sale_Report(DateTime? fdate, DateTime? ldate, int? CustId)
        {
            List<SalesGST> lst = new List<SalesGST>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            string SqlQuery = "";
            if (fdate != null && ldate != null && CustId != null)
            {
                SqlQuery = "select  sum(p.SaleGST_Total) as TotalSum, sum(p.SaleGST_GstRs) as GstRsSum, ProdGst from SalesGSTs as p  join ProductDetails as pd on pd.PDID = p.SaleGST_ProductID  join ProductGSTs as pg on pg.ProdGstID = pd.GstPercent where p.SaleGST_SuppCustId = @CustId and p.SaleGST_Date between @FDate and @LDate group by pg.ProdGst";

            }
            if (fdate != null && ldate != null && CustId == null)
            {
                SqlQuery = "select  sum(p.SaleGST_Total) as TotalSum, sum(p.SaleGST_GstRs) as GstRsSum, ProdGst from SalesGSTs as p  join ProductDetails as pd on pd.PDID = p.SaleGST_ProductID  join ProductGSTs as pg on pg.ProdGstID = pd.GstPercent where p.SaleGST_Date between @FDate and @LDate group by pg.ProdGst";
            }
            SqlCommand cmd = new SqlCommand(SqlQuery, Mycon);


            if (fdate != null && ldate != null && CustId != null)
            {
                cmd.Parameters.AddWithValue("@CustId", CustId);
                cmd.Parameters.AddWithValue("@FDate", fdate);
                cmd.Parameters.AddWithValue("@LDate", ldate);
            }
            if (fdate != null && ldate != null && CustId == null)
            {
                cmd.Parameters.AddWithValue("@FDate", fdate);
                cmd.Parameters.AddWithValue("@LDate", ldate);
            }



            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                SalesGST Pd = new SalesGST();

                Pd.SaleGST_Total = Convert.ToDecimal(dr["TotalSum"]);
                Pd.SaleGST_GstRs = Convert.ToDecimal(dr["GstRsSum"]);
                Pd.ProductGst = Convert.ToDecimal(dr["ProdGst"]);

                lst.Add(Pd);
            }

            Mycon.Close();

            return lst;
        }








        // <-----------------  @@@  End Sale report with Gst @@@ ---------->









        // @@@@@@@@@@@@@@@@@  End Report Section @@@@@@@@@@@@@@@@


        public void AddFeedback(Feedback fb)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);
            string Query;

            Query = "insert into Feedbacks values(@F_CustName,@F_Experiece,@F_Comments,@F_Images,@F_Rating,@F_Date)";

            SqlCommand cmd = new SqlCommand(Query, Mycon);

            DateTime dt = DateTime.Now;

            cmd.Parameters.AddWithValue("@F_CustName", fb.F_CustName);
            cmd.Parameters.AddWithValue("@F_Experiece", fb.F_Experiece);
            cmd.Parameters.AddWithValue("@F_Comments", fb.F_Comments);

            if (fb.F_Images != null)
            {
                cmd.Parameters.AddWithValue("@F_Images", fb.F_Images);
            }
            else
            {
                cmd.Parameters.AddWithValue("@F_Images", "");
            }

            cmd.Parameters.AddWithValue("@F_Rating", fb.F_Rating);
            cmd.Parameters.AddWithValue("@F_Date", dt.ToString("MM/dd/yyyy"));


            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }




        // <-------------------  @@@ Upload Form @@@ ----------------->



        public void AddFiles(UploadFiles uf, string FName, string FileExt)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);
            string Query;

            Query = "insert into UploadedTbs values(@Utb_Name,@Utb_FileExtension,@Utb_Dates,@UpID,@Uploader_Name_ID)";

            SqlCommand cmd = new SqlCommand(Query, Mycon);
            DateTime dt = DateTime.Now;


            cmd.Parameters.AddWithValue("@Utb_Name", FName);
            cmd.Parameters.AddWithValue("@Utb_FileExtension", FileExt);
            cmd.Parameters.AddWithValue("@Utb_Dates", dt.ToString("MM/dd/yyyy"));
            cmd.Parameters.AddWithValue("@UpID", uf.UpID);
            // cmd.Parameters.AddWithValue("@Uploader_Name_ID", 0); // Admin also zero

            if (uf.Uploader_Name_ID != 0)
            {
                cmd.Parameters.AddWithValue("@Uploader_Name_ID", uf.Uploader_Name_ID); // User Id
            }
            else
            {
                cmd.Parameters.AddWithValue("@Uploader_Name_ID", 0); // Admin also zero
            }


            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }

        public int AddUploadFile(UploadFiles uf)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);
            string Query;

            Query = "insert into UploadFiles OUTPUT INSERTED.UpID values(@Notes,@UpDates,@RID,@Status_ID,@Uploader_Name_ID)";

            SqlCommand cmd = new SqlCommand(Query, Mycon);

            DateTime dt = DateTime.Now;

            cmd.Parameters.AddWithValue("@Notes", uf.Notes);
            cmd.Parameters.AddWithValue("@UpDates", dt.ToString("MM/dd/yyyy"));
            cmd.Parameters.AddWithValue("@RID", uf.RID);
            cmd.Parameters.AddWithValue("@Status_ID", 1); // This is active
            if (uf.Uploader_Name_ID != 0)
            {
                cmd.Parameters.AddWithValue("@Uploader_Name_ID", uf.Uploader_Name_ID); // User Id
            }
            else
            {
                cmd.Parameters.AddWithValue("@Uploader_Name_ID", 0); // Admin also zero
            }


            Mycon.Open();
            //  cmd.ExecuteNonQuery();
            int id = (int)cmd.ExecuteScalar();
            Mycon.Close();

            return id;
        }



        public void Delele_UploadedFile(int? UpID)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);
            string Query = "";

            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    Query = "delete UploadFiles where UpID = @UpID";
                }


                if (i == 1)
                {
                    Query = "delete UploadedTbs where UpID = @UpID";
                }

                SqlCommand cmd = new SqlCommand(Query, Mycon);

                cmd.Parameters.AddWithValue("@UpID", UpID);
                Mycon.Open();
                cmd.ExecuteNonQuery();
                Mycon.Close();
            }

        }

        public void Edit_Delele_UploadedFile(int? UpID)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            string Query = "delete UploadedTbs where Utb_ID = @Utb_ID";

            SqlCommand cmd = new SqlCommand(Query, Mycon);

            cmd.Parameters.AddWithValue("@Utb_ID", UpID);
            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();


        }





        // <------------------- @@@ End Upload Form @@@ --------------->

        // <------------------- @@@ Income/Expense Report @@@ --------------->

        public List<Daily_Business> SumOfAllPayment(DateTime? Fdate, DateTime? Ldate)
        {
            List<Daily_Business> lst = new List<Daily_Business>();

            SqlConnection Mycon = new SqlConnection(Cnstr);

            SqlCommand cmd = new SqlCommand("select sum(Cash) as Cash,sum(Gpay) as Gpay,sum(Zomato) as Zomato,sum(Card) as Card,sum(Paytm) as Paytm,sum(Swiggy) as Swiggy from Daily_Business where Dates between @Fdate and @Ldate", Mycon);

            cmd.Parameters.AddWithValue("@Fdate", Fdate);
            cmd.Parameters.AddWithValue("@Ldate", Ldate);

            Mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Daily_Business Day_B = new Daily_Business();

                if (!(dr["Cash"] is DBNull))
                {
                    Day_B.Cash = Convert.ToDecimal(dr["Cash"]);
                }
                if (!(dr["Gpay"] is DBNull))
                {
                    Day_B.Gpay = Convert.ToDecimal(dr["Gpay"]);
                }
                if (!(dr["Zomato"] is DBNull))
                {
                    Day_B.Zomato = Convert.ToDecimal(dr["Zomato"]);
                }
                if (!(dr["Card"] is DBNull))
                {
                    Day_B.Card = Convert.ToDecimal(dr["Card"]);
                }

                if (!(dr["Paytm"] is DBNull))
                {
                    Day_B.Paytm = Convert.ToDecimal(dr["Paytm"]);
                }

                if (!(dr["Swiggy"] is DBNull))
                {
                    Day_B.Swiggy = Convert.ToDecimal(dr["Swiggy"]);
                }

                lst.Add(Day_B);
            }
            Mycon.Close();



            return lst;
        }



        // <------------------- @@@ End Income/Expense Report @@@ --------------->


        // <------------------- @@@ Credit Notes @@@ ---------------------------->
        public void AddEdit_CreditNote_Tnc(int id, string Bill_No)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);

            string query = "insert into CreditNotesTnCs values(@CreditNotesTnC_BillNo,@CreditNotesTnC_TCID)";

            SqlCommand cmd = new SqlCommand(query, Mycon);

            cmd.Parameters.AddWithValue("@CreditNotesTnC_BillNo", Bill_No);
            cmd.Parameters.AddWithValue("@CreditNotesTnC_TCID", id);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }

        public void AddEditCreditNote(CreditNotes CN)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);

            string query;

            //if (CN.CreditNotes_ID != 0)
            //{
            //    query = "update TempCreditNotes set TempCreditNotes_SuppCustId = @TempCreditNotes_SuppCustId, TempCreditNotes_BillNo = @TempCreditNotes_BillNo, TempCreditNotes_ProductRate = @TempCreditNotes_ProductRate, TempCreditNotes_ProductID = @TempCreditNotes_ProductID, TempCreditNotes_PDiscount = @TempCreditNotes_PDiscount, TempCreditNotes_Quantity = @TempCreditNotes_Quantity, TempCreditNotes_GstRs = @TempCreditNotes_GstRs, TempCreditNotes_Total = @TempCreditNotes_Total, TempCreditNotes_Date = @TempCreditNotes_Date where TempCreditNotes_ID = @TempCreditNotes_ID";
            //}
            //else
            //{
            query = "insert into CreditNotes values(@CreditNotes_SuppCustId,@CreditNotes_BillNo,@CreditNotes_SaleWithGSTBillNo,@CreditNotes_ProductRate,@CreditNotes_ProductID,@CreditNotes_PDiscount,@CreditNotes_Quantity,@CreditNotes_GstRs,@CreditNotes_Total,@TempSaleGST_DiscRs,@TempSaleGST_DiscPer,@TempSaleGST_ChargesName,@TempSaleGST_ChargesAmt,@TempSaleGST_Notes,@TempSaleGST_GrandTot,@TempSaleGST_FTotalAmt,@CreditNotes_Date)";
            //   }

            SqlCommand cmd = new SqlCommand(query, Mycon);

            cmd.Parameters.AddWithValue("@CreditNotes_SuppCustId", CN.CreditNotes_SuppCustId);
            cmd.Parameters.AddWithValue("@CreditNotes_BillNo", CN.CreditNotes_BillNo);
            cmd.Parameters.AddWithValue("@CreditNotes_SaleWithGSTBillNo", CN.CreditNotes_SaleWithGSTBillNo);
            cmd.Parameters.AddWithValue("@CreditNotes_ProductRate", CN.CreditNotes_ProductRate);
            cmd.Parameters.AddWithValue("@CreditNotes_ProductID", CN.CreditNotes_ProductID);
            cmd.Parameters.AddWithValue("@CreditNotes_PDiscount", CN.CreditNotes_PDiscount);

            cmd.Parameters.AddWithValue("@CreditNotes_Quantity", CN.CreditNotes_Quantity);
            cmd.Parameters.AddWithValue("@CreditNotes_GstRs", CN.TempSaleGST_ProductGst);
            cmd.Parameters.AddWithValue("@CreditNotes_Total", CN.CreditNotes_Total);
            cmd.Parameters.AddWithValue("@TempSaleGST_DiscRs", CN.TempSaleGST_DiscRs);

            cmd.Parameters.AddWithValue("@TempSaleGST_DiscPer", CN.TempSaleGST_DiscPer);

            if (CN.TempSaleGST_ChargesName != null)
            {
                cmd.Parameters.AddWithValue("@TempSaleGST_ChargesName", CN.TempSaleGST_ChargesName);
            }
            else
            {
                cmd.Parameters.AddWithValue("@TempSaleGST_ChargesName", "");
            }

            cmd.Parameters.AddWithValue("@TempSaleGST_ChargesAmt", CN.TempSaleGST_ChargesAmt);

            if (CN.TempSaleGST_Notes != null)
            {
                cmd.Parameters.AddWithValue("@TempSaleGST_Notes", CN.TempSaleGST_Notes);
            }
            else
            {
                cmd.Parameters.AddWithValue("@TempSaleGST_Notes", "");
            }

            cmd.Parameters.AddWithValue("@TempSaleGST_GrandTot", CN.TempSaleGST_GrandTot);
            cmd.Parameters.AddWithValue("@TempSaleGST_FTotalAmt", CN.TempSaleGST_FTotalAmt);
            cmd.Parameters.AddWithValue("@CreditNotes_Date", CN.CreditNotes_Date);


            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }

        public void OnEditTempCreditNote(CreditNotes CN)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);

            string query;



            query = "insert into TempCreditNotes values(@TempCreditNotes_SuppCustId,@TempCreditNotes_BillNo,@TempCreditNotes_ProductRate,@TempCreditNotes_ProductID,@TempCreditNotes_PDiscount,@TempCreditNotes_Quantity,@TempCreditNotes_GstRs,@TempCreditNotes_Total,@TempCreditNotes_Date)";


            SqlCommand cmd = new SqlCommand(query, Mycon);

            cmd.Parameters.AddWithValue("@TempCreditNotes_ID", Convert.ToInt32(CN.CreditNotes_ID));
            cmd.Parameters.AddWithValue("@TempCreditNotes_SuppCustId", Convert.ToInt32(CN.CreditNotes_SuppCustId));
            cmd.Parameters.AddWithValue("@TempCreditNotes_BillNo", CN.CreditNotes_SaleWithGSTBillNo);
            cmd.Parameters.AddWithValue("@TempCreditNotes_ProductRate", Convert.ToDecimal(CN.TempSaleGST_ProductRates));
            cmd.Parameters.AddWithValue("@TempCreditNotes_ProductID", Convert.ToInt32(CN.CreditNotes_ProductID));
            cmd.Parameters.AddWithValue("@TempCreditNotes_Quantity", CN.CreditNotes_Quantity);

            cmd.Parameters.AddWithValue("@TempCreditNotes_GstRs", Convert.ToDecimal(CN.CreditNotes_GstRs));
            cmd.Parameters.AddWithValue("@TempCreditNotes_Total", Convert.ToDecimal(CN.CreditNotes_Total));
            cmd.Parameters.AddWithValue("@TempCreditNotes_Date", CN.CreditNotes_Date);
            cmd.Parameters.AddWithValue("@TempCreditNotes_PDiscount", CN.CreditNotes_PDiscount);


            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }


        public void AddEditTempCreditNote(CreditNotes CN)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);

            string query;

            if (CN.CreditNotes_ID != 0)
            {
                query = "update TempCreditNotes set TempCreditNotes_SuppCustId = @TempCreditNotes_SuppCustId, TempCreditNotes_BillNo = @TempCreditNotes_BillNo, TempCreditNotes_ProductRate = @TempCreditNotes_ProductRate, TempCreditNotes_ProductID = @TempCreditNotes_ProductID, TempCreditNotes_PDiscount = @TempCreditNotes_PDiscount, TempCreditNotes_Quantity = @TempCreditNotes_Quantity, TempCreditNotes_GstRs = @TempCreditNotes_GstRs, TempCreditNotes_Total = @TempCreditNotes_Total, TempCreditNotes_Date = @TempCreditNotes_Date where TempCreditNotes_ID = @TempCreditNotes_ID";
            }
            else
            {
                query = "insert into TempCreditNotes values(@TempCreditNotes_SuppCustId,@TempCreditNotes_BillNo,@TempCreditNotes_ProductRate,@TempCreditNotes_ProductID,@TempCreditNotes_PDiscount,@TempCreditNotes_Quantity,@TempCreditNotes_GstRs,@TempCreditNotes_Total,@TempCreditNotes_Date)";
            }

            SqlCommand cmd = new SqlCommand(query, Mycon);

            cmd.Parameters.AddWithValue("@TempCreditNotes_ID", Convert.ToInt32(CN.CreditNotes_ID));
            cmd.Parameters.AddWithValue("@TempCreditNotes_SuppCustId", Convert.ToInt32(CN.CreditNotes_SuppCustId));
            cmd.Parameters.AddWithValue("@TempCreditNotes_BillNo", CN.CreditNotes_SaleWithGSTBillNo);
            cmd.Parameters.AddWithValue("@TempCreditNotes_ProductRate", Convert.ToDecimal(CN.TempSaleGST_ProductRates));
            cmd.Parameters.AddWithValue("@TempCreditNotes_ProductID", Convert.ToInt32(CN.CreditNotes_ProductID));
            cmd.Parameters.AddWithValue("@TempCreditNotes_Quantity", CN.CreditNotes_Quantity);

            decimal Prorate, ProQunt;
            Prorate = Convert.ToDecimal(CN.TempSaleGST_ProductRates);
            ProQunt = CN.CreditNotes_Quantity;

            decimal GrandTotal = Prorate * ProQunt;
            decimal gst = CN.TempSaleGST_ProductGst;
            decimal GstRs = GrandTotal * gst / 100;

            cmd.Parameters.AddWithValue("@TempCreditNotes_GstRs", GstRs);
            cmd.Parameters.AddWithValue("@TempCreditNotes_Total", GrandTotal);
            cmd.Parameters.AddWithValue("@TempCreditNotes_Date", CN.CreditNotes_Date);
            cmd.Parameters.AddWithValue("@TempCreditNotes_PDiscount", CN.CreditNotes_PDiscount);


            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }

        public void DeleteTempCreditNote(int SalID)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("delete  TempCreditNotes where TempCreditNotes_ID = @TempCreditNotes_ID", Mycon);
            cmd.Parameters.AddWithValue("@TempCreditNotes_ID", SalID);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();

        }

        public void Truncate_TempCreditNote() // this is temp data delete function
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("Truncate table TempCreditNotes", Mycon);
            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }

        public void Delete_CreditNoteTnC(string BillNo) // this is temp data delete function
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("delete CreditNotesTnCs where CreditNotesTnC_BillNo = @CreditNotesTnC_BillNo", Mycon);
            cmd.Parameters.AddWithValue("@CreditNotesTnC_BillNo", BillNo);
            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }

        public void Delete_CreditNote(string BillNo) // this is temp data delete function
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("delete CreditNotes where CreditNotes_SaleWithGSTBillNo = @CreditNotes_SaleWithGSTBillNo", Mycon);
            cmd.Parameters.AddWithValue("@CreditNotes_SaleWithGSTBillNo", BillNo);
            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }

        // <-------------------- End Credit Notes --------------------------->



        // <--------------------@@@ Store Code @@@--------------------------->
        public void AddStoreProduct(Store_AddProduct P, string FName)
        {

            SqlConnection Mycon = new SqlConnection(Cnstr);

            string query = "";

            if (P.Sp_ID != 0)
                query = "update  Store_AddProduct set Sp_ProductName = @Sp_ProductName, Sp_Rate = @Sp_Rate, Sp_Category = @Sp_Category, Sp_Description = @Sp_Description,Sp_PImageName = @ImgName where Sp_ID = @Sp_ID";
            else
                query = "insert into Store_AddProduct values(@Sp_ProductName,@Sp_Rate,@Sp_Category,@Sp_Description,1,@ImgName)";


            SqlCommand cmd = new SqlCommand(query, Mycon);

            cmd.Parameters.AddWithValue("@Sp_ID", P.Sp_ID);
            cmd.Parameters.AddWithValue("@Sp_ProductName", P.Sp_ProductName);
            cmd.Parameters.AddWithValue("@Sp_Rate", P.Sp_Rate);
            cmd.Parameters.AddWithValue("@Sp_Category", P.Sp_Category);
            cmd.Parameters.AddWithValue("@ImgName", FName);
            cmd.Parameters.AddWithValue("@Sp_Description", P.Sp_Description);
            //  cmd.Parameters.AddWithValue("@Sp_Status", P.Sp_Status);

            try
            {
                Mycon.Open();
                cmd.ExecuteNonQuery();
                Mycon.Close();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void ActiveDeactive_StoreProduct(int stID, int id) // this is temp data delete function
        {
            int i = stID;
            while (i <= 2)
            {
                if (i == 2)
                {
                    i = 1;
                    break;
                }
                i++;
                break;
            }

            SqlConnection Mycon = new SqlConnection(Cnstr);
            SqlCommand cmd = new SqlCommand("update Store_AddProduct set Sp_Status = @Sp_Status where Sp_ID = @Sp_ID", Mycon);
            cmd.Parameters.AddWithValue("@Sp_Status", i);
            cmd.Parameters.AddWithValue("@Sp_ID", id);

            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }

        public void Delete_DelivaryCharges(int id, string Act)
        {
            SqlConnection Mycon = new SqlConnection(Cnstr);
            string Query = "";

            if (Act == "del")
            {
                Query = "delete delivery_charges where DC_ID = @DC_ID";
            }
            else
            {
                Query = "truncate table delivery_charges";
            }

            SqlCommand cmd = new SqlCommand(Query, Mycon);
            cmd.Parameters.AddWithValue("@DC_ID", id);
            Mycon.Open();
            cmd.ExecuteNonQuery();
            Mycon.Close();
        }







        // <-------------------- End store code ------------------------------>
    }

}