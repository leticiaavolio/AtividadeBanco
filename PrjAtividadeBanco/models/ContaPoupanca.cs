using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetiAvolio.PrjAtividadeBanco.models
{
    /// <summary>
    /// Representa uma conta poupança, com data de aniversário da conta.
    /// </summary>
    public class ContaPoupanca:Conta
    {
        public ContaPoupanca(string pTitular, string pNumeroConta, double pSaldo, DateOnly pDataNascimento, string pTipoConta, string pSenha)
        {
            Titular = pTitular;
            NumeroConta = pNumeroConta;
            Saldo = pSaldo;
            DataNascimento = pDataNascimento;
            DataCriacaoConta = DateTime.Now;
            TipoConta = pTipoConta;
            Senha = pSenha;
        }


        /// <summary>
        /// Exibe os dados da conta poupança.
        /// </summary>
        /// <returns>String com os dados da conta.</returns>
        public override string exibirDadosConta()
        {
            return $"#############################\n " +
                   $"Titular: {Titular}\n" +
                   $"Número da Conta: {NumeroConta}\n" +
                   $"Saldo: {Saldo}\n" +
                   $"Data de Criação: {DataCriacaoConta}\n" +
                   $"Data de Nascimento: {DataNascimento}\n" +
                   $"Tipo de Conta: {TipoConta}\n" +
                   $"#############################";
        }

    }
}
