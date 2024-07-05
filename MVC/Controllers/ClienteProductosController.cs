using System.Linq;
using System.Web.Mvc;
using BL;
using DA;
using Models;
using Microsoft.AspNet.Identity;
using System;

namespace MVC.Controllers
{
    public class ClienteProductosController : Controller
    {
        private ClienteBL clientBL;

        public ClienteProductosController()
        {
            var dbContext = new ProyectoEntity();
            var clientDA = new ClienteDA(dbContext);
            clientBL = new ClienteBL(clientDA);
        }

        // Página principal
        public ActionResult Index(string sortOrder, string searchCategory, string searchName, string searchFeature1, string searchFeature2)
        {
            var productos = clientBL.ObtenerTodosLosProductos().AsQueryable();

            // Búsqueda por categoría
            if (!string.IsNullOrEmpty(searchCategory))
            {
                productos = productos.Where(p => p.Categorias.Nombre.Contains(searchCategory));
            }

            // Búsqueda por nombre
            if (!string.IsNullOrEmpty(searchName))
            {
                productos = productos.Where(p => p.Nombre.Contains(searchName));
            }

            // Búsqueda por características
            if (!string.IsNullOrEmpty(searchFeature1))
            {
                productos = productos.Where(p => p.Descripcion.Contains(searchFeature1));
            }
            if (!string.IsNullOrEmpty(searchFeature2))
            {
                productos = productos.Where(p => p.Descripcion.Contains(searchFeature2));
            }

            // Ordenamiento
            switch (sortOrder)
            {
                case "price_asc":
                    productos = productos.OrderBy(p => p.Precio);
                    break;
                case "price_desc":
                    productos = productos.OrderByDescending(p => p.Precio);
                    break;
                case "newest":
                    productos = productos.OrderByDescending(p => p.FechaCreacion);
                    break;
                case "popular":
                    productos = productos.OrderByDescending(p => p.Popularidad);
                    break;
                default:
                    productos = productos.OrderBy(p => p.Nombre);
                    break;
            }

            return View(productos.ToList());
        }

        public ActionResult DetallesProducto(int id)
        {
            var product = clientBL.ObtenerProductoPorId(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        // Carrito de compras
        public ActionResult Carrito()
        {
            var email = User.Identity.Name;
            if (string.IsNullOrEmpty(email))
            {
                TempData["Message"] = "No se ha ingresado";
                return RedirectToAction("Index", "Usuarios");
            }

            var user = clientBL.ObtenerUsuarioPorEmail(email);
            var cart = clientBL.ObtenerCarritoDeCompras(user.UsuarioID);
            return View(cart);
        }

        public ActionResult AddToCart(int id)
        {
            var email = User.Identity.Name;
            if (string.IsNullOrEmpty(email))
            {
                TempData["Message"] = "No se ha ingresado";
                return RedirectToAction("Index", "Usuarios");
            }

            var user = clientBL.ObtenerUsuarioPorEmail(email);
            var product = clientBL.ObtenerProductoPorId(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            clientBL.AñadirProductoAlCarrito(user.UsuarioID, id, 1);

            return RedirectToAction("Carrito");
        }

        public ActionResult RemoveFromCart(int id)
        {
            var email = User.Identity.Name;
            if (string.IsNullOrEmpty(email))
            {
                TempData["Message"] = "No se ha ingresado";
                return RedirectToAction("Index", "Usuarios");
            }

            var user = clientBL.ObtenerUsuarioPorEmail(email);
            clientBL.EliminarProductoDelCarrito(user.UsuarioID, id);

            return RedirectToAction("Carrito");
        }

        public ActionResult UpdateCart(int id, int quantity)
        {
            var email = User.Identity.Name;
            if (string.IsNullOrEmpty(email))
            {
                TempData["Message"] = "No se ha ingresado";
                return RedirectToAction("Index", "Usuarios");
            }

            var user = clientBL.ObtenerUsuarioPorEmail(email);
            clientBL.ActualizarCantidadProductoEnCarrito(user.UsuarioID, id, quantity);

            return RedirectToAction("Carrito");
        }

        // Compra
        [HttpGet]
        public ActionResult Compra()
        {
            if (!User.Identity.IsAuthenticated)
            {
                TempData["Message"] = "No se ha ingresado";
                return RedirectToAction("Index", "Usuarios");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Compra(Direcciones address)
        {
            var email = User.Identity.Name;
            if (string.IsNullOrEmpty(email))
            {
                TempData["Message"] = "No se ha ingresado";
                return RedirectToAction("Index", "Usuarios");
            }

            var user = clientBL.ObtenerUsuarioPorEmail(email);
            var cartItems = clientBL.ObtenerCarritoDeCompras(user.UsuarioID).ToList();

            if (cartItems.Count == 0)
            {
                ModelState.AddModelError("", "Tu carrito está vacío.");
                return View(address);
            }

            // Crear la orden
            var order = new Ordenes
            {
                UsuarioID = user.UsuarioID,
                FechaOrden = DateTime.Now,
                Direcciones = address,
                DetallesOrdenes = cartItems.Select(item => new DetallesOrdenes
                {
                    ProductoID = item.ProductoID,
                    Cantidad = item.Cantidad,
                    Precio = item.Productos.Precio
                }).ToList()
            };

            clientBL.CrearOrden(order);

            // Vaciar el carrito
            foreach (var item in cartItems)
            {
                if (item.ProductoID.HasValue)
                {
                    clientBL.EliminarProductoDelCarrito(user.UsuarioID, item.ProductoID.Value);
                }
            }

            return RedirectToAction("ConfirmarOrden", new { id = order.OrdenID });
        }

        public ActionResult ConfirmarOrden(int id)
        {
            var email = User.Identity.Name;
            if (string.IsNullOrEmpty(email))
            {
                TempData["Message"] = "No se ha ingresado";
                return RedirectToAction("Index", "Usuarios");
            }

            var order = clientBL.ObtenerOrdenPorId(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            return View(order);
        }

        public ActionResult HistorialOrdenes()
        {
            var email = User.Identity.Name;
            if (string.IsNullOrEmpty(email))
            {
                TempData["Message"] = "No se ha ingresado";
                return RedirectToAction("Index", "Usuarios");
            }

            var user = clientBL.ObtenerUsuarioPorEmail(email);
            var orders = clientBL.ObtenerOrdenesPorUsuario(user.UsuarioID);
            return View(orders);
        }

        // Métodos de búsqueda específicos
        public ActionResult BuscarCategoria()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscarCategoria(string categoria)
        {
            var productos = clientBL.BuscarProductos(null, categoria, null, null);
            return View("Index", productos);
        }

        public ActionResult BuscarNombre()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscarNombre(string nombre)
        {
            var productos = clientBL.BuscarProductos(nombre, null, null, null);
            return View("Index", productos);
        }

        public ActionResult BuscarCaracteristica()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscarCaracteristica(string feature1, string feature2)
        {
            var productos = clientBL.BuscarProductos(null, null, feature1, feature2);
            return View("Index", productos);
        }

        // Busqueda de ordenes
        public ActionResult BuscarOrden()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscarOrden(int numeroOrden)
        {
            var order = clientBL.ObtenerOrdenPorId(numeroOrden);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View("ConfirmarOrden", order);
        }
    }
}