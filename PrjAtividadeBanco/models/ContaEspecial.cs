using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public string exibirDadosConta()
        {
            return $"#############################\n " +
            $"O nome do titular é: {this.Titular}, " +
            $"o número de sua conta é: {this.NumeroConta}, " +
            $"seu saldo atual é de: {this.Saldo}, " +
            $"e seu limite disponível é: {this.Limite}. " +
            $"\n#############################";
        }
        public void Sacar(double valor)
        {
            if (valor > this.Saldo + this.Limite) 
            {
                throw new InvalidOperationException("#############################\n Saque não permitido. Valor maior que o saldo e limite.\n#############################");
            };
            this.Saldo -= valor;
        }


    }
}
