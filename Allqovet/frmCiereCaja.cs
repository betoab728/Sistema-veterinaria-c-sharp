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
    public partial class frmCiereCaja : Form
    {
      

        public frmCiereCaja()
        {
            InitializeComponent();
        }

        private void frmCiereCaja_Load(object sender, EventArgs e)
        {
            int idcaja = 0;
            idcaja = Idcajachica();
            VentasCierre(idcaja);
            ResumenVentasMediopago(idcaja);
            EgresosCierre(idcaja);
            ResumenEgresosMEdioPago(idcaja);

            SaldoFinal();
        }

        private void VentasCierre(int idcaja)
        {
            using (CajachicaBLL db = new CajachicaBLL())
            {
                try { 
                
                    dgvventas.DataSource = db.VentasCierre(idcaja);

                    if (dgvventas.Rows.Count >0)
                    {
                        double inicial = 0;

                      

                        foreach (DataGridViewRow row in dgvventas.Rows)
                        {
                            inicial = Convert.ToDouble(row.Cells["INICIAL"].Value);
                        
                        }
                        txtinicial.Text = string.Format("{0:0.00}", inicial); 

                    }

                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }





        private void ResumenVentasMediopago(int idcaja)
        {
            using (CajachicaBLL db = new CajachicaBLL())
            {
                try
                {

                    dgvTotalMediopagoVenta.DataSource = db.ResumenVentasMedioPago(idcaja);

                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void EgresosCierre(int idcaja)
        {
            using (CajachicaBLL db = new CajachicaBLL())
            {
                try
                {

                    dgvEgresos.DataSource = db.EgresosCierre( idcaja);

                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void ResumenEgresosMEdioPago(int idcaja)
        {
            using (CajachicaBLL db = new CajachicaBLL())
            {
                try
                {

                    dgvTotalEgresos.DataSource = db.ResumenEgresosMEdioPago(idcaja);

                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void SaldoFinal()
        {

            double ingresos_efectivo = 0;
            double egresos_Efectivo = 0;
            double saldo_inicial = Convert.ToDouble(txtinicial.Text);
            double saldo = 0;

            string mediopago = "";

            for (int fila = 0; fila < dgvTotalMediopagoVenta.Rows.Count; fila++)
            {
                mediopago = dgvTotalMediopagoVenta.Rows[fila].Cells["MEDIOPAGO"].Value.ToString();
                if (mediopago.Equals("Efectivo"))
                {

                    ingresos_efectivo =Convert.ToDouble( dgvTotalMediopagoVenta.Rows[fila].Cells["TOTAL"].Value.ToString());
                   
                }

            }

            for (int fila = 0; fila < dgvTotalEgresos.Rows.Count; fila++)
            {
                mediopago = dgvTotalEgresos.Rows[fila].Cells["MEDIOPAGO"].Value.ToString();
                if (mediopago.Equals("Efectivo"))
                {

                    egresos_Efectivo = Convert.ToDouble(dgvTotalEgresos.Rows[fila].Cells["TOTAL"].Value.ToString());

                }

            }

            txtcierre.Text = (ingresos_efectivo - egresos_Efectivo).ToString();

            saldo = ingresos_efectivo - egresos_Efectivo + saldo_inicial;

            //  txtcierre.Text = dtgresumenmedios.Rows[indice].Cells["TOTAL"].Value.ToString();

         
            txtfinal.Text = string.Format("{0:0.00}", saldo); ;

        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿ Esta seguro de hacer el cierre de caja?", "Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                CerrarCaja();
            }
        }

        private void CerrarCaja()
        {
            using (CajachicaBLL db=new CajachicaBLL())
            {
                try
                {
                    double importecierre = 0;
                    if (txtcierre.Text.Length>0)  importecierre = Convert.ToInt32(txtcierre.Text);

                    CajaChica cajaChica = new CajaChica();
                    cajaChica.Idcajachica = Idcajachica();
                    cajaChica.ImporteCierra = importecierre;


                    if (db.CerrarCaja(cajaChica) > 0)
                    {
                        frmMenu menu = Application.OpenForms.OfType<frmMenu>().SingleOrDefault();
                        if (menu != null)
                        {
                            menu.lblnombreusuario.Text = "-";
                            menu.lblEstadocaja.Text = "Estado caja: Cerrado";
                        }

                            MessageBox.Show("La caja se ha cerrado correctamente");



                        ImprimirCierre(cajaChica.Idcajachica);

                        this.Close();
                    }



                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void ImprimirCierre(int idcaja)
        {
            using (CajachicaBLL db = new CajachicaBLL())
            {
                try
                {

                    frmImprimirCierre cierre = new frmImprimirCierre();

                    ReportDataSource fuente = new ReportDataSource("DataSetVentasDia", db.VentasCierre(idcaja));

                    ReportDataSource fuente2 = new ReportDataSource("DataSetCobroVentasDia", db.CobrosCierre(idcaja));

                    ReportDataSource fuente3 = new ReportDataSource("DataSetResumenMedioPago", db.ResumenVentasMedioPago(idcaja));

                    ReportDataSource fuente5 = new ReportDataSource("DataSetEgresos", db.EgresosCierre(idcaja));

                    cierre.reportViewer1.LocalReport.DataSources.Clear();

                    cierre.reportViewer1.LocalReport.DataSources.Add(fuente);
                    //cierre.reportViewer1.LocalReport.DataSources.Add(fuente1);
                    cierre.reportViewer1.LocalReport.DataSources.Add(fuente2);
                    cierre.reportViewer1.LocalReport.DataSources.Add(fuente3);
                
                    cierre.reportViewer1.LocalReport.DataSources.Add(fuente5);

                    cierre.reportViewer1.LocalReport.ReportEmbeddedResource = "Allqovet.Reportes.CierreCaja.rdlc";

                    cierre.reportViewer1.RefreshReport();
                    cierre.reportViewer1.LocalReport.Refresh();

                    cierre.ShowDialog();
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
                    Idcajachica = db.AperturaActual();
                }
                catch (Exception ex)
                {
                    Idcajachica = 0;
                    MessageBox.Show(ex.Message);
                }

                return Idcajachica;
            }
        }
    }
}
