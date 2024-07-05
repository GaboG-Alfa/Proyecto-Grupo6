using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Models;

namespace DA
{
    public class ClienteDA
    {
        private readonly ProyectoEntities _context;

        public ClienteDA()
        {
            _context = new ProyectoEntities();
        }

        public bool LogIn(Usuarios usuario)
        {
            try
            {
                return _context.Usuarios.Any(x => x.Email == usuario.Email && x.Contrasena == usuario.Contrasena && x.RolID == 3);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                return false;
            }
        }

        public IEnumerable<Productos> ObtenerTodosLosProductos()
        {
            try
            {
                return _context.Productos.ToList();
            }
            catch (Exception ex)
            {
                // Manejo de excepción, podría ser logging, rethrow, etc.
                throw new Exception("Error al obtener todos los productos", ex);
            }
        }

        public Productos ObtenerProductoPorId(int id)
        {
            try
            {
                return _context.Productos.Find(id);
            }
            catch (Exception ex)
            {
                // Manejo de excepción, podría ser logging, rethrow, etc.
                throw new Exception($"Error al obtener el producto con ID {id}", ex);
            }
        }

        public IEnumerable<Productos> BuscarProductos(string nombre, string categoria, string feature1, string feature2)
        {
            try
            {
                var query = _context.Productos.AsQueryable();

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
            catch (Exception ex)
            {
                // Manejo de excepción, podría ser logging, rethrow, etc.
                throw new Exception("Error al buscar productos", ex);
            }
        }

        public void AñadirProductoAlCarrito(int userId, int productoId, int cantidad)
        {
            try
            {
                var carritoItem = _context.CarritoCompras
                    .FirstOrDefault(c => c.UsuarioID == userId && c.ProductoID == productoId);

                if (carritoItem == null)
                {
                    carritoItem = new CarritoCompras
                    {
                        UsuarioID = userId,
                        ProductoID = productoId,
                        Cantidad = cantidad
                    };
                    _context.CarritoCompras.Add(carritoItem);
                }
                else
                {
                    carritoItem.Cantidad += cantidad;
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Manejo de excepción, podría ser logging, rethrow, etc.
                throw new Exception("Error al añadir producto al carrito", ex);
            }
        }

        public void EliminarProductoDelCarrito(int userId, int productoId)
        {
            try
            {
                var carritoItem = _context.CarritoCompras
                    .FirstOrDefault(c => c.UsuarioID == userId && c.ProductoID == productoId);

                if (carritoItem != null)
                {
                    _context.CarritoCompras.Remove(carritoItem);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepción, podría ser logging, rethrow, etc.
                throw new Exception("Error al eliminar producto del carrito", ex);
            }
        }

        public void ActualizarCantidadProductoEnCarrito(int userId, int productoId, int cantidad)
        {
            try
            {
                var carritoItem = _context.CarritoCompras
                    .FirstOrDefault(c => c.UsuarioID == userId && c.ProductoID == productoId);

                if (carritoItem != null)
                {
                    carritoItem.Cantidad = cantidad;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepción, podría ser logging, rethrow, etc.
                throw new Exception("Error al actualizar cantidad de producto en el carrito", ex);
            }
        }

        public IEnumerable<CarritoCompras> ObtenerCarritoDeCompras(int userId)
        {
            try
            {
                return _context.CarritoCompras
                    .Where(c => c.UsuarioID == userId)
                    .Include(c => c.Productos)
                    .ToList();
            }
            catch (Exception ex)
            {
                // Manejo de excepción, podría ser logging, rethrow, etc.
                throw new Exception($"Error al obtener el carrito de compras para el usuario con ID {userId}", ex);
            }
        }

        public void CrearOrden(Ordenes orden)
        {
            try
            {
                _context.Ordenes.Add(orden);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Manejo de excepción, podría ser logging, rethrow, etc.
                throw new Exception("Error al crear la orden", ex);
            }
        }

        public Ordenes ObtenerOrdenPorId(int ordenId)
        {
            try
            {
                return _context.Ordenes
                    .Include(o => o.DetallesOrdenes.Select(d => d.Productos))
                    .Include(o => o.Usuarios)
                    .Include(o => o.Direcciones)
                    .FirstOrDefault(o => o.OrdenID == ordenId);
            }
            catch (Exception ex)
            {
                // Manejo de excepción, podría ser logging, rethrow, etc.
                throw new Exception($"Error al obtener la orden con ID {ordenId}", ex);
            }
        }

        public IEnumerable<Ordenes> ObtenerOrdenesPorUsuario(int userId)
        {
            try
            {
                return _context.Ordenes
                    .Where(o => o.UsuarioID == userId)
                    .OrderByDescending(o => o.FechaOrden)
                    .ToList();
            }
            catch (Exception ex)
            {
                // Manejo de excepción, podría ser logging, rethrow, etc.
                throw new Exception($"Error al obtener las órdenes para el usuario con ID {userId}", ex);
            }
        }

        public Usuarios ObtenerUsuarioPorEmail(string email)
        {
            try
            {
                return _context.Usuarios.FirstOrDefault(u => u.Email == email);
            }
            catch (Exception ex)
            {
                // Manejo de excepción, podría ser logging, rethrow, etc.
                throw new Exception($"Error al obtener el usuario con email {email}", ex);
            }
        }

        public Usuarios ObtenerUsuarioPorId(int usuarioId)
        {
            try
            {
                return _context.Usuarios.FirstOrDefault(u => u.UsuarioID == usuarioId);
            }
            catch (Exception ex)
            {
                // Manejo de excepción, podría ser logging, rethrow, etc.
                throw new Exception($"Error al obtener el usuario con ID {usuarioId}", ex);
            }
        }
    }
}