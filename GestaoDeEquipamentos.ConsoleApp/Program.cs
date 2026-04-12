using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using GestaoDeEquipamentos.ConsoleApp.ApresentarMenu;
using GestaoDeEquipamentos.ConsoleApp.dominio;

ApresentarMenu menu = new ApresentarMenu();
while (true)
{
    string? opcaoMenu = menu.MenuInical();

    if (opcaoMenu == "S")
        break;

    switch (opcaoMenu)
    {
        case "1":
            {
                menu.Cadastrar();
                break;
            }
        case "2":
            {
                menu.EditarEquipamentos();
                break;
            }
        case "3":
            {
                menu.ExcluirEquimentos();
                break;
            }   

        case "4":
            {
                menu.VisualizarEquipamentos();
                break;
            }

        default:
            Console.WriteLine("Opção invalida digite novamente!");
            break;
    }
}