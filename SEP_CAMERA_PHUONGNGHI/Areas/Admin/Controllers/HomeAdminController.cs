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
                db.SaveChanges();
                return RedirectToAction("Index", "HomeAdmin");
            }
            return View(account);
        }

        //public ActionResult ChangePassword()
        //{
        //    int id = (int)Session["user-id"];
        //    var Taikhoan = db.Accounts.FirstOrDefault(t => t.user_id == id);
        //    return View(Taikhoan);
        //}
        //[HttpPost]
        //public ActionResult ChangePassword(string Password, string NewPassword, string RenewPassword)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(Account).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index", "HomeAdmin");

        //    }
        //    return View(Account);
        //}
    }
}