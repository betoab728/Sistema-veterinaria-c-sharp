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
    public partial class frmNuevaCategory : Form
    {
        public frmNuevaCategory()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Registrar() > 0)
            {
                MessageBox.Show("Categoría registrada");
            }
        }

        private int Registrar()
        {
            Categoria categoria = new Categoria();
            categoria.Nombre = txtNombre.Text;

            int r = 0;

            using (CategoriaBLL db = new CategoriaBLL())
            {

                try
                {
                    r = db.Agregar(categoria);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                    r = 0;
                }
            }

            return r;

        }

        private void frmNuevaCategory_Load(object sender, EventArgs e)
        {

        }
    }
}
