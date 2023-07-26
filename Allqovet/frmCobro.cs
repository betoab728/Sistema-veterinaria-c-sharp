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
    public partial class frmCobro : Form
    {
        public frmCobro()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmCobro_Load(object sender, EventArgs e)
        {
            panelefectivo.Visible = true;
            paneltarjeta.Visible = false;

            ListarMedioPAgo();

        }

        private void ListarMedioPAgo()
        {
            using (MedioPagoBLL db=new MedioPagoBLL())
            {
                try
                {

                    cmbmedio.DataSource = db.Listar();
                    cmbmedio.DisplayMember = "Descripcion";
                    cmbmedio.ValueMember = "Idmediopago";

                    panelefectivo.Visible = true;
                    paneltarjeta.Visible = false;

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message); ;
                }
            }
        }

        private void cmbmedio_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (RegistrarPago()>0)
            {
                frmVentas frm = Application.OpenForms.OfType<frmVentas>().SingleOrDefault();

                int idventa = Convert.ToInt32(lblidventa.Text);



                frm.Imprimir(idventa);
                frm.Close();
                this.Close();
            }

          


        }


        private int RegistrarPago()
        {
            int idpago = 0;
            using (OperacionBLL db = new OperacionBLL())
            {
                try
                {
                    Operacion operacion = new Operacion();
                    operacion.Concepto = "Pago de venta N° "+lblnumeroventa.Text;
                    operacion.Tipo = "I";
                    operacion.Idmediopago = Convert.ToInt32(cmbmedio.SelectedValue);
                    operacion.Importe = Convert.ToDouble(lbltotal.Text);
                    operacion.Digitostarjeta = txtdigitos.Text;
                    operacion.Idventa = Convert.ToInt32(lblidventa.Text);
                    operacion.Idcajachica = Idcajachica();
                    operacion.idtipo = 1; // 1 es pago de venta

                    idpago = db.AgregarPagoVenta(operacion);
                }
                catch (Exception ex)
                {
                    idpago = 0;
                    MessageBox.Show(ex.Message) ;
                }

                return idpago;
            }
        }


        private int Idcajachica()
        {
            int Idcajachica = 0;
            using (CajachicaBLL db=new CajachicaBLL())


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

        private void cmbmedio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbmedio.Items.Count > 0)
            {
                int idmedio = 0;
                idmedio = Convert.ToInt32(cmbmedio.SelectedValue);


                if (idmedio == 1)
                {
                    panelefectivo.Visible = true;
                    paneltarjeta.Visible = false;
                }
                else
                {
                    panelefectivo.Visible = false;
                    paneltarjeta.Visible = true;
                }
            }
        }

        private void txtrecibido_Leave(object sender, EventArgs e)
        {



            double total = Convert.ToDouble(lbltotal.Text);
            double recibido = Convert.ToDouble(txtrecibido.Text);
            double cambio = recibido - total;

            txtrecibido.Text = string.Format("{0:0.00}", recibido);

            txtcambio.Text = string.Format("{0:0.00}", cambio);


        }
    }
}
