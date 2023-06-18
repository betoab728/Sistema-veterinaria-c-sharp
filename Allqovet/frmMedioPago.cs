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
using AllqovetDAO;
using AllqovetBLL;

namespace Allqovet
{
    public partial class frmMedioPago : Form
    {
        public frmMedioPago()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (Registrar() > 0)
            {
                MessageBox.Show("Nuevo Medio de Pago registrado");
            }
        }
    }
}
