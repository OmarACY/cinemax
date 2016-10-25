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
        public bool GeneraVenta(string clave_mem, string clave_fun, string clave_emp, string numero_tar, string codigo_seg, 
            DateTime fecha_ven, List<string> butacas, bool pagoEfectivo, float subtotal, string tipoAsiento)
        {
            bool success = false;
            string query;
            long claveVenta;
  
            query = "INSERT INTO Venta.venta(total, clave_mem, clave_fun, clave_emp)" +
                "VALUES(0, " + clave_mem + ", " + clave_fun + ", " + clave_emp + ")";
            if (EjecutaSentencia(query))
            {
                claveVenta = ObtenUltimoID("Venta.venta", "clave_ven");
                if (!pagoEfectivo)
                {
                    query = "INSERT INTO Venta.cuenta(clave_ven, numero_tar, codigo_seg, fecha_ven)" +
                        "VALUES(" + claveVenta.ToString() + ", '" + numero_tar + "', '" + codigo_seg + "', '" + fecha_ven.ToShortDateString().Replace("/", "-") + "')";
                    EjecutaSentencia(query);
                }
                foreach (string butaca in butacas)
                {
                    query = "INSERT INTO Venta.detalle_venta(clave_ven, subtotal, asiento, tipo_asi)" +
                        "VALUES(" + claveVenta + ", " + subtotal + ", '" + butaca + "', '" + tipoAsiento + "')";
                    if (!EjecutaSentencia(query))
                        return false;
                }
                success = true;
            }
            return success;
        }

        public List<string> ObtenButacasOcupadas(long clave_fun)
        {
            SqlDataAdapter adaptador = new SqlDataAdapter();
            List<string> listaButacas = new List<string>();

            if (AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT detalle.asiento FROM Venta.detalle_venta as detalle" +
                    " INNER JOIN Venta.venta AS venta ON venta.clave_ven = detalle.clave_ven" +
                    " INNER JOIN Cine.funcion AS funcion ON funcion.clave_fun = venta.clave_fun" +
                    " WHERE funcion.clave_fun = " + clave_fun.ToString(), con);
                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaButacas.Add(reader.GetValue(0).ToString());
                        }
                    }
                }
                catch (Exception)
                {

                }

                CerrarConexion();

            }
            return listaButacas;
        }
    }
}
