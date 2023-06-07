using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaces;
using Entidades;
using AllqovetBLL;

namespace Allqovet
{
    public partial class frmCategory : Form
    {
        public frmCategory()
        {
            InitializeComponent();
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {

        }

        private void Buscar()
        {
            using (CategoriaBLL db = new CategoriaBLL())
            {
                try
                {
                   Categoria categoria= new Categoria();
                    categoria.Nombre = txtBuscador.Text;

                    DataTable dt = db.Buscar(categoria);

                    dgCategoria.DataSource = dt;

                }
                catch (Exception ex)
                {

                    ex.ToString();
                }
            }
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmNuevaCategory nuevo = new frmNuevaCategory();
            nuevo.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
