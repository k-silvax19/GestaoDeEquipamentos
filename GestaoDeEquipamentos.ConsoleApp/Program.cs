using GestaoDeEquipamentos.ConsoleApp.Apresentacao;
using GestaoDeEquipamentos.ConsoleApp.ApresentarMenu;
using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();
RepositorioChamado repositorioChamado = new RepositorioChamado();

ApresentarMenu menu = new ApresentarMenu();
menu.repositorioEquipamento = repositorioEquipamento;

TelaChamado telaChamado = new TelaChamado();
telaChamado.repositorioChamado = repositorioChamado;
telaChamado.repositorioEquipamento = repositorioEquipamento;

// Dados teste
Equipamento equipamento = new Equipamento();
equipamento.nome = "Notebook";
equipamento.fabricante = "Acer";
equipamento.precoAquisicao = 2000;
equipamento.dataFabricacao = DateTime.Now.AddYears(-5);

Equipamento equipamento2 = new Equipamento();
equipamento2.nome = "Monitor";
equipamento2.fabricante = "LG";
equipamento2.precoAquisicao = 1200;
equipamento2.dataFabricacao = DateTime.Now.AddYears(-4);

repositorioEquipamento.Cadastrar(equipamento);
repositorioEquipamento.Cadastrar(equipamento2);

Chamado chamado = new Chamado();
chamado.titulo = "Quebrou o display";
chamado.descricao = "Está com deadpixel";
chamado.dataAbertura = DateTime.Now.AddDays(-7);
chamado.equipamento = equipamento;

repositorioChamado.Cadastrar(chamado);

while (true)
{
    Console.Clear();
    Console.WriteLine("---------------------------------");
    Console.WriteLine("Gestão de Equipamentos");
    Console.WriteLine("---------------------------------");
    Console.WriteLine("1 - Gerenciar Equipamentos");
    Console.WriteLine("2 - Gerenciar Chamados");
    Console.WriteLine("S - Sair");
    Console.WriteLine("---------------------------------");
    Console.Write("> ");
    string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

    if (opcaoMenuPrincipal == "S")
        break;


    switch (opcaoMenuPrincipal)
    {
        case "1":

            string? opcaoMenu = menu.ObterEscolhaMenuPrincipal();

            if (opcaoMenu == "S")
                break;

            switch (opcaoMenu)
            {
                case "1":
                    menu.Cadastrar();
                    break;
                case "2":
                    menu.Editar();
                    break;
                case "3":
                    menu.Excluir();
                    break;
                case "4":
                    menu.VisualizarTodos();
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
    }
}
