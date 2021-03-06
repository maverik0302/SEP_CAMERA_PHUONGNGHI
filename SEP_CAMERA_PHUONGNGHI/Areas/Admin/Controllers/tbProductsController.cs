using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SEP_CAMERA_PHUONGNGHI.Models;

namespace SEP_CAMERA_PHUONGNGHI.Areas.Admin.Controllers
{
    public class tbProductsController : Controller
    {
        private SEP25Team01Entities db = new SEP25Team01Entities();

        // GET: Admin/tbProducts
        public ActionResult Index()
        {
            var model = db.tbProducts.ToList();
            //var tbProducts = db.tbProducts.Include(t => t.Brand).Include(t => t.Category).Include(t => t.CommentProduct);
            return View(model); /*tbProducts.ToList()*/
        }

        // GET: Admin/tbProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbProduct tbProduct = db.tbProducts.Find(id);
            if (tbProduct == null)
            {
                return HttpNotFound();
            }
            return View(tbProduct);
        }

        // GET: Admin/tbProducts/Create
        public ActionResult Create()
        {
            ViewBag.brand_id = new SelectList(db.Brands, "brand_id", "Name");
            ViewBag.category_id = new SelectList(db.Categories, "category_id", "Name");
            ViewBag.comment_id = new SelectList(db.CommentProducts, "comment_id", "Name");
            return View();
        }

        // POST: Admin/tbProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "product_id,Name,SeoTitle,Status,Thumnail,Price,PromotionPrice,TonKho,BaoHanh,Desciption,category_id,brand_id,MetaKey,MetaDescription,CreateDate,UpdateDate,rank,comment_id")] tbProduct tbProduct)
        {
            if (ModelState.IsValid)
            {
                db.tbProducts.Add(tbProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.brand_id = new SelectList(db.Brands, "brand_id", "Name", tbProduct.brand_id);
            ViewBag.category_id = new SelectList(db.Categories, "category_id", "Name", tbProduct.category_id);
            ViewBag.comment_id = new SelectList(db.CommentProducts, "comment_id", "Name", tbProduct.comment_id);
            return View(tbProduct);
        }

        // GET: Admin/tbProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbProduct tbProduct = db.tbProducts.Find(id);
            if (tbProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.brand_id = new SelectList(db.Brands, "brand_id", "Name", tbProduct.brand_id);
            ViewBag.category_id = new SelectList(db.Categories, "category_id", "Name", tbProduct.category_id);
            ViewBag.comment_id = new SelectList(db.CommentProducts, "comment_id", "Name", tbProduct.comment_id);
            return View(tbProduct);
        }

        // POST: Admin/tbProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "product_id,Name,SeoTitle,Status,Thumnail,Price,PromotionPrice,TonKho,BaoHanh,Desciption,category_id,brand_id,MetaKey,MetaDescription,CreateDate,UpdateDate,rank,comment_id")] tbProduct tbProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.brand_id = new SelectList(db.Brands, "brand_id", "Name", tbProduct.brand_id);
            ViewBag.category_id = new SelectList(db.Categories, "category_id", "Name", tbProduct.category_id);
            ViewBag.comment_id = new SelectList(db.CommentProducts, "comment_id", "Name", tbProduct.comment_id);
            return View(tbProduct);
        }

        // GET: Admin/tbProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbProduct tbProduct = db.tbProducts.Find(id);
            if (tbProduct == null)
            {
                return HttpNotFound();
            }
            return View(tbProduct);
        }

        // POST: Admin/tbProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbProduct tbProduct = db.tbProducts.Find(id);
            db.tbProducts.Remove(tbProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
