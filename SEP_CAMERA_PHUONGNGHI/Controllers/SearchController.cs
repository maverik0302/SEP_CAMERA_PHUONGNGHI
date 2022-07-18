using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SEP_CAMERA_PHUONGNGHI.Models;
using PagedList;
using PagedList.Mvc;

namespace SEP_CAMERA_PHUONGNGHI.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        SEP25Team01Entities db = new SEP25Team01Entities();
        public ActionResult SearchReult(int productid = 0, string keyword ="")
        {
            if(keyword != "")
            {
                var lstProduct = db.tbProducts.Include(x => x.Name).Where(x => x.Name.ToUpper().Contains(keyword));
                return View(lstProduct);
            }
            else if (productid > 0)
            {
                var lstProduct = db.tbProducts.Include(x => x.Name).Where(x => x.product_id == productid);
                return View(lstProduct.ToList());
            }
            return View();
            
        }
    }
}