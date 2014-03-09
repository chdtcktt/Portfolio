using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPortfolioWebsite.Areas.CrudDemo.Controllers
{
    public class EfController : Controller
    {
        //
        // GET: /CrudDemo/Ef/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /CrudDemo/Ef/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /CrudDemo/Ef/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CrudDemo/Ef/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
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
