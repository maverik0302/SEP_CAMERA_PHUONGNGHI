using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEP_CAMERA_PHUONGNGHI.Models;

namespace SEP_CAMERA_PHUONGNGHI.Controllers
{
    public class UserController : Controller
    {
        SEP25Team01Entities db = new SEP25Team01Entities();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(Account acc)
        {
            if (ModelState.IsValid)
            {
                db.Accounts.Add(acc);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(acc);
           
        }
        
        public ActionResult Taikhoan()
        {
            int id = (int)Session["user-id"];
            var tkuser = db.Accounts.FirstOrDefault(t => t.user_id == id);
            return View(tkuser);
        }

        [HttpPost]
        public ActionResult Taikhoan(Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(account);
        }

        public ActionResult Doimatkhau()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Doimatkhau(string Password, string NewPassword, string RenewPassword)
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
                        ViewBag.Message = "Thay đổi mật khẩu thành công";
                        db.Entry(Xacthuc).State = EntityState.Modified;
                        db.SaveChanges();
                        return View();
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

        public ActionResult DangXuat()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}