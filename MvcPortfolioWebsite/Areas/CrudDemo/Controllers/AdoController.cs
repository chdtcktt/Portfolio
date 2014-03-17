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
            ViewBag.Message = TempData["message"] as string;



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
        public ActionResult Edit(Person person)
        {
            try
            {
                ado.UpdatePersonRecord(person);
                TempData["message"] = "Person Updated Successful!";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "Oops there was a problem!";
                return View();
            }
        }

        //
        // GET: /CrudDemo/Default1/Delete/5

        public ActionResult Delete(int id)
        {
            ViewBag.Message = "Are you sure you want to delete this record?";
            ViewBag.Header = "Delete Person";


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
        // POST: /CrudDemo/Default1/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                ado.DeletePersonById(id);
                TempData["message"] = "Person Deleted Successful!";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "Oops there was a problem!";
                return View();
            }
        }



        public ActionResult Error()
        {
            return View();
        }

 

  


    }
}
