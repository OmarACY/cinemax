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
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LimpiaFormularioEmpleado();
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
                conexion.AbrirConexion();

                string txtCmd = "INSERT INTO Persona.empleado(nombres,app,apm,fecha_nac,colonia,calle,numero)" +
                    "VALUES('" + tbNombreEmp.Text + "','" + tbAppEmp.Text + "','" + tbApmEmp.Text + "','" +
                    dpFechaEmp.Value.Year + "/" + dpFechaEmp.Value.Month + "/" + dpFechaEmp.Value.Day + "','" + tbColoniaEmp.Text + "','" + 
                    tbCalleEmp.Text + "'," + tbNumeroEmp.Text + ")";
                    SqlCommand cmd = new SqlCommand(txtCmd, conexion.con);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("El empleado se agrego correctamente!!");
                        //LimpiaCamposEmpleado();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
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
            lbMensaje.Text = string.Empty;
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
       
            if (error > 0) { lbMensaje.Text = "*  Campos requieridos"; valido = false; }

            return valido;
        }
        #endregion

   
        
    }
}
