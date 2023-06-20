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
    public partial class frmRegistrofichas : Form
    {
        public frmRegistrofichas()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ventana ventana = new Ventana();

            frmFicha ficha = new frmFicha(false);

            ventana.AbrirFormHijo(ficha);

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dtgfichas.Rows.Count >0)
            {
                int idficha =Convert.ToInt32( dtgfichas.CurrentRow.Cells["IDFICHA"].Value);

                ImprimirFicha(idficha);
            }
           
           
        }
        private void ImprimirFicha(int idficha)
        {
            using (FichaBLL db = new FichaBLL())
            {
                try
                {
                    frmImprimirFicha ficha = new frmImprimirFicha();
                    ReportDataSource fuente = new ReportDataSource("DataSetImprimirFicha", db.Imprimir(idficha));
                    ficha.reportViewer1.LocalReport.DataSources.Clear();
                    ficha.reportViewer1.LocalReport.DataSources.Add(fuente);
                    ficha.reportViewer1.LocalReport.ReportEmbeddedResource = "Allqovet.Reportes.Ficha.rdlc";
                    ficha.reportViewer1.RefreshReport();
                    ficha.reportViewer1.LocalReport.Refresh();

                    Ventana ventana = new Ventana();
                    ventana.AbrirFormHijo(ficha);

                  //  this.Close();


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void cbocriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbocriterio.SelectedIndex==2)
            {
                txtbuscar.Visible = false;
                panelfecha.Visible = true;
            }
            else
            {
                txtbuscar.Visible = true;
                panelfecha.Visible = false;
            }
        }

        private void BuscarFichaApellido()
        {
            using (FichaBLL db=new FichaBLL())
            {
                try
                {
                    string apellido = txtbuscar.Text;
                    dtgfichas.DataSource = db.BuscarFichaApellido(apellido);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void TamanioColumna()
        {
            dtgfichas.Columns["NOMBRE"].Width = 300;
        }
        private void BuscarFichaDNI()
        {
            using (FichaBLL db = new FichaBLL())
            {
                try
                {
                    string dni = txtbuscar.Text;
                    dtgfichas.DataSource = db.BuscarFichaDNI(dni);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BuscarFichaFechas()
        {
            

            using (FichaBLL db = new FichaBLL())
            {
                try
                {
                    DateTime desde = Convert.ToDateTime(dtpdesde.Value.ToString("yyyy-MM-dd"));
                    DateTime hasta = Convert.ToDateTime(dtphasta.Value.ToString("yyyy-MM-dd"));
                  
                    dtgfichas.DataSource = db.BuscarFichaFechas(desde,hasta);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbocriterio.SelectedIndex==0) //buscar por apellido
            {
                BuscarFichaApellido();
            }
            else if (cbocriterio.SelectedIndex == 1)  //buscar por dni
            {
                BuscarFichaDNI();
            }

            else if (cbocriterio.SelectedIndex == 2)  //buscar por fechas
            {
                BuscarFichaFechas();
            }

            TamanioColumna();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dtgfichas.Rows.Count >0)
            {
                Ventana ventana = new Ventana();

                int idficha = Convert.ToInt32(dtgfichas.CurrentRow.Cells["IDFICHA"].Value);

                frmFicha ficha = new frmFicha(true);
                ficha.lblidficha.Text = idficha.ToString();
                ventana.AbrirFormHijo(ficha);
              

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
