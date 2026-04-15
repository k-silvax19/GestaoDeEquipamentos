using GestaoDeEquipamentos.ConsoleApp.Apresentacao;
using GestaoDeEquipamentos.ConsoleApp.ApresentarMenu;
using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();
RepositorioChamado repositorioChamado = new RepositorioChamado();

RepositorioEquipamento rep = new RepositorioEquipamento();
RepositorioChamado repositorioChamado1 = new RepositorioChamado();

TelaEquipamento telaEquipamento = new TelaEquipamento();
telaEquipamento.repositorioEquipamento = repositorioEquipamento;

TelaChamado telaChamado = new TelaChamado();
telaChamado.repositorioChamado = repositorioChamado;
telaChamado.repositorioEquipamento = repositorioEquipamento;

TelaFabricante telaFabricante = new TelaFabricante();



while (true)
{
    Console.Clear();
    Console.WriteLine("---------------------------------");
    Console.WriteLine("Gestão de Equipamentos");
    Console.WriteLine("---------------------------------");
    Console.WriteLine("1 - Gerenciar Equipamentos");
    Console.WriteLine("2 - Gerenciar Chamados");
    Console.WriteLine("3 - Gerenciar Fabricantes");
    Console.WriteLine("S - Sair");
    Console.WriteLine("---------------------------------");
    Console.Write("> ");
    string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

    if (opcaoMenuPrincipal == "S")
        break;


    switch (opcaoMenuPrincipal)
    {
        case "1":

            string? opcaoMenu = telaEquipamento.ObterEscolhaMenuPrincipal();

            if (opcaoMenu == "S")
                break;

            switch (opcaoMenu)
            {
                case "1":
                    telaEquipamento.Cadastrar();
                    break;
                case "2":
                    telaEquipamento.Editar();
                    break;
                case "3":
                    telaEquipamento.Excluir();
                    break;
                case "4":
                    telaEquipamento.VisualizarTodos();
                    break;
            }

            break;

        case "2":
            {
                string? opcaoMenuChamado = telaChamado.ObterEscolhaMenuPrincipal();

                if (opcaoMenuChamado == "S")
                    break;

                if (opcaoMenuChamado == "1")
                    telaChamado.Cadastrar();

                else if (opcaoMenuChamado == "2")
                    telaChamado.Editar();

                else if (opcaoMenuChamado == "3")
                    telaChamado.Excluir();

                else if (opcaoMenuChamado == "4")
                    telaChamado.VisualizarTodos(deveExibirCabecalho: true);

                break;
            }
        case "3":
            {
                string? opcaoMenuFabricante = telaFabricante.ObterEscolhaMenuPrincipal();

                if (opcaoMenuFabricante == "S")
                    break;

                if (opcaoMenuFabricante == "1")
                    telaFabricante.Cadastrar();

                else if (opcaoMenuFabricante == "2")
                    telaFabricante.Editar();

                else if (opcaoMenuFabricante == "3")
                    telaFabricante.Excluir();

                else if (opcaoMenuFabricante == "4")
                    telaFabricante.VisualizarTodos(deveExibirCabecalho: true);

                else if (opcaoMenuFabricante == "5")
                    telaEquipamento.Cadastrar();

                break;
            }
    }
}
