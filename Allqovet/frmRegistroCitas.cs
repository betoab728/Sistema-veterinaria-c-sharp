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

namespace Allqovet
{
    public partial class frmRegistroCitas : Form
    {
        public frmRegistroCitas()
        {
            InitializeComponent();
        }

        private void frmRegistroCitas_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListarCitas();
        }

        private void ListarCitas()
        {

            using (CitaBLL db = new CitaBLL())
            {
                try
                {
                    DateTime fecha = Convert.ToDateTime(dtpfecha.Value.ToString("yyyy-MM-dd"));
                    dgvcitas.DataSource = db.ListarCitaFecha(fecha);
                }
                catch (Exception ex)
                {


                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Esta seguro de actualizar el estado de la cita?", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                AtenderCita();
            }
            
        }

        private void AtenderCita()
        {
            using (CitaBLL db=new CitaBLL())
            {
                try
                {

                    int idcita = 0;
                    idcita = Convert.ToInt32(dgvcitas.CurrentRow.Cells["IDCITA"].Value.ToString());

                    int r = db.AtenderCita(idcita);
                    if (r > 0)
                    {
                        MessageBox.Show("informacion de la cita actualizada");
                        ListarCitas();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Esta seguro de anular la cita?", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                AnularCita();
            }
        }

        private void AnularCita()
        {
            using (CitaBLL db = new CitaBLL())
            {
                try
                {

                    int idcita = 0;
                    idcita = Convert.ToInt32(dgvcitas.CurrentRow.Cells["IDCITA"].Value.ToString());

                    int r = db.AnularCita(idcita);
                    if (r > 0)
                    {
                        MessageBox.Show("cita anulada");
                        ListarCitas();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
