using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEP_CAMERA_PHUONGNGHI.Models;

namespace SEP_CAMERA_PHUONGNGHI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SEP25Team01Entities db = new SEP25Team01Entities();
            List<tbProduct> ketqua = db.tbProducts.ToList();

            return View(ketqua);
        }
    }
}