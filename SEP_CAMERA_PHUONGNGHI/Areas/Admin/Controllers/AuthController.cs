using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEP_CAMERA_PHUONGNGHI.Models;
namespace SEP_CAMERA_PHUONGNGHI.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        PhuongNghiEntities model = new PhuongNghiEntities();
        // GET: Admin/Auth
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var user = model.ADMIN.FirstOrDefault(u => u.email.Equals(email));/*ADMIN.FirstOrDefault(u => u.email.Equals(email));*/
            if(user != null)
            {
                if (user.password.Equals(password))
                {
                    Session["user-username"] = user.username;
                    Session["user-id"] = user.id_admin;
                    return RedirectToAction("Index", "HomeAdmin");
                }
                else
                {
                    Session["password-incorrect"] = true;
                    return View();
                }
            }
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