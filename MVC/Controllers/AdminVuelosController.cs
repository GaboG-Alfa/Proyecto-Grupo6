using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public class AdminVuelosController : Controller
    {
        private ProyectoEntities db = new ProyectoEntities();
        // GET: Vuelos
        public ActionResult Index()
        {
            List<Flight> flights = db.Flight.ToList();
            return View(flights);
        }

        // GET: Vuelos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vuelos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Destination,Price,DepartureDate")] Flight flights)
        {
            if (ModelState.IsValid)
            {
                db.Flight.Add(flights);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flights);
        }

        // GET: Vuelos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight fligths = db.Flight.Find(id);
            if (fligths == null)
            {
                return HttpNotFound();
            }
            return View(fligths);
        }

        // POST: Vuelos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Destination,Price,DepartureDate")] Flight flights)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flights).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flights);
        }

        // GET: Vuelos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flights = db.Flight.Find(id);
            if (flights == null)
            {
                return HttpNotFound();
            }
            return View(flights);
        }

        // GET: Vuelos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flights = db.Flight.Find(id);
            if (flights == null)
            {
                return HttpNotFound();
            }
            return View(flights);
        }

        // POST: Vuelos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flight flights = db.Flight.Find(id);
            db.Flight.Remove(flights);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}