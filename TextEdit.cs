using System.IO;
internal class Program
{
    private static void Main(string[] args)
    {
        Menu();
    }
    static void Menu()
    {
        Console.Clear();
        Console.WriteLine($"Bem vindo ao editor de texto\nEscolha uma opção:");
        Console.WriteLine($"1 - Abrir arquivo\n2 - Criar novo arquivo\n0 - Sair");

        short option = short.Parse(Console.ReadLine());
        switch (option)
        {
            case 1: Open(); break;
            case 2: Edit(); break;
            case 0: Console.Clear(); System.Environment.Exit(0); break;
            default: Menu(); break;
        }
    }
    static void Open()
    {
        Console.Clear();
        Console.WriteLine("Qual caminho do arquivo?");
        string path = Console.ReadLine();

        using (var file = new StreamReader(path))
        {
            string text = file.ReadToEnd();
            Console.WriteLine($"\n{text}");
        }

        Console.WriteLine("");
        Console.ReadLine();
        Menu();
    }
    static void Edit()
    {
        Console.Clear();
        Console.WriteLine("Digite seu texto abaixo (ESC para sair):");
        Console.WriteLine("------------------------");
        string text = "";

        do
        {
            text += Console.ReadLine();
            text += Environment.NewLine;
        }
        while (Console.ReadKey().Key != ConsoleKey.Escape);

        Salve(text);

    }
    static void Salve(string text)
    {
        Console.Clear();
        Console.WriteLine("_Qual caminho para salvar o arquivo?");
        var path = Console.ReadLine();

        using (var file = new StreamWriter(path))
        {
            file.Write(text);
        }
        Console.WriteLine($"Aquivo {path} salvo com sucesso!");
        Thread.Sleep(3500);
        Menu();
    }
}