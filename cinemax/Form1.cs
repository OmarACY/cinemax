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

namespace cinemax
{
    public partial class Cinemax : Form
    {

        #region Atributos
        private Point formPosition;
        private bool mouseAction;
        private Conexion conexion;
        private int opEmp = -1;
        private int opMem = -1;
        private int opPel = -1;
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
            opEmp = 0;
            LimpiaCamposEmpleado();
            BotonesAccionEmp(true);
            tbNombreEmp.Focus();
        }
        private void InsertaEmpleado() {
            LimpiaFormularioEmpleado();
            if (ValidaDatosEmpleado())
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
                        CambiaTextoMensajeEmp("Se agrego correctamente!",Color.Blue);
                        lbMensaje.Visible = true;                     
                        LimpiaCamposEmpleado();
                        BotonesAccionMem(false);
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
                            BotonesAccionEmp(false);
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
        }

        private void dgEmpleados_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SeleccionaRegistroEmp();
        }

        private void SeleccionaRegistroEmp()
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

            string clave_emp = RenglonSeleccionadoEmp();
            if (ValidaDatosEmpleado())
            {
                if (conexion.AbrirConexion())
                {
                    string txtCmd = "update Persona.empleado set nombres='" +
                        tbNombreEmp.Text + "', app='" + tbAppEmp.Text +
                        "', apm='" + tbApmEmp.Text + "', fecha_nac='" +
                        dpFechaEmp.Value.Year + "/" + dpFechaEmp.Value.Month + "/" + dpFechaEmp.Value.Day +
                        "', colonia='" + tbColoniaEmp.Text + "', calle='" + tbCalleEmp.Text +
                        "', numero='" + tbNumeroEmp.Text + "' where clave_emp=" + clave_emp;

                    SqlCommand cmd = new SqlCommand(txtCmd, conexion.con);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        ObtenerRegistrosEmpleado();
                        CambiaTextoMensajeEmp("Se actualizo correctamente!", Color.Blue);
                        lbMensaje.Visible = true;
                        LimpiaCamposEmpleado();
                        BotonesAccionEmp(false);
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


        private void btActualizaEmpleado_Click(object sender, EventArgs e)
        {            
            if (RenglonSeleccionadoEmp() != "")
            {
                opEmp = 1;
                BotonesAccionEmp(true);
            }
            else {
                MessageBox.Show("Primero selecciona al <Empleado> que se desea actualizar", "Atención");
            }
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
        private void btAceptarEmp_Click(object sender, EventArgs e)
        {
            RealizaAccionEmp();
        }

        private void RealizaAccionEmp() {
            switch (opEmp)
            {
                case 0: //Agregar
                    InsertaEmpleado();                    
                    break;
                case 1://Actualizar
                    ActualizarEmpleado();
                    break;
                default:
                    MessageBox.Show("Algo salio mal,Por favor vuelve a intentarlo");
                    break;
            } 
        }

        private void BotonesAccionEmp(bool activo) {
            btAceptarEmp.Visible = activo;
            btCancelarEmp.Visible = activo;
            gbDPEmp.Enabled = activo;
            gbDCEmp.Enabled = activo;
            dgEmpleados.Enabled = !activo;
            btInsertaEmpleado.Enabled = !activo;
            btEliminaEmpleado.Enabled = !activo;
            btActualizaEmpleado.Enabled = !activo;
        }

        private void btCancelarEmp_Click(object sender, EventArgs e)
        {
            LimpiaFormularioEmpleado();
            LimpiaCamposEmpleado();
            BotonesAccionEmp(false);
            dgEmpleados.ClearSelection();
        }
        
        #endregion

        #region Metodos Pestaña Membresia

        private void btInsertaMem_Click(object sender, EventArgs e)
        {
            opMem = 0;
            LimpiaCamposMembresia();
            BotonesAccionMem(true);
            tbNombreMem.Focus();
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
                        CambiaTextoMensajeMem("Se actualizo correctamente!", Color.Blue);
                        lbMensajeMem.Visible = true;
                        LimpiaCamposMembresia();
                        BotonesAccionMem(false);
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
            if (RenglonSeleccionadoMem() != "")
            {
                opMem = 1;
                BotonesAccionMem(true);
            }
            else
            {
                MessageBox.Show("Primero selecciona al <Membresia> que se desea actualizar", "Atención");
            }
        }

        private void ActualizarMembresia()
        {
            string clave_mem = RenglonSeleccionadoMem();
            if (ValidaDatosMembresia())
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
                        BotonesAccionMem(false);
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
        }

        private void dgMembresias_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SeleccionaRegistroMem();
        }

        private void SeleccionaRegistroMem()
        {
            if (dgMembresias.SelectedCells.Count > 1)
            {
                tbNombreMem.Text = dgMembresias.SelectedCells[dgMembresias.Columns["nombre"].Index].Value.ToString();
                tbAppMem.Text = dgMembresias.SelectedCells[dgMembresias.Columns["app"].Index].Value.ToString();
                tbApmMem.Text = dgMembresias.SelectedCells[dgMembresias.Columns["apm"].Index].Value.ToString();
                string fecha = dgMembresias.SelectedCells[dgMembresias.Columns["fecha_nac"].Index].Value.ToString();
                string[] f = fecha.Split('/');
                dpFechaMem.Text = f[0] + '/' + f[1] + '/' + f[2];
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
                            BotonesAccionMem(false);
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

        private void btAceptarMem_Click(object sender, EventArgs e)
        {
            RealizaAccionMem();
        }

        private void RealizaAccionMem()
        {
            switch (opMem)
            {
                case 0: //Agregar Membresia
                    InsertaMembresia();                    
                    break;
                case 1://Actualizar Membresia
                    ActualizarMembresia();
                    break;
                default:
                    MessageBox.Show("Algo salio mal,Por favor vuelve a intentarlo");
                    break;
            }
        }
        private void BotonesAccionMem(bool activo)
        {
            btAceptarMem.Visible = activo;
            btCancelarMem.Visible = activo;
            gbDPMem.Enabled = activo;
            gbDCMem.Enabled = activo;
            gbDMem.Enabled = activo;
            dgMembresias.Enabled = !activo;
            btInsertaMem.Enabled = !activo;
            btEliminaMem.Enabled = !activo;
            btActualizaMem.Enabled = !activo;
        }
        private void btCancelarMem_Click(object sender, EventArgs e)
        {
            LimpiaFormularioMembresia();
            LimpiaCamposMembresia();
            BotonesAccionMem(false);
            dgMembresias.ClearSelection();
        }

        #endregion

        #region Metodos pestaña peliculas
        private void btAgregarPel_Click(object sender, EventArgs e)
        {
            opPel = 0;
            LimpiaCamposPelicula();
            BotonesAccionPel(true);
            tbNombrePel.Focus();
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
                        CambiaTextoMensajePel("Se actualizo correctamente!", Color.Blue);
                        lbMensajePel.Visible = true;
                        LimpiaCamposPelicula();
                        BotonesAccionPel(false);
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
            lbNombreMem.Text = "Nombre";
            lbDirectorPel.Text = "Direcctor";
            lbClasificacionPel.Text = "Clasificación";
            lbGeneroPel.Text = "Genero";
            lbSinopsisPel.Text = "Sinopsis";
            lbMensajePel.Visible = false;
            //Cambia color
            lbNombreMem.ForeColor = Color.LightGray;
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

        private void BotonesAccionPel(bool activo)
        {
            btAceptarPel.Visible = activo;
            btCancelarPel.Visible = activo;
            gbDGPel.Enabled = activo;
            dgPeliculas.Enabled = !activo;
            btInsertaPel.Enabled = !activo;
            btEliminaPel.Enabled = !activo;
            btActualizaPel.Enabled = !activo;
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
            LimpiaFormularioPelicula();
            LimpiaCamposPelicula();
            BotonesAccionPel(false);
            dgPeliculas.ClearSelection();
        }

        private void dgPeliculas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionaRegistroPel();
        }

        private void dgPeliculas_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SeleccionaRegistroPel();
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
        private void btAceptarPel_Click(object sender, EventArgs e)
        {
            RealizaAccionPel();
        }

        private void RealizaAccionPel()
        {
            switch (opPel)
            {
                case 0: //Agregar Pelicula
                    InsertaPelicula();
                    break;
                case 1://Actualizar Pelicula
                    ActualizarPelicula();
                    break;
                default:
                    MessageBox.Show("Algo salio mal,Por favor vuelve a intentarlo");
                    break;
            }
        }

        private void btActualizaPel_Click(object sender, EventArgs e)
        {
            if (RenglonSeleccionadoPel() != "")
            {
                opPel = 1;
                BotonesAccionPel(true);
            }
            else
            {
                MessageBox.Show("Primero selecciona al <Pelicula> que se desea actualizar", "Atención");
            }
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
            string clave_pel = RenglonSeleccionadoPel();
            if (ValidaDatosPelicula())
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
                        BotonesAccionPel(false);
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
                            BotonesAccionPel(false);
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
            SwitchCamposSucural("Habilitar");
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

                /* Deshabilitación de campos de captura */
                SwitchCamposSucural("Deshabilitar");
                /* Actualización del grid */
                tcPrincipal_SelectedIndexChanged(this, null);
            }
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
                    gbInfoSucursal.Enabled = true;
                    gbUbicacionSucursal.Enabled = true;
                    btnAceptarSuc.Visible = true;
                    btnCancelarSuc.Visible = true;
                    btnActualizarSuc.Enabled = false;
                    btnEliminarSuc.Enabled = false;
                    btnAgregarSuc.Enabled = false;
                    nudSalasCine.Enabled = true;
                    btnEditarSalas.Visible = false;
                    labelSalasSucursal.Visible = false;
                    break;
                case "Deshabilitar":
                    gbInfoSucursal.Enabled = false;
                    gbUbicacionSucursal.Enabled = false;
                    btnAceptarSuc.Visible = false;
                    btnCancelarSuc.Visible = false;
                    btnActualizarSuc.Enabled = false;
                    btnEliminarSuc.Enabled = false;
                    btnAgregarSuc.Enabled = true;
                    tbNombreCine.Text = string.Empty;
                    nudSalasCine.Value = 0;
                    tbColoniaSuc.Text = string.Empty;
                    tbCalleSucursal.Text = string.Empty;
                    tbNumeroSucursal.Text = string.Empty;
                    tbTelefonoSucursal.Text = string.Empty;
                    btnEditarSalas.Visible = false;
                    labelSalasSucursal.Visible = false;
                    break;
                case "Actualizar":
                    gbInfoSucursal.Enabled = true;
                    gbUbicacionSucursal.Enabled = true;
                    btnCancelarSuc.Visible = true;
                    btnAgregarSuc.Enabled = false;
                    btnActualizarSuc.Enabled = true;
                    btnEliminarSuc.Enabled = true;
                    btnAceptarSuc.Visible = false;
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






 
    }
}
