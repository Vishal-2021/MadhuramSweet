using Accounting_Final_Details.Coding;
using Accounting_Final_Details.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Accounting_Final_Details.Controllers
{
    public class UserController : Controller
    {
        AccountDetailsDBContext db = new AccountDetailsDBContext();
        AdminCode ac = new AdminCode();
        ComboPack cb = new ComboPack();
        UserCode uc = new UserCode();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserAccessLink()
        {
            int RID = Convert.ToInt32(Session["User_IDs"]);
            ViewBag.UserAcess = (from s1 in db.UserAccess_Info join s2 in db.User_Access on s1.uai_Url_ID equals s2.UA_ID where s1.uai_Reg_ID == RID select new ComboPack { UserAccess_Info = s1, User_Access = s2 }).ToList();
            return PartialView("ActionLinks", ViewBag.UserAcess);
        }






        //@@@@@@@@@  Upload Files  @@@@@@@@@



        public ActionResult UplaodFiles()
        {
            ViewBag.RegistList = new SelectList(db.Registration, "RID", "Name");

            int RID = Convert.ToInt32(Session["User_IDs"]);

            //ViewBag.UploadedList = (from s1 in db.UploadFiles
            //                        join s2 in db.Registration on s1.RID equals s2.RID

            //                        where s1.Uploader_Name_ID == RID
            //                        select new ComboPack { UploadFiles = s1, Rgst = s2 }).ToList();



            ViewBag.UploadedList = uc.UploadedList(RID);





            return View();
        }


        [HttpPost]
        public ActionResult UplaodFiles(UploadFiles uf, HttpPostedFileBase[] files)
        {
            ViewBag.RegistList = new SelectList(db.Registration, "RID", "Name");

            int RID = Convert.ToInt32(Session["User_IDs"]);

            uf.Uploader_Name_ID = RID;

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
                
                    string FName = dt;

                    file.SaveAs(System.IO.Path.Combine(Server.MapPath("~/UploadedFiles/"), FName));

                    ac.AddFiles(uf, FName, filext);
           

                    //assigning file uploaded status to ViewBag for showing message to user.  
                    ViewBag.UploadStatus = files.Count().ToString() + "files Send successfully.";


                }
            }



            //ViewBag.UploadedList = (from s1 in db.UploadFiles
            //                        join s2 in db.Registration on s1.RID equals s2.RID

            //                        where s1.Uploader_Name_ID == RID
            //                        select new ComboPack { UploadFiles = s1, Rgst = s2 }).ToList();



            ViewBag.UploadedList = uc.UploadedList(RID);


            return View();
        }






        public ActionResult UploadedList()  // Received List
        {
            int RID = Convert.ToInt32(Session["User_IDs"]);

          
            ViewBag.UploadedList = uc.ReceivedList(RID);


            return View();
        }

        [HttpPost]
        public ActionResult UploadedList(DateTime? Fdate, DateTime? Ldate) // Received List
        {
            int RID = Convert.ToInt32(Session["User_IDs"]);
          
            ViewBag.UploadedList = uc.ReceivedList(Fdate, Ldate,RID);

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



        //  <------------  End Upload Files  ---------------->



    }
}