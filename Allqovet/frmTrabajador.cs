using AllqovetBLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Allqovet
{
    public partial class frmTrabajador : Form
    {
        //1 para nuevo , 2 para modificar
        int guardar = 0;

        public frmTrabajador()
        {
            InitializeComponent();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTrabajador_Load(object sender, EventArgs e)
        {
            ListarCargos();
            ListarTrabajadores();
        }

        private void ListarCargos()
        {
            using (CargoBLL db=new CargoBLL())
            {
                try
                {
                    cmbcargo.DataSource = db.Listar();
                    cmbcargo.ValueMember = "idCargo";
                    cmbcargo.DisplayMember = "descripcion";
                    cmbcargo.SelectedIndex = -1;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void ListarTrabajadores()
        {
            using (TrabajadorBLL db = new TrabajadorBLL())
            {
                try
                {
                    dtgtrabajadores.DataSource = db.Listar();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void BloquearBotones(bool estado)
        {
            btnnuevo.Enabled = estado;
            btnguardar.Enabled =! estado;
            btncancelar.Enabled =! estado;
            btnmodificar.Enabled = estado;
            btnsalir.Enabled = estado;
            boxdatos.Enabled =! estado;
            dtgtrabajadores.Enabled= estado;
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {

            BloquearBotones(false);
            cmbsexo.SelectedIndex = 0;
            cmbestado.SelectedIndex = 0;
            guardar = 1; //1 nuevo , 2 modificar

        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            BloquearBotones(true);
           
        }

        private void NuevoRegistro()
        {
            using (TrabajadorBLL db = new TrabajadorBLL())
            {
                try
                {
                  
                    string sexo = "";
                    if (cmbsexo.SelectedIndex == 0)
                    {
                        sexo = "M";
                    }
                    else
                    {
                        sexo = "F";
                    }

                    DateTime? fcese = null;
                    if (dtpfechacese.Checked) fcese = dtpfechacese.Value;
                    Trabajador tr = new Trabajador();

                    tr.DNI = txtdni.Text;
                    tr.ApellidoPaterno = txtapepaterno.Text;
                    tr.ApellidoMaterno = txtapematerno.Text;
                    tr.Nombres = txtnombres.Text;
                    tr.sexo = sexo;
                    tr.FechaNacimiento = dtpfechanac.Value;
                    tr.FechaIngreso = dtpfechaing.Value;
                    tr.idcargo = Convert.ToInt32(cmbcargo.SelectedValue);
                    tr.FechaCese = fcese;
                    tr.direccion = txtdireccion.Text;
                    tr.telefono = txttelefono.Text;
                    tr.correo = txtcorreo.Text;
                   
                   int rpta = db.Agregar(tr);
                    if (rpta == 1)
                    {
                        MessageBox.Show("Trabajador registrado correctamente", "Nuevo Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BloquearBotones(true);
                    }

                    BloquearBotones(false);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Actualizar()
        {
            using (TrabajadorBLL db = new TrabajadorBLL())
            {
                try
                {

                    string sexo = "";
                    if (cmbsexo.SelectedIndex == 0)
                    {
                        sexo = "M";
                    }
                    else
                    {
                        sexo = "F";
                    }

                    DateTime? fcese = null;
                    if (dtpfechacese.Checked) fcese = dtpfechacese.Value;
                    Trabajador tr = new Trabajador();

                    tr.DNI = txtdni.Text;
                    tr.ApellidoPaterno = txtapepaterno.Text;
                    tr.ApellidoMaterno = txtapematerno.Text;
                    tr.Nombres = txtnombres.Text;
                    tr.sexo = sexo;
                    tr.FechaNacimiento = dtpfechanac.Value;
                    tr.FechaIngreso = dtpfechaing.Value;
                    tr.idcargo = Convert.ToInt32(cmbcargo.SelectedValue);
                    tr.FechaCese = fcese;
                    tr.direccion = txtdireccion.Text;
                    tr.telefono = txttelefono.Text;
                    tr.correo = txtcorreo.Text;
                    tr.Idtrabajador =Convert.ToInt32( lblidtrabajador.Text);
                    int estado = 0;
                    if (cmbestado.SelectedIndex==0) estado = 1;
                    tr.estado = estado;
                    
                    int rpta = db.Editar(tr);
                    if (rpta == 1)
                    {
                        MessageBox.Show("Datos actualizados", "Modificar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BloquearBotones(true);
                        ListarTrabajadores();
                    }

                   
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ConsultaReniec()
        {
            using (ClienteBLL db = new ClienteBLL())
            {
                try
                {
                    if (txtdni.Text.Length != 8)
                    {
                        MessageBox.Show("El dni debe tener 8 digitos");
                        return;
                    }

                    string dni = txtdni.Text;

                    Cliente cliente = new Cliente();
                    cliente = db.ConsultaDNI(dni);

                    if (cliente != null)
                    {
                        txtnombres.Text = cliente.Nombres;
                        txtapepaterno.Text = cliente.ApellidoPaterno;
                        txtapematerno.Text = cliente.ApellidoMaterno;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());

                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConsultaReniec();
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            guardar = 2;
            BloquearBotones(false);
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (guardar==1 ) //1 nuevo , 2 modificar
            {
                NuevoRegistro();
            }else if (guardar == 2)
            {
                Actualizar();
            }
        }

        private void dtgtrabajadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MostrarRegistro();
        }

        private void MostrarRegistro()
        {
            lblidtrabajador.Text = dtgtrabajadores.CurrentRow.Cells["Idtrabajador"].Value.ToString();
            txtdni.Text = dtgtrabajadores.CurrentRow.Cells["DNI"].Value.ToString();
            txtnombres.Text = dtgtrabajadores.CurrentRow.Cells["Nombres"].Value.ToString();
            txtapepaterno.Text = dtgtrabajadores.CurrentRow.Cells["ApellidoPaterno"].Value.ToString();
            txtapematerno.Text = dtgtrabajadores.CurrentRow.Cells["ApellidoMaterno"].Value.ToString();
            cmbsexo.SelectedIndex = dtgtrabajadores.CurrentRow.Cells["sexo"].Value.ToString().Equals("M")? 0: 1;
            txtdireccion.Text = dtgtrabajadores.CurrentRow.Cells["Direccion"].Value.ToString();
            txtcorreo.Text = dtgtrabajadores.CurrentRow.Cells["Correo"].Value.ToString();
            txttelefono.Text = dtgtrabajadores.CurrentRow.Cells["Telefono"].Value.ToString();
            cmbcargo.SelectedValue = dtgtrabajadores.CurrentRow.Cells["idcargo"].Value.ToString();
            dtpfechanac.Value = Convert.ToDateTime( dtgtrabajadores.CurrentRow.Cells["FechaNacimiento"].Value.ToString());
            dtpfechaing.Value = Convert.ToDateTime(dtgtrabajadores.CurrentRow.Cells["FechaIngreso"].Value.ToString()); 
          
            cmbestado.SelectedIndex = dtgtrabajadores.CurrentRow.Cells["estado"].Value.ToString().Equals("1") ? 0 : 1;

            if (dtgtrabajadores.CurrentRow.Cells["FechaCese"].Value.ToString().Length >0)
            {
                dtpfechacese.Value = Convert.ToDateTime(dtgtrabajadores.CurrentRow.Cells["FechaCese"].Value.ToString());
            }
         
        }

        private void dtgtrabajadores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
