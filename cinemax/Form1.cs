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
using System.Text.RegularExpressions;
using cinemax.Models;

namespace cinemax
{
    public partial class Cinemax : Form
    {

        #region Atributos
        private Point formPosition;
        private bool mouseAction;
        private Conexion conexion;

        private int opFun = -1;

        public long clave_emp;

        private bool muestraButacas = false;
        private int contadorButacas = 0;

        #endregion

        #region Metodos Constructor y Load
        public Cinemax()
        {
            InitializeComponent();
            conexion = new Conexion();
            //this.BackgroundImage = cinemax.Properties.Resources.fondo2;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tcPrincipal_SelectedIndexChanged(this, null);                   
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

#endregion

        #region Metodos Pestaña Empleado
        private void btInsertaEmpeado_Click(object sender, EventArgs e)
        {
            InsertaEmpleado();
        }
        private void InsertaEmpleado() {
            LimpiaFormularioEmpleado();
            if (ValidaDatosEmpleado())
            {
                if (conexion.AbrirConexion())
                {
                    string txtCmd = "INSERT INTO Persona.empleado(nombres,app,apm,fecha_nac,colonia,calle,numero, contraseña)" +
                        "VALUES('" + tbNombreEmp.Text + "','" + tbAppEmp.Text + "','" + tbApmEmp.Text + "','" +
                        dpFechaEmp.Value.Year + "/" + dpFechaEmp.Value.Month + "/" + dpFechaEmp.Value.Day + "','" + tbColoniaEmp.Text + "','" +
                        tbCalleEmp.Text + "'," + tbNumeroEmp.Text + ", '" + tbPwdEmpl.Text + "')";

                    SqlCommand cmd = new SqlCommand(txtCmd, conexion.con);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        ObtenerRegistrosEmpleado();
                        CambiaTextoMensajeEmp("Se agrego correctamente!",Color.Blue);
                        lbMensaje.Visible = true;                     
                        LimpiaCamposEmpleado();
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

        }

        /// <summary>
        /// Cambiar el color y el mensaje del modulo empleados empleados que se mostrara al usuario    
        /// </summary>
        /// <param name="mensaje">Mensaje que se mostrara al usuario</param>
        /// <param name="color">Color del texto del mensaje que se le mostrara al usuario</param>
        private void CambiaTextoMensajeEmp(String mensaje,Color color) {
            lbMensaje.ForeColor = color;
            lbMensaje.Text = mensaje;
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
            lbPassword.Text = "Contraseña";
            lbMensaje.Visible = false;
            //Cambia color
            lbNombreEmp.ForeColor = Color.LightGray;
            lbAppEmp.ForeColor = Color.LightGray;
            lbApmEmp.ForeColor = Color.LightGray;
            lbFechaEmp.ForeColor = Color.LightGray;
            lbColoniaEmp.ForeColor = Color.LightGray;
            lbCalleEmp.ForeColor = Color.LightGray;
            lbNumeroEmp.ForeColor = Color.LightGray;
            lbPassword.ForeColor = Color.LightGray;
        }

        private bool ValidaDatosEmpleado()
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
            if (tbPwdEmpl.Text == string.Empty) { lbPassword.Text = "Contraseña *"; lbPassword.ForeColor = Color.Red; error++; }

            if (error > 0) { CambiaTextoMensajeEmp("* Campos requeridos!", Color.Red) ; lbMensaje.Visible = true; valido = false; }

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
            tbPwdEmpl.Clear();
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
                    dgEmpleados.ClearSelection();
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

            if ((clave_emp = RenglonSeleccionadoEmp()) != "")
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
                            CambiaTextoMensajeEmp("Se elimino correctamente!", Color.Blue);
                            LimpiaCamposEmpleado();
                            /* Deshabilitación de campos de captura */
                            SwitchCamposEmpleado("Deshabilitar");
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
            }else MessageBox.Show("Primero selecciona el <Empleado> que se desea eliminar","Atención");
        }

        private string RenglonSeleccionadoEmp()
        {
            string renglon;
            try { renglon = dgEmpleados.SelectedCells[0].Value.ToString(); }
            catch { renglon = string.Empty; }
            return renglon;
        }
        private void dgEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionaRegistroEmp();
            SwitchCamposEmpleado("Actualizar");
            
        }

        private void dgEmpleados_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SeleccionaRegistroEmp();
            SwitchCamposEmpleado("Actualizar");
        }

        private void SeleccionaRegistroEmp()
        {
            if (dgEmpleados.SelectedCells.Count > 1)
            {
                tbNombreEmp.Text = dgEmpleados.SelectedCells[dgEmpleados.Columns["nombres"].Index].Value.ToString();
                tbAppEmp.Text = dgEmpleados.SelectedCells[dgEmpleados.Columns["app"].Index].Value.ToString();
                tbApmEmp.Text = dgEmpleados.SelectedCells[dgEmpleados.Columns["apm"].Index].Value.ToString();
                dpFechaEmp.Text = dgEmpleados.SelectedCells[dgEmpleados.Columns["fecha_nac"].Index].Value.ToString();
                tbColoniaEmp.Text = dgEmpleados.SelectedCells[dgEmpleados.Columns["colonia"].Index].Value.ToString();
                tbCalleEmp.Text = dgEmpleados.SelectedCells[dgEmpleados.Columns["calle"].Index].Value.ToString();
                tbNumeroEmp.Text = dgEmpleados.SelectedCells[dgEmpleados.Columns["numero"].Index].Value.ToString();
                tbPwdEmpl.Text = dgEmpleados.SelectedCells[dgEmpleados.Columns["contraseña"].Index].Value.ToString();
            }

        }

