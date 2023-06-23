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

namespace AllqovetBLL
{
    public partial class frmDashboard : Form
    {
        private DashboardBLL dashboardBLL;
        public frmDashboard()
        
        {
            InitializeComponent();
            //Default - Últimos 7 días 
           
            dashboardBLL = new DashboardBLL();

            
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Today.AddDays(-7);
            dtpFechaFinal.Value = DateTime.Now;
            dtpFechaInicio_ValueChanged(null,EventArgs.Empty);
            dtpFechaFinal_ValueChanged(null, EventArgs.Empty);

            LoadData();
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
   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
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
    }

    }

