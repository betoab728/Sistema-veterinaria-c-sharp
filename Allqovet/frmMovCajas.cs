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
    public partial class frmMovCajas : Form
    {
        public frmMovCajas()
        {
            InitializeComponent();
        }

        private void frmMovCajas_Load(object sender, EventArgs e)
        {

        }

        private void rbfecfa_CheckedChanged(object sender, EventArgs e)
        {
            lbldesde.Enabled = true;
            lblhasta.Enabled = true;

            dtpdesde.Enabled = true;
            dtphasta.Enabled = true;

        }

        private void rbactual_CheckedChanged(object sender, EventArgs e)
        {
            lbldesde.Enabled = false;
            lblhasta.Enabled = false;

            dtpdesde.Enabled = false;
            dtphasta.Enabled = false;
        }

        private void chkforma_CheckedChanged(object sender, EventArgs e)
        {
            if (chkforma.Checked)
            {
                cmbtipopago.Enabled = true;
            }
            else
            {
                cmbtipopago.Enabled = false;
            }


        }

        private void chkoperacion_CheckedChanged(object sender, EventArgs e)
        {
            if(chkoperacion.Checked)
            {
                cmbtipooperacion.Enabled = true;
            }
            else
            {
                cmbtipooperacion.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmGasto gasto = new frmGasto();

            Ventana ventana = new Ventana();
            ventana.AbrirFormHijo(gasto);
        }
    }
}
