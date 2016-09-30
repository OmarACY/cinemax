using cinemax.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cinemax
{
    class VentaConexion : Conexion
    {
        public bool GeneraVenta(string clave_mem, string clave_fun, string clave_emp, string numero_tar, string codigo_seg, DateTime fecha_ven, List<string> butacas)
        {
            bool success = false;
            string query;
  
            query = "INSERT INTO Venta.venta(total, clave_mem, clave_fun, clave_emp)" +
                "VALUES(0, " + clave_mem + ", " + clave_fun + ", " + clave_emp + ")";
            if (EjecutaSentencia(query))
            {
                query = "INSERT INTO Venta.cuenta(clave_ven, numero_tar, codigo_seg, fecha_ven)" +
                "VALUES(" + 1 + ", '" + numero_tar + "', '" + codigo_seg + "', '" + fecha_ven.ToShortDateString().Replace("/", "-") + "')";
                if (EjecutaSentencia(query))
                    success = true;
            }

            return success;
        }
    }
}
