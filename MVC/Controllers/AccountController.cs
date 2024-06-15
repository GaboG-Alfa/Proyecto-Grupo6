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
    public class AccountController : Controller
    {
        private AccountBL accountBL = new AccountBL();

        // GET: Usuarios
        public ActionResult Index()
        {
            return View();
        }

        // POST: Account/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Email,AccountPassword")] Account
        account)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    accountBL.logIn(account);
                    FormsAuthentication.SetAuthCookie(account.Email, true);
                    return RedirectToAction("Index", "AdminVuelos");
                }
                catch (Exception error)
                {
                    ViewBag.Message = error.Message;
                    return View(account);
                }
            }
            return View(account);
        }

        // GET: Account/LogOut
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Vuelos");
        }

    }
}