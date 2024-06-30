using Microsoft.AspNet.Identity;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ClienteProductosController : Controller
    {
        private ProyectoEntities db = new ProyectoEntities();

        // Página principal
        public ActionResult Index()
        {
            return View(db.Productos.ToList());
        }

        public ActionResult ProductDetails(int id)
        {
            var product = db.Productos.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        // Carrito de compras
        public ActionResult ShoppingCart()
        {
            var cart = Session["Cart"] as List<CarritoCompras> ?? new List<CarritoCompras>();
            return View(cart);
        }

        public ActionResult AddToCart(int id)
        {
            var product = db.Productos.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            var cart = Session["Cart"] as List<CarritoCompras> ?? new List<CarritoCompras>();

            var cartItem = cart.FirstOrDefault(c => c.Productos.ProductoID == id);
            if (cartItem == null)
            {
                cart.Add(new CarritoCompras { Productos = product, Cantidad = 1 });
            }
            else
            {
                cartItem.Cantidad++;
            }

            Session["Cart"] = cart;
            return RedirectToAction("ShoppingCart");
        }

        public ActionResult RemoveFromCart(int id)
        {
            var cart = Session["Cart"] as List<CarritoCompras> ?? new List<CarritoCompras>();
            var cartItem = cart.FirstOrDefault(c => c.Productos.ProductoID == id);
            if (cartItem != null)
            {
                cart.Remove(cartItem);
            }

            Session["Cart"] = cart;
            return RedirectToAction("ShoppingCart");
        }

        public ActionResult UpdateCart(int id, int quantity)
        {
            var cart = Session["Cart"] as List<CarritoCompras> ?? new List<CarritoCompras>();
            var cartItem = cart.FirstOrDefault(c => c.Productos.ProductoID == id);
            if (cartItem != null)
            {
                cartItem.Cantidad = quantity;
            }

            Session["Cart"] = cart;
            return RedirectToAction("ShoppingCart");
        }

        // Órdenes
        public ActionResult Orders()
        {
            var userId = User.Identity.GetUserId();
            var orders = db.Ordenes.Where(o => Convert.ToString(o.UsuarioID) == userId).ToList();
            return View(orders);
        }

        public ActionResult OrderDetails(int id)
        {
            var order = db.Ordenes.Find(id);
            if (order == null || Convert.ToString(order.UsuarioID) != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }

            return View(order);
        }

        // Gestión de cuentas
        public ActionResult Account()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Usuarios.Find(userId);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        [HttpPost]
        public ActionResult Account(Usuarios user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = db.Usuarios.Find(user.UsuarioID);
                if (existingUser != null)
                {
                    existingUser.Nombre = user.Nombre;
                    existingUser.Email = user.Email;
                    // Actualizar otros campos según sea necesario
                    db.SaveChanges();
                }

                return RedirectToAction("Account");
            }

            return View(user);
        }

        // Lista de deseos
        public ActionResult Wishlist()
        {
            var userId = User.Identity.GetUserId();
            var wishlist = db.CarritoCompras.Where(w => Convert.ToString(w.UsuarioID) == userId).ToList();
            return View(wishlist);
        }

        public ActionResult AddToWishlist(int id)
        {
            var userId = User.Identity.GetUserId();
            var product = db.Productos.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            var wishlistItem = new CarritoCompras { ProductoID = id, UsuarioID = (int?)Convert.ToInt64 (userId) };
            db.CarritoCompras.Add(wishlistItem);
            db.SaveChanges();

            return RedirectToAction("Wishlist");
        }

        public ActionResult RemoveFromWishlist(int id)
        {
            var userId = User.Identity.GetUserId();
            var wishlistItem = db.CarritoCompras.FirstOrDefault(w => w.ProductoID == id && w.UsuarioID == (int?)Convert.ToInt64(userId));
            if (wishlistItem != null)
            {
                db.CarritoCompras.Remove(wishlistItem);
                db.SaveChanges();
            }

            return RedirectToAction("Wishlist");
        }

        [HttpGet]
        public ActionResult BuscarCategoria()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscarCategoria(string categoria)
        {
            if (string.IsNullOrEmpty(categoria))
            {
                return View("Index", db.Productos.ToList());
            }

            var products = db.Productos.Where(p => p.Categorias.Nombre.Contains(categoria)).ToList();
            return View("Index", products);
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
    }
}
