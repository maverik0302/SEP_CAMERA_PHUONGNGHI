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
            // Lấy số lượng người truy cập từ application
            ViewBag.SoNguoiTruyCap = HttpContext.Application["SoNguoiTruyCap"].ToString(); // lấy số lượng người truy cập từ application đã được tạo 
            ViewBag.SoNguoiOnline = HttpContext.Application["SoNguoiDangOnline"].ToString(); // lấy số người đang online trên website
            ViewBag.TongDoanhThu = ThongKeTongDoanhThu();
            ViewBag.DoanhThuTheoThang = ThongKeDoanhThuThang(Thang: DateTime.Now.Month, Nam: DateTime.Now.Year);
            return View();

        }
        public decimal ThongKeTongDoanhThu()
        {
            decimal TongDoanhThu = db.OrderDetails.Sum(n => n.num * n.price_product).Value;
            return TongDoanhThu;
        }

        public decimal ThongKeDoanhThuThang(int Thang, int Nam)
        {
            Thang = DateTime.Now.Month;
            Nam = DateTime.Now.Year;
            // Thống kê theo doanh thu  theo tháng
            // List ra những đơn hàng nào có tháng, năm tương ứng
            var lstDDH = db.Oders.Where(n => n.orderdate.Value.Month == Thang && n.orderdate.Value.Year == Nam);
            decimal TongTien = 0;
            // Duyệt chi tiết của đơn hàng đó và lấy tổng tiền của tất cả sản phẩm thuộc đơn hàng đó
            foreach (var item in lstDDH)
            {
                TongTien += decimal.Parse(item.OrderDetails.Sum(n => n.num * n.price_product).Value.ToString());
            }
            return TongTien;
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