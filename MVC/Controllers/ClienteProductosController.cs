using System.Linq;
using System.Web.Mvc;
using BL;
using Models;
using Microsoft.AspNet.Identity;
using System;
using DA;

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

        public ActionResult ProductDetails(int id)
        {
            var product = clientBL.ObtenerProductoPorId(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        // Carrito de compras
        public ActionResult ShoppingCart()
        {
            var userId = User.Identity.GetUserId();
            var cart = clientBL.ObtenerCarritoDeCompras(int.Parse(userId));
            return View(cart);
        }

        public ActionResult AddToCart(int id)
        {
            var userId = User.Identity.GetUserId();
            var product = clientBL.ObtenerProductoPorId(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            clientBL.AñadirProductoAlCarrito(int.Parse(userId), id, 1);

            return RedirectToAction("ShoppingCart");
        }

        public ActionResult RemoveFromCart(int id)
        {
            var userId = User.Identity.GetUserId();
            clientBL.EliminarProductoDelCarrito(int.Parse(userId), id);

            return RedirectToAction("ShoppingCart");
        }

        public ActionResult UpdateCart(int id, int quantity)
        {
            var userId = User.Identity.GetUserId();
            clientBL.ActualizarCantidadProductoEnCarrito(int.Parse(userId), id, quantity);

            return RedirectToAction("ShoppingCart");
        }

        // Compra
        [HttpGet]
        public ActionResult Checkout()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }

            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult Checkout(Direcciones address)
        {
            var userId = User.Identity.GetUserId();
            var cartItems = clientBL.ObtenerCarritoDeCompras(int.Parse(userId)).ToList();

            if (cartItems.Count == 0)
            {
                ModelState.AddModelError("", "Tu carrito está vacío.");
                return View(address);
            }

            // Crear la orden
            var order = new Ordenes
            {
                UsuarioID = int.Parse(userId),
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
                    clientBL.EliminarProductoDelCarrito(int.Parse(userId), item.ProductoID.Value);
                }
            }

            return RedirectToAction("OrderConfirmation", new { id = order.OrdenID });
        }

        public ActionResult OrderConfirmation(int id)
        {
            var order = clientBL.ObtenerOrdenPorId(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            return View(order);
        }

        public ActionResult OrderHistory()
        {
            var userId = User.Identity.GetUserId();
            var orders = clientBL.ObtenerOrdenesPorUsuario(int.Parse(userId));
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
    }
}