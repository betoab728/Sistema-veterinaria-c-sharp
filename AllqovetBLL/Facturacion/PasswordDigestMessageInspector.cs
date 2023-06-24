using Microsoft.Web.Services3.Security.Tokens;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Xml;


namespace AllqovetBLL.Facturacion
{
    class PasswordDigestMessageInspector: IClientMessageInspector
    {
        public string V1 { get; set; }
        public string V2 { get; set; }

        public PasswordDigestMessageInspector(string v1, string v2)
        {
            V1 = v1;
            V2 = v2;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {

        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            UsernameToken token = new UsernameToken(V1, V2, PasswordOption.SendPlainText);

            XmlElement securityToken = token.GetXml(new XmlDocument());

            // Modificamos el XML Generado.
            var nodo = securityToken.GetElementsByTagName("wsse:Nonce").Item(0);
            nodo.RemoveAll();

            nodo = securityToken.GetElementsByTagName("wsu:Created").Item(0);
            nodo.RemoveAll();

            securityToken.RemoveAttribute("Id");


            MessageHeader securityHeader = MessageHeader.CreateHeader("Security",
                "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd",
                securityToken, false);
            request.Headers.Add(securityHeader);

            return Convert.DBNull;
        }
    }
}
