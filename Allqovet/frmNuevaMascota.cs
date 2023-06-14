using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Allqovet
{
    public partial class frmNuevaMascota : Form
    {
        public frmNuevaMascota()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text.Length == 0)
            {
                MessageBox.Show("Ingrese el nombre");
                return;
            }

            if (txtraza.Text.Length == 0)
            {
                MessageBox.Show("Ingrese la raza");
                return;
            }

            if (txtespecie.Text.Length == 0)
            {
                MessageBox.Show("Ingrese la especie");
                return;
            }

            if (dtpfecha.Checked == false)
            {
                MessageBox.Show("Ingrese la fecha de nacimiento");
                return;
            }

            if (cmbsexo.SelectedIndex == 0)
            {
                MessageBox.Show("Ingrese el sexo");
                return;
            }

            if (txtcapa.Text.Length == 0)
            {
                MessageBox.Show("Ingrese la capa");
                return;
            }

            frmNuevoCliente frm = Application.OpenForms.OfType<frmNuevoCliente>().SingleOrDefault();
            frm.dtgmascotas.Rows.Add(txtnombre.Text, dtpfecha.Value.ToString("dd/MM/yyyy"), txtraza.Text, txtespecie.Text, cmbsexo.Text, txtcapa.Text, txtobs.Text);
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNuevaMascota_Load(object sender, EventArgs e)
        {
            cmbsexo.SelectedIndex = 0;
        }
    }
}
