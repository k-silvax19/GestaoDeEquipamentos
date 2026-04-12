using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using GestaoDeEquipamentos.ConsoleApp.ApresentarMenu;
using GestaoDeEquipamentos.ConsoleApp.dominio;
using GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();
RepositorioChamado repositorioChamado = new RepositorioChamado();

ApresentarMenu telaEquipamento = new ApresentarMenu();
telaEquipamento.repositorio = repositorioEquipamento;

TelaChamado telaChamado = new TelaChamado();
telaChamado.repositorioChamado = repositorioChamado;
telaChamado.repositorioEquipamento = repositorioEquipamento;

ApresentarMenu menu = new ApresentarMenu();

while (true)
{
    Console.Clear();
    Console.WriteLine("---------------------------------");
    Console.WriteLine("Gestão de Equipamentos");
    Console.WriteLine("---------------------------------");
    Console.WriteLine("1 - Gerenciar EquipamentoS");
    Console.WriteLine("2 - Gerenciar Chamados");
    Console.WriteLine("S - Sair");
    Console.WriteLine("---------------------------------");
    Console.Write("> ");
    string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

    if (opcaoMenuPrincipal == "S")
        break;
    while (true)
    {
        string? opcaoMenu = menu.MenuInical();

        if (opcaoMenu == "S")
            break;

        switch (opcaoMenuPrincipal)
        {
            case "1":
                {
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
                    break;
                }
            case "2":
                {
                    telaChamado.MenuInical();

                    if (opcaoMenu == "S")
                    {
                        Console.Clear();
                        break;
                    }

                    if (opcaoMenu == "1")
                        telaChamado.Cadastrar();

                    else if (opcaoMenu == "2")
                        telaChamado.Editar();

                    else if (opcaoMenu == "3")
                        telaChamado.Excluir();

                    else if (opcaoMenu == "4")
                        telaChamado.VisualizarTodos();
                    break;
                }
        }
    }
}