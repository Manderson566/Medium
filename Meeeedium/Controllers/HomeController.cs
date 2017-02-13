using Meeeedium.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Meeeedium.Controllers
{

    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
     
        {
            ViewBag.PublicBlogs = db.Blogs.Where(n => n.Public == true).ToList().OrderByDescending(o => o.Created);
            return View();
        }
        public ActionResult Details(int? id)

        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Where(b => b.Public == true).Where(b => b.Id == id).FirstOrDefault();
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        [HttpPost]
        public ActionResult Index(BlogSearch searchBox)
        {
            string userid = User.Identity.GetUserId();
            ViewBag.PublicBlogs = db.Blogs.Include(b => b.Owner).Where(b => b.Public == true).Where(b => b.Title.Contains(searchBox.Search));
            return View();

            
           
        }


    }
}