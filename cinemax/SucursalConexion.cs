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
            string query = "INSERT INTO Cine.cine(nombre, num_salas, colonia, calle, numero)" +
                "VALUES('" + nombreSucursal + "'," + numeroSalas + ",'" + colonia + "','" +
                calle + "'," + numero + ")";

            return Inserta(query);
        }

        public bool CargaDatosGrid(DataGridView dataGrid)
        {
            string query = "select * from Cine.cine";
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
