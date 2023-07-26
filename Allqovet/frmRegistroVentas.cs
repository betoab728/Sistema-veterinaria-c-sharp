using AllqovetBLL;
using Microsoft.Reporting.WinForms;
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
    public partial class frmRegistroVentas : Form
    {
        public bool ventaanulada = false;

        public frmRegistroVentas()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dtgventas.Rows.Count >0)
            {
                frmDetallesVenta detalleVenta = new frmDetallesVenta();

                using (VentaBLL db = new VentaBLL())
                {
                    try
                    {
                        Ventana ventana = new Ventana();
                        int idventa = Convert.ToInt32(dtgventas.CurrentRow.Cells["IDVENTA"].Value);
                        detalleVenta.dataGridView1.DataSource = db.DetalleVenta(idventa);
                        ventana.AbrirFormHijo(detalleVenta);

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
            }
         
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmVentas ventas = new frmVentas();
            ventas.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dtgventas.Rows.Count>0)
            {
                int idventa = Convert.ToInt32(dtgventas.CurrentRow.Cells["IDVENTA"].Value);
                Imprimir(idventa);
            }
          
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dtgfichas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbocriterio.SelectedIndex==0)
            {
                BuscarVentaApellidos();
            }
            else
            {
                BuscarVentaFechas();
            }
        }

        private void Buscar()
        {
            if (cbocriterio.SelectedIndex == 0)
            {
                BuscarVentaApellidos();
            }
            else
            {
                BuscarVentaFechas();
            }
        }

        private void BuscarVentaApellidos()
        {
            using (VentaBLL db=new VentaBLL())
            {
                try
                {
                    string apellido = txtbuscar.Text;
                    dtgventas.DataSource = db.BuscarVentaApellidos(apellido);
                    FormatoTabla();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message); 
                }
            }
        }

        private void FormatoTabla()
        {
            if (dtgventas.Rows.Count >0)
            {
                lblregistros.Text= dtgventas.Rows.Count.ToString();

                foreach (DataGridViewRow row in dtgventas.Rows)
                {


                    if (row.Cells["ESTADO"].Value.ToString() == "ANULADA")
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
        }

        private void BuscarVentaFechas()
        {
            using (VentaBLL db = new VentaBLL())
            {
                try
                {
                    DateTime desde = Convert.ToDateTime(dtpdesde.Value.ToString("yyyy-MM-dd"));
                    DateTime hasta = Convert.ToDateTime(dtphasta.Value.ToString("yyyy-MM-dd"));

                    dtgventas.DataSource = db.BuscarVentaFechas(desde, hasta);
                    FormatoTabla();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message); 
                }
            }
        }



        private void cbocriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbocriterio.SelectedIndex==0)
            {
                panelfecha.Visible = false;
                txtbuscar.Visible = true;
            }
            else
            {
                panelfecha.Visible = true;
                txtbuscar.Visible = false;
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

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dtgventas.Rows.Count >0)
            {
                EmitirBoleta();
            }
          
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dtgventas.Rows.Count > 0)
            {
                EmitirFactura();
            }
               


        }

        private void EmitirFactura()
        {
            using (VentaBLL db = new VentaBLL())
            {
                try
                {
                    Ventana ventana = new Ventana();
                    FrmFactura factura = new FrmFactura();
                    int idventa = Convert.ToInt32(dtgventas.CurrentRow.Cells["IDVENTA"].Value);
                    factura.lblidventa.Text = idventa.ToString();

                  DataTable detalleVenta = new DataTable();

                    detalleVenta = db.DetalleVenta(idventa);

                    string idproducto = "";
                    string codigo = "";
                    string descripcion = "";
                    string cantidad = "";
                    string precio = "";
                    string importe = "";

                    foreach (DataRow row in detalleVenta.Rows)
                    {
                       idproducto = row["IDPRODUCTO"].ToString();
                        codigo = row["CODIGO"].ToString(); ;
                        descripcion = row["DESCRIPCION"].ToString();
                        cantidad = row["CANTIDAD"].ToString(); 
                        precio = row["PRECIO"].ToString();
                        importe = row["IMPORTE"].ToString(); 

                        factura.dgvProductos.Rows.Add(idproducto, codigo, descripcion, cantidad, precio, importe);
                    }

                    ventana.AbrirFormHijo(factura);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void EmitirBoleta()
        {
            using (VentaBLL db = new VentaBLL())
            {
                try
                {

                    Ventana ventana = new Ventana();
                    frmBoleta boleta = new frmBoleta();

                    int idventa = Convert.ToInt32(dtgventas.CurrentRow.Cells["IDVENTA"].Value);
                    boleta.lblidventa.Text = idventa.ToString();

                    DataTable detalleVenta = new DataTable();

                    detalleVenta = db.DetalleVenta(idventa);

                    string idproducto = "";
                    string codigo = "";
                    string descripcion = "";
                    string cantidad = "";
                    string precio = "";
                    string importe = "";

                    boleta.txtdni.Text = dtgventas.CurrentRow.Cells["DNI"].Value.ToString();
                    boleta.txtnombre.Text= dtgventas.CurrentRow.Cells["CLIENTE"].Value.ToString();

                    foreach (DataRow row in detalleVenta.Rows)
                    {
                        idproducto = row["IDPRODUCTO"].ToString();
                        codigo = row["CODIGO"].ToString(); ;
                        descripcion = row["DESCRIPCION"].ToString();
                        cantidad = row["CANTIDAD"].ToString();
                        precio = row["PRECIO"].ToString();
                        importe = row["IMPORTE"].ToString();

                        boleta.dgvProductos.Rows.Add(idproducto, codigo, descripcion, cantidad, precio, importe);
                    }

                    ventana.AbrirFormHijo(boleta);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void frmRegistroVentas_Load(object sender, EventArgs e)
        {
            cbocriterio.SelectedIndex = 0;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int fila =Convert.ToInt32(dtgventas.SelectedRows.Count);

            if (fila >-1)
            {
                DialogResult dialogResult = MessageBox.Show("¿Esta seguro de anular la venta?", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    Anular();

                    if (ventaanulada)
                    {
                        Buscar();
                    }

                }
            }

            
        }

        private void Anular()
        {
            frmAnularVenta anulacion = new frmAnularVenta();
            anulacion.lblidventa.Text = dtgventas.CurrentRow.Cells["IDVENTA"].Value.ToString();

            Ventana ventana = new Ventana();
            ventana.AbrirFormDialog(anulacion);
        }
    }
}
