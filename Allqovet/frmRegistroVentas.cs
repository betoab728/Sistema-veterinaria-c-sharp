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

        }

        private void button2_Click(object sender, EventArgs e)
        {

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

        private void BuscarVentaApellidos()
        {
            using (VentaBLL db=new VentaBLL())
            {
                try
                {
                    string apellido = txtbuscar.Text;
                    dtgventas.DataSource = db.BuscarVentaApellidos(apellido);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message); 
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
    }
}
