using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Allqovet;
using AllqovetBLL;
using Entidades;

namespace AllqovetBLL
{
    public partial class frmDashboard : Form
    {
       private DashboardBLL dashboardBLL;
       public  BotonesDashboard btns =new BotonesDashboard();

        public frmDashboard(BotonesDashboard botones)
        
        {
            InitializeComponent();
            //Default - Últimos 7 días 
           
            dashboardBLL = new DashboardBLL();
            btns = botones;

          
            
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Today.AddDays(-7);
            dtpFechaFinal.Value = DateTime.Now;
            dtpFechaInicio_ValueChanged(null,EventArgs.Empty);
            dtpFechaFinal_ValueChanged(null, EventArgs.Empty);

            LoadData();

            EstadoBotones();


        }

        private void LoadData()
        {
            lblNumClientes.Text = dashboardBLL.ContarNumClientes().ToString();
            lblNumProductos.Text = dashboardBLL.ContarNumProductos().ToString();
            lblNumlProveedores.Text = dashboardBLL.ContarNumProveedores().ToString();

            DateTime fromDate = dtpFechaInicio.Value;
            DateTime toDate = dtpFechaFinal.Value;

            // Obtener el DataTable
            DataTable dataTable = dashboardBLL.TopProductos(fromDate, toDate);

            // Crear una lista para almacenar los valores de la columna deseada
            List<string> columnValues = new List<string>();

            // Verificar si el DataTable tiene datos
            if (dataTable.Rows.Count > 0)
            {
                // Iterar por cada fila del DataTable
                foreach (DataRow row in dataTable.Rows)
                {
                    // Obtener el valor de la columna deseada en cada fila
                    string columnValue = row["Descripcion"].ToString(); // Reemplaza "NombreColumna" con el nombre de la columna real
                    columnValues.Add(columnValue);
                }
            }

            // Crear una lista para almacenar los valores de la columna deseada
            List<string> yvalue = new List<string>();

            // Verificar si el DataTable tiene datos
            if (dataTable.Rows.Count > 0)
            {
                // Iterar por cada fila del DataTable
                foreach (DataRow row in dataTable.Rows)
                {
                    // Obtener el valor de la columna deseada en cada fila
                    string columnValue = row["TotalVendido"].ToString(); // Reemplaza "NombreColumna" con el nombre de la columna real
                    columnValues.Add(columnValue);
                }
            }

            chartTopProd.DataSource = dashboardBLL.TopProductos(fromDate, toDate);
            chartTopProd.Series[0].XValueMember = "Descripcion";
            chartTopProd.Series[0].YValueMembers = "TotalVendido";
            chartTopProd.DataBind();

            dtgvBajoStock.DataSource = dashboardBLL.Stock();




        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
            dtgvBajoStock.DataSource = dashboardBLL.Stock();
        }

        private void dtgvBajoStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void chartTopProd_Click(object sender, EventArgs e)
        {

        }

        private void lblNumClientes_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmNuevoCliente cliente = new frmNuevoCliente();
            cliente.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmClientes clientes = new frmClientes();
            clientes.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            dtpFechaInicio.Select();
            SendKeys.Send("%{DOWN}");
        }

        private void lblFechaFinal_Click(object sender, EventArgs e)
        {
            dtpFechaFinal.Select();
            SendKeys.Send("%{DOWN}");
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            lblFechaInicio.Text = dtpFechaInicio.Text;
        }

        private void dtpFechaFinal_ValueChanged(object sender, EventArgs e)
        {
            lblFechaFinal.Text = dtpFechaFinal.Text;
        }

        private void label5_Click_2(object sender, EventArgs e)
        {
        }

        private void label5_Click_3(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            frmRegistrofichas clientes = new frmRegistrofichas();
            clientes.ShowDialog();



        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ventana ventana = new Ventana();

            frmFicha ficha = new frmFicha(false);

            ventana.AbrirFormHijo(ficha);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmVentas ventas = new frmVentas();
            ventas.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmRegistroVentas registroVentas = new frmRegistroVentas();
            registroVentas.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmRegistroVentas registroVentas = new frmRegistroVentas();
            registroVentas.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            frmIngresoProductos ingresoProductos = new frmIngresoProductos();
            ingresoProductos.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Ventana ventana = new Ventana();
            frmReporteStock stock= new frmReporteStock();
            ventana.AbrirFormHijo(stock);
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Ventana ventana = new Ventana();
            frmReporteVenta reporte = new frmReporteVenta();
            ventana.AbrirFormHijo(reporte);
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void frmDashboard_Activated(object sender, EventArgs e)
        {
            frmMenu menu = Application.OpenForms.OfType<frmMenu>().SingleOrDefault();
            if (menu != null)
            {
                if (menu.btnNuevaVenta.Visible)
                {
                    btnNuevaVenta.Enabled = false;
                }
                else
                {
                    btnNuevaVenta.Enabled = false;
                }

                //   btnNuevaVenta.Enabled = menu.btnNuevaVenta.Visible == true ? true : false;
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            frmMenu menu = Application.OpenForms.OfType<frmMenu>().SingleOrDefault();
            if (menu != null)
            {
               // btnNuevoCliente.Enabled = menu.btnNuevoCliente.Visible == true ? true : false;
              //  btnNuevaVenta.Enabled = menu.btnNuevaVenta.Visible == true ? true : false;

                if (menu.btnNuevaVenta.Visible)
                {
                    MessageBox.Show("boton activo");
                  this.btnNuevaVenta.Enabled = true;
                }
                else
                {
                    //  this.btnNuevaVenta.Enabled = false;
                    MessageBox.Show("boton esta  inactivo");
                }

              /* btnNuevoCliente.Enabled = menu.btnNuevoCliente.Visible == true ? true : false;
                btnBuscarCliente.Enabled = menu.btnBuscarCliente.Visible == true ? true : false; ;
                btnBuscarMascota.Enabled = menu.btnBuscarFicha.Visible == true ? true : false;
                btnGenerarFicha.Enabled = menu.btnFichas.Visible == true ? true : false;
                btnNuevaVenta.Enabled = menu.btnNuevaVenta.Visible == true ? true : false;
                btnBuscarVenta.Enabled = menu.btnBuscarVenta.Visible == true ? true : false;
                btnNuevoComprobante.Enabled = menu.btnNuevoComprobante.Visible == true ? true : false;
                btnRepVentas.Enabled = menu.btnRepVentas.Visible == true ? true : false;
                btnPedido.Enabled = menu.btnIngresos.Visible == true ? true : false;
                btnCita.Enabled = menu.btnCitas.Visible == true ? true : false;
                btnInventario.Enabled = menu.btnStock.Visible == true ? true : false;
                btnSistema.Enabled = btnSistema.Visible == true ? true : false;

    */


            }
        }

        private void EstadoBotones()
        {
            btnNuevoCliente.Enabled = btns.btnNuevoCliente;
            btnBuscarCliente.Enabled = btns.btnBuscarCliente;
            btnBuscarMascota.Enabled = btns.btnBuscarMascota;
            btnGenerarFicha.Enabled = btns.btnGenerarFicha;
            btnNuevaVenta.Enabled = btns.btnNuevaVenta;
            btnBuscarVenta.Enabled = btns.btnBuscarVenta;
            btnNuevoComprobante.Enabled = btns.btnNuevoComprobante;
            btnRepVentas.Enabled = btns.btnRepVentas;
            btnPedido.Enabled = btns.btnPedido;
            btnCita.Enabled = btns.btnCita;
            btnInventario.Enabled = btns.btnInventario;
            btnSistema.Enabled = btns.btnSistema;
        }

    }

    }

