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
    public partial class frmBusCliFicha : Form
    {
        public frmBusCliFicha()
        {
            InitializeComponent();
        }

        private void frmBusCliFicha_Load(object sender, EventArgs e)
        {
            cbocriterio.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbocriterio.SelectedIndex==0)
            {
                BuscarApellido();
            }
            else if (cbocriterio.SelectedIndex == 1)
            {
                BuscarDNI();
            }
        }


        private void BuscarApellido()
        {
            using (ClienteBLL db = new ClienteBLL())
            {
                try
                {
                    Cliente cliente = new Cliente();
                    cliente.ApellidoPaterno = txtbuscar.Text;

                    DataTable dt = db.BuscarApellidos(cliente);

                    dtgcliente.DataSource = dt;

                }
                catch (Exception ex)
                {

                    ex.ToString();
                }
            }
        }

        private void BuscarDNI()
        {
            using (ClienteBLL db = new ClienteBLL())
            {
                try
                {
                    Cliente cliente = new Cliente();
                    cliente.DNI = txtbuscar.Text;

                    DataTable dt = db.BuscarDni(cliente);

                    dtgcliente.DataSource = dt;

                }
                catch (Exception ex)
                {

                    ex.ToString();
                }
            }
        }

        private void dtgcliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
          
        }

        private void BuscarMascotas()
        {
            using (MascotaBLL db=new MascotaBLL())
            {
                try
                {
                    int idcliente = Convert.ToInt32(dtgcliente.CurrentRow.Cells["idCliente"].Value);
                    dtgmascota.DataSource = db.BuscarMascotaFicha(idcliente);

                }
                catch (Exception e)
                {

                    MessageBox.Show(e.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmFicha frm = Application.OpenForms.OfType<frmFicha>().SingleOrDefault();

            frm.txtcliente.Text = dtgcliente.CurrentRow.Cells["Nombres"].Value.ToString() +
                                  " "+ dtgcliente.CurrentRow.Cells["ApellidoPaterno"].Value.ToString()
                                  +" "+ dtgcliente.CurrentRow.Cells["ApellidoMaterno"].Value.ToString();
            frm.txtdireccion.Text = dtgcliente.CurrentRow.Cells["Direccion"].Value.ToString();
            frm.txttelefono.Text = dtgcliente.CurrentRow.Cells["Telefono"].Value.ToString();
            frm.lblidcliente.Text= dtgcliente.CurrentRow.Cells["idCliente"].Value.ToString();

            frm.txtmascota.Text = dtgmascota.CurrentRow.Cells["Nombre"].Value.ToString();
            frm.txtraza.Text = dtgmascota.CurrentRow.Cells["raza"].Value.ToString();
            frm.txtespecie.Text = dtgmascota.CurrentRow.Cells["especie"].Value.ToString();
            frm.txtcapa.Text = dtgmascota.CurrentRow.Cells["capa"].Value.ToString();
            frm.lblidmascota.Text= dtgmascota.CurrentRow.Cells["idMascota"].Value.ToString();


            frm.cmbsexo.SelectedIndex = dtgmascota.CurrentRow.Cells["sexo"].Value.ToString().Equals("MASCULINO") ? 0:1 ;

            frm.dtpfecha.Value =Convert.ToDateTime( dtgmascota.CurrentRow.Cells["Fecha_Nacimiento"].Value.ToString());

            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dtgcliente.Rows.Count > 0)
            {
                BuscarMascotas();
            }
        }
    }
}
