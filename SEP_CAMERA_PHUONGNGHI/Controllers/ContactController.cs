using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEP_CAMERA_PHUONGNGHI.Models;


namespace SEP_CAMERA_PHUONGNGHI.Controllers
{
    public class ContactController : Controller
    {
        SEP25Team01Entities db = new SEP25Team01Entities();
        // GET: Contact

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Contact(Contact ct)
        {
            db.Contacts.Add(ct);
            db.SaveChanges();
            return View();
        }
    }
}