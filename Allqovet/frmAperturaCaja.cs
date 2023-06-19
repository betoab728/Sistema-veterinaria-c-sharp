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
    public partial class frmAperturaCaja : Form
    {
        public frmAperturaCaja()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmAperturaCaja_Load(object sender, EventArgs e)
        {
            txtdni.Focus();
        }

        private void frmAperturaCaja_Activated(object sender, EventArgs e)
        {
            txtdni.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (TrabajadorBLL db = new TrabajadorBLL())
            {
                try
                {

                    Trabajador trabajador = new Trabajador();
                    trabajador = db.BuscarDNI(txtdni.Text);
                    if (trabajador.Idtrabajador!=0)
                    {
                      
                        txttrabajador.Text = trabajador.Nombres + " " + trabajador.ApellidoPaterno + " " + trabajador.ApellidoMaterno;
                        lblidtrabajador.Text = trabajador.Idtrabajador.ToString();

                    }
                    else
                    {
                        MessageBox.Show("No se encontro al trabajador");
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BuscarTrabajador()
        {

        }

        private void txtmonto_Leave(object sender, EventArgs e)
        {
            if (txtmonto.Text.Length==0)
            {
                double monto = 0;
                monto = Convert.ToDouble(txtmonto.Text);
                txtmonto.Text = string.Format("{0:0.00}", monto);
            }
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblidtrabajador.Text)==0)
            {
                MessageBox.Show("seleccione un trabajador");
                return;
            }

            if (txtmonto.Text.Length==0)
            {
                MessageBox.Show("ingrese un monto");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Esta seguro de iniciar caja?", "Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                RegistrarApertura();
            }

          
        }

        private void RegistrarApertura()
        {
            using (CajachicaBLL db=new CajachicaBLL())
            {
                try
                {
                    CajaChica caja = new CajaChica();
                    caja.IdTrabajador = Convert.ToInt32(lblidtrabajador.Text);
                    caja.ImporteApertura = Convert.ToDouble(txtmonto.Text);

                    if (db.Agregar(caja) >0)
                    {
                        MessageBox.Show("Apertura de caja correcto");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
