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
        private string _titular;
        private string _numeroConta;
        private double _saldo;
        private DateOnly _dataNascimento;
        private string _tipoConta;
        private string _senha;

        public string Titular {
            get => _titular;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("O nome do titular não pode ser vazio.");
                _titular = value;
            }
        }
        public string NumeroConta {
            get => _numeroConta;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 5)
                    throw new ArgumentException("O número da conta deve ter 5 caracteres.");
                _numeroConta = value;
            }
        }
        public double Saldo {
            get => _saldo;
            set
            {
                if (value < 0)
                    throw new ArgumentException("O saldo não pode ser negativo.");
                _saldo = value;
            }
        }

        /// <summary>Data de nascimento do correntista.</summary>
        public DateOnly DataNascimento {
            get => _dataNascimento;
            set
            {
                if (value > DateOnly.FromDateTime(DateTime.Now.AddYears(-18)))
                {
                    throw new ArgumentException("O titular deve ter no mínimo 18 anos.");
                }
                _dataNascimento = value;
            }
        }

        /// <summary>Data de criação da conta.</summary>
        public DateTime DataCriacaoConta {get; set;}

        /// <summary>Tipo da conta (ex: Poupança, Especial).</summary>
        public string TipoConta {
            get => _tipoConta;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("O tipo de conta não pode ser vazio.");
                _tipoConta = value;
            }
        }

        /// <summary>Senha de acesso da conta.</summary>
        public string Senha {
            get => _senha;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 8)
                    throw new ArgumentException("A senha deve ter no mínimo 8 caracteres.");
                _senha = value;
            }
        }


        /// <summary>
        /// Realiza um saque na conta.
        /// </summary>
        /// <param name="valor">Valor a ser sacado.</param>
        public virtual string Sacar(double valor)
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
                return "Saque realizado com sucesso!";
            }
            catch (ArgumentException ex)
            {
                return $"Erro ao sacar: {ex.Message}";
            }
            catch (InvalidOperationException ex)
            {
                return $"Erro ao sacar: {ex.Message}";
            }
        }


        /// <summary>
        /// Realiza um depósito na conta.
        /// </summary>
        /// <param name="valor">Valor a ser depositado.</param>
        public string Depositar(double valor)
        {
            try
            {
                // Valida se o valor do depósito é positivo
                if (valor <= 0)
                {
                    throw new ArgumentException("O valor do depósito deve ser maior que zero.");
                }
                this.Saldo += valor;
                return "Depósito realizado com sucesso!";
            }
            catch (ArgumentException ex)
            {
                return $"Erro ao depositar: {ex.Message}";
            }
        }


        /// <summary>
        /// Transfere um valor para outra conta.
        /// </summary>
        /// <param name="pConta">Conta de destino.</param>
        /// <param name="pValor">Valor a ser transferido.</param>
        /// <returns>Retorna verdadeiro se a transferência for bem-sucedida; caso contrário, falso.</returns>
        public string Transferir(Conta pConta, double pValor)
        {
            try
            {
                // Valida se o valor da transferência é positivo
                if (pValor <= 0)
                {
                    throw new ArgumentException("O valor da transferência deve ser maior que zero.");
                }

                // Tenta realizar o saque e o depósito para a transferência
                var saqueResultado = this.Sacar(pValor);
                if (saqueResultado.Contains("Erro"))
                {
                    return saqueResultado;
                }

                var depositoResultado = pConta.Depositar(pValor);
                if (depositoResultado.Contains("Erro"))
                {
                    return depositoResultado;
                }

                return "Transferência realizada com sucesso!";
            }
            catch (ArgumentException ex)
            {
                return $"Erro na transferência: {ex.Message}";
            }
            catch (InvalidOperationException ex)
            {
                return $"Erro na transferência: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Erro inesperado na transferência: {ex.Message}";
            }
        }


        /// <summary>
        /// Método abstrato para exibir os dados da conta, a ser implementado nas classes derivadas.
        /// </summary>
        /// <returns>Uma string com os dados da conta.</returns>
        public abstract string exibirDadosConta();

    }
}
