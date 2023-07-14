using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AllqovetBLL;
using Entidades;

namespace Allqovet
{
    public partial class frmBusProVenta : Form
    {
        public frmBusProVenta()
        {
            InitializeComponent();
        }

        private void frmBusProVenta_Load(object sender, EventArgs e)
        {
            
        }

        private void Buscar()
        {
            using (ProductoBLL db = new ProductoBLL())
            {
                try
                {
                    Producto producto = new Producto();
                    producto.Descripcion = txtdescripcion.Text;

                    DataTable dt = db.Buscar(producto);

                    dgvProd.DataSource = dt;

                }
                catch (Exception ex)
                {

                    ex.ToString();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Buscar();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtdescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                Buscar();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvProd.Rows.Count > 0)
            {
                frmVentas venta = Application.OpenForms.OfType<frmVentas>().SingleOrDefault();
                if (venta != null)
                {
                    venta.txtcodigo.Text = dgvProd.CurrentRow.Cells["CODIGO"].Value.ToString();
                   
                }

                this.Close();

            }
        }

        private void txtdescripcion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
