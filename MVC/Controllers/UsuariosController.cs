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
    public class UsuariosController : Controller
    {
        private AdminBL adminBL = new AdminBL();

        // GET: Usuarios
        public ActionResult Index()
        {
            return View();
        }

        // POST: Usuarios/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Nombre,Apellido,Email,Contrasena,RolID")] Usuarios
        usuarios)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    adminBL.logIn(usuarios);
                    FormsAuthentication.SetAuthCookie(usuarios.Email, true);
                    return RedirectToAction("Index", "AdminProductos");
                }
                catch (Exception error)
                {
                    ViewBag.Message = error.Message;
                    return View(usuarios);
                }
            }
            return View(usuarios);
        }

        // GET: Usuarios/LogOut
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","ClienteProductos");
        }

    }
}