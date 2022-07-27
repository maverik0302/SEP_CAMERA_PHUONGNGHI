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
            var user = model.Accounts.FirstOrDefault(u => u.Email.Equals(email));/*ADMIN.FirstOrDefault(u => u.email.Equals(email));*/
            if(user != null)
            {
                if (user.Password.Equals(password))
                {
                    Session["user-username"] = user.Username;
                    Session["user-id"] = user.user_id;
                   
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

        // GET: Admin/tbProducts/Edit/5
        public ActionResult ChangeAccount(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = model.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Admin/tbProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeAccount( Account account)
        {
            if (ModelState.IsValid)
            {

                model.Entry(account).State = EntityState.Modified;
                model.SaveChanges();
                return RedirectToAction("Index", "HomeAdmin");
            }
            return View(account);
        }

    }
}