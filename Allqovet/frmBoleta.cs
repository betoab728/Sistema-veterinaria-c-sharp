using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AllqovetBLL;
using AllqovetBLL.Facturacion;
using Entidades;
using Entidades.cpe_sunat;
using Microsoft.Reporting.WinForms;

namespace Allqovet
{
    public partial class frmBoleta : Form
    {
        public frmBoleta()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBoleta_Load(object sender, EventArgs e)
        {
            CorelativoBoleta();
            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            if (dgvProductos.Rows.Count >0)
            {
                CalcularTotal();
            }
        }

        private void  CalcularTotal()
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

        private void CorelativoBoleta()
        {

            using (BoletaBLL db = new BoletaBLL())
            {
                try
                {

                    Boleta boleta = new Boleta();
                    boleta = db.Correlativo();

                    lblserie.Text = boleta.serie;
                 
                    int cantidadDigitos = 8;
                    lblnumero.Text = boleta.numero.ToString("D" + cantidadDigitos.ToString());
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConsultaReniec();
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
                       
                        txtnombre.Text = cliente.Nombres + cliente.ApellidoPaterno + cliente.ApellidoMaterno;
                       
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());

                }
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(" Esta seguro de registrar la boleta?", "boleta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
               int idboleta = RegistrarBoleta();
                //una vez que se graba en el sistema procede la facturacion electronica
                if (idboleta > 0)
                {
                    MessageBox.Show("Boleta Registrada");
                    ImporteLetras importe = new ImporteLetras();
                    string letras = importe.Convertir(txttotal.Text, true);
                    BoletaXML boleta = new BoletaXML();
                    List<BoletaDetalleXML> detalle = new List<BoletaDetalleXML>();

                    //llena los datos de la factura que van en el xml
                    boleta.serieynumero = lblserie.Text + "-" + lblnumero.Text;
                    boleta.fechaemision = DateTime.Now.ToString("yyyy-MM-dd");
                    boleta.horaemision = DateTime.Now.ToString("HH:mm:ss");
                    boleta.importeletras = letras;
                    boleta.cantidaditems = dgvProductos.Rows.Count.ToString();
                    boleta.rucemisor = lblruc.Text.Substring(4, 11);

                    boleta.razonemisor = lblrazon.Text;
                    boleta.nombrecomercial = "ALLQOVET";
                    boleta.dni = txtdni.Text;
                    boleta.nombre = txtnombre.Text;
                    boleta.igv = txtigv.Text;
                    boleta.subtotal = txtsubtotal.Text;
                    boleta.total = txttotal.Text;

                    int contador = 0;

                    foreach (DataGridViewRow row in dgvProductos.Rows)
                    {
                        if (Convert.ToDouble(row.Cells["PRECIO"].Value) > 0)
                        {
                            contador++;
                            double subtotal = Convert.ToDouble(row.Cells["SUBTOTAL"].Value);
                            double valorventa = subtotal / 1.18;
                            double igv = subtotal - valorventa;

                            BoletaDetalleXML detboleta = new BoletaDetalleXML();
                            detboleta.numeroitem = contador.ToString();
                            detboleta.cantidaditem = row.Cells["CANTIDAD"].Value.ToString();
                            detboleta.valorventa = string.Format("{0:0.00}", valorventa);
                            detboleta.preciounitario = row.Cells["PRECIO"].Value.ToString();
                            detboleta.igv = string.Format("{0:0.00}", igv);
                            detboleta.descripcion = row.Cells["DESCRIPCION"].Value.ToString();
                            detboleta.idproducto = row.Cells["IDPRODUCTO"].Value.ToString();

                            detalle.Add(detboleta);
                        }

                    }


                    //1.-GENERO EL XML DENTRO DE TRY CATCH PARA MOSTRAR EN CASO DE ERROR EN UN MESAGEBOX 
                    try
                    {
                        if (GenerarBoleta.Generar(boleta, detalle)) ;//MessageBox.Show("XML CREADO");

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error al generar XML de la boleta: " + ex.Message);
                        return;
                    }
                    //2.-FIRMO EL XML
                    try
                    {
                        if (GenerarBoleta.Firmar(boleta, "Carlosbeto0308")) ; //MessageBox.Show("XML FIRMADO");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al firmar XML de la boleta (Form): " + ex.Message);
                        return;
                    }
                    //3.- GENERO EL CODIGO QR ,NO HAGO EL ENVIO PORQUE SERA MEDIANTE RESUMEN
                    try
                    {
                        if (GenerarBoleta.CrearQR(boleta)) ;// MessageBox.Show("QR creado"); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al crear el codigo QR: " + ex.Message);
                        return;
                    }

                    //SI TODO SALIO BIEN IMPRIMO LA BOLETA
                    string exeFolder = Path.GetDirectoryName(Application.ExecutablePath); //ruta de la aplicacion
                    exeFolder += @"\sunat\boletas\qrcode\" + boleta.rucemisor + "-03-" + boleta.serieynumero + ".png"; //ruta absoluta de la imagen qr

                    ImprimirBoleta(idboleta, exeFolder);

                    this.Close();

                    //  ImprimirBoleta(idboleta);
                }
            }
        }

