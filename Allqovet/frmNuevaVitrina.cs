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
using Entidades;

namespace Allqovet
{
    public partial class frmNuevaVitrina : Form
    {
        public frmNuevaVitrina()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private int Registrar()
        {
            Vitrina vitrina = new Vitrina();
            vitrina.descripcion = txtDescripcion.Text;

            int r = 0;

            using (VitrinaBLL db = new VitrinaBLL())
            {

                try
                {
                    r = db.Agregar(vitrina);

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
                this.Close();
                MessageBox.Show("Vitrina registrada");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
