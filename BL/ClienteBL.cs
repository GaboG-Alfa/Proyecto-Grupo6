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
        private ClienteDA clienteDA;

        public ClienteBL(ClienteDA clientData)
        {
            clienteDA = clientData;
        }

        public ClienteBL()
        {
            clientDA = new ClienteDA(new ProyectoEntity());
        }

        public bool logIn(Usuarios client)
        {
            bool clientExits = clientDA.logIn(client);
            if (!clientExits)
            {
                throw new Exception("Credenciales incorrectas");
            }
            return clientExits;
        }

        public bool logIn(Usuarios client)
        {
            bool clientExits = clienteDA.logIn(client);
            if (!clientExits)
            {
                throw new Exception("Incorrect credentials");
            }
            return clientExits;
        }

        public IEnumerable<Productos> ObtenerTodosLosProductos()
        {
            return clienteDA.ObtenerTodosLosProductos();
        }

        public Productos ObtenerProductoPorId(int id)
        {
            return clienteDA.ObtenerProductoPorId(id);
        }

        public IEnumerable<Productos> BuscarProductos(string nombre, string categoria, string feature1, string feature2)
        {
            return clienteDA.BuscarProductos(nombre, categoria, feature1, feature2);
        }

        public void AñadirProductoAlCarrito(int userId, int productoId, int cantidad)
        {
            clienteDA.AñadirProductoAlCarrito(userId, productoId, cantidad);
        }

        public void EliminarProductoDelCarrito(int userId, int productoId)
        {
            clienteDA.EliminarProductoDelCarrito(userId, productoId);
        }

        public void ActualizarCantidadProductoEnCarrito(int userId, int productoId, int cantidad)
        {
            clienteDA.ActualizarCantidadProductoEnCarrito(userId, productoId, cantidad);
        }

        public IEnumerable<CarritoCompras> ObtenerCarritoDeCompras(int userId)
        {
            return clienteDA.ObtenerCarritoDeCompras(userId);
        }

        public void CrearOrden(Ordenes orden)
        {
            clienteDA.CrearOrden(orden);
        }

        public Ordenes ObtenerOrdenPorId(int ordenId)
        {
            return clienteDA.ObtenerOrdenPorId(ordenId);
        }

        public IEnumerable<Ordenes> ObtenerOrdenesPorUsuario(int userId)
        {
            return clienteDA.ObtenerOrdenesPorUsuario(userId);
        }

        public Usuarios ObtenerUsuarioPorEmail(string email)
        {
            return clientDA.ObtenerUsuarioPorEmail(email);
        }
    }
}