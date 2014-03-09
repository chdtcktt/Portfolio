using MvcPortfolioWebsite.Areas.CrudDemo.Models.ADO;
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
        CrudOperation Ado;

        public CrudController()
        {
           Ado = new CrudOperation();   
        }

        public ActionResult Index()
        {
            ViewBag.Header = "Crud Demo";

             
            
            List<Person> persons = Ado.GetPersons();




            return View();
        }


        public ActionResult EntityFw()
        {
            return View();
        }



 

  


    }
}
