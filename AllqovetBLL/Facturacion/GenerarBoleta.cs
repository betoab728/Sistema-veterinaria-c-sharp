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
  public  class GenerarBoleta
    {
        public static bool Generar(BoletaXML boleta, List<BoletaDetalleXML> detalle)
        {
            bool resultado = false;
            try
            {
                //cargar plantilla
                string mixml = File.ReadAllText("cpe_xml/Boleta.xml");
                mixml = mixml.Replace("{{serie_numero}}", boleta.serieynumero);
                mixml = mixml.Replace("{{fecha_emision}}", boleta.fechaemision);
                mixml = mixml.Replace("{{hora_emision}}", boleta.horaemision);
                mixml = mixml.Replace("{{fecha_vcmto}}", boleta.fechaemision);
                mixml = mixml.Replace("{{importe_letras}}", boleta.importeletras);
                mixml = mixml.Replace("{{cantidad_items}}", boleta.cantidaditems);
                mixml = mixml.Replace("{{ruc_emisor}}", boleta.rucemisor);
                mixml = mixml.Replace("{{razon_emisor}}", boleta.razonemisor);
                mixml = mixml.Replace("{{nombre_comercial}}", boleta.nombrecomercial);
                mixml = mixml.Replace("{{dni}}", boleta.dni);
                mixml = mixml.Replace("{{nombre_cliente}}", boleta.nombre);
                mixml = mixml.Replace("{{igv_venta}}", boleta.igv);
                mixml = mixml.Replace("{{subtotal}}", boleta.subtotal);
                mixml = mixml.Replace("{{total_venta}}", boleta.total);

                string item = "";
                string item2 = "";
                int contador = 1;
                foreach (BoletaDetalleXML det in detalle)
                {
                    item = File.ReadAllText("cpe_xml/BoletaDetalle.xml");
                    det.numeroitem = contador.ToString();

                    item = item.Replace("{{numero_item}}", det.numeroitem);
                    item = item.Replace("{{cantidad_item}}", det.cantidaditem);
                    item = item.Replace("{{valor_venta_item}}", det.valorventa);
                    item = item.Replace("{{precio_unitario_item}}", det.preciounitario);
                    item = item.Replace("{{igv_item}}", det.igv);
                    item = item.Replace("{{item_descripcion}}", det.descripcion);
                    item = item.Replace("{{idproducto}}", det.idproducto);
                    item2 += item;
                    contador++;
                }

                mixml = mixml.Replace("{{items}}", item2);

                string nombrearchivo = "sunat/boletas/xmls/" + boleta.rucemisor + "-03-" + boleta.serieynumero + ".xml";
                File.WriteAllText(nombrearchivo, mixml);
               

            }
            catch (Exception ex)
            {
                resultado = false;
                throw new Exception("Error al crear el archivo XML: " + ex.Message);

            }
            return resultado;
        }


        public static bool Firmar(BoletaXML boleta, string passcert)
        {
            bool resultado = false;
          
            try
            { //cada certificado llevara como nombre el RUC 
                string nombrearchivo = "sunat/boletas/firmados/" + boleta.rucemisor + "-03-" + boleta.serieynumero + ".xml";

                Firmador.Firmar("certificados/20600849957.pfx", passcert,
                "sunat/boletas/xmls/" + boleta.rucemisor + "-03-" + boleta.serieynumero + ".xml",
               nombrearchivo);

            }
            catch (Exception ex)
            {

                resultado = false;
                throw new Exception("Error al firmar el archivo XML (Generar): " + ex.Message);
            }
            return resultado;
        }

        public static bool Emitir(BoletaXML boleta, string carpeta)
        {
            bool resultado = false;

            try
            {
                //creo el archivo zip del xml firmado
                string nombrearchivo = "sunat/boletas/zipeados/" + boleta.rucemisor + "-03-" + boleta.serieynumero + ".zip";
                ZipFile zip = new ZipFile();
                zip.AddFile("sunat/boletas/firmados/" + boleta.rucemisor + "-03-" + boleta.serieynumero + ".xml", @"\");
                zip.Save(nombrearchivo);

                 ServiceFacturacion.billServiceClient cliente = new ServiceFacturacion.billServiceClient();
                cliente.Open();
                byte[] xml_zipeado = File.ReadAllBytes(nombrearchivo);

                byte[] xml_bytes = cliente.sendBill(boleta.rucemisor + "-03-" + boleta.serieynumero + ".zip", xml_zipeado, null);
                string archivoCDR = "sunat/boletas/cdr/R-" + boleta.rucemisor + "-03-" + boleta.serieynumero + ".zip";
                FileStream fs = new FileStream(archivoCDR, FileMode.Create);
                fs.Write(xml_bytes, 0, xml_bytes.Length);
                fs.Close();
                cliente.Close();

            }
            catch (Exception e)
            {
                resultado = false;
                throw new Exception("Error al enviar la boleta: " + e.Message);

            }

            return resultado;

        }


        public static bool CrearQR(BoletaXML boleta)
        {
            bool resultado = false;

            try
            {
                string serie, numero;
                serie = boleta.serieynumero.Substring(0, 4);
                numero = boleta.serieynumero.Substring(5, 8);

                //extraigo el digest value
                XmlDocument xmld = new XmlDocument();
                xmld.Load("sunat/boletas/firmados/" + boleta.rucemisor + "-03-" + boleta.serieynumero + ".xml");
                //EL QRCODE LLEVA: 1.RUC 2.TIPO COMPROBANTE 3.SERIE Y NUMERO 4.IGV 5.TOTAL 6.FECHA 7.TIPO DOC DEL USUARIO
                //8.NUMERO DOC 9.CODIGO HASH
                string codigo = xmld.GetElementsByTagName("DigestValue").Item(0).InnerText;
                string qrcode = boleta.rucemisor + "|" + "03" + "|" + serie + "|" + numero + "|" + boleta.igv + "|" +
                boleta.total + "|" + boleta.fechaemision + "|" + "1" + "|" + boleta.dni + "|" + codigo;

                QrEncoder qr = new QrEncoder();
                QrCode cod = new QrCode();
                qr.TryEncode(qrcode, out cod);
                GraphicsRenderer rederer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero));
                MemoryStream ms = new MemoryStream();
                rederer.WriteToStream(cod.Matrix, ImageFormat.Png, ms);
                var imgtemp = new Bitmap(ms);
                var img = new Bitmap(imgtemp, new Size(new Point(200, 200)));

                string nombrearchivo = "sunat/boletas/qrcode/" + boleta.rucemisor + "-03-" + boleta.serieynumero + ".png";
                img.Save(nombrearchivo, ImageFormat.Png);


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
