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
    public partial class frmFicha : Form
    {
        public frmFicha()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmBusCliFicha ficha = new frmBusCliFicha();
            ficha.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dtpproxcita.Checked==false)
            {
                MessageBox.Show("Indique la fecha de la proxima cita");
                return;
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
          // dtgficha.Rows.Add(dtpfechaAtencion.Value.ToString("dd/MM/yyyy"), dtpfecha.Value.ToString("dd/MM/yyyy"), txtraza.Text, txtespecie.Text, cmbsexo.Text, txtcapa.Text, txtobs.Text);

        }
    }
}
