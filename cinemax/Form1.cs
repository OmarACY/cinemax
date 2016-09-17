using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace cinemax
{
    public partial class Form1 : Form
    {
        private Point formPosition;
        private bool mouseAction;
        private Conexion conexion;

        public Form1()
        {
            InitializeComponent();
            conexion = new Conexion();
            this.BackgroundImage = cinemax.Properties.Resources.fondo2;
            dgEmpleados.MultiSelect = false;
            dgEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void Form1_Load(object sender, EventArgs e)
        {            
        }

        #region Metodos del formulario
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseAction == true)
            {
                Location = new Point(Cursor.Position.X - formPosition.X,Cursor.Position.Y - formPosition.Y);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            formPosition = new Point (Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y);
            mouseAction = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseAction = false;
        }

        private void pbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

#endregion

        #region Metodos Pestaña Empleado
        private void btInsertaEmpeado_Click(object sender, EventArgs e)
        {
            InsertaEmpleado();
        }
        private void InsertaEmpleado() {
            LimpiaFormularioEmpleado();
            if (ValidaFormularioEmpleado())
            {
                if (conexion.AbrirConexion())
                {

                    string txtCmd = "INSERT INTO Persona.empleado(nombres,app,apm,fecha_nac,colonia,calle,numero)" +
                        "VALUES('" + tbNombreEmp.Text + "','" + tbAppEmp.Text + "','" + tbApmEmp.Text + "','" +
                        dpFechaEmp.Value.Year + "/" + dpFechaEmp.Value.Month + "/" + dpFechaEmp.Value.Day + "','" + tbColoniaEmp.Text + "','" +
                        tbCalleEmp.Text + "'," + tbNumeroEmp.Text + ")";
                    SqlCommand cmd = new SqlCommand(txtCmd, conexion.con);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        ObtenerRegistrosEmpleado();
                        MessageBox.Show("El empleado se agrego correctamente!!");                        
                        LimpiaCamposEmpleado();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    conexion.CerrarConexion();
                }
                else {
                    MessageBox.Show("Error al llamar al serividor");
                }
            }

        }

        private void LimpiaFormularioEmpleado()
        {

            //Cambia texto
            lbNombreEmp.Text = "Nombre (s)";
            lbAppEmp.Text = "Apellido paterno";
            lbApmEmp.Text = "Apellido materno";
            lbFechaEmp.Text = "Fecha de nacimiento";
            lbColoniaEmp.Text = "Colonia";
            lbCalleEmp.Text = "Calle";
            lbNumeroEmp.Text = "Numero";
            lbMensaje.Visible = false;
            //Cambia color
            lbNombreEmp.ForeColor = Color.LightGray;
            lbAppEmp.ForeColor = Color.LightGray;
            lbApmEmp.ForeColor = Color.LightGray;
            lbFechaEmp.ForeColor = Color.LightGray;
            lbColoniaEmp.ForeColor = Color.LightGray;
            lbCalleEmp.ForeColor = Color.LightGray;
            lbNumeroEmp.ForeColor = Color.LightGray;
        }

        private bool ValidaFormularioEmpleado()
        {
            bool valido = true;
            int error = 0;

            if (tbNombreEmp.Text.Trim() == string.Empty) { lbNombreEmp.Text = "Nombre (s) *"; lbNombreEmp.ForeColor = Color.Red; error++; }
            if (tbAppEmp.Text.Trim() == string.Empty) { lbAppEmp.Text = "Apellido paterno *"; lbAppEmp.ForeColor = Color.Red; error++; }
            if (tbApmEmp.Text.Trim() == string.Empty) { lbApmEmp.Text = "Apellido materno *"; lbApmEmp.ForeColor = Color.Red; error++; }
            if (dpFechaEmp.Text.Trim() == string.Empty) { lbFechaEmp.Text = "Fecha de nacimiento *"; lbFechaEmp.ForeColor = Color.Red; error++; }
            if (tbColoniaEmp.Text.Trim() == string.Empty) { lbColoniaEmp.Text = "Colonia *"; lbColoniaEmp.ForeColor = Color.Red; error++; }
            if (tbCalleEmp.Text.Trim() == string.Empty) { lbCalleEmp.Text = "Calle *"; lbCalleEmp.ForeColor = Color.Red; error++; }
            if (tbNumeroEmp.Text.Trim() == string.Empty) { lbNumeroEmp.Text = "Numero *"; lbNumeroEmp.ForeColor = Color.Red; error++; }
       
            if (error > 0) { lbMensaje.Visible = true; valido = false; }

            return valido;
        }

        private void LimpiaCamposEmpleado() {             
            tbNombreEmp.Clear();
            tbAppEmp.Clear();
            tbApmEmp.Clear();
            tbColoniaEmp.Clear();
            tbCalleEmp.Clear();
            tbNumeroEmp.Clear();
            tbTelEmp.Clear();
            tbCelEmp.Clear();
        }

        private void ObtenerRegistrosEmpleado() {
            SqlDataAdapter adaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();           

            if (conexion.AbrirConexion())
            {
                string txtCmd = "select * from Persona.Empleado";
                SqlCommand cmd = new SqlCommand(txtCmd, conexion.con);

                try
                {
                    adaptador.SelectCommand = cmd;
                    adaptador.Fill(ds);
                    adaptador.Dispose();
                    cmd.Dispose();
                    dgEmpleados.DataSource = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                conexion.CerrarConexion();
            }
            else {
                MessageBox.Show("Error al llamar al servidor");
            }
        }

        private void btEliminaEmpleado_Click(object sender, EventArgs e)
        {
            EliminarEmpleado();
        }

        private void EliminarEmpleado()
        {
            string clave_emp;

            if ((clave_emp = RenglonSeleccionado()) != "")
            {
                if (conexion.AbrirConexion())
                {
                    clave_emp = dgEmpleados.SelectedCells[0].Value.ToString();
                    string txtCmd = "delete from Persona.Empleado where clave_emp = " + clave_emp;
                    SqlCommand cmd = new SqlCommand(txtCmd, conexion.con);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        ObtenerRegistrosEmpleado();
                        MessageBox.Show("Se elimino correctamente!!");
                        LimpiaCamposEmpleado();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    conexion.CerrarConexion();
                }
                else
                {
                    MessageBox.Show("Error al llamar al servidor");
                }

            }
        }

        private string RenglonSeleccionado()
        {

            string renglon;
            try { renglon = dgEmpleados.SelectedCells[0].Value.ToString(); }
            catch { renglon = string.Empty; }
            return renglon;
        }
        private void dgEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionaRegistro();
        }

        private void dgEmpleados_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SeleccionaRegistro();
        }

        private void SeleccionaRegistro()
        {
            if (dgEmpleados.SelectedCells.Count > 1)
            {
                tbNombreEmp.Text = dgEmpleados.SelectedCells[dgEmpleados.Columns["nombres"].Index].Value.ToString();
                tbAppEmp.Text = dgEmpleados.SelectedCells[dgEmpleados.Columns["app"].Index].Value.ToString();
                tbApmEmp.Text = dgEmpleados.SelectedCells[dgEmpleados.Columns["apm"].Index].Value.ToString();
                string fecha = dgEmpleados.SelectedCells[dgEmpleados.Columns["fecha_nac"].Index].Value.ToString();
                string[] f = fecha.Split('/');
                dpFechaEmp.Text = f[0] + '/' + f[1] + '/' + f[2];
                tbColoniaEmp.Text = dgEmpleados.SelectedCells[dgEmpleados.Columns["colonia"].Index].Value.ToString();
                tbCalleEmp.Text = dgEmpleados.SelectedCells[dgEmpleados.Columns["calle"].Index].Value.ToString();
                tbNumeroEmp.Text = dgEmpleados.SelectedCells[dgEmpleados.Columns["numero"].Index].Value.ToString();
            }

        }

        #endregion
        private void tcPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tcPrincipal.SelectedTab.Text)
            {
                case "Empleado":
                    ObtenerRegistrosEmpleado();
                    break;
            }

        }








    }
}
