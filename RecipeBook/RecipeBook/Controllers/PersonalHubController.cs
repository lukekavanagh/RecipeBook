using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecipeBook.Models;

namespace RecipeBook.Controllers
{
    public class PersonalHubController : Controller
    {
        // GET: PersonalHub
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ApplicationDbContext Db = new ApplicationDbContext();

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // GET: PersonalHub/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonalHub/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonalHub/Create
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

        // GET: PersonalHub/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonalHub/Edit/5
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

        // GET: PersonalHub/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonalHub/Delete/5
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
