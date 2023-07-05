using AllqovetBLL;
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
    public partial class frmCita : Form
    {
        public frmCita()
        {
            InitializeComponent();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void frmCita_Load(object sender, EventArgs e)
        {
            dtpHora.Format = DateTimePickerFormat.Custom;
            dtpHora.CustomFormat = "hh:mm tt";
            dtpHora.ShowUpDown = true;
            ListarTipocita();

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmBuscarClienteCita cli = new frmBuscarClienteCita();
            if (cli.ShowDialog() == DialogResult.OK)
            {
                // Obtener el ID del cliente seleccionado del formulario frmBuscarClienteCita
                int idc = cli.ClienteSeleccionadoId;

                // Actualizar la etiqueta lblIdcliente con el ID del cliente seleccionado
                lblIdcliente.Text = idc.ToString();

                // Llamar al método ListarMascota() para listar las mascotas del cliente seleccionado
                ListarMascota(idc);
            }
        }

        private void cmbTipoCita_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void ListarTipocita()
        {
            using (TipoCitaBLL db = new TipoCitaBLL())
            {
                try
                {
                    cmbTipoCita.DataSource = db.Listar();
                    cmbTipoCita.ValueMember = "Idtipocita";
                    cmbTipoCita.DisplayMember = "Descripcion";
                    cmbTipoCita.SelectedIndex = -1;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ListarMascota(int clienteId)
        {
            using (MascotaBLL db = new MascotaBLL())
            {
                try
                {
                    cmbMascota.DataSource = db.ListarMascota(clienteId);
                    cmbMascota.ValueMember = "idMascota";
                    cmbMascota.DisplayMember = "Nombre";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }
}
