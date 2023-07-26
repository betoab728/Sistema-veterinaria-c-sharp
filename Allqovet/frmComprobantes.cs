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

namespace Allqovet
{
    public partial class frmComprobantes : Form
    {
        public frmComprobantes()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbtipo.SelectedIndex==0)
            {
                BuscarBoleta();
            }
            else
            {
                BuscarFactura();
            }

          
        }

        private void BuscarBoleta()
        {
            if (cbocriterio.SelectedIndex == 0)
            {
                BuscarBoletaFechas();
            }
            else
            {
                BuscarBoletaApellidos();
            }
        }

        private void BuscarFactura()
        {
            if (cbocriterio.SelectedIndex == 0)
            {
                BuscarFacturaFechas();
            }
            else
            {
                BuscarFacturaRazon();
            }
        }

        private void BuscarBoletaApellidos()
        {
            using (BoletaBLL db = new BoletaBLL())
            {
                try
                {
                    string apellido = txtbuscar.Text;
                   // dtgventas.DataSource = db.BuscarVentaApellidos(apellido);
                   // FormatoTabla();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BuscarBoletaFechas()
        {
            using (BoletaBLL db = new BoletaBLL())
            {
                try
                {
                    DateTime desde = Convert.ToDateTime(dtpdesde.Value.ToString("yyyy-MM-dd"));
                    DateTime hasta = Convert.ToDateTime(dtphasta.Value.ToString("yyyy-MM-dd"));

                   dgvComprobantes.DataSource = db.BuscarBoletaFechas(desde, hasta);
                  
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BuscarFacturaFechas()
        {
            using (FacturaBLL db = new FacturaBLL())
            {
                try
                {
                    DateTime desde = Convert.ToDateTime(dtpdesde.Value.ToString("yyyy-MM-dd"));
                    DateTime hasta = Convert.ToDateTime(dtphasta.Value.ToString("yyyy-MM-dd"));

                    dgvComprobantes.DataSource = db.BuscarFacturaFechas(desde, hasta);
                  //  FormatoTabla();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BuscarFacturaRazon()
        {
            using (VentaBLL db = new VentaBLL())
            {
                try
                {
                    string apellido = txtbuscar.Text;
                    //dtgventas.DataSource = db.BuscarVentaApellidos(apellido);
                  //  FormatoTabla();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }





        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void frmComprobantes_Load(object sender, EventArgs e)
        {
            cbocriterio.SelectedIndex = 0;
            cmbtipo.SelectedIndex = 0;
        }

        private void cbocriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbocriterio.SelectedIndex == 0)
            {
                panelfecha.Visible = true;
                txtbuscar.Visible = false;
            }
            else
            {
                panelfecha.Visible = false;
                txtbuscar.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DatagridAexcel exportar = new DatagridAexcel();

            exportar.ExportarDataGridViewExcel(dgvComprobantes);
        }

    }
}
