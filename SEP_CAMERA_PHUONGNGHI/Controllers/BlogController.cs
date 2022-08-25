using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEP_CAMERA_PHUONGNGHI.Models;
using PagedList;
using PagedList.Mvc;

namespace SEP_CAMERA_PHUONGNGHI.Controllers
{
    public class BlogController : Controller
    {
        SEP25Team01Entities bl = new SEP25Team01Entities();
        // GET: Blog
        public ActionResult Blog(int? page)
        {
            int pageSize = 9;

            int pageNumber = (page ?? 1);

            List<Post> blog = bl.Posts.ToList();

            return View(bl.Posts.ToList().ToPagedList(pageNumber, pageSize));
        }
        public ActionResult BlogDetail(int id)
        {
            SEP25Team01Entities bl = new SEP25Team01Entities();
            Post bldt = bl.Posts.Find(id);

            return View(bldt);
        }
    }
}
