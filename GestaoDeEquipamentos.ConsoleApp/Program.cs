using System.Security.Cryptography;

string id = Convert.ToHexString(RandomNumberGenerator.GetBytes(20))
    .ToLower()
    .Substring(0, 7);

Console.WriteLine(id);

while (true)
{
    Console.Clear();
    Console.WriteLine("---------------------------------");
    Console.WriteLine("Gestão de Equipamentos");
    Console.WriteLine("---------------------------------");
    Console.WriteLine("1 - Cadastrar equipamento");
    Console.WriteLine("2 - Editar equipamento");
    Console.WriteLine("3 - Excluir equipamento");
    Console.WriteLine("4 - Visualizar equipamentos");
    Console.WriteLine("S - Sair");
    Console.WriteLine("---------------------------------");
    Console.Write("> ");
    string? opcaoMenu = Console.ReadLine()?.ToUpper();

    if (opcaoMenu == "S")
    {
        Console.Clear();
        break;
    }

    if (opcaoMenu == "1")
    {

    }

    else if (opcaoMenu == "2")
    {

    }

    else if (opcaoMenu == "3")
    {

    }

    else if (opcaoMenu == "4")
    {

    }
}