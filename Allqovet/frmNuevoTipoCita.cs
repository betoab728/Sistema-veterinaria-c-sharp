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
    public partial class frmNuevoTipoCita : Form
    {
        public frmNuevoTipoCita()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Registrar() > 0)
            {
                MessageBox.Show("Nuevo Tipo de Cita registrado");
                this.Close();
            }
        }

        private int Registrar()
        {
            TipoCita tipocita = new TipoCita();
            tipocita.Descripcion = txtDescripcion.Text;

            int r = 0;

            using (TipoCitaBLL db = new TipoCitaBLL())
            {

                try
                {
                    r = db.Agregar(tipocita);

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
    }
}
