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
        bool edicion = false;

        SoloNumeros validar = new SoloNumeros();
        public frmGasto(bool editar)
        {
            InitializeComponent();

            edicion = editar;
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


            if (edicion)
            {
                MostrarRegistro();
            }
        }
        private void MostrarRegistro()
        {
            using (OperacionBLL db = new OperacionBLL())
            {
                try
                {
                    int idoperacion = 0;
                   idoperacion =Convert.ToInt32(lblidoperacion.Text);

                    Operacion operacion = new Operacion();

                   operacion = db.MostrarRegistro(idoperacion);
                   int idt = operacion.idtipo;


                      cmbtipooperacion.SelectedValue = operacion.idtipo;

                     txtdescripcion.Text = operacion.Concepto;
                     dtpfecha.Value = operacion.fecha;

                     cmbforma.SelectedValue = operacion.Idmediopago;

                     cmbdoc.SelectedValue = operacion.iddocumento;
                     txtserie.Text = operacion.serie;
                     txtnumero.Text = operacion.numero.ToString();
                     txtimporte.Text = string.Format("{0:0.00}",operacion.Importe);
                     cmbtipo.SelectedValue = operacion.Tipo;


                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error en el metodo mostrar registro: "+ex.Message);
                }
            }
        }

        private void ListarOperacion()
        {
            using (TipoOperacionBLL db=new TipoOperacionBLL())
            {
                try
                {
                    DataTable operacion = db.Listar();

                    cmbtipooperacion.DataSource = operacion;
                    cmbtipooperacion.DisplayMember = "nombre";
                    cmbtipooperacion.ValueMember = "idtipooperacion";
                    cmbtipooperacion.SelectedIndex = -1;

                    cmbtipo.DataSource = operacion;
                    cmbtipo.DisplayMember = "descripcion_tipo";
                    cmbtipo.ValueMember = "tipo";
                    cmbtipo.SelectedIndex = -1;


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

            if (txtdescripcion.Text.Length==0)
            {
                MessageBox.Show("Ingrese una descripcion");
                return;
            }
            if (txtimporte.Text.Length==0)
            {
                MessageBox.Show("Ingrese un importe");
                return;
            }



            DialogResult dialogResult = MessageBox.Show(" Esta seguro de registrar la operacion?", "Movimiento de caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (!edicion)
                {
                    RegistraMovimiento();
                }
                else
                {
                    Actualizar();
                }
             
            }

        }

        private void Actualizar()
        {
            using (OperacionBLL db = new OperacionBLL())
            {
                try
                {
                    Operacion operacion = new Operacion();

                    operacion.fecha = dtpfecha.Value;
                    operacion.Concepto = txtdescripcion.Text;
                    operacion.Tipo = cmbtipo.SelectedValue.ToString();
                    operacion.Idmediopago = Convert.ToInt32(cmbforma.SelectedValue);
                    operacion.Importe = Convert.ToDouble(txtimporte.Text);
                    operacion.Idcajachica = Idcajachica();
                    operacion.idtipo = Convert.ToInt32(cmbtipooperacion.SelectedValue);
                    operacion.iddocumento = Convert.ToInt32(cmbdoc.SelectedValue);
                    operacion.serie = txtserie.Text;
                    operacion.numero = Convert.ToInt32(txtnumero.Text);
                    operacion.Idoperacion = Convert.ToInt32(lblidoperacion.Text);

                    int r = db.ActualizarMovimientoCaja(operacion);

                    if (r > 0)
                    {
                        MessageBox.Show("Movimiento Actualizado");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void RegistraMovimiento()
        {

            using (OperacionBLL db=new OperacionBLL())
            {
                try
                {
                    Operacion operacion = new Operacion();

                    operacion.fecha = dtpfecha.Value;
                    operacion.Concepto = txtdescripcion.Text;
                    operacion.Tipo = cmbtipo.SelectedValue.ToString();
                    operacion.Idmediopago = Convert.ToInt32(cmbforma.SelectedValue);
                    operacion.Importe = Convert.ToDouble(txtimporte.Text);
                    operacion.Idcajachica = Idcajachica();
                    operacion.idtipo = Convert.ToInt32(cmbtipooperacion.SelectedValue);
                    operacion.iddocumento = Convert.ToInt32(cmbdoc.SelectedValue);
                    operacion.serie = txtserie.Text;
                    operacion.numero = Convert.ToInt32(txtnumero.Text);

                    int r = db.AgregarMovimiento(operacion);

                    if( r >0)
                    {
                        MessageBox.Show("Movimiento registrado");
                        this.Close();
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

        private void cmbtipooperacion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbtipo.SelectedIndex = cmbtipooperacion.SelectedIndex;
        }

        private void txtimporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validar.Solonumeros(Convert.ToInt32(e.KeyChar), txtimporte);
        }
    }
}
