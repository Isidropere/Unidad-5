//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CatalogoProductoDesarrolloWebUASD.Models.ModelDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Venta
    {
        public int VentasID { get; set; }
        public Nullable<int> ProductoID { get; set; }
        public Nullable<int> ClienteID { get; set; }
        public string TipoVentas { get; set; }
        public string FormaPago { get; set; }
        public Nullable<decimal> ValorVenta { get; set; }
        public Nullable<int> FomadPagoID { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual FormaPago FormaPago1 { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
