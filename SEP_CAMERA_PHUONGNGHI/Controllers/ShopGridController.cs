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
        SEP25Team01Entities db = new SEP25Team01Entities();
        // GET: ShopGrid
        public ActionResult ShopGrid()
        {
            List<tbProduct> ketqua = db.tbProducts.ToList();

            return View(ketqua);
        }
        public ActionResult ProductDetail(int id)
        { 
            tbProduct detail = db.tbProducts.Find(id);

            return View(detail);
        }
        public ActionResult Category(int id)
        {
            var lstProduct = db.tbProducts.Where(P => P.category_id == id).ToList();

            return View("ShopGrid", lstProduct);
        }

        public ActionResult Brand(int idbrand, int idcategory)
        {
            var lstBrand = db.tbProducts.Where(B => B.brand_id == idbrand && B.category_id == idcategory).ToList();

            return View("ShopGrid", lstBrand);
        }
    }
}