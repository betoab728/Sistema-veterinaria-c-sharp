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
using System.Security.Cryptography;

namespace Allqovet
{
    public partial class frmNuevoUsuario : Form
    {
        public frmNuevoUsuario()
        {
            InitializeComponent();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNuevoUsuario_Load(object sender, EventArgs e)
        {
            ListarAccesos();
            ListarTrabajadores();
        }


        private void ListarAccesos()
        {
            try
            {
                NivelaccesoBLL nivel = new NivelaccesoBLL();

                cmbnivel.ValueMember = "Idnivel";
                cmbnivel.DisplayMember = "descripcion" ;
                cmbnivel.DataSource = nivel.Listar();

                cmbnivel.SelectedIndex = -1;


            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                Application.Exit();
            }


        }


        private void ListarTrabajadores()
        {
            using (TrabajadorBLL db = new TrabajadorBLL())
            {
                try
                {
                    cmbtrabajador.DataSource = db.ListarNombres();
                    cmbtrabajador.ValueMember = "Idtrabajador";
                    cmbtrabajador.DisplayMember = "nombres" ;
                   
                    cmbtrabajador.SelectedIndex = -1;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {

            if (txtclave.Text != txtconfirmar.Text)
            {
                MessageBox.Show("las contraseñas no coninciden");
                return;
            }

            DialogResult dlg = MessageBox.Show("¿Esta seguro de registrar al usuario?", "Registro de usuario", MessageBoxButtons.YesNo);
            if (dlg == DialogResult.Yes)
            {
                Usuario usuario = new Usuario();

                usuario.Nombre = txtusuario.Text;
                usuario.Contraseña = txtclave.Text;
                usuario.Idtrabajador = Convert.ToInt32(cmbtrabajador.SelectedValue);
                usuario.Idnivelacceso = Convert.ToInt32(cmbnivel.SelectedValue);


                using (UsuarioBLL db=new UsuarioBLL())
                {
                    try
                    {
                        int r = db.Agregar(usuario);

                        if (r >0)
                        {
                            MessageBox.Show("Usuario registrado correctamente");
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cmbtrabajador.SelectedValue.ToString());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            string clave_encriptada = Encriptar(txtclave.Text);

            MessageBox.Show(clave_encriptada , clave_encriptada.Length.ToString());
        }

        private string Encriptar(string clave)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] claveBytes = Encoding.UTF8.GetBytes(clave);
                byte[] claveHashBytes = sha256.ComputeHash(claveBytes);
                string claveEncriptada = Convert.ToBase64String(claveHashBytes);
                return claveEncriptada;
            }
        }
    }
}
