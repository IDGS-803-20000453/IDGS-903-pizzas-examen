using Pizzas.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pizzas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult VistaOrden()
        {
            return View();
        }
        [HttpPost]
        public ActionResult VistaOrden(Orden or)
        {
            var objPizzaPedir= new Orden();
            var pizzas= objPizzaPedir.PedirOrden(or);
            ViewBag.Pizzas = pizzas;
            return View();
        }
        
        public ActionResult VistaOrdenDetalle()
        {
            var objPizzas= new Orden();
            
            var orden = objPizzas.mostrarDetalle();
            var datos = objPizzas.mostrarDetalleDatos();

            ViewBag.Nombre = datos.GetValue(0).ToString();
            ViewBag.Direccion = datos.GetValue(1).ToString();
            ViewBag.Telefono = datos.GetValue(2).ToString();
            ViewBag.FechaCompra = datos.GetValue(3).ToString();
            ViewBag.Orden = orden;
            return View();
        }

    }
}