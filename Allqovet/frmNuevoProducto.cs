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
using Interfaces;
using AllqovetBLL;

namespace Allqovet
{
    public partial class frmNuevoProducto : Form
    {
        public frmNuevoProducto()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private int Registrar()
        {
            Producto producto = new Producto();
            producto.Descripcion = txtDescripcion.Text;
            producto.Idmarca = Convert.ToInt32(cmbMarca.SelectedValue);
            producto.Idcategoria = Convert.ToInt32(cmbCategoria.SelectedValue);
            producto.PrecioCosto = Convert.ToDouble(txtPrecioCosto.Text);
            producto.PrecioVenta = Convert.ToDouble(txtPrecioVenta.Text);
            producto.FechaVencimiento =txtFechaVenc.Value;
          

            int r = 0;

            using (ProductoBLL db = new ProductoBLL())
            {

                try
                {
                    r = db.Agregar(producto);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                    r = 0;
                }
            }

            return r;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarMarca();
        }
        private void ListarCategorias()
        {
              using (CategoriaBLL db = new CategoriaBLL())
                try
            {
                    try
                    {
                        DataTable dt = null;
                        dt = db.Listar();
                        cmbCategoria.DataSource = dt;

                        cmbCategoria.ValueMember = "idcategoria";
                        cmbCategoria.DisplayMember = "nombre";
                        cmbCategoria.SelectedIndex = -1;

                        AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
                        foreach (DataRow item in dt.Rows)
                        {
                            coleccion.Add(Convert.ToString(item["nombre"]));
                        }
                        cmbCategoria.AutoCompleteCustomSource = coleccion;
                        cmbCategoria.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        cmbCategoria.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



        }

        private void ListarMarca()        {            using (MarcaBLL db = new MarcaBLL())            {                try                {                    DataTable dt = null;                    dt = db.Listar();                    cmbMarca.DataSource = dt;                    cmbMarca.ValueMember = "idmarca";                    cmbMarca.DisplayMember = "nombre";                    cmbMarca.SelectedIndex = -1;                    AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();                    foreach (DataRow item in dt.Rows)                    {                        coleccion.Add(Convert.ToString(item["nombre"]));                    }                    cmbMarca.AutoCompleteCustomSource = coleccion;                    cmbMarca.AutoCompleteMode = AutoCompleteMode.SuggestAppend;                    cmbMarca.AutoCompleteSource = AutoCompleteSource.CustomSource;                }                catch (Exception ex)                {                    MessageBox.Show(ex.Message);                }            }        }

        private void frmNuevoProducto_Load(object sender, EventArgs e)
        {
            ListarMarca();
            ListarCategorias();
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Registrar() > 0)
            {
                MessageBox.Show("Producto registrado");
            }
        }
    }
}
