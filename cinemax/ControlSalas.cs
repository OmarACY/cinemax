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
    public partial class ControlSalas : Form
    {
        private string ClaveSucursal;
        private List<Sala> listaSalas;

        public ControlSalas(string claveSucursal)
        {
            InitializeComponent();
            ClaveSucursal = claveSucursal;
        }

        private void ControlSalas_Load(object sender, EventArgs e)
        {
            SucursalConexion conexion = new SucursalConexion();

            listaSalas = conexion.ObtenSalas(ClaveSucursal);
            cbSalas.DataSource = listaSalas;
            cbSalas.DisplayMember = "clave_sal";
        }

        private void cbSalas_SelectedIndexChanged(object sender, EventArgs e)
        {
            nudCupo.Value = (cbSalas.SelectedValue as Sala).cupo;
        }

        private void nudCupo_ValueChanged(object sender, EventArgs e)
        {
            listaSalas.FirstOrDefault(l => l.clave_sal == (cbSalas.SelectedValue as Sala).clave_sal).cupo = (int)nudCupo.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SucursalConexion conexion = new SucursalConexion();

            if (!conexion.ActualizaSalas(listaSalas, ClaveSucursal))
                MessageBox.Show("La información de una o más salas no fue actualizada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
