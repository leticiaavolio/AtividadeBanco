using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetiAvolio.PrjAtividadeBanco.models
{
    public abstract class Conta
    {
        public string Titular { get; set; }
        public string NumeroConta { get; set; }
        public double Saldo { get; set; }

        public void Sacar(double valor)
        {
            if (valor > Saldo)
            {
                throw new InvalidOperationException("#############################\n Saque não permitido. Valor maior que o saldo. \n#############################");
            }
            this.Saldo -= valor;
        }
        public void Depositar(double valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("#############################\n Valor do depósito deve ser maior que zero.\n#############################");
            }
            this.Saldo += valor;
        }
        public bool Transferir(Conta pConta, double pValor) 
        {
            try
            {
                this.Sacar(pValor);
                pConta.Depositar(pValor);
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }
        

        public abstract string exibirDadosConta();
    }
}
