using Meeeedium.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Meeeedium.Controllers
{

    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
     
        {
            ViewBag.PublicBlogs = db.Blogs.Where(n => n.Public == true).ToList();
            return View();
        }
        public ActionResult Details(int? id)

        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.PublicBlogs = db.Blogs.Where(n => n.Public == true).ToList();
            return View();
        }


    }
}