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
        #region Atributos
        private Point formPosition;
        private bool mouseAction;
        private Conexion conexion;
        #endregion

        #region Metodos Constructor y Load
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

        #endregion

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
                string txtCmd = "select * from Persona.empleado";
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
                if (MessageBox.Show("¿Esta seguro de querer eliminar este Empleado?", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    if (conexion.AbrirConexion())
                    {
                        //clave_emp = dgEmpleados.SelectedCells[0].Value.ToString();
                        string txtCmd = "delete from Persona.empleado where clave_emp = " + clave_emp;
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

        private void ActualizarEmpleado() {

            string clave_emp;

            if ((clave_emp = RenglonSeleccionado()) != "")
            {
                if (conexion.AbrirConexion())
                {//(nombres,app,apm,fecha_nac,colonia,calle,numero)
                    string txtCmd = "update Persona.empleado set nombres='" +
                        tbNombreEmp.Text + "', app='" + tbAppEmp.Text +
                        "', apm='" + tbApmEmp.Text + "', fecha_nac='" +
                        dpFechaEmp.Value.Year +  "/" + dpFechaEmp.Value.Month + "/" + dpFechaEmp.Value.Day +
                        "', colonia='" + tbColoniaEmp.Text + "', calle='" + tbCalleEmp.Text +
                        "', numero='" + tbNumeroEmp.Text + "' where clave_emp=" + clave_emp;

                    SqlCommand cmd = new SqlCommand(txtCmd, conexion.con);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        ObtenerRegistrosEmpleado();
                        MessageBox.Show("Se actualizo correctamente!!");
                        LimpiaCamposEmpleado();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else {
                    MessageBox.Show("Error al llamar al servidor");
                }
            }
        }


        private void btActualizaEmpleado_Click(object sender, EventArgs e)
        {
            ActualizarEmpleado();
        }

        private void tbNumeroEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaNumero(e);
        }

        private void tbTelEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaNumero(e);
        }

        private void tbCelEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaNumero(e);
        }

        #endregion

        #region Metodos Comunes
        private void tcPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tcPrincipal.SelectedTab.Text)
            {
                case "Empleado":
                    ObtenerRegistrosEmpleado();
                    break;
                case "Membresias":
                    ObtenerRegistrosMembresia();
                    break;
            }

        }

        private void ValidaNumero(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        #endregion



        #region Metodos Pestaña Membresia

        private void btInsertaMem_Click(object sender, EventArgs e)
        {
            InsertaMembresia();            
        }

        private void InsertaMembresia()
        {
            LimpiaFormularioMembresia();
            if (ValidaFormularioMembresia())
            {
                if (conexion.AbrirConexion())
                {

                    string txtCmd = "INSERT INTO Persona.membresia(nombre,app,apm,fecha_nac,colonia,calle,numero,tipo,puntos)" +
                        "VALUES('" + tbNombreMem.Text + "','" + tbAppMem.Text + "','" + tbApmMem.Text + "','" +
                        dpFechaMem.Value.Year + "/" + dpFechaMem.Value.Month + "/" + dpFechaMem.Value.Day + "','" + tbColoniaMem.Text + "','" +
                        tbCalleMem.Text + "'," + tbNumeroMem.Text + ",'" + cbTipoMem.Text + "'," + nuPuntosMem.Value + ")";
                    SqlCommand cmd = new SqlCommand(txtCmd, conexion.con);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        ObtenerRegistrosMembresia();
                        MessageBox.Show("El empleado se agrego correctamente!!");
                        LimpiaCamposMembresia();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    conexion.CerrarConexion();
                }
                else
                {
                    MessageBox.Show("Error al llamar al serividor");
                }
            }

        }
        private void LimpiaFormularioMembresia()
        {

            //Cambia texto
            lbNombreMem.Text = "Nombre (s)";
            lbAppMem.Text = "Apellido paterno";
            lbApmMem.Text = "Apellido materno";
            lbFechaMem.Text = "Fecha de nacimiento";
            lbColoniaMem.Text = "Colonia";
            lbCalleMem.Text = "Calle";
            lbNumeroMem.Text = "Numero";
            lbTipoMem.Text = "Tipo";
            lbMensajeMem.Visible = false;
            //Cambia color
            lbNombreMem.ForeColor = Color.LightGray;
            lbAppMem.ForeColor = Color.LightGray;
            lbApmMem.ForeColor = Color.LightGray;
            lbFechaMem.ForeColor = Color.LightGray;
            lbColoniaMem.ForeColor = Color.LightGray;
            lbCalleMem.ForeColor = Color.LightGray;
            lbNumeroMem.ForeColor = Color.LightGray;
            lbTipoMem.ForeColor = Color.LightGray;
        }

        private bool ValidaFormularioMembresia()
        {
            bool valido = true;
            int error = 0;

            if (tbNombreMem.Text.Trim() == string.Empty) { lbNombreMem.Text = "Nombre (s) *"; lbNombreMem.ForeColor = Color.Red; error++; }
            if (tbAppMem.Text.Trim() == string.Empty) { lbAppMem.Text = "Apellido paterno *"; lbAppMem.ForeColor = Color.Red; error++; }
            if (tbApmMem.Text.Trim() == string.Empty) { lbApmMem.Text = "Apellido materno *"; lbApmMem.ForeColor = Color.Red; error++; }
            if (dpFechaMem.Text.Trim() == string.Empty) { lbFechaMem.Text = "Fecha de nacimiento *"; lbFechaMem.ForeColor = Color.Red; error++; }
            if (tbColoniaMem.Text.Trim() == string.Empty) { lbColoniaMem.Text = "Colonia *"; lbColoniaMem.ForeColor = Color.Red; error++; }
            if (tbCalleMem.Text.Trim() == string.Empty) { lbCalleMem.Text = "Calle *"; lbCalleMem.ForeColor = Color.Red; error++; }
            if (tbNumeroMem.Text.Trim() == string.Empty) { lbNumeroMem.Text = "Numero *"; lbNumeroMem.ForeColor = Color.Red; error++; }
            if (cbTipoMem.Text == string.Empty) { lbTipoMem.Text = "Tipo *"; lbTipoMem.ForeColor = Color.Red; error++; }

            if (error > 0) { lbMensajeMem.Visible = true; valido = false; }

            return valido;
        }

        private void LimpiaCamposMembresia()
        {
            tbNombreMem.Clear();
            tbAppMem.Clear();
            tbApmMem.Clear();
            tbColoniaMem.Clear();
            tbCalleMem.Clear();
            tbNumeroMem.Clear();
        }

        private void ObtenerRegistrosMembresia()
        {
            SqlDataAdapter adaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            if (conexion.AbrirConexion())
            {
                string txtCmd = "select * from Persona.membresia";
                SqlCommand cmd = new SqlCommand(txtCmd, conexion.con);

                try
                {
                    adaptador.SelectCommand = cmd;
                    adaptador.Fill(ds);
                    adaptador.Dispose();
                    cmd.Dispose();
                    dgMembresias.DataSource = ds.Tables[0];
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

        #endregion
    }
}
