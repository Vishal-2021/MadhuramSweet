using Accounting_Final_Details.Coding;
using Accounting_Final_Details.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Accounting_Final_Details.Controllers
{
    public class CustomerController : Controller
    {
        AccountDetailsDBContext db = new AccountDetailsDBContext();
        AdminCode ac = new AdminCode();
        ComboPack cb = new ComboPack();
        UserCode uc = new UserCode();

        CustomerCode cc = new CustomerCode();


        // GET: Customer
        public ActionResult Index()
        {
          //  ViewBag.ProductList = db.Store_AddProduct.ToList();
            ViewBag.ProductList = cc.TrendingProducts();


            ViewBag.PCategory = db.Product_Catagory.ToList();


            ViewBag.SliderLst = db.CustomerSlider.ToList();

            return View();
        }

         [HttpPost]
        public JsonResult ProductFilterByCategory(FormCollection fc)
        {

            string EmptyOrNot = fc["ID"];

            if (EmptyOrNot != null)
            {
                string[] ids = fc["ID"].Split();

                string st = ids[0];
                ViewBag.ProductList = cc.TrendingProducts(st);

            }
            else
            {
                ViewBag.ProductList = cc.TrendingProducts();
            }
           


            return Json(ViewBag.ProductList, JsonRequestBehavior.AllowGet);
        }






        public ActionResult productlist()
        {
         
            //  ViewBag.ProductList = cc.TrendingProducts();

          //    var lists = db.Store_AddProduct.FirstOrDefault();

         //  ViewBag.imgs = Convert.ToBase64String(lists.Sp_PImage); 


            Response.Cookies["cookie"].Value = "This is my Cookie values in asp.net mvc";
            return View();
        }
        [HttpGet]
        public JsonResult LoadProductList()
        {
          ViewBag.ProductList = (from s1 in db.Store_AddProduct
                         join s2 in db.Product_Catagory on s1.Sp_Category equals s2.C_ID  

                         where s1.Sp_Status == 1
                         select new ComboPack { Store_AddProduct = s1, Product_Catagory = s2 }).OrderByDescending(x => x.Store_AddProduct.Sp_ID).ToList();

            return Json(ViewBag.ProductList, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult FilterProductListByPName(string ProductName)
        {
            if (ProductName == "")
          
            ViewBag.ProductList = (from s1 in db.Store_AddProduct
                                   join s2 in db.Product_Catagory on s1.Sp_Category equals s2.C_ID
                                   where s1.Sp_Status == 1
                                   select new ComboPack { Store_AddProduct = s1, Product_Catagory = s2 }).OrderByDescending(x => x.Store_AddProduct.Sp_ID).ToList();
            else
                ViewBag.ProductList = (from s1 in db.Store_AddProduct
                                       join s2 in db.Product_Catagory on s1.Sp_Category equals s2.C_ID
                                       where s1.Sp_Status == 1 && s1.Sp_ProductName.Contains(ProductName)
                                       select new ComboPack { Store_AddProduct = s1, Product_Catagory = s2 }).OrderByDescending(x => x.Store_AddProduct.Sp_ID).ToList();






            return Json(ViewBag.ProductList, JsonRequestBehavior.AllowGet);
        }




        public ActionResult checkoutCart()
        {
            var lst = db.delivery_charges.FirstOrDefault();

            ViewBag.DeliveryCharg = lst.DC_Charges;
            return View();
        }

        public JsonResult checkoutCartCustdtl()
        {
            int CustId = Convert.ToInt32(Session["CustId"]);
            ViewBag.CustDtl = db.Customer_Registration.Where(x => x.Cust_RID == CustId).FirstOrDefault();

            return Json(ViewBag.CustDtl, JsonRequestBehavior.AllowGet);
        }

        public ActionResult OrderHistory()
        {

            ViewBag.MyProductLst = db.OrderedProducts.ToList();

            return View();
        }


        public JsonResult OrderHistoryList()
        {
            int CustID = Convert.ToInt32(Session["CustId"]);
        
            ViewBag.MyOrders = (from s1 in db.CustomerOrder
                                join s2 in db.CustomerDeliveryStatus on s1.DeliveryStatus equals s2.CDS_ID

                                where s1.CustID == CustID
                                select new ComboPack { CustomerOrder = s1, CustomerDeliveryStatus = s2 }).OrderByDescending(x => x.CustomerOrder.OrderID).ToList();

            return Json(ViewBag.MyOrders, JsonRequestBehavior.AllowGet);
        }











        public ActionResult CancleOrder(ItemsCancleReason ICR)
        {

            db.ItemsCancleReason.Add(ICR);
            db.SaveChanges();

            ac.CancleOrder(ICR.ICR_OrdID);

            return RedirectToAction("OrderHistory");
        }

        public JsonResult CheckAvailabitityPincode(int CustPincode)
        {
         
           var dt =    db.delivery_charges.Where(x => x.Pincode == CustPincode).FirstOrDefault();

            var arlist = new ArrayList();

            

            if (dt != null)
            {
                arlist.Add(1);
                var dNc = db.delivery_charges.Where(x => x.Pincode == CustPincode).FirstOrDefault();
                arlist.Add(dNc.DC_Charges);
             }
            else{
                arlist.Add(0);
            }



            return Json(arlist, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AddPlaceOrder(CustomerOrder CO)
        {
            CO.CustID = Convert.ToInt32(Session["CustId"]);

          //  string ConvDate =  Convert.ToDateTime(CO.CustOrdDate).ToString("MM-dd-yyyy");
           /// CO.CustOrdDate = Convert.ToDateTime(ConvDate);
           /// 

            CO.DeliveryStatus = 1;

            string datess = Convert.ToDateTime(CO.CustOrdDate).ToString("yyyy-MM-dd");

            var Dicharg = db.delivery_charges.Where(x=>x.Pincode == CO.CustPincode).FirstOrDefault();

            if (Dicharg != null) // check pincode exist or not
            {
                CO.DeliveryCharges = Dicharg.DC_Charges;

             if (datess == "0001-01-01")
            {
              string currdate =   Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd");
                CO.CustOrdDate =Convert.ToDateTime(currdate);
                CO.DeliTime = "";
            }
           

            db.CustomerOrder.Add(CO);

            db.SaveChanges();

            int OrdID = CO.OrderID; // Last Inserted ID
 
            ViewBag.CartList = (from s1 in db.Cart
                                  join s2 in db.Store_AddProduct on s1.Crt_ProdId equals s2.Sp_ID
                                
                                  where s1.Crt_CustId == CO.CustID
                                  select new ComboPack { Cart = s1, Store_AddProduct = s2 }).ToList();


            foreach (var item in ViewBag.CartList)
            {
                OrderedProducts op = new OrderedProducts();

                op.OP_OrderId = OrdID;
                op.OP_Qty = item.Cart.Crt_PQty;
                op.OP_Name =   item.Store_AddProduct.Sp_ProductName;
                op.OP_Rate =   item.Store_AddProduct.Sp_Rate;
                op.OP_Desc =   item.Store_AddProduct.Sp_Description;
                op.OP_Img =   item.Store_AddProduct.Sp_PImageName;

                db.OrderedProducts.Add(op);
                db.SaveChanges();

            }

            cc.DeleteCart(CO.CustID);


            TempData["OrderPlace"] = "Order Placed Successfully";

                return RedirectToAction("OrderHistory");

            }
            else
            {
                TempData["MsgPinc"] = "Order not available on this pincode";

                return RedirectToAction("checkoutCart");
            }

            
        }







        public ActionResult CustomerFeedback()
        {

            return View();
        }


        [HttpPost]
        public ActionResult CustomerFeedback(Feedback fb,HttpPostedFileBase[] files)
        {

            string ImgStr = "";

            if (Session["CustName"] != null)
            {

           
            string CustName = Session["CustName"].ToString();

            fb.F_CustName = CustName;

            foreach (HttpPostedFileBase file in files)
            {
               //Checking file is available to save.  
                if (file != null)
                {

                    string fileName = System.IO.Path.GetFileName(file.FileName);

                    System.Guid guid = System.Guid.NewGuid();



                    string ID = guid.ToString();

                    var ext = Path.GetExtension(file.FileName); //getting the extension(ex-.jpg)  

                    string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                    string dt = name + "_" + ID + ext; //appending the name with id 
            



                     ImgStr += dt + ",";
                     string FName = dt;

                     file.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Logo/FeedbackImg/"), FName));
                    

                  

                  
                }
            }
          
            fb.F_Images = ImgStr;
            ac.AddFeedback(fb);

            ViewBag.UploadStatus = "Feedback sended successfully.";

            }

            return View();
        }




        public ActionResult Login(string Cust_EmailID, string Password)
        {

            var Email =  db.Customer_Registration.Where(x => x.Cust_EmailID == Cust_EmailID).FirstOrDefault();

            if (Email == null)
            {
                TempData["Msg"] = "Invalid Email-ID";
            }
            else
            {
                var EmailPass = db.Customer_Registration.Where(x => x.Cust_EmailID == Cust_EmailID && x.Password == Password).FirstOrDefault();

                if (EmailPass == null)
                {
                    TempData["Msg"] = "Invalid Password";
                }
                else
                {
                    TempData["Msg"] = "Login Successfull...";
                   
                    Session["CustId"] = EmailPass.Cust_RID;
                    Session["CustName"] = EmailPass.Cust_Name;


                    HttpCookie EmailID = new HttpCookie("EmailID", Cust_EmailID);
                    EmailID.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Add(EmailID);


                    HttpCookie Pass = new HttpCookie("Pass", Password);
                    Pass.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Add(Pass);

                }

            }

            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
        


        public ActionResult Forgetpassword(string FrgtEmail)
        {
             var  RgstLst = db.Customer_Registration.Where(x => x.Cust_EmailID == FrgtEmail).FirstOrDefault();

            if(RgstLst != null)
            {
                SendEmail(FrgtEmail, RgstLst.Password);
                TempData["Msgss"] = "Password sended successfully on your Email-Id";
            }
            else
            {
                TempData["Msgss"] = "Invalid Email-Id";
            }

            return RedirectToAction("Index");
        }




        [NonAction]
        public void SendEmail(string emailID, string Password)
        {
            //  var verifyUrl = "/User/" + emailFor + "/" + activationCode;
            //  var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("info@madhuramsweet.in", "Madhuram Sweets");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "madhuram@123$$"; // Replace with actual password

            string subject = "";
            string body = "";

            subject = "Welcome to Account Details";
            body = "Forgot Password,<br/><br/> " +
                "<br/><br/>" +
             "<div style = 'border:1px solid #ddd;width:50%;border-radius : 5px'>" +
             "<div style = 'border-bottom:1px solid #ddd;padding-left:5px'>" +
             "<h3 style = 'color:#ff6a00;padding:0' > Your Registration Details !</h3>" +
             "</div>" +
             "<div style = 'padding:5px;'>" +

                "<b> Email-ID:</b> <b style = 'font-weight:600' > " + emailID + " </b><br />" +
                         "<b> password :</b> <b style = 'font-weight:600' > " + Password + " </b><br />" +
               "</div>" +
           "</div>";




            var smtp = new SmtpClient
            {
                Host = "vision.herosite.pro",
                Port = 25,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }










        [HttpPost]
        public JsonResult AddToCartWithLogins(Cart crt)
        {


            int custID = crt.Crt_CustId;
            int PID = crt.Crt_ProdId;
            decimal PQty = crt.Crt_PQty;

            var obj = db.Cart.Where(x => x.Crt_ProdId == PID && x.Crt_CustId == custID).FirstOrDefault();


            if (obj == null)
            {
                cc.AddToCartWithLogin(custID, PID, PQty,"add");
            }else
            {
                cc.AddToCartWithLogin(custID, PID, PQty,"update");
            }

         //   ViewBag.Carts =  cc.FetchCartList(custID);

            return Json("AddUpdate", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CartData(int? id)
        {
            ViewBag.Carts = cc.FetchCartList(id);

            return Json(ViewBag.Carts, JsonRequestBehavior.AllowGet);
        }




        [HttpPost]
        public JsonResult ProductCategory()
        {
            ViewBag.PCategory = db.Product_Catagory.ToList();

            return Json(ViewBag.PCategory, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RemoveCartItem(int id)
        {

            var delobj = db.Cart.Where(p => p.Crt_Id == id).SingleOrDefault();
            db.Cart.Remove(delobj);
            db.SaveChanges();

            return Json("Remove", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UdateCartQty(int PID,decimal PQnt)
        {

            //var delobj = db.Cart.Where(p => p.Crt_Id == id).SingleOrDefault();
            //db.Cart.Remove(delobj);
            //db.SaveChanges();

            cc.EditQtyCart(PID, PQnt);

            return Json("updatQty", JsonRequestBehavior.AllowGet);
        }




































        //  this is for cookie section

        public ActionResult AddToCart()
        {
            return View();
        }
        [HttpPost]
      //  [Authorize]
        public ActionResult AddToCartss(int productId, int quantity)
        {
            //If the cart cookie doesn't exist, create it.
            if (Request.Cookies["cart"] == null)
            {
                Response.Cookies.Add(new HttpCookie("cart"));

            }

            //Helper method here.
            var values = GenerateNameValueCollection(Request.Cookies["cart"], productId, quantity);
            Response.Cookies["cart"].Values.Add(values);

            TempData["datas"] = values;

            Response.Cookies["cart"].Expires = DateTime.Now.AddYears(1);
       
            //HttpCookie kt1 = new HttpCookie("user","world");
            //Response.Cookies.Add(kt1);

            return RedirectToAction("AddToCart", "Customer");
        }

        private NameValueCollection GenerateNameValueCollection(HttpCookie cookie, int productId, int quantity)
        {
            var collection = new NameValueCollection();
            foreach (var value in cookie.Values)
            {
                //If the current element isn't the first empty element.
                if (value != null)
                {
                    collection.Add(value.ToString(), cookie.Values[value.ToString()]);
                }
            }

            //Does this product exist in the cookie?
            if (cookie.Values[productId.ToString()] != null)
            {
                collection.Remove(productId.ToString());
                //Get current count of item in cart.
                int tmpAmount = Convert.ToInt32(cookie.Values[productId.ToString()]);
                int total = tmpAmount + quantity;
                collection.Add(productId.ToString(), total.ToString());
            }
            else //It doesn't exist, so add it.
            {
                collection.Add(productId.ToString(), quantity.ToString());
            }

            if (!collection.HasKeys())
                collection.Add(productId.ToString(), quantity.ToString());

            return collection;
        }

        // End Cookie section 



      

































    } // Lst
} // Lst