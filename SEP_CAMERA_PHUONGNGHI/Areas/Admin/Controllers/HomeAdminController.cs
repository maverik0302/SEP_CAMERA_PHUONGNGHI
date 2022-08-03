using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SEP_CAMERA_PHUONGNGHI.Models;
using SEP_CAMERA_PHUONGNGHI.Areas.Admin.Middleware;
using System.Web.Mvc;
using System.Data.Entity;
using WebMatrix.WebData;

namespace SEP_CAMERA_PHUONGNGHI.Areas.Admin.Controllers
{
    [LoginVerification]
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin
        SEP25Team01Entities db = new SEP25Team01Entities();
        public ActionResult Index()
        {
            ViewBag.Message = null;
            return View();
        }
        public ActionResult MyProfile()
        {
            int id = (int)Session["user-id"];
            var Taikhoan = db.Accounts.FirstOrDefault(t => t.user_id == id);
            return View(Taikhoan);
        }
        public ActionResult EditProfile()
        {
            int id = (int)Session["user-id"];
            var Taikhoan = db.Accounts.FirstOrDefault(t => t.user_id == id);
            return View(Taikhoan);

        }
        [HttpPost]
        public ActionResult EditProfile(Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                // Upload file
                //var img = Request.Files["img"]; // lay thong tin file
                //if (img.ContentLength != 0)
                //{
                //    string[] FileExtentions = new string[] { ".jpg", ".jepg", ".png", ".gif" };
                //    // Kiem tra tap tin
                //    if (FileExtentions.Contains(img.FileName.Substring(img.FileName.LastIndexOf("."))))
                //    {
                //        string slug = Account.Thumnail;
                //        //
                //        string imgName = slug + img.FileName.Substring(img.FileName.LastIndexOf("."));
                //        Account.Thumnail = imgName;
                //        string PathDir = "~/Content/image/ImgProduct/";
                //        string PathFile = Path.Combine(Server.MapPath(PathDir), imgName);
                //        img.SaveAs(PathFile);
                //    }
                //}
                // end Upload file
                db.SaveChanges();
                return RedirectToAction("Index", "HomeAdmin");
            }
            return View(account);
        }

        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(string Password, string NewPassword, string RenewPassword)
        {
            int id = (int)Session["user-id"];
            var Xacthuc = db.Accounts.FirstOrDefault(x => x.user_id == id);
            if (Xacthuc.Password.Equals(Password))
            {
                if (!Xacthuc.Password.Equals(NewPassword))
                {
                    if (NewPassword.Equals(RenewPassword))
                    {
                        Xacthuc.Password = NewPassword;
                        db.Entry(Xacthuc).State = EntityState.Modified;
                        db.SaveChanges();
                        ViewBag.Message = null;
                        return RedirectToAction("MyProfile", "HomeAdmin");
                    }
                    ViewBag.Message = "Nhập lại mật khẩu không trùng khớp";
                    return View();

                }
                ViewBag.Message = "Mật khẩu mới không được trùng mật khẩu cũ";
                return View();

            }
            ViewBag.Message = "Mật khẩu hiện tại không chính xác";
            return View();
        }
    }
}