using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyWork.Models;

namespace MyWork.Controllers
{
    [Authorize(Roles = "admin")]

    public class VideoTitlesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VideoTitles
        public ActionResult Index()
        {
            var videoTitles = db.VideoTitles.Include(v => v.Lesson);
            return View(videoTitles.ToList());
        }

        // GET: VideoTitles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoTitle videoTitle = db.VideoTitles.Find(id);
            if (videoTitle == null)
            {
                return HttpNotFound();
            }
            return View(videoTitle);
        }

        // GET: VideoTitles/Create
        public ActionResult Create()
        {
            ViewBag.LessonId = new SelectList(db.Lessons, "LessonId", "LessonTitle");
            return View();
        }

        // POST: VideoTitles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VideoTitleId,Title,VideoUrl,Time,LessonId")] VideoTitle videoTitle)
        {
            if (ModelState.IsValid)
            {
                db.VideoTitles.Add(videoTitle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LessonId = new SelectList(db.Lessons, "LessonId", "LessonTitle", videoTitle.LessonId);
            return View(videoTitle);
        }

        // GET: VideoTitles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoTitle videoTitle = db.VideoTitles.Find(id);
            if (videoTitle == null)
            {
                return HttpNotFound();
            }
            ViewBag.LessonId = new SelectList(db.Lessons, "LessonId", "LessonTitle", videoTitle.LessonId);
            return View(videoTitle);
        }

        // POST: VideoTitles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VideoTitleId,Title,VideoUrl,Time,LessonId")] VideoTitle videoTitle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoTitle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LessonId = new SelectList(db.Lessons, "LessonId", "LessonTitle", videoTitle.LessonId);
            return View(videoTitle);
        }

        // GET: VideoTitles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoTitle videoTitle = db.VideoTitles.Find(id);
            if (videoTitle == null)
            {
                return HttpNotFound();
            }
            return View(videoTitle);
        }

        // POST: VideoTitles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VideoTitle videoTitle = db.VideoTitles.Find(id);
            db.VideoTitles.Remove(videoTitle);
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
