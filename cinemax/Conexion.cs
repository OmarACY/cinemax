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
        /*
         public string datosCon = @"Data Source = OMARACY-MAC\SQLEXPRESS;" +
             "Initial Catalog = cinemax; Integrated Security = true;";
        */

        /* Cadena de Conexión Milán */
        
        public string datosCon = @"Data Source=BECARIOS-PC\;Initial Catalog=cinemax;Integrated Security=True;";
         
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

        protected bool Inserta(string query)
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
    }
}
