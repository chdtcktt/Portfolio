using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPortfolioWebsite.Areas.CrudDemo.Controllers
{
    public class CrudController : Controller
    {
        //
        // GET: /CrudDemo/Crud/

        public ActionResult Index()
        {

            ViewBag.Header = "CRUD Operations Demo";

            return View();
        }



        /// <summary>
        /// set the 
        /// </summary>
        /// <param name="crudtype"></param>
        public void ReadData(string crudtype)
        { }


           //if(crudtype == "1")
           //{
               
           //}
           //else
           //{

           //}

        public ActionResult Select(string crudtype)
        {
           

            return View();

        }


    }
}
