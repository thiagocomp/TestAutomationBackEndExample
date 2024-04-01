using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationExample.Infra.RestConfig
{
    public class PerfilCliente
    {
        protected readonly RestClient _client;
        protected readonly string _Bearer;

        public PerfilCliente()
        {
            _client = new RestClient(Environment.GetEnvironmentVariable("PERFIL_URL"));
            _Bearer = Environment.GetEnvironmentVariable("PERFIL_BEARER");
        }
    }
}
