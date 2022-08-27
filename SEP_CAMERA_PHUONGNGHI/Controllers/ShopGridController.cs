using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEP_CAMERA_PHUONGNGHI.Models;
using PagedList;
using PagedList.Mvc;

namespace SEP_CAMERA_PHUONGNGHI.Controllers
{
    public class ShopGridController : Controller
    {
        SEP25Team01Entities db = new SEP25Team01Entities();
        // GET: ShopGrid
        public ActionResult ShopGrid(int? page)
        {
            int pageSize = 12;

            int pageNumber = (page ?? 1);

            return View(db.tbProducts.ToList().OrderBy(n => n.product_id).ToPagedList(pageNumber, pageSize));
        }


        public ActionResult ProductDetail(int id)
        {
            tbProduct detail = db.tbProducts.Find(id);

            return View(detail);
        }


        public ActionResult Category(int id, int? page)
        {
            int pageSize = 9;

            int pageNumber = (page ?? 1);

            return View("ShopGrid", db.tbProducts.ToList().Where(P => P.category_id == id).ToPagedList(pageNumber, pageSize));
        }



        public ActionResult Brand(int idbrand, int idcategory, int? page)
        {
            //var lstBrand = db.tbProducts.Where(B => B.brand_id == idbrand && B.category_id == idcategory).ToList();
            int pageSize = 9;

            int pageNumber = (page ?? 1);

            return View("ShopGrid", db.tbProducts.ToList().Where(B => B.brand_id == idbrand && B.category_id == idcategory).ToPagedList(pageNumber, pageSize));
        }



        public ActionResult ProductCate(int id, int? page)
        {
            int pageSize = 9;

            int pageNumber = (page ?? 1);

            return View("ShopGrid", db.tbProducts.ToList().Where(P => P.category_id == id).ToPagedList(pageNumber, pageSize));
        }


        public ActionResult Cmtrate(int id, int? page)
        {
            int pageSize = 9;

            int pageNumber = (page ?? 1);

            return View("ShopGrid", db.Cmts.ToList().Where(P => P.cmt_id == id).ToPagedList(pageNumber, pageSize));
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