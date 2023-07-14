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
using Microsoft.Reporting.WinForms;

namespace Allqovet
{
    public partial class frmVentas : Form
    {
        public frmVentas()
        {
            InitializeComponent();
        }

        private void frmVentas_Load(object sender, EventArgs e)
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

                    lblserie.Text = venta.serie;

                    int cantidadDigitos = 8;

                      lblnumero.Text = venta.numero.ToString("D" + cantidadDigitos.ToString());

                }
                catch (Exception ex)
                {

                    MessageBox.Show("error en el correlativo: "+ex.Message);
                }
            }

        }

        private void ListarTrabajadores()
        {
            using (TrabajadorBLL db = new TrabajadorBLL())
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

            txttotalitem.Text = total.ToString();

            txttotalitem.Text = string.Format("{0:0.00}", total);

            //calculo para la utilidad--------
            double costo = 0;
            double utilidad_item = 0;
            if (lblcosto.Text.Length > 0) costo = Convert.ToDouble(lblcosto.Text);
            costo = Convert.ToDouble(lblcosto.Text);

            utilidad_item = total - (cantidad * costo);

            lblutilidad_item.Text = string.Format("{0:0.00}", utilidad_item);
            //---------------------------------
        }

        private void txtprecio_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtproducto.Text))
            {
              //  MessageBox.Show("ingrese un producto");

            }
            else
            {
                if (txtprecio.Text.Length > 0)
                {
                    TotalItem();

                    double precio = 0;
                    precio = Convert.ToDouble(txtprecio.Text);
                    txtprecio.Text = string.Format("{0:0.00}", precio);
                }
            }

          

        }

        private void txtcan_Leave(object sender, EventArgs e)
        {
            TotalItem();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmBusCliVenta cli = new frmBusCliVenta();

            //  Ventana ventana = new Ventana();

            //   frm.SetDesktopLocation((panelEscritorio.Width - frm.Width) / 2, (panelEscritorio.Height - frm.Height) / 2);

             /* frmMenu menu = Application.OpenForms.OfType<frmMenu>().SingleOrDefault();
             if (menu != null)
             {


                 int x = 0;
                 int y = 0;

                 x = menu.Location.X;

                 x = (menu.panelEscritorio.Width - cli.Width) / 2;
                 y  = (menu.panelEscritorio.Height - cli.Height) / 2;


             }

             */
           

            cli.ShowDialog();


            // ventana.AbrirFormHijo(cli);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtcodigo.Text))
            {
                BuscarProducto();
            }
            else
            {
                MessageBox.Show("Ingrese un codigo");
            }

              
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
                            lblCodigo.Text = row["codigo"].ToString();
                            txtproducto.Text = row["producto"].ToString();
                            lblcosto.Text = row["PrecioCosto"].ToString();
                            txtprecio.Text = row["PrecioVenta"].ToString();
                            txtstock.Text = row["stock"].ToString();
                            lblmanejastock.Text = row["manejastock"].ToString();

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
            if (String.IsNullOrEmpty(txttotalitem.Text))
            {
                MessageBox.Show("ingrese una producto");
                return;
            }

            if (txtcan.Text.Length == 0)
            {

                MessageBox.Show("ingrese una cantidad");
                return;
            }

            int cantidad = Convert.ToInt32(txtcan.Text);
            int stock = Convert.ToInt32(txtstock.Text);

            if (cantidad <= 0)
            {

                MessageBox.Show("ingrese una cantidad valida");
                return;
            }

            if (stock <= 0)
            {

                MessageBox.Show("no hay stock suficiente");
                return;
            }
            if (cantidad > stock)
            {
                MessageBox.Show("no hay stock suficiente ");
                return;
            }

            stock = Convert.ToInt32(txtstock.Text);
            if (stock > 0)
            {

                if (!ProductoenLista())
                {
                    dgvproductos.Rows.Add(lblidproducto.Text, lblCodigo.Text, txtproducto.Text, txtcan.Text, txtprecio.Text, txttotalitem.Text, lblcosto.Text, lblutilidad_item.Text);

             

                    CalcularTotal();
                    Limpiar();


                }


                CalcularTotal();
                Limpiar();


            }
            else
            {
                MessageBox.Show("No hay stock suficiente");
            }
        }

        private void Limpiar()
        {
            txtprecio.Text = "";
            txtcodigo.Text = "";
            lblidproducto.Text = "0";
            lblCodigo.Text = "0";
            txtstock.Text = "";
            txtcan.Text = "1";
            txtproducto.Text = "";
            txttotalitem.Text = "";
            txtcodigo.Focus();
        }

        private bool ProductoenLista()
        {
            bool result = false;
            string idproducto = "";
            double preciolista = 0;
            double precio = 0;
            int stock = 0;
            precio = Convert.ToDouble(txtprecio.Text);
            stock = Convert.ToInt32(txtstock.Text);

            int cant = Convert.ToInt32(txtcan.Text);
            int cantlista = 0;
            double subtotal = Convert.ToDouble(txttotalitem.Text);
            double subtotallista = 0;
            double utilidad = cant*( precio - Convert.ToDouble(lblcosto.Text));
            
            //  FrmNuevaFacturaCompra f1 = Application.OpenForms.OfType<FrmNuevaFacturaCompra>().SingleOrDefault();

            for (int fila = 0; fila < dgvproductos.Rows.Count; fila++)
            {
                idproducto = dgvproductos.Rows[fila].Cells["idproducto"].Value.ToString();
                if (idproducto.Equals(lblidproducto.Text))
                {
                    result = true;
                    DialogResult dlg = MessageBox.Show("¿El producto ya se encuentra en el listado, desea agregarlo?", "Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == DialogResult.Yes)
                    {
                        preciolista = Convert.ToDouble(dgvproductos.Rows[fila].Cells["PRECIO"].Value.ToString());

                        if (precio != preciolista)
                        {
                            MessageBox.Show("Los precios no coinciden", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return result;
                        }

                        cantlista = Convert.ToInt32(dgvproductos.Rows[fila].Cells["CANTIDAD"].Value.ToString());
                        cant += cantlista;

                        subtotallista = Convert.ToDouble(dgvproductos.Rows[fila].Cells["IMPORTE"].Value.ToString());
                        subtotal += subtotallista;
                        utilidad += Convert.ToDouble(dgvproductos.Rows[fila].Cells["UTILIDAD"].Value.ToString());

                        if (lblmanejastock.Text.Equals("1"))
                        {
                     
                            if (cant > stock)
                            {
                                MessageBox.Show("No hay stock suficiente", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return result;
                            }
                            else
                            {
                                dgvproductos.Rows[fila].Cells["CANTIDAD"].Value = Convert.ToString(cant);
                                dgvproductos.Rows[fila].Cells["IMPORTE"].Value = Convert.ToString(string.Format("{0:0.00}", subtotal));

                                dgvproductos.Rows[fila].Cells["UTILIDAD"].Value = Convert.ToString(string.Format("{0:0.00}", utilidad));
                            }

                        }
                        else
                        {
                            dgvproductos.Rows[fila].Cells["CANTIDAD"].Value = Convert.ToString(cant);
                            dgvproductos.Rows[fila].Cells["IMPORTE"].Value = Convert.ToString(string.Format("{0:0.00}", subtotal));

                            dgvproductos.Rows[fila].Cells["UTILIDAD"].Value = Convert.ToString(string.Format("{0:0.00}", utilidad));
                        }
                        
                    }
                }


            }

            return result;
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

                lbltotal.Text = string.Format("{0:0.00}", total);
                lblarticulos.Text = cantidad.ToString();
                lblutilidad.Text = string.Format("{0:0.00}", utilidad);

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
            int idcliente = Convert.ToInt32(lblidcliente.Text);

            if (idcliente==0)
            {
                MessageBox.Show("Ingrese un cliente");
                return;
            }

            if (cmbvendedor.SelectedIndex==-1)
            {
                MessageBox.Show("seleccione un vendedor");
                return;
            }

            if (dgvproductos.Rows.Count ==0)
            {
                MessageBox.Show("La venta no tiene productos");
                return;
            }



            DialogResult dialogResult = MessageBox.Show(" Esta seguro de registrar la venta?", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                RegistrarVenta();
            }
        }

        private void RegistrarVenta()
        {
            int idventa = 0;
            using (VentaBLL db = new VentaBLL())
            {
                try
                {
                    Venta venta = new Venta();
                    Movimiento movimiento = new Movimiento();

                    List<DetalleVenta> detalleVentas = new List<DetalleVenta>();
                    List<ProductoVitrina> productoVitrinas = new List<ProductoVitrina>();
                    List<Salida> salidas = new List<Salida>();

                    venta.serie = lblserie.Text;
                    venta.numero = Convert.ToInt32(lblnumero.Text);
                    venta.Idcliente = Convert.ToInt32(lblidcliente.Text);
                    venta.Idtrabajador = Convert.ToInt32(cmbvendedor.SelectedValue);
                    venta.Total = Convert.ToDouble(lbltotal.Text);
                    venta.Utilidad = Convert.ToDouble(lblutilidad.Text);
                    venta.idcajachica = Idcajachica();

                    movimiento.Tipo = "s";
                    movimiento.idcausa = 1; //motivo 1: venta de producto
                    movimiento.cantidad = Convert.ToInt32(lblarticulos.Text);

                    foreach (DataGridViewRow row in dgvproductos.Rows)
                    {
                        DetalleVenta detalleVenta = new DetalleVenta();
                        ProductoVitrina productoVitrina = new ProductoVitrina();
                        Salida salida = new Salida();

                        detalleVenta.Idproducto = Convert.ToInt32(row.Cells["IDPRODUCTO"].Value.ToString());
                        detalleVenta.Descripcion = row.Cells["DESCRIPCION"].Value.ToString();
                        detalleVenta.Cantidad = Convert.ToInt32(row.Cells["CANTIDAD"].Value.ToString());
                        detalleVenta.Precio = Convert.ToDouble(row.Cells["PRECIO"].Value.ToString());
                        detalleVenta.Costo = Convert.ToDouble(row.Cells["COSTO"].Value.ToString());

                        productoVitrina.Idproducto = Convert.ToInt32(row.Cells["IDPRODUCTO"].Value.ToString());

                        productoVitrina.Stock = Convert.ToInt32(row.Cells["CANTIDAD"].Value.ToString());

                        salida.Idproducto = Convert.ToInt32(row.Cells["IDPRODUCTO"].Value.ToString());
                        salida.Cantidad = Convert.ToInt32(row.Cells["CANTIDAD"].Value.ToString());

                        detalleVentas.Add(detalleVenta);
                        productoVitrinas.Add(productoVitrina);
                        salidas.Add(salida);

                    }

                    idventa = db.Agregar(venta, detalleVentas, productoVitrinas, movimiento, salidas);
                    if (idventa > 0)
                    {
                        MessageBox.Show("Venta registrada: " + idventa);

                        //ventana cobro

                        frmCobro cobro = new frmCobro();
                        cobro.lbltotal.Text = lbltotal.Text;
                        cobro.lblidventa.Text = idventa.ToString();
                        cobro.lblnumeroventa.Text = lblserie.Text +"-"+ lblnumero.Text;

                        Ventana ventana = new Ventana();

                        ventana.AbrirFormHijo(cobro);



                        //    Imprimir(idventa);
                       // this.Close();
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }



        }


        private int Idcajachica()
        {
            int Idcajachica = 0;
            using (CajachicaBLL db = new CajachicaBLL())

            {
                try
                {
                    Idcajachica = db.BuscarCajaActiva();
                }
                catch (Exception ex)
                {
                    Idcajachica = 0;
                    MessageBox.Show(ex.Message);
                }

                return Idcajachica;
            }
        }

        public void Imprimir(int idventa)
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

        private void txtcliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttotalitem_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txtprecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbvendedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmBusProVenta buscar = new frmBusProVenta();
            buscar.ShowDialog();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            int x = this.Location.X;
            int y = this.Location.Y;

            MessageBox.Show("ubicacion X:"+x + "y:"+y);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido

                if (!string.IsNullOrEmpty(txtcodigo.Text))
                {
                    BuscarProducto();
                }
                else
                {
                    MessageBox.Show("Ingrese un codigo");
                }
            }

         
        }
    }
}
