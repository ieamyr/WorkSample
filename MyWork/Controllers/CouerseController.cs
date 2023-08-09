using MyWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWork.Controllers
{
    public class CouerseController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            try
            {
                List<Couerse> entity = context.Couerses.ToList();
                return PartialView("_List", entity);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
        public ActionResult Detail(int id)
        {
            Couerse entity = context.Couerses.Find(id);
            return View(entity);
        }
        public ActionResult Search(String search)
        {
            try
            {
                var entities = context.Couerses.Where(b => b.Title.Contains(search)).ToList();
                return View(entities);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
    }
}
