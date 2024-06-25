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
    public class VuelosController : Controller
    {
        private ProyectoEntities db = new ProyectoEntities();
        // GET: Vuelos
        public ActionResult Index()
        {
            List<Flight> flights = db.Flight.ToList();
            return View(flights);
        }
        [HttpGet]
        public ActionResult BuscarFecha()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BuscarFecha(string fecha1, string fecha2)
        {
            List<Flight> flightsList = new List<Flight>();
            List<Flight> flightsList2 = db.Flight.ToList();
            List<Flight> flightListError = new List<Flight>();

            try
            {
                DateTime fechaInicio = DateTime.Parse(fecha1);
                DateTime fechaFin = DateTime.Parse(fecha2);

                foreach (var flight in flightsList2)
                {
                    if (flight.DepartureDate >= fechaInicio && flight.DepartureDate <= fechaFin)
                    {
                        flightsList.Add(flight);
                    }
                }

                return View("Index", flightsList);
            } catch (Exception error) {

                Console.WriteLine(error.Message);
               return View(flightListError);
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
            List<Flight> flightsList = new List<Flight>();
            List<Flight> flightsList2 = db.Flight.ToList();

            foreach (var flight in flightsList2)
            {
                if (flight.Destination == destino)
                {
                    flightsList.Add(flight);
                }
            }
            TempData["FlightsList"] = flightsList;
            return View("Index",flightsList);
        }




    }
}