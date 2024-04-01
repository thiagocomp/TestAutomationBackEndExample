using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationExample.Domain.PerfilCliente
{
    public class CriarPerfilCliente
    {
        public string nome { get; set; }
        public int agencia { get; set; }
        public int conta { get; set; }
        public int dac  { get; set; }
        public PerfilInvestidor perfil_investidor { get; set; }
        public bool possui_investimento { get; set; }

        public CriarPerfilCliente(string _nome, int _agencia, int _conta, int _dac, PerfilInvestidor _perfilInvestidor, bool _possuiInvestimento)
        {
            nome = _nome;
            agencia = _agencia;
            conta = _conta;
            dac = _dac;
            perfil_investidor = _perfilInvestidor;
            possui_investimento = _possuiInvestimento;
        }
    }
}
