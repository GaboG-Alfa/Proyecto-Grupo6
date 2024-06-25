using BL;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC.Controllers
{
    public class ProductosController : Controller
    {
        private ProyectoEntities db = new ProyectoEntities();
        // GET: Productos
        public ActionResult Index()
        {
            List<Productos> productos = db.Productos.ToList();
            return View(productos);
        }
        [HttpGet]
        public ActionResult BuscarFecha()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BuscarFecha(string fecha1, string fecha2)
        {
            List<Productos> productosList = new List<Productos>();
            List<Productos> productosList2 = db.Productos.ToList();
            List<Productos> productosListError = new List<Productos>();

            try
            {
                DateTime fechaInicio = DateTime.Parse(fecha1);
                DateTime fechaFin = DateTime.Parse(fecha2);

                foreach (var productos in flightsList2)
                {
                    if (productos.DepartureDate >= fechaInicio && productos.DepartureDate <= fechaFin)
                    {
                        productosList.Add(productos);
                    }
                }

                return View("Index", productosList);
            } catch (Exception error) {

                Console.WriteLine(error.Message);
               return View(productosListError);
            }
        }

        [HttpGet]
        public ActionResult BuscarDestino()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BuscarDestino(string destino)
        {
            List<Productos> productosList = new List<Productos>();
            List<Productos> productosList2 = db.Productos.ToList();

            foreach (var productos in productosList2)
            {
                if (productos.Destination == destino)
                {
                    productosList.Add(productos);
                }
            }
            TempData["ProductosList"] = productosList;
            return View("Index",productosList);
        }




    }
}