using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Interfaces;
using AllqovetBLL;


namespace Allqovet
{
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void frmProductos_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buscar_Click(object sender, EventArgs e)
        {

        }

        private void Buscar()
        {
            using (ProductoBLL db = new ProductoBLL())
            {
                try
                {
                    Producto producto = new Producto();
                    producto.Descripcion = txtBuscador.Text;

                    DataTable dt = db.Buscar(producto);

                    dgProductos.DataSource = dt;

                }
                catch (Exception ex)
                {

                    ex.ToString();
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frmNuevoProducto nuevo = new frmNuevoProducto();
            nuevo.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
