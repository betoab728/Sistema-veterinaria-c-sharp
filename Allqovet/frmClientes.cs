using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using AllqovetBLL;

namespace Allqovet
{
    public partial class frmClientes : Form
    {

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        public frmClientes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {

        }

        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            using (ClienteBLL db= new ClienteBLL())
            {
                try
                {
                    Cliente cliente = new Cliente();
                    cliente.ApellidoPaterno = txtbuscar.Text;

                    DataTable dt = db.BuscarApellidos(cliente);

                    dgClientes.DataSource = dt;

                }
                catch (Exception ex)
                {

                    ex.ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmNuevoCliente nuevo = new frmNuevoCliente();
            nuevo.ShowDialog();
        }
    }
}
