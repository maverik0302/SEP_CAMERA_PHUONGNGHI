using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
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

        public ActionResult ProductCate(int id)
        {
            var lstProduct = db.tbProducts.Where(P => P.category_id == id).ToList();

            return View("ShopGrid", lstProduct);
        }
        public ActionResult Cmtrate(int id)
        {
            var cmt = db.Cmts.Where(P => P.cmt_id == id).ToList();

            return View("ShopGrid", cmt);
        }

        [HttpPost]
        public ActionResult CommentRate(string sreview, int userID, int proID)
        {
            if (!string.IsNullOrEmpty(sreview.Trim()))
            {

                Cmt dcomment = new Cmt();
                dcomment.product_id = proID;
                dcomment.user_id = userID;
                dcomment.rating = "5";
                dcomment.review = sreview;
                dcomment.CreateDate = DateTime.Now;
                db.Cmts.Add(dcomment);
                db.SaveChanges();
                return RedirectToAction("ProductDetail", new { id = proID });
            }

            return RedirectToAction("ProductDetail", new { id = proID });
        }
    }
}