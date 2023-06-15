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
using Entidades;
using Interfaces;

namespace Allqovet
{
    public partial class frmMarca : Form
    {
        public frmMarca()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void Buscar()
        {
            using (MarcaBLL db = new MarcaBLL())
            {
                try
                {
                    Marca marca = new Marca();
                    marca.Nombre = txtBuscador.Text;

                    DataTable dt = db.Buscar(marca);

                    dgMarca.DataSource = dt;

                }
                catch (Exception ex)
                {

                    ex.ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmNuevaMarca nuevo = new frmNuevaMarca();
            nuevo.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void frmMarca_Load(object sender, EventArgs e)
        {
           
        }
    }
}
