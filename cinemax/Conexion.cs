using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace cinemax
{
    public class Conexion
    {
        /* Cadena de Conexión Omar */
        // public string datosCon = @"Data Source = OMARACY-MAC\SQLEXPRESS; Initial Catalog = cinemax; Integrated Security = true;";

        /* Cadena de Conexión Milán */
        // public string datosCon = @"Data Source=BECARIOS-PC\;Initial Catalog=cinemax;Integrated Security=True;";
         

        /* Cadena de Conexión Milán (Laptop) */
         public string datosCon = @"Data Source=MILAN-PC\;Initial Catalog=cinemax;Integrated Security=True;";

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

        protected bool EjecutaSentencia(string query)
        {
            if (AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    return false;
                }

                CerrarConexion();
                return true;
            }
            else
            {
                return false;
            }
        }

        protected DataTable ObtenDatosGrid(string query)
        {
            SqlDataAdapter adaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            if (AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    adaptador.SelectCommand = cmd;
                    adaptador.Fill(ds);
                    adaptador.Dispose();
                    cmd.Dispose();
                }
                catch (Exception)
                {
                    return null;
                }
                CerrarConexion();
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        protected int ObtenUltimoID(string tabla, string nombreId)
        {
            SqlDataAdapter adaptador = new SqlDataAdapter();
            int id;

            if (AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT top 1 " + nombreId + " from " + tabla + " order by " + nombreId + " desc", con);

                try
                {
                    id = int.Parse(cmd.ExecuteScalar().ToString());
                }
                catch (Exception)
                {
                    return -1;
                }

                CerrarConexion();
                return id;
            }
            else
            {
                return -1;
            }
        }
    }
}
