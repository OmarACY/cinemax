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
    class EmpleadoConexion : Conexion
    {
        public List<Empleado> ObtenEmpleados()
        {
            SqlDataAdapter adaptador = new SqlDataAdapter();
            List<Empleado> listaEmpleados = new List<Empleado>();

            if (AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT * from Persona.empleado", con);

                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaEmpleados.Add(new Empleado()
                            {
                                clave_emp =  long.Parse(reader.GetValue(0).ToString()),
                                nombres = reader.GetValue(1).ToString(),
                                app = reader.GetValue(2).ToString(),
                                apm = reader.GetValue(3).ToString(),
                                fecha_nac = DateTime.Parse(reader.GetValue(4).ToString()),
                                colonia = reader.GetValue(5).ToString(),
                                calle = reader.GetValue(6).ToString(),
                                numero = int.Parse(reader.GetValue(7).ToString()),
                                contraseña = reader.GetValue(8).ToString()
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    
                }

                CerrarConexion();
                
            }
            return listaEmpleados;
        }
    }
}
