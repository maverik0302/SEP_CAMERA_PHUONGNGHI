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
    public class SearchController : Controller
    {
        // GET: Search
        SEP25Team01Entities db = new SEP25Team01Entities();
        public ActionResult SearchReult(String keyword)
        {
            var lstProduct = db.tbProducts.Where(x => x.Name.Contains(keyword));
            return View(lstProduct.OrderBy(x=>x.Name));
        }
    }
}