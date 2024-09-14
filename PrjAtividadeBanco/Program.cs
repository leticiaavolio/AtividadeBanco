using PrjAtividadeBanco.models;

ContaPoupanca poupanca = new ContaPoupanca();

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

Console.WriteLine($"#############################\n " +
    $"O nome do titular é: {especial.Titular}, " +
    $"o número de sua conta é: {especial.NumeroConta}, " +
    $"seu saldo atual é de: {especial.Saldo}, " +
    $"e seu limite disponível é: {especial.Limite}. " +
    $"\n#############################");

Console.WriteLine("POUPANÇA");
Console.WriteLine("Digite seu nome:");
poupanca.Titular = Console.ReadLine();
Console.WriteLine("Digite o número da sua conta:");
poupanca.NumeroConta = Console.ReadLine();
Console.WriteLine("Digite o saldo disponível na conta:");
poupanca.Saldo = Convert.ToDouble(Console.ReadLine());

Console.WriteLine($"#############################\n " +
    $"O nome do titular é: {poupanca.Titular}, " +
    $"o número de sua conta é: {poupanca.NumeroConta}, " +
    $"seu saldo atual é de: {poupanca.Saldo}, " +
    $"e sua data de aniversário é: {poupanca.DataDeAniversario}. " +
    $"\n#############################");