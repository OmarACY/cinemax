using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
            if (Inserta(query1))
            {
                query2 = "INSERT INTO Cine.tel_cin(clave_cin, telefono)" +
                "VALUES(" + ObtenUltimoID("cine", "clave_cin") + "," + telefono + ")";
                Inserta(query2);
                return true;
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
    }
}
