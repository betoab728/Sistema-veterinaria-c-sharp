using AllqovetBLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Reporting.WinForms;

namespace Allqovet
{
    public partial class frmFicha : Form
    {
        private bool edicion = false;
        public frmFicha(bool Editar)
        {
            InitializeComponent();
            edicion = Editar;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmBusCliFicha ficha = new frmBusCliFicha();
            ficha.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dtpproxcita.Checked==false)
            {
                MessageBox.Show("Indique la fecha de la proxima cita");
                return;
            }

            if (dtpfechaAtencion.Checked == false)
            {
                MessageBox.Show("Indique la fecha de atencion");
                return;
            }

            if (txtdescripcion.Text.Length==0)
            {
                MessageBox.Show("Ingrese una descripcion");
                return;
            }
            if (txttemperatura.Text.Length == 0)
            {
                MessageBox.Show("Ingrese una temperatura");
                return;
            }

            dtgficha.Rows.Add(dtpfechaAtencion.Value.ToString("dd/MM/yyyy"),txtdescripcion.Text,txttemperatura.Text,dtpproxcita.Value.ToString("dd/MM/yyyy"),"0");
            dtpfechaAtencion.Checked = false;
            txttemperatura.Text = "";
            dtpproxcita.Checked = false;
            txtdescripcion.Text = "";
          

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // dtgficha.Rows.Add(dtpfechaAtencion.Value.ToString("dd/MM/yyyy"), dtpfecha.Value.ToString("dd/MM/yyyy"), txtraza.Text, txtespecie.Text, cmbsexo.Text, txtcapa.Text, txtobs.Text);
            if (dtgficha.CurrentRow.Cells["R"].Value.Equals("0"))
            {
                dtgficha.Rows.Remove(dtgficha.CurrentRow);
            }
          

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (edicion)
            {
                Actualizar();
            }
            else
            {
                Nuevo();
            }


            
        }

        private void Nuevo()
        {
            DialogResult dialogResult = MessageBox.Show("Esta seguro de registrar la ficha?", "Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                int idficha = RegistrarFicha();
                if (idficha > 0)
                {
                    MessageBox.Show("cliente registrado correctamente");
                    ImprimirFicha(idficha);
                    this.Close();
                }
            }
        }

