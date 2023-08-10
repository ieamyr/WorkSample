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
        private ApplicationDbContext context = new ApplicationDbContext();

        // GET: VideoTitles
        public ActionResult Index()
        {
            var videoTitles = context.VideoTitles.Include(v => v.Lesson);
            return View(videoTitles.ToList());
        }

        // GET: VideoTitles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoTitle videoTitle = context.VideoTitles.Find(id);
            if (videoTitle == null)
            {
                return HttpNotFound();
            }
            return View(videoTitle);
        }

        // GET: VideoTitles/Create
        public ActionResult Create()
        {
            ViewBag.LessonId = new SelectList(context.Lessons, "LessonId", "LessonTitle");
            return View();
        }

        // POST: VideoTitles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VideoTitleId,Title,VideoUrl,Time,LessonId")] VideoTitle videoTitle)
        {
            if (ModelState.IsValid)
            {
                context.VideoTitles.Add(videoTitle);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LessonId = new SelectList(context.Lessons, "LessonId", "LessonTitle", videoTitle.LessonId);
            return View(videoTitle);
        }

        // GET: VideoTitles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoTitle videoTitle = context.VideoTitles.Find(id);
            if (videoTitle == null)
            {
                return HttpNotFound();
            }
            ViewBag.LessonId = new SelectList(context.Lessons, "LessonId", "LessonTitle", videoTitle.LessonId);
            return View(videoTitle);
        }

        // POST: VideoTitles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VideoTitleId,Title,VideoUrl,Time,LessonId")] VideoTitle videoTitle)
        {
            if (ModelState.IsValid)
            {
                context.Entry(videoTitle).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LessonId = new SelectList(context.Lessons, "LessonId", "LessonTitle", videoTitle.LessonId);
            return View(videoTitle);
        }

        // GET: VideoTitles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoTitle videoTitle = context.VideoTitles.Find(id);
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
            VideoTitle videoTitle = context.VideoTitles.Find(id);
            context.VideoTitles.Remove(videoTitle);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
