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
        public ActionResult Dashboard()
        {
            //Return với tổng doanh thu của cửa hàng

            if (Session["user-id"] != null)
            {
                for (int i = 1; i <= 12; i++)
                {
                    int days = DateTime.DaysInMonth(DateTime.Now.Year, i);
                    string ssDate = DateTime.Now.Year + "-" + i.ToString().PadLeft(2, '0') + "-01 00:00:00";
                    string seDate = DateTime.Now.Year + "-" + i.ToString().PadLeft(2, '0') + "-" + days.ToString().PadLeft(2, '0') + " 00:00:00";
                    DateTime stD = DateTime.ParseExact(ssDate, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    DateTime enD = DateTime.ParseExact(seDate, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                    //var saoke = db.Sao_Ke.Where(s => s.Ngay_Giao_Dich >= stD && s.Ngay_Giao_Dich <= enD).ToList();
                    decimal tong = 0;
                    decimal coc = 0;
                    decimal thanhtoan = 0;

                    //if (saoke.Count > 0)
                    //{
                    //    foreach (var item in saoke.Where(s => s.Coc_or_ThanhToan == 0).ToList())
                    //        coc += item.So_Tien;
                    //    foreach (var item in saoke.Where(s => s.Coc_or_ThanhToan == 1).ToList())
                    //        thanhtoan += item.So_Tien;
                    //    foreach (var item in saoke)
                    //        tong += item.So_Tien;
                    //}

                    if (i == 1) { ViewBag.CocThangMot = coc; ViewBag.ThanhToanThangMot = thanhtoan; ViewBag.TongThangMot = tong; }
                    else if (i == 2) { ViewBag.CocThangHai = coc; ViewBag.ThanhToanThangHai = thanhtoan; ViewBag.TongThangHai = tong; }
                    else if (i == 3) { ViewBag.CocThangBa = coc; ViewBag.ThanhToanThangBa = thanhtoan; ViewBag.TongThangBa = tong; }
                    else if (i == 4) { ViewBag.CocThangBon = coc; ViewBag.ThanhToanThangBon = thanhtoan; ViewBag.TongThangBon = tong; }
                    else if (i == 5) { ViewBag.CocThangNam = coc; ViewBag.ThanhToanThangNam = thanhtoan; ViewBag.TongThangNam = tong; }
                    else if (i == 6) { ViewBag.CocThangSau = coc; ViewBag.ThanhToanThangSau = thanhtoan; ViewBag.TongThangSau = tong; }
                    else if (i == 7) { ViewBag.CocThangBay = coc; ViewBag.ThanhToanThangBay = thanhtoan; ViewBag.TongThangBay = tong; }
                    else if (i == 8) { ViewBag.CocThangTam = coc; ViewBag.ThanhToanThangTam = thanhtoan; ViewBag.TongThangTam = tong; }
                    else if (i == 9) { ViewBag.CocThangChin = coc; ViewBag.ThanhToanThangChin = thanhtoan; ViewBag.TongThangChin = tong; }
                    else if (i == 10) { ViewBag.CocThangMuoi = coc; ViewBag.ThanhToanThangMuoi = thanhtoan; ViewBag.TongThangMuoi = tong; }
                    else if (i == 11) { ViewBag.CocThangMMot = coc; ViewBag.ThanhToanThangMot = thanhtoan; ViewBag.TongThangMMot = tong; }
                    else if (i == 12) { ViewBag.CocThangMHai = coc; ViewBag.ThanhToanThangMHai = thanhtoan; ViewBag.TongThangMHai = tong; }
                }
                return View();
            }
            return RedirectToAction("Index");

        }
    }
}