using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWork.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                return View();
            }catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Faq()
        {
            ViewBag.Message = "Your Faq page.";

            return View();
        }
        public ActionResult Blogs()
        {
            ViewBag.Message = "Your Blog page.";

            return View();
        } 

    }
}