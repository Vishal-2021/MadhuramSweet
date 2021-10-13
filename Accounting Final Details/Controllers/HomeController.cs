using Accounting_Final_Details.Coding;
using Accounting_Final_Details.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Accounting_Final_Details.Controllers
{
    public class HomeController : Controller
    {
        AccountDetailsDBContext db = new AccountDetailsDBContext();
     //   HomeCode ac = new HomeCode();
        ComboPack cb = new ComboPack();
        CustomerCode cc = new CustomerCode();

        public ActionResult Index()
        {
            Session.Abandon();
            return View();
        }

        [HttpPost]
        public ActionResult Index(Registration rgst)
        {

            var obj_UserName = db.Registration.Where(a => a.UserName.Equals(rgst.UserName)).FirstOrDefault();
            if (obj_UserName != null)
            {
               var obj_PassNusername = db.Registration.Where(a => a.UserName.Equals(rgst.UserName) && a.Password.Equals(rgst.Password)).FirstOrDefault();

                if (obj_PassNusername != null)
                {
                    Session["User_IDs"] = obj_PassNusername.RID.ToString();
                    Session["Role"] = "User";
                    //    Session["UserName"] = obj_PassNusername.UserName.ToString();
                    return RedirectToAction("index", "User");
                }
                else
                {
                    ViewBag.Login_Msg = "Invalid Password !";
                }
             }
            else
            {

                var Admin_UserName = db.AdminLogin.Where(a => a.A_UserName.Equals(rgst.UserName)).FirstOrDefault();

                if (Admin_UserName != null)
                {
                    var Admin_PassNusername = db.AdminLogin.Where(a => a.A_UserName.Equals(rgst.UserName) && a.A_Password.Equals(rgst.Password)).FirstOrDefault();

                    if (Admin_PassNusername != null)
                    {
                        Session["User_IDs"] = Admin_PassNusername.A_Id.ToString();

                        //  Session["Role"] = "User";
                        //  Session["UserName"] = obj_PassNusername.UserName.ToString();

                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        ViewBag.Login_Msg = "Invalid Password !";
                    }
                }
                else
                {
                    ViewBag.Login_Msg = "Invalid User Name !";
                }

            }
            return View();
        }


        public ActionResult RegistShow()
        {
            AccountDetailsDBContext db = new AccountDetailsDBContext();
            return View(db.Registration.ToList());
        }

        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(Customer_Registration reg)
        {
            reg.Cust_RegisteredDate = DateTime.Now;
            cc.Cust_Regist(reg);

            SendEmail(reg.Cust_EmailID, reg.Password);

            TempData["RegSucess"] = "Registration Successfully";

            return RedirectToAction("Index","Customer");

        }
        [HttpPost]
        public JsonResult EmailIDExistOrNot(Customer_Registration rgst)
        {
            int rslt = 0;

         

            object obj = db.Customer_Registration.Where(x => x.Cust_EmailID == rgst.Cust_EmailID).FirstOrDefault();

                

            if(obj != null)
            {
                rslt = 0;
            }
            else
            {
                rslt = 1;

            }
            return Json(rslt, JsonRequestBehavior.AllowGet);
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
            body = "Hi,<br/><br/>Hey, Welcome to Account Details you can login using below details" +
                "<br/><br/>" +


            "<div style = 'border:1px solid #ddd;width:50%;border-radius : 5px'>" +

     "<div style = 'border-bottom:1px solid #ddd;padding-left:5px'>" +

          "<h3 style = 'color:#ff6a00;padding:0' > Registration Details !</h3>" +

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
                UseDefaultCredentials = true,
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




        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string EmailID)
        {


           // Verify Email ID
           // Generate Reset password link
           // Send Email
            string message = "";
          //  bool status = false;


            var account = db.Registration.Where(a => a.EmailID == EmailID).FirstOrDefault();

            if (account != null)
            {
                //   Send email for reset password

                //   string resetCode = Guid.NewGuid().ToString();

                SendVerificationLinkEmail(account.EmailID, account.UserName, account.Password);

             //   account.ResetPasswordCode = resetCode;
                //This line I have added here to avoid confirm password not match issue , as we had added a confirm password property 
                //in our model class in part 1
              //  dc.Configuration.ValidateOnSaveEnabled = false;
              //  dc.SaveChanges();
                message = "Your User-Name and Password  has been sent to your Email-ID.";
            }
            else
            {
                message = "Account not found";
            }

         //  ViewBag.Message = message;
            TempData["Fmsg"] = message;


            return View();
        }


        [NonAction]
        public void SendVerificationLinkEmail(string emailID, string UserName, string Password)
        {
          //  var verifyUrl = "/User/" + emailFor + "/" + activationCode;
          //  var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("info@madhuramsweet.in", "Final Account Details");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "madhuram@123$$"; // Replace with actual password

            string subject = "";
            string body = "";
            //if (emailFor == "VerifyAccount")
            //{
            //    subject = "Your account is successfully created!";
            //    body = "<br/><br/ >We are excited to tell you that your Dotnet Awesome account is" +
            //        " successfully created. Please click on the below link to verify your account" +
            //        " <br/><br/><a href='" + link + "'>" + link + "</a> ";
            //}
            //else if (emailFor == "ResetPassword")
            //{
                subject = "Reset Password";
                body = "Hi,<br/><br/>We got request for reset your account password. see on the below Login Details" +
                    "<br/><br/>"+


                "<div style = 'border:1px solid #ddd;width:50%;border-radius : 5px'>" +
 
         "<div style = 'border-bottom:1px solid #ddd;padding-left:5px'>"+
  
              "<h3 style = 'color:#ff6a00;padding:0' > Registration Details !</h3>"+
       
               "</div>"+
       
               "<div style = 'padding:5px;'>"+

                    "<b> User Name:</b> <b style = 'font-weight:600' > " + UserName + " </b><br />" +

                             "<b> password :</b> <b style = 'font-weight:600' > " + Password + " </b><br />" +

                   "</div>" +
               "</div>";



                                       //  }


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











    }
}