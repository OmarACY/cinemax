using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinemax.Models
{
    class Empleado
    {
        public long clave_emp { get; set; }
        public string nombres { get; set; }
        public string app { get; set; }
        public string apm { get; set; }
        public DateTime fecha_nac { get; set; }
        public string colonia { get; set; }
        public string calle { get; set; }
        public int numero { get; set; }
        public string contraseña { get; set; }
    }
}
