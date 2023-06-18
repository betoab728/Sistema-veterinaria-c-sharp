using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Interfaces;
using AllqovetBLL;

namespace Allqovet
{
    public partial class frmProveedores : Form
    {
        public frmProveedores()
        {
            InitializeComponent();
        }

        private void cbocriterio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Buscar();
           
        }
        private void Buscar()
        {
            using (ProveedorBLL  db = new ProveedorBLL())
            {
                try
                {
                    Proveedor proveedor = new Proveedor();
                    proveedor.RazonSocial = txtbuscar.Text;

                    DataTable dt = db.BuscarRazonSocial(proveedor);

                    dgClientes.DataSource = dt;

                }
                catch (Exception ex)
                {

                    ex.ToString();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmNuevoProveedor nuevo = new frmNuevoProveedor();
            nuevo.ShowDialog();

        }
    }
}
