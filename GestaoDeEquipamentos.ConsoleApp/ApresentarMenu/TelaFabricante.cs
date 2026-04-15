using System;
using System.Diagnostics.Tracing;
using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

namespace GestaoDeEquipamentos.ConsoleApp.ApresentarMenu;

public class TelaFabricante
{
    public string? ObterEscolhaMenuPrincipal()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Fabricantes");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Cadastrar Fabricantes");
        Console.WriteLine("2 - Editar Fabricantes");
        Console.WriteLine("3 - Excluir Fabricantes");
        Console.WriteLine("4 - Visualizar Fabricantes");
        Console.WriteLine("5 - Cadastrar novos equipamentos");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenuFabricante = Console.ReadLine()?.ToUpper();

        return opcaoMenuFabricante;
    }
    RepositorioFabricante repositorioFabricante = new RepositorioFabricante();

    public void Cadastrar()
    {

        ExibirCabecalho("Cadastro de Fabricante");


        Fabricantes? novoFabricante = ObterDadosCadastrais();

        repositorioFabricante.Cadastrar(novoFabricante);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro \"{novoFabricante.idFabricante}\" foi cadastrado com sucesso.");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    public void Editar()
    {
        ExibirCabecalho("Edição de Fabricante");

        VisualizarTodos(deveExibirCabecalho: false);

        Console.WriteLine("---------------------------------");

        string? idSelecionado;

        do
        {
            Console.Write("Digite o id do fabricante que deseja editar: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        } while (true);

        Fabricantes? novoFabricante = ObterDadosCadastrais();

        if (novoFabricante == null)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Não foi possível obter os dados do registro.");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        }

        bool conseguiuEditar = repositorioFabricante.Editar(idSelecionado, novoFabricante);

        if (!conseguiuEditar)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Não foi possível encontrar o registro informado.");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro \"{idSelecionado}\" foi editado com sucesso.");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    public void Excluir()
    {
        ExibirCabecalho("Exclusão de Fabricante");

        VisualizarTodos(deveExibirCabecalho: false);

        Console.WriteLine("---------------------------------");

        string? idSelecionado;

        do
        {
            Console.Write("Digite o id do chamado que deseja excluir: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        } while (true);

        bool conseguiuExcluir = repositorioFabricante.Excluir(idSelecionado);

        if (!conseguiuExcluir)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Não foi possível encontar o registro informado.");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro \"{idSelecionado}\" foi excluído com sucesso.");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    public void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de Fabricantes");

        Console.WriteLine(
            "{0, -7} | {1, -10} | {2, -30} | {3, -22}",
            "Id", "Nome", "Email", "Telefone"
        );

        Fabricantes?[] fabricantes = repositorioFabricante.SelecionarTodos();

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricantes? f = fabricantes[i];

            if (f == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -10} | {2, -20} | {3, -22}",
                f.idFabricante, f.nomeFabricante, f.email, f.telefone
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    public Fabricantes? ObterDadosCadastrais()
    {

        Fabricantes novoFabricante = new Fabricantes();

        do
        {
            Console.Write("Digite o nome do fabricante: ");
            novoFabricante.nomeFabricante = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoFabricante.nomeFabricante) &&
                novoFabricante.nomeFabricante.Length >= 3)
            {
                break;
            }

        } while (true);


        Console.Write("Digite o email do fabricante: ");
        novoFabricante.email = Console.ReadLine();

        Console.Write("Digite o telefone do fabricante: ");
        novoFabricante.telefone = Convert.ToDecimal(Console.ReadLine());

        return novoFabricante;
    }

    public void ExibirCabecalho(string titulo)
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Fabricantes");
        Console.WriteLine("---------------------------------");
        Console.WriteLine(titulo);
        Console.WriteLine("---------------------------------");
    }
}
