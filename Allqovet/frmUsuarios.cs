using AllqovetBLL;
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
          
            frmNuevoUsuario nuevo = new frmNuevoUsuario(false);
           
            nuevo.ShowDialog();
        }

        private void btnmod_Click(object sender, EventArgs e)
        {

        }

        private void btnbaja_Click(object sender, EventArgs e)
        {

        }

        private void btnnuevo_Click_1(object sender, EventArgs e)
        {
            frmNuevoUsuario nuevo = new frmNuevoUsuario(false);
            nuevo.ShowDialog();
        }

        private void btnmod_Click_1(object sender, EventArgs e)
        {
            frmNuevoUsuario fr = new frmNuevoUsuario(true);
            fr.lbltitulo.Text = "MODFICAR DATOS DE USUARIO";
            fr.lblidusuario.Text = dtgusuarios.CurrentRow.Cells["ID"].Value.ToString(); 
            fr.ShowDialog();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            ListarUsuarios();
        }

        private void ListarUsuarios()
        {

            using (UsuarioBLL db = new UsuarioBLL())
            {
                try
                {
                    dtgusuarios.DataSource = db.Listar();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
