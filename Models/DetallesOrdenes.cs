//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetallesOrdenes
    {
        public int DetalleID { get; set; }
        public Nullable<int> OrdenID { get; set; }
        public Nullable<int> ProductoID { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    
        public virtual Ordenes Ordenes { get; set; }
        public virtual Productos Productos { get; set; }
    }
}