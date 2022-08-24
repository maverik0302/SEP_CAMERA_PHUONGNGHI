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
                return RedirectToAction("Dashboard", "HomeAdmin");
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
        public ActionResult Dashboard()
        {
            ThongKeDoanhThuThang();
            return View();

        }
      
        public void ThongKeDoanhThuThang()
        {
            for (int i = 1; i <= 12; i++)
            {
                int Nam = DateTime.Now.Year;
                var saoke = db.Oders.Where(n => n.orderdate.Value.Month == i && n.orderdate.Value.Year == Nam).ToList();
                decimal tong = 0;

                if (saoke.Count > 0)
                {
                    foreach (var item in saoke)
                        tong += decimal.Parse(item.total_price.Value.ToString());
                }

                if (i == 1) { ViewBag.TongThangMot = tong; }
                else if (i == 2) { ViewBag.TongThangHai = tong; }
                else if (i == 3) { ViewBag.TongThangBa = tong; }
                else if (i == 4) { ViewBag.TongThangBon = tong; }
                else if (i == 5) { ViewBag.TongThangNam = tong; }
                else if (i == 6) { ViewBag.TongThangSau = tong; }
                else if (i == 7) { ViewBag.TongThangBay = tong; }
                else if (i == 8) { ViewBag.TongThangTam = tong; }
                else if (i == 9) { ViewBag.TongThangChin = tong; }
                else if (i == 10) { ViewBag.TongThangMuoi = tong; }
                else if (i == 11) { ViewBag.TongThangMMot = tong; }
                else if (i == 12) { ViewBag.TongThangMHai = tong; }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}