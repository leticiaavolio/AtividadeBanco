using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrjAtividadeBanco.models
{
    internal class ContaEspecial
    {
        public string Titular { get; set; }
        public string NumeroConta { get; set; }
        public double Saldo { get; set; }
        public double Limite { get; set; }

        public ContaEspecial()
        {
        }
        public ContaEspecial(string pTitular, string pNumeroConta, double pSaldo, double pLimite) 
        { 
            this.Titular = pTitular;
            this.NumeroConta = pNumeroConta;
            this.Saldo = pSaldo;
            this.Limite = pLimite;
        }
    }
}
