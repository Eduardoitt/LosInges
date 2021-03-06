//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LosInges.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Factura
    {
        public int IdFactura { get; set; }
        public Nullable<int> IdAuto { get; set; }
        public Nullable<int> IdCliente { get; set; }
        public Nullable<int> IdRestauracion { get; set; }
        public Nullable<int> IdProducto { get; set; }
        public Nullable<int> IdPromocion { get; set; }
        public Nullable<int> IdEmpleado { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<System.DateTime> FechaExpedicion { get; set; }
    
        public virtual Auto Auto { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Empleado Empleado { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual Promocion Promocion { get; set; }
        public virtual Restauracion Restauracion { get; set; }
    }
}
