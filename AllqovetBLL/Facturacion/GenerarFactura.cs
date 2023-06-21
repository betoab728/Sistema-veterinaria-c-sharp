using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zip;
using System.Xml;
using System.IO;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.Drawing.Imaging;
using System.Drawing;
using Entidades.cpe_sunat;

namespace AllqovetBLL.Facturacion
{
   public class GenerarFactura
    {
        public static bool Generar(FacturaXML factura, List<FacturaDetalleXML> detalle)
        {
            bool resultado = false;
            try
            {
                //cargar plantilla
                string mixml = File.ReadAllText("cpe_xml/Factura.xml");
                mixml = mixml.Replace("{{serie_numero}}", factura.serieynumero);
                mixml = mixml.Replace("{{fecha_emision}}", factura.fechaemision);
                mixml = mixml.Replace("{{hora_emision}}", factura.horaemision);
                mixml = mixml.Replace("{{fecha_vcmto}}", factura.fechaemision);
                mixml = mixml.Replace("{{importe_letras}}", factura.importeletras);
                mixml = mixml.Replace("{{numeroitems}}", factura.cantidaditems);
                mixml = mixml.Replace("{{ruc_emisor}}", factura.rucemisor);
                mixml = mixml.Replace("{{razon_emisor}}", factura.razonemisor);
                mixml = mixml.Replace("{{nombre_comercial}}", factura.nombrecomercial);
                mixml = mixml.Replace("{{ruc_cliente}}", factura.ruccliente);
                mixml = mixml.Replace("{{razon_cliente}}", factura.razoncliente);
                mixml = mixml.Replace("{{direccion_cliente}}", factura.direccion);
                mixml = mixml.Replace("{{igv_venta}}", factura.igv);
                mixml = mixml.Replace("{{subtotal}}", factura.subtotal);
                mixml = mixml.Replace("{{total_venta}}", factura.total);

                string item = "";
                string item2 = "";
                int contador = 1;
                double valorprecio = 0;
                foreach (FacturaDetalleXML det in detalle)
                {

                    // esto es nuevo requisito de sunat


                    item = File.ReadAllText("cpe_xml/FacturaDetalle.xml");
                    det.numeroitem = contador.ToString();

                    item = item.Replace("{{numero_item}}", det.numeroitem);
                    item = item.Replace("{{cantidad_item}}", det.cantidaditem);
                    item = item.Replace("{{valor_venta_item}}", det.valorventa);
                    item = item.Replace("{{precio_unitario_item}}", det.preciounitario);
                    item = item.Replace("{{igv_item}}", det.igv);
                    item = item.Replace("{{item_descripcion}}", det.descripcion);
                    item = item.Replace("{{idproducto}}", det.idproducto);
                    valorprecio = Math.Round(Convert.ToDouble(det.preciounitario) / 1.18, 4);
                    item = item.Replace("{{valorprecio}}", valorprecio.ToString());
                    item2 += item;
                    contador++;
                }

                mixml = mixml.Replace("{{items}}", item2);
                string nombrearchivo = "sunat/facturas/xmls/" + factura.rucemisor + "-01-" + factura.serieynumero + ".xml";
                File.WriteAllText(nombrearchivo, mixml);
                resultado = true;
             

            }
            catch (Exception ex)
            {

                resultado = false;
                throw new Exception("Error al crear el archivo XML: " + ex.Message);
            }
            return resultado;
        }


        public static bool Firmar(FacturaXML factura,string passcert)
        {
            bool resultado = false;
            try
            {
                string nombrearchivo = "sunat/facturas/firmados/" + factura.rucemisor + "-01-" + factura.serieynumero + ".xml";
                Firmador.Firmar("certificados/" + factura.rucemisor + ".pfx", passcert,
                     "sunat/facturas/xmls/" + factura.rucemisor + "-01-" + factura.serieynumero + ".xml"
                     , nombrearchivo);
                resultado = true;
           

            }
            catch (Exception ex)
            {

                resultado = false;
                throw new Exception("Error al firmar el archivo XML: " + ex.Message);
            }
            return resultado;
        }

