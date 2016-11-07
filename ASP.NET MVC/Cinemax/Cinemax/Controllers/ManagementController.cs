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

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}