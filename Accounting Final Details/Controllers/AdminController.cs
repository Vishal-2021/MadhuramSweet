using Accounting_Final_Details.Coding;
using Accounting_Final_Details.Models;
using Accounting_Final_Details.Models.ViewModels;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Web;
using System.Web.Mvc;

namespace Accounting_Final_Details.Controllers
{
    public class AdminController : Controller
    {
        readonly AccountDetailsDBContext db = new AccountDetailsDBContext();

        AdminCode ac = new AdminCode();
        ComboPack cb = new ComboPack();
        UserCode uc = new UserCode();
        // GET: Admin
        public ActionResult Index()
        {



            ViewBag.DeliOrderNow = ac.DaliveryOrderNow();
            ViewBag.DeliOrderWeekly = ac.DaliveryOrderWeekly();
            ViewBag.DeliOrderMonthly = ac.DaliveryOrderMonthly();


            ViewBag.DeliOrderNowSale = ac.DaliveryOrderNowSale();
            ViewBag.DeliOrderWeeklySale = ac.DaliveryOrderWeeklySale();
            ViewBag.DeliOrderMonthlySale = ac.DaliveryOrderMonthlySale();






            ViewBag.TotalProducts = ac.TotalProduct();
            ViewBag.TotalUsers = ac.TotalUsers();
            ViewBag.TotalCustomer = ac.TotalCustomers();

            ViewBag.TotalDailyPurchase = ac.TotalDailyPurchase();
            ViewBag.TotalWeekPurchase = ac.TotalWeeklyPurchase();
            ViewBag.TotalMonthlyPurchase = ac.TotalMonthlyPurchase();
            ViewBag.TotalYearlyPurchase = ac.TotalYearlyPurchase();

            ViewBag.TotalDailyPurchase_ReceivedAmt = ac.TotalDailyPurchase_Received();
            ViewBag.TotalWeeklyPurchase_ReceivedAmt = ac.TotalWeeklyPurchase_Received();
            ViewBag.TotalMonthlyPurchase_ReceivedAmt = ac.TotalMonthlyPurchase_Received();
            ViewBag.TotalYearlyPurchase_ReceivedAmt = ac.TotalYearlyPurchase_Received();



            //  decimal AllFinal_PurchaseTotal     = Convert.ToDecimal(ac.TotalAllPurchase());
            //  decimal AllFinal_TransactionTotal  = Convert.ToDecimal(ac.TotalAllPurchase_Received());


            ViewBag.AllFinal_PurchaseTotal = ac.TotalAllPurchase();
            ViewBag.AllFinal_TransactionTotal = ac.TotalAllPurchase_Received();


            decimal AllFinal_PurchaseTotal = 0;
            decimal AllFinal_TransactionTotal = 0;





            if (!(ViewBag.AllFinal_PurchaseTotal is DBNull))
            {
                AllFinal_PurchaseTotal = ViewBag.AllFinal_PurchaseTotal;
            }

            if (!(ViewBag.AllFinal_TransactionTotal is DBNull))
            {
                AllFinal_TransactionTotal = ViewBag.AllFinal_TransactionTotal;
            }


            //  decimal AllFinal_PurchaseTotal = Convert.ToDecimal(ac.TotalAllPurchase());
            //  decimal AllFinal_TransactionTotal = Convert.ToDecimal(ac.TotalAllPurchase_Received());



            ViewBag.OutstandingAmt = AllFinal_PurchaseTotal - AllFinal_TransactionTotal;




            ViewBag.TotalBills = ac.TotalBills();






            ViewBag.TotalDaily_SaleWithoutGst = ac.TotalDaily_SaleWithoutGst();

            ViewBag.TotalWeekly_SaleWithoutGst = ac.TotalWeekly_SaleWithoutGst();

            ViewBag.TotalMonthly_SaleWithoutGst = ac.TotalMonthly_SaleWithoutGst();

            ViewBag.TotalYearly_SaleWithoutGst = ac.TotalYearly_SaleWithoutGst();


            ViewBag.TotalAll_SaleWithoutGst = ac.TotalAll_SaleWithoutGst();

            ViewBag.Outsand_SaleWithoutGst = ac.Outsand_SaleWithoutGst();

            ViewBag.TotalBills_SaleWithoutGst = ac.TotalBills_SaleWithoutGst();





            ViewBag.TotalDaily_SaleWithGst = ac.TotalDaily_SaleWithGst();
            ViewBag.TotalWeekly_SaleWithGst = ac.TotalWeekly_SaleWithGst();
            ViewBag.TotalMonthly_SaleWithGst = ac.TotalMonthly_SaleWithGst();
            ViewBag.TotalYearly_SaleWithGst = ac.TotalYearly_SaleWithGst();




            ViewBag.TotalDailySaleWithGst_Received = ac.TotalDailySaleWithGst_Received();

            ViewBag.TotalWeeklySaleWithGst_Received = ac.TotalWeeklySaleWithGst_Received();
            ViewBag.TotalMonthlySaleWithGst_Received = ac.TotalMonthlySaleWithGst_Received();
            ViewBag.TotalYearlySaleWithGst_Received = ac.TotalYearlySaleWithGst_Received();

            decimal TotalSaleAmt = 0;
            decimal TotalReceivedAmt = 0;



            object FinalAmt = ac.TotalAll_SaleWithGst();

            object TotalReciAmt = ac.TotalAllSaleWithGst_Received();


            //object FinalAmt = Convert.ToDecimal(ac.TotalAll_SaleWithGst());

            //object TotalReciAmt = Convert.ToDecimal(ac.TotalAllSaleWithGst_Received());


            if (!(FinalAmt is DBNull))

            {
                TotalSaleAmt = Convert.ToDecimal(FinalAmt);
            }

            if (!(TotalReciAmt is DBNull))
            {
                TotalReceivedAmt = Convert.ToDecimal(TotalReciAmt);
            }



            ViewBag.TotalOutstanding = TotalSaleAmt - TotalReceivedAmt;

            ViewBag.TotalBills_SaleWithGst = ac.TotalBills_SaleWithGst();

            // ViewBag.Layouts = Convert.ToInt32(id);



            ViewBag.Outstand = ac.OustStand();




            string B_No;
            decimal F_Amt = 0, T_Amt = 0;
            int Count_Out_Bill = 0;

            foreach (var item in ViewBag.Outstand)
            {
                F_Amt = item.SalesGST_Rpt_FinalTotal;
                B_No = item.SGstTran_BillNo;
                T_Amt = item.SGstTran_TranReciAmt;

                decimal Rslt = F_Amt - T_Amt;

                if (Rslt > 0)
                {
                    Count_Out_Bill++;

                }

            }

            ViewBag.OutStandingBill = Count_Out_Bill;


            return View();
        }

        // @@@@@@@@@@@ Registration Details @@@@@@@@

        public ActionResult UserAccess(int? id)
        {

            User_Access ua = new User_Access();

            //if (custId != null && id == null)
            //{
            //    ua.UserID = Convert.ToInt32(custId);
            //}
            //if (custId == null && id != null)
            //{
            ua.UserID = Convert.ToInt32(id);
            // }



            ViewBag.UserName = new SelectList(db.Registration.ToList(), "RID", "UserName");

            ViewBag.UserAccess_List = db.User_Access.ToList();

            //var data = db.User_Access.ToList();
            ViewBag.UserAccessInfo_List = db.UserAccess_Info.Where(x => x.uai_Reg_ID == id).ToList();
            //data.Where(x=>)

            return View(ua);
        }



        public ActionResult CustID(int id)
        {

            return RedirectToAction("UserAccess", new { id = id });

        }

        [HttpPost]
        public ActionResult UserAccess(FormCollection fc)
        {

            int User_Ids = Convert.ToInt32(fc["UserID"]);
            ac.Delete_UserAccess(User_Ids);

            string[] ids = fc["UA_ID"].Split(new char[] { ',' });


            foreach (string id in ids)
            {
                ac.Add_UserAccess(int.Parse(id), User_Ids);
            }

            ViewBag.UserName = new SelectList(db.Registration.ToList(), "RID", "UserName");
            ViewBag.UserAccess_List = db.User_Access.ToList();

            TempData["SaveRegMsg"] = "Data Saved Successfully...!";

            return View();
        }









