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
        SEP25Team01Entities db = new SEP25Team01Entities();
        public ActionResult Index()
        {
            List<tbProduct> ketqua = db.tbProducts.ToList();

            return View(ketqua);
        }
        public ActionResult Blog(int id)
        {
            var lstBlog = db.Posts.Where(P => P.post_id == id).ToList();

            return View("Home", lstBlog);
        }
    }
}