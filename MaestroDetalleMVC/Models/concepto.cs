//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MaestroDetalleMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class concepto
    {
        public int id { get; set; }
        public int idVenta { get; set; }
        public int cantidad { get; set; }
        public string nombre { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal total { get; set; }
    
        public virtual venta venta { get; set; }
    }
}