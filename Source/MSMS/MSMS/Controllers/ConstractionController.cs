using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSMS.Controllers
{
    public class ConstractionController : Controller
    {
        // GET: Constraction
        public ActionResult Index()
        {
            return View();
        }

        // GET: Constraction/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Constraction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Constraction/Create
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

        // GET: Constraction/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Constraction/Edit/5
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

        // GET: Constraction/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Constraction/Delete/5
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