        private void ActualizarEmpleado() {

            string clave_emp;

            if ((clave_emp = RenglonSeleccionadoEmp()) != "")
            {
                if (ValidaDatosEmpleado())
                {
                    if (MessageBox.Show("¿Esta seguro de querer actualizar la \n información de este empleado?", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (conexion.AbrirConexion())
                        {
                            string txtCmd = "update Persona.empleado set nombres='" +
                                tbNombreEmp.Text + "', app='" + tbAppEmp.Text +
                                "', apm='" + tbApmEmp.Text + "', fecha_nac='" +
                                dpFechaEmp.Value.Year + "/" + dpFechaEmp.Value.Month + "/" + dpFechaEmp.Value.Day +
                                "', colonia='" + tbColoniaEmp.Text + "', calle='" + tbCalleEmp.Text +
                                "', numero='" + tbNumeroEmp.Text + "', contraseña= '" + tbPwdEmpl.Text + "' where clave_emp=" + clave_emp;

                            SqlCommand cmd = new SqlCommand(txtCmd, conexion.con);

                            try
                            {
                                cmd.ExecuteNonQuery();
                                /*Carga nuevamente los registros*/
                                ObtenerRegistrosEmpleado();
                                /*Cambia el mensaje que se mostrara al usuario*/
                                CambiaTextoMensajeEmp("Se actualizo correctamente!", Color.Blue);
                                lbMensaje.Visible = true;
                                /*Limpia los campos de captura de datos*/
                                LimpiaCamposEmpleado();
                                /* Deshabilitación de campos de captura */
                                SwitchCamposEmpleado("Deshabilitar");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Error al llamar al servidor");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Primero selecciona al <Empleado> que se desea actualizar", "Atención");
            }
            
        }

        private void btCancelaEmp_Click(object sender, EventArgs e)
        {
            SwitchCamposEmpleado("Deshabilitar");
            LimpiaFormularioEmpleado();
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

        private void SwitchCamposEmpleado(string caso)
        {
            switch (caso)
            {
                case "Habilitar":
                    btCancelaEmp.Visible = true;
                    btActualizaEmp.Enabled = false;
                    btEliminaEmp.Enabled = false;
                    btInsertaEmp.Enabled = false;
                    break;
                case "Deshabilitar":
                    btCancelaEmp.Visible = false;
                    btActualizaEmp.Enabled = false;
                    btEliminaEmp.Enabled = false;
                    btInsertaEmp.Enabled = true;
                    LimpiaCamposEmpleado();
                    dgEmpleados.ClearSelection();
                    break;
                case "Actualizar":
                    LimpiaFormularioEmpleado();
                    btCancelaEmp.Visible = true;
                    btActualizaEmp.Enabled = true;
                    btEliminaEmp.Enabled = true;
                    btInsertaEmp.Enabled = false;
                    break;
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
            if (ValidaDatosMembresia())
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
                        CambiaTextoMensajeMem("Se agrego correctamente!", Color.Blue);
                        lbMensajeMem.Visible = true;
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

        private void SwitchCamposMembresia(string caso)
        {
            switch (caso)
            {
                case "Habilitar":
                    btCancelaMem.Visible = true;
                    btActualizaMem.Enabled = false;
                    btEliminaMem.Enabled = false;
                    btInsertaMem.Enabled = false;
                    break;
                case "Deshabilitar":
                    btCancelaMem.Visible = false;
                    btActualizaMem.Enabled = false;
                    btEliminaMem.Enabled = false;
                    btInsertaMem.Enabled = true;
                    LimpiaCamposMembresia();
                    dgMembresias.ClearSelection();
                    break;
                case "Actualizar":
                    LimpiaFormularioMembresia();
                    btCancelaMem.Visible = true;
                    btActualizaMem.Enabled = true;
                    btEliminaMem.Enabled = true;
                    btInsertaMem.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// Cambiar el color y el mensaje del modulo membresia que se mostrara al usuario    
        /// </summary>
        /// <param name="mensaje">Mensaje que se mostrara al usuario</param>
        /// <param name="color">Color del texto del mensaje que se le mostrara al usuario</param>
        private void CambiaTextoMensajeMem(String mensaje, Color color)
        {
            lbMensajeMem.ForeColor = color;
            lbMensajeMem.Text = mensaje;
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

        private bool ValidaDatosMembresia()
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

            if (error > 0) { CambiaTextoMensajeMem("* Campos requeridos", Color.Red); lbMensajeMem.Visible = true; valido = false; }

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
            cbTipoMem.SelectedIndex = -1;
            nuPuntosMem.Value = 0;
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
                    dgMembresias.ClearSelection();
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
        private void btActualizaMem_Click(object sender, EventArgs e)
        {
            ActualizarMembresia();
        }

        private void ActualizarMembresia()
        {
            string clave_mem;
            if ((clave_mem = RenglonSeleccionadoMem()) != "")
            {
                if (ValidaDatosMembresia())
                {
                    if (MessageBox.Show("¿Esta seguro de querer actualizar la \n información de esta Membresia?", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (conexion.AbrirConexion())
                        {
                            string txtCmd = "update Persona.membresia set nombre='" +
                                tbNombreMem.Text + "', app='" + tbAppMem.Text +
                                "', apm='" + tbApmMem.Text + "', fecha_nac='" +
                                dpFechaMem.Value.Year + "/" + dpFechaMem.Value.Month + "/" + dpFechaMem.Value.Day +
                                "', colonia='" + tbColoniaMem.Text + "', calle='" + tbCalleMem.Text +
                                "', numero=" + tbNumeroMem.Text + ", tipo='" + cbTipoMem.Text + "', puntos=" + nuPuntosMem.Value.ToString() +
                                " where clave_mem=" + clave_mem;

                            SqlCommand cmd = new SqlCommand(txtCmd, conexion.con);

                            try
                            {
                                cmd.ExecuteNonQuery();
                                ObtenerRegistrosMembresia();
                                CambiaTextoMensajeMem("Se actualizo correctamente!", Color.Blue);
                                lbMensajeMem.Visible = true;
                                LimpiaCamposMembresia();
                                /* Deshabilitación de campos de captura */
                                SwitchCamposMembresia("Deshabilitar");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Error al llamar al servidor");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Primero selecciona al <Membresia> que se desea actualizar", "Atención");
            }
        }

        private string RenglonSeleccionadoMem()
        {
            string renglon;
            try { renglon = dgMembresias.SelectedCells[0].Value.ToString(); }
            catch { renglon = string.Empty; }
            return renglon;
        }

        private void dgMembresias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionaRegistroMem();
            SwitchCamposMembresia("Actualizar");
        }

        private void dgMembresias_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SeleccionaRegistroMem();
            SwitchCamposMembresia("Actualizar");
        }

        private void SeleccionaRegistroMem()
        {
            if (dgMembresias.SelectedCells.Count > 1)
            {
                tbNombreMem.Text = dgMembresias.SelectedCells[dgMembresias.Columns["nombre"].Index].Value.ToString();
                tbAppMem.Text = dgMembresias.SelectedCells[dgMembresias.Columns["app"].Index].Value.ToString();
                tbApmMem.Text = dgMembresias.SelectedCells[dgMembresias.Columns["apm"].Index].Value.ToString();
                dpFechaMem.Text = dgMembresias.SelectedCells[dgMembresias.Columns["fecha_nac"].Index].Value.ToString();
                tbColoniaMem.Text = dgMembresias.SelectedCells[dgMembresias.Columns["colonia"].Index].Value.ToString();
                tbCalleMem.Text = dgMembresias.SelectedCells[dgMembresias.Columns["calle"].Index].Value.ToString();
                tbNumeroMem.Text = dgMembresias.SelectedCells[dgMembresias.Columns["numero"].Index].Value.ToString();
                cbTipoMem.SelectedItem = dgMembresias.SelectedCells[dgMembresias.Columns["tipo"].Index].Value.ToString();
                nuPuntosMem.Value =(int)dgMembresias.SelectedCells[dgMembresias.Columns["puntos"].Index].Value;
            }
        }

        private void btEliminaMem_Click(object sender, EventArgs e)
        {
            EliminarMembresia();
        }

        private void EliminarMembresia()
        {
            string clave_mem;

            if ((clave_mem = RenglonSeleccionadoMem()) != "")
            {
                if (MessageBox.Show("¿Esta seguro de querer eliminar esta Membresia?", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    if (conexion.AbrirConexion())
                    {
                        //clave_emp = dgEmpleados.SelectedCells[0].Value.ToString();
                        string txtCmd = "delete from Persona.membresia where clave_mem = " + clave_mem;
                        SqlCommand cmd = new SqlCommand(txtCmd, conexion.con);
                        try
                        {
                            cmd.ExecuteNonQuery();
                            ObtenerRegistrosMembresia();
                            CambiaTextoMensajeMem("Se elimino correctamente!", Color.Blue);
                            LimpiaCamposMembresia();
                            /* Deshabilitación de campos de captura */
                            SwitchCamposMembresia("Deshabilitar");
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
            else MessageBox.Show("Primero selecciona la <Membresia> que se desea eliminar", "Atención");
        }

        private void btCancelarMem_Click(object sender, EventArgs e)
        {
            SwitchCamposMembresia("Deshabilitar");
            LimpiaFormularioMembresia();
        }

        #endregion

        #region Metodos pestaña peliculas

        private void SwitchCamposPelicula(string caso)
        {
            
            switch (caso)
            {
                case "Habilitar":
                    btCancelaPel.Visible = true;
                    btActualizaPel.Enabled = false;
                    btEliminaPel.Enabled = false;
                    btInsertaPel.Enabled = false;
                    break;
                case "Deshabilitar":
                    btCancelaPel.Visible = false;
                    btActualizaPel.Enabled = false;
                    btEliminaPel.Enabled = false;
                    btInsertaPel.Enabled = true;
                    LimpiaCamposPelicula();
                    dgPeliculas.ClearSelection();
                    break;
                case "Actualizar":
                    LimpiaFormularioPelicula();
                    btCancelaPel.Visible = true;
                    btActualizaPel.Enabled = true;
                    btEliminaPel.Enabled = true;
                    btInsertaPel.Enabled = false;
                    break;
            }
        }

        private void btAgregarPel_Click(object sender, EventArgs e)
        {
            InsertaPelicula();
        }

        private void InsertaPelicula()
        {
            LimpiaFormularioPelicula();
            if (ValidaDatosPelicula())
            {
                if (conexion.AbrirConexion())
                {

                    string txtCmd = "INSERT INTO Cine.pelicula(nombre,director,sinopsis,clasificacion,genero)" +
                        "VALUES('" + tbNombrePel.Text + "','" + tbDirectorPel.Text + "','" + tbSinopsisPel.Text + "','" +
                        ClasificacionPelicula() + "','" + cbGeneroPel.Text + "')";
                    SqlCommand cmd = new SqlCommand(txtCmd, conexion.con);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        ObtenerRegistrosPelicula();
                        CambiaTextoMensajePel("Se agrego correctamente!", Color.Blue);
                        lbMensajePel.Visible = true;
                        LimpiaCamposPelicula();
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

        private bool ValidaDatosPelicula()
        {
            bool valido = true;
            int error = 0;

            if (tbNombrePel.Text.Trim() == string.Empty) { lbNombrePel.Text = "Nombre *"; lbNombrePel.ForeColor = Color.Red; error++; }
            if (tbDirectorPel.Text.Trim() == string.Empty) { lbDirectorPel.Text = "Director *"; lbDirectorPel.ForeColor = Color.Red; error++; }
            if (ClasificacionPelicula() == '0') { lbClasificacionPel.Text = "Clasificación *"; lbClasificacionPel.ForeColor = Color.Red; error++; }
            if (cbGeneroPel.Text == string.Empty) { lbGeneroPel.Text = "Genero *"; lbGeneroPel.ForeColor = Color.Red; error++; }
            if (tbSinopsisPel.Text.Trim() == string.Empty) { lbSinopsisPel.Text = "Sinopsis *"; lbSinopsisPel.ForeColor = Color.Red; error++; }

            if (error > 0) { CambiaTextoMensajePel("* Campos requeridos", Color.Red); lbMensajePel.Visible = true; valido = false; }

            return valido;
        }

        /// <summary>
        /// Cambiar el color y el mensaje del modulo pelicula que se mostrara al usuario    
        /// </summary>
        /// <param name="mensaje">Mensaje que se mostrara al usuario</param>
        /// <param name="color">Color del texto del mensaje que se le mostrara al usuario</param>
        private void CambiaTextoMensajePel(String mensaje, Color color)
        {
            lbMensajePel.ForeColor = color;
            lbMensajePel.Text = mensaje;
        }

        private char ClasificacionPelicula() {
            char clas = '0';

            if (rbAPel.Checked)
                clas = 'A';
            else
                if (rbBPel.Checked)
                    clas = 'B';
                else
                    if (rbCPel.Checked)
                        clas = 'C';

            return clas;
        }

        private void ClasificacionPelicula(char clas)
        {
            switch (clas) { 
                case 'A':
                    rbAPel.Checked = true;
                    break;
                case 'B':
                    rbBPel.Checked = true;
                    break;
                case 'C':
                    rbCPel.Checked = true;
                    break;
            
            }

        }

        private void LimpiaFormularioPelicula()
        {

            //Cambia texto
            lbNombrePel.Text = "Nombre";
            lbDirectorPel.Text = "Direcctor";
            lbClasificacionPel.Text = "Clasificación";
            lbGeneroPel.Text = "Genero";
            lbSinopsisPel.Text = "Sinopsis";
            lbMensajePel.Visible = false;
            //Cambia color
            lbNombrePel.ForeColor = Color.LightGray;
            lbDirectorPel.ForeColor = Color.LightGray;
            lbClasificacionPel.ForeColor = Color.LightGray;
            lbGeneroPel.ForeColor = Color.LightGray;
            lbSinopsisPel.ForeColor = Color.LightGray;
        }

        private void LimpiaCamposPelicula()
        {
            tbNombrePel.Clear();
            tbDirectorPel.Clear();
            rbAPel.Checked = false;
            rbBPel.Checked = false;
            rbCPel.Checked = false;
            cbGeneroPel.SelectedIndex = -1;
            tbSinopsisPel.Clear();
        }

        private void ObtenerRegistrosPelicula()
        {
            SqlDataAdapter adaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            if (conexion.AbrirConexion())
            {
                string txtCmd = "select * from Cine.pelicula";
                SqlCommand cmd = new SqlCommand(txtCmd, conexion.con);

                try
                {
                    adaptador.SelectCommand = cmd;
                    adaptador.Fill(ds);
                    adaptador.Dispose();
                    cmd.Dispose();
                    dgPeliculas.DataSource = ds.Tables[0];
                    dgPeliculas.ClearSelection();
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

        private void btCancelarPel_Click(object sender, EventArgs e)
        {
            SwitchCamposPelicula("Deshabilitar");
            LimpiaFormularioPelicula();
        }

        private void dgPeliculas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionaRegistroPel();
            SwitchCamposPelicula("Actualizar");
        }

        private void dgPeliculas_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SeleccionaRegistroPel();
            SwitchCamposPelicula("Actualizar");
        }
        private void SeleccionaRegistroPel()
        {
            if (dgPeliculas.SelectedCells.Count > 1)
            {
                tbNombrePel.Text = dgPeliculas.SelectedCells[dgPeliculas.Columns["nombre"].Index].Value.ToString();
                tbDirectorPel.Text = dgPeliculas.SelectedCells[dgPeliculas.Columns["director"].Index].Value.ToString();
                tbSinopsisPel.Text = dgPeliculas.SelectedCells[dgPeliculas.Columns["sinopsis"].Index].Value.ToString();
                ClasificacionPelicula(char.Parse(dgPeliculas.SelectedCells[dgPeliculas.Columns["clasificacion"].Index].Value.ToString()));
                cbGeneroPel.SelectedItem = dgPeliculas.SelectedCells[dgPeliculas.Columns["genero"].Index].Value.ToString();
            }
        }     

        private void btActualizaPel_Click(object sender, EventArgs e)
        {
            ActualizarPelicula();
        }

        private string RenglonSeleccionadoPel()
        {
            string renglon;
            try { renglon = dgPeliculas.SelectedCells[0].Value.ToString(); }
            catch { renglon = string.Empty; }
            return renglon;
        }

        private void ActualizarPelicula()
        {
            string clave_pel;
            if ((clave_pel = RenglonSeleccionadoPel()) != "")
            {
                if (ValidaDatosPelicula())
                {
                    if (MessageBox.Show("¿Esta seguro de querer actualizar la \n información de este empleado?", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (conexion.AbrirConexion())
                        {
                            string txtCmd = "update Cine.pelicula set nombre='" +
                                tbNombrePel.Text + "', director='" + tbDirectorPel.Text +
                                "', sinopsis='" + tbSinopsisPel.Text + "', clasificacion='" + ClasificacionPelicula() +
                                "', genero='" + cbGeneroPel.Text + "' where clave_pel=" + clave_pel;

                            SqlCommand cmd = new SqlCommand(txtCmd, conexion.con);

                            try
                            {
                                cmd.ExecuteNonQuery();
                                ObtenerRegistrosPelicula();
                                CambiaTextoMensajePel("Se actualizo correctamente!", Color.Blue);
                                lbMensajePel.Visible = true;
                                LimpiaCamposPelicula();
                                /* Deshabilitación de campos de captura */
                                SwitchCamposPelicula("Deshabilitar");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al llamar al servidor");
                    }
                }
            }
            else
            {
                MessageBox.Show("Primero selecciona la <Pelicula> que se desea actualizar", "Atención");
            }

        }

        private void btEliminaPel_Click(object sender, EventArgs e)
        {
            EliminarPelicula();
        }

        private void EliminarPelicula()
        {
            string clave_pel;

            if ((clave_pel = RenglonSeleccionadoPel()) != "")
            {
                if (MessageBox.Show("¿Esta seguro de querer eliminar esta Pelicula?", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    if (conexion.AbrirConexion())
                    {
                        //clave_emp = dgEmpleados.SelectedCells[0].Value.ToString();
                        string txtCmd = "delete from Cine.Pelicula where clave_pel = " + clave_pel;
                        SqlCommand cmd = new SqlCommand(txtCmd, conexion.con);
                        try
                        {
                            cmd.ExecuteNonQuery();
                            ObtenerRegistrosPelicula();
                            CambiaTextoMensajePel("Se elimino correctamente!", Color.Blue);
                            LimpiaCamposPelicula();
                            /* Deshabilitación de campos de captura */
                            SwitchCamposPelicula("Deshabilitar");
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
            else MessageBox.Show("Primero selecciona la <Pelicula> que se desea eliminar", "Atención");
        }

        #endregion

        #region Metodos Pestaña Sucursal
        private void btnAgregarSuc_Click(object sender, EventArgs e)
        {
            SucursalConexion dbConexion = new SucursalConexion();
            bool resultado;

            if (ValidaDatosSucursal())
            {
                /* Insercción de datos */
                resultado = dbConexion.InsertaSucursal(tbNombreCine.Text,
                    nudSalasCine.Value.ToString(),
                    tbColoniaSuc.Text,
                    tbCalleSucursal.Text,
                    tbNumeroSucursal.Text,
                    tbTelefonoSucursal.Text);

                if (!resultado)
                    MessageBox.Show("La sucursal no fue agregada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    labelMensajeSucursal.Text = "Sucursal agregada";
                    tcPrincipal_SelectedIndexChanged(this, null);
                    labelMensajeSucursal.Visible = true;
                    ResetTimer.Enabled = true;
                }

                /* Actualización del grid */
                tcPrincipal_SelectedIndexChanged(this, null);
            }
        }

        private void btnEliminarSuc_Click(object sender, EventArgs e)
        {
            string clave_cin;
            SucursalConexion dbConexion = new SucursalConexion();
            bool resultado;

            #region Obtener clave de cine
            try 
            {
                clave_cin = dgSucursales.SelectedCells[0].Value.ToString(); 
            }
            catch(Exception)
            { 
                clave_cin = string.Empty;
            }
            #endregion
            if (clave_cin != "")
            {
                if (MessageBox.Show("¿Esta seguro de querer eliminar esta sucursal?", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    /* Insercción de datos */
                    resultado = dbConexion.EliminaSucursal(clave_cin);

                    if (!resultado)
                        MessageBox.Show("La sucursal \n no fue eliminada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        labelMensajeSucursal.Text = "Sucursal eliminada";
                        labelMensajeSucursal.Visible = true;
                        ResetTimer.Enabled = true;
                        /* Actualización del grid */
                        tcPrincipal_SelectedIndexChanged(this, null);
                        /* Deshabilitación de campos de captura */
                        SwitchCamposSucural("Deshabilitar");
                    }
                }
            }
            else MessageBox.Show("Primero seleccione la <Sucursal> que se desea eliminar", "Atención");
        }

        private void btnActualizarSuc_Click(object sender, EventArgs e)
        {
            string clave_cin;
            SucursalConexion dbConexion = new SucursalConexion();
            bool resultado;

            #region Obtener clave de cine
            try
            {
                clave_cin = dgSucursales.SelectedCells[0].Value.ToString();
            }
            catch (Exception)
            {
                clave_cin = string.Empty;
            }
            #endregion
            if (clave_cin != "")
            {
                if (MessageBox.Show("¿Esta seguro de querer actualizar la \n información de esta sucursal?", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ValidaDatosSucursal())
                    {
                        /* Insercción de datos */
                        resultado = dbConexion.ActualizaSucursal(clave_cin, tbNombreCine.Text,
                            nudSalasCine.Value.ToString(),
                            tbColoniaSuc.Text,
                            tbCalleSucursal.Text,
                            tbNumeroSucursal.Text,
                            tbTelefonoSucursal.Text);

                        if (!resultado)
                            MessageBox.Show("La información de la sucursal \n no fue actualizada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            labelMensajeSucursal.Text = "Información de la sucursal actualizada";
                            labelMensajeSucursal.Visible = true;
                            ResetTimer.Enabled = true;
                            /* Actualización del grid */
                            tcPrincipal_SelectedIndexChanged(this, null);
                            /* Deshabilitación de campos de captura */
                            SwitchCamposSucural("Deshabilitar");
                        }
                    }
                }
            }
            else MessageBox.Show("Primero seleccione la <Sucursal> que se desea actualizar", "Atención");
        }

        private void btnAceptarSuc_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancelarSuc_Click(object sender, EventArgs e)
        {
            SwitchCamposSucural("Deshabilitar");
        }

        private void SwitchCamposSucural(string caso)
        {
            switch (caso)
            {
                case "Habilitar":
                    btnCancelarSuc.Visible = true;
                    btnActualizarSuc.Enabled = false;
                    btnEliminarSuc.Enabled = false;
                    btnAgregarSuc.Enabled = false;
                    nudSalasCine.Enabled = true;
                    btnEditarSalas.Visible = false;
                    labelSalasSucursal.Visible = false;
                    
                    break;
                case "Deshabilitar":
                    btnCancelarSuc.Visible = false;
                    btnActualizarSuc.Enabled = false;
                    btnEliminarSuc.Enabled = false;
                    btnAgregarSuc.Enabled = true;
                    tbNombreCine.Text = string.Empty;
                    nudSalasCine.Value = 0;
                    nudSalasCine.Enabled = true;
                    tbColoniaSuc.Text = string.Empty;
                    tbCalleSucursal.Text = string.Empty;
                    tbNumeroSucursal.Text = string.Empty;
                    tbTelefonoSucursal.Text = string.Empty;
                    btnEditarSalas.Visible = false;
                    labelSalasSucursal.Visible = false;
                    dgSucursales.ClearSelection();
                    break;
                case "Actualizar":
                    btnCancelarSuc.Visible = true;
                    btnAgregarSuc.Enabled = false;
                    btnActualizarSuc.Enabled = true;
                    btnEliminarSuc.Enabled = true;
                    nudSalasCine.Enabled = false;
                    btnEditarSalas.Visible = true;
                    labelSalasSucursal.Visible = true;
                    break;
            }
        }

        private bool ValidaDatosSucursal()
        {

            List<string> errores;

            errores = new List<string>();
            if (tbNombreCine.Text == string.Empty || Regex.IsMatch(tbNombreCine.Text, @"^(\s)+$"))
                errores.Add("Nomre de sucursal requerido");
            if (tbColoniaSuc.Text == string.Empty || Regex.IsMatch(tbColoniaSuc.Text, @"^(\s)+$"))
                errores.Add("Colonia requerida");
            if (tbCalleSucursal.Text == string.Empty || Regex.IsMatch(tbCalleSucursal.Text, @"^(\s)+$"))
                errores.Add("Calle requerida");
            if (!Regex.IsMatch(tbNumeroSucursal.Text, "[0-9]+"))
                errores.Add("Ingrese un número en la dirección de la sucursal");
            if ((tbTelefonoSucursal.Text != string.Empty) && !Regex.IsMatch(tbTelefonoSucursal.Text, @"^([0-9\s])+$"))
                errores.Add("Ingrese un número teléfonico válido");
            if (Regex.IsMatch(tbTelefonoSucursal.Text, @"^(\s)+$"))
                tbTelefonoSucursal.Text = string.Empty;
            if (errores.Count == 0)
                return true;
            else
            {
                string msgText = string.Empty;
                foreach (string elem in errores)
                {
                    msgText += elem + "\n";
                }
                MessageBox.Show(msgText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void dgSucursales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgSucursales.SelectedCells.Count > 1)
            {
                tbNombreCine.Text = dgSucursales.SelectedCells[dgSucursales.Columns["nombre"].Index].Value.ToString();
                nudSalasCine.Value = decimal.Parse(dgSucursales.SelectedCells[dgSucursales.Columns["num_salas"].Index].Value.ToString());
                tbColoniaSuc.Text = dgSucursales.SelectedCells[dgSucursales.Columns["colonia"].Index].Value.ToString();
                tbCalleSucursal.Text = dgSucursales.SelectedCells[dgSucursales.Columns["calle"].Index].Value.ToString();
                tbNumeroSucursal.Text = dgSucursales.SelectedCells[dgSucursales.Columns["numero"].Index].Value.ToString();
                tbTelefonoSucursal.Text = dgSucursales.SelectedCells[dgSucursales.Columns["telefono"].Index].Value.ToString();
                SwitchCamposSucural("Actualizar");
            }
        }

        private void dgSucursales_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgSucursales.SelectedCells.Count > 1)
            {
                tbNombreCine.Text = dgSucursales.SelectedCells[dgSucursales.Columns["nombre"].Index].Value.ToString();
                nudSalasCine.Value = decimal.Parse(dgSucursales.SelectedCells[dgSucursales.Columns["num_salas"].Index].Value.ToString());
                tbColoniaSuc.Text = dgSucursales.SelectedCells[dgSucursales.Columns["colonia"].Index].Value.ToString();
                tbCalleSucursal.Text = dgSucursales.SelectedCells[dgSucursales.Columns["calle"].Index].Value.ToString();
                tbNumeroSucursal.Text = dgSucursales.SelectedCells[dgSucursales.Columns["numero"].Index].Value.ToString();
                tbTelefonoSucursal.Text = dgSucursales.SelectedCells[dgSucursales.Columns["telefono"].Index].Value.ToString();
                SwitchCamposSucural("Actualizar");
            }
        }

        private void btnEditarSalas_Click(object sender, EventArgs e)
        {
            ControlSalas dlg = new ControlSalas(dgSucursales.SelectedCells[dgSucursales.Columns["clave_cin"].Index].Value.ToString());

            if(dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }

        #endregion

        #region Metodos Comunes
        private void tcPrincipal_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (tcPrincipal.SelectedTab.AccessibleName == "Ventas")
            {
                CargaClientes();
            }
        }

        private void tcPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            Conexion con;
            switch (tcAdministracion.SelectedTab.Text)
            {
                case "Empleado":
                    ObtenerRegistrosEmpleado();
                    break;
                case "Membresía":
                    ObtenerRegistrosMembresia();
                    break;
                case "Pelicula":
                    ObtenerRegistrosPelicula();
                    break;
                case "Sucursal":
                    con = new SucursalConexion();
                    if (!(con as SucursalConexion).CargaDatosGrid(dgSucursales))
                        MessageBox.Show("Error al llamar al servidor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SwitchCamposSucural("Deshabilitar");
                    break;
                case "Funcion":
                    ActualizaFecha();
                    ObtenerPeliculas();
                    ObtenerCines();
                    ObtenerRegistrosFuncion();
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
        private void ResetTimer_Tick(object sender, EventArgs e)
        {
            foreach (Control ctrl in gbSucursal.Controls)
            {
                if (ctrl.AccessibleName == "StatusLabel")
                    ctrl.Visible = false;
            }
            ResetTimer.Enabled = false;
        }

        #endregion

        #region Metodos Pestaña Funcion

        private void SwitchCamposFuncion(string caso)
        {

            switch (caso)
            {
                case "Habilitar":
                    btCancelarFun.Visible = true;
                    btActualizaFun.Enabled = false;
                    btEliminaFun.Enabled = false;
                    btInsertaFun.Enabled = false;
                    break;
                case "Deshabilitar":
                    btCancelarFun.Visible = false;
                    btActualizaFun.Enabled = false;
                    btEliminaFun.Enabled = false;
                    btInsertaFun.Enabled = true;
                    LimpiaCamposFuncion();
                    dgFunciones.ClearSelection();
                    break;
                case "Actualizar":
                    LimpiaFormularioFuncion();
                    btCancelarFun.Visible = true;
                    btActualizaFun.Enabled = true;
                    btEliminaFun.Enabled = true;
                    btInsertaFun.Enabled = false;
                    break;
            }
        }

        private void ActualizaFecha()
        {
            dpFechaFun.MinDate = DateTime.Now;
            dpFechaFun.Value = DateTime.Now.AddDays(30);
        }

        private void ObtenerRegistrosFuncion()
        {
            SqlDataAdapter adaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            if (conexion.AbrirConexion())
            {
                string txtCmd = "select * from Cine.funcion";
                SqlCommand cmd = new SqlCommand(txtCmd, conexion.con);

                try
                {
                    adaptador.SelectCommand = cmd;
                    adaptador.Fill(ds);
                    adaptador.Dispose();
                    cmd.Dispose();
                    dgFunciones.DataSource = ds.Tables[0];
                    dgFunciones.ClearSelection();
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

        private void ObtenerPeliculas() {
            SqlDataAdapter adaptador = new SqlDataAdapter();
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            if (conexion.AbrirConexion())
            {
                string txtCmd = "select * from Cine.pelicula";
                SqlCommand cmd = new SqlCommand(txtCmd, conexion.con);

                try
                {
                    adaptador.SelectCommand = cmd;
                    adaptador.Fill(dt);
                    adaptador.Dispose();
                    cmd.Dispose(); 
                    cbPelFun.DataSource = dt;
                    cbPelFun.DisplayMember = "nombre";
                    cbPelFun.ValueMember = "clave_pel";
                    cbPelFun.SelectedIndex = -1;
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

        private void ObtenerCines() {
            SqlDataAdapter adaptador = new SqlDataAdapter();
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            if (conexion.AbrirConexion())
            {
                string txtCmd = "select * from Cine.cine";
                SqlCommand cmd = new SqlCommand(txtCmd, conexion.con);

                try
                {
                    adaptador.SelectCommand = cmd;
                    adaptador.Fill(dt);
                    adaptador.Dispose();
                    cmd.Dispose();
                    cbCinFun.DataSource = dt;
                    cbCinFun.DisplayMember = "nombre";
                    cbCinFun.ValueMember = "clave_cin";
                    cbCinFun.SelectedIndex = -1;
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
        private void cbCinFun_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCine;
            if (cbCinFun.SelectedValue != null)
                if (int.TryParse(cbCinFun.SelectedValue.ToString(), out idCine))
                    ObtenerSalas(idCine);
        }

        private void ObtenerSalas(int idCine) {
            SqlDataAdapter adaptador = new SqlDataAdapter();
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            if (conexion.AbrirConexion())
            {
                string txtCmd = "select * from Cine.sala where clave_cin=" + idCine;
                SqlCommand cmd = new SqlCommand(txtCmd, conexion.con);

                try
                {
                    adaptador.SelectCommand = cmd;
                    adaptador.Fill(dt);
                    adaptador.Dispose();
                    cmd.Dispose();
                    cbSalFun.DataSource = dt;
                    cbSalFun.DisplayMember = "clave_sal";
                    cbSalFun.ValueMember = "clave_sal";
                    cbSalFun.SelectedIndex = -1;
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

        private void LimpiaCamposFuncion()
        {
            cbPelFun.SelectedIndex = -1;
            cbCinFun.SelectedIndex = -1;
            cbSalFun.SelectedIndex = -1;
        }

    

        private void RealizaAccionFun()
        {
            switch (opFun)
            {
                case 0: //Agregar Membresia
                    InsertaFuncion();
                    break;
                case 1://Actualizar Membresia
                    ActualizarFuncion();
                    break;
                default:
                    MessageBox.Show("Algo salio mal,Por favor vuelve a intentarlo");
                    break;
            }
        }

        private void btAceptarFun_Click(object sender, EventArgs e)
        {
            RealizaAccionFun();
        }

        private void btCancelarFun_Click(object sender, EventArgs e)
        {
            SwitchCamposFuncion("Deshabilitar");
            LimpiaFormularioFuncion();
        }

        private void LimpiaFormularioFuncion()
        {

            //Cambia texto
            lbPelFun.Text = "Pelicula";
            lbCinFun.Text = "Cine";
            lbSalFun.Text = "Sala";
            lbMensajeFun.Visible = false;
            //Cambia color
            lbPelFun.ForeColor = Color.LightGray;
            lbCinFun.ForeColor = Color.LightGray;
            lbSalFun.ForeColor = Color.LightGray;
        }

        private bool ValidaDatosFuncion()
        {
            bool valido = true;
            int error = 0;

            if (cbPelFun.Text == string.Empty) { lbPelFun.Text = "Pelicula *"; lbPelFun.ForeColor = Color.Red; error++; }
            if (cbCinFun.Text == string.Empty) { lbCinFun.Text = "Cine *"; lbCinFun.ForeColor = Color.Red; error++; }
            if (cbSalFun.Text == string.Empty) { lbSalFun.Text = "Sala *"; lbSalFun.ForeColor = Color.Red; error++; }

            if (error > 0) { CambiaTextoMensajeFun("* Campos requeridos", Color.Red); lbMensajeFun.Visible = true; valido = false; }

            return valido;
        }

        private void CambiaTextoMensajeFun(String mensaje, Color color)
        {
            lbMensajeFun.ForeColor = color;
            lbMensajeFun.Text = mensaje;
        }

        private void InsertaFuncion()
        {
            LimpiaFormularioFuncion();
            if (ValidaDatosFuncion())
            {
                if (conexion.AbrirConexion())
                {

                    string txtCmd = "INSERT INTO Cine.funcion(clave_pel,clave_sal,hora_ini,hora_fin,fecha)" +
                        "VALUES(" + cbPelFun.SelectedValue + "," + cbSalFun.SelectedValue + ",'" +
                         dpHoraIniFun.Value.Hour + ':' + dpHoraIniFun.Value.Minute + ':' +dpHoraIniFun.Value.Second + "','" +
                         dpHoraFinFun.Value.Hour + ':' + dpHoraFinFun.Value.Minute + ':' + dpHoraFinFun.Value.Second + 
                         "','" + dpFechaFun.Value.Day + "/" + dpFechaFun.Value.Month + "/" +dpFechaFun.Value.Year + "')";
                    SqlCommand cmd = new SqlCommand(txtCmd, conexion.con);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        ObtenerRegistrosFuncion();
                        CambiaTextoMensajeFun("Se agrego correctamente!", Color.Blue);
                        lbMensajeFun.Visible = true;
                        LimpiaCamposFuncion();
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

        private void ActualizarFuncion()
        {
            string clave_fun;
            if ((clave_fun=RenglonSeleccionadoFun()) != "")
            {
                if (ValidaDatosFuncion())
                {
                    if (MessageBox.Show("¿Esta seguro de querer actualizar la \n información de esta funcion?", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (conexion.AbrirConexion())
                        {
                            string txtCmd = "update Cine.funcion set clave_pel=" +
                                cbPelFun.SelectedValue + ", clave_sal=" + cbSalFun.SelectedValue +
                                ", hora_ini='" + dpHoraIniFun.Value.Hour + ':' + dpHoraIniFun.Value.Minute + ':' + dpHoraIniFun.Value.Second +
                                "', hora_fin='" + dpHoraFinFun.Value.Hour + ':' + dpHoraFinFun.Value.Minute + ':' + dpHoraFinFun.Value.Second +
                                "', fecha='" + dpFechaFun.Value.Year + "/" + dpFechaFun.Value.Month + "/" + dpFechaFun.Value.Day +
                                "' where clave_fun=" + clave_fun;

                            SqlCommand cmd = new SqlCommand(txtCmd, conexion.con);

                            try
                            {
                                cmd.ExecuteNonQuery();
                                ObtenerRegistrosFuncion();
                                CambiaTextoMensajeFun("Se actualizo correctamente!", Color.Blue);
                                lbMensajeFun.Visible = true;
                                LimpiaCamposFuncion();
                                SwitchCamposFuncion("Deshabilitar");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Error al llamar al servidor");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Primero selecciona la <Funcion> que se desea actualizar", "Atención");
            }
        }

        private void EliminarFuncion()
        {
            string clave_fun;

            if ((clave_fun = RenglonSeleccionadoFun()) != "")
            {
                if (MessageBox.Show("¿Esta seguro de querer eliminar esta Funcion?", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    if (conexion.AbrirConexion())
                    {
                        string txtCmd = "delete from Cine.funcion where clave_fun = " + clave_fun;
                        SqlCommand cmd = new SqlCommand(txtCmd, conexion.con);
                        try
                        {
                            cmd.ExecuteNonQuery();
                            ObtenerRegistrosFuncion();
                            CambiaTextoMensajeFun("Se elimino correctamente!", Color.Blue);
                            LimpiaCamposFuncion();
                            SwitchCamposFuncion("Deshabilitar");
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
            else MessageBox.Show("Primero selecciona la <Funcion> que se desea eliminar", "Atención");
        }

        private void btInsertaFun_Click(object sender, EventArgs e)
        {
            InsertaFuncion();
        }

        private void btActualizaFun_Click(object sender, EventArgs e)
        {
            ActualizarFuncion();
        }
        private void btEliminaFun_Click(object sender, EventArgs e)
        {
            EliminarFuncion();
        }

        private string RenglonSeleccionadoFun()
        {
            string renglon;
            try { renglon = dgFunciones.SelectedCells[0].Value.ToString(); }
            catch { renglon = string.Empty; }
            return renglon;
        }
        private void dgFunciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionaRegistroFun();
            SwitchCamposFuncion("Actualizar");
        }
        private void dgFunciones_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SeleccionaRegistroFun();
            SwitchCamposFuncion("Actualizar");
        }
        private void SeleccionaRegistroFun()
        {
            if (dgFunciones.SelectedCells.Count > 1)
            {
                cbPelFun.SelectedValue = dgFunciones.SelectedCells[dgFunciones.Columns["clave_pel"].Index].Value;
                cbCinFun.SelectedValue = SalaPerteneceACine(dgFunciones.SelectedCells[dgFunciones.Columns["clave_sal"].Index].Value.ToString());
                cbSalFun.SelectedValue = dgFunciones.SelectedCells[dgFunciones.Columns["clave_sal"].Index].Value;
                dpHoraIniFun.Text = dgFunciones.SelectedCells[dgFunciones.Columns["hora_ini"].Index].Value.ToString();
                dpHoraFinFun.Text = dgFunciones.SelectedCells[dgFunciones.Columns["hora_fin"].Index].Value.ToString();
                dpFechaFun.Text = dgFunciones.SelectedCells[dgFunciones.Columns["fecha"].Index].Value.ToString();
            }
        }

        private string SalaPerteneceACine(string idSala)
        {
            string idCine = "-1";
            SqlDataAdapter adaptador = new SqlDataAdapter();
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            if (conexion.AbrirConexion())
            {
                string txtCmd = "SELECT * FROM Cine.sala WHERE clave_sal=" + idSala;
                SqlCommand cmd = new SqlCommand(txtCmd, conexion.con);

                try
                {
                    adaptador.SelectCommand = cmd;
                    adaptador.Fill(dt);
                    adaptador.Dispose();
                    cmd.Dispose();
                    idCine = dt.Rows[0]["clave_cin"].ToString();
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
            return idCine;
        }
        #endregion

        #region Metodos pestaña ventas
        private void CargaClientes()
        {
            ClienteConexion conexion = new ClienteConexion();
            List<Cliente> listaClientes = conexion.ObtenClientes();
            cbClienteVenta.DataSource = listaClientes;
            cbClienteVenta.DisplayMember = "nombreCompleto";
            cbClienteVenta.SelectedIndex = -1;
        }

        private void GeneraButacas(int cupo)
        {
            PictureBox butaca;
            Label lbl;
            int x, y, numButacas, tamButaca, separacion, tamEtiqueta, butacasHilera;
            char fila;
            List<Control> listaControles = new List<Control>();
            VentaConexion conexion = new VentaConexion();
            List<string> listaButacas;

            fila = 'A';
            x = y = 30;
            tamButaca = 48;
            numButacas = cupo;
            separacion = 5;
            tamEtiqueta = 25;
            butacasHilera = 0;
            listaButacas = conexion.ObtenButacasOcupadas((cbHoraFuncionVenta.SelectedValue as Funcion).clave_fun);
            foreach (Control ctrl in VentaContainer.Panel2.Controls)
                ctrl.Dispose();
            VentaContainer.Panel2.Controls.Clear();
            lbl = new Label()
            {
                Name = "lbFila" + fila,
                Text = fila.ToString(),
                ForeColor = Color.DodgerBlue,
                Location = new System.Drawing.Point(5, y + (tamButaca / 3)),
                Size = new Size(tamEtiqueta, tamEtiqueta)
            };
            listaControles.Add(lbl);
            for (int i = 0; i < numButacas; i++)
            {
                if (x > VentaContainer.Panel2.Width - (tamButaca + separacion))
                {
                    x = 30;
                    y += tamButaca + separacion;
                    fila++;
                    lbl = new Label()
                    {
                        Name = "lbFila" + fila,
                        Text = fila.ToString(),
                        ForeColor = Color.DodgerBlue,
                        Location = new System.Drawing.Point(5, y + (tamButaca / 3)),
                        Size = new Size(tamEtiqueta, tamEtiqueta)
                    };
                    listaControles.Add(lbl);
                }
                if (y == 30)
                {
                    lbl = new Label()
                    {
                        Name = "lbNumero" + i.ToString(),
                        Text = i.ToString(),
                        ForeColor = Color.DodgerBlue,
                        Location = new System.Drawing.Point(x + (tamButaca / 3), 5),
                        Size = new Size(tamEtiqueta, tamEtiqueta)
                    };
                    butacasHilera++;
                    listaControles.Add(lbl);
                }
                butaca = new PictureBox()
                {
                    BackgroundImage = global::cinemax.Properties.Resources.butaca,
                    BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom,
                    Location = new System.Drawing.Point(x, y),
                    Name = "pbButaca" + i.ToString(),
                    AccessibleName = (fila).ToString() + (i % butacasHilera).ToString(),
                    Size = new System.Drawing.Size(tamButaca, tamButaca)
                };
                if (listaButacas.FirstOrDefault(b => b == butaca.AccessibleName) == null)
                {
                    butaca.Cursor = System.Windows.Forms.Cursors.Hand;
                    butaca.BackColor = Color.Transparent;
                    butaca.Click += butaca_Click;
                }
                else
                {
                    butaca.Cursor = System.Windows.Forms.Cursors.Arrow;
                    butaca.BackColor = Color.Firebrick;
                }
                x += tamButaca + separacion;
                listaControles.Add(butaca);
            }
            butaca = new PictureBox()
            {
                BackColor = Color.Black,
                Location = new System.Drawing.Point(VentaContainer.Panel2.Width / 2 - 200, y + (tamButaca * 2)),
                Name = "pbPantalla",
                Size = new System.Drawing.Size(400, 20),
            };
            listaControles.Add(butaca);
            VentaContainer.Panel2.Controls.AddRange(listaControles.ToArray());
        }

        void butaca_Click(object sender, EventArgs e)
        {
            if ((sender as PictureBox).BackColor == Color.Transparent)
            {
                (sender as PictureBox).BackColor = Color.SteelBlue;
                (sender as PictureBox).AccessibleDescription = "Active";
                contadorButacas++;
            }
            else
            {
                (sender as PictureBox).BackColor = Color.Transparent;
                (sender as PictureBox).AccessibleDescription = "Inactive";
                contadorButacas--;
            }
        }
        
        private void dgEmpleados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgEmpleados.Columns[e.ColumnIndex].Name == "contraseña" && e.Value != null)
            {
                dgEmpleados.Rows[e.RowIndex].Tag = e.Value;
                e.Value = new String('*', 10);
            }
        }

        private void cbClienteVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex != -1)
            {
                SucursalConexion conexion = new SucursalConexion();
                List<Cine> listaSucursales = conexion.ObtenSucursales();
                cbCineVenta.DataSource = listaSucursales;
                cbCineVenta.DisplayMember = "nombre";
                cbCineVenta.SelectedIndex = -1;
                cbCineVenta.Enabled = true;
            }
            else
            {
                cbCineVenta.SelectedIndex = -1;
                cbCineVenta.Enabled = false;
            }
        }

        private void cbCineVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex != -1)
            {
                FuncionConexion conexion = new FuncionConexion();
                List<Funcion> listaFunciones = conexion.ObtenPeliculas(((sender as ComboBox).SelectedValue as Cine).clave_cin);
                cbFuncionVenta.DataSource = listaFunciones;
                cbFuncionVenta.DisplayMember = "nombre_pelicula";
                cbFuncionVenta.SelectedIndex = -1;
                cbFuncionVenta.Enabled = true;
            }
            else
                cbFuncionVenta.Enabled = false;
        }

        private void cbFuncionVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex != -1)
            {
                FuncionConexion conexion = new FuncionConexion();
                List<Funcion> listaFunciones = conexion.ObtenFunciones((cbCineVenta.SelectedValue as Cine).clave_cin,
                    ((sender as ComboBox).SelectedValue as Funcion).nombre_pelicula);
                cbHoraFuncionVenta.DataSource = listaFunciones;
                cbHoraFuncionVenta.DisplayMember = "hora_ini";
                cbHoraFuncionVenta.SelectedIndex = -1;
                cbHoraFuncionVenta.Enabled = true;
            }
            else
                cbHoraFuncionVenta.Enabled = false;
        }

        private void cbHoraFuncionVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex != -1)
            {
                tbSalaVenta.Text = ((sender as ComboBox).SelectedValue as Funcion).clave_sal.ToString();
                rbEfectivo.Enabled = true;
                rbTarjeta.Enabled = true;
            }
            else
            {
                muestraButacas = false;
                tbSalaVenta.Clear();
                rbEfectivo.Enabled = false;
                rbTarjeta.Enabled = false;
            }
        }

        private void rbEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                tbNumTarjeta.Enabled = false;
                tbCodSeguridad.Enabled = false;
                tbMesVenc.Enabled = false;
                tbAnoVenc.Enabled = false;
            }
            else
            {
                tbNumTarjeta.Enabled = true;
                tbCodSeguridad.Enabled = true;
                tbMesVenc.Enabled = true;
                tbAnoVenc.Enabled = true;
            }
            btnGenerarVenta.Enabled = true;
        }

        private void cbHoraFuncionVenta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SucursalConexion conexion = new SucursalConexion();
            int cupoSala = conexion.ObtenCupoSala((cbHoraFuncionVenta.SelectedValue as Funcion).clave_sal);
            GeneraButacas(cupoSala);
        }

        private void btnGenerarVenta_Click(object sender, EventArgs e)
        {
            VentaConexion conexion = new VentaConexion();
            List<string> listaButacas;
            bool ventaGenerada;
            float subtotal;

            subtotal = 35;
            // Busqueda de butacas seleccionadas
            listaButacas = (from Control c in VentaContainer.Panel2.Controls
                            where (Regex.IsMatch(c.Name, "^pbButaca") && c.AccessibleDescription == "Active")
                            select c.AccessibleName).ToList();
            if (ValidaControlesVenta() && ConfirmaVenta(listaButacas, subtotal))
            {
                // Generación de la venta
                ventaGenerada = conexion.GeneraVenta((cbClienteVenta.SelectedValue as Cliente).clave_mem.ToString(),
                    (cbHoraFuncionVenta.SelectedValue as Funcion).clave_fun.ToString(),
                    clave_emp.ToString(),
                    tbNumTarjeta.Text,
                    tbCodSeguridad.Text,
                    tbAnoVenc.Text != string.Empty ? new DateTime(int.Parse(tbAnoVenc.Text), int.Parse(tbMesVenc.Text), 1) : DateTime.Now,
                    listaButacas,
                    rbEfectivo.Checked,
                    subtotal,
                    "Normal");
                if (ventaGenerada)
                {
                    MessageBox.Show("Venta generada satisfactoriamente", "Cinemax", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbHoraFuncionVenta_SelectionChangeCommitted(this, null);
                }
                else
                    MessageBox.Show("Venta no generada", "Cinemax", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool ValidaControlesVenta()
        {
            bool success = true;
            string validaciones = string.Empty;

            if (contadorButacas <= 0)
            {
                success = false;
                validaciones += "Por favor seleccione los asientos para la función\r\n";
            }
            else if(!rbEfectivo.Checked)
            {
                if (!Regex.IsMatch(tbNumTarjeta.Text, @"^[0-9]+$"))
                {
                    success = false;
                    validaciones += "Por favor ingrese un número de tarjeta válido\r\n";
                }
                if (!Regex.IsMatch(tbCodSeguridad.Text, @"^[0-9]{3}$"))
                {
                    success = false;
                    validaciones += "Por favor ingrese un código de seguridad a 3 dígitos\r\n";
                }
                if (!Regex.IsMatch(tbMesVenc.Text, @"^([0][1-9])|([1][0-2])$"))
                {
                    success = false;
                    validaciones += "Por favor ingrese un mes válido\r\n";
                }
                if (!Regex.IsMatch(tbAnoVenc.Text, @"^[2]([0-9]{3})$") || (DateTime.Now.Year.CompareTo(int.Parse(tbAnoVenc.Text)) > 0) )
                {
                    success = false;
                    validaciones += "Por favor ingrese un año válido\r\n";
                }
            }
            if(!success)
               MessageBox.Show(validaciones, "Venta de tickets", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return success;
        }

        private bool ConfirmaVenta(List<string> listaButacas, float precio)
        {
            string mensajeConf = string.Empty;
            float total = 0;
            
            mensajeConf += "Cliente:\r\n" + (cbClienteVenta.SelectedValue as Cliente).nombreCompleto.ToString();
            mensajeConf += "\r\nCine: \r\n" + (cbCineVenta.SelectedValue as Cine).nombre.ToString();
            mensajeConf += "\r\nFunción: \r\n" + (cbFuncionVenta.SelectedValue as Funcion).nombre_pelicula.ToString();
            mensajeConf += "\r\nHora: \r\n" + (cbHoraFuncionVenta.SelectedValue as Funcion).hora_ini.ToString();
            mensajeConf += "\r\nSala: \r\n" + (cbHoraFuncionVenta.SelectedValue as Funcion).clave_sal.ToString() + "\r\n\r\n";
            foreach (string butaca in listaButacas)
            {
                mensajeConf += "Asiento " + butaca + " :\t\t$" + precio.ToString() + "\r\n";
                total += precio;
            }
            mensajeConf += "*********************************\r\n TOTAL:\t\t\t$" + total;
            return (MessageBox.Show(mensajeConf, "Confirmación de venta", MessageBoxButtons.OKCancel, MessageBoxIcon.None) == DialogResult.OK) ?
                true :
                false;
        }
        #endregion
    }
}
