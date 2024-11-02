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
            try
            {
                // Valida se o valor do saque é positivo
                if (valor <= 0)
                {
                    throw new ArgumentException("O valor do saque deve ser maior que zero.");
                }
                // Valida se o saldo é suficiente para o saque
                if (valor > this.Saldo)
                {
                    throw new InvalidOperationException("Saque não permitido. Valor maior que o saldo disponível.");
                }

                this.Saldo -= valor;
                Console.WriteLine("Saque realizado com sucesso!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro ao sacar: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Erro ao sacar: {ex.Message}");
            }
        }


        /// <summary>
        /// Realiza um depósito na conta.
        /// </summary>
        /// <param name="valor">Valor a ser depositado.</param>
        public void Depositar(double valor)
        {
            try
            {
                // Valida se o valor do depósito é positivo
                if (valor <= 0)
                {
                    throw new ArgumentException("O valor do depósito deve ser maior que zero.");
                }
                this.Saldo += valor;
                Console.WriteLine("Depósito realizado com sucesso!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro ao depositar: {ex.Message}");
            }
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
                // Valida se o valor da transferência é positivo
                if (pValor <= 0)
                {
                    throw new ArgumentException("O valor da transferência deve ser maior que zero.");
                }

                // Tenta realizar o saque e o depósito para a transferência
                this.Sacar(pValor);
                pConta.Depositar(pValor);
                Console.WriteLine("Transferência realizada com sucesso!");
                return true;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro na transferência: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Erro na transferência: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado na transferência: {ex.Message}");
            }
            return false;
        }


        /// <summary>
        /// Método abstrato para exibir os dados da conta, a ser implementado nas classes derivadas.
        /// </summary>
        /// <returns>Uma string com os dados da conta.</returns>
        public abstract string exibirDadosConta();
    }
}
