using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinemax.Controllers
{
    public class ManagementController : Controller
    {
        // GET: Management/Employees
        public ActionResult Employees()
        {
            return View();
        }

        // GET: Management/Clients
        public ActionResult Clients()
        {
            return View();
        }

        // GET: Management/MovieTeathers
        public ActionResult MovieTeathers()
        {
            return View();
        }

        // GET: Management/Movies
        public ActionResult Movies()
        {
            return View();
        }

        // GET: Management/FilmFunctions
        public ActionResult FilmFunctions()
        {
            return View();
        }
    }
}