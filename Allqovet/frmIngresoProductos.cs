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
using Microsoft.Reporting.WinForms;

namespace Allqovet
{
    public partial class frmIngresoProductos : Form
    {
        public frmIngresoProductos()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dgvproductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ListarProveedores()
        {
            using (ProveedorBLL db = new ProveedorBLL())
            {
                try
                {

                    cmbProveedor.DataSource = db.Listar();
                    cmbProveedor.ValueMember = "idProveedor";
                    cmbProveedor.DisplayMember = "RazonSocial";
                    cmbProveedor.SelectedIndex = -1;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
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

            lbltotal.Text = total.ToString();

            lbltotal.Text = string.Format("{0:0.00}", total);

   
        }

        private void txtprecio_Leave(object sender, EventArgs e)
        {
            if (txtprecio.Text.Length > 0)
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

        private void BuscarProducto()
        {
            using (ProductoBLL db = new ProductoBLL())
            {
                try
                {
                    DataTable producto = db.BuscarProductoCodigo(txtcodigo.Text);

                    if (producto.Rows.Count > 0)
                    {
                        foreach (DataRow row in producto.Rows)
                        {
                            // idproducto = Convert.ToInt32(row["idproducto"].ToString());
                            lblidproducto.Text = row["Idproducto"].ToString();
                            txtcodigo.Text = row["codigo"].ToString();
                            txtdescripcion.Text = row["descripcion"].ToString();
                            txtprecio.Text = row["PrecioVenta"].ToString();

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
                lblarticulos.Text = cantidad.ToString();
               

            }
        }

        private void txtcan_TextChanged(object sender, EventArgs e)
        {

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

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esta seguro de registrar el ingreso?", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                RegistrarPedido();
            }
        }

        private void RegistrarPedido()
        {
            int idpedido = 0;
            using (PedidoBLL db = new PedidoBLL())
            {
                try
                {
                    Pedido pedido = new Pedido();
                    Movimiento movimiento = new Movimiento();

                    List<DetallePedido> detallepedidos = new List<DetallePedido>();
                    List<ProductoVitrina> productoVitrinas = new List<ProductoVitrina>();
                    List<Entrada> entradas= new List<Entrada>();

                    pedido.Serie = txtserie.Text;
                    pedido.Numero = Convert.ToInt32(txtnumero.Text);
                    pedido.idproveedor = Convert.ToInt32(cmbProveedor.SelectedValue);
                    pedido.Total = Convert.ToDouble(lbltotal.Text);
                    

                    movimiento.Tipo = "e";
                    movimiento.idcausa = 2; //motivo 2: compra de producto
                    movimiento.cantidad = Convert.ToInt32(lblarticulos.Text);

                    foreach (DataGridViewRow row in dgvproductos.Rows)
                    {
                        DetallePedido detallePedido= new DetallePedido();
                        ProductoVitrina productoVitrina = new ProductoVitrina();
                        Entrada entrada = new Entrada();

                        detallePedido.Idproducto = Convert.ToInt32(row.Cells["IDPRODUCTO"].Value.ToString());
                        detallePedido.Descripcion = row.Cells["DESCRIPCION"].Value.ToString();
                        detallePedido.Cantidad = Convert.ToInt32(row.Cells["CANTIDAD"].Value.ToString());
                        detallePedido.Precio = Convert.ToDouble(row.Cells["PRECIO"].Value.ToString());
                        

                        productoVitrina.Idproducto = Convert.ToInt32(row.Cells["IDPRODUCTO"].Value.ToString());

                        productoVitrina.Stock = Convert.ToInt32(row.Cells["CANTIDAD"].Value.ToString());

                        entrada.Idproducto= Convert.ToInt32(row.Cells["IDPRODUCTO"].Value.ToString());
                        entrada.Cantidad = Convert.ToInt32(row.Cells["CANTIDAD"].Value.ToString());

                        detallepedidos.Add(detallePedido);
                        productoVitrinas.Add(productoVitrina);
                        entradas.Add(entrada);

                    }

                    idpedido = db.Agregar(pedido, detallepedidos, productoVitrinas, movimiento, entradas);
                    if (idpedido> 0)
                    {
                        MessageBox.Show("Ingreso registrada: " + idpedido);
                        Imprimir(idpedido);
                        this.Close();
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }



        }

        private void Imprimir(int idped)
        {
            using (PedidoBLL db = new PedidoBLL())
            {
                try
                {
                    ImprimirPedido pedido = new ImprimirPedido();

                    ReportDataSource fuente = new ReportDataSource("DataSetPedido", db.ImprimirPedido(idped));
                    pedido.reportViewer1.LocalReport.DataSources.Clear();
                    pedido.reportViewer1.LocalReport.DataSources.Add(fuente);
                    pedido.reportViewer1.LocalReport.ReportEmbeddedResource = "Allqovet.Reportes.Pedido.rdlc";
                    pedido.reportViewer1.RefreshReport();
                    pedido.reportViewer1.LocalReport.Refresh();

                    Ventana ventana = new Ventana();
                    ventana.AbrirFormHijo(pedido);

                    //  this.Close();


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void frmIngresoProductos_Load(object sender, EventArgs e)
        {
            ListarProveedores();
            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            BuscarProducto();
        }
    }
}
