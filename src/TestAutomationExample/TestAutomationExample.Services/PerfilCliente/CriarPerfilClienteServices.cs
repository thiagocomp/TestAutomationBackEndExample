using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationExample.Domain.PerfilCliente;

namespace TestAutomationExample.Services.PerfilCliente
{
    public class CriarPerfilClienteServices : Infra.RestConfig.PerfilCliente
    {
        public RestResponse criarPerfilCliente(CriarPerfilCliente criarPerfilCliente)
        {
            var request = new RestRequest("criarPerfilCliente");
            request.AddHeader("Authorization", _Bearer);
            request.AddBody(criarPerfilCliente);
            return _client.Post(request);
        }

        public RestResponse criarPerfilClienteBearerTokenInvalido(CriarPerfilCliente criarPerfilCliente)
        {
            var request = new RestRequest("criarPerfilCliente");
            request.AddHeader("Authorization", "DFGHJKXCVBN");
            request.AddBody(criarPerfilCliente);
            return _client.Post(request);
        }

        public RestResponse criarPerfilClienteSemBearerToken(CriarPerfilCliente criarPerfilCliente)
        {
            var request = new RestRequest("criarPerfilCliente");
            request.AddBody(criarPerfilCliente);
            return _client.Post(request);
        }
    }
}
