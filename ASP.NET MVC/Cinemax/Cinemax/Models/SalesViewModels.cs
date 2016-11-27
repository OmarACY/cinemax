using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinemax.Models
{
    public class SalesViewModel
    {
        [Display(Name = "ID de venta")]
        public long? clave_venta { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        public long clave_mem { get; set; }

        [Required]
        [Display(Name = "Sucursal")]
        public long clave_cin { get; set; }

        [Required]
        [Display(Name = "Película")]
        public long clave_pel { get; set; }

        [Required]
        [Display(Name = "Sala")]
        public long clave_sal { get; set; }

        [Required]
        [Display(Name = "Función")]
        public long clave_fun { get; set; }

        [Required]
        [Display(Name = "Empleado")]
        public long clave_emp { get; set; }

        [Required]
        [Display(Name = "Tipo de pago")]
        public string tipo_pago { get; set; }
        
        [Display(Name = "Número de tarjeta")]
        public string num_tarjeta { get; set; }
        
        [Display(Name = "Código de seguridad")]
        public string cod_seguridad { get; set; }
        
        [Display(Name = "Mes de vencimiento")]
        public string mes_ven { get; set; }
        
        [Display(Name = "Mes de vencimiento")]
        public string anio_ven { get; set; }

        [Required]
        [Display(Name = "Total $(MXN)")]
        public decimal total { get; set; }

        [Display(Name = "Sucursal")]
        public List<SelectMovieTeather> cines { get; set; }

        [Display(Name = "Cliente")]
        public List<SelectClient> clientes { get; set; }

        [Display(Name = "Pelicula")]
        public List<SelectMovie> peliculas { get; set; }

        [Display(Name = "Funcion")]
        public List<SelectFunction> funciones { get; set; }

        [Display(Name = "Asientos")]
        public List<Place> asientos { get; set; }
    }

    public class SelectClient
    {
        public long clave_mem { get; set; }
        public string nombre { get; set; }
    }

    public class SelectFunction
    { 
        public long clave_cin { get; set; }
        public long clave_sal { get; set; }
        public long clave_fun { get; set; }
        public long clave_pel { get; set; }
        public string hora { get; set; }
    }

    public class Place
    {
        public string Name { get; set; } 
    }

    public class GetPlacesViewModel
    {
        public List<Place> asientos { get; set; }
    }
}