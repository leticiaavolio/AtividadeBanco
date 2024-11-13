using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LetiAvolio.PrjAtividadeBanco.models
{
    /// <summary>
    /// Representa uma conta especial, com limite adicional de crédito.
    /// </summary>
    public class ContaEspecial:Conta
    {
        private double _limite;

        public double Limite {
            get => _limite;
            set
            {
                if (value < 0)
                    throw new ArgumentException("O limite não pode ser negativo.");
                _limite = value;
            }
        }


        public ContaEspecial(string pTitular, string pNumeroConta, double pSaldo, double pLimite, DateOnly pDataNascimento, string pTipoConta, string pSenha)
        {
            Titular = pTitular;
            NumeroConta = pNumeroConta;
            Saldo = pSaldo;
            Limite = pLimite;
            DataNascimento = pDataNascimento;
            DataCriacaoConta = DateTime.Now;
            TipoConta = pTipoConta;
            Senha = pSenha;
        }


        /// <summary>
        /// Exibe os dados da conta especial.
        /// </summary>
        /// <returns>String com os dados da conta.</returns>
        public override string exibirDadosConta()
        {
            return $"#############################\n " +
                   $"Titular: {Titular}\n" +
                   $"Número da Conta: {NumeroConta}\n" +
                   $"Saldo: {Saldo}\n" +
                   $"Limite: {Limite}\n" +
                   $"Data de Criação: {DataCriacaoConta}\n" +
                   $"Data de Nascimento: {DataNascimento}\n" +
                   $"Tipo de Conta: {TipoConta}\n" +
                   $"#############################";
        }

        /// <summary>
        /// Realiza um saque na conta especial, validando se o valor é positivo e se há saldo ou limite disponível.
        /// </summary>
        /// <param name="valor">Valor a ser sacado.</param>
        public override string Sacar(double valor)
        {
            try
            {
                if (valor <= 0)
                {
                    throw new ArgumentException("O valor do saque deve ser maior que zero.");
                }
                // Valida se o saldo e o limite juntos são suficientes para o saque
                if (valor > Saldo + Limite)
                {
                    throw new InvalidOperationException("Saque não permitido. Valor maior que o saldo e limite.");
                }

                Saldo -= valor;
                return "Saque realizado com sucesso!";
            }
            catch (Exception ex)
            {
                return $"Erro ao sacar: {ex.Message}";
            }
        }
    }
}