        private void Actualizar()
        {
            int r = 0;

            using (FichaBLL db = new FichaBLL())
            {

                try
                {


                    Ficha ficha = new Ficha();
                    List<DetalleFicha> detalleFichas = new List<DetalleFicha>();

                    ficha.Idficha= Convert.ToInt32(lblidficha.Text);
                    ficha.numero = Convert.ToInt32(lblnumeroficha.Text);
                    ficha.Idcliente = Convert.ToInt32(lblidcliente.Text);
                    ficha.Idmascota = Convert.ToInt32(lblidmascota.Text);

                    //lleno detalle ficha

                    foreach (DataGridViewRow row in dtgficha.Rows)
                    {
                        if (row.Cells["R"].Value.ToString().Equals("0"))
                        {
                            DetalleFicha detalle = new DetalleFicha();

                            detalle.fecha = Convert.ToDateTime(row.Cells["FECHA"].Value.ToString());
                            detalle.descripcion = row.Cells["DESCRIPCION"].Value.ToString();
                            detalle.temperatura = row.Cells["TEMPERATURA"].Value.ToString();
                            detalle.proxcita = Convert.ToDateTime(row.Cells["PROX_CITA"].Value.ToString());

                            detalleFichas.Add(detalle);
                        }

                    }

                    if (detalleFichas.Count ==0)
                    {
                        MessageBox.Show("No hay datos para actualizar");
                        return;
                    }

                    r = db.Editar(ficha, detalleFichas);

                    if (r >0)
                    {
                        MessageBox.Show("Ficha actualizada");
                        this.Close();
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                    r = 0;
                }
            }

          
        }


        private int RegistrarFicha()
        {

            int r = 0;

            using (FichaBLL db = new FichaBLL())
            {

                try
                {
                  

                    Ficha ficha = new Ficha();
                    List<DetalleFicha> detalleFichas = new List<DetalleFicha>();

                    ficha.numero = Convert.ToInt32(lblnumeroficha.Text);
                    ficha.Idcliente = Convert.ToInt32(lblidcliente.Text);
                    ficha.Idmascota = Convert.ToInt32(lblidmascota.Text);

                    //lleno detalle ficha

                    foreach (DataGridViewRow row in dtgficha.Rows)
                    {
                        DetalleFicha detalle = new DetalleFicha();
                     
                        detalle.fecha = Convert.ToDateTime(row.Cells["FECHA"].Value.ToString());
                        detalle.descripcion = row.Cells["DESCRIPCION"].Value.ToString();
                        detalle.temperatura = row.Cells["TEMPERATURA"].Value.ToString();
                        detalle.proxcita = Convert.ToDateTime(row.Cells["PROX_CITA"].Value.ToString());

                        detalleFichas.Add(detalle);

                    }

                    r = db.Agregar(ficha, detalleFichas);


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                    r = 0;
                }
            }

            return r;

        }

        private void frmFicha_Load(object sender, EventArgs e)
        {
            if (edicion)
            {
                BuscarFicha();
            }
            else
            {
                CorrelativoFicha();
            }

               
        }

        private void BuscarFicha()
        {
            using (FichaBLL db=new FichaBLL())
            {
                try
                {
                    int idficha = Convert.ToInt32(lblidficha.Text);

                    DataTable ficha = db.BuscarFichaID(idficha);

                    if (ficha.Rows.Count>0)
                    {
                        lblidficha.Text= ficha.Rows[0][0].ToString();
                        lblnumeroficha.Text= ficha.Rows[0][1].ToString();
                        lblidcliente.Text = ficha.Rows[0][2].ToString(); 
                        txtcliente.Text = ficha.Rows[0][3].ToString(); 
                        txtdireccion.Text = ficha.Rows[0][4].ToString();
                        txttelefono.Text = ficha.Rows[0][5].ToString();

                        lblidmascota.Text = ficha.Rows[0][6].ToString();
                        txtmascota.Text = ficha.Rows[0][7].ToString(); 
                        txtespecie.Text = ficha.Rows[0][8].ToString() ;
                        txtcapa.Text = ficha.Rows[0][9].ToString(); 
                        txtraza.Text = ficha.Rows[0][10].ToString();

                        cmbsexo.SelectedIndex=ficha.Rows[0][11].ToString().Equals("m")?0:1;

                        dtpfecha.Value = Convert.ToDateTime(ficha.Rows[0][12].ToString()); 

                        foreach (DataRow row in ficha.Rows)
                        {
                            dtgficha.Rows.Add(row["fecha"], row["descripcion"], row["temperatura"], row["proxcita"], row["registrado"]);

                        }
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CorrelativoFicha()
        {
            using (FichaBLL db=new FichaBLL())
            {
                try
                {
                    lblnumeroficha.Text = db.CorrelativoFicha();
                }
                catch (Exception ex)
                {

                  MessageBox.Show(ex.Message) ;
                }
            }
        }

       private void ImprimirFicha(int idficha)
        {
            using (FichaBLL db = new FichaBLL())
            {
                try
                {
                    frmImprimirFicha ficha = new frmImprimirFicha();
                    ReportDataSource fuente = new ReportDataSource("DataSetEntrada", db.Imprimir(idficha));
                    ficha.reportViewer1.LocalReport.DataSources.Clear();
                    ficha.reportViewer1.LocalReport.DataSources.Add(fuente);
                    ficha.reportViewer1.LocalReport.ReportEmbeddedResource = "Allqovet.Reportes.Ficha.rdlc";

                    //ReportParameter[] p = new ReportParameter[6];
                    //p[0] = new ReportParameter("pfecha", dtpfecha.Value.ToString("dd/MM/yyyy"));
                    //reportViewer1.LocalReport.SetParameters(p);

                    ficha.reportViewer1.RefreshReport();
                    ficha.reportViewer1.LocalReport.Refresh();

                    Ventana ventana = new Ventana();
                    ventana.AbrirFormHijo(ficha);

                    this.Close();


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
        }
    }
}
