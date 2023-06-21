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
using Entidades;
namespace Allqovet
{
    public partial class FrmFactura : Form
    {
        public FrmFactura()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConsultaSUNAT();
        }

        private void ConsultaSUNAT()
        {
            using (ProveedorBLL db = new ProveedorBLL())
            {
                try
                {
                    if (txtruc.Text.Length != 11)
                    {
                        MessageBox.Show("El ruc debe tener 11 dígitos");
                        return;
                    }

                    string ruc = txtruc.Text;

                    Proveedor proveedor = new Proveedor();
                    proveedor = db.ConsultaRUC(ruc);
                    if (proveedor != null)
                    {
                        txtrazon.Text = proveedor.RazonSocial;
                        txtdireccion.Text = proveedor.Direccion;

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());

                }
            }


        }

        private void FrmFactura_Load(object sender, EventArgs e)
        {
            CorelativoFactura();
            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            if (dgvProductos.Rows.Count>0)
            {
                CalcularTotal();
            }
        }

        private void CorelativoFactura()
        {

            using (FacturaBLL db = new FacturaBLL())
            {
                try
                {

                    Factura factura = new Factura();
                    factura = db.Correlativo();

                    lblserie.Text = factura.Serie;

                    int cantidadDigitos = 8;
                    lblnumero.Text = factura.Numero.ToString("D" + cantidadDigitos.ToString());
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void CalcularTotal()
        {
            double total = 0;
            double subtotal = 0;
            double igv = 0;
            int items = 0;
            int productos = 0;

            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                total += Convert.ToDouble(row.Cells["SUBTOTAL"].Value);
                //cantidad += Convert.ToInt32(row.Cells["CANTIDAD"].Value);

                if (Convert.ToDouble(row.Cells["PRECIO"].Value) > 0)
                {
                    items += 1;
                    productos += Convert.ToInt32(row.Cells["CANTIDAD"].Value);
                }

            }

            subtotal = total / 1.18;
            igv = total - subtotal;

            txttotal.Text = string.Format("{0:0.00}", total);
            txtsubtotal.Text = string.Format("{0:0.00}", subtotal);
            txtigv.Text = string.Format("{0:0.00}", igv);
            lblitems.Text = items.ToString();
            lblproductos.Text = productos.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(" Esta seguro de registrar la venta?", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                RegistrarFactura();
            }
        }

        private void RegistrarFactura()
        {

        }
    }
}
