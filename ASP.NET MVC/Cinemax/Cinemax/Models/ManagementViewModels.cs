using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;

namespace Cinemax.Models
{
    public class EmployeesViewModel
    {
        [Display(Name = "Clave de empleado")]
        public long Clave { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public string NombreUsuario { get; set; }

        [Required]
        [Display(Name = "Nombre(s)")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellido paterno")]
        public string ApPaterno { get; set; }

        [Required]
        [Display(Name = "Apellido materno")]
        public string ApMaterno { get; set; }

        [Required]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime FechaNac { get; set; }
        
        [Display(Name = "Fecha de nacimiento")]
        public String FechaNacGrid { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Número telefónico")]
        public string Telefono { get; set; }

        [Required]
        [Display(Name = "Colonia")]
        public string Colonia { get; set; }

        [Required]
        [Display(Name = "Calle")]
        public string Calle { get; set; }

        [Required]
        [Display(Name = "Número")]
        public int Numero { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} debe tener al menos {2} caracteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Acción")]
        public string Accion { get; set; }
    }

    public class GetEmployeesViewModel
    {
        public int current { get; set; }
        public int rowCount { get; set; }
        public int total { get; set; }
        public List<EmployeesViewModel> rows;

        public GetEmployeesViewModel()
        {
            rows = new List<EmployeesViewModel>();
        }
    }
}