using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaestroDetalleMVC.Models.ViewModels
{
    public class VentaViewModel
    {
        public string cliente { get; set; }

        //Lista de conceptos
        public List<Concepto> conceptos { get; set; }
    }

    public class Concepto { 
        public int cantidad { get; set; }
        public int idVenta { get; set; }
        public string nombre { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal total { get; set; }
    }
}