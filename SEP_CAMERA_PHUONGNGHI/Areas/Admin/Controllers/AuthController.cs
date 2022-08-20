using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SEP_CAMERA_PHUONGNGHI.Models;
namespace SEP_CAMERA_PHUONGNGHI.Areas.Admin.Controllers
{
    
    public class AuthController : Controller
    {
        SEP25Team01Entities model = new SEP25Team01Entities();
        // GET: Admin/Auth
        public ActionResult Login()
        {
            Session["password-incorrect"] = false;  
            Session["user-not-found"] = false;
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var user = model.Accounts.FirstOrDefault(u => u.Email.Equals(email) && u.Password.Equals(password));/*ADMIN.FirstOrDefault(u => u.email.Equals(email));*/
            if(user != null)
            {
                if (user.Role == null)
                {
                    ViewBag.ThongBao = "Đăng nhập thành công!";
                    Session["Account"] = user;
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                else
                {
                    Session["user-username"] = user.Username;
                    Session["user-id"] = user.user_id;
                    Session["user-fname"] = user.FirstName;
                    Session["user-lname"] = user.LastName;
                    return RedirectToAction("Dashboard", "HomeAdmin");

                }
            }
            Session["password-incorrect"] = true;
            Session["user-not-found"] = true;
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}