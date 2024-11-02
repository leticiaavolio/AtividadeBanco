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
        public double Limite { get; set; }


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
        public override void Sacar(double valor)
        {
            try
            {
                // Valida se o saldo e o limite juntos são suficientes para o saque
                if (valor > Saldo + Limite)
                {
                    throw new InvalidOperationException("#############################\n Saque não permitido. Valor maior que o saldo e limite.\n#############################");
                }
                Saldo -= valor;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
