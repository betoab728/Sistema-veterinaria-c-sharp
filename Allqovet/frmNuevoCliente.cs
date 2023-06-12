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

namespace Allqovet
{
    public partial class frmNuevoCliente : Form
    {
        public frmNuevoCliente()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Registrar() > 0)
            {
                MessageBox.Show("cliente registrado");
            }

        }

       private int Registrar()
        {
            Cliente cliente = new Cliente();
            cliente.DNI = txtdni.Text;
            cliente.Nombres = txtNombre.Text;
            cliente.ApellidoPaterno = txtApePaterno.Text;
            cliente.ApellidoMaterno = txtApeMaterno.Text;
            cliente.Direccion = txtDireccion.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.Correo = txtCorreo.Text;

            int r = 0;

            using (ClienteBLL db= new ClienteBLL())
            {
              
                try
                {
                   r = db.Agregar(cliente);

                }
                catch (Exception ex )
                {

                    MessageBox.Show(ex.ToString());
                    r= 0;
                }
            }

            return r;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConsultaReniec();
        }

        private void ConsultaReniec()
        {
            using (ClienteBLL db=new ClienteBLL())
            {
                try
                {
                    if (txtdni.Text.Length !=8)
                    {
                        MessageBox.Show("El dni debe tener 8 digitos");
                        return;
                    }

                    string dni = txtdni.Text;

                    Cliente cliente = new Cliente();
                    cliente = db.ConsultaDNI(dni);

                    if (cliente !=null)
                    {
                        txtNombre.Text = cliente.Nombres;
                        txtApePaterno.Text = cliente.ApellidoPaterno;
                        txtApeMaterno.Text = cliente.ApellidoMaterno;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());

                }
            }

           
        }
    }
}
