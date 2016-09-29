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
    class FuncionConexion : Conexion
    {
        public List<Funcion> ObtenPeliculas(long clave_cin)
        {
            SqlDataAdapter adaptador = new SqlDataAdapter();
            List<Funcion> listaFunciones = new List<Funcion>();

            if (AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT distinct pelicula.nombre " +
                    "from Cine.funcion as funcion " + 
                    "INNER JOIN Cine.sala as sala on sala.clave_sal = funcion.clave_sal "+
                    "INNER JOIN Cine.cine as cine on cine.clave_cin = sala.clave_cin " + 
                    "INNER JOIN Cine.pelicula as pelicula on pelicula.clave_pel = funcion.clave_pel " +
                    "WHERE cine.clave_cin = " + clave_cin.ToString(), con);

                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaFunciones.Add(new Funcion()
                            {
                                nombre_pelicula = reader.GetValue(0).ToString()
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    
                }

                CerrarConexion();
                
            }
            return listaFunciones;
        }

        public List<Funcion> ObtenFunciones(long clave_cin, string nombre_pelicula)
        {
            SqlDataAdapter adaptador = new SqlDataAdapter();
            List<Funcion> listaFunciones = new List<Funcion>();

            if (AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT funcion.* " +
                    "from Cine.funcion as funcion " +
                    "INNER JOIN Cine.sala as sala on sala.clave_sal = funcion.clave_sal " +
                    "INNER JOIN Cine.cine as cine on cine.clave_cin = sala.clave_cin " +
                    "INNER JOIN Cine.pelicula as pelicula on pelicula.clave_pel = funcion.clave_pel " +
                    "WHERE cine.clave_cin = " + clave_cin.ToString() +
                    " AND pelicula.nombre = '" + nombre_pelicula + "'", con);

                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaFunciones.Add(new Funcion()
                            {
                                clave_fun = long.Parse(reader.GetValue(0).ToString()),
                                clave_pel = long.Parse(reader.GetValue(1).ToString()),
                                clave_sal = long.Parse(reader.GetValue(2).ToString()),
                                hora_ini = reader.GetValue(3).ToString(),
                                hora_fin = reader.GetValue(4).ToString(),
                            });
                        }
                    }
                }
                catch (Exception)
                {

                }

                CerrarConexion();

            }
            return listaFunciones;
        }
    }
}
