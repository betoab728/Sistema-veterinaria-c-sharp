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
using Entidades.cpe_sunat;
using AllqovetBLL.Facturacion;
using System.IO;
using Microsoft.Reporting.WinForms;

namespace Allqovet
{
    public partial class FrmFactura : Form
    {
        public FrmFactura()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConsultaSUNAT();
        }

        private void ConsultaSUNAT()
        {
            using (ProveedorBLL db = new ProveedorBLL())
            {
                try
                {
                    if (txtruc.Text.Length != 11)
                    {
                        MessageBox.Show("El ruc debe tener 11 dígitos");
                        return;
                    }

                    string ruc = txtruc.Text;

                    Proveedor proveedor = new Proveedor();
                    proveedor = db.ConsultaRUC(ruc);
                    if (proveedor != null)
                    {
                        txtrazon.Text = proveedor.RazonSocial;
                        txtdireccion.Text = proveedor.Direccion;

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());

                }
            }


        }

        private void FrmFactura_Load(object sender, EventArgs e)
        {
            CorelativoFactura();
            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            if (dgvProductos.Rows.Count>0)
            {
                CalcularTotal();
            }
        }

        private void CorelativoFactura()
        {

            using (FacturaBLL db = new FacturaBLL())
            {
                try
                {

                    Factura factura = new Factura();
                    factura = db.Correlativo();

                    lblserie.Text = factura.Serie;

                    int cantidadDigitos = 8;
                    lblnumero.Text = factura.Numero.ToString("D" + cantidadDigitos.ToString());
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void CalcularTotal()
        {
            double total = 0;
            double subtotal = 0;
            double igv = 0;
            int items = 0;
            int productos = 0;

            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                total += Convert.ToDouble(row.Cells["SUBTOTAL"].Value);
                //cantidad += Convert.ToInt32(row.Cells["CANTIDAD"].Value);

                if (Convert.ToDouble(row.Cells["PRECIO"].Value) > 0)
                {
                    items += 1;
                    productos += Convert.ToInt32(row.Cells["CANTIDAD"].Value);
                }

            }

            subtotal = total / 1.18;
            igv = total - subtotal;

            txttotal.Text = string.Format("{0:0.00}", total);
            txtsubtotal.Text = string.Format("{0:0.00}", subtotal);
            txtigv.Text = string.Format("{0:0.00}", igv);
            lblitems.Text = items.ToString();
            lblproductos.Text = productos.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(" Esta seguro de registrar la factura?", "factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                int idfactura = RegistrarFactura();

                if (idfactura > 0)
                {
                    MessageBox.Show("Factura Registrada");
                    ImporteLetras importe = new ImporteLetras();
                    string letras = importe.Convertir(txttotal.Text, true);
                    FacturaXML factura = new FacturaXML();
                    List<FacturaDetalleXML> detalle = new List<FacturaDetalleXML>();

                    //llena los datos de la factura que van en el xml
                    factura.serieynumero = lblserie.Text + "-" + lblnumero.Text;
                    factura.fechaemision = DateTime.Now.ToString("yyyy-MM-dd");
                    factura.horaemision = DateTime.Now.ToString("HH:mm:ss");
                    factura.importeletras = letras;
                    factura.cantidaditems = dgvProductos.Rows.Count.ToString();
                    factura.rucemisor = lblruc.Text.Substring(4, 11);

                    factura.razonemisor = lblrazon.Text;
                    factura.nombrecomercial = "ALLQOVET";
                    factura.ruccliente = txtruc.Text;
                    factura.razoncliente = txtrazon.Text;
                    factura.igv = txtigv.Text;
                    factura.subtotal = txtsubtotal.Text;
                    factura.total = txttotal.Text;

                    int contador = 0;

                    foreach (DataGridViewRow row in dgvProductos.Rows)
                    {
                        if (Convert.ToDouble(row.Cells["PRECIO"].Value) > 0)
                        {
                            contador++;
                            double subtotal = Convert.ToDouble(row.Cells["SUBTOTAL"].Value);
                            double valorventa = subtotal / 1.18;
                            double igv = subtotal - valorventa;

                            FacturaDetalleXML detfactura = new FacturaDetalleXML();
                            detfactura.numeroitem = contador.ToString();
                            detfactura.cantidaditem = row.Cells["CANTIDAD"].Value.ToString();
                            detfactura.valorventa = string.Format("{0:0.00}", valorventa);
                            detfactura.preciounitario = row.Cells["PRECIO"].Value.ToString();
                            detfactura.igv = string.Format("{0:0.00}", igv);
                            detfactura.descripcion = row.Cells["DESCRIPCION"].Value.ToString();
                            detfactura.idproducto = row.Cells["IDPRODUCTO"].Value.ToString();

                            detalle.Add(detfactura);
                        }

                    }


                    //1.-GENERO EL XML DENTRO DE TRY CATCH PARA MOSTRAR EN CASO DE ERROR EN UN MESAGEBOX 
                    try
                    {
                        if (GenerarFactura.Generar(factura, detalle)) ;//MessageBox.Show("XML CREADO");

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error al generar XML de la boleta: " + ex.Message);
                        return;
                    }
                    //2.-FIRMO EL XML
                    try
                    {
                        if (GenerarFactura.Firmar(factura, "Carlosbeto0308")) ; //MessageBox.Show("XML FIRMADO");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al firmar XML de la boleta (Form): " + ex.Message);
                        return;
                    }
                    //3.- GENERO EL CODIGO QR ,NO HAGO EL ENVIO PORQUE SERA MEDIANTE RESUMEN
                    try
                    {
                        if (GenerarFactura.CrearQR(factura)) ;// MessageBox.Show("QR creado"); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al crear el codigo QR: " + ex.Message);
                        return;
                    }
                    //SI TODO SALIO BIEN IMPRIMO LA FACTURA
                    string exeFolder = Path.GetDirectoryName(Application.ExecutablePath); //ruta de la aplicacion

                    exeFolder += @"\sunat\facturas\qrcode\" + factura.rucemisor + "-01-" + factura.serieynumero + ".png"; //ruta absoluta de la imagen qr

                    //  string archivoqr = "sunat/facturas/qrcode/" + factura.rucemisor + "-01-" + factura.serieynumero + ".png";
                    ImprimirFactura(idfactura, exeFolder);
                    this.Close();




                }
            }
        }

        private int RegistrarFactura()
        {
            int idfactura = 0;
            using (FacturaBLL db = new FacturaBLL())
            {
                try
                {

                    Factura factura = new Factura();
                    List<DetalleFactura> detallesFactura = new List<DetalleFactura>();

                    factura.Serie = lblserie.Text;
                    factura.Numero = Convert.ToInt32(lblnumero.Text);
                    factura.Idventa = Convert.ToInt32(lblidventa.Text);
                    factura.Total = Convert.ToDouble(txttotal.Text);

                    factura.ruc = txtruc.Text;
                    factura.razon = txtrazon.Text;
                    factura.direccion = txtdireccion.Text;

                    foreach (DataGridViewRow row in dgvProductos.Rows)
                    {
                        DetalleFactura detalle = new DetalleFactura();
                        detalle.Idproducto = Convert.ToInt32(row.Cells["IDPRODUCTO"].Value.ToString());
                        detalle.Descripcion = row.Cells["DESCRIPCION"].Value.ToString();
                        detalle.Cantidad = Convert.ToInt32(row.Cells["CANTIDAD"].Value.ToString());
                        detalle.Precio = Convert.ToDouble(row.Cells["PRECIO"].Value.ToString());

                        detallesFactura.Add(detalle);


                    }

                    idfactura = db.Agregar(factura, detallesFactura);
                    return idfactura;
                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                    return 0;
                }
            }

        }

        private void ImprimirFactura(int idfactura, string archivoqr)
        {


            using (FacturaBLL db = new FacturaBLL())
            {
                try
                {
                    ImporteLetras importe = new ImporteLetras();
                    string letras = importe.Convertir(txttotal.Text, true);

                    DataTable prueba = db.ImprimiFactura(idfactura);

                    int filas = prueba.Rows.Count;

                    frmImprimirFactura factura = new frmImprimirFactura();
                    factura.ruta = @"sunat\facturas\" + lblserie.Text + "-" + lblnumero.Text + ".pdf";

                    ReportDataSource fuente = new ReportDataSource("DataSetFactura", db.ImprimiFactura(idfactura));

                    factura.reportViewer1.LocalReport.DataSources.Clear();
                    factura.reportViewer1.LocalReport.DataSources.Add(fuente);
                    factura.reportViewer1.LocalReport.ReportEmbeddedResource = "Allqovet.Reportes.Factura.rdlc";

                    ReportParameter[] p = new ReportParameter[2];

                    p[0] = new ReportParameter("ptotal", letras);
                    p[1] = new ReportParameter("pcodigoQR", @"file:///" + archivoqr);

                    factura.reportViewer1.LocalReport.EnableExternalImages = true;
                    factura.reportViewer1.LocalReport.SetParameters(p);

                    factura.reportViewer1.RefreshReport();
                    factura.reportViewer1.LocalReport.Refresh();

                    Ventana ventana = new Ventana();
                    ventana.AbrirFormHijo(factura);

                 

                }

                catch (Exception ex)
                {

                    MessageBox.Show("error al imprimir : " + ex.Message);
                }
            }
        }
    }
}