        public static bool Emitir(FacturaXML factura, string carpeta,
          string usuario, string pass, string UsuarioSol, string paasw)
        {
            bool resultado = false;

            try
            {
                //creo el archivo zip del xml firmado
                ZipFile zip = new ZipFile();
                string nombrearchivo = "sunat/facturas/zipeados/" + factura.rucemisor + "-01-" + factura.serieynumero + ".zip";
                zip.AddFile("sunat/facturas/firmados/" + factura.rucemisor + "-01-" + factura.serieynumero + ".xml", @"\");
                zip.Save(nombrearchivo);

                // Conexion a la sunat

                ServiceFacturacion.billServiceClient cliente = new ServiceFacturacion.billServiceClient();
                System.Net.ServicePointManager.UseNagleAlgorithm = true;
                System.Net.ServicePointManager.Expect100Continue = false;
                System.Net.ServicePointManager.CheckCertificateRevocationList = true;
                var behavior = new PasswordDigestBehavior(UsuarioSol, paasw);
                cliente.Endpoint.EndpointBehaviors.Add(behavior);


                //esta parte comente para que solo cree el zip
                // ServiceFacturaSunat.billServiceClient cliente = new ServiceFacturaSunat.billServiceClient();
                cliente.Open();
                byte[] xml_zipeado = File.ReadAllBytes("sunat/facturas/zipeados/" + factura.rucemisor + "-01-" + factura.serieynumero + ".zip");

                byte[] xml_bytes = cliente.sendBill(factura.rucemisor + "-01-" + factura.serieynumero + ".zip", xml_zipeado, null);
                // byte[] xml_bytes = cliente.sendBill("20524728061" + "-01-" + factura.serieynumero + ".zip", xml_zipeado, null);
                string archivoCDR = "sunat/facturas/cdr/R-" + factura.rucemisor + "-01-" + factura.serieynumero + ".zip";
                FileStream fs = new FileStream(archivoCDR, FileMode.Create);
                fs.Write(xml_bytes, 0, xml_bytes.Length);
                fs.Close();
                cliente.Close();
                resultado = true;

            }
            catch (Exception e)
            {
                resultado = false;
                throw new Exception("Error al enviar la factura: " + e.Message);

            }

            return resultado;

        }
        public static bool Comprimir(FacturaXML factura)
        {
            try
            {
                ZipFile zip = new ZipFile();
                string nombrearchivo = "sunat/facturas/zipeados/" + factura.rucemisor + "-01-" + factura.serieynumero + ".zip";
                zip.AddFile("sunat/facturas/firmados/" + factura.rucemisor + "-01-" + factura.serieynumero + ".xml", @"\");
                zip.Save(nombrearchivo);
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static bool CrearQR(FacturaXML factura)
        {
            bool resultado = false;

            try
            {
                string serie, numero;
                serie = factura.serieynumero.Substring(0, 4);
                numero = factura.serieynumero.Substring(5, 8);

                //extraigo el digest value
                XmlDocument xmld = new XmlDocument();
                xmld.Load("sunat/facturas/firmados/" + factura.rucemisor + "-01-" + factura.serieynumero + ".xml");
                //EL QRCODE LLEVA: 1.RUC 2.TIPO COMPROBANTE 3.SERIE Y NUMERO 4.IGV 5.TOTAL 6.FECHA 7.TIPO DOC DEL USUARIO
                //8.NUMERO DOC 9.CODIGO HASH
                string codigo = xmld.GetElementsByTagName("DigestValue").Item(0).InnerText;
                string qrcode = factura.rucemisor + "|" + "01" + "|" + serie + "|" + numero + "|" + factura.igv + "|" +
                factura.total + "|" + factura.fechaemision + "|" + "6" + "|" + factura.ruccliente + "|" + codigo;

                QrEncoder qr = new QrEncoder();
                QrCode cod = new QrCode();
                qr.TryEncode(qrcode, out cod);
                GraphicsRenderer rederer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero));
                MemoryStream ms = new MemoryStream();
                rederer.WriteToStream(cod.Matrix, ImageFormat.Png, ms);
                var imgtemp = new Bitmap(ms);
                var img = new Bitmap(imgtemp, new Size(new Point(200, 200)));

                string nombrearchivo = "sunat/facturas/qrcode/" + factura.rucemisor + "-01-" + factura.serieynumero + ".png";
                img.Save(nombrearchivo, ImageFormat.Png);
               
                resultado = true;
              

            }
            catch (Exception e)
            {

                resultado = false;
                throw new Exception("Error al generar el codigo QR: " + e.Message);
            }
            return resultado;
        }
    }
}
