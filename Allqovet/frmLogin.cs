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
        string NombreUsuario = "";
        string EstadoCaja = "Estado Caja: ";


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
                Application.Exit();
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
                frmMenu menu=null;
                MessageBox.Show("Acceso correcto. Bienvenido");
             

                using (PermisoBLL db = new PermisoBLL())
                {
                    try
                    {
                       

                        int idnivel = Convert.ToInt32(cbonivel.SelectedValue);
                        Usuario usuario = new Usuario();
                        usuario.Idnivelacceso = Convert.ToInt32(cbonivel.SelectedValue);

                        DataTable permisos = db.LeerPermisos(usuario);

                        BotonesDashboard botones = new BotonesDashboard();

                        botones.btnNuevoCliente = permisos.Rows[5][5].ToString() == "1" ? true : false; 
                        botones.btnBuscarCliente = permisos.Rows[6][5].ToString() == "1" ? true : false;
                        botones.btnBuscarMascota = permisos.Rows[22][5].ToString() == "1" ? true : false;
                        botones.btnGenerarFicha = permisos.Rows[21][0].ToString() == "1" ? true : false;
                        botones.btnNuevaVenta = permisos.Rows[0][5].ToString() == "1" ? true : false;
                        botones.btnBuscarVenta = permisos.Rows[1][5].ToString() == "1" ? true : false;
                        botones.btnNuevoComprobante = permisos.Rows[11][5].ToString() == "1" ? true : false;
                        botones.btnRepVentas = permisos.Rows[16][5].ToString() == "1" ? true : false;
                        botones.btnPedido = permisos.Rows[18][5].ToString() == "1" ? true : false;
                        botones.btnCita = permisos.Rows[23][5].ToString() == "1" ? true : false;
                        botones.btnInventario = permisos.Rows[14][5].ToString() == "1" ? true : false;
                        botones.btnSistema = permisos.Rows[29][2].ToString() == "1" ? true : false;

                        menu = new frmMenu(botones);
                        menu.lblnombreusuario.Text = NombreUsuario;
                        menu.lblEstadocaja.Text = EstadoCaja;

                        //correlativo.Rows[0][0].ToString();
                        // (edad >= 18) ? "Es mayor de edad" : "Es menor de edad";


                        //menus del sistema


                        menu.btnVentas.Visible = permisos.Rows[0][2].ToString() == "1" ? true : false;
                        menu.btnClientes.Visible = permisos.Rows[5][2].ToString() == "1" ? true : false;
                        menu.btnProductos.Visible = permisos.Rows[7][2].ToString() == "1" ? true : false;
                        menu.btnFacturacion.Visible = permisos.Rows[11][2].ToString() == "1" ? true : false;
                        menu.btnReportes.Visible = permisos.Rows[13][2].ToString() == "1" ? true : false;
                        menu.btnAlmacen.Visible = permisos.Rows[18][2].ToString() == "1" ? true : false;
                        menu.btnConsultorio.Visible = permisos.Rows[21][2].ToString() == "1" ? true : false;
                        menu.btnMantenimiento.Visible = permisos.Rows[25][2].ToString() == "1" ? true : false;
                        menu.btnSistema.Visible = permisos.Rows[29][2].ToString() == "1" ? true : false;



                        //submenus del sistema

                        menu.btnNuevaVenta.Visible = permisos.Rows[0][5].ToString() == "1" ? true : false;
                        menu.btnBuscarVenta.Visible = permisos.Rows[1][5].ToString() == "1" ? true : false;
                        menu.btnIniciarCaja.Visible = permisos.Rows[2][5].ToString() == "1" ? true : false;
                        menu.btnCerrarCaja.Visible = permisos.Rows[3][5].ToString() == "1" ? true : false;
                        menu.btnMovCaja.Visible = permisos.Rows[4][5].ToString() == "1" ? true : false;
                        menu.btnNuevoCliente.Visible = permisos.Rows[5][5].ToString() == "1" ? true : false;
                        menu.btnBuscarCliente.Visible = permisos.Rows[6][5].ToString() == "1" ? true : false;
                        menu.btnNuevoProducto.Visible = permisos.Rows[7][5].ToString() == "1" ? true : false;
                        menu.btnBuscarProducto.Visible = permisos.Rows[8][5].ToString() == "1" ? true : false;
                        menu.btnMarca.Visible = permisos.Rows[9][5].ToString() == "1" ? true : false;

                        menu.btnCategoria.Visible = permisos.Rows[10][5].ToString() == "1" ? true : false;
                        menu.btnNuevoComprobante.Visible = permisos.Rows[11][5].ToString() == "1" ? true : false;
                        menu.btnBuscarComprobante.Visible = permisos.Rows[12][5].ToString() == "1" ? true : false;
                        menu.btnRepClientes.Visible = permisos.Rows[13][5].ToString() == "1" ? true : false;
                        menu.btnRepStock.Visible = permisos.Rows[14][5].ToString() == "1" ? true : false;
                        menu.btnRepFacturacion.Visible = permisos.Rows[15][5].ToString() == "1" ? true : false;
                        menu.btnRepVentas.Visible = permisos.Rows[16][5].ToString() == "1" ? true : false;
                        menu.btnRepCaducidad.Visible = permisos.Rows[17][5].ToString() == "1" ? true : false;
                        menu.btnIngresos.Visible = permisos.Rows[18][5].ToString() == "1" ? true : false;
                        menu.btnSalidas.Visible = permisos.Rows[19][5].ToString() == "1" ? true : false;

                        menu.btnStock.Visible = permisos.Rows[20][5].ToString() == "1" ? true : false;
                        menu.btnFichas.Visible = permisos.Rows[21][0].ToString() == "1" ? true : false;
                        menu.btnBuscarFicha.Visible = permisos.Rows[22][5].ToString() == "1" ? true : false;
                        menu.btnCitas.Visible = permisos.Rows[23][5].ToString() == "1" ? true : false;
                        menu.btnListaCitas.Visible = permisos.Rows[24][5].ToString() == "1" ? true : false;
                        menu.btnTrabajadores.Visible = permisos.Rows[25][5].ToString() == "1" ? true : false;
                        menu.btnUsuarios.Visible = permisos.Rows[26][5].ToString() == "1" ? true : false;
                        menu.btnProveedores.Visible = permisos.Rows[27][5].ToString() == "1" ? true : false;
                        menu.btnMedioPago.Visible = permisos.Rows[28][5].ToString() == "1" ? true : false;
                        menu.btnPermisos.Visible = permisos.Rows[29][5].ToString() == "1" ? true : false;

                        menu.btnBackup.Enabled = permisos.Rows[30][5].ToString() == "1" ? true : false;

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }

                menu.Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Usuario no encontrado");
            }
            
        }

        private void LeerPermisos(Form frmMenu)
        {
          
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
                        // permisos.Rows[16][5].ToString()
                        NombreUsuario = datos.Rows[0][1].ToString();
                        EstadoCaja += datos.Rows[0][3].ToString() == "1" ? "Abierto" : "Cerrado";
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

        private void cbonivel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmLogin_Activated(object sender, EventArgs e)
        {

            cbonivel.Focus();
        }
    }
}
