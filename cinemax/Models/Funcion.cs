using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinemax.Models
{
    class Funcion
    {
        public long clave_fun { get; set; }
        public long clave_pel { get; set; }
        public long clave_sal { get; set; }
        public string hora_ini { get; set; }
        public string hora_fin { get; set; }
        public DateTime fecha { get; set; }
        public string nombre_pelicula { get; set; }
    }
}
