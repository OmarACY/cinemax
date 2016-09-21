using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace cinemax
{
    public class Conexion
    {
        /* Cadena de Conexión Omar */
         public string datosCon = @"Data Source = OMARACY-MAC\SQLEXPRESS;" +
             "Initial Catalog = cinemax; Integrated Security = true;";

        /* Cadena de Conexión Milán */
        /*
        public string datosCon = @"Data Source=BECARIOS-PC\;Initial Catalog=cinemax;Integrated Security=True;";
         */
        public SqlConnection con;

        /// <summary>
        /// Me abre una conexion con la base de datos
        /// </summary> 
        public bool AbrirConexion() {
            bool resp = true;
            try{
                con = new SqlConnection(datosCon);
                con.Open();
            }catch (Exception){
               resp = false;
            }
            return resp;
        }
        /// <summary>
        /// Cierra la conexion de la base de datos
        /// </summary>
        public void CerrarConexion() {
            con.Close();
        }
    }
}
