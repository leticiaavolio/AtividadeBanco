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
    }
}
