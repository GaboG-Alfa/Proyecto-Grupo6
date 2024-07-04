using Models;
using System.Linq;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class AdminCategoriasController : Controller
    {
        private ProyectoEntity db = new ProyectoEntity();

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

        // POST: Categorias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categorias category)
        {
            if (ModelState.IsValid)
            {
                db.Categorias.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categorias/Edit
        public ActionResult Edit(int id)
        {
            var category = db.Categorias.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categorias/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categorias category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categorias/Details
        public ActionResult Details(int id)
        {
            var category = db.Categorias.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categorias/Delete
        public ActionResult Delete(int id)
        {
            var category = db.Categorias.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categorias/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var category = db.Categorias.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            db.Categorias.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
