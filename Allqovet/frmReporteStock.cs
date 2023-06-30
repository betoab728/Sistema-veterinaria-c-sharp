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
    public partial class frmReporteStock : Form
    {
        public frmReporteStock()
        {
            InitializeComponent();
        }

        private void frmReporteStock_Load(object sender, EventArgs e)
        {
            ListarMarcas();
            ListarCategorias();
            ListarVitrinas();
        }

        private void ListarMarcas()
        {
            using (MarcaBLL db=new MarcaBLL())
            {
                try
                {
                    cmbmarca.DataSource = db.Listar();
                    cmbmarca.DisplayMember = "Nombre";
                    cmbmarca.ValueMember = "Idmarca";
                    cmbmarca.SelectedIndex = -1;

                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void ListarCategorias()
        {
            using (CategoriaBLL db = new CategoriaBLL())
            {
                try
                {
                    cmbcategoria.DataSource = db.Listar();
                    cmbcategoria.DisplayMember = "Nombre";
                    cmbcategoria.ValueMember = "Idcategoria";
                    cmbcategoria.SelectedIndex = -1;

                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void ListarVitrinas()
        {
            using (VitrinaBLL db = new VitrinaBLL())
            {
                try
                {
                    cmbvitrina.DataSource = db.Listar();
                    cmbvitrina.DisplayMember = "descripcion";
                    cmbvitrina.ValueMember = "idVitrina";
                    cmbvitrina.SelectedIndex = -1;

                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkmarca.Checked)
            {
                cmbmarca.Enabled = true;
            }
            else
            {
                cmbmarca.Enabled = false;
            }
        }

        private void chkcategoria_CheckedChanged(object sender, EventArgs e)
        {
            if (chkcategoria.Checked)
            {
                cmbcategoria.Enabled = true;
            }
            else
            {
                cmbcategoria.Enabled = false;
            }
        }

        private void chkvitrina_CheckedChanged(object sender, EventArgs e)
        {
            if (chkvitrina.Checked)
            {
                cmbvitrina.Enabled = true;
            }
            else
            {
                cmbvitrina.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Consulta();
        }

        private void Consulta()
        {
            using (ProductoBLL db = new ProductoBLL())
            {
                try
                {
                    int idmarca = 0;
                    int idcategoria = 0;
                    int idvitrina = 0;
                    int stock = 0;


                    if (chkmarca.Checked) idmarca = Convert.ToInt32(cmbmarca.SelectedValue);
                    if (chkcategoria.Checked) idcategoria = Convert.ToInt32(cmbcategoria.SelectedValue);
                    if (chkvitrina.Checked) idvitrina = Convert.ToInt32(cmbvitrina.SelectedValue);
                    if (chkstock.Checked) stock = 1;

                    dgvproductos.DataSource = db.ReporteStock(idmarca,idcategoria,idvitrina,stock);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DatagridAexcel exportar = new DatagridAexcel();

            exportar.ExportarDataGridViewExcel(dgvproductos);
        }



        private void Reporte()
        {
            using (ProductoBLL db = new ProductoBLL())
            {
                try
                {

                    int idmarca = 0;
                    int idcategoria = 0;
                    int idvitrina = 0;
                    int stock = 0;


                    if (chkmarca.Checked) idmarca = Convert.ToInt32(cmbmarca.SelectedValue);
                    if (chkcategoria.Checked) idcategoria = Convert.ToInt32(cmbcategoria.SelectedValue);
                    if (chkvitrina.Checked) idvitrina = Convert.ToInt32(cmbvitrina.SelectedValue);
                    if (chkstock.Checked) stock = 1;


                    ReportDataSource fuente = new ReportDataSource("DataSetReporteStock", db.ReporteStock(idmarca, idcategoria, idvitrina, stock));

                    frmImprimirStock imprimir = new frmImprimirStock();

                    imprimir.reportViewer1.LocalReport.DataSources.Clear();
                    imprimir.reportViewer1.LocalReport.DataSources.Add(fuente);
                    imprimir.reportViewer1.LocalReport.ReportEmbeddedResource = "Allqovet.Reportes.ReporteStock.rdlc";

                    //parametros
                    string marca = "TODOS";
                    string categoria = "TODOS";
                    string vitrina = "TODOS";
                    string fecha = DateTime.Now.ToString("dd/MM/yyyy");

                    if (chkmarca.Checked) marca = cmbmarca.Text;
                    if (chkcategoria.Checked) categoria = chkcategoria.Text;
                    if (chkvitrina.Checked) vitrina = cmbvitrina.Text;



                    ReportParameter[] p = new ReportParameter[4];
                    p[0] = new ReportParameter("pmarca", marca);
                    p[1] = new ReportParameter("pcategoria", categoria);
                    p[2] = new ReportParameter("pvitrina", vitrina);
                    p[3] = new ReportParameter("pfecha", fecha);

                    imprimir.reportViewer1.LocalReport.SetParameters(p);

                    imprimir.reportViewer1.RefreshReport();
                    imprimir.reportViewer1.LocalReport.Refresh();

                    Ventana ventana = new Ventana();
                    ventana.AbrirFormHijo(imprimir);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reporte();
        }
    }
}
