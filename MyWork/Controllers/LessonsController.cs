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

    public class LessonsController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        // GET: Lessons
        public ActionResult Index()
        {
            var lessons = context.Lessons.Include(l => l.Couerse);
            return View(lessons.ToList());
        }
        // GET: Lessons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = context.Lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }
        // GET: Lessons/Create
        public ActionResult Create()
        {
            ViewBag.CouerseId = new SelectList(context.Couerses, "Id", "Title");
            return View();
        }
        // POST: Lessons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LessonId,LessonTitle,CouerseId")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                context.Lessons.Add(lesson);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CouerseId = new SelectList(context.Couerses, "Id", "Title", lesson.CouerseId);
            return View(lesson);
        }
        // GET: Lessons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = context.Lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            ViewBag.CouerseId = new SelectList(context.Couerses, "Id", "Title", lesson.CouerseId);
            return View(lesson);
        }
        // POST: Lessons/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LessonId,LessonTitle,CouerseId")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                context.Entry(lesson).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CouerseId = new SelectList(context.Couerses, "Id", "Title", lesson.CouerseId);
            return View(lesson);
        }
        // GET: Lessons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = context.Lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }
        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lesson lesson = context.Lessons.Find(id);
            context.Lessons.Remove(lesson);
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
