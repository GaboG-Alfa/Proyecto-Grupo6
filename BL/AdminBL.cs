using DA;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AdminBL
    {
        private readonly AdminDA _adminDA;

        public AdminBL()
        {
            _adminDA = new AdminDA();
        }

        public bool LogIn(Usuarios admin)
        {
            bool adminExists = _adminDA.LogIn(admin);
            return adminExists;
        }
        public Usuarios ObtenerUsuarioPorEmail(string email)
        {
            return _adminDA.ObtenerUsuarioPorEmail(email);
        }

        public List<Productos> ObtenerProductos()
        {
            return _adminDA.ObtenerProductos();
        }

        public Productos ObtenerProductoPorId(int id)
        {
            return _adminDA.ObtenerProductoPorId(id);
        }

        public void AgregarProducto(Productos producto)
        {
            _adminDA.AgregarProducto(producto);
        }

        public void EditarProducto(Productos producto)
        {
            _adminDA.EditarProducto(producto);
        }

        public void EliminarProducto(int id)
        {
            _adminDA.EliminarProducto(id);
        }

        public List<Categorias> ObtenerCategorias()
        {
            return _adminDA.ObtenerCategorias();
        }

        public Categorias ObtenerCategoriaPorId(int id)
        {
            return _adminDA.ObtenerCategoriaPorId(id);
        }

        public void AgregarCategoria(Categorias categoria)
        {
            _adminDA.AgregarCategoria(categoria);
        }

        public void EditarCategoria(Categorias categoria)
        {
            _adminDA.EditarCategoria(categoria);
        }

        public void EliminarCategoria(int id)
        {
            _adminDA.EliminarCategoria(id);
        }
    }
}