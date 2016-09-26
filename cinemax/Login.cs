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

        public Login()
        {
            InitializeComponent();
            loginStatus = false;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            EmpleadoConexion conexion = new EmpleadoConexion();

            listaEmpleados = conexion.ObtenEmpleados();
            cbCveEmpleados.DataSource = listaEmpleados;
            cbCveEmpleados.DisplayMember = "clave_emp";
        }

        private void cbCveEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbNombreEmpledo.Text = (cbCveEmpleados.SelectedValue as Empleado).nombres + " " + (cbCveEmpleados.SelectedValue as Empleado).app + " " + (cbCveEmpleados.SelectedValue as Empleado).apm;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if ((cbCveEmpleados.SelectedValue as Empleado).contraseña.CompareTo(tbContraseña.Text) == 0)
            {
                loginStatus = true;
                Close();
            }
            else
                MessageBox.Show("Contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
