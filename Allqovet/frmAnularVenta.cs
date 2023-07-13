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
    public partial class frmAnularVenta : Form
    {
        public frmAnularVenta()
        {
            InitializeComponent();
        }

        int IdUsuario_Anula = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtclave.Text))
            {
                MessageBox.Show("Ingrese la clave correctamente");
                return;
            }
            if (String.IsNullOrEmpty(txtmotivo.Text))
            {
                MessageBox.Show("Ingrese motivo de anulacion");
                return;
            }

            int idventa = Convert.ToInt32(lblidventa.Text);

            if (idventa==0)
            {
                MessageBox.Show("Ingrese motivo de anulacion");
                return;
            }
            
           if(Permiso())
            {
                Anular();
            }
            else
            {
                MessageBox.Show("contraseña incorrecta");
            }

        }


        private bool Permiso()
        {
            bool acceso = false;

            using (UsuarioBLL db=new UsuarioBLL())
            {
                try
                {
                    Usuario usuario = new Usuario();
                    usuario = db.PermisoAnulacion(txtclave.Text);
                    IdUsuario_Anula = usuario.Idusuario;

                    if (IdUsuario_Anula >0)
                    {
                        acceso = true;
                    }
                 

                }
                catch (Exception ex)
                {
                     acceso = false;
                    MessageBox.Show("error en al validar la contraseña "+ex.Message);
                }
            }

            return acceso;
         
        }

        private void Anular()
        {
            using (VentaBLL db=new VentaBLL())
            {
                try
                {
                    int idventa = Convert.ToInt32(lblidventa.Text);

                    Venta venta = new Venta();
                    List<ProductoVitrina> listado = new List<ProductoVitrina>();

                    venta.Idventa = idventa;
                    venta.IdUsuarioAnula = IdUsuario_Anula;
                    venta.motivo = txtmotivo.Text;

                    DataTable detalleventa = db.DetalleVenta(idventa);

                    foreach (DataRow row in detalleventa.Rows)
                    {
                        ProductoVitrina pv = new ProductoVitrina();
                        pv.Idproducto = Convert.ToInt32(row["IDPRODUCTO"]);
                        pv.Idvitrina= Convert.ToInt32(row["Idvitrina"]);
                        pv.Stock= Convert.ToInt32(row["CANTIDAD"]);

                        listado.Add(pv);
                    }

                    int r = db.AnularVenta(venta,listado);

                    if (r>0)
                    {
                        frmRegistroVentas f1 = Application.OpenForms.OfType<frmRegistroVentas>().SingleOrDefault();
                        if (f1 != null)
                        {
                             f1.ventaanulada=true;
                        }

                        MessageBox.Show("Venta anulada correctamente", "Anulacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }else
                    {
                        MessageBox.Show("Error al anular", "Anulacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("error en anulacion " + ex.Message); ;
                }
            }

         
            

        }
    }
}
