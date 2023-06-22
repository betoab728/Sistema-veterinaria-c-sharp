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
using AllqovetDAO;
using Interfaces;
using AllqovetBLL;

namespace Allqovet
{
    public partial class frmIngreso : Form
    {
        public frmIngreso()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txttotalitem_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListarProveedores()
        {
            using (ProveedorBLL db = new ProveedorBLL())
            {
                try
                {

                    cmbproveedor.DataSource = db.Listar();
                    cmbproveedor.ValueMember = "Idproveedor";
                    cmbproveedor.DisplayMember = "RazonSocial";
                    cmbproveedor.SelectedIndex = -1;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void TotalItem()
        {
            int cantidad = 0;
            double precio = 0;
            double total = 0;

            if (txtcan.Text.Length > 0) cantidad = Convert.ToInt32(txtcan.Text);
            if (txtprecio.Text.Length > 0) precio = Convert.ToDouble(txtprecio.Text);
            total = cantidad * precio;

            txttotalitem.Text = total.ToString();

            txttotalitem.Text = string.Format("{0:0.00}", total);

            //calculo para la utilidad--------
            double costo = 0;
            double utilidad_item = 0;
            if (lblcosto.Text.Length > 0) costo = Convert.ToDouble(lblcosto.Text);
            costo = Convert.ToDouble(lblcosto.Text);

            utilidad_item = total - (cantidad * costo);

            lblutilidad_item.Text = string.Format("{0:0.00}", utilidad_item);
            //---------------------------------
        }

        private void txtprecio_Leave(object sender, EventArgs e)
        {
            if (txtprecio.Text.Length > 0)
            {
                TotalItem();

                double precio = 0;
                precio = Convert.ToDouble(txtprecio.Text);
                txtprecio.Text = string.Format("{0:0.00}", precio);
            }

        }

        private void txtcan_Leave(object sender, EventArgs e)
        {
            TotalItem();
        }

        




    }
}
