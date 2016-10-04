using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinemax.Models
{
    class Cliente
    {
        public long clave_mem { get; set; }
        public string nombres { get; set; }
        public string app { get; set; }
        public string apm { get; set; }
        public string nombreCompleto { get { return nombres + " " + app + " " + apm; } }
        public DateTime fecha_nac { get; set; }
        public string colonia { get; set; }
        public string calle { get; set; }
        public int numero { get; set; }
        public string tipo { get; set; }
        public int puntos { get; set; }
    }
}
