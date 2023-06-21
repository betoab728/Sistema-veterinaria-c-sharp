using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;


namespace AllqovetBLL.Facturacion
{
    class PasswordDigestBehavior: IEndpointBehavior
    {
        public string V1 { get; set; }
        public string V2 { get; set; }

        public PasswordDigestBehavior(string v1, string v2)
        {
            V1 = v1;
            V2 = v2;
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            // new System.NotImplementedException();
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime) =>
            //throw new System.NotImplementedException();
            clientRuntime.ClientMessageInspectors.Add(new PasswordDigestMessageInspector(V1, V2));

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            //throw new System.NotImplementedException();
        }

        public void Validate(ServiceEndpoint endpoint)
        {
            //throw new System.NotImplementedException();
            return;
        }
    }
}
