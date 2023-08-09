using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using MyWork.Models;

namespace MyWork.Controllers
{
    [Authorize(Roles = "admin")]
    public class CouersesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Couerses
        public ActionResult Index()
        {
            return View(db.Couerses.ToList());
        }
        public ActionResult List()
        {
            return PartialView("_List", db.Couerses.ToList());
        }

        // GET: Couerses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Couerse couerse = db.Couerses.Find(id);
            if (couerse == null)
            {
                return HttpNotFound();
            }
            return View(couerse);
        }

        // GET: Couerses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Couerses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,Price")] Couerse couerse, HttpPostedFileBase image)
        {
            if (image.ContentLength <= 2000000)
            {
                string extension = Path.GetExtension(image.FileName);
                if (extension.ToLower() == ".png" || extension.ToLower() == ".jpg")
                {
                    if (ModelState.IsValid)
                    {
                        // Save Image in The Folder img ------------------
                        string filname = GenerateRandomNumber() + extension;
                        string strpath = Server.MapPath("~/img/") + filname;
                        image.SaveAs(strpath);
                        // Save in the Db
                        couerse.Image = filname;
                        db.Couerses.Add(couerse);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(couerse);
        }

        // GET: Couerses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Couerse couerse = db.Couerses.Find(id);
            if (couerse == null)
            {
                return HttpNotFound();
            }
            return View(couerse);
        }
        // Post: Couerses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,Price,Image")] Couerse couerse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(couerse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(couerse);
        }

        // GET: Couerses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Couerse couerse = db.Couerses.Find(id);
            if (couerse == null)
            {
                return HttpNotFound();
            }
            return View(couerse);
        }

        // POST: Couerses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Couerse couerse = db.Couerses.Find(id);
            db.Couerses.Remove(couerse);
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
        // Get RandNumber
        public string GenerateRandomNumber()
        {
            string result = "";
            for (int i = 0; i < 20; i++)
            {
                Random rnd = new Random();
                result = result + rnd.Next(0, 10);
            }
            return result;
        }
    }
}
