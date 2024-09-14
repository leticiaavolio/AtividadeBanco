using PrjAtividadeBanco.models;

ContaPoupanca poupanca = new ContaPoupanca();

Console.WriteLine("ano");
poupanca.DataDeAniversario = Convert.ToDateTime(Console.ReadLine());
Console.WriteLine($"{poupanca.DataDeAniversario}");