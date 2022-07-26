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
    public class PostController : Controller
    {
        private SEP25Team01Entities db = new SEP25Team01Entities();

        // GET: Admin/Post
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.CommentPost);
            return View(posts.ToList());
        }

        // GET: Admin/Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Admin/Post/Create
        public ActionResult Create()
        {
            ViewBag.comment_id = new SelectList(db.CommentPosts, "comment_id", "Name");
            return View();
        }

        // POST: Admin/Post/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "post_id,Name,SeoTitle,Status,Image,Description,Detail,MetaKey,MetaDescription,CreateDate,UpdateDate,comment_id")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                post.CreateDate = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.comment_id = new SelectList(db.CommentPosts, "comment_id", "Name", post.comment_id);
            return View(post);
        }

        // GET: Admin/Post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.comment_id = new SelectList(db.CommentPosts, "comment_id", "Name", post.comment_id);
            return View(post);
        }

        // POST: Admin/Post/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "post_id,Name,SeoTitle,Status,Image,Description,Detail,MetaKey,MetaDescription,CreateDate,UpdateDate,comment_id")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                post.UpdateDate = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.comment_id = new SelectList(db.CommentPosts, "comment_id", "Name", post.comment_id);
            return View(post);
        }

        // GET: Admin/Post/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Admin/Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
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
