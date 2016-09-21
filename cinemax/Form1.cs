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
        private int opEmp = -1;
        private int opMem = -1;
        #endregion

        #region Metodos Constructor y Load
        public Form1()
        {
            InitializeComponent();
            conexion = new Conexion();
            this.BackgroundImage = cinemax.Properties.Resources.fondo2;
            dgEmpleados.MultiSelect = false;            
            dgEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgMembresias.MultiSelect = false;
            dgMembresias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
                        MessageBox.Show("Se agrego correctamente!","Información");                        
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
                            MessageBox.Show("Se elimino correctamente!!");
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
            }else MessageBox.Show("Primero selecciona al <Empleado> que se desea eliminar","Atención");
        }

        private string RenglonSeleccionadoEmp()
        {
            string renglon;
            try { renglon = dgEmpleados.SelectedCells[0].Value.ToString(); }
            catch { renglon = string.Empty; }
            return renglon;
        }
        private void dgEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

            string clave_emp;
            if ((clave_emp = RenglonSeleccionadoEmp()) != "")
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
                        MessageBox.Show("Se actualizo correctamente!","Información");
                        LimpiaCamposEmpleado();
                        BotonesAccionEmp(false);
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
            if (RenglonSeleccionadoEmp() != "")
            {
                opEmp = 1;
                BotonesAccionEmp(true);
                tbNombreEmp.Focus();
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

        #region Metodos Comunes
        private void tcPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tcAdministracion.SelectedTab.Text)
            {
                case "Empleado":
                    ObtenerRegistrosEmpleado();
                    break;
                case "Membresía":
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
            opMem = 0;
            LimpiaCamposMembresia();
            BotonesAccionMem(true);
            tbNombreMem.Focus();
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
                        MessageBox.Show("Se agrego correctamente!", "Información"); 
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
                tbNombreMem.Focus();
            }
            else
            {
                MessageBox.Show("Primero selecciona al <Membresia> que se desea actualizar", "Atención");
            }
        }

        private void ActualizarMembresia()
        {
            string clave_mem;
            if ((clave_mem = RenglonSeleccionadoMem()) != "")
            {
                if (conexion.AbrirConexion())
                {
                    string txtCmd = "update Persona.membresia set nombre='" +
                        tbNombreMem.Text + "', app='" + tbAppMem.Text +
                        "', apm='" + tbApmMem.Text + "', fecha_nac='" +
                        dpFechaMem.Value.Year + "/" + dpFechaMem.Value.Month + "/" + dpFechaMem.Value.Day +
                        "', colonia='" + tbColoniaMem.Text + "', calle='" + tbCalleMem.Text +
                        "', numero=" + tbNumeroMem.Text + ", tipo='" + cbTipoMem.SelectedItem.ToString() + "', puntos=" + nuPuntosMem.Value.ToString() +
                        " where clave_mem=" + clave_mem;
                   
                    SqlCommand cmd = new SqlCommand(txtCmd, conexion.con);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        ObtenerRegistrosMembresia();
                        MessageBox.Show("Se actualizo correctamente!", "Información");
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

        private void dgMembresias_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                            MessageBox.Show("Se elimino correctamente!!");
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
            else MessageBox.Show("Primero selecciona al <Membresia> que se desea eliminar", "Atención");
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








        
    }
}
