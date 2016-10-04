using cinemax.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cinemax
{
    public partial class Login : Form
    {
        private List<Empleado> listaEmpleados;
        public bool loginStatus;
        public long clave_emp;

        public Login()
        {
            InitializeComponent();
            loginStatus = false;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            EmpleadoConexion conexion = new EmpleadoConexion();

            if (conexion.AbrirConexion())
            {
                conexion.CerrarConexion();
                listaEmpleados = conexion.ObtenEmpleados();
                if (listaEmpleados.Count > 0)
                {
                    cbCveEmpleados.DataSource = listaEmpleados;
                    cbCveEmpleados.DisplayMember = "clave_emp";
                }
                else
                {
                    clave_emp = -1;
                    loginStatus = true;
                    Close();
                }
            }
            else
            {
                MessageBox.Show("No se puede establecer conexión con la base de datos \n El programa se cerrará", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void cbCveEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbNombreEmpledo.Text = (cbCveEmpleados.SelectedValue as Empleado).nombres + " " + (cbCveEmpleados.SelectedValue as Empleado).app + " " + (cbCveEmpleados.SelectedValue as Empleado).apm;
        }


        private void btSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if ((cbCveEmpleados.SelectedValue as Empleado).contraseña.CompareTo(tbContraseña.Text) == 0)
            {
                clave_emp = (cbCveEmpleados.SelectedValue as Empleado).clave_emp;
                loginStatus = true;
                Close();
            }
            else
                MessageBox.Show("Contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
