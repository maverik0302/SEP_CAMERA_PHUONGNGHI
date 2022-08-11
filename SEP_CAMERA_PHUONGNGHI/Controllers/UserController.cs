using System;
using System.Collections.Generic;
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
        public ActionResult DangKy() { 
            return View(); 
        }


        [HttpPost]

        public ActionResult DangKy(Account acc)
        {
            db.Accounts.Add(acc);
            db.SaveChanges();
            return View();
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string sAcc = f["txtTaikhoan"].ToString();
            string sPass = f.Get("txtMatkhau").ToString();
            
            Account sUser = db.Accounts.SingleOrDefault(n => n.Email==sAcc&&n.Password == sPass); 

            if(sUser != null)
            {
                ViewBag.ThongBao = "Đăng nhập thành công!";
                Session["Account"] = sUser;
                return View();
            }
            ViewBag.ThongBao = "Không tìm thấy mật khẩu hoặc tài khoản";
            return View();
        }

    }
}