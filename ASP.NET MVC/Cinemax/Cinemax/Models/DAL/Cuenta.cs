//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cinemax.Models.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cuenta
    {
        public long clave_venta { get; set; }
        public string numero_tarjeta { get; set; }
        public string codigo_seg { get; set; }
        public System.DateTime fecha_venta { get; set; }
    
        public virtual Venta Venta { get; set; }
    }
}
