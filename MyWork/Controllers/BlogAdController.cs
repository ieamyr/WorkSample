using MyWork.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWork.Controllers
{
    [Authorize(Roles = "admin")]
    public class BlogAdController : Controller
    {
        // GET: BlogCAd
        private ApplicationDbContext context = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            List<BlogC> entity = context.BlogCs.ToList();
            return PartialView("_List", entity);
        }
        [HttpGet]
        public ActionResult Create()
        {
            BlogC entity = new BlogC();
            return View(entity);
        }
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase image, BlogC entity)
        {
            string extension = Path.GetExtension(image.FileName);

            if (image.ContentLength <= 2000000)
            {
                if (extension.ToLower() == ".png" || extension.ToLower() == ".jpg")
                {
                    string filname = GenerateRandomNumber() + extension;
                    string strpath = Server.MapPath("~/img/") + filname;
                    image.SaveAs(strpath);

                    entity.Image = filname;
                    context.BlogCs.Add(entity);
                    context.SaveChanges();
                    return RedirectToAction("List");
                }
            }
            return RedirectToAction("Create");
        }
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
        public ActionResult DeleteConfirm(int id)
        {
            BlogC entity = context.BlogCs.Find(id);
            return View(entity);
        }
        public ActionResult Delete(int id)
        {
            BlogC entity = context.BlogCs.Find(id);
            context.BlogCs.Remove(entity);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            BlogC entity = context.BlogCs.Find(id);
            return View(entity);
        }
        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase image, BlogC entity)
        {
            string extension = Path.GetExtension(image.FileName);

            if (image.ContentLength <= 2000000)
            {
                if (extension.ToLower() == ".png" || extension.ToLower() == ".jpg")
                {
                    string filname = GenerateRandomNumber() + extension;
                    string strpath = Server.MapPath("~/img/") + filname;
                    image.SaveAs(strpath);

                    entity.Image = filname;
                    context.BlogCs.AddOrUpdate(entity);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}