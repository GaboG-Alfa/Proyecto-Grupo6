using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class AdminDA
    {
        private readonly ProyectoEntities _context;

        public AdminDA()
        {
            _context = new ProyectoEntities();
        }

        public bool LogIn(Usuarios usuario)
        {
            try
            {
                if (_context.Usuarios.Any(x => x.Email == usuario.Email && x.Contrasena == usuario.Contrasena && x.RolID == 1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                return false;
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
                throw new Exception($"Error al obtener el usuario con email {email}", ex);
            }
        }

        public List<Productos> ObtenerProductos()
        {
            try
            {
                return _context.Productos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los productos", ex);
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
                throw new Exception($"Error al obtener el producto con ID {id}", ex);
            }
        }

        public void AgregarProducto(Productos producto)
        {
            try
            {
                _context.Productos.Add(producto);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el producto", ex);
            }
        }

        public void EditarProducto(Productos producto)
        {
            try
            {
                _context.Entry(producto).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar el producto", ex);
            }
        }

        public void EliminarProducto(int id)
        {
            try
            {
                var producto = _context.Productos.Find(id);
                if (producto != null)
                {
                    _context.Productos.Remove(producto);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el producto con ID {id}", ex);
            }
        }

        public List<Categorias> ObtenerCategorias()
        {
            try
            {
                return _context.Categorias.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las categorías", ex);
            }
        }

        public Categorias ObtenerCategoriaPorId(int id)
        {
            try
            {
                return _context.Categorias.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener la categoría con ID {id}", ex);
            }
        }

        public void AgregarCategoria(Categorias categoria)
        {
            try
            {
                _context.Categorias.Add(categoria);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la categoría", ex);
            }
        }

        public void EditarCategoria(Categorias categoria)
        {
            try
            {
                _context.Entry(categoria).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar la categoría", ex);
            }
        }

        public void EliminarCategoria(int id)
        {
            try
            {
                var categoria = _context.Categorias.Find(id);
                if (categoria != null)
                {
                    _context.Categorias.Remove(categoria);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar la categoría con ID {id}", ex);
            }
        }
    }
}