using Cinemax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinemax.Controllers
{
    [Authorize]
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index()
        {
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
    }
}