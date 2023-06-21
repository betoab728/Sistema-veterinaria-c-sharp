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
using Microsoft.Reporting.WinForms;

namespace Allqovet
{
    public partial class frmReporteVenta : Form
    {
        public frmReporteVenta()
        {
            InitializeComponent();
        }

        private void frmReporteVenta_Load(object sender, EventArgs e)
        {

          
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReporteVentas();
        }

        private void ReporteVentas()
        {
            using (VentaBLL db=new VentaBLL())
            {
                try
                {
                    DateTime desde = Convert.ToDateTime(dtpdesde.Value.ToString("yyyy-MM-dd"));
                    DateTime hasta = Convert.ToDateTime(dtphasta.Value.ToString("yyyy-MM-dd"));

                    ReportDataSource fuente = new ReportDataSource("DataSetReporteVenta", db.ReporteVentas(desde, hasta));

                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(fuente);
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Allqovet.Reportes.ReporteVentas.rdlc";

                    ReportParameter[] p = new ReportParameter[2];
                    p[0] = new ReportParameter("pdesde", dtpdesde.Value.ToString("dd/MM/yyyy"));
                    p[1] = new ReportParameter("phasta", dtphasta.Value.ToString("dd/MM/yyyy"));

                    reportViewer1.LocalReport.SetParameters(p);
                    reportViewer1.RefreshReport();
                    reportViewer1.LocalReport.Refresh();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
