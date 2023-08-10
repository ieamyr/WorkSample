using Microsoft.Ajax.Utilities;
using MyWork.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace MyWork.Controllers
{
    public class BlogController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        // GET: BlogC
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            List<BlogC> entity = context.BlogCs.ToList();
            return PartialView("_List", entity);
        }
        public ActionResult Detail(int id)
        {
            BlogC entity = context.BlogCs.Find(id);
            return View(entity);
        }
        // List 5 New Date
        public ActionResult ListNewData()
        {
            List<BlogC> entity = context.BlogCs.OrderByDescending(x => x.Id).Take(5).ToList();
            return PartialView("_ListNewData", entity);
        }
        // Search in the Blog Title
        public ActionResult Search(String title)
        {
            try
            {
                var entities = context.BlogCs.Where(b => b.Title.Contains(title)).ToList();
                return View(entities);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
    }
}