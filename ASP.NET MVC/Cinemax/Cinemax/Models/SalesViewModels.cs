using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinemax.Models
{
    public class SalesViewModel
    {
        [Required]
        [Display(Name = "ID de venta")]
        public long clave_venta { get; set; }

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
        [Display(Name = "Hora")]
        public string hora { get; set; }

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

        [Required]
        [Display(Name = "Número de tarjeta")]
        public string num_tarjeta { get; set; }

        [Required]
        [Display(Name = "Código de seguridad")]
        public string cod_seguridad { get; set; }

        [Required]
        [Display(Name = "Mes de vencimiento")]
        public string mes_ven { get; set; }

        [Required]
        [Display(Name = "Mes de vencimiento")]
        public string anio_ven { get; set; }

        [Required]
        [Display(Name = "Total $(MXN)")]
        public decimal total { get; set; }

        [Required]
        [Display(Name = "Acción")]
        public string Accion { get; set; }


        [Display(Name = "Sucursal")]
        public List<SelectMovieTeather> cines;

        [Display(Name = "Cliente")]
        public List<SelectClient> clientes;

        [Display(Name = "Pelicula")]
        public List<SelectMovie> peliculas;

        [Display(Name = "Funcion")]
        public List<SelectFunction> funciones;
    }

    public class SelectClient
    {
        public long clave_mem;
        public string nombre;
    }

    public class SelectFunction
    { 
        public long clave_cin;
        public long clave_sal;
        public long clave_fun;
        public long clave_pel;
        public string hora;
    }
}