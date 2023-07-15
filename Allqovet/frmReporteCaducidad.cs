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
    public partial class frmReporteCaducidad : Form
    {
        public frmReporteCaducidad()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dtpdesde_ValueChanged(object sender, EventArgs e)
        {

        }

        private void frmReporteCaducidad_Load(object sender, EventArgs e)
        {
            dtpCaducidad.Format = DateTimePickerFormat.Custom;
            dtpCaducidad.CustomFormat = "MM/yyyy";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reporte();
        }

        private void Reporte()
        {
            using (ProductoBLL db = new ProductoBLL())
            {
                try
                {
                    DateTime cadu = Convert.ToDateTime(dtpCaducidad.Value.ToString("yyyy-MM-dd"));
                    ReportDataSource fuente = new ReportDataSource("DataSetCaducidad", db.ReporteCaducidad(cadu));
                 
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(fuente);
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Allqovet.Reportes.ReporteCaducidad.rdlc";
                    
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
