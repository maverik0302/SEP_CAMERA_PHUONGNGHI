using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEP_CAMERA_PHUONGNGHI.Models;

namespace SEP_CAMERA_PHUONGNGHI.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Blog()
        {
            SEP25Team01Entities bl = new SEP25Team01Entities();
            List<Post> blog = bl.Posts.ToList();

            return View(blog);
        }
        public ActionResult BlogDetail(int id)
        {
            SEP25Team01Entities bl = new SEP25Team01Entities();
            Post bldt = bl.Posts.Find(id);

            return View(bldt);
        }
    }
}
