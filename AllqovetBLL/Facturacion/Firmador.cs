using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.Xml;
namespace AllqovetBLL.Facturacion
{
    class Firmador
    {
        public static void Firmar (string path_cert, string pass_cert, string path_xml, string path_guardar)
        {
            //cargar certificado
            System.Security.Cryptography.X509Certificates.X509Certificate2 certificado
                = new System.Security.Cryptography.X509Certificates.X509Certificate2(path_cert, pass_cert,
                    System.Security.Cryptography.X509Certificates.X509KeyStorageFlags.Exportable);

            //cargar xml
            var xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.PreserveWhitespace = true;
            xmlDoc.Load(path_xml);

            var nodoExtension =
                xmlDoc.GetElementsByTagName(
                    "ExtensionContent",
                    "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2").Item(0);

            var signedXml = new SignedXml(xmlDoc) { SigningKey = certificado.PrivateKey };
            var xmlSignature = signedXml.Signature;

            var env = new XmlDsigEnvelopedSignatureTransform();

            var reference = new Reference(string.Empty);
            reference.AddTransform(env);
            xmlSignature.SignedInfo.AddReference(reference);

            var keyInfo = new KeyInfo();
            var x509Data = new KeyInfoX509Data(certificado);

            x509Data.AddSubjectName(certificado.Subject);

            keyInfo.AddClause(x509Data);
            xmlSignature.KeyInfo = keyInfo;
            xmlSignature.Id = "Sunat";
            signedXml.ComputeSignature();

            nodoExtension.AppendChild(signedXml.GetXml());

            using (var memDoc = new System.IO.MemoryStream())
            {

                using (var writer = System.Xml.XmlWriter.Create(memDoc,
                    new System.Xml.XmlWriterSettings { Encoding = Encoding.GetEncoding("UTF-8") }))
                {
                    xmlDoc.WriteTo(writer);
                }
            }
            xmlDoc.Save(path_guardar);
        }
    }
}
