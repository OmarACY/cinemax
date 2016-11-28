using Cinemax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Cinemax.Controllers
{
    [Authorize]
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index(string message)
        {
            ViewBag.StatusMessage = message;
            using (Funcion funcion = new Funcion())
            using (Pelicula pelicula = new Pelicula())
            using (Membresia cliente = new Membresia())
            using (Cine cine = new Cine())
            {
                SalesViewModel sale = new SalesViewModel();
                sale.cines = cine.ObtenCines();
                sale.clientes = cliente.ObtenClientes();
                sale.peliculas = pelicula.ObtenPeliculas();
                sale.funciones = funcion.ObtenFunciones();
                return View(sale);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SalesViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (Empleado empleado = new Empleado())
                using (Venta venta = new Venta())
                {
                    model.clave_emp = empleado.ObtenEmpleado(User.Identity.GetUserName()).Clave;
                    if (venta.AgregaVenta(model))
                        return RedirectToAction("Index", new { message = "Venta realizada exitosamente!" });
                    else
                        ModelState.AddModelError("", "Venta no realizada, por favor verifique que los campos sean correctos!");
                }
            }
            using (Funcion funcion = new Funcion())
            using (Pelicula pelicula = new Pelicula())
            using (Membresia cliente = new Membresia())
            using (Cine cine = new Cine())
            {
                model.cines = cine.ObtenCines();
                model.clientes = cliente.ObtenClientes();
                model.peliculas = pelicula.ObtenPeliculas();
                model.funciones = funcion.ObtenFunciones();
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult GetPlaces(long id)
        {
            using (Funcion funcion = new Funcion())
            {
                GetPlacesViewModel model = new Models.GetPlacesViewModel()
                {
                    asientos = funcion.ObtenAsientosOcupados(id)
                };
                return PartialView(model);
            }
        }
    }
}