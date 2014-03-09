using MvcPortfolioWebsite.Areas.CrudDemo.Models.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MvcPortfolioWebsite.Areas.CrudDemo.ViewModels;

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
            Mapper.CreateMap<Person,PersonViewModel>();
              
        }

        public ActionResult Index()
        {
            ViewBag.Header = "CRUD Demo";


            var data = ado.GetPersons();
            IEnumerable<PersonViewModel> vm = Mapper.Map<IEnumerable<Person>, IEnumerable<PersonViewModel>>(data);

            return View(vm);
        }


      



 

  


    }
}
