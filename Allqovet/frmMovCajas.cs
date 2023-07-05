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

namespace Allqovet
{
    public partial class frmMovCajas : Form
    {
        public frmMovCajas()
        {
            InitializeComponent();
        }

        private void frmMovCajas_Load(object sender, EventArgs e)
        {
            ListarFormaPagos();
            ListarOperaciones();
        }

        private void ListarOperaciones()
        {
            using (TipoOperacionBLL db = new TipoOperacionBLL())
            {
                try
                {
                    cmbtipooperacion.DataSource = db.Listar();
                    cmbtipooperacion.DisplayMember = "nombre";
                    cmbtipooperacion.ValueMember = "idtipooperacion";
                    cmbtipooperacion.SelectedIndex = -1;


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ListarFormaPagos()
        {
              using (MedioPagoBLL db = new MedioPagoBLL())
                {
                    try
                    {

                        cmbtipopago.DataSource = db.Listar();
                        cmbtipopago.DisplayMember = "Descripcion";
                        cmbtipopago.ValueMember = "Idmediopago";
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message); ;
                    }
                }
            
        }


        private void rbfecfa_CheckedChanged(object sender, EventArgs e)
        {
            lbldesde.Enabled = true;
            lblhasta.Enabled = true;

            dtpdesde.Enabled = true;
            dtphasta.Enabled = true;

        }

        private void rbactual_CheckedChanged(object sender, EventArgs e)
        {
            lbldesde.Enabled = false;
            lblhasta.Enabled = false;

            dtpdesde.Enabled = false;
            dtphasta.Enabled = false;
        }

        private void chkforma_CheckedChanged(object sender, EventArgs e)
        {
            if (chkforma.Checked)
            {
                cmbtipopago.Enabled = true;
            }
            else
            {
                cmbtipopago.Enabled = false;
            }


        }

        private void chkoperacion_CheckedChanged(object sender, EventArgs e)
        {
            if(chkoperacion.Checked)
            {
                cmbtipooperacion.Enabled = true;
            }
            else
            {
                cmbtipooperacion.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmGasto gasto = new frmGasto(false);

            Ventana ventana = new Ventana();
            ventana.AbrirFormHijo(gasto);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿ Esta seguro de Anular el movimiento de caja?", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Anular();
            }
        }

        private void Anular()
        {
            using (OperacionBLL db= new OperacionBLL())
            {
                try
                {
                    int idoperacion = 0;
                    idoperacion = Convert.ToInt32(dgvMovimientos.CurrentRow.Cells["IDOPERACION"].Value);

                    int r = db.Anular(idoperacion);

                    if (r>0)
                    {
                        MessageBox.Show("Registro anulado");
                        Consulta();

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Consulta();
        }

        private void Consulta()
        {
            if (rbactual.Checked)
            {


                BuscarMovCajaActual();
            }
            else if (rbfecfa.Checked)
            {
                BuscarMovCajaFechas();
            }
        }

        private void BuscarMovCajaActual()
        {
            using (OperacionBLL db=new OperacionBLL())
            {
                try
                {
                    int idcajachica = 0;
                    int idmediopago = 0;
                    int idtipoOoperacion = 0;

                    idcajachica = Idcajachica();
                    if (chkforma.Checked) idmediopago = Convert.ToInt32(cmbtipopago.SelectedValue);
                    if (chkoperacion.Checked) idtipoOoperacion = Convert.ToInt32(cmbtipooperacion.SelectedValue);

                    dgvMovimientos.DataSource = db.BuscarMovCajaActual(idcajachica, idmediopago, idtipoOoperacion);

                    if (dgvMovimientos.Rows.Count >0)
                    {
                     
                        dgvMovimientos.Columns["IDOPERACION"].Visible = false;

                       foreach (DataGridViewRow row in dgvMovimientos.Rows)
                        {

                            if (row.Cells["ESTADO"].Value.ToString() == "ANULADO")
                            {
                                row.DefaultCellStyle.BackColor = Color.Red;
                            }
                        }

                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void BuscarMovCajaFechas()
        {
            using (OperacionBLL db = new OperacionBLL())
            {
                try
                {
                    DateTime desde = Convert.ToDateTime(dtpdesde.Value.ToString("yyyy-MM-dd"));
                    DateTime hasta = Convert.ToDateTime(dtphasta.Value.ToString("yyyy-MM-dd"));
                    int idmediopago = 0;
                    int idtipoOoperacion = 0;

                 
                    if (chkforma.Checked) idmediopago = Convert.ToInt32(cmbtipopago.SelectedValue);
                    if (chkoperacion.Checked) idtipoOoperacion = Convert.ToInt32(cmbtipooperacion.SelectedValue);

                    dgvMovimientos.DataSource = db.BuscarMovCajaFechas(desde, hasta, idmediopago, idtipoOoperacion);

                    if (dgvMovimientos.Rows.Count>0)
                    {
                        dgvMovimientos.Columns["IDOPERACION"].Visible = false;

                        foreach (DataGridViewRow row in dgvMovimientos.Rows)
                        {
                         

                            if (row.Cells["ESTADO"].Value.ToString() == "ANULADO")
                                
                            {
                               
                                row.DefaultCellStyle.BackColor = Color.Red;
                            }
                        }
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

        private void button3_Click(object sender, EventArgs e)
        {
            DatagridAexcel exportar = new DatagridAexcel();

            exportar.ExportarDataGridViewExcel(dgvMovimientos);
        }

        private void button6_Click(object sender, EventArgs e)
        {

            frmGasto gasto = new frmGasto(true);

            int idoperacion = 0;

            idoperacion = Convert.ToInt32(dgvMovimientos.CurrentRow.Cells["IDOPERACION"].Value);
            gasto.lblidoperacion.Text = idoperacion.ToString();

            Ventana ventana = new Ventana();
            ventana.AbrirFormHijo(gasto);
        }


    }
}
