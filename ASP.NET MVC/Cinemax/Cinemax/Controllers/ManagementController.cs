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

            estatus = false;
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.NombreUsuario, Email = model.Email, PhoneNumber = model.Telefono };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    using (Empleado emp = new Empleado())
                    {
                        estatus = emp.AgregaEmpleado(model);
                    }
                }
                else
                {
                    AddErrors(result);
                }
            }

            if (!estatus)
            {
                ModelState.AddModelError("", "Empleado no agregado!");
                return View();
            }
            else
                return RedirectToAction("Employees", "Management", new { message = "Empleado agregado!" });
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