using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Meeeedium.Models;
using Microsoft.AspNet.Identity;

namespace Meeeedium.Controllers
{
    public class BlogController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private IQueryable<Blog> GetBlogs()
        {
            string userid = User.Identity.GetUserId();
            return db.Blogs.Include(b => b.Owner).Where(b => b.OwnerId == userid);
        }
        // GET: Blog
        [Authorize]
        public ActionResult Index()
        {
            var blogs = GetBlogs().OrderByDescending(o => o.Created);
            return View(blogs.ToList());
        }

        //Post Blog
        [HttpPost]
        public ActionResult Index(BlogSearch searchBox)
        {
            var blogs = GetBlogs().Where(b => b.Title.Contains(searchBox.Search));
            return View(blogs.ToList());
        }

        // GET: Blog/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userId = User.Identity.GetUserId();
            Blog blog = db.Blogs.Where(b => b.OwnerId == userId).Where(b => b.Id == id).FirstOrDefault();
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blog/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.OwnerId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Blog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,TeaserText,Body,Public")] Blog blog)
        {

            
                db.Blogs.Add(blog);
                blog.OwnerId = User.Identity.GetUserId();
                blog.Created = DateTime.Now;
                db.SaveChanges();
           
            ViewBag.OwnerId = new SelectList(db.Users, "Id", "Email", blog.OwnerId);
            return RedirectToAction("Index");
        }

        // GET: Blog/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userId = User.Identity.GetUserId();
            Blog blog = db.Blogs.Where(b => b.OwnerId == userId).Where(b => b.Id == id).FirstOrDefault();
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerId = new SelectList(db.Users, "Id", "Email", blog.OwnerId);
            return View(blog);
        }

        // POST: Blog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,TeaserText,Body,Public")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                blog.OwnerId = User.Identity.GetUserId();
                db.Entry(blog).State = EntityState.Modified;
                blog.Created = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerId = new SelectList(db.Users, "Id", "Email", blog.OwnerId);
            return View(blog);
        }

        // GET: Blog/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userId = User.Identity.GetUserId();
            Blog blog = db.Blogs.Where(b => b.OwnerId == userId).Where(b => b.Id == id).FirstOrDefault();
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
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
            {

            }
        }
    }
}
