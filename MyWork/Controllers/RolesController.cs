using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyWork.Models;

namespace MyWork.Controllers
{
    [Authorize(Roles = "admin")]
    public class RolesController : Controller
    {
        ApplicationDbContext Context;

        public RolesController()
        {
            Context = new ApplicationDbContext();
        }
        // GET: Roles
        public ActionResult Index()
        {
            var Role = Context.Roles.ToList();
            return View(Role);
        }
        public ActionResult Create()
        {
            var Role  = new IdentityRole();
            return View(Role);
        }
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            Context.Roles.Add(Role);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}