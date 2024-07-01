using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA;
using Models;

namespace BL
{
    public class ClienteBL
    {
        private ClienteDA clientDA;

        public ClienteBL(ClienteDA clientData)
        {
            clientDA = clientData;
        }

        public ClienteBL() { }

        public IEnumerable<Productos> ObtenerTodosLosProductos()
        {
            return clientDA.ObtenerTodosLosProductos();
        }

        public Productos ObtenerProductoPorId(int id)
        {
            return clientDA.ObtenerProductoPorId(id);
        }

        public IEnumerable<Productos> BuscarProductos(string nombre, string categoria, string feature1, string feature2)
        {
            return clientDA.BuscarProductos(nombre, categoria, feature1, feature2);
        }

        public void AñadirProductoAlCarrito(int userId, int productoId, int cantidad)
        {
            clientDA.AñadirProductoAlCarrito(userId, productoId, cantidad);
        }

        public void EliminarProductoDelCarrito(int userId, int productoId)
        {
            clientDA.EliminarProductoDelCarrito(userId, productoId);
        }

        public void ActualizarCantidadProductoEnCarrito(int userId, int productoId, int cantidad)
        {
            clientDA.ActualizarCantidadProductoEnCarrito(userId, productoId, cantidad);
        }

        public IEnumerable<CarritoCompras> ObtenerCarritoDeCompras(int userId)
        {
            return clientDA.ObtenerCarritoDeCompras(userId);
        }

        public void CrearOrden(Ordenes orden)
        {
            clientDA.CrearOrden(orden);
        }

        public Ordenes ObtenerOrdenPorId(int ordenId)
        {
            return clientDA.ObtenerOrdenPorId(ordenId);
        }

        public IEnumerable<Ordenes> ObtenerOrdenesPorUsuario(int userId)
        {
            return clientDA.ObtenerOrdenesPorUsuario(userId);
        }
    }
}