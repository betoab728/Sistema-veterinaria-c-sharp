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
using AllqovetBLL;
using Interfaces;

namespace Allqovet
{
    public partial class frmNuevoProveedor : Form
    {
        public frmNuevoProveedor()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConsultaReniec();
        }
        private void ConsultaReniec()
        {
            using (ProveedorBLL db = new ProveedorBLL())
            {
                try
                {
                    if (txtruc.Text.Length != 11)
                    {
                        MessageBox.Show("El ruc debe tener 11 dígitos");
                        return;
                    }

                    string ruc = txtruc.Text;

                    Proveedor proveedor = new Proveedor();
                    proveedor = db.ConsultaRUC(ruc);
                    if (proveedor != null)
                    {
                        txtRazonSocial.Text = proveedor.RazonSocial;

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());

                }
            }


        }

        private int Registrar()
        {
            int r = 0;

            using (ProveedorBLL db = new ProveedorBLL())
            {

                try
                {

                    Proveedor proveedor = new Proveedor();

                    proveedor.Ruc = txtruc.Text;
                    proveedor.RazonSocial = txtRazonSocial.Text;
                    proveedor.Direccion = txtDireccion.Text;
                    proveedor.Telefono = txttelefono.Text;
                    proveedor.Correo = txtCorreo.Text;
                    proveedor.Contacto1 = Convert.ToInt32(txtContacto1.Text);
                    proveedor.Contacto2 = Convert.ToInt32(txtContacto2.Text);
                    proveedor.Contacto3 = Convert.ToInt32(txtContacto3.Text);

                    r = db.Agregar(proveedor);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                    r = 0;
                }
            }

            return r;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Registrar() > 0)
            {
                MessageBox.Show("Proveedor registrado correctamente");
                this.Close();
            }
        }
    }
}
