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
            frmGasto gasto = new frmGasto();

            Ventana ventana = new Ventana();
            ventana.AbrirFormHijo(gasto);
        }
    }
}
