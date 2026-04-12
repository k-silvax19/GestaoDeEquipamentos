using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using GestaoDeEquipamentos.ConsoleApp.ApresentarMenu;
using GestaoDeEquipamentos.ConsoleApp.dominio;
Equipamento[] equipamentos = new Equipamento[190];
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
                menu.Cadastrar(equipamentos);
                break;
            }
        case "2":
            {
                menu.EditarEquipamentos(equipamentos);
                break;
            }
        case "3":
            {
                menu.ExcluirEquimentos(equipamentos);
                break;
            }   

        case "4":
            {
                menu.VisualizarEquipamentos(equipamentos);
                break;
            }

        default:
            Console.WriteLine("Opção invalida digite novamente!");
            break;
    }
}