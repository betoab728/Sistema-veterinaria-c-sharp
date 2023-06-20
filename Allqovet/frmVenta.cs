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
using Entidades;
using Microsoft.Reporting.WinForms;

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
            CorelativoVenta();
        }

        private void CorelativoVenta()
        {
            
                using (VentaBLL db = new VentaBLL())
                {
                    try
                    {

                        Venta venta = new Venta();
                        venta = db.Correlativo();

                        lblserie.Text =venta.serie ;

                    int cantidadDigitos = 8;
                    lblnumero.Text = venta.numero.ToString("D"+ cantidadDigitos.ToString());
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
            
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

            //calculo para la utilidad--------
            double costo = 0;
            double utilidad_item = 0;
            if (lblcosto.Text.Length > 0) costo = Convert.ToDouble(lblcosto.Text);
            costo = Convert.ToDouble(lblcosto.Text);

            utilidad_item = total - (cantidad * costo);
            
            lblutilidad_item.Text= string.Format("{0:0.00}", utilidad_item);
            //---------------------------------
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
               

                dgvproductos.Rows.Add(lblidproducto.Text, lblCodigo.Text, txtproducto.Text, txtcan.Text, txtprecio.Text, txttotalitem.Text,lblcosto.Text,lblutilidad_item.Text);

                txtprecio.Text = "";
                txtcodigo.Text = "";
                lblidproducto.Text = "0";
                lblCodigo.Text = "0";
                txtstock.Text = "";
                txtcan.Text = "1";
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
                double utilidad = 0;

                foreach (DataGridViewRow row in dgvproductos.Rows)
                {
                    total += Convert.ToDouble(row.Cells["IMPORTE"].Value);
                    cantidad += Convert.ToInt32(row.Cells["CANTIDAD"].Value);
                    utilidad += Convert.ToDouble(row.Cells["UTILIDAD"].Value);
                }

                lbltotal.Text = string.Format("{0:0.00}",total);
                lblarticulos.Text = cantidad.ToString();
                lblutilidad.Text = string.Format("{0:0.00}",utilidad);

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

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(" Esta seguro de registrar la venta?", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                RegistrarVenta();
            }
        }


        private void  RegistrarVenta()
        {
            int idventa = 0;
            using (VentaBLL db=new VentaBLL())
            {
                try
                {
                    Venta venta = new Venta();
                    Movimiento movimiento = new Movimiento();

                    List<DetalleVenta> detalleVentas  = new List<DetalleVenta>();
                    List<ProductoVitrina> productoVitrinas =new  List<ProductoVitrina>();
                    List<Salida> salidas = new List<Salida>();

                    venta.serie = lblserie.Text;
                    venta.numero =Convert.ToInt32(lblnumero.Text);
                    venta.Idcliente = Convert.ToInt32(lblidcliente.Text);
                    venta.Idtrabajador = Convert.ToInt32(cmbvendedor.SelectedValue);
                    venta.Total = Convert.ToDouble(lbltotal.Text);
                    venta.Utilidad = Convert.ToDouble(lblutilidad.Text);

                    movimiento.Tipo = "s";
                    movimiento.idcausa = 1; //motivo 1: venta de producto
                    movimiento.cantidad =Convert.ToInt32( lblarticulos.Text);

                    foreach (DataGridViewRow row in dgvproductos.Rows)
                    {
                        DetalleVenta detalleVenta = new DetalleVenta();
                        ProductoVitrina productoVitrina = new ProductoVitrina();
                        Salida salida = new Salida();

                        detalleVenta.Idproducto= Convert.ToInt32(row.Cells["IDPRODUCTO"].Value.ToString());
                        detalleVenta.Descripcion = row.Cells["DESCRIPCION"].Value.ToString();
                        detalleVenta.Cantidad = Convert.ToInt32(row.Cells["CANTIDAD"].Value.ToString());
                        detalleVenta.Precio = Convert.ToDouble(row.Cells["PRECIO"].Value.ToString());
                        detalleVenta.Costo = Convert.ToDouble(row.Cells["COSTO"].Value.ToString());

                        productoVitrina.Idproducto= Convert.ToInt32(row.Cells["IDPRODUCTO"].Value.ToString());
                     
                        productoVitrina.Stock= Convert.ToInt32(row.Cells["CANTIDAD"].Value.ToString());

                        salida.Idproducto= Convert.ToInt32(row.Cells["IDPRODUCTO"].Value.ToString());
                        salida.Cantidad= Convert.ToInt32(row.Cells["CANTIDAD"].Value.ToString());

                        detalleVentas.Add(detalleVenta);
                        productoVitrinas.Add(productoVitrina);
                        salidas.Add(salida);

                    }

                    idventa = db.Agregar(venta,detalleVentas,productoVitrinas,movimiento,salidas);
                    if (idventa >0)
                    {
                        MessageBox.Show("Venta registrada: "+idventa);
                        Imprimir(idventa);
                        this.Close();
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message); 
                }
            }
            

           
        }


        private void Imprimir(int idventa)
        {
            using (VentaBLL db = new VentaBLL())
            {
                try
                {
                    frmImprimirVenta venta = new frmImprimirVenta();

                    ReportDataSource fuente = new ReportDataSource("DataSetImprimirVenta", db.ImprimirVenta(idventa));
                    venta.reportViewer1.LocalReport.DataSources.Clear();
                    venta.reportViewer1.LocalReport.DataSources.Add(fuente);
                    venta.reportViewer1.LocalReport.ReportEmbeddedResource = "Allqovet.Reportes.Venta.rdlc";
                    venta.reportViewer1.RefreshReport();
                    venta.reportViewer1.LocalReport.Refresh();

                    Ventana ventana = new Ventana();
                    ventana.AbrirFormHijo(venta);

                    //  this.Close();


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
        }
    }
}
