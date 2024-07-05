using System.Collections.Generic;
using DA;
using Models;

namespace BL
{
    public class ClienteBL
    {
        private readonly ClienteDA _clientDA;

        public ClienteBL()
        {
            _clientDA = new ClienteDA();
        }

        public bool LogIn(Usuarios client)
        {
            return _clientDA.LogIn(client);
        }

        public IEnumerable<Productos> ObtenerTodosLosProductos()
        {
            return _clientDA.ObtenerTodosLosProductos();
        }

        public Productos ObtenerProductoPorId(int id)
        {
            return _clientDA.ObtenerProductoPorId(id);
        }

        public IEnumerable<Productos> BuscarProductos(string nombre, string categoria, string feature1, string feature2)
        {
            return _clientDA.BuscarProductos(nombre, categoria, feature1, feature2);
        }

        public void AñadirProductoAlCarrito(int userId, int productoId, int cantidad)
        {
            _clientDA.AñadirProductoAlCarrito(userId, productoId, cantidad);
        }

        public void EliminarProductoDelCarrito(int userId, int productoId)
        {
            _clientDA.EliminarProductoDelCarrito(userId, productoId);
        }

        public void ActualizarCantidadProductoEnCarrito(int userId, int productoId, int cantidad)
        {
            _clientDA.ActualizarCantidadProductoEnCarrito(userId, productoId, cantidad);
        }

        public IEnumerable<CarritoCompras> ObtenerCarritoDeCompras(int userId)
        {
            return _clientDA.ObtenerCarritoDeCompras(userId);
        }

        public void CrearOrden(Ordenes orden)
        {
            _clientDA.CrearOrden(orden);
        }

        public Ordenes ObtenerOrdenPorId(int ordenId)
        {
            return _clientDA.ObtenerOrdenPorId(ordenId);
        }

        public IEnumerable<Ordenes> ObtenerOrdenesPorUsuario(int userId)
        {
            return _clientDA.ObtenerOrdenesPorUsuario(userId);
        }

        public Usuarios ObtenerUsuarioPorEmail(string email)
        {
            return _clientDA.ObtenerUsuarioPorEmail(email);
        }

        public Usuarios ObtenerUsuarioPorId(int usuarioId)
        {
            return _clientDA.ObtenerUsuarioPorId(usuarioId);
        }
    }
}