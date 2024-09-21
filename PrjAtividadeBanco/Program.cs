using PrjAtividadeBanco.models;
using System.Runtime.CompilerServices;

Console.WriteLine("ESPECIAL");
Console.WriteLine("Digite seu nome:");
string pTitular = Console.ReadLine();
Console.WriteLine("Digite o número da sua conta:");
string pNumeroConta =  Console.ReadLine();
Console.WriteLine("Digite o saldo disponível na conta:");
double pSaldo = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Digite o limite na conta:");
double pLimite = Convert.ToDouble(Console.ReadLine());


ContaEspecial especial = new ContaEspecial(pTitular, pNumeroConta, pSaldo, pLimite);
Console.WriteLine(especial.exibirDadosConta());
try
{
    Console.WriteLine("Digite o valor a ser sacado: ");
    especial.Sacar(Convert.ToDouble(Console.ReadLine()));
    Console.WriteLine($"#############################\n Saque na Conta Especial realizado.\n#############################");

    Console.WriteLine("Digite o valor a ser depositado: ");
    especial.Depositar(Convert.ToDouble(Console.ReadLine()));
    Console.WriteLine($"#############################\n Valor Depositado. \n#############################");
    Console.WriteLine(especial.exibirDadosPosOperacao());
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

ContaPoupanca poupanca = new ContaPoupanca();

Console.WriteLine("POUPANÇA");
Console.WriteLine("Digite seu nome:");
poupanca.Titular = Console.ReadLine();
Console.WriteLine("Digite o número da sua conta:");
poupanca.NumeroConta = Console.ReadLine();
Console.WriteLine("Digite o saldo disponível na conta:");
poupanca.Saldo = Convert.ToDouble(Console.ReadLine());
Console.WriteLine(poupanca.exibirDadosConta());

try
{
    Console.WriteLine("Digite o valor a ser sacado: ");
    poupanca.Sacar(Convert.ToDouble(Console.ReadLine()));
    Console.WriteLine($"#############################\n Saque na Conta Poupança realizado. \n#############################");

    Console.WriteLine("Digite o valor a ser depositado: ");
    poupanca.Depositar(Convert.ToDouble(Console.ReadLine()));
    Console.WriteLine($"#############################\n Valor Depositado. \n#############################");
    Console.WriteLine(poupanca.exibirDadosPosOperacao());
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}