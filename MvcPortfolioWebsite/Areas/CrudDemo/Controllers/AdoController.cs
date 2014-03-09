using MvcPortfolioWebsite.Areas.CrudDemo.Models.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace MvcPortfolioWebsite.Areas.CrudDemo.Controllers
{
    public class AdoController : Controller
    {
        //
        // GET: /CrudDemo/Crud/
        readonly CrudOperation ado;

        public AdoController()
        {
           ado = new CrudOperation();
              
        }

        public ActionResult Index()
        {
            ViewBag.Header = "Crud Demo";
            var data = ado.GetPersons();

            return View(data);
        }


      



 

  


    }
}
