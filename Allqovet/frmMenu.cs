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
    public partial class frmMenu : Form
    {
        /*private Panel leftBorderBtn;*/

        private Form formActual;

        

        public frmMenu()
        {
          InitializeComponent();
            /*
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7,41);
            panelmenu.Controls.Add(leftBorderBtn);*/

           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
        }

        private void iconmaximizar_Click(object sender, EventArgs e)
        {
   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //  BotonActivo(btnVentas);

            MostrarSubmenu(panelSubmenuVentas);

        }

        private void BotonActivo(Button button)
        {

            foreach (Control item in panelmenu.Controls)
            {

              

                if (item is Button )
                {
                   

                    Button botonn = (Button)item;

                    botonn.TextAlign = ContentAlignment.MiddleCenter;
                    botonn.BackColor = Color.FromArgb(153, 128, 154);
                  //  botonn.SendToBack();

                }
          
            }

            if (button.TextAlign == ContentAlignment.MiddleCenter)
            {

                button.TextAlign = ContentAlignment.MiddleRight;
                button.BackColor = Color.FromArgb(144, 116, 140);
                /*leftBorderBtn.BackColor = Color.White;
                leftBorderBtn.Location = new Point(0, button.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();*/

            }
           
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            Ocultarsubmenu();
        }

        private void Diseniomenu()
        {
           
        }

        private void Ocultarsubmenu()
        {
            if (panelSubmenuVentas.Visible == true)
                panelSubmenuVentas.Visible = false;

            if (panelProductos.Visible == true)
                panelProductos.Visible = false;

            if (panelFacturacion.Visible == true)
                panelFacturacion.Visible = false;

            if (panelAlmacen.Visible == true)
                panelAlmacen.Visible = false;

            if (panelPedidos.Visible == true)
                panelPedidos.Visible = false;

            if (panelsubmenuSistemas.Visible == true)
                panelsubmenuSistemas.Visible = false;

            if (panelsubmenuClientes.Visible == true)
                panelsubmenuClientes.Visible = false;

            if (panelSubmenuConsultorio.Visible == true)
                panelSubmenuConsultorio.Visible = false;
        }

       private void MostrarSubmenu(Panel submenu)
        {
            if (submenu.Visible==false)
            {
                Ocultarsubmenu();
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false;
            }

           

        }

        private void button3_Click(object sender, EventArgs e)
        {

           // BotonActivo(button3);

            frmClientes clientes = new frmClientes();
            AbrirFormHijo(clientes);
        

        }

        private void AbrirFormHijo( Form frm)
        {
            formActual = frm;
            frm.TopLevel = false;
            //frm.Dock = DockStyle.Fill;
            panelEscritorio.Controls.Add(frm);
            panelEscritorio.Tag = frm;
            frm.BringToFront();
            frm.SetDesktopLocation( (panelEscritorio.Width - frm.Width)/2, (panelEscritorio.Height - frm.Height)/2);
            frm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           // BotonActivo(button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
         //   BotonActivo(button5);
        }

        private void button9_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show(" ¿Salir del Sistema?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(panelSubmenuConsultorio);
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            //MostrarSubmenu(panelsubmenuMant);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(panelAlmacen);
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            /*MostrarSubmenu(panelsubmenuFinanzas);*/
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(panelsubmenuSistemas);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(panelsubmenuClientes);
        }

        private void button37_Click(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {

        }

        private void button34_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(panelProductos);
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(panelFacturacion);
        }

        private void button33_Click(object sender, EventArgs e)
        {

        }

        private void panelFacturacion_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(panelPedidos);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            MostrarSubmenu(panelAlmacen);
        }

        private void button21_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void panelSubmenuConsultorio_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
