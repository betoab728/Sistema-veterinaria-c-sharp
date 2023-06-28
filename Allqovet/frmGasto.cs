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

namespace Allqovet
{
    public partial class frmGasto : Form
    {
        public frmGasto()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGasto_Load(object sender, EventArgs e)
        {
            ListarOperacion();
            ListarMedioPAgo();
            ListaTipoDocumento();
        }

        private void ListarOperacion()
        {
            using (TipoOperacionBLL db=new TipoOperacionBLL())
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

        private void ListarMedioPAgo()
        {
            using (MedioPagoBLL db = new MedioPagoBLL())
            {
                try
                {

                    cmbforma.DataSource = db.Listar();
                    cmbforma.DisplayMember = "Descripcion";
                    cmbforma.ValueMember = "Idmediopago";

                    cmbforma.SelectedIndex = -1;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message); ;
                }
            }
        }

        private void ListaTipoDocumento()
        {
            using (DocumentoBLL db = new DocumentoBLL())
            {
                try
                {
                    cmbdoc.DisplayMember = "nombre";
                    cmbdoc.ValueMember = "iddocumento";
                    cmbdoc.DataSource = db.Listar();

                    cmbdoc.SelectedIndex = -1;
                    cmbforma.SelectedIndex = -1;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message); ;
                }
            }
        }

        private void txtimporte_Leave(object sender, EventArgs e)
        {
            if (txtimporte.Text.Length > 0)
            {
            

                double precio = 0;
                precio = Convert.ToDouble(txtimporte.Text);
                txtimporte.Text = string.Format("{0:0.00}", precio);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cmbtipooperacion.SelectedIndex==-1)
            {
                MessageBox.Show("Seleccione un tipo de operacion");
                return;
            }

            if(cmbforma.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una forma dwe pago");
                return;
            }

            if(cmbdoc.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una tipo de documento");
                return;
            }

        }

        private void RegistraMovimiento()
        {
            Operacion operacion = new Operacion();

        }

    }
}
