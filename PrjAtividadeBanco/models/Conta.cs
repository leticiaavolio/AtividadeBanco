using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetiAvolio.PrjAtividadeBanco.models
{
    /// <summary>
    /// Representa uma conta bancária genérica.
    /// Classe base para outras contas, como ContaEspecial e ContaPoupanca.
    /// </summary>
    public abstract class Conta
    {
        public string Titular { get; set; }
        public string NumeroConta { get; set; }
        public double Saldo { get; set; }

        /// <summary>Data de nascimento do correntista.</summary>
        public DateOnly DataNascimento { get; set; }

        /// <summary>Data de criação da conta.</summary>
        public DateTime DataCriacaoConta { get; set; }

        /// <summary>Tipo da conta (ex: Poupança, Especial).</summary>
        public string TipoConta { get; set; }

        /// <summary>Senha de acesso da conta.</summary>
        public string Senha { get; set; }


        /// <summary>
        /// Realiza um saque na conta.
        /// </summary>
        /// <param name="valor">Valor a ser sacado.</param>
        public virtual void Sacar(double valor)
        {
            if (valor > Saldo)
            {
                throw new InvalidOperationException("#############################\n Saque não permitido. Valor maior que o saldo.\n#############################");
            }
            Saldo -= valor;
        }


        /// <summary>
        /// Realiza um depósito na conta.
        /// </summary>
        /// <param name="valor">Valor a ser depositado.</param>
        public void Depositar(double valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("#############################\n Valor do depósito deve ser maior que zero.\n#############################");
            }
            Saldo += valor;
        }


        /// <summary>
        /// Transfere um valor para outra conta.
        /// </summary>
        /// <param name="pConta">Conta de destino.</param>
        /// <param name="pValor">Valor a ser transferido.</param>
        /// <returns>Retorna verdadeiro se a transferência for bem-sucedida; caso contrário, falso.</returns>
        public bool Transferir(Conta pConta, double pValor)
        {
            try
            {
                Sacar(pValor);
                pConta.Depositar(pValor);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// Método abstrato para exibir os dados da conta, a ser implementado nas classes derivadas.
        /// </summary>
        /// <returns>Uma string com os dados da conta.</returns>
        public abstract string exibirDadosConta();
    }
}
