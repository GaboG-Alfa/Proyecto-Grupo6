using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DA
{
    public class ClienteDA
    {
        private ProyectoEntity db;

        public ClienteDA(ProyectoEntity context)
        {
            db = context;
        }

        public bool logIn(Usuarios usuario)
        {
            try
            {
                return db.Usuarios.FirstOrDefault(x => x.Email == usuario.Email &&
                        x.Contrasena == usuario.Contrasena && x.RolID == 3) != null;
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                return false;
            }
        }

        public IEnumerable<Productos> ObtenerTodosLosProductos()
        {
            return db.Productos.ToList();
        }

        public Productos ObtenerProductoPorId(int id)
        {
            return db.Productos.Find(id);
        }

        public IEnumerable<Productos> BuscarProductos(string nombre, string categoria, string feature1, string feature2)
        {
            var query = db.Productos.AsQueryable();

            if (!string.IsNullOrEmpty(nombre))
                query = query.Where(p => p.Nombre.Contains(nombre));

            if (!string.IsNullOrEmpty(categoria))
                query = query.Where(p => p.Categorias.Nombre.Contains(categoria));

            if (!string.IsNullOrEmpty(feature1))
                query = query.Where(p => p.Descripcion.Contains(feature1));

            if (!string.IsNullOrEmpty(feature2))
                query = query.Where(p => p.Descripcion.Contains(feature2));

            return query.ToList();
        }

        public void AñadirProductoAlCarrito(int userId, int productoId, int cantidad)
        {
            var carritoItem = db.CarritoCompras
                .FirstOrDefault(c => c.UsuarioID == userId && c.ProductoID == productoId);

            if (carritoItem == null)
            {
                carritoItem = new CarritoCompras
                {
                    UsuarioID = userId,
                    ProductoID = productoId,
                    Cantidad = cantidad
                };
                db.CarritoCompras.Add(carritoItem);
            }
            else
            {
                carritoItem.Cantidad += cantidad;
            }

            db.SaveChanges();
        }

        public void EliminarProductoDelCarrito(int userId, int productoId)
        {
            var carritoItem = db.CarritoCompras
                .FirstOrDefault(c => c.UsuarioID == userId && c.ProductoID == productoId);

            if (carritoItem != null)
            {
                db.CarritoCompras.Remove(carritoItem);
                db.SaveChanges();
            }
        }

        public void ActualizarCantidadProductoEnCarrito(int userId, int productoId, int cantidad)
        {
            var carritoItem = db.CarritoCompras
                .FirstOrDefault(c => c.UsuarioID == userId && c.ProductoID == productoId);

            if (carritoItem != null)
            {
                carritoItem.Cantidad = cantidad;
                db.SaveChanges();
            }
        }

        public IEnumerable<CarritoCompras> ObtenerCarritoDeCompras(int userId)
        {
            return db.CarritoCompras
                .Where(c => c.UsuarioID == userId)
                .Include(c => c.Productos)
                .ToList();
        }

        public void CrearOrden(Ordenes orden)
        {
            db.Ordenes.Add(orden);
            db.SaveChanges();
        }

        public Ordenes ObtenerOrdenPorId(int ordenId)
        {
            return db.Ordenes
                .Include(o => o.DetallesOrdenes.Select(d => d.Productos))
                .Include(o => o.Usuarios)
                .Include(o => o.Direcciones)
                .FirstOrDefault(o => o.OrdenID == ordenId);
        }

        public IEnumerable<Ordenes> ObtenerOrdenesPorUsuario(int userId)
        {
            return db.Ordenes
                .Where(o => o.UsuarioID == userId)
                .OrderByDescending(o => o.FechaOrden)
                .ToList();
        }

        public Usuarios ObtenerUsuarioPorEmail(string email)
        {
            return db.Usuarios.FirstOrDefault(u => u.Email == email);
        }
    }
}