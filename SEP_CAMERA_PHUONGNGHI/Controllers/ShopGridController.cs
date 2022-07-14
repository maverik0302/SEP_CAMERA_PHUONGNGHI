using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEP_CAMERA_PHUONGNGHI.Models;

namespace SEP_CAMERA_PHUONGNGHI.Controllers
{
    public class ShopGridController : Controller
    {
        // GET: ShopGrid
        public ActionResult ShopGrid()
        {
            SEP25Team01Entities db = new SEP25Team01Entities();
            List<tbProduct> ketqua = db.tbProducts.ToList();

            return View(ketqua);
        }
        public ActionResult ProductDetail(int id)
        {
            SEP25Team01Entities db = new SEP25Team01Entities();
            tbProduct detail = db.tbProducts.Find(id);

            return View(detail);
        }
    }
}