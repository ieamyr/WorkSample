using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWork.Controllers
{
/*    [Authorize]*/
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Layout()
        {
            return PartialView("_Layout");
        }
    }
}