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
    class ClienteConexion : Conexion
    {
        public List<Cliente> ObtenClientes()
        {
            SqlDataAdapter adaptador = new SqlDataAdapter();
            List<Cliente> listaClientes = new List<Cliente>();

            if (AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT * from Persona.membresia", con);

                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaClientes.Add(new Cliente()
                            {
                                clave_mem =  long.Parse(reader.GetValue(0).ToString()),
                                nombres = reader.GetValue(1).ToString(),
                                app = reader.GetValue(2).ToString(),
                                apm = reader.GetValue(3).ToString(),
                                fecha_nac = DateTime.Parse(reader.GetValue(4).ToString()),
                                colonia = reader.GetValue(5).ToString(),
                                calle = reader.GetValue(6).ToString(),
                                numero = int.Parse(reader.GetValue(7).ToString()),
                                tipo = reader.GetValue(8).ToString(),
                                puntos = int.Parse(reader.GetValue(9).ToString())
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    
                }

                CerrarConexion();
                
            }
            return listaClientes;
        }
    }
}
