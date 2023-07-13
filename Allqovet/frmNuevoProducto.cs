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

            DateTime? vencimiento = null;
            if (dtpfecha.Checked) vencimiento = dtpfecha.Value;

            string manejastock = "0";
            if (btnSi.Checked) manejastock = "1";


            producto.Descripcion = txtDescripcion.Text;
            producto.Idmarca = Convert.ToInt32(cmbMarca.SelectedValue);
            producto.Idcategoria = Convert.ToInt32(cmbCategoria.SelectedValue);
            producto.PrecioCosto = Convert.ToDouble(txtPrecioCosto.Text);
            producto.PrecioVenta = Convert.ToDouble(txtPrecioVenta.Text);
            producto.FechaVencimiento = vencimiento;
            producto.codigo = txtcodigo.Text;
            producto.Stokcminimo = Convert.ToInt32(txtstockmin.Text);
            producto.Manejastock = manejastock;

            ProductoVitrina productoVitrina = new ProductoVitrina();
            productoVitrina.Idvitrina = Convert.ToInt32(cmbubicacion.SelectedValue);


            int r = 0;

            using (ProductoBLL db = new ProductoBLL())
            {

                try
                {
                    r = db.Agregar(producto, productoVitrina);

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
               
        }

        private void ListarMarca()
        {
            using (MarcaBLL db = new MarcaBLL())
            {
                try
                {
                    DataTable dt = null;
                    dt = db.Listar();
                    cmbMarca.DataSource = dt;

                    cmbMarca.ValueMember = "Idmarca";
                    cmbMarca.DisplayMember = "Nombre";

                  
                   cmbMarca.SelectedIndex = -1;

                   AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
                    foreach (DataRow item in dt.Rows)
                    {
                        coleccion.Add(Convert.ToString(item["Nombre"]));
                    }
                    cmbMarca.AutoCompleteCustomSource = coleccion;
                    cmbMarca.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cmbMarca.AutoCompleteSource = AutoCompleteSource.CustomSource;

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void frmNuevoProducto_Load(object sender, EventArgs e)
        {
            
            ListarCategorias();
            ListarMarca();
            ListarVitrina();
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListarVitrina()
        {
            using (ProductoVitrinaBLL db = new ProductoVitrinaBLL())
            {
                try
                {
                    DataTable dt = null;
                    dt = db.ListarVitrinas();
                    cmbubicacion.DataSource = dt;

                    cmbubicacion.ValueMember = "idVitrina";
                    cmbubicacion.DisplayMember = "descripcion";
                    cmbubicacion.SelectedIndex = -1;

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtcodigo.Text))
            {
                MessageBox.Show("indique el codigo del producto");
                return;
            }

            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("indique la descripcion");
                return;
            }
            if (String.IsNullOrEmpty(txtPrecioCosto.Text))
            {
                MessageBox.Show("indique el precio de costo");
                return;
            }
            if (String.IsNullOrEmpty(txtPrecioVenta.Text))
            {
                MessageBox.Show("indique el precio de venta");
                return;
            }
            if (String.IsNullOrEmpty(txtstockmin.Text))
            {
                MessageBox.Show("indique el stock minimo");
                return;
            }


            if (btnSi.Checked ==false && btnNo.Checked==false)
            {
                MessageBox.Show("indique si el producto maneja stock");
                return;
            }
            if (cmbMarca.SelectedIndex==-1)
            {
                MessageBox.Show("seleccione una marca");
                return;
            }

            if (cmbCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("seleccione una categoria");
                return;
            }

            if (btnSi.Checked)
            {
                if (cmbubicacion.SelectedIndex==-1)
                {
                    MessageBox.Show("seleccione una ubicacion");
                    return;
                }
            }


            if (btnSi.Checked)
            {
                if (Registrar() > 0)
                {
                    MessageBox.Show("Producto registrado");
                    this.Close();
                }
            }
            else
            {
                if (RegistrarServicio() > 0)
                {
                    MessageBox.Show("Producto registrado");
                    this.Close();
                }
            }

           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private int RegistrarServicio()
        {
            Producto producto = new Producto();

            DateTime? vencimiento = null;
            if (dtpfecha.Checked) vencimiento = dtpfecha.Value;

            producto.Descripcion = txtDescripcion.Text;
            producto.Idmarca = Convert.ToInt32(cmbMarca.SelectedValue);
            producto.Idcategoria = Convert.ToInt32(cmbCategoria.SelectedValue);
            producto.PrecioCosto = Convert.ToDouble(txtPrecioCosto.Text);
            producto.PrecioVenta = Convert.ToDouble(txtPrecioVenta.Text);
            producto.FechaVencimiento = vencimiento;
            producto.codigo = txtcodigo.Text;
            producto.Manejastock = "0";
            producto.Stokcminimo = Convert.ToInt32(txtstockmin.Text);
                
            int r = 0;

            using (ProductoBLL db = new ProductoBLL())
            {

                try
                {
                    r = db.AgregarServicio(producto);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                    r = 0;
                }
            }
            return r;
        }
    }
}
