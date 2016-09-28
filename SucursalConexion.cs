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
    class SucursalConexion : Conexion
    {
        public bool InsertaSucursal(string nombreSucursal, string numeroSalas, string colonia, string calle, string numero, string telefono)
        {
            string query2, query1;
            
            query1 = "INSERT INTO Cine.cine(nombre, num_salas, colonia, calle, numero)" +
                "VALUES('" + nombreSucursal + "'," + numeroSalas + ",'" + colonia + "','" +
                calle + "'," + numero + ")";
            if (EjecutaSentencia(query1))
            {
                query2 = "INSERT INTO Cine.tel_cin(clave_cin, telefono)" +
                "VALUES(" + ObtenUltimoID("cine", "clave_cin") + "," + telefono + ")";
                EjecutaSentencia(query2);
                return true;
            }
            else
                return false;
        }

        public bool ActualizaSucursal(string claveCine, string nombreSucursal, string numeroSalas, string colonia, string calle, string numero, string telefono)
        {
            string query2, query1;

            query1 = "UPDATE Cine.cine SET " + 
                " nombre = '" + nombreSucursal + "'" +
                ", num_salas = " + numeroSalas +
                ", colonia = '" + colonia + "'" +
                ", calle = '" + calle + "'" +
                ", numero = '" + numero + "'" +
                " WHERE clave_cin = '" + claveCine + "';";
            if (EjecutaSentencia(query1))
            {
                if ((telefono == string.Empty) || Regex.IsMatch(telefono, @"^(\s)+$"))
                {
                    query2 = "DELETE FROM Cine.tel_cin " +
                    " WHERE clave_cin = '" + claveCine + "';";
                    EjecutaSentencia(query2);
                }
                else
                {
                    if (ObtenTelefonoSucursal(claveCine) != string.Empty)
                        query2 = "UPDATE Cine.tel_cin SET " +
                        " telefono = '" + telefono + "'" +
                        " WHERE clave_cin = '" + claveCine + "';";
                    else
                        query2 = "INSERT INTO Cine.tel_cin(clave_cin, telefono)" +
                        "VALUES(" + claveCine + "," + telefono + ")";

                    EjecutaSentencia(query2);
                }
                return true;
            }
            else
                return false;
        }

        public bool EliminaSucursal(string claveCine)
        {
            string query2, query1;

            query1 = "delete from Cine.sala where clave_cin = " + claveCine;
            query2 = "delete from Cine.tel_cin where clave_cin = " + claveCine;
            if (EjecutaSentencia(query1) && EjecutaSentencia(query2))
            {
                query1 = "delete from Cine.cine where clave_cin = " + claveCine;
                if (EjecutaSentencia(query1))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public bool CargaDatosGrid(DataGridView dataGrid)
        {
            string query = "select cine.*, tel.telefono from Cine.cine as cine left join Cine.tel_cin as tel on tel.clave_cin = cine.clave_cin";
            DataTable tabla;

            tabla = ObtenDatosGrid(query);
            if (tabla != null)
            {
                dataGrid.DataSource = tabla;
                dataGrid.ClearSelection();
                return true;
            }
            else
                return false;
        }

        private string ObtenTelefonoSucursal(string claveSucursal)
        {
            SqlDataAdapter adaptador = new SqlDataAdapter();
            string telefono;

            if (AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT telefono from Cine.tel_cin where clave_cin = '" + claveSucursal + "'", con);

                try
                {
                    telefono = cmd.ExecuteScalar().ToString();
                }
                catch (Exception)
                {
                    return string.Empty;
                }

                CerrarConexion();
                return telefono;
            }
            else
            {
                return string.Empty;
            }
        }

        public List<Sala> ObtenSalas(string claveSucursal)
        {
            SqlDataAdapter adaptador = new SqlDataAdapter();
            List<Sala> listaSalas = new List<Sala>();

            if (AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT * from Cine.sala where clave_cin = " + claveSucursal, con);

                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaSalas.Add(new Sala()
                            {
                                clave_sal = int.Parse(reader.GetValue(0).ToString()),
                                cupo = int.Parse(reader.GetValue(2).ToString())
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    
                }

                CerrarConexion();
                
            }
            return listaSalas;
        }

        public bool ActualizaSalas(List<Sala> salas, string claveCine)
        {
            bool estatus = true;
            string query;

            foreach (Sala item in salas)
            {
                query = "UPDATE Cine.sala SET cupo = " + item.cupo + " where clave_cin = " + claveCine + " AND clave_sal = " + item.clave_sal;
                if (!EjecutaSentencia(query))
                {
                    estatus = false;
                }
            }

            return estatus;
        }
    }
}
