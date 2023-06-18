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
using AllqovetDAO;
using Entidades;

namespace Allqovet
{
    public partial class NuevoTipoPago : Form
    {
        public NuevoTipoPago()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Registrar() > 0)
            {
                MessageBox.Show("Nuevo Medio de Pago registrado");
                this.Close();
            }
        }

        private int Registrar()
        {
            MedioPago mediopago = new MedioPago();
            mediopago.Descripcion = txtDescripcion.Text;

            int r = 0;

            using (MedioPagoBLL db = new MedioPagoBLL())
            {

                try
                {
                    r = db.Agregar(mediopago);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                    r = 0;
                }
            }

            return r;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
