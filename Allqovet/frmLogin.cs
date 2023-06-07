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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

       private void ListarAccesos()
        {
            try
            {
                NivelaccesoBLL nivel = new NivelaccesoBLL();

                cbonivel.ValueMember = "Idnivel";
                cbonivel.DisplayMember = "descripcion";
                cbonivel.DataSource = nivel.Listar();   

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

         
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            txtnombre.BackColor = Color.White;
            panel3.BackColor = Color.White;
            panel4.BackColor = SystemColors.Control;
            txtpass.BackColor = SystemColors.Control;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            ListarAccesos();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_Click(object sender, EventArgs e)
        {
          
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            txtpass.BackColor = Color.White;
            panel4.BackColor = Color.White;

            txtnombre.BackColor = SystemColors.Control;
            panel3.BackColor = SystemColors.Control;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validacion())
            {
                MessageBox.Show("Acceso correcto. Bienvenido"); 

                frmMenu menu = new frmMenu();
                menu.Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Usuario no encontrado");
            }
            
        }

        private bool Validacion()
        {
            bool resultado=false;


            using (UsuarioBLL db=new UsuarioBLL())
            {
                try
                {
                    Usuario usuario = new Usuario();

                    usuario.Nombre =txtnombre.Text;
                    usuario.Contraseña =txtpass.Text;
                    usuario.Idnivelacceso =Convert.ToInt32(cbonivel.SelectedValue);

                    DataTable datos = db.Login(usuario);

                    if (datos.Rows.Count > 0)
                    {
                        resultado = true;
                    }
                    else
                    {
                        resultado = false;
                    }
                }
                catch (Exception ex)
                {

                    ex.ToString();
                }
            }


            return resultado;
            
        }


    }
}
