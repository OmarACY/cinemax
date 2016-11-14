using Cinemax.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Cinemax.Controllers
{
    [Authorize]
    public class ManagementController : Controller
    {
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Management/Employees
        public ActionResult Employees(string message)
        {
            ViewBag.StatusMessage = message;
            return View();
        }

        // POST: Management/Employees
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Employees(EmployeesViewModel model)
        {
            bool estatus;
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            estatus = false;
            switch (model.Accion)
            {
                case "Add":
                    var user = new ApplicationUser { UserName = model.NombreUsuario, Email = model.Email, PhoneNumber = null };
                    var result = await UserManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        using (Empleado emp = new Empleado())
                        {
                            estatus = emp.AgregaEmpleado(model);
                            if (!estatus)
                            {
                                ModelState.AddModelError("", "Empleado no agregado!");
                                return View(model);
                            }
                            else
                                return RedirectToAction("Employees", "Management", new { message = "Empleado agregado!" });
                        }
                    }
                    else
                    {
                        AddErrors(result);
                        return View(model);
                    }
                case "Edit":
                    using (Empleado emp = new Empleado())
                    {
                        EmployeesViewModel empleado = emp.ObtenEmpleado(model.Clave, model.NombreUsuario);
                        string oldPassword = empleado.Password;
                        estatus = emp.EditaEmpleado(model);
                        if (!estatus)
                        {
                            ModelState.AddModelError("", "Empleado no editado!");
                            return View(model);
                        }
                        else
                        {
                            if((empleado != null) && (oldPassword != model.Password))
                            {
                                IdentityResult resultPassword = await UserManager.ChangePasswordAsync(empleado.IdUsuarioAspNet, oldPassword, model.Password);
                            }
                            return RedirectToAction("Employees", "Management", new { message = "Empleado agregado!" });
                        }
                    }
                case "Remove":
                    using (Empleado emp = new Empleado())
                    {
                        estatus = emp.EliminaEmpleado(model.Clave);
                        if (!estatus)
                        {
                            ModelState.AddModelError("", "Empleado no eliminado!");
                            return View(model);
                        }
                        else
                            return RedirectToAction("Employees", "Management", new { message = "Empleado agregado!" });
                    }
                default:
                    return View(model);
            }
        }

        [HttpPost]
        public ActionResult GetEmployees(int current, int rowCount, Dictionary<object, string> sort, string searchPhrase)
        {
            using (Empleado emp = new Empleado())
            {
                return new JsonResult()
                {
                    Data = emp.ObtenEmpleados(current, rowCount, sort, searchPhrase)
                };
            }
        }

        // GET: Management/Clients
        public ActionResult Clients(string message)
        {
            ViewBag.StatusMessage = message;
            return View();
        }

        // POST: Management/Clients
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Clients(ClientsViewModel model)
        {
            bool estatus;

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                switch (model.Accion)
                {
                    case "Add":
                        using (Membresia mem = new Membresia())
                        {
                            estatus = mem.AgregaCliente(model);
                            if (!estatus)
                            {
                                ModelState.AddModelError("", "Cliente no agregado!");
                                return View(model);
                            }
                            else
                                return RedirectToAction("Clients", "Management", new { message = "Cliente agregado!" });
                        }
                    case "Edit":
                        if (model.clave_mem != null)
                            using (Membresia mem = new Membresia())
                            {
                                estatus = mem.EditaCliente(model);
                                if (!estatus)
                                {
                                    ModelState.AddModelError("", "Cliente no editado!");
                                    return View(model);
                                }
                                else
                                    return RedirectToAction("Clients", "Management", new { message = "Cliente editado!" });
                            }
                        else
                        {
                            ModelState.AddModelError("", "Cliente no editado!");
                            return View(model);
                        }
                    case "Remove":
                        if (model.clave_mem != null)
                            using (Membresia mem = new Membresia())
                            {
                                estatus = mem.EliminaCliente(model.clave_mem.Value);
                                if (!estatus)
                                {
                                    ModelState.AddModelError("", "Cliente no eliminado!");
                                    return View(model);
                                }
                                else
                                    return RedirectToAction("Cliente", "Management", new { message = "Cliente eliminado!" });
                            }
                        else
                        {
                            ModelState.AddModelError("", "Cliente no eliminado!");
                            return View(model);
                        }
                    default:
                        return View(model);
                }
                
            }
        }
        
        /// <summary>
        /// Devuelve un conjunto de clientes. Utilizado para cragar datos en el grid de clientes
        /// </summary>
        /// <param name="current">Pagina actual del grid</param>
        /// <param name="rowCount">Numero de elementos por pagina</param>
        /// <param name="sort">Columnas y tipos de ordenamiento. Utilizado para ordenar el grid</param>
        /// <param name="searchPhrase">Frase de busqueda. Se utiliza para filtrar elementos en el grid</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetClients(int current, int rowCount, Dictionary<object, string> sort, string searchPhrase)
        {
            using (Membresia cliente = new Membresia())
            {
                return new JsonResult()
                {
                    Data = cliente.ObtenClientes(current, rowCount, sort, searchPhrase)
                };
            }
        }

        // GET: Management/MovieTeathers
        public ActionResult MovieTeathers()
        {
            return View();
        }

        // POST: Management/MovieTeathers
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MovieTeathers(MovieTeathersViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("MovieTeathers", "Management");
            }
        }
        
        /// <summary>
        /// Devuelve un conjunto de cines. Utilizado para cragar datos en el grid de cines
        /// </summary>
        /// <param name="current">Pagina actual del grid</param>
        /// <param name="rowCount">Numero de elementos por pagina</param>
        /// <param name="sort">Columnas y tipos de ordenamiento. Utilizado para ordenar el grid</param>
        /// <param name="searchPhrase">Frase de busqueda. Se utiliza para filtrar elementos en el grid</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetMovieTeathers(int current, int rowCount, Dictionary<object, string> sort, string searchPhrase)
        {
            using (Cine cine = new Cine())
            {
                return new JsonResult()
                {
                    Data = cine.ObtenCines(current, rowCount, sort, searchPhrase)
                };
            }
        }

        // GET: Management/Movies
        public ActionResult Movies(string message)
        {
            ViewBag.StatusMessage = message;
            return View();
        }

        // POST: Management/Movies
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Movies(MoviesViewModel model)
        {
            bool estatus;

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            estatus = false;
            switch (model.Accion)
            {
                case "Add":
                    using (Pelicula pel = new Pelicula())
                    {
                        estatus = pel.AgregaPelicula(model);
                        if (!estatus)
                        {
                            ModelState.AddModelError("", "Pelicula no agregada!");
                            return View(model);
                        }
                        else
                            return RedirectToAction("Pelicula", "Management", new { message = "Pelicula agregada!" });
                    }
                case "Edit":
                    if (model.clave_pel != null)
                        using (Pelicula pel = new Pelicula())
                        {
                            estatus = pel.EditaPelicula(model);
                            if (!estatus)
                            {
                                ModelState.AddModelError("", "Pelicula no editada!");
                                return View(model);
                            }
                            else
                                return RedirectToAction("Pelicula", "Management", new { message = "Pelicula editada!" });
                        }
                    else
                    {
                        ModelState.AddModelError("", "Pelicula no editado!");
                        return View(model);
                    }
                case "Remove":
                    if (model.clave_pel != null)
                        using (Pelicula pel = new Pelicula())
                        {
                            estatus = pel.EliminaPelicula(model.clave_pel.Value);
                            if (!estatus)
                            {
                                ModelState.AddModelError("", "Pelicula no eliminada!");
                                return View(model);
                            }
                            else
                                return RedirectToAction("Pelicula", "Management", new { message = "Pelicula eliminada!" });
                        }
                    else
                    {
                        ModelState.AddModelError("", "Pelicula no eliminada!");
                        return View(model);
                    }
                default:
                    return View(model);
            }
        }
        
        /// <summary>
        /// Devuelve un conjunto de peliculas. Utilizado para cragar datos en el grid de peliculas
        /// </summary>
        /// <param name="current">Pagina actual del grid</param>
        /// <param name="rowCount">Numero de elementos por pagina</param>
        /// <param name="sort">Columnas y tipos de ordenamiento. Utilizado para ordenar el grid</param>
        /// <param name="searchPhrase">Frase de busqueda. Se utiliza para filtrar elementos en el grid</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetMovies(int current, int rowCount, Dictionary<object, string> sort, string searchPhrase)
        {
            using (Pelicula pelicula = new Pelicula())
            {
                return new JsonResult()
                {
                    Data = pelicula.ObtenPeliculas(current, rowCount, sort, searchPhrase)
                };
            }
        }

        // GET: Management/FilmFunctions
        public ActionResult FilmFunctions()
        {
            return View();
        }

        // POST: Management/FilmFunctions
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FilmFunctions(FilmFunctionsViewModel model)
        {
            return View(model);
        }
        
        /// <summary>
        /// Devuelve un conjunto de funciones. Utilizado para cragar datos en el grid de funciones
        /// </summary>
        /// <param name="current">Pagina actual del grid</param>
        /// <param name="rowCount">Numero de elementos por pagina</param>
        /// <param name="sort">Columnas y tipos de ordenamiento. Utilizado para ordenar el grid</param>
        /// <param name="searchPhrase">Frase de busqueda. Se utiliza para filtrar elementos en el grid</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetFilmFunctions(int current, int rowCount, Dictionary<object, string> sort, string searchPhrase)
        {
            using (Funcion funcion = new Funcion())
            {
                return new JsonResult()
                {
                    Data = funcion.ObtenFunciones(current, rowCount, sort, searchPhrase)
                };
            }
        }

        #region Metodos auxiliares
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        #endregion
    }
}