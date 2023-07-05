using AllqovetBLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Allqovet
{
    public partial class frmBuscarClienteCita : Form
    {

        // Otras propiedades y miembros de la clase

        public int ClienteSeleccionadoId { get; private set; }

        // Evento que se dispara cuando se selecciona un cliente
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            // Obtener el ID del cliente seleccionado
            int clienteId = ObtenerClienteSeleccionadoId();

            // Asignar el ID del cliente a la propiedad ClienteSeleccionadoId
            ClienteSeleccionadoId = clienteId;

            // Cerrar el formulario con DialogResult.OK para indicar que se seleccionó un cliente
            DialogResult = DialogResult.OK;
        }

        // Método que obtiene el ID del cliente seleccionado
        private int ObtenerClienteSeleccionadoId()
        {
            // Lógica para obtener el ID del cliente seleccionado
            // Puedes utilizar controles como DataGridView, ListBox, ComboBox, etc., según el diseño de tu formulario

            // Ejemplo: Obtener el ID del cliente seleccionado de un DataGridView llamado dgvClientes
            if (dgvclientes.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgvclientes.SelectedRows[0];
                int clienteId = Convert.ToInt32(filaSeleccionada.Cells["IdCliente"].Value);
                return clienteId;
            }

            // Si no se seleccionó ningún cliente, puedes lanzar una excepción, retornar un valor predeterminado o manejarlo de otra manera según tus necesidades
            throw new InvalidOperationException("No se seleccionó ningún cliente.");
        }
        public frmBuscarClienteCita()
        {
            InitializeComponent();
        }

        private void frmBuscarClienteCita_Load(object sender, EventArgs e)
        {
            txtbuscar.Focus();
        }

        private void frmBusClienteCita_Activated(object sender, EventArgs e)
        {
            if (txtbuscar.Text.Length > 0)
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
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuscarCliente();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dgvclientes.Rows.Count > 0)
            {
                frmCita cita = Application.OpenForms.OfType<frmCita>().SingleOrDefault();
                if (cita != null)
                {
                    cita.lblIdcliente.Text = dgvclientes.CurrentRow.Cells["idCliente"].Value.ToString();
                    cita.txtCliente.Text = dgvclientes.CurrentRow.Cells["Nombres"].Value.ToString() + "  " +
                    dgvclientes.CurrentRow.Cells["ApellidoPaterno"].Value.ToString() + "  "+
                    dgvclientes.CurrentRow.Cells["ApellidoMaterno"].Value.ToString() + "  " ;
                    cita.txtTelf.Text = dgvclientes.CurrentRow.Cells["Telefono"].Value.ToString();

                }

                this.Close();

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
