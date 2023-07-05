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
            DialogResult dialogResult = MessageBox.Show("Esta seguro de registrar al cliente?", "Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (Registrar() > 0)
                {
                    MessageBox.Show("Cliente registrado correctamente");
                    DialogResult dialogResult2 = MessageBox.Show("Desea programar cita?", "Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        frmCita cita = new frmCita();
                        Ventana ventana = new Ventana();
                        ventana.AbrirFormHijo(cita);
                    }
                
                    this.Close();
                    
                    
                }
            }
               

        }

       private int Registrar()
        {
         

           int r = 0;

            using (ClienteBLL db= new ClienteBLL())
            {
              
                try
                {

                    Cliente cliente = new Cliente();
                    List<Mascota> ListaMascotas = new List<Mascota>();

                    cliente.DNI = txtdni.Text;
                    cliente.Nombres = txtNombre.Text;
                    cliente.ApellidoPaterno = txtApePaterno.Text;
                    cliente.ApellidoMaterno = txtApeMaterno.Text;
                    cliente.Direccion = txtDireccion.Text;
                    cliente.Telefono = txtTelefono.Text;
                    cliente.Correo = txtCorreo.Text;


                    //lleno la lista de mascotas

                    foreach (DataGridViewRow row in dtgmascotas.Rows)
                    {
                        Mascota mascota = new Mascota();
                        mascota.Nombre = row.Cells["NOMBRE"].Value.ToString();
                        mascota.FechaNacimiento = Convert.ToDateTime(row.Cells["FNACIMIENTO"].Value.ToString());
                        mascota.Raza = row.Cells["RAZA"].Value.ToString();
                        mascota.Especie = row.Cells["ESPECIE"].Value.ToString();
                        mascota.Sexo = row.Cells["SEXO"].Value.ToString().Equals("MASCULINO") ? "m" : "f";
                        mascota.Capa = row.Cells["CAPA"].Value.ToString();
                        mascota.Observacion = row.Cells["OBSERVACION"].Value.ToString();

                        ListaMascotas.Add(mascota);

                    }

                    r = db.Agregar(cliente, ListaMascotas);


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

        private void button2_Click(object sender, EventArgs e)
        {
            frmNuevaMascota mascota = new frmNuevaMascota();
            mascota.ShowDialog();
        }

        private void frmNuevoCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
