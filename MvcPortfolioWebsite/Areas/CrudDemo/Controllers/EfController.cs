using AutoMapper;
using MvcPortfolioWebsite.Areas.CrudDemo.Models.EnityFramework;
using MvcPortfolioWebsite.Areas.CrudDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPortfolioWebsite.Areas.CrudDemo.Controllers
{
    public class EfController : Controller
    {
        readonly DB_9ACB28_CrudDemoEntities db;

        public EfController()
        {
            db = new DB_9ACB28_CrudDemoEntities();
            
            //fix formating from auto generated model using automapper
            Mapper.CreateMap<Custom_Person, PersonViewModel>()
                .ForMember(dest => dest.PersonId, opt => opt.MapFrom(source => source.ID));
            

        }

        //
        // GET: /CrudDemo/Ef/
        public ActionResult Index()
        {
            ViewBag.Header = "CRUD Demo";
            ViewBag.Message = TempData["message"] as string;


            var data = db.Custom_Person.Take(500).OrderByDescending(x=>x.ID);
            IEnumerable<PersonViewModel> vm = Mapper.Map<IEnumerable<Custom_Person>, IEnumerable<PersonViewModel>>(data);

            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(string firstname, string lastname)
        {
            if(string.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(lastname))
            {
                TempData["message"] = "You must enter something in both fields to create a record";

                return RedirectToAction("Index");
            }

            else
            {

                Custom_Person person = new Custom_Person
                {
                    FirstName = firstname,
                    LastName = lastname

                };

                db.Custom_Person.Add(person);
                db.SaveChanges();

                ViewBag.Message = "Employee record created!";
                return View();
            }
 

        }



        //
        // GET: /CrudDemo/Ef/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /CrudDemo/Ef/Edit/5

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
        // GET: /CrudDemo/Ef/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /CrudDemo/Ef/Delete/5

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
    }
}
