using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class AdminCategoriasController : Controller
    {
        private ProyectoEntities db = new ProyectoEntities();

        // GET: Categorias
        public ActionResult Index()
        {
            return View(db.Categorias.ToList());
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // Post: Categorias/Create
        [HttpPost]
        public ActionResult Create(Categorias category)
        {
            if (ModelState.IsValid)
            {
                db.Categorias.Add(category);
                db.SaveChanges();
                return RedirectToAction("Categorias");
            }

            return View(category);
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(int id)
        {
            var category = db.Categorias.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categorias/Edit/5
        [HttpPost]
        public ActionResult Edit(Categorias category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Categorias");
            }
            return View(category);
        }

        // GET: Categorias/Details/5
        public ActionResult Details(int id)
        {
            var category = db.Categorias.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int id)
        {
            var category = db.Categorias.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var category = db.Categorias.Find(id);
            db.Categorias.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Categorias");
        }
    }
}