using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEP_CAMERA_PHUONGNGHI.Models;

namespace SEP_CAMERA_PHUONGNGHI.Controllers
{
    public class AboutsController : Controller
    {
        SEP25Team01Entities db = new SEP25Team01Entities();
        // GET: About
        public ActionResult Abouts()
        {
            List<About> ab = db.Abouts.ToList();

            return View(ab);
        }
    }
}