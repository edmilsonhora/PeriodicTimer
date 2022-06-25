
using Console_PeriodicTimer;

Console.WriteLine("Pressione qualquer Tecla para iniciar operação!");
Console.ReadKey();

var operacao = new Operacao(TimeSpan.FromMilliseconds(1000));
operacao.Start();

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Pressione qualquer Tecla para encerrar operação!");
Console.ForegroundColor = ConsoleColor.Green;
Console.ReadKey();
Console.Clear();
operacao.StopAsync();
