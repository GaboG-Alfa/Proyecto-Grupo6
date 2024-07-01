using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Controllers
{
    public class ProductosController : Controller
    {
        private ProyectoEntity db = new ProyectoEntity();
        // GET: Productos
        public ActionResult Index()
        {
            List<Productos> productos = db.Productos.ToList();
            return View(productos);
        }
        [HttpGet]
        public ActionResult BuscarNombre()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BuscarNombre(string nombre)
        {
            List<Productos> productosList = new List<Productos>();
            List<Productos> productosList2 = db.Productos.ToList();

            foreach (var productos in productosList2)
            {
                if (productos.Nombre == nombre)
                {
                    productosList.Add(productos);
                }
            }
            TempData["ProductosList"] = productosList;
            return View("Index", productosList);
        }

        [HttpGet]
        public ActionResult BuscarCodigo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BuscarCodigo(string codigo)
        {
            List<Productos> productosList = new List<Productos>();
            List<Productos> productosList2 = db.Productos.ToList();

            foreach (var productos in productosList2)
            {
                if (productos.Codigo == codigo)
                {
                    productosList.Add(productos);
                }
            }
            TempData["ProductosList"] = productosList;
            return View("Index", productosList);
        }
    }
}