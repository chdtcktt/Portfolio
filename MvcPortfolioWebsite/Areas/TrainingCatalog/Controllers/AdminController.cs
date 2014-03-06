using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPortfolioWebsite.Areas.TrainingCatalog.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /TrainingCatalog/Admin/

        public ActionResult EditUser()
        {
            return View();
        }

        public ActionResult EditCourses()
        {
            return View();
        }
        public ActionResult EditTemplates()
        {
            return View();
        }
    }
}
