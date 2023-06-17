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
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            int AltoPantalla = Screen.PrimaryScreen.WorkingArea.Height;
            int AnchoPantalla = Screen.PrimaryScreen.WorkingArea.Width;

            frmNuevoUsuario nuevo = new frmNuevoUsuario();
           
            nuevo.ShowDialog();
        }

        private void btnmod_Click(object sender, EventArgs e)
        {

        }

        private void btnbaja_Click(object sender, EventArgs e)
        {

        }
    }
}