        public ActionResult ActiveStatusRgst(int id)
        {
            ac.ActiveStatusRgst(id, "Registration");
            return RedirectToAction("ListRegistrationDetails");
        }
        [HttpPost]
        public JsonResult EmailIDExistOrNot(Registration rgst)
        {
            int rslt;

            object obj = ac.EmailExistOrNot(rgst);
            if (obj != null)
            {
                rslt = 0;

            }
            else
            {
                rslt = 1;

            }
            return Json(rslt, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EmailIDExistOrNots(Registration rgst)
        {
            int rslt;

            object obj = ac.EmailExistOrNot(rgst);
            if (obj != null)
            {
                rslt = 0;

            }
            else
            {
                rslt = 1;

            }
            return Json(rslt, JsonRequestBehavior.AllowGet);
        }




        public ActionResult Demo()
        {


            ViewBag.lst = db.Feedback.ToList();

            //ViewBag.TermsnConditions = ac.ListTnC();

            //ViewBag.TranPayDtl = db.CustSuppPayment.Join(// outer sequence 
            //                      db.CustSupTransaction,  // inner sequence 
            //                      custPay => custPay.SupCustBillNo,    // outerKeySelector
            //                      custTran => custTran.TranBillNo,  // innerKeySelector
            //                      (custPay, custTran) => new  // result selector
            //                      {
            //                          SupCustBillAmt = custPay.SupCustBillAmt,
            //                          TranReciAmt = custTran.TranReciAmt
            //                      });



            //  List<ComboPack> cp = ac.PDShow();

            //  ViewBag.LIst = ac.PDShow();

            //
            //   ViewBag.Bac = "hellow";

            //var results = from p in persons
            //              group p.car by p.PersonId into g
            //              select new { PersonId = g.Key, Cars = g.ToList() };


            //ViewBag.List = from s in db.PurchaseDtl
            //               group s by s.PurSuppCustId;


            return View();
        }

        public ActionResult ReportExample()
        {
            AccountDetailsDBContext context = new AccountDetailsDBContext();


            //   select* from PurchaseDtls as p  join PurchaseForReports as pr on pr.PrBillNo = p.PurBillNo join Registrations as r on r.RID = p.PurSuppCustId where p.PurBillNo = 001


            ViewBag.ListRgstDtl = (from s1 in db.PurchaseDtl join s2 in db.PurchaseForReport on s1.PurBillNo equals s2.PrBillNo join s3 in db.Registration on s1.PurSuppCustId equals s3.RID select new ComboPack { PurchaseDtl = s1, PurchaseForReport = s2, Rgst = s3 }).ToList();

            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Report"), "Registrations.rpt"));
            rd.SetDataSource(ViewBag.ListRgstDtl);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "CustomerList.pdf");
        }




        public ActionResult ListRegistrationDetails()
        {
            ViewBag.ListRgstDtl = (from s1 in db.Registration join s2 in db.ActivationStatus on s1.ActiveStatus equals s2.ActStsID select new ComboPack { Rgst = s1, ActStats = s2 }).ToList();
            ViewBag.ActStatusList = new SelectList(db.ActivationStatus.ToList(), "ActStsID", "ActStsName");

            return View();
        }
        [HttpPost]
        public ActionResult AddRegistrationDetails(Registration reg)
        {

            ac.AddRegistration(reg);

            TempData["SaveRegMsg"] = "Data Saved Successfully...!";



            return RedirectToAction("ListRegistrationDetails");
        }
        public ActionResult EditRegistrationDetails(Registration reg)
        {
            int id = reg.RID;
            ac.EditRegistration(reg);

            TempData["UpdatRegMsg"] = "Data Updated Successfully...!";

            return RedirectToAction("ListRegistrationDetails");
        }
        public ActionResult DeletRegistration(int id)
        {
            // ViewBag.IDSS = id;
            ac.DeleteRegistration(id);
            return RedirectToAction("ListRegistrationDetails");
        }
        public JsonResult FetchRegistDetails(int ID)
        {
            var FetchRegist = db.Registration.ToList().Find(x => x.RID.Equals(ID));
            return Json(FetchRegist, JsonRequestBehavior.AllowGet);
        }



        // <----------  End Registration Details -------->

        // @@@@@@@@@@   Bank Details @@@@@@@@@@@

        public ActionResult ListBankDetails()
        {

            //   ViewBag.ListBnkDtl = db.BankDetails.ToList();
            ViewBag.ListBnkDtl = (from s1 in db.BankDetails join s2 in db.OrganizationDetails on s1.OrgID equals s2.OrgID select new ComboPack { BankDetails = s1, OrganizationDetails = s2 }).ToList();


            ViewBag.OrgList = new SelectList(db.OrganizationDetails.ToList(), "OrgID", "OrgName");

            return View();
        }
        public ActionResult DeleteBankDetail(int id)
        {

            ac.DeleteBankDetails(id);
            return RedirectToAction("ListBankDetails");
        }
        public ActionResult CreateBankDetails(BankDetails bd)
        {
            ac.AddBankDeatils(bd);
            TempData["SaveRegMsg"] = "Data Saved Successfully...!";
            return RedirectToAction("ListBankDetails");
        }

        public ActionResult EditBankDetails(BankDetails bd)
        {
            ac.EditBankDeatils(bd);
            TempData["UpdatRegMsg"] = "Data Updated Successfully...!";
            return RedirectToAction("ListBankDetails");
        }

        //public JsonResult AutoOrganizationName(string search)
        //{
        //    List<AutoDropdown> allsearch = db.CustomerDetails.Where(x => x.CustName.Contains(search)).Select(x => new AutoDropdown
        //    {
        //        Id = x.CustID,
        //        Name = x.CustName
        //    }).ToList();
        //    return new JsonResult { Data = allsearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}

        //public JsonResult GetOrgID(BankDetails Bd)
        //{
        //    var FetchOrgID = db.OrganizationDetails.ToList().Find(x => x.OrgName.Equals(Bd.OrgName));
        //    return Json(FetchOrgID, JsonRequestBehavior.AllowGet);
        //}


        public JsonResult FetchBankDetails(int ID)
        {

            //     var FetchRegist = db.BankDetails.ToList().Find(x => x.BnkDID.Equals(ID));
            //  var FetchRegist = (from s1 in db.BankDetails join s2 in db.OrganizationDetails on s1.OrgID equals s2.OrgID where s1.BnkDID == ID select new ComboPack { BankDetails = s1, OrganizationDetails = s2 }).ToList();
            ViewBag.msg = (from s1 in db.BankDetails join s2 in db.OrganizationDetails on s1.OrgID equals s2.OrgID where s1.BnkDID == ID select new ComboPack { BankDetails = s1, OrganizationDetails = s2 }).FirstOrDefault();
            return Json(ViewBag.msg, JsonRequestBehavior.AllowGet);
        }


        // <----------- End Bank Details ----------->


        // @@@@@@@@@@@@ Customer Details @@@@@@@@@@@@@@@@@
        public ActionResult ActiveStatusCustomerSupplier(int id)
        {
            ac.ActiveStatusRgst(id, "CustomerSupplier");
            return RedirectToAction("ListCustomerDetails");
        }
        public ActionResult Dist(int Sid)
        {
            List<District> district = ac.DistList(Sid);

            ViewBag.DistrictList = new SelectList(district, "DistId", "DistName");

            return PartialView("District");
        }

        public ActionResult DistUpdate()
        {
            // List<District> district = ac.DistList(Sid);

            //   ViewBag.DistrictList = new SelectList(district, "DistId", "DistName");

            ViewBag.DistrictList = new SelectList(db.district.ToList(), "DistId", "DistName");


            return PartialView("District");
        }





        public ActionResult ListCustomerDetails()
        {
            //  ViewBag.ListCustDtl = db.CustomerDetails.ToList();

            ViewBag.ListCustDtl = (from s1 in db.CustomerDetails join s2 in db.ActivationStatus on s1.CustStatus equals s2.ActStsID join s3 in db.state on s1.CustStatus equals s3.SId join s4 in db.district on s1.CustDistrict equals s4.DistId select new ComboPack { CustDtl = s1, ActStats = s2, state = s3, district = s4 }).ToList();


            //< ------ Dropdown List Data -------->
            ViewBag.ActStatusList = new SelectList(db.ActivationStatus.ToList(), "ActStsID", "ActStsName");
            ViewBag.StateList = new SelectList(db.state.ToList(), "SId", "SName");
            ViewBag.DistrictList = new SelectList(db.district.ToList(), "DistId", "DistName");
            // < --------- End Dropdown List Data -------->


            return View();
        }

        public ActionResult AddCustomerSupplierList(CustomerDetails custdtl)
        {
            ac.AddCustomerSupplier(custdtl);
            TempData["SaveRegMsg"] = "Data Saved Successfully...!";

            return RedirectToAction("ListCustomerDetails");
        }

        public ActionResult EditCustomerSupplierList(CustomerDetails custdtl)
        {
            ac.EditCustomerSupplier(custdtl);
            TempData["UpdatRegMsg"] = "Data Updated Successfully...!";
            return RedirectToAction("ListCustomerDetails");
        }
        public ActionResult DeletCustomerSupplier(int id)
        {
            // ViewBag.IDSS = id;
            ac.DeleteCustomerSupplier(id);
            return RedirectToAction("ListCustomerDetails");
        }
        public JsonResult FetchCustomerSupplierDetails(int ID)
        {
            var FetchRegist = db.CustomerDetails.ToList().Find(x => x.CustID.Equals(ID));
            return Json(FetchRegist, JsonRequestBehavior.AllowGet);
        }
        // <--------   End of Customer Details -------->

        // @@@@@@@@@@@ Product Details @@@@@@@@@@@@


        #region Product Category
        public JsonResult CategoryNameExistOrNot(Product_Catagory pc)
        {
            int rslt;

            object obj = ac.CategoryNameExistOrNot(pc);
            if (obj != null)
            {
                rslt = 0;

            }
            else
            {
                rslt = 1;

            }
            return Json(rslt, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddProduct_category()
        {
            ViewBag.CatagoryList = db.Product_Catagory.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct_category(Product_Catagory pc)
        {
            if (pc.C_ID != 0)
            {
                db.Entry(pc).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                //  TempData["SaveRegMsg"] = "Data updated successfully...!";
            }



            ViewBag.CatagoryList = db.Product_Catagory.ToList();
            return View();
        }
        public ActionResult Add_Product_Catagory(Product_Catagory pc)
        {
            if (pc.C_ID == 0)
            {

                db.Product_Catagory.Add(pc);
                db.SaveChanges();

                // TempData["SaveRegMsg"] = "Data inserted successfully...!";
            }
            return RedirectToAction("AddProduct_category");
        }
        public JsonResult Fetch_Product_Catagory(int ID)
        {
            //   var FetchRegist = db.Registration.ToList().Find(x => x.RID.Equals(ID));
            var delobj = db.Product_Catagory.Where(p => p.C_ID == ID).SingleOrDefault();

            return Json(delobj, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteCatagory(int id)
        {


            var delobj = db.Product_Catagory.Where(p => p.C_ID == id).SingleOrDefault();
            db.Product_Catagory.Remove(delobj);
            db.SaveChanges();

            //  TempData["SaveRegMsg"] = "Data deleted successfully...!";

            return RedirectToAction("AddProduct_category");
        }
        #endregion



        #region Product Details
        public ActionResult ListProductDeatails()
        {
            //   ViewBag.ListPrdctDtl = db.ProductDetails.ToList();
            ViewBag.ListPrdctDtl = (from s1 in db.ProductDetails
                                    join s2 in db.Mesurement on s1.PDMeasurement equals s2.MID
                                    join s3 in db.TypesOfGoods on s1.PDTypeGoods equals s3.TOGID
                                    join s4 in db.ProductGST on s1.GstPercent equals s4.ProdGstID
                                    join s5 in db.Product_Catagory on s1.Category_ID equals s5.C_ID
                                    join s6 in db.Wearhouse on s1.WearhouseRefId equals s6.Id

                                    select new ProductDetailsVM { ProductDetails = s1, Mesurement = s2, TypesOfGoods = s3, ProductGST = s4, Product_Catagory = s5, Wearhouse = s6 }).ToList();

            // <--------- DropdownList ----------->
            ViewBag.MesurementList = new SelectList(db.Mesurement.ToList(), "MID", "MesureType");
            ViewBag.TypeOfGoodsList = new SelectList(db.TypesOfGoods.ToList(), "TOGID", "TypeOfGoodsName");
            ViewBag.ProductGst = new SelectList(db.ProductGST.ToList(), "ProdGstID", "ProdGst");
            ViewBag.ProductCategory = new SelectList(db.Product_Catagory.ToList(), "C_ID", "Category_Name");

            ViewBag.WearhouseList = new SelectList(db.Wearhouse.ToList(), "Id", "Name");



            return View();
        }
        public ActionResult CreateProductDetails(ProductDetails pd)
        {
            db.ProductDetails.Add(pd);
            db.SaveChanges();
            TempData["SaveRegMsg"] = "Data Saved Successfully...!";
            return RedirectToAction("ListProductDeatails");
        }
        public ActionResult EditProductDetails(ProductDetails pd)
        {
            db.Entry(pd).State = System.Data.EntityState.Modified;
            db.SaveChanges();
            TempData["UpdatRegMsg"] = "Data Updated Successfully...!";
            return RedirectToAction("ListProductDeatails");
        }
        public ActionResult DeleteProductDetails(int id)
        {
            ac.DeleteProduct(id);
            return RedirectToAction("ListProductDeatails");
        }


        public JsonResult FetchProductDetails(int ID)
        {
            var FetchProduct = db.ProductDetails.ToList().Find(x => x.PDID.Equals(ID));
            return Json(FetchProduct, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ProducNameExistOrNot(ProductDetails pd)
        {
            int rslt;

            object obj = ac.ProductNameExistOrNot(pd);
            if (obj != null)
            {
                rslt = 0;
            }
            else
            {
                rslt = 1;
            }
            return Json(rslt, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ProducBarcodeNoExistOrNot(string BarcodeNo)
        {
            int rslt;



            var obj = db.ProductDetails.Where(x => x.BarcodeNo == BarcodeNo).FirstOrDefault();

            if (obj != null)
            {
                rslt = 0;
            }
            else
            {
                rslt = 1;
            }
            return Json(rslt, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddProduct_Modal(ProductDetails pd)
        {

            if (pd.PDID != 0)
            {
                ac.EditProductsdtl(pd);
                TempData["SaveMsg"] = "Data Updated Successfully...!";
            }
            else
            {
                db.ProductDetails.Add(pd);
                db.SaveChanges();
                TempData["SaveMsg"] = "Data Saved Successfully...!";
            }

            return Json(TempData["SaveMsg"], JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region Wearhouse
        public ActionResult Wearhouse()
        {

            var wearhouseList = db.Wearhouse.ToList();

            return View(Tuple.Create<Wearhouse, IEnumerable<Wearhouse>>(new Wearhouse(), wearhouseList));
        }

        [HttpPost]
        public ActionResult Wearhouse_AddUpdate([Bind(Prefix = "Item1")] Wearhouse wearhouse)
        {

            try
            {
                if (wearhouse.Id != 0)
                {
                    var wearhouseData = db.Wearhouse.FirstOrDefault(x => x.Id == wearhouse.Id);
                    wearhouseData.Name = wearhouse.Name;
                    wearhouseData.Address = wearhouse.Address;
                    wearhouseData.Status = wearhouse.Status;

                }
                else
                {
                    db.Wearhouse.Add(wearhouse);
                }
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("Wearhouse");
        }

        public ActionResult Wearhouse_Delete(int id)
        {
            try
            {
                var wearhouse = db.Wearhouse.FirstOrDefault(x => x.Id == id);
                if (wearhouse != null)
                {
                    db.Wearhouse.Remove(wearhouse);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("Wearhouse");
        }

        public JsonResult WearhouseGetById(int id)
        {
            var wearhouse = db.Wearhouse.FirstOrDefault(x => x.Id == id);
            return Json(wearhouse, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WearhouseExistance(string wearhouseName)
        {
            bool status = false;
            var wearhouse = db.Wearhouse.FirstOrDefault(x => x.Name == wearhouseName);

            status = (wearhouse == null) ? false : true;
            return Json(status, JsonRequestBehavior.AllowGet);
        }


        #endregion

        //  <------------- End product Details --------->

        // @@@@@@@@@@@@@@ Organization Details @@@@@@@@@@@@


        [HttpPost]
        public JsonResult OrgNameExistOrNot(OrganizationDetails org)
        {
            int rslt;

            object obj = ac.OrgNameExistOrNot(org);
            if (obj != null)
            {
                rslt = 0;

            }
            else
            {
                rslt = 1;

            }
            return Json(rslt, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ActiveStatusOrgnization(int id)
        {
            ac.ActiveStatusRgst(id, "Org");
            return RedirectToAction("ListOrganizationDetails");
        }
        public ActionResult ListOrganizationDetails()
        {
            //  ViewBag.ListOrgDtl = db.OrganizationDetails.ToList();

            ViewBag.ListOrgDtl = (from s1 in db.OrganizationDetails join s2 in db.state on s1.OrgState equals s2.SId join s3 in db.ActivationStatus on s1.OrgStatus equals s3.ActStsID select new ComboPack { OrganizationDetails = s1, state = s2, ActStats = s3 }).ToList();


            ViewBag.ActStatusList = new SelectList(db.ActivationStatus.ToList(), "ActStsID", "ActStsName");

            ViewBag.StateList = new SelectList(db.state.ToList(), "SId", "SName");



            return View();
        }

        [HttpPost]
        public ActionResult CreateOrganizationDetails(OrganizationDetails org, HttpPostedFileBase OrgImg, HttpPostedFileBase SignatureImg)
        {
            ac.AddOrgnizationDetails(org, OrgImg, SignatureImg);
            TempData["SaveRegMsg"] = "Data Saved Successfully...!";
            return RedirectToAction("ListOrganizationDetails");
        }

        public ActionResult EditOrgDetails(OrganizationDetails pd, HttpPostedFileBase OrgImg, HttpPostedFileBase SignatureImg)
        {

            ac.EditOrgnizationDetails(pd, OrgImg, SignatureImg);

            TempData["UpdatRegMsg"] = "Data Updated Successfully...!";
            return RedirectToAction("ListOrganizationDetails");
        }

        public ActionResult DeletOrgnization(int id)
        {
            ac.DeleteOrganization(id);
            return RedirectToAction("ListOrganizationDetails");
        }

        public JsonResult FetchOrgDetails(int ID)
        {
            var FetchOrg = db.OrganizationDetails.ToList().Find(x => x.OrgID.Equals(ID));
            return Json(FetchOrg, JsonRequestBehavior.AllowGet);
        }




        // < -------------- End Organization Datails ----------->



        // @@@@@@@@@@   Purchase Details @@@@@@@@@@@


        // PurchaseForReporting Table



        public JsonResult PurchaseForReports(PurchaseDtl pd)
        {
            int id = 0;

            ViewBag.PurRepExist = db.PurchaseForReport.FirstOrDefault(x => x.PrBillNo == pd.PurBillNo);

            if (ViewBag.PurRepExist != null)
            {
                string BillNo = ViewBag.PurRepExist.PrBillNo;
                if (BillNo != "")
                {
                    id = 1;
                }
            }

            ac.AddPurchaseForReports(pd, id);

            ViewBag.msg = "";
            return Json(ViewBag.msg, JsonRequestBehavior.AllowGet);
        }


        // End

        public ActionResult ListPurchaseDetails()
        {

            //    ViewBag.ListPrchsDtl = (from s1 in db.PurchaseDtl  join s2 in db.CustomerDetails on s1.PurSuppCustId equals s2.CustID join s3 in db.ProductDetails on s1.PurProductID equals s3.PDID  select new ComboPack { PurchaseDtl = s1, CustDtl = s2, ProductDetails = s3 }).ToList();

            // ViewBag.ListPrchsDtl = from s in db.PurchaseDtl group s by s.PurBillNo;

            ViewBag.ListPrchsDtl = ac.ListPurchaseDtl();


            // dropdown Lists
            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");

            ViewBag.ProductList = new SelectList(db.ProductDetails, "PDID", "ProductName");

            ViewBag.ProductGst = new SelectList(db.ProductGST.ToList(), "ProdGstID", "ProdGst");

            ViewBag.TypeOfGoodsList = new SelectList(db.TypesOfGoods.ToList(), "TOGID", "TypeOfGoodsName");












            return View();
        }
        public ActionResult EditPurchaseDetails(PurchaseDtl pd)
        {
            ac.EditPurchaseDeatils(pd);

            return RedirectToAction("ListPurchaseDetails");
        }


        public ActionResult DeletePurchaseDetails(string billNo)
        {
            string bill = billNo;

            ViewBag.Qty_Sum = ac.QuantitySum_TempPurchaseDtl(billNo); // all Product sum

            foreach (var item in ViewBag.Qty_Sum)
            {
                ac.Add_Sub_ProductQty(item.PurProductID, item.QtySum, "Sub");
            }


            ac.DeletePurchaseDetails(billNo);
            ac.DeletePurchaseForReports(billNo);
            ac.DeletePurchaseReportBills(billNo);



            return RedirectToAction("ListPurchaseDetails");
        }

        // Add all data from temp Data
        public ActionResult CreateTempdataDetails(string BillNo)
        {
            ViewBag.ListPrchsDtl = (from s1 in db.PurchaseDtl
                                    join s2 in db.CustomerDetails on s1.PurSuppCustId equals s2.CustID
                                    join s3 in db.PurchaseDtlPurchaseReportBill on s1.PurBillNo equals s3.PrRBBillNo
                                    join s4 in db.PurchaseForReport on s1.PurBillNo equals s4.PrBillNo
                                    where s1.PurBillNo == BillNo
                                    select new ComboPack { PurchaseDtl = s1, CustDtl = s2, PurchaseReportBill = s3, PurchaseForReport = s4 }).FirstOrDefault();

            string CustSuppName = ViewBag.ListPrchsDtl.CustDtl.CustName;
            string CustSuppBillNo = ViewBag.ListPrchsDtl.PurchaseDtl.PurBillNo;
            DateTime CustSuppDateTime = ViewBag.ListPrchsDtl.PurchaseDtl.PurDate;

            decimal DiscountPer = ViewBag.ListPrchsDtl.PurchaseReportBill.PrRBDiscountPer;
            decimal DiscountRs = ViewBag.ListPrchsDtl.PurchaseReportBill.PrRBDiscountRs;
            decimal Charges = ViewBag.ListPrchsDtl.PurchaseReportBill.PrRBCharges;

            decimal GrandTotal = ViewBag.ListPrchsDtl.PurchaseForReport.PrGrandTotal;
            decimal FinalTotal = ViewBag.ListPrchsDtl.PurchaseForReport.PrFinalTotal;


            PurchaseDtl pd = new PurchaseDtl();

            pd.SplrCustName = CustSuppName;
            pd.PurBillNo = CustSuppBillNo;
            pd.PurDate = CustSuppDateTime;
            pd.DiscPer = DiscountPer;
            pd.DiscRs = DiscountRs;
            pd.Charges = Charges;

            pd.GrandTot = GrandTotal;
            pd.TotalAmt = FinalTotal;


            var purchaseList = (from s1 in db.PurchaseDtl where s1.PurBillNo == BillNo select new ComboPack { PurchaseDtl = s1 }).ToList();
            ac.DeletePurchaseDeatils(); // Clear Temp table data


            foreach (var item in purchaseList)
            {
                TempDataPurchase prdtl = new TempDataPurchase();

                prdtl.TempPurSuppCustName = item.PurchaseDtl.PurSuppCustId;
                prdtl.TempPurBillNo = item.PurchaseDtl.PurBillNo;
                prdtl.TempPurProductID = item.PurchaseDtl.PurProductID;
                prdtl.TempPurProductRate = item.PurchaseDtl.PurProductRate;

                prdtl.TempPurDiscount = item.PurchaseDtl.PurDiscount;
                prdtl.TempPurQuantity = item.PurchaseDtl.PurQuantity;

                prdtl.TempPurGstRs = item.PurchaseDtl.PurGstRs;
                prdtl.TempPurTotal = item.PurchaseDtl.PurTotal;
                prdtl.TempPurDate = item.PurchaseDtl.PurDate;
                prdtl.WearhouseRefID = item.PurchaseDtl.WearhouseRefID;

                ac.AddTempPurchaseIntoPurchase(prdtl);

            }

            //ac.DeletePurchaseDeatils(BillNo);
            //ac.DeletePurchaseForReports(BillNo);

            return RedirectToAction("AddPurchaseDetails", pd);
        }
        // End Temp Data



        public ActionResult Trash_TempPurchase()
        {
            ac.DeletePurchaseDeatils();
            return RedirectToAction("AddPurchaseDetails");
        }





        // Temp table data

        public JsonResult BillnoExistorNot(string BillNo)
        {
            int rslt;

            object obj1 = ac.BillnoExistorNot(BillNo);
            if (obj1 != null)
            {
                rslt = 1;

            }
            else
            {
                object obj2 = ac.BillnoExistorNotInTempData(BillNo);
                if (obj2 != null)
                {
                    rslt = 2;

                }
                else
                {
                    rslt = 0;
                }


            }
            return Json(rslt, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TempOrgNameExistorNot(string id)
        {
            int rslt = 5;

            string ids = "";

            ViewBag.cust = db.CustomerDetails.Where(t => t.CustName.Equals(id)).FirstOrDefault();

            try
            {
                if (ViewBag.cust.CustID != null)
                {
                    ids = ViewBag.cust.CustID;
                }
            }
            catch (Exception ex)
            {

                string es = ex.ToString();
            }




            if (ids != "")
            {


                object obj = ac.TempOrgNameExistorNot(Convert.ToInt32(ids));
                if (obj != null)
                {
                    rslt = 1;
                }
                else
                {
                    rslt = 2;
                }
            }




            return Json(rslt, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AutoCustOrgName(string search)
        {
            List<AutoDropdown> allsearch = db.CustomerDetails.Where(x => x.CustName.Contains(search)).Select(x => new AutoDropdown
            {
                Id = x.CustID,
                Name = x.CustName
            }).ToList();
            return new JsonResult { Data = allsearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult AutoProductName(string search)
        {
            List<AutoDropdown> allsearch = db.ProductDetails.Where(x => x.ProductName.Contains(search)).Select(x => new AutoDropdown
            {
                Id = x.PDID,
                Name = x.ProductName
            }).ToList();
            return new JsonResult { Data = allsearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult FetchProductDetailByName(PurchaseDtl pd)
        {
            var FetchProduct = db.ProductDetails.FirstOrDefault(x => x.ProductName == pd.ProductSelection);

            return Json(FetchProduct, JsonRequestBehavior.AllowGet);
        }

        public JsonResult FetchProductDetailByBarcodeNo(string BarcodeNo)
        {
            var FetchProduct = db.ProductDetails.Where(x => x.BarcodeNo == BarcodeNo).FirstOrDefault();



            if (FetchProduct == null)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(FetchProduct, JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult FetchProductDetailByProductName(string ProductName)
        {
            var FetchProduct = db.ProductDetails.Where(x => x.ProductName == ProductName).FirstOrDefault();
            return Json(FetchProduct, JsonRequestBehavior.AllowGet);
        }




        public ActionResult AddPurchaseDetails(PurchaseDtl pd)
        {

            PurchaseDtl pdBnd = new PurchaseDtl();

            string CustSuppName = pd.SplrCustName;
            // string datess =Convert.ToString(pd.PurDate);
            pdBnd.SplrCustName = pd.SplrCustName;
            pdBnd.PurBillNo = pd.PurBillNo;
            pdBnd.dateInStrFormate = Convert.ToDateTime(pd.PurDate).ToString("yyyy-MM-dd");
            pdBnd.DiscPer = pd.DiscPer;
            pdBnd.DiscRs = pd.DiscRs;
            pdBnd.Charges = pd.Charges;
            pdBnd.GrandTot = pd.GrandTot;
            pdBnd.TotalAmt = pd.TotalAmt;

            ViewBag.ListTempPrchsDtl = (from s1 in db.TempDataPurchase join s2 in db.CustomerDetails on s1.TempPurSuppCustName equals s2.CustID join s3 in db.ProductDetails on s1.TempPurProductID equals s3.PDID select new ComboPack { TempDataPurchase = s1, CustDtl = s2, ProductDetails = s3 }).ToList();
            ViewBag.ProductGst = new SelectList(db.ProductGST.ToList(), "ProdGstID", "ProdGst");
            ViewBag.TypeOfGoodsList = new SelectList(db.TypesOfGoods.ToList(), "TOGID", "TypeOfGoodsName");



            // <--------- DropdownList ----------->
            ViewBag.MesurementList = new SelectList(db.Mesurement.ToList(), "MID", "MesureType");
            ViewBag.TypeOfGoodsList = new SelectList(db.TypesOfGoods.ToList(), "TOGID", "TypeOfGoodsName");
            ViewBag.ProductGst = new SelectList(db.ProductGST.ToList(), "ProdGstID", "ProdGst");
            ViewBag.ProductCategory = new SelectList(db.Product_Catagory.ToList(), "C_ID", "Category_Name");
            ViewBag.WearhouseList = new SelectList(db.Wearhouse.ToList(), "Id", "Name");


            return View(pd);
        }



        public JsonResult AddPurchaseReportBill(PurchaseDtl pd)
        {

            ViewBag.TempPurList = db.TempDataPurchase.FirstOrDefault();

            if (ViewBag.TempPurList != null)
            {

                string BillNo = ViewBag.TempPurList.TempPurBillNo;
                if (BillNo != "")
                {
                    pd.PurBillNo = BillNo;
                    ac.AddPurchaseReportBill(pd);
                }

            }

            return Json(ViewBag.Billno, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AfterSaveRedirect()
        {
            ViewBag.Billno = db.TempDataPurchase.FirstOrDefault();
            return Json(ViewBag.Billno, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Check_TempPurchaseEmpty()
        {
            int rslt = 0;

            ViewBag.TempPur = db.TempDataPurchase.FirstOrDefault();
            if (ViewBag.TempPur != null)
            {
                rslt = 1;
            }

            return Json(rslt, JsonRequestBehavior.AllowGet);
        }



        public JsonResult TempPurchaseList()
        {
            ViewBag.ListTempPrchsDtl = (from s1 in db.TempDataPurchase 
                                        join s2 in db.CustomerDetails on s1.TempPurSuppCustName equals s2.CustID 
                                        join s3 in db.ProductDetails on s1.TempPurProductID equals s3.PDID 
                                        join s4 in db.ProductGST on s3.GstPercent equals s4.ProdGstID 
                                        join s5 in db.Wearhouse on s1.WearhouseRefID equals s5.Id 
                                        select new ProductDetailsVM
                                        { 
                                            TempDataPurchase = s1,
                                            CustomerDetails = s2, 
                                            ProductDetails = s3,
                                            ProductGST = s4, 
                                            Wearhouse = s5 
                                        }).ToList();

            return Json(ViewBag.ListTempPrchsDtl, JsonRequestBehavior.AllowGet);
        }

        // Gst Calculation
        public JsonResult TotalsTempPurchaseList()
        {

            decimal Fgrandtotal, TotalDiscount, GstTotal, SumofQuntity, RowCount, ProductRate;

            TempData["SumofQantity"] = ac.SumOfQuntPurchaseDtl();
            TempData["TotalDisc"] = ac.TotalDiscountPurchaseDtl();
            TempData["Rowcount"] = ac.RowCountPurchaseDtl();
            TempData["ProductRate"] = ac.SumOfProductRatePurchaseDtl();
            TempData["TotalGst"] = ac.SumOfProductGSTPurchaseDtl();
            TempData["GrandTotal"] = ac.SumOfPurTotalDtl();


            // varialble of post 
            RowCount = Convert.ToInt32(TempData["Rowcount"]);


            if (RowCount != 0)
            {

                SumofQuntity = Convert.ToDecimal(TempData["SumofQantity"]);
                TotalDiscount = Convert.ToDecimal(TempData["TotalDisc"]);
                RowCount = Convert.ToInt32(TempData["Rowcount"]);
                ProductRate = Convert.ToDecimal(TempData["ProductRate"]);
                GstTotal = Convert.ToDecimal(TempData["TotalGst"]);
                Fgrandtotal = Convert.ToDecimal(TempData["GrandTotal"]);

            }
            else
            {
                SumofQuntity = 0;
                TotalDiscount = 0;
                RowCount = 0;
                ProductRate = 0;
                GstTotal = 0;
                Fgrandtotal = 0;
            }

            //  decimal gstamt = Fgrandtotal * GstTotal / 100;  // Gst amt

            decimal finaltot = Fgrandtotal + GstTotal;  // Final amt


            decimal[] data = new decimal[7];

            data[0] = SumofQuntity;  // not required
            data[1] = RowCount;      // not required
            data[2] = ProductRate;   // not required (total product rate)

            data[3] = Fgrandtotal;
            data[4] = GstTotal;
            data[5] = finaltot;

            data[6] = TotalDiscount;  // not required (Sum of total discou)

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        // End Gst Calculation

        public JsonResult AddTempData(PurchaseDtl pd)
        {

            // here we are getting (ProductID & SupplierID)
            pd.PurProductID = db.ProductDetails.FirstOrDefault(x => x.ProductName == pd.ProductSelection).PDID;
            pd.PurSuppCustId = db.CustomerDetails.FirstOrDefault(t => t.CustName == pd.SplrCustName).CustID;
            // End 

            // here getting id of Customer
            pd.ProductGst = db.ProductGST.FirstOrDefault(x => x.ProdGstID == (int)pd.ProductGst).ProdGst; // get Gast in Percentage
                                                                                                          // End

            if (pd.PurID != 0)
            {
                ac.EditTempPurchaseDeatils(pd);
            }
            else
            {
                ac.AddTempPurchaseDeatils(pd); // save data
            }

            List<TempDataPurchase> tempPurchaseList = db.TempDataPurchase.ToList();
            foreach (TempDataPurchase p in tempPurchaseList)
            {
                p.TempPurDate = pd.PurDate;
                p.TempPurSuppCustName = pd.PurSuppCustId;
                p.TempPurBillNo = pd.PurBillNo;
            }
            db.SaveChanges();

            return Json("", JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteTempData(int id)
        {
            ac.DeleteTempData(id);

            ViewBag.ListTempPrchsDtl = "Hi";


            return Json(ViewBag.ListTempPrchsDtl, JsonRequestBehavior.AllowGet);
        }


        // Add the all data from TempDataPurchase Table
        public JsonResult CreatePurchaseDetails()
        {

            string billNumber = db.TempDataPurchase.FirstOrDefault().TempPurBillNo;

            if (billNumber != null)
            {

                int C_Purch = ac.Count_PurchaseDtls(billNumber);

                if (C_Purch != 0)
                {
                    ViewBag.Qty_Sum = ac.QuantitySum_TempPurchaseDtl(billNumber); // all Product sum
                    foreach (var item in ViewBag.Qty_Sum)
                    {
                        ac.Add_Sub_ProductQty(item.PurProductID, item.QtySum, "Sub");
                    }
                }
                ac.Delete_PurchaseDtls(billNumber);
            }


            var purchaseList = db.TempDataPurchase.ToList();

            var qtySumList = ac.QuantitySum_TempPurchaseDtl(); // all Product sum

            foreach (var item in qtySumList)
            {
                ac.Add_Sub_ProductQty(item.PurProductID, item.QtySum, "Add"); // opening stock
            }




            foreach (var item in purchaseList)
            {
                PurchaseDtl prdtl = new PurchaseDtl();

                prdtl.PurSuppCustId = item.TempPurSuppCustName;
                prdtl.PurBillNo = item.TempPurBillNo;
                prdtl.PurProductID = item.TempPurProductID;
                prdtl.PurProductRate = item.TempPurProductRate;
                prdtl.PurDiscount = item.TempPurDiscount;
                prdtl.PurQuantity = item.TempPurQuantity;
                prdtl.PurGstRs = item.TempPurGstRs;
                prdtl.PurTotal = item.TempPurTotal;
                prdtl.PurDate = item.TempPurDate;
                prdtl.WearhouseRefID = item.WearhouseRefID;

                ac.AddPurchaseDeatils(prdtl);
            }

            ac.DeletePurchaseDeatils();


            return Json("", JsonRequestBehavior.AllowGet);
        }

        // End

        public JsonResult FetchTempPurchaseDetails(int ID)
        {
            var FetchRegist = db.TempDataPurchase.ToList().Find(x => x.TempPurID.Equals(ID));
            return Json(FetchRegist, JsonRequestBehavior.AllowGet);
        }
        public JsonResult FetchPurchaseDetails(int ID)
        {
            ViewBag.PurchaseData = (from s1 in db.TempDataPurchase
                                    join s2 in db.CustomerDetails on s1.TempPurSuppCustName equals s2.CustID
                                    join s3 in db.ProductDetails on s1.TempPurProductID equals s3.PDID
                                    where s1.TempPurID == ID
                                    select new ProductDetailsVM
                                    {
                                        TempDataPurchase = s1,
                                        CustomerDetails = s2,
                                        ProductDetails = s3,
                                    }).FirstOrDefault();


            return Json(ViewBag.PurchaseData, JsonRequestBehavior.AllowGet);
        }

        // End







        // <------ End Purchase Details ------->

        // @@@@@@@ Old Purchase Rate @@@@@@

        public ActionResult OldPurchaseRate()
        {
            //   ViewBag.ListOldPrchsDtl = db.PurchaseOldRate.ToList();
            ViewBag.ListOldPrchsDtl = (from s1 in db.PurchaseOldRate join s2 in db.ProductDetails on s1.PName equals s2.PDID join s3 in db.CustomerDetails on s1.SupplierName equals s3.CustID select new ComboPack { PurchaseOldRate = s1, ProductDetails = s2, CustDtl = s3 }).ToList();


            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");
            ViewBag.ProductList = new SelectList(db.ProductDetails, "PDID", "ProductName");


            return View();
        }


        public ActionResult AddOldPurchaseDetails(PurchaseOldRate por)
        {
            ac.AddOldPurchaseRate(por);
            TempData["SaveRegMsg"] = "Data Saved Successfully...!";
            return RedirectToAction("OldPurchaseRate");
        }

        public ActionResult EditOldPurchaseDetails(PurchaseOldRate por)
        {
            ac.EditOldPurchaseRate(por);
            TempData["UpdatRegMsg"] = "Data Updated Successfully...!";
            return RedirectToAction("OldPurchaseRate");
        }
        public ActionResult DeleteOldPurchaseRate(int id)
        {
            ac.DeleteOldPurchaseRate(id);
            return RedirectToAction("OldPurchaseRate");
        }

        public JsonResult FetchOldPurchaseRateDtl(int ID)
        {
            ViewBag.OldPurchaseRate = (from s1 in db.PurchaseOldRate join s2 in db.ProductDetails on s1.PName equals s2.PDID join s3 in db.CustomerDetails on s1.SupplierName equals s3.CustID where s1.PORID == ID select new ComboPack { PurchaseOldRate = s1, ProductDetails = s2, CustDtl = s3 }).FirstOrDefault();

            return Json(ViewBag.OldPurchaseRate, JsonRequestBehavior.AllowGet);
        }


        // <------   End Old Purchase Rate ------->


        // @@@@ Payment from supplier @@@@@@@



        //// New
        public ActionResult ListSuppCustPaymentDetails(PurchaseDtl pd)
        {


            ViewBag.ListSplrPymtDtl = ac.ListCustSuppPayments();



            CustSuppPayment pfs = new CustSuppPayment();

            pfs.SupCustID = pd.PurSuppCustId;
            pfs.SupCustBillNo = pd.PurBillNo;
            pfs.SupCustBillAmt = pd.TotalAmt;
            pfs.Existance = pd.Existance;


            return View(pfs);
        }



        // Garbage
        public ActionResult PassPaymentFromSupplier(PurchaseDtl pd)
        {
            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");
            ViewBag.PayMethodList = new SelectList(db.PaymentMethod, "PayMId", "PayMName");
            ViewBag.PayStatusList = new SelectList(db.PaymentStatus, "PayStId", "PayStName");

            PaymentFromSupplier pfs = new PaymentFromSupplier();

            pfs.PFSName = pd.PurSuppCustId;
            pfs.PFSBillNumber = pd.PurBillNo;
            pfs.PFSBillAmount = pd.TotalAmt;


            return View(pfs);
        }

        // end garbage

        public JsonResult FetchBillDtl(string BillNo)
        {

            var lst = (from s1 in db.PurchaseDtl
                       join s2 in db.CustomerDetails on s1.PurSuppCustId equals s2.CustID
                       join s3 in db.PurchaseForReport on s1.PurBillNo equals s3.PrBillNo
                       where s1.PurBillNo == BillNo
                       select new
                       {
                           s1.PurSuppCustId,
                           s2.CustName,
                           s3.PrFinalTotal
                       }).FirstOrDefault();

            if (lst != null)
            {
                return Json(lst, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }



        }

        public ActionResult AddPaymentFromSupplier(CustSuppPayment csp)
        {
            ViewBag.Existance = db.CustSuppPayment.ToList().Find(x => x.SupCustBillNo == csp.SupCustBillNo);

            if (ViewBag.Existance == null)
            {

                var validate = db.PurchaseDtl.Where(x => x.PurBillNo == csp.SupCustBillNo).FirstOrDefault();

                if (validate != null)
                {
                    ac.AddPaymentfromSupplier(csp);
                    TempData["SaveRegMsg"] = "Data Saved Successfully...!";
                }
            }

            return RedirectToAction("ListSuppCustPaymentDetails");
        }
        public JsonResult FetchPaymentFromSupplierDtl(int ID)
        {
            ViewBag.ListSplrPymtDtl = (from s1 in db.CustSuppPayment join s2 in db.CustomerDetails on s1.SupCustID equals s2.CustID join s3 in db.PaymentStatus on s1.SupCustStatus equals s3.PayStId where s1.SupCustPayID == ID select new ComboPack { CustSuppPayment = s1, CustDtl = s2, PaymentStatus = s3 }).FirstOrDefault();

            return Json(ViewBag.ListSplrPymtDtl, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdatePaymentFromSupplier(CustSuppPayment csp)
        {
            ac.UpdatePaymentfromSupplier(csp);
            return RedirectToAction("ListSuppCustPaymentDetails");
        }
        public ActionResult DeletePaymentfromSupplier(int id)
        {


            var BillData = db.CustSuppPayment.Where(x => x.SupCustPayID == id).FirstOrDefault();

            string BillNo = BillData.SupCustBillNo;

            ac.DeletePaymentfromSupplier(id);
            ac.Delete_Transaction_Purchase(BillNo);

            return RedirectToAction("ListSuppCustPaymentDetails");
        }








        // Transaction List


        public ActionResult ListCustSupTransaction(string BillNo)
        {

            if (BillNo == null)
            {
                return RedirectToAction("ListSuppCustPaymentDetails");
            }

            Session["BillNo"] = BillNo;

            ViewBag.ListCustSupTransaction = (from s1 in db.CustSupTransaction join s2 in db.CustomerDetails on s1.CustSuppId equals s2.CustID join s3 in db.PaymentMethod on s1.TranPayMethod equals s3.PayMId where s1.TranBillNo == BillNo select new ComboPack { CustSupTransaction = s1, CustDtl = s2, PaymentMethod = s3 }).ToList();

            ViewBag.BillAmtList = db.PurchaseForReport.ToList().Find(x => x.PrBillNo == BillNo);

            if (ViewBag.BillAmtList != null)
            {
                ViewBag.BillAmt = ViewBag.BillAmtList.PrFinalTotal; // Bill Amt
            }
            else
            {
                ViewBag.BillAmt = 0;
            }

            ViewBag.SumOfReciAmt = ac.SumOfReciAmt(BillNo);

            //DropdownList 
            ViewBag.ListPaymentMethod = new SelectList(db.PaymentMethod.ToList(), "PayMId", "PayMName");
            return View();
        }
        public ActionResult AddCustSuppTransaction(CustSupTransaction csp)
        {
            string Billno = Session["BillNo"].ToString();

            ViewBag.CustSuppList = db.PurchaseDtl.FirstOrDefault(x => x.PurBillNo == Billno);
            csp.TranBillNo = Billno;

            if (ViewBag.CustSuppList != null)
            {
                csp.CustSuppId = ViewBag.CustSuppList.PurSuppCustId;
                ac.AddTransaction(csp);
            }



            string Billnos = Session["BillNo"].ToString();

            TempData["SaveRegMsg"] = "Data Saved Successfully...!";

            return RedirectToAction("ListCustSupTransaction", new { BillNo = Billnos });
        }
        public JsonResult FetchCustSuppTransaction(int ID)
        {
            ViewBag.ListSplrPymtDtl = (from s1 in db.CustSupTransaction join s2 in db.CustomerDetails on s1.CustSuppId equals s2.CustID join s3 in db.PaymentMethod on s1.TranPayMethod equals s3.PayMId where s1.TranId == ID select new ComboPack { CustSupTransaction = s1, CustDtl = s2, PaymentMethod = s3 }).FirstOrDefault();

            return Json(ViewBag.ListSplrPymtDtl, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateCustSuppTransaction(CustSupTransaction csp)
        {
            ac.UpdateTransaction(csp);
            string Billnos = Session["BillNo"].ToString();
            TempData["UpdatRegMsg"] = "Data Updated Successfully...!";
            return RedirectToAction("ListCustSupTransaction", new { BillNo = Billnos });
        }
        public ActionResult DeleteCustSuppTransaction(int id)
        {
            ac.DeleteTransaction(id);
            string Billnos = Session["BillNo"].ToString();
            return RedirectToAction("ListCustSupTransaction", new { BillNo = Billnos });
        }

        //end
        // <---------- End payment from supplier @@@@@

        // @@@@@@@@@@@@@  Add Terms And Conditions @@@@@@@@@@
        public ActionResult TermsAndConditions()
        {
            ViewBag.TermsAndCondition = (from s1 in db.TermsCondition join s2 in db.BillTypes on s1.BTID equals s2.BTID select new ComboPack { TermsCondition = s1, BillTypes = s2 }).ToList();
            // DropdownList 
            ViewBag.BillType = new SelectList(db.BillTypes.ToList(), "BTID", "BillTypeName");
            return View();
        }
        public ActionResult AddEditTermsCondition(TermsCondition tc)
        {
            ac.AddEditTermsnConditions(tc);


            if (tc.TCID == 0)
            {
                TempData["SaveRegMsg"] = "Data Saved Successfully...!";
            }
            else
            {
                TempData["UpdatRegMsg"] = "Data Updated Successfully...!";
            }




            return RedirectToAction("TermsAndConditions");
        }
        public ActionResult DeleteTermsAndConditions(int ID)
        {
            ac.DeleteTnC(ID);
            return RedirectToAction("TermsAndConditions");
        }
        public JsonResult FetchTnc(int ID)
        {
            ViewBag.TermsAndCondition = db.TermsCondition.FirstOrDefault(x => x.TCID == ID);
            return Json(ViewBag.TermsAndCondition, JsonRequestBehavior.AllowGet);
        }
        // <------------- End Add Terms And Conditions ---------->


        // @@@______________ Sales Bill Without GST ______________@@@

        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult ListSaleBillWithoutGst()
        {
            ViewBag.ListSaleWiGstDtl = ac.ListSaleWiGstDtl();

            return View();
        }

        public ActionResult SaveRedirection_To_Add(int? id)
        {
            // TempData["Msg"] = id;

            return RedirectToAction("ListSaleBillWithoutGst", "Admin");
        }



        // Load Data 
        public JsonResult ListTempSalesBillWithoutGstDtls()
        {
            ViewBag.ListTempPrchsDtl = (from s1 in db.TempSalesBillWithoutGstDtl
                                        join s2 in db.CustomerDetails on s1.SalBilWiGSTSuppCustId equals s2.CustID
                                        join s3 in db.ProductDetails on s1.SalBilWiGSTProductID equals s3.PDID
                                        join s4 in db.ProductGST on s3.GstPercent equals s4.ProdGstID
                                        join s5 in db.Wearhouse on s1.WearhouseRefId equals s5.Id

                                        select new SaleWithoutGstVM
                                        {
                                            TempSalesBillWithoutGstDtl = s1,
                                            CustDtl = s2,
                                            ProductDetails = s3,
                                            ProductGST = s4,
                                            Wearhouse = s5
                                        }).ToList();


            //  ViewBag.ListTempPrchsDtl = db.TempSalesBillWithoutGstDtl.ToList();


            return Json(ViewBag.ListTempPrchsDtl, JsonRequestBehavior.AllowGet);
        }

        // Add all data from temp Data on Edit option


        public ActionResult CreateTempSaleWiGstDetails(string BillNo)
        {
            ViewBag.ListSaleWiGstDtl = (from s1 in db.SalesBillWithoutGstDtl
                                        join s2 in db.CustomerDetails on s1.SalBilWiGSTSuppCustId equals s2.CustID
                                        join s3 in db.SalesBillWithoutGstDtl_ChargesDisc on s1.SalBilWiGSTBillNo equals s3.SalBiWiGst_BillNo
                                        where s1.SalBilWiGSTBillNo == BillNo
                                        select new ComboPack { SalesBillWithoutGstDtl = s1, CustDtl = s2, SalesBillWithoutGstDtl_ChargesDisc = s3 }).FirstOrDefault();

            TempSalesBillWithoutGstDtl Tsd = new TempSalesBillWithoutGstDtl();

            string CustSuppName, CustSuppBillNo, ChargesName, Notes;
            decimal DiscountPer, DiscountRs, Charges;
            int Pay_Status;
            DateTime CustSuppDateTime;

            if (ViewBag.ListSaleWiGstDtl != null)
            {
                CustSuppName = ViewBag.ListSaleWiGstDtl.CustDtl.CustName;
                CustSuppBillNo = ViewBag.ListSaleWiGstDtl.SalesBillWithoutGstDtl.SalBilWiGSTBillNo;
                CustSuppDateTime = ViewBag.ListSaleWiGstDtl.SalesBillWithoutGstDtl.SalBilWiGSTDate;
                DiscountPer = ViewBag.ListSaleWiGstDtl.SalesBillWithoutGstDtl_ChargesDisc.SalBiWiGst_DiscountPer;
                DiscountRs = ViewBag.ListSaleWiGstDtl.SalesBillWithoutGstDtl_ChargesDisc.SalBiWiGst_DiscountRs;
                ChargesName = ViewBag.ListSaleWiGstDtl.SalesBillWithoutGstDtl_ChargesDisc.SalBiWiGst_ChargesName;
                Charges = ViewBag.ListSaleWiGstDtl.SalesBillWithoutGstDtl_ChargesDisc.SalBiWiGst_ChargesAmt;
                Notes = ViewBag.ListSaleWiGstDtl.SalesBillWithoutGstDtl_ChargesDisc.SalBiWiGst_Note;
                Pay_Status = ViewBag.ListSaleWiGstDtl.SalesBillWithoutGstDtl_ChargesDisc.SalBiWiGst_Status;




                Tsd.SalBilWiGSTSplrCustName = CustSuppName;
                Tsd.SalBilWiGSTBillNo = CustSuppBillNo;
                Tsd.SalBilWiGSTDate = CustSuppDateTime;

                Tsd.SalBilWiGSTDiscPer = DiscountPer;
                Tsd.SalBilWiGSTDiscRs = DiscountRs;
                Tsd.SalBilWiGSTChargesName = ChargesName;
                Tsd.SalBilWiGSTChargesAmt = Charges;

                Tsd.SalBiWiGst_Note = Notes;
                Tsd.SalBiWiGst_Status = Pay_Status;

                Tsd.Update_Status = "Update";


            }

            var saleWithoutGstProductList = db.SalesBillWithoutGstDtl.Where(x => x.SalBilWiGSTBillNo == BillNo).ToList();

            ac.DeleteTempSaleDeatils();

            foreach (var item in saleWithoutGstProductList)
            {
                TempSalesBillWithoutGstDtl Tsb = new TempSalesBillWithoutGstDtl();

                Tsb.SalBilWiGSTSuppCustId = item.SalBilWiGSTSuppCustId;
                Tsb.SalBilWiGSTBillNo = item.SalBilWiGSTBillNo;
                Tsb.SalBilWiGSTProductID = item.SalBilWiGSTProductID;
                Tsb.SalBilWiGSTProductRate = item.SalBilWiGSTProductRate;
                Tsb.SalBilWiGSTQuantity = item.SalBilWiGSTQuantity;
                Tsb.SalBilWiGSTGstRs = item.SalBilWiGSTGstRs;
                Tsb.SalBilWiGSTTotal = item.SalBilWiGSTTotal;
                Tsb.SalBilWiGSTDate = item.SalBilWiGSTDate;
                Tsb.WearhouseRefId = item.WearhouseRefId;

                ac.AddTempSaleWiGst(Tsb);
            }


            return RedirectToAction("AddSaleBillWithoutGst", Tsd);
        }
        // End Temp Data


        public ActionResult Delete_SaleBillWithoutGst(string BillNo)
        {

            //    ViewBag.Qty_Sum = ac.QuantitySum_TempPurchaseDtl(BillNo); // all Product sum

            ViewBag.Qty_Sum = ac.QuantitySum_Temp_SaleWithoutGST(BillNo);


            foreach (var item in ViewBag.Qty_Sum)
            {
                ac.Add_Sub_ProductQty(item.SalBilWiGSTProductID, item.QtySum, "Add");
            }



            ac.DeleteSaleWiGstDetails(BillNo);
            ac.DeleteSalesBillWithoutGstDtl_Report(BillNo);
            ac.Delete_SaleWiGst(BillNo);
            ac.DeleteTermsNconditonsWiGst(BillNo);


            return RedirectToAction("ListSaleBillWithoutGst");
        }


        public JsonResult Check_TempSaleWithoutGSTEmpty()
        {
            int rslt = 0;
            ViewBag.TempSaleWithoutGst = db.TempSalesBillWithoutGstDtl.FirstOrDefault();

            if (ViewBag.TempSaleWithoutGst != null)
            {
                rslt = 1;
            }

            return Json(rslt, JsonRequestBehavior.AllowGet);
        }





        // <------------ this is Add form --------------->
        public JsonResult BillNoGenerator()
        {
            int bill_No = 1;

            string BillNo = ac.BarcodeGenrator();

            if (BillNo != "")
            {
                string str1, str2;
                str1 = BillNo;
                str2 = "";

                int length = BillNo.Length;

                for (int i = 2; i < length; i++)
                {
                    if (str1[i] == '/')
                    {
                        break;
                    }
                    str2 += str1[i];
                }

                string st = str2;
                bill_No = Convert.ToInt32(st);
                bill_No++;
            }



            return Json(bill_No, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaleWiGstTnC(FormCollection formCollection)
        {
            ViewBag.SaleWiGst_Existance = db.TempSalesBillWithoutGstDtl.FirstOrDefault();


            string BillNo = "";

            if (ViewBag.SaleWiGst_Existance != null)
            {
                BillNo = ViewBag.SaleWiGst_Existance.SalBilWiGSTBillNo;
            }



            if (BillNo != "")
            {
                ac.DeleteTermsNconditonsWiGst(BillNo);
            }

            string billno = formCollection["autoBillno"];

            string ID = formCollection["ID"];

            if (ID != null)
            {
                string[] ids = formCollection["ID"].Split(new char[] { ',' });

                foreach (string id in ids)
                {
                    ac.AddEdit_SaleWiGstTnc(int.Parse(id), billno);
                }
            }




            ViewBag.TermsAndCondition = "";
            return Json(ViewBag.TermsAndCondition, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddSaleBillWithoutGst(TempSalesBillWithoutGstDtl Tsb)
        {

            if (Tsb.Update_Status == "Update")
            {
                ViewBag.UpdateMsg = "2";
            }
            else
            {
                ViewBag.UpdateMsg = "1";
            }

            ViewBag.TermsnConditions = ac.ListTnC();

            ViewBag.TncInfo = db.SaleWiGstTnC.Where(x => x.SaleWiGstTnC_BillNo == Tsb.SalBilWiGSTBillNo).ToList();

            ViewBag.PaymentStatus = new SelectList(db.PaymentStatus.ToList(), "PayStId", "PayStName");
            ViewBag.ProductGst = new SelectList(db.ProductGST.ToList(), "ProdGstID", "ProdGst");
            ViewBag.TypeOfGoodsList = new SelectList(db.TypesOfGoods.ToList(), "TOGID", "TypeOfGoodsName");
            ViewBag.MesurementList = new SelectList(db.Mesurement.ToList(), "MID", "MesureType");
            ViewBag.TypeOfGoodsList = new SelectList(db.TypesOfGoods.ToList(), "TOGID", "TypeOfGoodsName");
            ViewBag.ProductCategory = new SelectList(db.Product_Catagory.ToList(), "C_ID", "Category_Name");
            ViewBag.WearhouseList = new SelectList(db.Wearhouse.ToList(), "Id", "Name");

            return View(Tsb);
        }








        // Gst Calculation
        public JsonResult TotalSaleLists()
        {

            decimal Fgrandtotal, TotalDiscount, GstTotal, SumofQuntity, RowCount, ProductRate;

            TempData["SumofQantity"] = ac.SumOfQuntSaleWiGST();

            //      TempData["TotalDisc"] = ac.TotalDiscountPurchaseDtl();

            TempData["Rowcount"] = ac.RowCountSaleWiGst();
            TempData["ProductRate"] = ac.SumOfProductRateSaleWiGST();
            TempData["TotalGst"] = ac.SumOfProductGSTSaleWiGST();
            TempData["GrandTotal"] = ac.SumOfPSaleWiGSTTotalDtl();


            // varialble of post 

            RowCount = Convert.ToInt32(TempData["Rowcount"]);


            if (RowCount != 0)
            {

                SumofQuntity = Convert.ToDecimal(TempData["SumofQantity"]);
                TotalDiscount = 0;
                RowCount = Convert.ToInt32(TempData["Rowcount"]);
                ProductRate = Convert.ToDecimal(TempData["ProductRate"]);
                GstTotal = Convert.ToDecimal(TempData["TotalGst"]);
                Fgrandtotal = Convert.ToDecimal(TempData["GrandTotal"]);

            }
            else
            {
                SumofQuntity = 0;
                TotalDiscount = 0;
                RowCount = 0;
                ProductRate = 0;
                GstTotal = 0;
                Fgrandtotal = 0;
            }

            //  decimal gstamt = Fgrandtotal * GstTotal / 100;  // Gst amt

            decimal finaltot = Fgrandtotal;  // Final amt


            decimal[] data = new decimal[7];

            data[0] = SumofQuntity;  // not required
            data[1] = RowCount;      // not required
            data[2] = ProductRate;   // not required (total product rate)

            data[3] = Fgrandtotal;
            data[4] = GstTotal;
            data[5] = finaltot;

            data[6] = TotalDiscount;  // not required (Sum of total discou)

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        // End Gst Calculation
        public JsonResult SaleBillReports(TempSalesBillWithoutGstDtl Tsb)
        {
            ViewBag.SaleWiGst_Existance = db.TempSalesBillWithoutGstDtl.FirstOrDefault();

            if (ViewBag.SaleWiGst_Existance != null)
            {
                string BillNo = ViewBag.SaleWiGst_Existance.SalBilWiGSTBillNo;
                if (BillNo != "")
                {
                    ac.DeleteSalesBillWithoutGstDtl_Report(BillNo);
                }
            }
            ac.AddSaleReports(Tsb);

            ViewBag.msg = "";
            return Json(ViewBag.msg, JsonRequestBehavior.AllowGet);
        }
        // Add the all data from TempDataPurchase Table
        public ActionResult SaleWithoutGST_AddUpdate(TempSalesBillWithoutGstDtl swgstDtl) // Without Gst
        {
            TempData["Msg"] = "Data saved successfully...!";

            string BillNo = swgstDtl.SalBilWiGSTBillNo;
            if (BillNo != "")
            {

                int C_SaleWi = ac.Count_SaleWithoutGST(BillNo);

                if (C_SaleWi != 0)
                {
                    ViewBag.Qty_Sum = ac.QuantitySum_Temp_SaleWithoutGST(BillNo);

                    foreach (var item in ViewBag.Qty_Sum)
                    {
                        ac.Add_Sub_ProductQty(item.SalBilWiGSTProductID, item.QtySum, "Add"); // Opening stock
                    }
                }
                var checkExist = db.SalesBillWithoutGstDtl.Where(x => x.SalBilWiGSTBillNo == BillNo).FirstOrDefault();

                if (checkExist != null)
                {
                    ac.DeleteSaleWiGstDetails(BillNo);  // current data delete for update purpose
                    TempData["Msg"] = "Data updated successfully...!";

                }

                // Opening stock
                ViewBag.Qty_Sum = ac.QuantitySum_Temp_SaleWithoutGST();
                foreach (var item in ViewBag.Qty_Sum)
                {
                    ac.Add_Sub_ProductQty(item.SalBilWiGSTProductID, item.QtySum, "Sub");  // Reusable Function
                }
                // End opening stock

                // Billno Generator code
                string st1, st2 = "";
                st1 = BillNo;
                int len = st1.Length;
                for (int i = 2; i < len; i++)
                {
                    if (st1[i] == '/')
                    {
                        break;
                    }
                    st2 += st1[i];
                }
                // End Bill NO Generator code


                var tempWithoutGstSaleList = db.TempSalesBillWithoutGstDtl.ToList();
                foreach (var item in tempWithoutGstSaleList)
                {
                    SalesBillWithoutGstDtl SaleWiGst = new SalesBillWithoutGstDtl();

                    SaleWiGst.SalBilWiGSTSuppCustId = item.SalBilWiGSTSuppCustId;
                    SaleWiGst.SalBilWiGSTBillNo = BillNo;
                    SaleWiGst.SalBilWiGSTBillNo_Int = Convert.ToInt32(st2);
                    SaleWiGst.SalBilWiGSTProductID = item.SalBilWiGSTProductID;
                    SaleWiGst.SalBilWiGSTProductRate = item.SalBilWiGSTProductRate;
                    SaleWiGst.SalBilWiGSTQuantity = item.SalBilWiGSTQuantity;
                    SaleWiGst.SalBilWiGSTGstRs = item.SalBilWiGSTGstRs;
                    SaleWiGst.SalBilWiGSTTotal = item.SalBilWiGSTTotal;
                    SaleWiGst.SalBilWiGSTDate = item.SalBilWiGSTDate;
                    SaleWiGst.WearhouseRefId = item.WearhouseRefId;

                    ac.AddSaleWiGstDeatils(SaleWiGst);
                }

                ac.DeleteTempSaleDeatils();

            }




            return RedirectToAction("ListSaleBillWithoutGst");
        }
        // End


        public ActionResult Trash_TempSalesWiGst()
        {
            ac.DeleteTempSaleDeatils();
            return RedirectToAction("AddSaleBillWithoutGst");
        }

        public JsonResult AddSaleWithGstReportBill(TempSalesBillWithoutGstDtl tsb)
        {

            //ViewBag.TempSaleWiGstList = db.TempSalesBillWithoutGstDtl.FirstOrDefault();
            //if (ViewBag.TempSaleWiGstList != null)
            //{
            //    tsb.SalBilWiGSTBillNo = ViewBag.TempSaleWiGstList.SalBilWiGSTBillNo;

            //}

            ac.AddSaleWiGstReportBill(tsb);
            return Json(ViewBag.Billno, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddEditTempSalesBillWithoutGstDtls(TempSalesBillWithoutGstDtl TSal)
        {

            // here we are getting (ProductID & SupplierID)
            TSal.SalBilWiGSTProductID = db.ProductDetails.FirstOrDefault(t => t.ProductName.Contains(TSal.SalBilWiGSTProductSelection)).PDID;
            TSal.SalBilWiGSTSuppCustId = db.CustomerDetails.FirstOrDefault(t => t.CustName.Contains(TSal.SalBilWiGSTSplrCustName)).CustID;

            // here get Gst Amt
            TSal.SalBilWiGSTProductGst = db.ProductGST.FirstOrDefault(x => x.ProdGstID == (int)TSal.SalBilWiGSTProductGst).ProdGst;


            ac.AddEditTempSalesBillWithoutGstDtls(TSal);



            var tempSaleWithoutGSTList = db.TempSalesBillWithoutGstDtl.ToList();

            foreach (TempSalesBillWithoutGstDtl p in tempSaleWithoutGSTList)
            {
                p.SalBilWiGSTDate = TSal.SalBilWiGSTDate;
                p.SalBilWiGSTSuppCustId = TSal.SalBilWiGSTSuppCustId;
            }
            db.SaveChanges();

            return Json("", JsonRequestBehavior.AllowGet);
        }
        public JsonResult FetchSaleBillWithoutGst(int ID)
        {
            ViewBag.SaleBillData = (from s1 in db.TempSalesBillWithoutGstDtl
                                    join s2 in db.CustomerDetails on s1.SalBilWiGSTSuppCustId equals s2.CustID
                                    join s3 in db.ProductDetails on s1.SalBilWiGSTProductID equals s3.PDID
                                    where s1.SalBilWiGSTID == ID
                                    select new ComboPack { TempSalesBillWithoutGstDtl = s1, CustDtl = s2, ProductDetails = s3 }).FirstOrDefault();
            return Json(ViewBag.SaleBillData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteTempSales(int ID)
        {
            ac.DeleteTempSalesBillWithoutGstDtls(ID);
            ViewBag.TermsAndCondition = "";
            return Json(ViewBag.TermsAndCondition, JsonRequestBehavior.AllowGet);
        }









        public ActionResult AddEditSalesGst_Payment(SalesGST_Payment sp)
        {
            ViewBag.Existance = db.SalesGST_Payment.ToList().Find(x => x.SaleGstPay_CustSuppBillNo == sp.SaleGstPay_CustSuppBillNo);

            if (ViewBag.Existance == null)
            {
                var validate = db.SalesGST.Where(x => x.SaleGST_BillNo == sp.SaleGstPay_CustSuppBillNo).FirstOrDefault();

                if (validate != null)
                {
                    ac.AddEditSalesGst_Payment(sp);
                    TempData["SaveRegMsg"] = "Data Saved Successfully...!";
                }
            }

            return RedirectToAction("SalesGst_Payment");
        }



        public ActionResult AddCreditNotes(CreditNotes CN, string BillNo)
        {

            ViewBag.CommonBillID = BillNo;

            ViewBag.TermsnConditions = ac.ListTnC_Gst();
            ViewBag.TncInfo = db.CreditNotesTnC.Where(x => x.CreditNotesTnC_BillNo == CN.CreditNotes_SaleWithGSTBillNo).ToList();


            ViewBag.ProductGst = new SelectList(db.ProductGST.ToList(), "ProdGstID", "ProdGst");
            ViewBag.TypeOfGoodsList = new SelectList(db.TypesOfGoods.ToList(), "TOGID", "TypeOfGoodsName");
            ViewBag.CustNameList = new SelectList(db.CustomerDetails.ToList(), "CustID", "CustName");

            return View(CN);
        }
        [HttpPost]
        public ActionResult AddCreditNotes(CreditNotes CN, FormCollection formCollection)
        {
            ac.Delete_CreditNoteTnC(CN.CreditNotes_SaleWithGSTBillNo);
            ac.Delete_CreditNote(CN.CreditNotes_SaleWithGSTBillNo);

            ViewBag.TempCreditNotes = db.TempCreditNotes.ToList();

            string ID = formCollection["ID"];
            if (ID != null)
            {
                string[] ids = formCollection["ID"].Split(new char[] { ',' });

                foreach (string id in ids)
                {
                    ac.AddEdit_CreditNote_Tnc(int.Parse(id), CN.CreditNotes_SaleWithGSTBillNo);
                }
            }


            foreach (var item in ViewBag.TempCreditNotes)
            {

                //  CN.CreditNotes_SuppCustId = item.TempCreditNotes_SuppCustId;
                //  CN.CreditNotes_SaleWithGSTBillNo = item.TempCreditNotes_BillNo;

                CN.CreditNotes_ProductID = item.TempCreditNotes_ProductID;
                CN.CreditNotes_ProductRate = item.TempCreditNotes_ProductRate;

                CN.CreditNotes_Quantity = item.TempCreditNotes_Quantity;
                CN.CreditNotes_PDiscount = item.TempCreditNotes_PDiscount;

                CN.TempSaleGST_ProductGst = item.TempCreditNotes_GstRs;
                CN.CreditNotes_Total = item.TempCreditNotes_Total;

                ac.AddEditCreditNote(CN);
            }


            // Terms N Conditions
            ViewBag.TermsnConditions = ac.ListTnC_Gst();
            ViewBag.TncInfo = db.CreditNotesTnC.Where(x => x.CreditNotesTnC_BillNo == CN.CreditNotes_SaleWithGSTBillNo).ToList();
            // End Terms N Condition

            ViewBag.ProductGst = new SelectList(db.ProductGST.ToList(), "ProdGstID", "ProdGst");
            ViewBag.TypeOfGoodsList = new SelectList(db.TypesOfGoods.ToList(), "TOGID", "TypeOfGoodsName");
            ViewBag.CustNameList = new SelectList(db.CustomerDetails.ToList(), "CustID", "CustName");

            ac.Truncate_TempCreditNote();

            ViewBag.MsgSave = "save";

            return View(CN);
        }
        public ActionResult Trash_TempCreditNotes()
        {
            ac.Truncate_TempCreditNote();
            return RedirectToAction("AddCreditNotes");
        }
        public ActionResult Add_CreditNotes_to_TempCreditNotes(string BillNo)
        {

            ac.Truncate_TempCreditNote();

            ViewBag.TempCreditNotes = db.CreditNotes.Where(x => x.CreditNotes_SaleWithGSTBillNo == BillNo).ToList();


            CreditNotes CN = new CreditNotes();

            CN.CreditNotes_SuppCustId = ViewBag.TempCreditNotes[0].CreditNotes_SuppCustId;
            CN.CreditNotes_SaleWithGSTBillNo = ViewBag.TempCreditNotes[0].CreditNotes_SaleWithGSTBillNo;
            CN.CreditNotes_Date = ViewBag.TempCreditNotes[0].CreditNotes_Date;
            CN.TempSaleGST_DiscPer = ViewBag.TempCreditNotes[0].TempSaleGST_DiscPer;
            CN.TempSaleGST_DiscRs = ViewBag.TempCreditNotes[0].TempSaleGST_DiscRs;
            CN.TempSaleGST_ChargesName = ViewBag.TempCreditNotes[0].TempSaleGST_ChargesName;
            CN.TempSaleGST_ChargesAmt = ViewBag.TempCreditNotes[0].TempSaleGST_ChargesAmt;
            CN.TempSaleGST_Notes = ViewBag.TempCreditNotes[0].TempSaleGST_Notes;


            foreach (var item in ViewBag.TempCreditNotes)
            {
                CreditNotes TCN = new CreditNotes();

                TCN.CreditNotes_SuppCustId = item.CreditNotes_SuppCustId;
                TCN.CreditNotes_SaleWithGSTBillNo = item.CreditNotes_SaleWithGSTBillNo;
                TCN.TempSaleGST_ProductRates = item.CreditNotes_ProductRate;
                TCN.CreditNotes_ProductID = item.CreditNotes_ProductID;
                TCN.CreditNotes_PDiscount = item.CreditNotes_PDiscount;
                TCN.CreditNotes_Quantity = item.CreditNotes_Quantity;
                TCN.CreditNotes_GstRs = item.CreditNotes_GstRs;
                TCN.CreditNotes_Total = item.CreditNotes_Total;
                TCN.CreditNotes_Date = item.CreditNotes_Date;

                ac.OnEditTempCreditNote(TCN);
            }

            return RedirectToAction("AddCreditNotes", CN);
        }
        public ActionResult Delete_ListCreditNotes(string billNo)
        {
            ac.Delete_CreditNoteTnC(billNo);
            ac.Delete_CreditNote(billNo);
            return RedirectToAction("ListSaleGst");
        }

        public ActionResult ListCreditNotes_Report(string BillNo)
        {

            if (BillNo != null)
            {


                ViewBag.ProductCount = ac.CountProduct_CreditNotes(BillNo);






                ViewBag.ListOrgDtl = (from s1 in db.OrganizationDetails
                                      join s2 in db.state on s1.OrgState equals s2.SId
                                      join s3 in db.ActivationStatus on s1.OrgStatus equals s3.ActStsID
                                      //        join s4 in db.BankDetails on s1.OrgID equals s4.OrgID

                                      select new ComboPack { OrganizationDetails = s1, state = s2, ActStats = s3 /*, BankDetails = s4*/ }).First();



                ViewBag.ListOrgBnkDtl = (from s1 in db.OrganizationDetails
                                         join s4 in db.BankDetails on s1.OrgID equals s4.OrgID

                                         select new ComboPack { OrganizationDetails = s1, BankDetails = s4 }).ToList();







                //    ViewBag.ListCustDtl


                ViewBag.ListCreditNotes = (from s1 in db.CreditNotes

                                           join s2 in db.CustomerDetails on s1.CreditNotes_SuppCustId equals s2.CustID
                                           join s3 in db.state on s2.CustStatus equals s3.SId
                                           join s4 in db.district on s2.CustDistrict equals s4.DistId

                                           join s5 in db.ProductDetails on s1.CreditNotes_ProductID equals s5.PDID
                                           join s6 in db.ProductGST on s5.GstPercent equals s6.ProdGstID




                                           where s1.CreditNotes_SaleWithGSTBillNo == BillNo

                                           select new ComboPack { CreditNotes = s1, CustDtl = s2, state = s3, district = s4, ProductDetails = s5, ProductGST = s6 }).ToList();





                //ViewBag.ProductsDtl = (from s1 in db.SalesGST
                //                       join s2 in db.ProductDetails on s1.SaleGST_ProductID equals s2.PDID
                //                       join s3 in db.ProductGST on s2.GstPercent equals s3.ProdGstID

                //                       where s1.SaleGST_BillNo == BillNo
                //                       select new ComboPack { SalesGST = s1, ProductDetails = s2, ProductGST = s3 }).ToList();





                // not requierd

                //ViewBag.ListDiscFitotalDtl = (from s1 in db.SalesGST_Report
                //                              join s2 in db.SalesGST_ChargeDisc on s1.SalesGST_Rpt_BillNo equals s2.SalesGST_BillNo

                //                              where s1.SalesGST_Rpt_BillNo == BillNo
                //                              select new ComboPack { SalesGST_Report = s1, SalesGST_ChargeDisc = s2 }).ToList();







                ViewBag.TermsNConditon = (from s1 in db.CreditNotesTnC
                                          join s2 in db.TermsCondition on s1.CreditNotesTnC_TCID equals s2.TCID

                                          where s1.CreditNotesTnC_BillNo == BillNo

                                          select new ComboPack { CreditNotesTnC = s1, TermsCondition = s2 }).ToList();


            }
            else
            {
                return RedirectToAction("ListSaleGst");
            }
            return View();
        }










        public JsonResult BillNoGenerator_CreditBillNo()
        {
            int bill_No = 1;

            string BillNo = ac.BarcodeGenrator_CreditNotes();

            if (BillNo != "")
            {
                bill_No = Convert.ToInt32(BillNo);

                bill_No++;
            }
            return Json(bill_No, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add_SaleGst_to_AddCreditNotes(string BillNo)
        {
            ViewBag.ListSaleGst = (from s1 in db.SalesGST
                                   join s2 in db.CustomerDetails on s1.SaleGST_SuppCustId equals s2.CustID
                                   join s3 in db.SalesGST_ChargeDisc on s1.SaleGST_BillNo equals s3.SalesGST_BillNo
                                   where s1.SaleGST_BillNo == BillNo
                                   select new ComboPack { SalesGST = s1, CustDtl = s2, SalesGST_ChargeDisc = s3 }).FirstOrDefault();

            int CustIDs = ViewBag.ListSaleGst.CustDtl.CustID;
            string CustSuppBillNo = ViewBag.ListSaleGst.SalesGST.SaleGST_BillNo;


            // string Update_Status = "Update";

            CreditNotes CN = new CreditNotes();

            CN.CreditNotes_SuppCustId = CustIDs;
            CN.CreditNotes_SaleWithGSTBillNo = CustSuppBillNo;

            ac.Truncate_TempCreditNote();

            return RedirectToAction("AddCreditNotes", CN);
        }
        public JsonResult ListTempCreditNotes()
        {

            ViewBag.ListTempSaleGst = (from s1 in db.TempCreditNotes
                                       join s2 in db.CustomerDetails on s1.TempCreditNotes_SuppCustId equals s2.CustID
                                       join s3 in db.ProductDetails on s1.TempCreditNotes_ProductID equals s3.PDID
                                       join s4 in db.ProductGST on s3.GstPercent equals s4.ProdGstID
                                       select new ComboPack
                                       {
                                           TempCreditNotes = s1,
                                           CustDtl = s2,
                                           ProductDetails = s3,
                                           ProductGST = s4

                                       }).ToList();
            //  ViewBag.ListTempSaleGst = db.TempSaleGST.ToList();
            return Json(ViewBag.ListTempSaleGst, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddEditTempCreditNotes(CreditNotes CN)
        {
            //List<TempSaleGST> result = (from p in db.TempSaleGST
            //                            select p).ToList();
            //foreach (TempSaleGST p in result)
            //{
            //    p.TempSaleGST_Date = TSal.TempSaleGST_Date;
            //}

            //  db.SaveChanges();

            // here we are getting (ProductID & SupplierID)

            ViewBag.product = db.ProductDetails.Where(t => t.ProductName.Contains(CN.TempSaleGST_ProductSelection)).FirstOrDefault();

            // ViewBag.cust = db.CustomerDetails.Where(t => t.CustName.Contains(CN.TempSaleGST_SplrCustName)).FirstOrDefault();

            CN.CreditNotes_ProductID = ViewBag.product.PDID;

            //  CN.TempSaleGST_SuppCustId = ViewBag.cust.CustID;
            // End 
            // here getting id of Customer

            int GstId = Convert.ToInt32(CN.TempSaleGST_ProductGst);
            ViewBag.ProductGstList = (from s1 in db.ProductGST where s1.ProdGstID == GstId select new ComboPack { ProductGST = s1 }).FirstOrDefault();

            CN.TempSaleGST_ProductGst = ViewBag.ProductGstList.ProductGST.ProdGst; // get Gast in Percentage
                                                                                   // End

            ac.AddEditTempCreditNote(CN);


            ViewBag.TermsAndCondition = "";

            return Json(ViewBag.TermsAndCondition, JsonRequestBehavior.AllowGet);
        }
        public JsonResult FetchCreditNotes(int ID)
        {
            ViewBag.SaleBillGst = (from s1 in db.TempCreditNotes
                                   join s2 in db.CustomerDetails on s1.TempCreditNotes_SuppCustId equals s2.CustID
                                   join s3 in db.ProductDetails on s1.TempCreditNotes_ProductID equals s3.PDID
                                   where s1.TempCreditNotes_ID == ID
                                   select new ComboPack { TempCreditNotes = s1, CustDtl = s2, ProductDetails = s3 }).FirstOrDefault();
            return Json(ViewBag.SaleBillGst, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteCreditNotes(int ID)
        {
            ac.DeleteTempCreditNote(ID);
            ViewBag.TermsAndCondition = "";
            return Json(ViewBag.TermsAndCondition, JsonRequestBehavior.AllowGet);
        }


        // <------------ End Credit Notes ----------->








        // @@@______________ Sales With GST _______________@@@

        public ActionResult ListSaleGst(int? id)
        {
            //if (id == 1)
            //{
            //    TempData["SaveRegMsg"] = "Data Saved Successfully ...!";
            //}
            //else if (id == 2)
            //{
            //    TempData["UpdatRegMsg"] = "Data Updated Successfully ...!";
            //}

            ViewBag.ListCreditNote = db.CreditNotes.ToList();


            ViewBag.ListSaleGstDtl = ac.ListSaleGst();

            return View();
        }
        public ActionResult Delete_ListSaleGst(string billNo)
        {

            ViewBag.Qty_Sum = ac.QuantitySum_Temp_SaleWithGST(billNo);

            foreach (var item in ViewBag.Qty_Sum)
            {
                ac.Add_Sub_ProductQty(item.TempSaleGST_ProductID, item.QtySum, "Add");  // Reusable Function
            }

            ac.Delete_SaleGstList(billNo);
            ac.Delete_SaleGst_Report(billNo);
            ac.Delete_SaleGst_ChargeDisc(billNo);
            ac.DeleteTermsNconditons_SalesGst(billNo);

            return RedirectToAction("ListSaleGst");
        }


        public ActionResult Add_SaleGst_to_TempSaleGst(string BillNo)
        {
            ViewBag.ListSaleGst = (from s1 in db.SalesGST
                                   join s2 in db.CustomerDetails on s1.SaleGST_SuppCustId equals s2.CustID
                                   join s3 in db.SalesGST_ChargeDisc on s1.SaleGST_BillNo equals s3.SalesGST_BillNo
                                   where s1.SaleGST_BillNo == BillNo
                                   select new ComboPack { SalesGST = s1, CustDtl = s2, SalesGST_ChargeDisc = s3 }).FirstOrDefault();

            string CustSuppName = ViewBag.ListSaleGst.CustDtl.CustName;
            string CustSuppBillNo = ViewBag.ListSaleGst.SalesGST.SaleGST_BillNo;
            DateTime CustSuppDateTime = ViewBag.ListSaleGst.SalesGST.SaleGST_Date;
            decimal DiscountPer = ViewBag.ListSaleGst.SalesGST_ChargeDisc.SalesGST_DiscountPer;
            decimal DiscountRs = ViewBag.ListSaleGst.SalesGST_ChargeDisc.SalesGST_DiscountRs;
            string ChargesName = ViewBag.ListSaleGst.SalesGST_ChargeDisc.SalesGST_ChargesName;
            decimal Charges = ViewBag.ListSaleGst.SalesGST_ChargeDisc.SalesGST_ChargesAmt;

            string Update_Status = "Update";

            TempSaleGST Tsd = new TempSaleGST();

            Tsd.TempSaleGST_SplrCustName = CustSuppName;
            Tsd.TempSaleGST_BillNo = CustSuppBillNo;
            Tsd.TempSaleGST_Date = CustSuppDateTime;
            Tsd.TempSaleGST_DiscPer = DiscountPer;
            Tsd.TempSaleGST_DiscRs = DiscountRs;
            Tsd.TempSaleGST_ChargesName = ChargesName;
            Tsd.TempSaleGST_ChargesAmt = Charges;

            Tsd.Update_Status_Msg = Update_Status;



            ViewBag.SalesGst = (from s1 in db.SalesGST where s1.SaleGST_BillNo == BillNo select new ComboPack { SalesGST = s1 }).ToList();

            ac.Truncate_TempSaleGst();

            foreach (var item in ViewBag.SalesGst)
            {
                TempSaleGST Tsb = new TempSaleGST();

                Tsb.TempSaleGST_SuppCustId = item.SalesGST.SaleGST_SuppCustId;
                Tsb.TempSaleGST_BillNo = item.SalesGST.SaleGST_BillNo;
                Tsb.TempSaleGST_ProductID = item.SalesGST.SaleGST_ProductID;
                Tsb.TempSaleGST_ProductRate = item.SalesGST.SaleGST_ProductRate;

                Tsb.TempSaleGST_PDiscount = item.SalesGST.SaleGST_Discount;

                Tsb.TempSaleGST_Quantity = item.SalesGST.SaleGST_Quantity;
                Tsb.TempSaleGST_GstRs = item.SalesGST.SaleGST_GstRs;
                Tsb.TempSaleGST_Total = item.SalesGST.SaleGST_Total;
                Tsb.TempSaleGST_Date = item.SalesGST.SaleGST_Date;

                ac.Add_TempSalesGst(Tsb);
            }

            return RedirectToAction("AddSaleGst", Tsd);
        }









        // Add Sale Gst Dtls  
        public ActionResult AddSaleGst(TempSaleGST TSG, string BillNo)
        {


            ViewBag.CommonBillID = BillNo;

            //if (TSG.Update_Status_Msg == "Update")
            //{
            //    ViewBag.UpdateMsg = "2";
            //}
            //else
            //{
            //    ViewBag.UpdateMsg = "1";
            //}

            ViewBag.TermsnConditions = ac.ListTnC_Gst();

            ViewBag.TncInfo = db.SalesGst_Tnc.Where(x => x.SalesGst_BillNo == TSG.TempSaleGST_BillNo).ToList();


            ViewBag.ProductGst = new SelectList(db.ProductGST.ToList(), "ProdGstID", "ProdGst");
            ViewBag.TypeOfGoodsList = new SelectList(db.TypesOfGoods.ToList(), "TOGID", "TypeOfGoodsName");

            ViewBag.MesurementList = new SelectList(db.Mesurement.ToList(), "MID", "MesureType");
            ViewBag.ProductCategory = new SelectList(db.Product_Catagory.ToList(), "C_ID", "Category_Name");


            return View(TSG);
        }
        public JsonResult AddSalesGst_ChargeDisc(TempSaleGST tsg)
        {
            ViewBag.TempSalesGstList = db.TempSaleGST.FirstOrDefault();
            if (ViewBag.TempSalesGstList != null)
            {
                tsg.TempSaleGST_BillNo = ViewBag.TempSalesGstList.TempSaleGST_BillNo;

            }

            ac.AddSaleGst_ChargeDis(tsg);


            return Json(ViewBag.Billno, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SaleGst_TnC(FormCollection formCollection)
        {
            // string billno = Tsb.SalBilWiGSTBillNo;
            string billno = formCollection["autoBillno"];

            ac.DeleteTermsNconditons_SalesGst(billno);

            string ID = formCollection["ID"];
            if (ID != null)
            {
                string[] ids = formCollection["ID"].Split(new char[] { ',' });

                foreach (string id in ids)
                {
                    ac.AddEdit_SaleGst_Tnc(int.Parse(id), billno);
                }
            }


            ViewBag.TermsAndCondition = "";
            return Json(ViewBag.TermsAndCondition, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SaleGst_Reports(TempSaleGST Tsb)
        {
            ac.Delete_SaleGst_Report(Tsb.TempSaleGST_BillNo);
            ac.Add_SaleGst_Reports(Tsb);
            ViewBag.msg = "";
            return Json(ViewBag.msg, JsonRequestBehavior.AllowGet);
        }
        // Add the all data from TempDataPurchase Table
        public string AutoBillNos()
        {
            int bill_No = 1;

            string BillNo = ac.BarcodeGenrator_WithGst();

            if (BillNo != "")
            {
                string str1, str2;
                str1 = BillNo;
                str2 = "";

                int length = BillNo.Length;

                for (int i = 6; i < length; i++)
                {
                    if (str1[i] == '/')
                    {
                        break;
                    }
                    str2 += str1[i];
                }

                string st = str2;
                bill_No = Convert.ToInt32(st);
                bill_No++;
            }


            var Year = DateTime.Now.Year;

            string Final_BillNo = "MADH00" + bill_No + "/" + Year;

            //$("#TempSaleGST_BillNo").val("MADH00" + rslt + "/" + Year);
            //$("#autoBillno").val("MADH00" + rslt + "/" + Year);  // this for checkbox of terms and conditions

            return Final_BillNo;
        }







        public JsonResult SaleGst_Add_From_TempSaleGst(string BillNo)
        {


            int C_Sale = ac.Count_SaleWithGST(BillNo);

            if (C_Sale != 0)
            {
                ViewBag.Qty_Sum = ac.QuantitySum_Temp_SaleWithGST(BillNo);

                foreach (var item in ViewBag.Qty_Sum)
                {
                    ac.Add_Sub_ProductQty(item.TempSaleGST_ProductID, item.QtySum, "Add");
                }
            }


            ac.Delete_SaleGstList(BillNo); // its use for update time


            ViewBag.Qty_Sum = ac.QuantitySum_Temp_SaleWithGST();


            foreach (var item in ViewBag.Qty_Sum)
            {
                ac.Add_Sub_ProductQty(item.TempSaleGST_ProductID, item.QtySum, "Sub");  // Reusable Function
            }











            string st1, st2 = "";

            st1 = BillNo;

            int len = st1.Length;

            for (int i = 6; i < len; i++)
            {
                if (st1[i] == '/')
                {
                    break;
                }
                st2 += st1[i];
            }



            ViewBag.SaleList = db.TempSaleGST.ToList();

            foreach (var item in ViewBag.SaleList)
            {
                SalesGST SaleGst = new SalesGST();

                SaleGst.SaleGST_SuppCustId = item.TempSaleGST_SuppCustId;
                SaleGst.SaleGST_BillNo = BillNo;

                SaleGst.SaleGST_BillNo_Int = Convert.ToInt32(st2);

                SaleGst.SaleGST_ProductID = item.TempSaleGST_ProductID;

                SaleGst.SaleGST_ProductRate = item.TempSaleGST_ProductRate;

                SaleGst.SaleGST_Discount = item.TempSaleGST_PDiscount;

                SaleGst.SaleGST_Quantity = item.TempSaleGST_Quantity;
                SaleGst.SaleGST_GstRs = item.TempSaleGST_GstRs;
                SaleGst.SaleGST_Total = item.TempSaleGST_Total;
                SaleGst.SaleGST_Date = item.TempSaleGST_Date;


                ac.Add_SalesGst(SaleGst);

            }

            foreach (var item in ViewBag.SaleList)
            {
                string BillNoss = item.TempSaleGST_BillNo;

                ac.DeleteSaleWiGstDetails(BillNoss);
                ac.DeleteSalesBillWithoutGstDtl_Report(BillNoss);
                ac.Delete_SaleWiGst(BillNoss);
                ac.DeleteTermsNconditonsWiGst(BillNoss);
            }

            ac.Truncate_TempSaleGst();


            ViewBag.PurchaseData = "";

            return Json(ViewBag.PurchaseData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Trash_TempSalesGst()
        {
            ac.Truncate_TempSaleGst();

            return RedirectToAction("AddSaleGst");
        }

        public JsonResult Redirect_To_SalesGst_Payment()
        {
            ViewBag.Billno = db.TempSaleGST.FirstOrDefault();

            return Json(ViewBag.Billno, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Check_TempSaleGSTEmpty()
        {
            int rslt = 0;
            ViewBag.TempSaleGst = db.TempSaleGST.FirstOrDefault();
            if (ViewBag.TempSaleGst != null)
            {
                rslt = 1;
            }
            return Json(rslt, JsonRequestBehavior.AllowGet);
        }


        // End

        // --------------------

        // Payments --

        public ActionResult SalesGst_Payment(TempSaleGST Tsg)
        {


            ViewBag.ListSplrPymtDtl = ac.ListSalesGst_Payment();

            SalesGST_Payment Sp = new SalesGST_Payment();

            Sp.SaleGstPay_SupCustID = Tsg.TempSaleGST_SuppCustId;
            Sp.SaleGstPay_CustSuppBillNo = Tsg.TempSaleGST_BillNo;
            Sp.SaleGstPay_SupCustBillAmt = Tsg.TempSaleGST_TotalAmt;
            Sp.SaleGstPay_Existance = Tsg.TempSaleGST_Existance;

            return View(Sp);
        }

        public ActionResult DeleteSaleGst_Payment(int id)
        {


            var BillData = db.SalesGST_Payment.Where(x => x.SaleGstPay_ID == id).FirstOrDefault();

            string BillNo = BillData.SaleGstPay_CustSuppBillNo;



            ac.DeleteSaleGst_Payment(id);

            ac.DeleteSaleGst_Transactions(BillNo);


            return RedirectToAction("SalesGst_Payment");
        }

        public JsonResult FetchSaleGst_Report_onBill(string BillNos)
        {
            var lst = (from s1 in db.SalesGST
                       join s2 in db.CustomerDetails on s1.SaleGST_SuppCustId equals s2.CustID
                       join s3 in db.SalesGST_Report on s1.SaleGST_BillNo equals s3.SalesGST_Rpt_BillNo
                       where s1.SaleGST_BillNo == BillNos
                       select new
                       {
                           s1.SaleGST_SuppCustId,
                           s2.CustName,
                           s3.SalesGST_Rpt_FinalTotal
                       }).FirstOrDefault();

            if (lst != null)
            {
                return Json(lst, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }

        }








        public ActionResult SalesGst_Transaction(string BillNo)
        {


            if (BillNo == null)
            {
                return RedirectToAction("SalesGst_Payment");
            }

            Session["SaleBillNo"] = BillNo;

            ViewBag.ListCustSupTransaction = (from s1 in db.SalesGST_Transactions
                                              join s2 in db.CustomerDetails on s1.SGstTran_CustSupID equals s2.CustID
                                              join s3 in db.PaymentMethod on s1.SGstTran_TranPayMethod equals s3.PayMId
                                              where s1.SGstTran_BillNo == BillNo
                                              select new ComboPack
                                              { SalesGST_Transactions = s1, CustDtl = s2, PaymentMethod = s3 }).ToList();

            ViewBag.BillAmtList = db.SalesGST_Report.ToList().Find(x => x.SalesGST_Rpt_BillNo == BillNo);

            if (ViewBag.BillAmtList != null)
            {
                ViewBag.BillAmt = ViewBag.BillAmtList.SalesGST_Rpt_FinalTotal; // Bill Amt
            }
            else
            {
                ViewBag.BillAmt = 0; // Bill Amt
            }



            ViewBag.SumOfReciAmt = ac.SumOfReciAmt_Sale(BillNo);

            ViewBag.ListPaymentMethod = new SelectList(db.PaymentMethod.ToList(), "PayMId", "PayMName");

            return View();
        }
        public JsonResult FetchSalesGst_Transaction(int ID)
        {
            ViewBag.ListSplrPymtDtl = (from s1 in db.SalesGST_Transactions
                                       join s2 in db.CustomerDetails on s1.SGstTran_CustSupID equals s2.CustID
                                       join s3 in db.PaymentMethod on s1.SGstTran_TranPayMethod equals s3.PayMId
                                       where s1.SGstTran_TranID == ID
                                       select new ComboPack { SalesGST_Transactions = s1, CustDtl = s2, PaymentMethod = s3 }).FirstOrDefault();

            return Json(ViewBag.ListSplrPymtDtl, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteSalesGst_Transaction(int id)
        {
            ac.DeleteSaleGst_Transaction(id);
            string Billnos = Session["SaleBillNo"].ToString();
            return RedirectToAction("SalesGst_Transaction", new { BillNo = Billnos });

        }
        public ActionResult AddEditSaleGst_Transaction(SalesGST_Transactions St)
        {
            string Billno = Session["SaleBillNo"].ToString();

            ViewBag.CustSuppList = db.SalesGST.FirstOrDefault(x => x.SaleGST_BillNo == Billno);



            St.SGstTran_BillNo = Billno;
            if (ViewBag.CustSuppList != null)
            {
                St.SGstTran_CustSupID = ViewBag.CustSuppList.SaleGST_SuppCustId;
                ac.AddSaleGst_Transaction(St);
            }





            string Billnos = Session["SaleBillNo"].ToString();
            return RedirectToAction("SalesGst_Transaction", new { BillNo = Billnos });
        }





        public JsonResult BillNoGenerator_WithGst()
        {
            int bill_No = 1;

            string BillNo = ac.BarcodeGenrator_WithGst();

            if (BillNo != "")
            {
                string str1, str2;
                str1 = BillNo;
                str2 = "";

                int length = BillNo.Length;

                for (int i = 6; i < length; i++)
                {
                    if (str1[i] == '/')
                    {
                        break;
                    }
                    str2 += str1[i];
                }

                string st = str2;
                bill_No = Convert.ToInt32(st);
                bill_No++;
            }
            return Json(bill_No, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListTempSalesGst()
        {

            ViewBag.ListTempSaleGst = (from s1 in db.TempSaleGST
                                       join s2 in db.CustomerDetails on s1.TempSaleGST_SuppCustId equals s2.CustID
                                       join s3 in db.ProductDetails on s1.TempSaleGST_ProductID equals s3.PDID
                                       join s4 in db.ProductGST on s3.GstPercent equals s4.ProdGstID
                                       select new ComboPack
                                       {
                                           TempSaleGST = s1,
                                           CustDtl = s2,
                                           ProductDetails = s3,
                                           ProductGST = s4
                                       }).ToList();

            //  ViewBag.ListTempSaleGst = db.TempSaleGST.ToList();
            return Json(ViewBag.ListTempSaleGst, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteTempSalesGst(int ID)
        {
            ac.DeleteTempSalesGst(ID);
            ViewBag.TermsAndCondition = "";
            return Json(ViewBag.TermsAndCondition, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddEditTempSaleGst(TempSaleGST TSal)
        {
            List<TempSaleGST> result = (from p in db.TempSaleGST
                                        select p).ToList();

            foreach (TempSaleGST p in result)
            {
                p.TempSaleGST_Date = TSal.TempSaleGST_Date;
            }

            db.SaveChanges();

            // here we are getting (ProductID & SupplierID)
            ViewBag.product = db.ProductDetails.Where(t => t.ProductName.Contains(TSal.TempSaleGST_ProductSelection)).FirstOrDefault();
            ViewBag.cust = db.CustomerDetails.Where(t => t.CustName.Contains(TSal.TempSaleGST_SplrCustName)).FirstOrDefault();
            TSal.TempSaleGST_ProductID = ViewBag.product.PDID;
            TSal.TempSaleGST_SuppCustId = ViewBag.cust.CustID;
            // End 
            // here getting id of Customer
            int GstId = Convert.ToInt32(TSal.TempSaleGST_ProductGst);
            ViewBag.ProductGstList = (from s1 in db.ProductGST where s1.ProdGstID == GstId select new ComboPack { ProductGST = s1 }).FirstOrDefault();
            TSal.TempSaleGST_ProductGst = ViewBag.ProductGstList.ProductGST.ProdGst; // get Gast in Percentage
                                                                                     // End

            ac.AddEditTempSaleGst(TSal);
            ViewBag.TermsAndCondition = "";

            return Json(ViewBag.TermsAndCondition, JsonRequestBehavior.AllowGet);
        }
        public JsonResult FetchSaleGst(int ID)
        {
            ViewBag.SaleBillGst = (from s1 in db.TempSaleGST
                                   join s2 in db.CustomerDetails on s1.TempSaleGST_SuppCustId equals s2.CustID
                                   join s3 in db.ProductDetails on s1.TempSaleGST_ProductID equals s3.PDID
                                   where s1.TempSaleGST_ID == ID
                                   select new ComboPack { TempSaleGST = s1, CustDtl = s2, ProductDetails = s3 }).FirstOrDefault();

            return Json(ViewBag.SaleBillGst, JsonRequestBehavior.AllowGet);
        }
        // Gst Calculation
        public JsonResult TotalSaleGstLists()
        {

            decimal Fgrandtotal, TotalDiscount, GstTotal, SumofQuntity, RowCount, ProductRate;

            TempData["SumofQantity"] = ac.SumOfQuntSaleGST();

            //      TempData["TotalDisc"] = ac.TotalDiscountPurchaseDtl();

            TempData["Rowcount"] = ac.RowCountSaleGst();
            TempData["ProductRate"] = ac.SumOfProductRateSaleGST();
            TempData["TotalGst"] = ac.SumOfProductGSTSaleGST();
            TempData["GrandTotal"] = ac.SumOfPSaleGSTTotalDtl();


            // varialble of post 

            RowCount = Convert.ToInt32(TempData["Rowcount"]);


            if (RowCount != 0)
            {

                SumofQuntity = Convert.ToDecimal(TempData["SumofQantity"]);
                TotalDiscount = 0;
                RowCount = Convert.ToInt32(TempData["Rowcount"]);
                ProductRate = Convert.ToDecimal(TempData["ProductRate"]);
                GstTotal = Convert.ToDecimal(TempData["TotalGst"]);
                Fgrandtotal = Convert.ToDecimal(TempData["GrandTotal"]);

            }
            else
            {
                SumofQuntity = 0;
                TotalDiscount = 0;
                RowCount = 0;
                ProductRate = 0;
                GstTotal = 0;
                Fgrandtotal = 0;
            }

            //  decimal gstamt = Fgrandtotal * GstTotal / 100;  // Gst amt

            decimal finaltot = Fgrandtotal + GstTotal;  // Final amt

            decimal[] data = new decimal[7];

            data[0] = SumofQuntity;  // not required
            data[1] = RowCount;      // not required
            data[2] = ProductRate;   // not required (total product rate)

            data[3] = Fgrandtotal;
            data[4] = GstTotal;
            data[5] = finaltot;

            data[6] = TotalDiscount;  // not required (Sum of total discou)

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        // End Gst Calculation




        // <------------- End Sales with Gst ---------------->


        // <-------------- Common Bill No Generate ------------>


        // @@@@@ Add Common Content in Sales With Gst @@@@


        //public JsonResult TempSaleGstCommonBillNo(int ID)
        //{

        public JsonResult TempSaleGstCommonBillNo(string BillID)
        {

            //  ViewBag.Sale = db.TempSalesBillWithoutGstDtl.ToList();
            //  ac.DeleteTempSaleDeatils();
            //  string BillID = "001/2021";




            ViewBag.CommonBillNo = ac.CommonBillNo_GroupBy(BillID);

            foreach (var item1 in ViewBag.CommonBillNo)
            {

                ViewBag.SaleWithoutGstLst = ac.SalewithoutGstList(item1.ComBiNo_BillNo);

                //  SaleGst.SalBilWiGSTGstRs


                foreach (var item2 in ViewBag.SaleWithoutGstLst)
                {
                    TempSalesBillWithoutGstDtl SaleGst = new TempSalesBillWithoutGstDtl();
                    SaleGst.SalBilWiGSTSuppCustId = item2.SalBilWiGSTSuppCustId;
                    SaleGst.SalBilWiGSTBillNo = item2.SalBilWiGSTBillNo;
                    SaleGst.SalBilWiGSTProductRate = item2.SalBilWiGSTProductRate;
                    SaleGst.SalBilWiGSTProductID = item2.SalBilWiGSTProductID;
                    SaleGst.SalBilWiGSTQuantity = item2.SalBilWiGSTQuantity;
                    SaleGst.SalBilWiGSTGstRs = item2.SalBilWiGSTGstRs;
                    SaleGst.SalBilWiGSTTotal = item2.SalBilWiGSTTotal;
                    SaleGst.SalBilWiGSTDate = item2.SalBilWiGSTDate;
                    ac.AddTempSaleGst(SaleGst);
                }
            }


            var salegstlst = db.SalesGST.FirstOrDefault();



            int CustID = salegstlst.SaleGST_SuppCustId;

            var CustLst = db.CustomerDetails.Where(x => x.CustID == CustID).FirstOrDefault();

            ViewBag.PurchaseData = CustLst.CustName;

            ac.CommonBill_Delete(BillID);


            return Json(ViewBag.PurchaseData, JsonRequestBehavior.AllowGet);

            //  return View();

        }


        // <-------------- End commmon content ---------->






        //public ActionResult ListCommonBillGenerate()
        //{
        //    ViewBag.ListOfCommonBillID = ac.CommonBillNo_GroupBy();
        //    return View();
        //}
        //public ActionResult CommonBill_Edit(string BillID)
        //{
        //    ac.CommonBill_Edit(BillID);
        //    return RedirectToAction("CommonBillGenerate");
        //}
        //public ActionResult CommonBill_Delete(string BillID)
        //{
        //    ac.CommonBill_Delete(BillID);
        //    return RedirectToAction("ListCommonBillGenerate");
        //}


        // Add Common Bill 
        public ActionResult CommonBillGenerate()
        {
            ViewBag.CustSuppName = new SelectList(db.CustomerDetails.ToList(), "CustID", "CustName");
            return View();
        }

        public JsonResult CommonBillno_List()
        {
            ViewBag.CommanBillNo = db.CommanBillNo.Where(t => t.DispStatus.Equals(1)).ToList();
            return Json(ViewBag.CommanBillNo, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CommonBillno_BillNoGenerator()
        {
            int bill_No = 1;

            string BillNo = ac.CommanBill_BarcodeGenrator();

            if (BillNo != "")
            {
                string str1, str2;
                str1 = BillNo;
                str2 = "";

                int length = BillNo.Length;

                for (int i = 2; i < length; i++)
                {
                    if (str1[i] == '/')
                    {
                        break;
                    }
                    str2 += str1[i];
                }

                string st = str2;
                bill_No = Convert.ToInt32(st);
                bill_No++;
            }
            return Json(bill_No, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddCommonBillGenerate(FormCollection formCollection)
        {
            ViewBag.TermsAndCondition = "";

            string BillID = formCollection["ComBiNo_BillID"];

            string ID = formCollection["BillNo"];

            if (ID != null)
            {
                string[] ids = formCollection["BillNo"].Split(new char[] { ',' });
                foreach (string id in ids)
                {
                    ac.AddCommonBillNo(id, BillID);
                }
            }
            else
            {
                ViewBag.TermsAndCondition = "You are not selected Bill No";
            }




            return Json(ViewBag.TermsAndCondition, JsonRequestBehavior.AllowGet);
        }



        public ActionResult DeleteCommonBillGenerate(int ID)
        {
            ac.DeleteCommonBillNo(ID);
            return RedirectToAction("CommonBillGenerate");
        }
        public JsonResult FetchFinalNReciAmt(string BillNo)
        {

            decimal FinalAmt, PaidAmt;

            TempData["FinalBillAmt"] = ac.CommonBillNo_FinalAmt(BillNo);
            TempData["PaidAmt"] = ac.CommonBillNo_PaidAmt(BillNo);

            FinalAmt = Convert.ToInt32(TempData["FinalBillAmt"]);
            PaidAmt = Convert.ToInt32(TempData["PaidAmt"]);

            decimal[] data = new decimal[7];

            data[0] = FinalAmt;  // not required
            data[1] = PaidAmt;      // not required


            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult BillNo_AccordingName(int ID)
        {
            List<CommanBillNo> ListBillno = ac.BillNoList_AccordingName(ID);

            // ViewBag.BillNo = new SelectList(SaleGst, "SalBilWiGSTBillNo", "SalBilWiGSTBillNo");
            // return PartialView("BillNo_AccordingNames");

            return Json(ListBillno, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult BillNo_AccordingName_BetDate(CommanBillNo comBillno)
        {
            var lst = ac.BillNoList_AccordingName_BetDate(comBillno);

            return Json(lst, JsonRequestBehavior.AllowGet);
        }



        public ActionResult CommonBillUpdateStatus(string BillIDs)
        {




            ac.CommonBillUpdateStatus();

            string Billnos = BillIDs;

            //   return RedirectToAction("AddSaleGst");
            return RedirectToAction("AddSaleGst", new { BillNo = Billnos });
        }



        // <-------------- End Common Bill No Generate ----------->


        // @@@@@@@@@@@@@@    Upload form  @@@@@@@@@@@@@

        public ActionResult UplaodFiles()
        {
            ViewBag.RegistList = new SelectList(db.Registration, "RID", "Name");

            ViewBag.UploadedList = (from s1 in db.UploadFiles
                                    join s2 in db.Registration on s1.RID equals s2.RID

                                    where s1.Uploader_Name_ID == 0
                                    select new ComboPack { UploadFiles = s1, Rgst = s2 }).ToList();

            return View();
        }
        [HttpPost]
        public ActionResult UplaodFiles(UploadFiles uf, HttpPostedFileBase[] files)
        {
            ViewBag.RegistList = new SelectList(db.Registration, "RID", "Name");

            uf.UpID = ac.AddUploadFile(uf);  // Get Last Inserted ID


            //iterating through multiple file collection 

            foreach (HttpPostedFileBase file in files)
            {

                //Checking file is available to save.  
                if (file != null)
                {
                    string InputFileName = Path.GetFileName(file.FileName);

                    string filext = Path.GetExtension(file.FileName);

                    string dt = string.Format(@"{0}_" + Path.GetFileName(file.FileName), DateTime.Now.Ticks);

                    //  string dts = dt.ToString("dd-MM-yyyy");
                    string FName = dt;



                    //var ServerSavePath = Path.Combine(Server.MapPath("~/UploadedFiles/") + FName);
                    //Save file to server folder 
                    //System.IO.Path.Combine(Server.MapPath("~/Image/"), Filename)
                    file.SaveAs(System.IO.Path.Combine(Server.MapPath("~/UploadedFiles/"), FName));

                    ac.AddFiles(uf, FName, filext);

                    //  Guid obj = new Guid();
                    // Guid newGuid = Guid.NewGuid();
                    // string imageName = newGuid.ToString();


                    //assigning file uploaded status to ViewBag for showing message to user.  
                    ViewBag.UploadStatus = files.Count().ToString() + "files Send successfully.";


                }
            }



            ViewBag.UploadedList = (from s1 in db.UploadFiles
                                    join s2 in db.Registration on s1.RID equals s2.RID

                                    where s1.Uploader_Name_ID == 0
                                    select new ComboPack { UploadFiles = s1, Rgst = s2 }).ToList();



            return View();
        }




        public ActionResult UploadedList()
        {

            //ViewBag.UploadedList = (from s1 in db.UploadFiles
            //                              join s2 in db.Registration on s1.RID equals s2.RID

            //                        where s1.RID == 0

            //                        select new ComboPack { UploadFiles = s1, Rgst = s2 }).ToList();



            //   int RID = Convert.ToInt32(Session["User_IDs"]);


            ViewBag.UploadedList = uc.ReceivedList(0);


            return View();
        }
        [HttpPost]
        public ActionResult UploadedList(DateTime? fdate, DateTime? ldate)
        {
            //ViewBag.UploadedList = (from s1 in db.UploadFiles
            //                        join s2 in db.Registration on s1.RID equals s2.RID
            //                        where (s1.UpDates == fdate && s1.UpDates == ldate)
            //                        select new ComboPack { UploadFiles = s1, Rgst = s2 }).ToList();


            ViewBag.UploadedList = uc.ReceivedList(fdate, ldate, 0);


            return View();
        }


        public ActionResult Deactive_ReceiveFile(int? UpID)
        {
            uc.Deactive_Document(UpID);

            return RedirectToAction("UploadedList");
        }




        public ActionResult DownloadFiles(int? UpID)
        {
            if (UpID != null)
            {
                ViewBag.DownloadFilesList = db.UploadedTb.Where(a => a.UpID == UpID).ToList();
            }
            else
            {
                return RedirectToAction("UploadedList");
            }

            return View();
        }

        public ActionResult Delete_DownloadFiles(int? UpID)
        {
            ViewBag.DownloadFilesList = db.UploadedTb.Where(a => a.UpID == UpID).ToList();
            foreach (var item in ViewBag.DownloadFilesList)
            {
                string filepath = Path.Combine(Server.MapPath("~/UploadedFiles/"), item.Utb_Name);
                System.IO.File.Delete(filepath);
            }

            ac.Delele_UploadedFile(UpID);
            return RedirectToAction("UplaodFiles");
        }




        public ActionResult Edit_DeleteFiles(int? ID)
        {
            ViewBag.DownloadFilesList = db.UploadedTb.Where(a => a.Utb_ID == ID).ToList();

            foreach (var item in ViewBag.DownloadFilesList)
            {
                string filepath = Path.Combine(Server.MapPath("~/UploadedFiles/"), item.Utb_Name);
                System.IO.File.Delete(filepath);
            }

            ac.Edit_Delele_UploadedFile(ID);

            int UpID = Convert.ToInt32(Session["UpID_Session"]);

            return RedirectToAction("Edit_UploadedFiles", new { UpID = UpID });
        }

        public ActionResult Edit_UploadedFiles(int? UpID)
        {
            if (UpID != null)
            {
                Session["UpID_Session"] = UpID;
                ViewBag.DownloadFilesList = db.UploadedTb.Where(a => a.UpID == UpID).ToList();
            }
            else
            {
                return RedirectToAction("UplaodFiles");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Edit_UploadedFiles(UploadFiles uf, HttpPostedFileBase[] files)
        {

            uf.UpID = Convert.ToInt32(Session["UpID_Session"]); // Get  UPID

            //iterating through multiple file collection 

            foreach (HttpPostedFileBase file in files)
            {

                //Checking file is available to save.  
                if (file != null)
                {
                    string InputFileName = Path.GetFileName(file.FileName);

                    string filext = Path.GetExtension(file.FileName);

                    string dt = string.Format(@"{0}_" + Path.GetFileName(file.FileName), DateTime.Now.Ticks);

                    string FName = dt;


                    file.SaveAs(System.IO.Path.Combine(Server.MapPath("~/UploadedFiles/"), FName));

                    ac.AddFiles(uf, FName, filext);

                    ViewBag.UploadStatus = files.Count().ToString() + "files Updated successfully.";


                }
            }



            ViewBag.DownloadFilesList = db.UploadedTb.Where(a => a.UpID == uf.UpID).ToList();


            return View();
        }
















        //[HttpPost]
        //public JsonResult Upload()
        //{

        //    foreach (var file in Request.Files)
        //    {
        //        if (file.ContentLength > 0)
        //        {
        //            file.SaveAs(Server.MapPath("~/Upload/" + file.FileName));
        //        }
        //    }

        //    return Json(new { result = true });
        //}
        // <------------      End Upload Form       ------------->





        // <-==========@@@@@@@@@@ Store  @@@@@@@@@@@==================->

        // <-------------@@@ Store Products @@@---------------->



        public ActionResult CutFeedback()
        {
            //  DateTime dt = DateTime.Now;
            ViewBag.Feedback = (from s1 in db.Feedback
                                    //  where (s1.F_Date >= dt && s1.F_Date <= dt)
                                select new ComboPack { Feedback = s1 }
                       ).ToList();

            return View();
        }
        [HttpPost]
        public ActionResult CutFeedback(DateTime? Fdate, DateTime? Ldate)
        {

            ViewBag.Feedback = (from s1 in db.Feedback
                                where (s1.F_Date >= Fdate && s1.F_Date <= Ldate)
                                select new ComboPack { Feedback = s1 }
                                  ).ToList();


            return View();
        }


        public ActionResult CustomerProductSlider()
        {
            ViewBag.PSliderLst = db.CustomerSlider.ToList();

            return View();
        }

        public ActionResult ProductSlider_AddUpdate(CustomerSlider CS, HttpPostedFileBase PImg)
        {
            string msg;

            if (PImg != null)
            {

                string fileName = System.IO.Path.GetFileName(PImg.FileName);

                System.Guid guid = System.Guid.NewGuid();

                string ID = guid.ToString();

                var ext = Path.GetExtension(PImg.FileName); //getting the extension(ex-.jpg)  

                string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                string myfile = name + "_" + ID + ext; //appending the name with id  




                //Set the Image File Path.
                string filePath = "~/Logo/Slider/" + myfile;

                //Save the Image File in Folder.
                PImg.SaveAs(Server.MapPath(filePath));
                CS.CS_ImgPath = myfile;
            }

            if (CS.CS_ID != 0)
            {
                var FetchPro = db.CustomerSlider.Where(x => x.CS_ID == CS.CS_ID).FirstOrDefault();


                // This is for Update table
                //db.Entry(CS).State = System.Data.EntityState.Modified;
                //db.SaveChanges();


                ac.ProductSlider_Update(CS);
                // End

                if (CS.CS_ImgPath != null)
                {
                    string filepath = Path.Combine(Server.MapPath("~/Logo/Slider/"), FetchPro.CS_ImgPath);
                    System.IO.File.Delete(filepath);
                }




                msg = "Data updated successfully";

            }
            else
            {
                db.CustomerSlider.Add(CS);
                db.SaveChanges();
                msg = "Data inserted successfully";
            }


            TempData["CPMsg"] = msg;

            return RedirectToAction("CustomerProductSlider");
        }


        public JsonResult ProductSlider_Fetch(int ID)
        {
            var FetchPro = db.CustomerSlider.Where(x => x.CS_ID == ID).FirstOrDefault();

            //  FetchPro.ImgString = "data:image/jpg;base64," + Convert.ToBase64String(FetchPro.Sp_PImage);

            return Json(FetchPro, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ProductSlider_Delete(int ID)
        {
            var FetchPro = db.CustomerSlider.Where(x => x.CS_ID == ID).FirstOrDefault();



            string filepath = Path.Combine(Server.MapPath("~/Logo/Slider/"), FetchPro.CS_ImgPath);
            System.IO.File.Delete(filepath);


            CustomerSlider p = db.CustomerSlider.Find(ID);
            db.CustomerSlider.Remove(p);
            db.SaveChanges();



            return RedirectToAction("CustomerProductSlider");
        }






        public ActionResult Store_Products()
        {
            ViewBag.StoreProductList = db.Store_AddProduct.ToList();

            ViewBag.StoreProductList = (from s1 in db.Store_AddProduct

                                        join s2 in db.Product_Catagory on s1.Sp_Category equals s2.C_ID
                                        join s3 in db.ActivationStatus on s1.Sp_Status equals s3.ActStsID


                                        select new ComboPack { Store_AddProduct = s1, Product_Catagory = s2, ActStats = s3 }).ToList();


            ViewBag.ProductCategoryList = new SelectList(db.Product_Catagory.ToList(), "C_ID", "Category_Name");
            ViewBag.ActStatusList = new SelectList(db.ActivationStatus.ToList(), "ActStsID", "ActStsName");

            return View();
        }
        [HttpPost]
        public ActionResult AddEditStore_Products(Store_AddProduct P, HttpPostedFileBase SpPImage)
        {

            if (P.Sp_ID != 0)
            {
                var PRow = db.Store_AddProduct.Where(x => x.Sp_ID == P.Sp_ID).FirstOrDefault();

                string filepath = Path.Combine(Server.MapPath("~/StoreProductImgs/"), PRow.Sp_PImageName);
                System.IO.File.Delete(filepath);
            }




            //Checking file is available to save.  
            if (SpPImage != null)
            {
                string InputFileName = Path.GetFileName(SpPImage.FileName);
                string filext = Path.GetExtension(SpPImage.FileName);

                string dt = string.Format(@"{0}_" + Path.GetFileName(SpPImage.FileName), DateTime.Now.Ticks);

                string FName = dt;


                SpPImage.SaveAs(System.IO.Path.Combine(Server.MapPath("~/StoreProductImgs/"), FName));

                ac.AddStoreProduct(P, FName);

                TempData["SaveRegMsg"] = "Data Saved Successfully...!";




                // Guid newGuid = Guid.NewGuid();
                // string imageName = newGuid.ToString();



            }












            return RedirectToAction("Store_Products");
        }
        public JsonResult FetchStoreProductDtls(int ID)
        {
            var FetchPro = db.Store_AddProduct.Where(x => x.Sp_ID == ID).FirstOrDefault();

            //  FetchPro.ImgString = "data:image/jpg;base64," + Convert.ToBase64String(FetchPro.Sp_PImage);

            return Json(FetchPro, JsonRequestBehavior.AllowGet);
        }
        public ActionResult StoreProduct_Delete(int id)
        {
            var PRow = db.Store_AddProduct.Where(x => x.Sp_ID == id).FirstOrDefault();

            string filepath = Path.Combine(Server.MapPath("~/StoreProductImgs/"), PRow.Sp_PImageName);
            System.IO.File.Delete(filepath);


            Store_AddProduct p = db.Store_AddProduct.Find(id);
            db.Store_AddProduct.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Store_Products");
        }
        public ActionResult ActiveStatusStoreProduct(int id)
        {
            var plst = db.Store_AddProduct.Where(x => x.Sp_ID == id).FirstOrDefault();


            ac.ActiveDeactive_StoreProduct(plst.Sp_Status, id);
            return RedirectToAction("Store_Products");
        }
        [HttpPost]
        public JsonResult StoreProductNameExistOrNot(Store_AddProduct P)
        {
            int rslt;

            //  object obj = ac.OrgNameExistOrNot(org);

            object obj = db.Store_AddProduct.Where(x => x.Sp_ProductName == P.Sp_ProductName).FirstOrDefault();

            if (obj != null)
            {
                rslt = 0;

            }
            else
            {
                rslt = 1;

            }

            return Json(rslt, JsonRequestBehavior.AllowGet);
        }

        // <---------------- End store products ----------------->


        // <----------------@@@ Delivary charges @@@----------------->
        public ActionResult DelivaryCharges()
        {
            ViewBag.DelivaryChargList = db.delivery_charges.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult DelivaryCharges(delivery_charges dc)
        {

            if (dc.DC_ID != 0)
            {
                db.Entry(dc).State = System.Data.EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                db.delivery_charges.Add(dc);
                db.SaveChanges();
            }

            ViewBag.DelivaryChargList = db.delivery_charges.ToList();
            return View();
        }

        public ActionResult Delete_DelivaryCharges(int id)
        {
            ac.Delete_DelivaryCharges(id, "del");
            return RedirectToAction("DelivaryCharges");
        }

        public JsonResult FetchDeleveryData(int id)
        {
            var lst = db.delivery_charges.Where(x => x.DC_ID == id).FirstOrDefault();

            return Json(lst, JsonRequestBehavior.AllowGet);
        }


        public JsonResult PicodeExistorNot(int Pincode)
        {
            int rstlt;
            var lst = db.delivery_charges.Where(x => x.Pincode == Pincode).FirstOrDefault();

            if (lst != null)
            {
                rstlt = 0;
            }
            else
            {
                rstlt = 1;
            }

            return Json(rstlt, JsonRequestBehavior.AllowGet);
        }
        // <---------------- End Delivary charges ----------------->


        // <----------------- Customer Orders ----------------------->

        public ActionResult Customer_Orders()
        {


            var chargDisc = db.delivery_charges.FirstOrDefault();

            ViewBag.charges = chargDisc.DC_Charges;


            ViewBag.DeliveryStatusList = db.CustomerDeliveryStatus.ToList(); // this for json

            return View();
        }


        public ActionResult Past_Customer_Orders()
        {


            var chargDisc = db.delivery_charges.FirstOrDefault();

            ViewBag.charges = chargDisc.DC_Charges;


            ViewBag.DeliveryStatusList = db.CustomerDeliveryStatus.ToList(); // this for json

            return View();
        }

        public JsonResult PastCustomer_OrderList()
        {


            return Json(ac.PastCustOrderList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult FromDatePastCustomer_OrderList(DateTime? Fdate, DateTime? Ldate)
        {
            return Json(ac.PastCustOrderList(Fdate, Ldate), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Customer_OrderList()
        {
            //ViewBag.CustOrderList = (from s1 in db.CustomerOrder
            //                         join s2 in db.Customer_Registration on s1.CustID equals s2.Cust_RID
            //                         join s3 in db.CustomerDeliveryStatus on s1.DeliveryStatus equals s3.CDS_ID 

            //                         where s1.DeliveryStatus != 5
            //                         select new ComboPack { CustomerOrder = s1, Customer_Registration = s2,/* CustomerDeliveryStatus = s3*/ }).OrderByDescending(x => x.CustomerOrder.OrderID).ToList();




            return Json(ac.CustOrderList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Customer_OrderStatusUpdate(int OrdId, int StatusId)
        {

            ac.CustomerStatusUpdate(OrdId, StatusId);

            return Json("Delivery Status Updated Successfully...", JsonRequestBehavior.AllowGet);
        }






        public JsonResult OrderedItemsList(int OrdID)
        {
            ViewBag.CustOrderProductList = (from s1 in db.OrderedProducts
                                            join s2 in db.CustomerOrder on s1.OP_OrderId equals s2.OrderID
                                            where s1.OP_OrderId == OrdID
                                            select new ComboPack { OrderedProducts = s1, CustomerOrder = s2 }).ToList();


            return Json(ViewBag.CustOrderProductList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Customer_DeliveredOrders()
        {
            var chargDisc = db.delivery_charges.FirstOrDefault();

            ViewBag.charges = chargDisc.DC_Charges;



            ViewBag.DeliveryStatusList = db.CustomerDeliveryStatus.ToList(); // this for json

            return View();
        }

        public JsonResult Customer_DeliveredOrderList()
        {
            ViewBag.CustOrderList = (from s1 in db.CustomerOrder

                                     join s2 in db.Customer_Registration on s1.CustID equals s2.Cust_RID
                                     join s3 in db.CustomerDeliveryStatus on s1.DeliveryStatus equals s3.CDS_ID

                                     where s1.DeliveryStatus == 5
                                     select new ComboPack { CustomerOrder = s1, Customer_Registration = s2, CustomerDeliveryStatus = s3 }).OrderByDescending(x => x.CustomerOrder.OrderID).ToList();


            return Json(ViewBag.CustOrderList, JsonRequestBehavior.AllowGet);
        }



        // <-------------------======= Report ======----------------->


        public ActionResult CustomerOrdersReport()
        {

            ViewBag.DeliveryStatusList = new SelectList(db.CustomerDeliveryStatus, "CDS_ID", "CDS_Name");


            return View();
        }
        [HttpPost]
        public ActionResult CustomerOrdersReport(DateTime? Fdate, DateTime? Ldate, int? OrdID, int? DelStatus)
        {

            ViewBag.DeliveryStatusList = new SelectList(db.CustomerDeliveryStatus, "CDS_ID", "CDS_Name");


            if (Fdate == null && Ldate == null && OrdID != null)
            {

                ViewBag.OrdList = (from s1 in db.CustomerOrder
                                   where s1.OrderID == OrdID

                                   select new ComboPack { CustomerOrder = s1 }
                 ).ToList();


                ViewBag.OrderDtl = (from s1 in db.CustomerOrder
                                    join s2 in db.OrderedProducts on s1.OrderID equals s2.OP_OrderId
                                    join s3 in db.Customer_Registration on s1.CustID equals s3.Cust_RID

                                    where s1.OrderID == OrdID

                                    select new ComboPack { CustomerOrder = s1, OrderedProducts = s2, Customer_Registration = s3 }
                                ).ToList();

            }

            if (Fdate != null && Ldate != null && OrdID == null)
            {
                ViewBag.OrdList = (from s1 in db.CustomerOrder
                                   where s1.DeliveryStatus == 5 && (s1.CustOrdDate >= Fdate && s1.CustOrdDate <= Ldate)

                                   select new ComboPack { CustomerOrder = s1 }
                  ).ToList();

                ViewBag.OrderDtl = (from s1 in db.CustomerOrder
                                    join s2 in db.OrderedProducts on s1.OrderID equals s2.OP_OrderId
                                    join s3 in db.Customer_Registration on s1.CustID equals s3.Cust_RID

                                    where s1.DeliveryStatus == 5 && (s1.CustOrdDate >= Fdate && s1.CustOrdDate <= Ldate)

                                    select new ComboPack { CustomerOrder = s1, OrderedProducts = s2, Customer_Registration = s3 }
                                    ).ToList();

            }


            if (Fdate != null && Ldate != null && OrdID == null && DelStatus != null)
            {
                ViewBag.OrdList = (from s1 in db.CustomerOrder
                                   where s1.DeliveryStatus == DelStatus && (s1.CustOrdDate >= Fdate && s1.CustOrdDate <= Ldate)

                                   select new ComboPack { CustomerOrder = s1 }
                  ).ToList();

                ViewBag.OrderDtl = (from s1 in db.CustomerOrder
                                    join s2 in db.OrderedProducts on s1.OrderID equals s2.OP_OrderId
                                    join s3 in db.Customer_Registration on s1.CustID equals s3.Cust_RID

                                    where s1.DeliveryStatus == DelStatus && (s1.CustOrdDate >= Fdate && s1.CustOrdDate <= Ldate)

                                    select new ComboPack { CustomerOrder = s1, OrderedProducts = s2, Customer_Registration = s3 }
                                    ).ToList();

            }






            return View();
        }








        // <------------------- End Report ----------------------------->




        // <------------------ End Customer Orders ------------------->



        // <-==========@@@@@@@@@@ END Store @@@@@@@@@@@==================->
























        // @@@@@@@@@@@@@@@@@@@@  Report for javascript @@@@@@@@@@@@@@@


        // <---------------  Purchase Reports --------------------->
        public ActionResult ListPurchase_Report(string BillNo)
        {
            // BillNo = "0011";


            if (BillNo != null)
            {
                var data = db.OrganizationDetails.ToList().FirstOrDefault();
                ViewBag.name = data.OrgName;

                ViewBag.ListPurchaseDtl = (from s1 in db.PurchaseDtl
                                           join s2 in db.PurchaseForReport on s1.PurBillNo equals s2.PrBillNo
                                           join s4 in db.CustomerDetails on s1.PurSuppCustId equals s4.CustID
                                           join s5 in db.ProductDetails on s1.PurProductID equals s5.PDID
                                           join s6 in db.ProductGST on s5.GstPercent equals s6.ProdGstID
                                           join s7 in db.PurchaseDtlPurchaseReportBill on s1.PurBillNo equals s7.PrRBBillNo

                                           where s1.PurBillNo == BillNo
                                           select new ComboPack { PurchaseDtl = s1, PurchaseForReport = s2, CustDtl = s4, ProductDetails = s5, ProductGST = s6, PurchaseReportBill = s7 }).ToList();

                ViewBag.SumGst = ac.SumGstRs(BillNo);
            }
            else
            {
                return RedirectToAction("ListPurchaseDetails");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Search_FromDate_Purchase_Report()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Search_FromDate_Purchase_Report(DateTime? Fdate, DateTime? Ldate)
        {

            var data = db.OrganizationDetails.ToList().FirstOrDefault();

            ViewBag.name = data.OrgName;

            ViewBag.PurchaseDtl = ac.Purchase_FromDate_Report(Fdate, Ldate);

            ViewBag.FinalTotal = ac.Sum_FinalTotl_In_Puchase(Fdate, Ldate);


            //   ViewBag.Printf = "print";



            return View();
        }


        [HttpGet]
        public ActionResult ChargDisc_BillnoNDate_Purchase_Report()
        {
            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");

            return View();
        }
        [HttpPost]
        public ActionResult ChargDisc_BillnoNDate_Purchase_Report(DateTime? Fdate, DateTime? Ldate, string BillNo, int? CustId)
        {

            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");

            if (BillNo == "")
            {

                ViewBag.CustInfo = ac.CustInfo(Fdate, Ldate, CustId);

                ViewBag.ProductList = ac.Product_Report(Fdate, Ldate, CustId);

                ViewBag.DiscCharge = ac.DiscCharge_Report(Fdate, Ldate, CustId);

                ViewBag.GTotFTot = ac.GrandTotalFinalTotal_Report(Fdate, Ldate, CustId);
            }
            else
            {

                ViewBag.CustInfo = ac.CustInfo(BillNo);

                ViewBag.ProductList = ac.Product_Report(BillNo);

                ViewBag.DiscCharge = ac.DiscCharge_Report(BillNo);

                ViewBag.GTotFTot = ac.GrandTotalFinalTotal_Report(BillNo);

            }

            //  ViewBag.Printf = "print";




            return View();
        }


        [HttpGet]
        public ActionResult Payment_ChargDisc_BillnoNDate_Purchase_Report()
        {
            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");

            return View();
        }
        [HttpPost]
        public ActionResult Payment_ChargDisc_BillnoNDate_Purchase_Report(DateTime? Fdate, DateTime? Ldate, string BillNo, int? CustId)
        {

            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");

            if (BillNo == "")
            {
                ViewBag.CustInfo = ac.Payment_CustInfo(Fdate, Ldate, CustId);
                ViewBag.PaymentTransaction = ac.Payment_Transaction_Report(Fdate, Ldate, CustId);
                ViewBag.Outstand = ac.Payment_Outstanding_Report(CustId);
            }
            else
            {
                ViewBag.CustInfo = ac.Payment_CustInfo(BillNo);
                ViewBag.PaymentTransaction = ac.Payment_Transaction_Report(BillNo);
                ViewBag.Outstand = ac.Payment_Outstanding_Report(BillNo);
            }
            //   ViewBag.Printf = "print";

            return View();
        }

        [HttpGet]
        public ActionResult Transaction_FromDate_Purchase_Report()
        {
            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");

            return View();
        }
        [HttpPost]
        public ActionResult Transaction_FromDate_Purchase_Report(DateTime? Fdate, DateTime? Ldate)
        {
            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");

            ViewBag.CustInfo = ac.Payment_CustInfo_TransactionDtl_Report(Fdate, Ldate);
            ViewBag.PaymentTransaction = ac.Payment_TransactionDtl_Report(Fdate, Ldate);

            ViewBag.Printf = "print";
            return View();
        }

        [HttpGet]
        public ActionResult Transaction_CustNameFromDateBillNo_Purchase_Report()
        {
            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");

            return View();
        }
        [HttpPost]
        public ActionResult Transaction_CustNameFromDateBillNo_Purchase_Report(DateTime? Fdate, DateTime? Ldate, string BillNo, int? CustId)
        {
            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");

            if (BillNo == "")
            {
                ViewBag.CustInfo = ac.Payment_CustInfo_TransactionDtl_Report(Fdate, Ldate, CustId);
                ViewBag.PaymentTransaction = ac.Payment_TransactionDtl_Report(Fdate, Ldate, CustId);
            }
            else
            {

                ViewBag.CustInfo = ac.Payment_CustInfo_TransactionDtl_Report(BillNo);
                ViewBag.PaymentTransaction = ac.Payment_TransactionDtl_Report(BillNo);
            }

            // ViewBag.Printf = "print";

            return View();
        }

        [HttpGet]
        public ActionResult Transaction_CustNameFromDateBillNoPayStatus_Purchase_Report()
        {
            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");
            ViewBag.PaymentStatusList = new SelectList(db.PaymentStatus, "PayStId", "PayStName");

            return View();
        }
        [HttpPost]
        public ActionResult Transaction_CustNameFromDateBillNoPayStatus_Purchase_Report(DateTime? Fdate, DateTime? Ldate, string BillNo, int? CustId, int? PayStId)
        {
            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");
            ViewBag.PaymentStatusList = new SelectList(db.PaymentStatus, "PayStId", "PayStName");

            ViewBag.PayStId = PayStId;


            if (Fdate != null && Ldate != null && CustId == null)
            {
                ViewBag.CustInfo = ac.Payment_CustInfo_TransactionDtl_Report(Fdate, Ldate);
                ViewBag.PaymentTransaction = ac.Payment_TransactionDtl_Report(Fdate, Ldate);

            }

            if (Fdate != null && Ldate != null && CustId != null)
            {
                ViewBag.CustInfo = ac.Payment_CustInfo_TransactionDtl_Report(Fdate, Ldate, CustId);
                ViewBag.PaymentTransaction = ac.Payment_TransactionDtl_Report(Fdate, Ldate, CustId);

            }

            if (BillNo != "")
            {
                ViewBag.BillNoCustInfo = ac.Payment_CustInfo_TransactionDtl_Report(BillNo);
                ViewBag.BillNoPaymentTransaction = ac.Payment_TransactionDtl_Report(BillNo);
            }

            //if (CustId == null)
            //{
            //    ViewBag.CustInfo = ac.Payment_CustInfo_TransactionDtl_Report(Fdate, Ldate);
            //    ViewBag.PaymentTransaction = ac.Payment_TransactionDtl_Report(Fdate, Ldate);

            //}
            //else
            //{
            //    if (BillNo == "")
            //    {
            //        ViewBag.CustInfo = ac.Payment_CustInfo_TransactionDtl_Report(Fdate, Ldate, CustId);
            //        ViewBag.PaymentTransaction = ac.Payment_TransactionDtl_Report(Fdate, Ldate, CustId);

            //    }
            //    else
            //    {
            //        ViewBag.BillNoCustInfo = ac.Payment_CustInfo_TransactionDtl_Report(BillNo);
            //        ViewBag.BillNoPaymentTransaction = ac.Payment_TransactionDtl_Report(BillNo);
            //    }
            //}

            ViewBag.Printf = "print";

            return View();
        }

        [HttpGet]
        public ActionResult FinalTransaction_Purchase_Report()
        {
            ViewBag.FinalTotalAmt = ac.AllFinalTotalAmt();
            ViewBag.ReceivedAmt = ac.TotalTransactionAmt();
            return View();
        }

        public ActionResult SalesGstNGstbifercation()
        {

            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");

            return View();
        }
        [HttpPost]
        public ActionResult SalesGstNGstbifercation(DateTime? fdate, DateTime? ldate, int? CustId)
        {
            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");



            if (fdate != null && ldate != null && CustId == null)
            {
                ViewBag.GSTBifercation = ac.GST_Bifercation_Report(fdate, ldate);
            }

            if (fdate != null && ldate != null && CustId != null)
            {
                ViewBag.GSTBifercation = ac.GST_Bifercation_Report(fdate, ldate, CustId);
            }


            foreach (var item in ViewBag.GSTBifercation)
            {

                int gst = Convert.ToInt32(item.ProductGst);

                if (gst == 0)
                {
                    ViewBag.Total0 = item.PurTotal;
                    ViewBag.GST_Total0 = item.PurGstRs;

                    ViewBag.Final_Total0 = ViewBag.Total0 + ViewBag.GST_Total0;
                }
                if (gst == 5)
                {
                    ViewBag.Total5 = item.PurTotal;
                    ViewBag.GST_Total5 = item.PurGstRs;

                    ViewBag.Final_Total5 = ViewBag.Total5 + ViewBag.GST_Total5;
                }
                if (gst == 12)
                {
                    ViewBag.Total12 = item.PurTotal;
                    ViewBag.GST_Total12 = item.PurGstRs;

                    ViewBag.Final_Total12 = ViewBag.Total12 + ViewBag.GST_Total12;
                }
                if (gst == 18)
                {
                    ViewBag.Total18 = item.PurTotal;
                    ViewBag.GST_Total18 = item.PurGstRs;

                    ViewBag.Final_Total18 = ViewBag.Total18 + ViewBag.GST_Total18;
                }

                if (gst == 28)
                {
                    ViewBag.Total28 = item.PurTotal;
                    ViewBag.GST_Total28 = item.PurGstRs;

                    ViewBag.Final_Total28 = ViewBag.Total28 + ViewBag.GST_Total28;
                }
            }

            ViewBag.FinalPurchaseTotal = Convert.ToDecimal(ViewBag.Total0) + Convert.ToDecimal(ViewBag.Total5) + Convert.ToDecimal(ViewBag.Total12) + Convert.ToDecimal(ViewBag.Total18) + Convert.ToDecimal(ViewBag.Total28);
            ViewBag.FinalPurchaseGSTTotal = Convert.ToDecimal(ViewBag.GST_Total0) + Convert.ToDecimal(ViewBag.GST_Total5) + Convert.ToDecimal(ViewBag.GST_Total12) + Convert.ToDecimal(ViewBag.GST_Total18) + Convert.ToDecimal(ViewBag.GST_Total28);
            ViewBag.FinalTotal = Convert.ToDecimal(ViewBag.Final_Total0) + Convert.ToDecimal(ViewBag.Final_Total5) + Convert.ToDecimal(ViewBag.Final_Total12) + Convert.ToDecimal(ViewBag.Final_Total18) + Convert.ToDecimal(ViewBag.Final_Total28);

            //  ViewBag.Printf = "print";

            return View();
        }

        // <---------------   End Purchase Report ----------------->


        // <---------------  Sales Without Gst --------------------->
        public ActionResult ListSaleWiGst_Report(string BillNo)
        {

            if (BillNo != null)
            {

                ViewBag.ProductCount = ac.CountProduct_SaleWiGST(BillNo);

                ViewBag.ListOrgDtl = (from s1 in db.OrganizationDetails join s2 in db.state on s1.OrgState equals s2.SId join s3 in db.ActivationStatus on s1.OrgStatus equals s3.ActStsID select new ComboPack { OrganizationDetails = s1, state = s2, ActStats = s3 }).First();

                ViewBag.ListCustDtl = (from s1 in db.SalesBillWithoutGstDtl

                                       join s2 in db.CustomerDetails on s1.SalBilWiGSTSuppCustId equals s2.CustID
                                       join s3 in db.state on s2.CustStatus equals s3.SId
                                       join s4 in db.district on s2.CustDistrict equals s4.DistId
                                       join s5 in db.SalesBillWithoutGstDtl_ChargesDisc on s1.SalBilWiGSTBillNo equals s5.SalBiWiGst_BillNo
                                       join s6 in db.PaymentStatus on s5.SalBiWiGst_Status equals s6.PayStId
                                       join s7 in db.SalesBillWithoutGstDtl_Report on s1.SalBilWiGSTBillNo equals s7.SalBiWiGst_Rpt_BillNo

                                       where s1.SalBilWiGSTBillNo == BillNo
                                       select new ComboPack { SalesBillWithoutGstDtl = s1, CustDtl = s2, state = s3, district = s4, SalesBillWithoutGstDtl_ChargesDisc = s5, PaymentStatus = s6, SalesBillWithoutGstDtl_Report = s7 }).First();


                ViewBag.ProductsDtl = (from s1 in db.SalesBillWithoutGstDtl
                                       join s2 in db.ProductDetails on s1.SalBilWiGSTProductID equals s2.PDID
                                       join s3 in db.ProductGST on s2.GstPercent equals s3.ProdGstID

                                       where s1.SalBilWiGSTBillNo == BillNo

                                       select new ComboPack { SalesBillWithoutGstDtl = s1, ProductDetails = s2, ProductGST = s3 }).ToList();

                ViewBag.TermsNConditon = (from s1 in db.SaleWiGstTnC
                                          join s2 in db.TermsCondition on s1.SaleWiGstTnC_TCID equals s2.TCID

                                          where s1.SaleWiGstTnC_BillNo == BillNo

                                          select new ComboPack { SaleWiGstTnC = s1, TermsCondition = s2 }).ToList();


            }
            else
            {
                return RedirectToAction("ListSaleBillWithoutGst");
            }


            return View();
        }

        public ActionResult Search_FromDate_WithoutGst_Report()
        {


            return View();
        }

        [HttpPost]
        public ActionResult Search_FromDate_WithoutGst_Report(DateTime? Fdate, DateTime? Ldate)
        {

            ViewBag.ListOrgDtl = (from s1 in db.OrganizationDetails join s2 in db.state on s1.OrgState equals s2.SId join s3 in db.ActivationStatus on s1.OrgStatus equals s3.ActStsID select new ComboPack { OrganizationDetails = s1, state = s2, ActStats = s3 }).FirstOrDefault();

            ViewBag.ListBillNos = ac.List_BillNosSaleBilWiGst(Fdate, Ldate);



            ViewBag.ListCustDtl = (from s1 in db.SalesBillWithoutGstDtl

                                   join s2 in db.CustomerDetails on s1.SalBilWiGSTSuppCustId equals s2.CustID
                                   join s3 in db.state on s2.CustStatus equals s3.SId
                                   join s4 in db.district on s2.CustDistrict equals s4.DistId
                                   join s5 in db.SalesBillWithoutGstDtl_ChargesDisc on s1.SalBilWiGSTBillNo equals s5.SalBiWiGst_BillNo
                                   join s6 in db.PaymentStatus on s5.SalBiWiGst_Status equals s6.PayStId
                                   join s7 in db.SalesBillWithoutGstDtl_Report on s1.SalBilWiGSTBillNo equals s7.SalBiWiGst_Rpt_BillNo

                                   where (s1.SalBilWiGSTDate >= Fdate && s1.SalBilWiGSTDate <= Ldate)
                                   select new ComboPack { SalesBillWithoutGstDtl = s1, CustDtl = s2, state = s3, district = s4, SalesBillWithoutGstDtl_ChargesDisc = s5, PaymentStatus = s6, SalesBillWithoutGstDtl_Report = s7 }).ToList();


            ViewBag.ProductsDtl = (from s1 in db.SalesBillWithoutGstDtl
                                   join s2 in db.ProductDetails on s1.SalBilWiGSTProductID equals s2.PDID
                                   join s3 in db.ProductGST on s2.GstPercent equals s3.ProdGstID

                                   where (s1.SalBilWiGSTDate >= Fdate && s1.SalBilWiGSTDate <= Ldate)
                                   select new ComboPack { SalesBillWithoutGstDtl = s1, ProductDetails = s2, ProductGST = s3 }).ToList();


            ViewBag.TermsNConditon = (from s1 in db.SaleWiGstTnC
                                      join s2 in db.TermsCondition on s1.SaleWiGstTnC_TCID equals s2.TCID

                                      //   where (s1.SalBilWiGSTDate >= Fdate && s1.SalBilWiGSTDate <= Ldate)

                                      select new ComboPack { SaleWiGstTnC = s1, TermsCondition = s2 }).ToList();


            return View();
        }

        public ActionResult Search_Date_Cust_BillNo_Report()
        {
            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");

            return View();
        }

        [HttpPost]
        public ActionResult Search_Date_Cust_BillNo_Report(DateTime? Fdate, DateTime? Ldate, string BillNo, int? CustId)
        {

            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");

            ViewBag.ListOrgDtl = (from s1 in db.OrganizationDetails join s2 in db.state on s1.OrgState equals s2.SId join s3 in db.ActivationStatus on s1.OrgStatus equals s3.ActStsID select new ComboPack { OrganizationDetails = s1, state = s2, ActStats = s3 }).First();






            ViewBag.ListBillNos = ac.List_BillNosSaleBilWiGst(Fdate, Ldate, BillNo, CustId);



            if (Fdate != null && Ldate != null && CustId != null && BillNo == "")
            {

                ViewBag.ListCustDtl = (from s1 in db.SalesBillWithoutGstDtl

                                       join s2 in db.CustomerDetails on s1.SalBilWiGSTSuppCustId equals s2.CustID
                                       join s3 in db.state on s2.CustStatus equals s3.SId
                                       join s4 in db.district on s2.CustDistrict equals s4.DistId
                                       join s5 in db.SalesBillWithoutGstDtl_ChargesDisc on s1.SalBilWiGSTBillNo equals s5.SalBiWiGst_BillNo
                                       join s6 in db.PaymentStatus on s5.SalBiWiGst_Status equals s6.PayStId
                                       join s7 in db.SalesBillWithoutGstDtl_Report on s1.SalBilWiGSTBillNo equals s7.SalBiWiGst_Rpt_BillNo

                                       where s1.SalBilWiGSTSuppCustId == CustId && (s1.SalBilWiGSTDate >= Fdate && s1.SalBilWiGSTDate <= Ldate)
                                       select new ComboPack { SalesBillWithoutGstDtl = s1, CustDtl = s2, state = s3, district = s4, SalesBillWithoutGstDtl_ChargesDisc = s5, PaymentStatus = s6, SalesBillWithoutGstDtl_Report = s7 }).ToList();


                ViewBag.ProductsDtl = (from s1 in db.SalesBillWithoutGstDtl
                                       join s2 in db.ProductDetails on s1.SalBilWiGSTProductID equals s2.PDID
                                       join s3 in db.ProductGST on s2.GstPercent equals s3.ProdGstID

                                       where s1.SalBilWiGSTSuppCustId == CustId && (s1.SalBilWiGSTDate >= Fdate && s1.SalBilWiGSTDate <= Ldate)
                                       select new ComboPack { SalesBillWithoutGstDtl = s1, ProductDetails = s2, ProductGST = s3 }).ToList();

                ViewBag.TermsNConditon = (from s1 in db.SaleWiGstTnC
                                          join s2 in db.TermsCondition on s1.SaleWiGstTnC_TCID equals s2.TCID

                                          //   where (s1.SalBilWiGSTDate >= Fdate && s1.SalBilWiGSTDate <= Ldate)

                                          select new ComboPack { SaleWiGstTnC = s1, TermsCondition = s2 }).ToList();

            }



            if (BillNo != "" && Fdate == null && Ldate == null && CustId == null)
            {

                ViewBag.ProductCount = ac.CountProduct_SaleWiGST(BillNo);



                ViewBag.ListCustDtl = (from s1 in db.SalesBillWithoutGstDtl

                                       join s2 in db.CustomerDetails on s1.SalBilWiGSTSuppCustId equals s2.CustID
                                       join s3 in db.state on s2.CustStatus equals s3.SId
                                       join s4 in db.district on s2.CustDistrict equals s4.DistId
                                       join s5 in db.SalesBillWithoutGstDtl_ChargesDisc on s1.SalBilWiGSTBillNo equals s5.SalBiWiGst_BillNo
                                       join s6 in db.PaymentStatus on s5.SalBiWiGst_Status equals s6.PayStId
                                       join s7 in db.SalesBillWithoutGstDtl_Report on s1.SalBilWiGSTBillNo equals s7.SalBiWiGst_Rpt_BillNo

                                       where s1.SalBilWiGSTBillNo == BillNo
                                       select new ComboPack { SalesBillWithoutGstDtl = s1, CustDtl = s2, state = s3, district = s4, SalesBillWithoutGstDtl_ChargesDisc = s5, PaymentStatus = s6, SalesBillWithoutGstDtl_Report = s7 }).ToList();


                ViewBag.ProductsDtl = (from s1 in db.SalesBillWithoutGstDtl
                                       join s2 in db.ProductDetails on s1.SalBilWiGSTProductID equals s2.PDID
                                       join s3 in db.ProductGST on s2.GstPercent equals s3.ProdGstID

                                       where s1.SalBilWiGSTBillNo == BillNo
                                       select new ComboPack { SalesBillWithoutGstDtl = s1, ProductDetails = s2, ProductGST = s3 }).ToList();

                ViewBag.TermsNConditon = (from s1 in db.SaleWiGstTnC
                                          join s2 in db.TermsCondition on s1.SaleWiGstTnC_TCID equals s2.TCID

                                          //   where (s1.SalBilWiGSTDate >= Fdate && s1.SalBilWiGSTDate <= Ldate)

                                          select new ComboPack { SaleWiGstTnC = s1, TermsCondition = s2 }).ToList();

            }


            return View();
        }

        public ActionResult Total_Amt_Report()
        {
            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");
            //  ViewBag.PaymentStatusList = new SelectList(db.PaymentStatus, "PayStId", "PayStName");


            return View();
        }

        [HttpPost]
        public ActionResult Total_Amt_Report(DateTime? Fdate, DateTime? Ldate, int? CustId)
        {
            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");



            ViewBag.ListTotlAmt = ac.TotalAmt_BillNosSaleBilWiGst(Fdate, Ldate, CustId);



            return View();
        }

        public ActionResult Status_Wise_Report()
        {
            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");
            ViewBag.PaymentStatusList = new SelectList(db.PaymentStatus, "PayStId", "PayStName");


            return View();
        }
        [HttpPost]
        public ActionResult Status_Wise_Report(DateTime? Fdate, DateTime? Ldate, int? CustId, int? PayStId)
        {
            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");
            ViewBag.PaymentStatusList = new SelectList(db.PaymentStatus, "PayStId", "PayStName");

            ViewBag.ListOrgDtl = (from s1 in db.OrganizationDetails join s2 in db.state on s1.OrgState equals s2.SId join s3 in db.ActivationStatus on s1.OrgStatus equals s3.ActStsID select new ComboPack { OrganizationDetails = s1, state = s2, ActStats = s3 }).First();


            ViewBag.ListBillNos = ac.List_BillNosSaleBilWiGst(Fdate, Ldate, CustId, PayStId);



            if (Fdate != null && Ldate != null && CustId != null && PayStId != null)
            {

                ViewBag.ListCustDtl = (from s1 in db.SalesBillWithoutGstDtl

                                       join s2 in db.CustomerDetails on s1.SalBilWiGSTSuppCustId equals s2.CustID
                                       join s3 in db.state on s2.CustStatus equals s3.SId
                                       join s4 in db.district on s2.CustDistrict equals s4.DistId
                                       join s5 in db.SalesBillWithoutGstDtl_ChargesDisc on s1.SalBilWiGSTBillNo equals s5.SalBiWiGst_BillNo
                                       join s6 in db.PaymentStatus on s5.SalBiWiGst_Status equals s6.PayStId
                                       join s7 in db.SalesBillWithoutGstDtl_Report on s1.SalBilWiGSTBillNo equals s7.SalBiWiGst_Rpt_BillNo

                                       where s1.SalBilWiGSTSuppCustId == CustId && (s1.SalBilWiGSTDate >= Fdate && s1.SalBilWiGSTDate <= Ldate) && s5.SalBiWiGst_Status == PayStId

                                       select new ComboPack { SalesBillWithoutGstDtl = s1, CustDtl = s2, state = s3, district = s4, SalesBillWithoutGstDtl_ChargesDisc = s5, PaymentStatus = s6, SalesBillWithoutGstDtl_Report = s7 }).ToList();


                ViewBag.ProductsDtl = (from s1 in db.SalesBillWithoutGstDtl
                                       join s2 in db.ProductDetails on s1.SalBilWiGSTProductID equals s2.PDID
                                       join s3 in db.ProductGST on s2.GstPercent equals s3.ProdGstID

                                       join s5 in db.SalesBillWithoutGstDtl_ChargesDisc on s1.SalBilWiGSTBillNo equals s5.SalBiWiGst_BillNo

                                       //    where s1.SalBilWiGSTSuppCustId == CustId && (s1.SalBilWiGSTDate >= Fdate && s1.SalBilWiGSTDate <= Ldate)
                                       where s1.SalBilWiGSTSuppCustId == CustId && (s1.SalBilWiGSTDate >= Fdate && s1.SalBilWiGSTDate <= Ldate) && s5.SalBiWiGst_Status == PayStId
                                       select new ComboPack { SalesBillWithoutGstDtl = s1, ProductDetails = s2, ProductGST = s3, SalesBillWithoutGstDtl_ChargesDisc = s5 }).ToList();

                ViewBag.TermsNConditon = (from s1 in db.SaleWiGstTnC
                                          join s2 in db.TermsCondition on s1.SaleWiGstTnC_TCID equals s2.TCID

                                          //   where (s1.SalBilWiGSTDate >= Fdate && s1.SalBilWiGSTDate <= Ldate)

                                          select new ComboPack { SaleWiGstTnC = s1, TermsCondition = s2 }).ToList();

            }



            if (Fdate != null && Ldate != null && CustId == null && PayStId != null)
            {

                ViewBag.ListCustDtl = (from s1 in db.SalesBillWithoutGstDtl

                                       join s2 in db.CustomerDetails on s1.SalBilWiGSTSuppCustId equals s2.CustID
                                       join s3 in db.state on s2.CustStatus equals s3.SId
                                       join s4 in db.district on s2.CustDistrict equals s4.DistId
                                       join s5 in db.SalesBillWithoutGstDtl_ChargesDisc on s1.SalBilWiGSTBillNo equals s5.SalBiWiGst_BillNo
                                       join s6 in db.PaymentStatus on s5.SalBiWiGst_Status equals s6.PayStId
                                       join s7 in db.SalesBillWithoutGstDtl_Report on s1.SalBilWiGSTBillNo equals s7.SalBiWiGst_Rpt_BillNo


                                       where (s1.SalBilWiGSTDate >= Fdate && s1.SalBilWiGSTDate <= Ldate) && s5.SalBiWiGst_Status == PayStId

                                       select new ComboPack { SalesBillWithoutGstDtl = s1, CustDtl = s2, state = s3, district = s4, SalesBillWithoutGstDtl_ChargesDisc = s5, PaymentStatus = s6, SalesBillWithoutGstDtl_Report = s7 }).ToList();


                ViewBag.ProductsDtl = (from s1 in db.SalesBillWithoutGstDtl
                                       join s2 in db.ProductDetails on s1.SalBilWiGSTProductID equals s2.PDID
                                       join s3 in db.ProductGST on s2.GstPercent equals s3.ProdGstID

                                       join s5 in db.SalesBillWithoutGstDtl_ChargesDisc on s1.SalBilWiGSTBillNo equals s5.SalBiWiGst_BillNo

                                       where (s1.SalBilWiGSTDate >= Fdate && s1.SalBilWiGSTDate <= Ldate) && s5.SalBiWiGst_Status == PayStId
                                       select new ComboPack { SalesBillWithoutGstDtl = s1, ProductDetails = s2, ProductGST = s3, SalesBillWithoutGstDtl_ChargesDisc = s5 }).ToList();

                ViewBag.TermsNConditon = (from s1 in db.SaleWiGstTnC
                                          join s2 in db.TermsCondition on s1.SaleWiGstTnC_TCID equals s2.TCID

                                          //   where (s1.SalBilWiGSTDate >= Fdate && s1.SalBilWiGSTDate <= Ldate)

                                          select new ComboPack { SaleWiGstTnC = s1, TermsCondition = s2 }).ToList();

            }


            return View();
        }


        // <--------------- End Sales Without Gst ------------------->


        public ActionResult ListSaleGst_Report(string BillNo)
        {

            if (BillNo != null)
            {


                ViewBag.ProductCount = ac.CountProduct_SaleGST(BillNo);


                ViewBag.ListOrgDtl = (from s1 in db.OrganizationDetails
                                      join s2 in db.state on s1.OrgState equals s2.SId
                                      join s3 in db.ActivationStatus on s1.OrgStatus equals s3.ActStsID
                                      //        join s4 in db.BankDetails on s1.OrgID equals s4.OrgID

                                      select new ComboPack { OrganizationDetails = s1, state = s2, ActStats = s3 /*, BankDetails = s4*/ }).First();



                ViewBag.ListOrgBnkDtl = (from s1 in db.OrganizationDetails
                                         join s4 in db.BankDetails on s1.OrgID equals s4.OrgID

                                         select new ComboPack { OrganizationDetails = s1, BankDetails = s4 }).ToList();




                ViewBag.ListCustDtl = (from s1 in db.SalesGST

                                       join s2 in db.CustomerDetails on s1.SaleGST_SuppCustId equals s2.CustID
                                       join s3 in db.state on s2.CustStatus equals s3.SId
                                       join s4 in db.district on s2.CustDistrict equals s4.DistId
                                       join s5 in db.SalesGST_ChargeDisc on s1.SaleGST_BillNo equals s5.SalesGST_BillNo

                                       // join s6 in db.BankDetails on s5.SalBiWiGst_Status equals s6.PayStId

                                       join s7 in db.SalesGST_Report on s1.SaleGST_BillNo equals s7.SalesGST_Rpt_BillNo

                                       where s1.SaleGST_BillNo == BillNo

                                       select new ComboPack { SalesGST = s1, CustDtl = s2, state = s3, district = s4, SalesGST_ChargeDisc = s5, /*PaymentStatus = s6,*/ SalesGST_Report = s7 }).FirstOrDefault();



                ViewBag.ProductsDtl = (from s1 in db.SalesGST
                                       join s2 in db.ProductDetails on s1.SaleGST_ProductID equals s2.PDID
                                       join s3 in db.ProductGST on s2.GstPercent equals s3.ProdGstID

                                       where s1.SaleGST_BillNo == BillNo
                                       select new ComboPack { SalesGST = s1, ProductDetails = s2, ProductGST = s3 }).ToList();






                ViewBag.ListDiscFitotalDtl = (from s1 in db.SalesGST_Report
                                              join s2 in db.SalesGST_ChargeDisc on s1.SalesGST_Rpt_BillNo equals s2.SalesGST_BillNo

                                              where s1.SalesGST_Rpt_BillNo == BillNo
                                              select new ComboPack { SalesGST_Report = s1, SalesGST_ChargeDisc = s2 }).ToList();







                ViewBag.TermsNConditon = (from s1 in db.SalesGst_Tnc
                                          join s2 in db.TermsCondition on s1.SalesGst_TCID equals s2.TCID


                                          where s1.SalesGst_BillNo == BillNo

                                          select new ComboPack { SalesGst_Tnc = s1, TermsCondition = s2 }).ToList();


            }
            else
            {
                return RedirectToAction("ListSaleGst");
            }
            return View();
        }

        public ActionResult Search_FromDate_WithGst_Report()
        {


            return View();
        }

        [HttpPost]
        public ActionResult Search_FromDate_WithGst_Report(DateTime? Fdate, DateTime? Ldate)
        {



            ViewBag.ListOrgDtl = (from s1 in db.OrganizationDetails
                                  join s2 in db.state on s1.OrgState equals s2.SId
                                  join s3 in db.ActivationStatus on s1.OrgStatus equals s3.ActStsID
                                  //  join s4 in db.BankDetails on s1.OrgID equals s4.OrgID

                                  select new ComboPack { OrganizationDetails = s1, state = s2, ActStats = s3 /*BankDetails = s4 */}).FirstOrDefault();

            ViewBag.ListOrgBnkDtl = (from s1 in db.OrganizationDetails
                                     join s4 in db.BankDetails on s1.OrgID equals s4.OrgID

                                     select new ComboPack { OrganizationDetails = s1, BankDetails = s4 }).ToList();



            ViewBag.ListBillNos = ac.List_BillNosSaleBilGst(Fdate, Ldate);

            ViewBag.ListCustDtl = (from s1 in db.SalesGST

                                   join s2 in db.CustomerDetails on s1.SaleGST_SuppCustId equals s2.CustID
                                   join s3 in db.state on s2.CustStatus equals s3.SId
                                   join s4 in db.district on s2.CustDistrict equals s4.DistId
                                   join s5 in db.SalesGST_ChargeDisc on s1.SaleGST_BillNo equals s5.SalesGST_BillNo

                                   // join s6 in db.BankDetails on s5.SalBiWiGst_Status equals s6.PayStId

                                   join s7 in db.SalesGST_Report on s1.SaleGST_BillNo equals s7.SalesGST_Rpt_BillNo
                                   where (s1.SaleGST_Date >= Fdate && s1.SaleGST_Date <= Ldate)
                                   select new ComboPack { SalesGST = s1, CustDtl = s2, state = s3, district = s4, SalesGST_ChargeDisc = s5, /*PaymentStatus = s6,*/ SalesGST_Report = s7 }).ToList();

            ViewBag.ProductsDtl = (from s1 in db.SalesGST
                                   join s2 in db.ProductDetails on s1.SaleGST_ProductID equals s2.PDID
                                   join s3 in db.ProductGST on s2.GstPercent equals s3.ProdGstID

                                   where (s1.SaleGST_Date >= Fdate && s1.SaleGST_Date <= Ldate)
                                   select new ComboPack { SalesGST = s1, ProductDetails = s2, ProductGST = s3 }).ToList();



            ViewBag.ListDiscFitotalDtl = (from s1 in db.SalesGST_Report
                                          join s2 in db.SalesGST_ChargeDisc on s1.SalesGST_Rpt_BillNo equals s2.SalesGST_BillNo

                                          where (s1.SalesGST_Rpt_date >= Fdate && s1.SalesGST_Rpt_date <= Ldate)
                                          select new ComboPack { SalesGST_Report = s1, SalesGST_ChargeDisc = s2 }).ToList();

            ViewBag.TermsNConditon = (from s1 in db.SalesGst_Tnc
                                      join s2 in db.TermsCondition on s1.SalesGst_TCID equals s2.TCID

                                      //   where s1.SalesGst_BillNo == BillNo
                                      select new ComboPack { SalesGst_Tnc = s1, TermsCondition = s2 }).ToList();

            return View();
        }


        public ActionResult Search_FromDateCustNameBill_WithGst_Report()
        {
            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");

            return View();
        }
        [HttpPost]
        public ActionResult Search_FromDateCustNameBill_WithGst_Report(DateTime? Fdate, DateTime? Ldate, string BillNo, int? CustId)
        {
            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");


            ViewBag.ListOrgDtl = (from s1 in db.OrganizationDetails
                                  join s2 in db.state on s1.OrgState equals s2.SId
                                  join s3 in db.ActivationStatus on s1.OrgStatus equals s3.ActStsID
                                  // join s4 in db.BankDetails on s1.OrgID equals s4.OrgID

                                  select new ComboPack { OrganizationDetails = s1, state = s2, ActStats = s3/*, BankDetails = s4*/ }).First();

            ViewBag.ListOrgBnkDtl = (from s1 in db.OrganizationDetails
                                     join s4 in db.BankDetails on s1.OrgID equals s4.OrgID

                                     select new ComboPack { OrganizationDetails = s1, BankDetails = s4 }).ToList();



            ViewBag.ListBillNos = ac.List_BillNosSaleBilGst(Fdate, Ldate, BillNo, CustId);





            if (Fdate != null && Ldate != null && CustId != null && BillNo == "")
            {


                //  ViewBag.ListBillNos = ac.List_BillNosSaleBilGst(Fdate, Ldate);



                ViewBag.ListCustDtl = (from s1 in db.SalesGST

                                       join s2 in db.CustomerDetails on s1.SaleGST_SuppCustId equals s2.CustID
                                       join s3 in db.state on s2.CustStatus equals s3.SId
                                       join s4 in db.district on s2.CustDistrict equals s4.DistId
                                       join s5 in db.SalesGST_ChargeDisc on s1.SaleGST_BillNo equals s5.SalesGST_BillNo

                                       // join s6 in db.BankDetails on s5.SalBiWiGst_Status equals s6.PayStId

                                       join s7 in db.SalesGST_Report on s1.SaleGST_BillNo equals s7.SalesGST_Rpt_BillNo
                                       where (s1.SaleGST_Date >= Fdate && s1.SaleGST_Date <= Ldate) && s1.SaleGST_SuppCustId == CustId
                                       select new ComboPack { SalesGST = s1, CustDtl = s2, state = s3, district = s4, SalesGST_ChargeDisc = s5, /*PaymentStatus = s6,*/ SalesGST_Report = s7 }).ToList();



                ViewBag.ProductsDtl = (from s1 in db.SalesGST
                                       join s2 in db.ProductDetails on s1.SaleGST_ProductID equals s2.PDID
                                       join s3 in db.ProductGST on s2.GstPercent equals s3.ProdGstID

                                       where (s1.SaleGST_Date >= Fdate && s1.SaleGST_Date <= Ldate) && s1.SaleGST_SuppCustId == CustId
                                       select new ComboPack { SalesGST = s1, ProductDetails = s2, ProductGST = s3 }).ToList();




                ViewBag.ListDiscFitotalDtl = (from s1 in db.SalesGST_Report
                                              join s2 in db.SalesGST_ChargeDisc on s1.SalesGST_Rpt_BillNo equals s2.SalesGST_BillNo

                                              where (s1.SalesGST_Rpt_date >= Fdate && s1.SalesGST_Rpt_date <= Ldate)
                                              select new ComboPack { SalesGST_Report = s1, SalesGST_ChargeDisc = s2 }).ToList();



                ViewBag.TermsNConditon = (from s1 in db.SalesGst_Tnc
                                          join s2 in db.TermsCondition on s1.SalesGst_TCID equals s2.TCID

                                          //   where s1.SalesGst_BillNo == BillNo
                                          select new ComboPack { SalesGst_Tnc = s1, TermsCondition = s2 }).ToList();




            }



            if (BillNo != "" && Fdate == null && Ldate == null && CustId == null)
            {


                ViewBag.ProductCount = ac.CountProduct_SaleGST(BillNo);


                ViewBag.ListCustDtl = (from s1 in db.SalesGST

                                       join s2 in db.CustomerDetails on s1.SaleGST_SuppCustId equals s2.CustID
                                       join s3 in db.state on s2.CustStatus equals s3.SId
                                       join s4 in db.district on s2.CustDistrict equals s4.DistId
                                       join s5 in db.SalesGST_ChargeDisc on s1.SaleGST_BillNo equals s5.SalesGST_BillNo

                                       // join s6 in db.BankDetails on s5.SalBiWiGst_Status equals s6.PayStId

                                       join s7 in db.SalesGST_Report on s1.SaleGST_BillNo equals s7.SalesGST_Rpt_BillNo
                                       where s1.SaleGST_BillNo == BillNo
                                       select new ComboPack { SalesGST = s1, CustDtl = s2, state = s3, district = s4, SalesGST_ChargeDisc = s5, /*PaymentStatus = s6,*/ SalesGST_Report = s7 }).ToList();



                ViewBag.ProductsDtl = (from s1 in db.SalesGST
                                       join s2 in db.ProductDetails on s1.SaleGST_ProductID equals s2.PDID
                                       join s3 in db.ProductGST on s2.GstPercent equals s3.ProdGstID

                                       where s1.SaleGST_BillNo == BillNo
                                       select new ComboPack { SalesGST = s1, ProductDetails = s2, ProductGST = s3 }).ToList();




                ViewBag.ListDiscFitotalDtl = (from s1 in db.SalesGST_Report
                                              join s2 in db.SalesGST_ChargeDisc on s1.SalesGST_Rpt_BillNo equals s2.SalesGST_BillNo

                                              where s1.SalesGST_Rpt_BillNo == BillNo
                                              select new ComboPack { SalesGST_Report = s1, SalesGST_ChargeDisc = s2 }).ToList();



                ViewBag.TermsNConditon = (from s1 in db.SalesGst_Tnc
                                          join s2 in db.TermsCondition on s1.SalesGst_TCID equals s2.TCID

                                          where s1.SalesGst_BillNo == BillNo
                                          select new ComboPack { SalesGst_Tnc = s1, TermsCondition = s2 }).ToList();


            }

            return View();
        }





        public ActionResult Total_Amt_Sale_Gst_Report()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Total_Amt_Sale_Gst_Report(DateTime? Fdate, DateTime? Ldate)
        {

            ViewBag.ListTotlAmt = ac.TotalAmt_BillNosSaleBilGst(Fdate, Ldate);


            return View();
        }


        public ActionResult AllInOne_SaleGst_Report()
        {

            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");

            return View();
        }
        [HttpPost]
        public ActionResult AllInOne_SaleGst_Report(DateTime? Fdate, DateTime? Ldate, string BillNo, int? CustId)
        {
            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");


            ViewBag.ListOrgDtl = (from s1 in db.OrganizationDetails
                                  join s2 in db.state on s1.OrgState equals s2.SId
                                  join s3 in db.ActivationStatus on s1.OrgStatus equals s3.ActStsID
                                  //    join s4 in db.BankDetails on s1.OrgID equals s4.OrgID

                                  select new ComboPack { OrganizationDetails = s1, state = s2, ActStats = s3/*, BankDetails = s4*/ }).FirstOrDefault();

            ViewBag.ListOrgBnkDtl = (from s1 in db.OrganizationDetails
                                     join s4 in db.BankDetails on s1.OrgID equals s4.OrgID

                                     select new ComboPack { OrganizationDetails = s1, BankDetails = s4 }).ToList();



            ViewBag.ListBillNos = ac.List_BillNosSaleBilGst(Fdate, Ldate, CustId, BillNo);





            if (Fdate != null && Ldate != null && CustId != null && BillNo == "")
            {




                ViewBag.ListCustDtl = (from s1 in db.SalesGST

                                       join s2 in db.CustomerDetails on s1.SaleGST_SuppCustId equals s2.CustID
                                       join s3 in db.state on s2.CustStatus equals s3.SId
                                       join s4 in db.district on s2.CustDistrict equals s4.DistId
                                       join s5 in db.SalesGST_ChargeDisc on s1.SaleGST_BillNo equals s5.SalesGST_BillNo

                                       // join s6 in db.BankDetails on s5.SalBiWiGst_Status equals s6.PayStId

                                       join s7 in db.SalesGST_Report on s1.SaleGST_BillNo equals s7.SalesGST_Rpt_BillNo
                                       where (s1.SaleGST_Date >= Fdate && s1.SaleGST_Date <= Ldate) && s1.SaleGST_SuppCustId == CustId
                                       select new ComboPack { SalesGST = s1, CustDtl = s2, state = s3, district = s4, SalesGST_ChargeDisc = s5, /*PaymentStatus = s6,*/ SalesGST_Report = s7 }).ToList();



                ViewBag.ProductsDtl = (from s1 in db.SalesGST
                                       join s2 in db.ProductDetails on s1.SaleGST_ProductID equals s2.PDID
                                       join s3 in db.ProductGST on s2.GstPercent equals s3.ProdGstID

                                       where (s1.SaleGST_Date >= Fdate && s1.SaleGST_Date <= Ldate) && s1.SaleGST_SuppCustId == CustId
                                       select new ComboPack { SalesGST = s1, ProductDetails = s2, ProductGST = s3 }).ToList();




                ViewBag.ListDiscFitotalDtl = (from s1 in db.SalesGST_Report
                                              join s2 in db.SalesGST_ChargeDisc on s1.SalesGST_Rpt_BillNo equals s2.SalesGST_BillNo

                                              where (s1.SalesGST_Rpt_date >= Fdate && s1.SalesGST_Rpt_date <= Ldate)
                                              select new ComboPack { SalesGST_Report = s1, SalesGST_ChargeDisc = s2 }).ToList();



                ViewBag.TermsNConditon = (from s1 in db.SalesGst_Tnc
                                          join s2 in db.TermsCondition on s1.SalesGst_TCID equals s2.TCID

                                          //   where s1.SalesGst_BillNo == BillNo
                                          select new ComboPack { SalesGst_Tnc = s1, TermsCondition = s2 }).ToList();


                ViewBag.PaymentTransaction = ac.AllInOne_Transaction_WtGST_Report(Fdate, Ldate, CustId);

            }

            if (Fdate != null && Ldate != null && CustId == null && BillNo == "")
            {

                ViewBag.ListCustDtl = (from s1 in db.SalesGST

                                       join s2 in db.CustomerDetails on s1.SaleGST_SuppCustId equals s2.CustID
                                       join s3 in db.state on s2.CustStatus equals s3.SId
                                       join s4 in db.district on s2.CustDistrict equals s4.DistId
                                       join s5 in db.SalesGST_ChargeDisc on s1.SaleGST_BillNo equals s5.SalesGST_BillNo

                                       // join s6 in db.BankDetails on s5.SalBiWiGst_Status equals s6.PayStId

                                       join s7 in db.SalesGST_Report on s1.SaleGST_BillNo equals s7.SalesGST_Rpt_BillNo
                                       where (s1.SaleGST_Date >= Fdate && s1.SaleGST_Date <= Ldate)
                                       select new ComboPack { SalesGST = s1, CustDtl = s2, state = s3, district = s4, SalesGST_ChargeDisc = s5, /*PaymentStatus = s6,*/ SalesGST_Report = s7 }).ToList();



                ViewBag.ProductsDtl = (from s1 in db.SalesGST
                                       join s2 in db.ProductDetails on s1.SaleGST_ProductID equals s2.PDID
                                       join s3 in db.ProductGST on s2.GstPercent equals s3.ProdGstID

                                       where (s1.SaleGST_Date >= Fdate && s1.SaleGST_Date <= Ldate)
                                       select new ComboPack { SalesGST = s1, ProductDetails = s2, ProductGST = s3 }).ToList();




                ViewBag.ListDiscFitotalDtl = (from s1 in db.SalesGST_Report
                                              join s2 in db.SalesGST_ChargeDisc on s1.SalesGST_Rpt_BillNo equals s2.SalesGST_BillNo

                                              where (s1.SalesGST_Rpt_date >= Fdate && s1.SalesGST_Rpt_date <= Ldate)
                                              select new ComboPack { SalesGST_Report = s1, SalesGST_ChargeDisc = s2 }).ToList();



                ViewBag.TermsNConditon = (from s1 in db.SalesGst_Tnc
                                          join s2 in db.TermsCondition on s1.SalesGst_TCID equals s2.TCID

                                          //   where s1.SalesGst_BillNo == BillNo
                                          select new ComboPack { SalesGst_Tnc = s1, TermsCondition = s2 }).ToList();


                ViewBag.PaymentTransaction = ac.AllInOne_Transaction_WtGST_Report(Fdate, Ldate, CustId);

            }


            if (Fdate == null && Ldate == null && CustId == null && BillNo != "")
            {

                ViewBag.ProductCount = ac.CountProduct_SaleGST(BillNo);


                ViewBag.ListCustDtl = (from s1 in db.SalesGST

                                       join s2 in db.CustomerDetails on s1.SaleGST_SuppCustId equals s2.CustID
                                       join s3 in db.state on s2.CustStatus equals s3.SId
                                       join s4 in db.district on s2.CustDistrict equals s4.DistId
                                       join s5 in db.SalesGST_ChargeDisc on s1.SaleGST_BillNo equals s5.SalesGST_BillNo

                                       // join s6 in db.BankDetails on s5.SalBiWiGst_Status equals s6.PayStId

                                       join s7 in db.SalesGST_Report on s1.SaleGST_BillNo equals s7.SalesGST_Rpt_BillNo
                                       where s1.SaleGST_BillNo == BillNo
                                       select new ComboPack { SalesGST = s1, CustDtl = s2, state = s3, district = s4, SalesGST_ChargeDisc = s5, /*PaymentStatus = s6,*/ SalesGST_Report = s7 }).ToList();



                ViewBag.ProductsDtl = (from s1 in db.SalesGST
                                       join s2 in db.ProductDetails on s1.SaleGST_ProductID equals s2.PDID
                                       join s3 in db.ProductGST on s2.GstPercent equals s3.ProdGstID

                                       where s1.SaleGST_BillNo == BillNo
                                       select new ComboPack { SalesGST = s1, ProductDetails = s2, ProductGST = s3 }).ToList();




                ViewBag.ListDiscFitotalDtl = (from s1 in db.SalesGST_Report
                                              join s2 in db.SalesGST_ChargeDisc on s1.SalesGST_Rpt_BillNo equals s2.SalesGST_BillNo

                                              where s1.SalesGST_Rpt_BillNo == BillNo
                                              select new ComboPack { SalesGST_Report = s1, SalesGST_ChargeDisc = s2 }).ToList();



                ViewBag.TermsNConditon = (from s1 in db.SalesGst_Tnc
                                          join s2 in db.TermsCondition on s1.SalesGst_TCID equals s2.TCID

                                          where s1.SalesGst_BillNo == BillNo
                                          select new ComboPack { SalesGst_Tnc = s1, TermsCondition = s2 }).ToList();


                ViewBag.PaymentTransaction = ac.AllInOne_Transaction_WtGST_Report(BillNo);

            }




            return View();
        }


        public ActionResult Payment_Date_SaleGst_Report()
        {

            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");

            return View();
        }
        [HttpPost]
        public ActionResult Payment_Date_SaleGst_Report(DateTime? Fdate, DateTime? Ldate, string BillNo, int? CustId)
        {

            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");


            ViewBag.ListOrgDtl = (from s1 in db.OrganizationDetails
                                  join s2 in db.state on s1.OrgState equals s2.SId
                                  join s3 in db.ActivationStatus on s1.OrgStatus equals s3.ActStsID
                                  //   join s4 in db.BankDetails on s1.OrgID equals s4.OrgID

                                  select new ComboPack { OrganizationDetails = s1, state = s2, ActStats = s3/*, BankDetails = s4*/ }).First();

            ViewBag.ListOrgBnkDtl = (from s1 in db.OrganizationDetails
                                     join s4 in db.BankDetails on s1.OrgID equals s4.OrgID

                                     select new ComboPack { OrganizationDetails = s1, BankDetails = s4 }).ToList();



            ViewBag.ListBillNos = ac.List_BillNosSaleBilGst(Fdate, Ldate, CustId, BillNo);





            if (Fdate != null && Ldate != null && CustId != null && BillNo == "")
            {




                ViewBag.ListCustDtl = (from s1 in db.SalesGST

                                       join s2 in db.CustomerDetails on s1.SaleGST_SuppCustId equals s2.CustID
                                       join s3 in db.state on s2.CustStatus equals s3.SId
                                       join s4 in db.district on s2.CustDistrict equals s4.DistId
                                       join s5 in db.SalesGST_ChargeDisc on s1.SaleGST_BillNo equals s5.SalesGST_BillNo

                                       // join s6 in db.BankDetails on s5.SalBiWiGst_Status equals s6.PayStId

                                       join s7 in db.SalesGST_Report on s1.SaleGST_BillNo equals s7.SalesGST_Rpt_BillNo
                                       where (s1.SaleGST_Date >= Fdate && s1.SaleGST_Date <= Ldate) && s1.SaleGST_SuppCustId == CustId
                                       select new ComboPack { SalesGST = s1, CustDtl = s2, state = s3, district = s4, SalesGST_ChargeDisc = s5, /*PaymentStatus = s6,*/ SalesGST_Report = s7 }).ToList();



                ViewBag.ProductsDtl = (from s1 in db.SalesGST
                                       join s2 in db.ProductDetails on s1.SaleGST_ProductID equals s2.PDID
                                       join s3 in db.ProductGST on s2.GstPercent equals s3.ProdGstID

                                       where (s1.SaleGST_Date >= Fdate && s1.SaleGST_Date <= Ldate) && s1.SaleGST_SuppCustId == CustId
                                       select new ComboPack { SalesGST = s1, ProductDetails = s2, ProductGST = s3 }).ToList();




                ViewBag.ListDiscFitotalDtl = (from s1 in db.SalesGST_Report
                                              join s2 in db.SalesGST_ChargeDisc on s1.SalesGST_Rpt_BillNo equals s2.SalesGST_BillNo

                                              where (s1.SalesGST_Rpt_date >= Fdate && s1.SalesGST_Rpt_date <= Ldate)
                                              select new ComboPack { SalesGST_Report = s1, SalesGST_ChargeDisc = s2 }).ToList();



                ViewBag.TermsNConditon = (from s1 in db.SalesGst_Tnc
                                          join s2 in db.TermsCondition on s1.SalesGst_TCID equals s2.TCID

                                          //   where s1.SalesGst_BillNo == BillNo
                                          select new ComboPack { SalesGst_Tnc = s1, TermsCondition = s2 }).ToList();


                ViewBag.PaymentTransaction = ac.AllInOne_Transaction_WtGST_Report(Fdate, Ldate, CustId);

            }

            if (Fdate != null && Ldate != null && CustId == null && BillNo == "")
            {

                ViewBag.ListCustDtl = (from s1 in db.SalesGST

                                       join s2 in db.CustomerDetails on s1.SaleGST_SuppCustId equals s2.CustID
                                       join s3 in db.state on s2.CustStatus equals s3.SId
                                       join s4 in db.district on s2.CustDistrict equals s4.DistId
                                       join s5 in db.SalesGST_ChargeDisc on s1.SaleGST_BillNo equals s5.SalesGST_BillNo

                                       // join s6 in db.BankDetails on s5.SalBiWiGst_Status equals s6.PayStId

                                       join s7 in db.SalesGST_Report on s1.SaleGST_BillNo equals s7.SalesGST_Rpt_BillNo
                                       where (s1.SaleGST_Date >= Fdate && s1.SaleGST_Date <= Ldate)
                                       select new ComboPack { SalesGST = s1, CustDtl = s2, state = s3, district = s4, SalesGST_ChargeDisc = s5, /*PaymentStatus = s6,*/ SalesGST_Report = s7 }).ToList();



                ViewBag.ProductsDtl = (from s1 in db.SalesGST
                                       join s2 in db.ProductDetails on s1.SaleGST_ProductID equals s2.PDID
                                       join s3 in db.ProductGST on s2.GstPercent equals s3.ProdGstID

                                       where (s1.SaleGST_Date >= Fdate && s1.SaleGST_Date <= Ldate)
                                       select new ComboPack { SalesGST = s1, ProductDetails = s2, ProductGST = s3 }).ToList();




                ViewBag.ListDiscFitotalDtl = (from s1 in db.SalesGST_Report
                                              join s2 in db.SalesGST_ChargeDisc on s1.SalesGST_Rpt_BillNo equals s2.SalesGST_BillNo

                                              where (s1.SalesGST_Rpt_date >= Fdate && s1.SalesGST_Rpt_date <= Ldate)
                                              select new ComboPack { SalesGST_Report = s1, SalesGST_ChargeDisc = s2 }).ToList();



                ViewBag.TermsNConditon = (from s1 in db.SalesGst_Tnc
                                          join s2 in db.TermsCondition on s1.SalesGst_TCID equals s2.TCID

                                          //   where s1.SalesGst_BillNo == BillNo
                                          select new ComboPack { SalesGst_Tnc = s1, TermsCondition = s2 }).ToList();


                ViewBag.PaymentTransaction = ac.AllInOne_Transaction_WtGST_Report(Fdate, Ldate, CustId);

            }


            if (Fdate == null && Ldate == null && CustId == null && BillNo != "")
            {
                ViewBag.ListCustDtl = (from s1 in db.SalesGST

                                       join s2 in db.CustomerDetails on s1.SaleGST_SuppCustId equals s2.CustID
                                       join s3 in db.state on s2.CustStatus equals s3.SId
                                       join s4 in db.district on s2.CustDistrict equals s4.DistId
                                       join s5 in db.SalesGST_ChargeDisc on s1.SaleGST_BillNo equals s5.SalesGST_BillNo

                                       // join s6 in db.BankDetails on s5.SalBiWiGst_Status equals s6.PayStId

                                       join s7 in db.SalesGST_Report on s1.SaleGST_BillNo equals s7.SalesGST_Rpt_BillNo
                                       where s1.SaleGST_BillNo == BillNo
                                       select new ComboPack { SalesGST = s1, CustDtl = s2, state = s3, district = s4, SalesGST_ChargeDisc = s5, /*PaymentStatus = s6,*/ SalesGST_Report = s7 }).ToList();



                ViewBag.ProductsDtl = (from s1 in db.SalesGST
                                       join s2 in db.ProductDetails on s1.SaleGST_ProductID equals s2.PDID
                                       join s3 in db.ProductGST on s2.GstPercent equals s3.ProdGstID

                                       where s1.SaleGST_BillNo == BillNo
                                       select new ComboPack { SalesGST = s1, ProductDetails = s2, ProductGST = s3 }).ToList();




                ViewBag.ListDiscFitotalDtl = (from s1 in db.SalesGST_Report
                                              join s2 in db.SalesGST_ChargeDisc on s1.SalesGST_Rpt_BillNo equals s2.SalesGST_BillNo

                                              where s1.SalesGST_Rpt_BillNo == BillNo
                                              select new ComboPack { SalesGST_Report = s1, SalesGST_ChargeDisc = s2 }).ToList();



                ViewBag.TermsNConditon = (from s1 in db.SalesGst_Tnc
                                          join s2 in db.TermsCondition on s1.SalesGst_TCID equals s2.TCID

                                          where s1.SalesGst_BillNo == BillNo
                                          select new ComboPack { SalesGst_Tnc = s1, TermsCondition = s2 }).ToList();


                ViewBag.PaymentTransaction = ac.AllInOne_Transaction_WtGST_Report(BillNo);

            }

            return View();
        }


        public ActionResult Payment_DateNameBillno_SaleGst_Report()
        {
            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");
            return View();
        }
        [HttpPost]
        public ActionResult Payment_DateNameBillno_SaleGst_Report(DateTime? Fdate, DateTime? Ldate, string BillNo, int? CustId)
        {

            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");


            ViewBag.ListOrgDtl = (from s1 in db.OrganizationDetails
                                  join s2 in db.state on s1.OrgState equals s2.SId
                                  join s3 in db.ActivationStatus on s1.OrgStatus equals s3.ActStsID
                                  //   join s4 in db.BankDetails on s1.OrgID equals s4.OrgID

                                  select new ComboPack { OrganizationDetails = s1, state = s2, ActStats = s3/*, BankDetails = s4*/ }).First();

            ViewBag.ListOrgBnkDtl = (from s1 in db.OrganizationDetails
                                     join s4 in db.BankDetails on s1.OrgID equals s4.OrgID
                                     select new ComboPack { OrganizationDetails = s1, BankDetails = s4 }).ToList();



            ViewBag.ListBillNos = ac.List_BillNosSaleBilGst(Fdate, Ldate, CustId, BillNo);





            if (Fdate != null && Ldate != null && CustId != null && BillNo == "")
            {




                ViewBag.ListCustDtl = (from s1 in db.SalesGST

                                       join s2 in db.CustomerDetails on s1.SaleGST_SuppCustId equals s2.CustID
                                       join s3 in db.state on s2.CustStatus equals s3.SId
                                       join s4 in db.district on s2.CustDistrict equals s4.DistId
                                       join s5 in db.SalesGST_ChargeDisc on s1.SaleGST_BillNo equals s5.SalesGST_BillNo

                                       // join s6 in db.BankDetails on s5.SalBiWiGst_Status equals s6.PayStId

                                       join s7 in db.SalesGST_Report on s1.SaleGST_BillNo equals s7.SalesGST_Rpt_BillNo
                                       where (s1.SaleGST_Date >= Fdate && s1.SaleGST_Date <= Ldate) && s1.SaleGST_SuppCustId == CustId
                                       select new ComboPack { SalesGST = s1, CustDtl = s2, state = s3, district = s4, SalesGST_ChargeDisc = s5, /*PaymentStatus = s6,*/ SalesGST_Report = s7 }).ToList();



                ViewBag.ProductsDtl = (from s1 in db.SalesGST
                                       join s2 in db.ProductDetails on s1.SaleGST_ProductID equals s2.PDID
                                       join s3 in db.ProductGST on s2.GstPercent equals s3.ProdGstID

                                       where (s1.SaleGST_Date >= Fdate && s1.SaleGST_Date <= Ldate) && s1.SaleGST_SuppCustId == CustId
                                       select new ComboPack { SalesGST = s1, ProductDetails = s2, ProductGST = s3 }).ToList();




                ViewBag.ListDiscFitotalDtl = (from s1 in db.SalesGST_Report
                                              join s2 in db.SalesGST_ChargeDisc on s1.SalesGST_Rpt_BillNo equals s2.SalesGST_BillNo

                                              where (s1.SalesGST_Rpt_date >= Fdate && s1.SalesGST_Rpt_date <= Ldate)
                                              select new ComboPack { SalesGST_Report = s1, SalesGST_ChargeDisc = s2 }).ToList();



                ViewBag.TermsNConditon = (from s1 in db.SalesGst_Tnc
                                          join s2 in db.TermsCondition on s1.SalesGst_TCID equals s2.TCID

                                          //   where s1.SalesGst_BillNo == BillNo
                                          select new ComboPack { SalesGst_Tnc = s1, TermsCondition = s2 }).ToList();


                ViewBag.PaymentTransaction = ac.AllInOne_Transaction_WtGST_Report(Fdate, Ldate, CustId);

            }

            if (Fdate != null && Ldate != null && CustId == null && BillNo == "")
            {

                ViewBag.ListCustDtl = (from s1 in db.SalesGST

                                       join s2 in db.CustomerDetails on s1.SaleGST_SuppCustId equals s2.CustID
                                       join s3 in db.state on s2.CustStatus equals s3.SId
                                       join s4 in db.district on s2.CustDistrict equals s4.DistId
                                       join s5 in db.SalesGST_ChargeDisc on s1.SaleGST_BillNo equals s5.SalesGST_BillNo

                                       // join s6 in db.BankDetails on s5.SalBiWiGst_Status equals s6.PayStId

                                       join s7 in db.SalesGST_Report on s1.SaleGST_BillNo equals s7.SalesGST_Rpt_BillNo
                                       where (s1.SaleGST_Date >= Fdate && s1.SaleGST_Date <= Ldate)
                                       select new ComboPack { SalesGST = s1, CustDtl = s2, state = s3, district = s4, SalesGST_ChargeDisc = s5, /*PaymentStatus = s6,*/ SalesGST_Report = s7 }).ToList();



                ViewBag.ProductsDtl = (from s1 in db.SalesGST
                                       join s2 in db.ProductDetails on s1.SaleGST_ProductID equals s2.PDID
                                       join s3 in db.ProductGST on s2.GstPercent equals s3.ProdGstID

                                       where (s1.SaleGST_Date >= Fdate && s1.SaleGST_Date <= Ldate)
                                       select new ComboPack { SalesGST = s1, ProductDetails = s2, ProductGST = s3 }).ToList();




                ViewBag.ListDiscFitotalDtl = (from s1 in db.SalesGST_Report
                                              join s2 in db.SalesGST_ChargeDisc on s1.SalesGST_Rpt_BillNo equals s2.SalesGST_BillNo

                                              where (s1.SalesGST_Rpt_date >= Fdate && s1.SalesGST_Rpt_date <= Ldate)
                                              select new ComboPack { SalesGST_Report = s1, SalesGST_ChargeDisc = s2 }).ToList();



                ViewBag.TermsNConditon = (from s1 in db.SalesGst_Tnc
                                          join s2 in db.TermsCondition on s1.SalesGst_TCID equals s2.TCID

                                          //   where s1.SalesGst_BillNo == BillNo
                                          select new ComboPack { SalesGst_Tnc = s1, TermsCondition = s2 }).ToList();


                ViewBag.PaymentTransaction = ac.AllInOne_Transaction_WtGST_Report(Fdate, Ldate, CustId);

            }


            if (Fdate == null && Ldate == null && CustId == null && BillNo != "")
            {

                ViewBag.ProductCount = ac.CountProduct_SaleGST(BillNo);

                ViewBag.ListCustDtl = (from s1 in db.SalesGST

                                       join s2 in db.CustomerDetails on s1.SaleGST_SuppCustId equals s2.CustID
                                       join s3 in db.state on s2.CustStatus equals s3.SId
                                       join s4 in db.district on s2.CustDistrict equals s4.DistId
                                       join s5 in db.SalesGST_ChargeDisc on s1.SaleGST_BillNo equals s5.SalesGST_BillNo

                                       // join s6 in db.BankDetails on s5.SalBiWiGst_Status equals s6.PayStId

                                       join s7 in db.SalesGST_Report on s1.SaleGST_BillNo equals s7.SalesGST_Rpt_BillNo
                                       where s1.SaleGST_BillNo == BillNo
                                       select new ComboPack { SalesGST = s1, CustDtl = s2, state = s3, district = s4, SalesGST_ChargeDisc = s5, /*PaymentStatus = s6,*/ SalesGST_Report = s7 }).ToList();



                ViewBag.ProductsDtl = (from s1 in db.SalesGST
                                       join s2 in db.ProductDetails on s1.SaleGST_ProductID equals s2.PDID
                                       join s3 in db.ProductGST on s2.GstPercent equals s3.ProdGstID

                                       where s1.SaleGST_BillNo == BillNo
                                       select new ComboPack { SalesGST = s1, ProductDetails = s2, ProductGST = s3 }).ToList();




                ViewBag.ListDiscFitotalDtl = (from s1 in db.SalesGST_Report
                                              join s2 in db.SalesGST_ChargeDisc on s1.SalesGST_Rpt_BillNo equals s2.SalesGST_BillNo

                                              where s1.SalesGST_Rpt_BillNo == BillNo
                                              select new ComboPack { SalesGST_Report = s1, SalesGST_ChargeDisc = s2 }).ToList();



                ViewBag.TermsNConditon = (from s1 in db.SalesGst_Tnc
                                          join s2 in db.TermsCondition on s1.SalesGst_TCID equals s2.TCID

                                          where s1.SalesGst_BillNo == BillNo
                                          select new ComboPack { SalesGst_Tnc = s1, TermsCondition = s2 }).ToList();


                ViewBag.PaymentTransaction = ac.AllInOne_Transaction_WtGST_Report(BillNo);

            }




            return View();
        }


        public ActionResult Payment_Date_PayStatus_Report()
        {
            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");
            ViewBag.PaymentStatusList = new SelectList(db.PaymentStatus, "PayStId", "PayStName");

            return View();
        }
        [HttpPost]
        public ActionResult Payment_Date_PayStatus_Report(DateTime? Fdate, DateTime? Ldate, int? PayStId, int? CustId)
        {
            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");
            ViewBag.PaymentStatusList = new SelectList(db.PaymentStatus, "PayStId", "PayStName");


            ViewBag.PayStId = PayStId;


            ViewBag.ListOrgDtl = (from s1 in db.OrganizationDetails
                                  join s2 in db.state on s1.OrgState equals s2.SId
                                  join s3 in db.ActivationStatus on s1.OrgStatus equals s3.ActStsID
                                  //    join s4 in db.BankDetails on s1.OrgID equals s4.OrgID

                                  select new ComboPack { OrganizationDetails = s1, state = s2, ActStats = s3/*, BankDetails = s4*/ }).First();

            ViewBag.ListOrgBnkDtl = (from s1 in db.OrganizationDetails
                                     join s4 in db.BankDetails on s1.OrgID equals s4.OrgID

                                     select new ComboPack { OrganizationDetails = s1, BankDetails = s4 }).ToList();



            ViewBag.ListBillNos = ac.List_BillNosSaleBilGst(Fdate, Ldate);



            if (Fdate != null && Ldate != null)
            {

                ViewBag.ListCustDtl = (from s1 in db.SalesGST

                                       join s2 in db.CustomerDetails on s1.SaleGST_SuppCustId equals s2.CustID
                                       join s3 in db.state on s2.CustStatus equals s3.SId
                                       join s4 in db.district on s2.CustDistrict equals s4.DistId
                                       join s5 in db.SalesGST_ChargeDisc on s1.SaleGST_BillNo equals s5.SalesGST_BillNo

                                       // join s6 in db.BankDetails on s5.SalBiWiGst_Status equals s6.PayStId

                                       join s7 in db.SalesGST_Report on s1.SaleGST_BillNo equals s7.SalesGST_Rpt_BillNo
                                       where (s1.SaleGST_Date >= Fdate && s1.SaleGST_Date <= Ldate)
                                       select new ComboPack { SalesGST = s1, CustDtl = s2, state = s3, district = s4, SalesGST_ChargeDisc = s5, /*PaymentStatus = s6,*/ SalesGST_Report = s7 }).ToList();



                ViewBag.ProductsDtl = (from s1 in db.SalesGST
                                       join s2 in db.ProductDetails on s1.SaleGST_ProductID equals s2.PDID
                                       join s3 in db.ProductGST on s2.GstPercent equals s3.ProdGstID

                                       where (s1.SaleGST_Date >= Fdate && s1.SaleGST_Date <= Ldate)
                                       select new ComboPack { SalesGST = s1, ProductDetails = s2, ProductGST = s3 }).ToList();




                ViewBag.ListDiscFitotalDtl = (from s1 in db.SalesGST_Report
                                              join s2 in db.SalesGST_ChargeDisc on s1.SalesGST_Rpt_BillNo equals s2.SalesGST_BillNo

                                              where (s1.SalesGST_Rpt_date >= Fdate && s1.SalesGST_Rpt_date <= Ldate)
                                              select new ComboPack { SalesGST_Report = s1, SalesGST_ChargeDisc = s2 }).ToList();



                ViewBag.TermsNConditon = (from s1 in db.SalesGst_Tnc
                                          join s2 in db.TermsCondition on s1.SalesGst_TCID equals s2.TCID

                                          //   where s1.SalesGst_BillNo == BillNo
                                          select new ComboPack { SalesGst_Tnc = s1, TermsCondition = s2 }).ToList();


                ViewBag.PaymentTransaction = ac.AllInOne_Transaction_WtGST_Report(Fdate, Ldate, CustId);

            }

            return View();
        }


        public ActionResult Payment_DateCustNamePayStatus_PayStatus_Report()
        {
            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");
            ViewBag.PaymentStatusList = new SelectList(db.PaymentStatus, "PayStId", "PayStName");

            return View();
        }
        [HttpPost]
        public ActionResult Payment_DateCustNamePayStatus_PayStatus_Report(DateTime? Fdate, DateTime? Ldate, int? PayStId, int? CustId)
        {
            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");
            ViewBag.PaymentStatusList = new SelectList(db.PaymentStatus, "PayStId", "PayStName");


            ViewBag.PayStId = PayStId;

            ViewBag.ListOrgDtl = (from s1 in db.OrganizationDetails
                                  join s2 in db.state on s1.OrgState equals s2.SId
                                  join s3 in db.ActivationStatus on s1.OrgStatus equals s3.ActStsID
                                  //    join s4 in db.BankDetails on s1.OrgID equals s4.OrgID

                                  select new ComboPack { OrganizationDetails = s1, state = s2, ActStats = s3/*, BankDetails = s4*/ }).First();

            ViewBag.ListOrgBnkDtl = (from s1 in db.OrganizationDetails
                                     join s4 in db.BankDetails on s1.OrgID equals s4.OrgID

                                     select new ComboPack { OrganizationDetails = s1, BankDetails = s4 }).ToList();

            string billno = "";

            ViewBag.ListBillNos = ac.List_BillNosSaleBilGst(Fdate, Ldate, billno, CustId);



            if (Fdate != null && Ldate != null && CustId != null)
            {

                ViewBag.ListCustDtl = (from s1 in db.SalesGST

                                       join s2 in db.CustomerDetails on s1.SaleGST_SuppCustId equals s2.CustID
                                       join s3 in db.state on s2.CustStatus equals s3.SId
                                       join s4 in db.district on s2.CustDistrict equals s4.DistId
                                       join s5 in db.SalesGST_ChargeDisc on s1.SaleGST_BillNo equals s5.SalesGST_BillNo

                                       // join s6 in db.BankDetails on s5.SalBiWiGst_Status equals s6.PayStId

                                       join s7 in db.SalesGST_Report on s1.SaleGST_BillNo equals s7.SalesGST_Rpt_BillNo
                                       where (s1.SaleGST_Date >= Fdate && s1.SaleGST_Date <= Ldate) && s1.SaleGST_SuppCustId == CustId
                                       select new ComboPack { SalesGST = s1, CustDtl = s2, state = s3, district = s4, SalesGST_ChargeDisc = s5, /*PaymentStatus = s6,*/ SalesGST_Report = s7 }).ToList();



                ViewBag.ProductsDtl = (from s1 in db.SalesGST
                                       join s2 in db.ProductDetails on s1.SaleGST_ProductID equals s2.PDID
                                       join s3 in db.ProductGST on s2.GstPercent equals s3.ProdGstID

                                       where (s1.SaleGST_Date >= Fdate && s1.SaleGST_Date <= Ldate) && s1.SaleGST_SuppCustId == CustId
                                       select new ComboPack { SalesGST = s1, ProductDetails = s2, ProductGST = s3 }).ToList();




                ViewBag.ListDiscFitotalDtl = (from s1 in db.SalesGST_Report
                                              join s2 in db.SalesGST_ChargeDisc on s1.SalesGST_Rpt_BillNo equals s2.SalesGST_BillNo

                                              // where (s1.SalesGST_Rpt_date >= Fdate && s1.SalesGST_Rpt_date <= Ldate)
                                              where (s1.SalesGST_Rpt_date >= Fdate && s1.SalesGST_Rpt_date <= Ldate)
                                              select new ComboPack { SalesGST_Report = s1, SalesGST_ChargeDisc = s2 }).ToList();



                ViewBag.TermsNConditon = (from s1 in db.SalesGst_Tnc
                                          join s2 in db.TermsCondition on s1.SalesGst_TCID equals s2.TCID

                                          //   where s1.SalesGst_BillNo == BillNo
                                          select new ComboPack { SalesGst_Tnc = s1, TermsCondition = s2 }).ToList();


                ViewBag.PaymentTransaction = ac.AllInOne_Transaction_WtGST_Report(Fdate, Ldate, CustId);

            }
            return View();
        }



        public ActionResult Payment_Transaction_PayStatus_Report()
        {
            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");

            return View();
        }
        [HttpPost]
        public ActionResult Payment_Transaction_PayStatus_Report(DateTime? Fdate, DateTime? Ldate, int? CustId)
        {
            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");

            ViewBag.CustInfo = ac.Payment_CustInfo_TransactionDtl_SalesGst_Report(Fdate, Ldate, CustId);
            ViewBag.PaymentTransaction = ac.Payment_TransactionDtl_SaleGst_Report(Fdate, Ldate, CustId);

            return View();
        }





        public ActionResult GSTBifercation_Sale_Report()
        {

            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");
            return View();
        }
        [HttpPost]
        public ActionResult GSTBifercation_Sale_Report(DateTime? fdate, DateTime? ldate, int? CustId)
        {


            ViewBag.SuppCustList = new SelectList(db.CustomerDetails, "CustID", "CustName");

            ViewBag.GSTBifercation = ac.GST_Bifercation_Sale_Report(fdate, ldate, CustId);

            foreach (var item in ViewBag.GSTBifercation)
            {

                int gst = Convert.ToInt32(item.ProductGst);

                if (gst == 0)
                {
                    ViewBag.Total0 = item.SaleGST_Total;
                    ViewBag.GST_Total0 = item.SaleGST_GstRs;

                    ViewBag.Final_Total0 = ViewBag.Total0 + ViewBag.GST_Total0;
                }
                if (gst == 5)
                {
                    ViewBag.Total5 = item.SaleGST_Total;
                    ViewBag.GST_Total5 = item.SaleGST_GstRs;

                    ViewBag.Final_Total5 = ViewBag.Total5 + ViewBag.GST_Total5;
                }
                if (gst == 12)
                {
                    ViewBag.Total12 = item.SaleGST_Total;
                    ViewBag.GST_Total12 = item.SaleGST_GstRs;

                    ViewBag.Final_Total12 = ViewBag.Total12 + ViewBag.GST_Total12;
                }
                if (gst == 18)
                {
                    ViewBag.Total18 = item.SaleGST_Total;
                    ViewBag.GST_Total18 = item.SaleGST_GstRs;

                    ViewBag.Final_Total18 = ViewBag.Total18 + ViewBag.GST_Total18;
                }

                if (gst == 28)
                {
                    ViewBag.Total28 = item.SaleGST_Total;
                    ViewBag.GST_Total28 = item.SaleGST_GstRs;

                    ViewBag.Final_Total28 = ViewBag.Total28 + ViewBag.GST_Total28;
                }
            }

            ViewBag.FinalPurchaseTotal = Convert.ToDecimal(ViewBag.Total0) + Convert.ToDecimal(ViewBag.Total5) + Convert.ToDecimal(ViewBag.Total12) + Convert.ToDecimal(ViewBag.Total18) + Convert.ToDecimal(ViewBag.Total28);
            ViewBag.FinalPurchaseGSTTotal = Convert.ToDecimal(ViewBag.GST_Total0) + Convert.ToDecimal(ViewBag.GST_Total5) + Convert.ToDecimal(ViewBag.GST_Total12) + Convert.ToDecimal(ViewBag.GST_Total18) + Convert.ToDecimal(ViewBag.GST_Total28);
            ViewBag.FinalTotal = Convert.ToDecimal(ViewBag.Final_Total0) + Convert.ToDecimal(ViewBag.Final_Total5) + Convert.ToDecimal(ViewBag.Final_Total12) + Convert.ToDecimal(ViewBag.Final_Total18) + Convert.ToDecimal(ViewBag.Final_Total28);









            return View();
        }




        // <---------------  Sales With Gst --------------------->






        // <--------------- End Sales With Gst ------------------->












        // <---------------------@@@@@@ End Report @@@@@@------------------------->




        // <---------------@@@@@@ daily Business @@@@@@------------------->

        public ActionResult Daily_Business()
        {

            ViewBag.Daily_Business = (from s1 in db.Daily_Business
                                      select new ComboPack { Daily_Business = s1 }).ToList();



            return View();
        }
        [HttpPost]
        public ActionResult Daily_Business(Daily_Business Da_Bus, DateTime? Fdate, DateTime? Ldate)
        {

            if (Da_Bus.DB_ID != 0 && Fdate == null && Ldate == null)
            {
                DateTime dt = DateTime.Now;
                Da_Bus.Dates = Convert.ToDateTime(dt.ToString("yyyy-MM-dd"));

                db.Entry(Da_Bus).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                TempData["SaveRegMsg"] = "Data updated successfully...!";
            }

            if (Da_Bus.DB_ID == 0 && Fdate == null && Ldate == null)
            {
                DateTime dt = DateTime.Now;

                Da_Bus.Dates = Convert.ToDateTime(dt.ToString("yyyy-MM-dd"));

                db.Daily_Business.Add(Da_Bus);
                db.SaveChanges();

                TempData["SaveRegMsg"] = "Data inserted successfully...!";

            }




            if (Fdate != null && Ldate != null)
            {
                ViewBag.Daily_Business = (from s1 in db.Daily_Business
                                          where (s1.Dates >= Fdate && s1.Dates <= Ldate)
                                          select new ComboPack { Daily_Business = s1 }).ToList();
            }
            else
            {
                ViewBag.Daily_Business = (from s1 in db.Daily_Business
                                          select new ComboPack { Daily_Business = s1 }).ToList();
            }


            return View();
        }
        public ActionResult Daily_Business_Delete(int id)
        {

            var delobj = db.Daily_Business.Where(p => p.DB_ID == id).SingleOrDefault();
            db.Daily_Business.Remove(delobj);
            db.SaveChanges();

            TempData["SaveRegMsg"] = "Data deleted successfully...!";

            return RedirectToAction("Daily_Business");
        }
        public JsonResult Fetch_Daily_Busines(int ID)
        {
            //   var FetchRegist = db.Registration.ToList().Find(x => x.RID.Equals(ID));
            var delobj = db.Daily_Business.Where(p => p.DB_ID == ID).SingleOrDefault();

            return Json(delobj, JsonRequestBehavior.AllowGet);
        }

        // <--------------- End daily Business ----------------->



        // <---------------@@@@@@ Normal IncomeExpenses @@@@@@------------------->

        public ActionResult Normal_IncomeExpenses()
        {
            ViewBag.NormalIncomeExpense = (from s1 in db.NormalIncomeExpense
                                           select new ComboPack { NormalIncomeExpense = s1 }).ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Normal_IncomeExpenses(NormalIncomeExpense NIE, DateTime? Fdate, DateTime? Ldate)
        {
            if (NIE.NIE_ID != 0 && Fdate == null && Ldate == null)
            {
                db.Entry(NIE).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                TempData["SaveRegMsg"] = "Data updated successfully...!";
            }

            if (NIE.NIE_ID == 0 && Fdate == null && Ldate == null)
            {

                db.NormalIncomeExpense.Add(NIE);
                db.SaveChanges();

                TempData["SaveRegMsg"] = "Data inserted successfully...!";
            }




            if (Fdate != null && Ldate != null)
            {

                ViewBag.NormalIncomeExpense = (from s1 in db.NormalIncomeExpense
                                               where (s1.NIE_Date >= Fdate && s1.NIE_Date <= Ldate)
                                               select new ComboPack { NormalIncomeExpense = s1 }).ToList();

            }
            else
            {
                ViewBag.NormalIncomeExpense = (from s1 in db.NormalIncomeExpense
                                               select new ComboPack { NormalIncomeExpense = s1 }).ToList();
            }

            return View();
        }

        public ActionResult Normal_IncomeExpenses_Delete(int id)
        {

            var delobj = db.NormalIncomeExpense.Where(p => p.NIE_ID == id).SingleOrDefault();
            db.NormalIncomeExpense.Remove(delobj);
            db.SaveChanges();

            TempData["SaveRegMsg"] = "Data deleted successfully...!";

            return RedirectToAction("Normal_IncomeExpenses");
        }

        public JsonResult Fetch_Normal_IncomeExpenses(int ID)
        {
            //   var FetchRegist = db.Registration.ToList().Find(x => x.RID.Equals(ID));
            var delobj = db.NormalIncomeExpense.Where(p => p.NIE_ID == ID).SingleOrDefault();

            return Json(delobj, JsonRequestBehavior.AllowGet);
        }

        // <--------------- End daily Business ----------------->



        // <---------------@@@@@@ daily Business N Normal IncomeExpenses Report @@@@@@------------------->
        public ActionResult BusinessNIncomeExpense_Report()
        {


            return View();
        }
        [HttpPost]
        public ActionResult BusinessNIncomeExpense_Report(DateTime? Fdate, DateTime? Ldate)
        {

            ViewBag.Fdate = Fdate;
            ViewBag.Ldate = Ldate;

            ViewBag.ListOrgDtl = (from s1 in db.OrganizationDetails
                                      // join s2 in db.state on s1.OrgState equals s2.SId
                                      // join s3 in db.ActivationStatus on s1.OrgStatus equals s3.ActStsID
                                      //    join s4 in db.BankDetails on s1.OrgID equals s4.OrgID
                                  select new ComboPack { OrganizationDetails = s1/*, state = s2, ActStats = s3, BankDetails = s4*/ }).FirstOrDefault();


            ViewBag.NormalIncome = (from s1 in db.NormalIncomeExpense
                                    where (s1.NIE_Date >= Fdate && s1.NIE_Date <= Ldate) && s1.NIE_Category == "Income"
                                    select new ComboPack { NormalIncomeExpense = s1 }).ToList();


            ViewBag.NormalExpense = (from s1 in db.NormalIncomeExpense
                                     where (s1.NIE_Date >= Fdate && s1.NIE_Date <= Ldate) && s1.NIE_Category == "Expense"
                                     select new ComboPack { NormalIncomeExpense = s1 }).ToList();


            ViewBag.DailyBusiness = ac.SumOfAllPayment(Fdate, Ldate).ToList();




            if (!(ViewBag.DailyBusiness is DBNull))
            {
                foreach (var item in ViewBag.DailyBusiness)
                {
                    ViewBag.Cash = item.Cash;
                    ViewBag.Gpay = item.Gpay;
                    ViewBag.Zomato = item.Zomato;
                    ViewBag.Card = item.Card;
                    ViewBag.Paytm = item.Paytm;
                    ViewBag.Swiggy = item.Swiggy;

                    break;
                }
                ViewBag.FinalTotal = Convert.ToDecimal(ViewBag.Cash) + Convert.ToDecimal(ViewBag.Gpay) + Convert.ToDecimal(ViewBag.Zomato) + Convert.ToDecimal(ViewBag.Card) + Convert.ToDecimal(ViewBag.Paytm) + Convert.ToDecimal(ViewBag.Swiggy);
            }
            return View();
        }

        // <--------------- daily Business N Normal IncomeExpenses Report ----------------->


        // <--------------- @@@@@ Product Category Report @@@@@ -------------------->

        public ActionResult Product_Category()
        {
            ViewBag.CategoryList = new SelectList(db.Product_Catagory.ToList(), "C_ID", "Category_Name");
            ViewBag.ProductsList = new SelectList(db.ProductDetails.ToList(), "PDID", "ProductName");



            return View();
        }

        [HttpPost]
        public ActionResult Product_Category(int? CatID, decimal? StkCount, int? PDID)
        {
            ViewBag.CategoryList = new SelectList(db.Product_Catagory.ToList(), "C_ID", "Category_Name");
            ViewBag.ProductsList = new SelectList(db.ProductDetails.ToList(), "PDID", "ProductName");

            if (CatID != null && StkCount == null)
            {
                ViewBag.ProductList = (from s1 in db.ProductDetails
                                       join s2 in db.Product_Catagory on s1.Category_ID equals s2.C_ID
                                       where s1.Category_ID == CatID
                                       select new ComboPack { ProductDetails = s1, Product_Catagory = s2 }).ToList();
            }

            if (CatID != null && StkCount != null)
            {
                ViewBag.ProductList = (from s1 in db.ProductDetails
                                       join s2 in db.Product_Catagory on s1.Category_ID equals s2.C_ID
                                       where s1.Category_ID == CatID && s1.Opening_Stock_Qty <= StkCount
                                       select new ComboPack { ProductDetails = s1, Product_Catagory = s2 }).ToList();
            }


            if (PDID != null && CatID == null && StkCount == null)
            {
                ViewBag.ProductList = (from s1 in db.ProductDetails
                                       join s2 in db.Product_Catagory on s1.Category_ID equals s2.C_ID
                                       where s1.PDID == PDID
                                       select new ComboPack { ProductDetails = s1, Product_Catagory = s2 }).ToList();
            }




            return View();
        }





        // <--------------- End Product Category Report ------------------>














































    } // Lst
}  // Lst