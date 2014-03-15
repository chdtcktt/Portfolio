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


        public ActionResult Create(string firstname, string lastname)
        {
            int r = ado.CreateNewPerson(firstname,lastname);

            if (r == 0)
                ViewBag.Message = "Oops there was a problem!";
            else
                ViewBag.Message = "Employee record created!";

            return View();

        }


        public ActionResult Edit(int id)
        {
            ViewBag.Header = "Edit Person";


            var data = ado.GetPersonById(id);

            var vm = new PersonViewModel
            {
                PersonId = data.PersonId,
                FirstName = data.FirstName,
                LastName = data.LastName
            };

            return View(vm);
        }

        //
        // POST: /CrudDemo/Default1/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /CrudDemo/Default1/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /CrudDemo/Default1/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        public ActionResult Error()
        {
            return View();
        }

 

  


    }
}
