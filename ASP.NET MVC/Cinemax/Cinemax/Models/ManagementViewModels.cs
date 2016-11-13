using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;

namespace Cinemax.Models
{
    public class EmployeesViewModel
    {
        public string IdUsuarioAspNet;

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

    public class ClientsViewModel
    {
        [Display(Name = "Clave")]
        public long? clave_mem { get; set; }

        [Required]
        [Display(Name = "Nombre(s)")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Apellido paterno")]
        public string app { get; set; }

        [Required]
        [Display(Name = "Apellido materno")]
        public string apm { get; set; }

        [Required]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime fecha_nac { get; set; }

        public string fecha_nacimiento_grid { get; set; }

        [Required]
        [Display(Name = "Colonia")]
        public string colonia { get; set; }

        [Required]
        [Display(Name = "Calle")]
        public string calle { get; set; }

        [Required]
        [Display(Name = "Número")]
        public int numero { get; set; }

        [Required]
        [Display(Name = "Tipo de membresía")]
        public string tipo { get; set; }

        [Required]
        [Display(Name = "Puntos")]
        public int puntos { get; set; }
    }

    public class GetClientsViewModel
    {
        public int current { get; set; }
        public int rowCount { get; set; }
        public int total { get; set; }
        public List<ClientsViewModel> rows;

        public GetClientsViewModel()
        {
            rows = new List<ClientsViewModel>();
        }
    }

    public class FilmFunctionsViewModel
    {
        [Display(Name = "Clave")]
        public long clave_fun { get; set; }

        [Required]
        [Display(Name = "Pelicula")]
        public long clave_pel { get; set; }

        [Required]
        [Display(Name = "Sala")]
        public long clave_sal { get; set; }

        [Required]
        [Display(Name = "Hora inicio")]
        public DateTime hora_ini { get; set; }

        [Required]
        [Display(Name = "Hora fin")]
        public DateTime hora_fin { get; set; }

        [Required]
        [Display(Name = "Fecha")]
        public DateTime fecha { get; set; }
        
        [Display(Name = "Cupo")]
        public int cupo { get; set; }
    }

    public class GetFilmFunctionsViewModel
    {
        public int current { get; set; }
        public int rowCount { get; set; }
        public int total { get; set; }
        public List<FilmFunctionsViewModel> rows;

        public GetFilmFunctionsViewModel()
        {
            rows = new List<FilmFunctionsViewModel>();
        }
    }

    public class MoviesViewModel
    {
        [Display(Name = "Clave")]
        public long? clave_pel { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Director")]
        public string director { get; set; }

        [Required]
        [Display(Name = "Sinopsis")]
        public string sinopsis { get; set; }

        [Required]
        [Display(Name = "Clasificación")]
        public string clasificacion { get; set; }

        [Required]
        [Display(Name = "Género")]
        public string genero { get; set; }
    }

    public class GetMoviesViewModel
    {
        public int current { get; set; }
        public int rowCount { get; set; }
        public int total { get; set; }
        public List<MoviesViewModel> rows;

        public GetMoviesViewModel()
        {
            rows = new List<MoviesViewModel>();
        }
    }

    public class MovieTeathersViewModel
    {
        [Display(Name = "Clave")]
        public long? clave_cin { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

            
        [Display(Name = "Teléfono")]
        public string telefono { get; set; }

        [Required]
        [Display(Name = "Número de salas")]
        public int num_salas { get; set; }

        [Required]
        [Display(Name = "Colonia")]
        public string colonia { get; set; }

        [Required]
        [Display(Name = "Calle")]
        public string calle { get; set; }

        [Required]
        [Display(Name = "Número")]
        public int numero { get; set; }
    }

    public class GetMovieTeathersViewModel
    {
        public int current { get; set; }
        public int rowCount { get; set; }
        public int total { get; set; }
        public List<MovieTeathersViewModel> rows;

        public GetMovieTeathersViewModel()
        {
            rows = new List<MovieTeathersViewModel>();
        }
    }
}