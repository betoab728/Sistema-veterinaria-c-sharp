using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarcodeLib;
using AllqovetBLL;
namespace Allqovet
{
    public partial class frmVenta : Form
    {
        public frmVenta()
        {
            InitializeComponent();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmVenta_Load(object sender, EventArgs e)
        {
            ListarTrabajadores();
            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void ListarTrabajadores()
        {
            using (TrabajadorBLL db =new TrabajadorBLL())
            {
                try
                {
                    
                    cmbvendedor.DataSource = db.ListarNombres();
                    cmbvendedor.ValueMember = "Idtrabajador";
                    cmbvendedor.DisplayMember = "nombres";
                    cmbvendedor.SelectedIndex = -1;
                }
                catch (Exception ex)
                {

                   MessageBox.Show( ex.Message);
                }
            }
        }

        private void TotalItem()
        {
            int cantidad = 0;
            double precio = 0;
            double total = 0;

            if (txtcan.Text.Length > 0) cantidad = Convert.ToInt32(txtcan.Text);
            if (txtprecio.Text.Length > 0) precio = Convert.ToDouble(txtprecio.Text);
            total = cantidad * precio;

            txttotalitem.Text = total.ToString();

            txttotalitem.Text = string.Format("{0:0.00}", total);
        }


        private void txtcodigo_Leave(object sender, EventArgs e)
        {
            //  CodigoBarras();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtprecio_Leave(object sender, EventArgs e)
        {
            if (txtprecio.Text.Length>0)
            {
                TotalItem();

                double precio = 0;
                precio = Convert.ToDouble(txtprecio.Text);
                txtprecio.Text = string.Format("{0:0.00}", precio);
            }

         

        }

        private void txtcan_Leave(object sender, EventArgs e)
        {

          
            TotalItem();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ventana ventana = new Ventana();
            frmBusCliVenta cli = new frmBusCliVenta();
            ventana.AbrirFormHijo(cli);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BuscarProducto();
        }

        private void BuscarProducto()
        {
            using (ProductoBLL db=new ProductoBLL())
            {
                try
                {
                    DataTable producto = db.BuscarProductoCodigo(txtcodigo.Text);

                    if (producto.Rows.Count >0)
                    {
                        foreach (DataRow row in producto.Rows)
                        {
                            // idproducto = Convert.ToInt32(row["idproducto"].ToString());
                            lblidproducto.Text = row["Idproducto"].ToString();
                            lblCodigo.Text = row["codigo"].ToString();
                            txtproducto.Text= row["producto"].ToString();
                            lblcosto.Text= row["PrecioCosto"].ToString();
                            txtprecio.Text = row["PrecioVenta"].ToString();
                            txtstock.Text = row["stock"].ToString();

                            TotalItem();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Producto no encontrado");
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int stock = 0;

            stock = Convert.ToInt32(txtstock.Text);
            if (stock >0)
            {
                dgvproductos.Rows.Add(lblidproducto.Text, lblCodigo.Text, txtproducto.Text, txtcan.Text, txtprecio.Text, txttotalitem.Text);

                txtprecio.Text = "";
                txtcodigo.Text = "";
                lblidproducto.Text = "0";
                lblCodigo.Text = "0";
                txtstock.Text = "";
                txtcan.Text = "";
                txtproducto.Text = "";
                txttotalitem.Text = "";

                CalcularTotal();
                txtcodigo.Focus();
            }
            else
            {
                MessageBox.Show("No hay stock suficiente");
            }
        }

        private void CalcularTotal()
        {
            if (dgvproductos.Rows.Count == 0)
            {
                lbltotal.Text = "0.00";
                lblarticulos.Text = "0";


            }
            else
            {
                double total = 0;
                int cantidad = 0;
                foreach (DataGridViewRow row in dgvproductos.Rows)
                {
                    total += Convert.ToDouble(row.Cells["IMPORTE"].Value);
                    cantidad += Convert.ToInt32(row.Cells["CANTIDAD"].Value);
                }
                lbltotal.Text = string.Format("{0:0.00}", total);
                lblarticulos.Text = cantidad.ToString(); ;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dgvproductos.Rows.Count > 0)
            {

                DialogResult dlg = MessageBox.Show("¿Esta seguro de Quitar el producto?", "Ingreso de productos", MessageBoxButtons.YesNo);
                if (dlg == DialogResult.Yes)
                {


                    dgvproductos.Rows.Remove(dgvproductos.CurrentRow);
                    CalcularTotal();

                }
            }
        }
    }
}
