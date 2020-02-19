﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class LosIngesEntities : DbContext
    {
        public LosIngesEntities()
            : base("name=LosIngesEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Auto> Auto { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Diagnostico> Diagnostico { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Promocion> Promocion { get; set; }
        public virtual DbSet<Puesto> Puesto { get; set; }
        public virtual DbSet<Restauracion> Restauracion { get; set; }
        public virtual DbSet<Status_Auto> Status_Auto { get; set; }
        public virtual DbSet<TipoCliente> TipoCliente { get; set; }
    
        public virtual int SP_Cliente_Altaid(string nombre, string apPat, string apMat, string telefono, string correo)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apPatParameter = apPat != null ?
                new ObjectParameter("ApPat", apPat) :
                new ObjectParameter("ApPat", typeof(string));
    
            var apMatParameter = apMat != null ?
                new ObjectParameter("ApMat", apMat) :
                new ObjectParameter("ApMat", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Cliente_Altaid", nombreParameter, apPatParameter, apMatParameter, telefonoParameter, correoParameter);
        }
    
        public virtual int SP_Cliente_Update(Nullable<int> idCliente, string nombre, string apPat, string apMat, string telefono, string correo)
        {
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apPatParameter = apPat != null ?
                new ObjectParameter("ApPat", apPat) :
                new ObjectParameter("ApPat", typeof(string));
    
            var apMatParameter = apMat != null ?
                new ObjectParameter("ApMat", apMat) :
                new ObjectParameter("ApMat", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Cliente_Update", idClienteParameter, nombreParameter, apPatParameter, apMatParameter, telefonoParameter, correoParameter);
        }
    
        public virtual int SP_Cliente_Alta(string nombre, string apPat, string apMat, string telefono, string correo)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apPatParameter = apPat != null ?
                new ObjectParameter("ApPat", apPat) :
                new ObjectParameter("ApPat", typeof(string));
    
            var apMatParameter = apMat != null ?
                new ObjectParameter("ApMat", apMat) :
                new ObjectParameter("ApMat", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Cliente_Alta", nombreParameter, apPatParameter, apMatParameter, telefonoParameter, correoParameter);
        }
    
        public virtual int Alta_Producto(string descripcion, string noParte)
        {
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var noParteParameter = noParte != null ?
                new ObjectParameter("NoParte", noParte) :
                new ObjectParameter("NoParte", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Alta_Producto", descripcionParameter, noParteParameter);
        }
    }
}