        private int RegistrarBoleta()
        {
            int idboleta = 0;
            using (BoletaBLL db=new BoletaBLL())
            {
                try
                {
                
                    Boleta boleta = new Boleta();
                    List<DetalleBoleta> detallesBoleta = new List<DetalleBoleta>();

                    boleta.serie = lblserie.Text;
                    boleta.numero = Convert.ToInt32(lblnumero.Text);
                    boleta.Idventa = Convert.ToInt32(lblidventa.Text);
                    boleta.Total = Convert.ToDouble(txttotal.Text);

                    foreach (DataGridViewRow row in dgvProductos.Rows)
                    {
                        DetalleBoleta detalle = new DetalleBoleta();
                        detalle.Idproducto= Convert.ToInt32(row.Cells["IDPRODUCTO"].Value.ToString());
                        detalle.Descripcion = row.Cells["DESCRIPCION"].Value.ToString();
                        detalle.Cantidad= Convert.ToInt32(row.Cells["CANTIDAD"].Value.ToString());
                        detalle.Precio = Convert.ToDouble(row.Cells["PRECIO"].Value.ToString());

                        detallesBoleta.Add(detalle);


                    }

                    idboleta= db.Agregar(boleta, detallesBoleta);
                    return idboleta;
                }
               
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                    return 0;
                }
            }

        }
        private void ImprimirBoleta(int idboleta, string archivoqr)
        {


            using (BoletaBLL db = new BoletaBLL())
            {
                try
                {
                    ImporteLetras importe = new ImporteLetras();
                    string letras = importe.Convertir(txttotal.Text, true);

                    DataTable prueba = db.ImprimiBoleta(idboleta);

                    int filas = prueba.Rows.Count;

                    frmImprimirBoleta boleta = new frmImprimirBoleta();
                    ReportDataSource fuente = new ReportDataSource("DataSetBoleta", db.ImprimiBoleta(idboleta));

                    //  boleta.nombrearchivo = lblserie.Text + "-" + lblnumero.Text;

                    boleta.ruta = @"sunat\boletas\" + lblserie.Text + "-" + lblnumero.Text + ".pdf";

                    boleta.reportViewer1.LocalReport.DataSources.Clear();
                    boleta.reportViewer1.LocalReport.DataSources.Add(fuente);
                    boleta.reportViewer1.LocalReport.ReportEmbeddedResource = "Allqovet.Reportes.Boleta.rdlc";

                    ReportParameter[] p = new ReportParameter[2];

                    p[0] = new ReportParameter("ptotal", letras);
                    p[1] = new ReportParameter("pcodigoQR", @"file:///" + archivoqr);

                    boleta.reportViewer1.LocalReport.EnableExternalImages = true;
                    boleta.reportViewer1.LocalReport.SetParameters(p);

                    boleta.reportViewer1.RefreshReport();
                    boleta.reportViewer1.LocalReport.Refresh();

                    Ventana ventana = new Ventana();
                    ventana.AbrirFormHijo(boleta);
                  
                    // Inicializar();

                }

                catch (Exception ex)
                {

                    MessageBox.Show( "error al imprimir : "+ex.Message);
                }
            }
        }
    }
}
