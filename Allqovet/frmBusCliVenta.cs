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
    public partial class frmBusCliVenta : Form
    {
        public frmBusCliVenta()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBusCliVenta_Load(object sender, EventArgs e)
        {
            txtbuscar.Focus();
        }

        private void frmBusCliVenta_Activated(object sender, EventArgs e)
        {
            txtbuscar.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtbuscar.Text.Length>0)
            {
                BuscarCliente();
            }
           
        }

        private void BuscarCliente()
        {
            using (ClienteBLL db = new ClienteBLL())
            {
                try
                {
                    Cliente cliente = new Cliente();
                    cliente.ApellidoPaterno = txtbuscar.Text;

                    dgvclientes.DataSource = db.BuscarApellidos(cliente);
                    if (dgvclientes.Rows.Count > 0) dgvclientes.Columns["idCliente"].Visible = false;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvclientes.Rows.Count > 0)
            {
                frmVentas venta = Application.OpenForms.OfType<frmVentas>().SingleOrDefault();
                if (venta != null)
                {
                    venta.lblidcliente.Text = dgvclientes.CurrentRow.Cells["idCliente"].Value.ToString();
                    venta.txtcliente.Text = dgvclientes.CurrentRow.Cells["Nombres"].Value.ToString()+
                        dgvclientes.CurrentRow.Cells["ApellidoPaterno"].Value.ToString() + 
                        dgvclientes.CurrentRow.Cells["ApellidoMaterno"].Value.ToString();

                }
                this.Close();
            }

           
        }
    }
}
