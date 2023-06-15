using System;
using System.Data;
using System.Windows.Forms;
using Entidades;
using Interfaces;
using AllqovetBLL;


namespace Allqovet
{
    public partial class frmDashboard : Form
  
    {
        private DashboardBLL dashboardBLL;
        public frmDashboard()   
        {
            InitializeComponent();
            //Default - Últimos 7 días 
            dtpFechaInicio.Value = DateTime.Today.AddDays(-7);
            dtpFechaFinal.Value = DateTime.Now;
            dashboardBLL = new DashboardBLL();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void LoadData()
        {
            lblNumClientes.Text = dashboardBLL.ContarNumClientes().ToString();
            lblNumProductos.Text = dashboardBLL.ContarNumProductos().ToString();
            lblNumlProveedores.Text = dashboardBLL.ContarNumProveedores().ToString();

            int resultado = dashboardBLL.ContarNumClientes();



        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
