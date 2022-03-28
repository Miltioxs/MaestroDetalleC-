using MaestroDetalleMVC.Models;
using MaestroDetalleMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaestroDetalleMVC.Controllers
{
    public class MaestroDetalleController : Controller
    {
        // GET: MaestroDetalle
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(VentaViewModel model) 
        {
            try
            {
                //El using que esta aquí sirve para crear una conexion y al terminar luego de las llave la elimina.
                using (MaestroDetalleMVCEntities db = new MaestroDetalleMVCEntities()) 
                {
                    //Creo mi objeto oVenta de mi modelo que esta en ViewMoldes=>Venta
                    venta oVenta = new venta();
                    //Calculo mi campo fecha con la función DateTime.Now, para tomar la fecha del momento(ahora).
                    oVenta.fecha = DateTime.Now;
                    //Recibo desde la vista el cliente y se lo asigno a mi objeto oVenta.
                    oVenta.cliente = model.cliente;
                    //Lo agregamos a la base de datos con db.venta.Add y le paso mi objeto de venta.
                    db.venta.Add(oVenta);
                    //Este sirve para guardar mi usuario.
                    db.SaveChanges();//Si no requiero tomar el id de la venta, no es necesario que haga esto SaveChanges()

                    //Recorrer los conceptos que estan llegando desde mi vista utilizando input hidden, osea Cantidad, PrecioUnitario, Nombre 
                    //Tambien calculo el total y guardo el id de la venta en idVenta.
                    foreach (var oC in model.conceptos) 
                    {
                        //Creo mi objeto oConcepto, oC tienen que ir los nombre igual a los del modelo ejemplo: oC.cantidad.
                        concepto oConcepto = new concepto();
                        oConcepto.cantidad = oC.cantidad;
                        oConcepto.nombre = oC.nombre;
                        oConcepto.precioUnitario = oC.precioUnitario;
                        oConcepto.total = oC.cantidad * oC.precioUnitario;
                        oConcepto.idVenta = oVenta.id;
                        //Lo agregamos a la base de datos con db.concepto.Add y le paso mi objeto de oConcepto.
                        db.concepto.Add(oConcepto);

                    }
                    //Guardo los cambios a mi base de datos.
                    db.SaveChanges();
                }
                ViewBag.Message = "Registro Insertado";
                //Redirecciono a mi vista index. si lo dejo como return view busca una vista como el nombre de mi accion y si no existe da error.
                //Quite el redirectToAction y cambie el nombre mi método Index a Add.
                    return View();
            }
            catch (Exception e)
            {

                return View(model);
            }
        }
    }
}