using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrjAtividadeBanco.models
{
    internal class ContaPoupanca
    {
        public string Titular { get; set; }
        public string NumeroConta { get; set; }
        public double Saldo { get; set; }
        public DateTime DataDeAniversario = DateTime.Now;

        public string exibirDadosConta()
        {
            return $"#############################\n " +
            $"O nome do titular é: {this.Titular}, " +
            $"o número de sua conta é: {this.NumeroConta}, " +
            $"seu saldo atual é de: {this.Saldo}, " +
            $"e sua data de entrada é: {this.DataDeAniversario}. " +
            $"\n#############################";
        }

    }
}
