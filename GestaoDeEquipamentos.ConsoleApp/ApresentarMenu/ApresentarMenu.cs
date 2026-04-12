using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp.dominio;
using GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

namespace GestaoDeEquipamentos.ConsoleApp.ApresentarMenu;

public class ApresentarMenu
{
    public RepositorioEquipamento repositorio = new RepositorioEquipamento();
    public string? MenuInical()
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

        return opcaoMenu;
    }

    public void Cadastrar()
    {

        Equipamento novoEquipamento = new Equipamento();

        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Cadastrar Equipamento");

        do
        {
            Console.Write("Digite o nome do equipamento: ");
            novoEquipamento.nome = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoEquipamento.nome) &&
                novoEquipamento.nome.Length >= 3)
            {
                break;
            }

        } while (true);
        
        do
        {
            Console.Write("Digite o nome do fabricante: ");
            novoEquipamento.fabricante = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoEquipamento.fabricante) && novoEquipamento.fabricante.Length >= 2)
            {
                break;
            }

        } while (true);

        Console.Write("Digite o Preço De Aquisição: ");
        novoEquipamento.precoAquisicao = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Digite a data da fabricação: ");
        novoEquipamento.dataFabricacao = Convert.ToDateTime(Console.ReadLine());

        Equipamento?[] equipamentos = repositorio.SelecionarTodos();

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento? e = equipamentos[i];

            if (e == null)
            {
                equipamentos[i] = novoEquipamento;
                break;
            }
        }

        repositorio.Cadastrar(novoEquipamento);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O \"{novoEquipamento.nome}\" foi castrado com sucesso e o ID e: {novoEquipamento.id}");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Aperte ENTER para voltar");
        Console.ReadLine();
    }

    public void EditarEquipamentos()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Editar equipamento");

        Console.WriteLine("{0,-7} | {1,-15} | {2,-15} | {3,-22} | {4,-10}",
     "ID", "NOME", "FABRICANTE", "PREÇO DE AQUISIÇÃO", "DATA DE FABRICAÇÃO");

        Equipamento?[] equipamentos = repositorio.SelecionarTodos();

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento? e = equipamentos[i];

            if (e == null)
            {
                continue;
            }

            Console.WriteLine("{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
            e.id, e.nome, e.fabricante, e.precoAquisicao.ToString("C2"), e.dataFabricacao.ToShortDateString());
        }

        string? idSelecionado;
        do
        {
            Console.Write("Digite o ID do equipamento que deseja editar: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrEmpty(idSelecionado) && idSelecionado.Length == 7)
                break;

        } while (true);

        Equipamento novoEquipamento = new Equipamento();
        do
        {
            Console.Write("Digite o nome do equipamento: ");
            novoEquipamento.nome = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoEquipamento.nome) && novoEquipamento.nome.Length >= 3)
            {
                break;
            }

        } while (true);

        do
        {
            Console.Write("Digite o nome do fabricante: ");
            novoEquipamento.fabricante = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoEquipamento.fabricante) && novoEquipamento.fabricante.Length >= 2)
            {
                break;
            }

        } while (true);

        Console.Write("Digite o Preço De Aquisição: ");
        novoEquipamento.precoAquisicao = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Digite a data da fabricação: ");
        novoEquipamento.dataFabricacao = Convert.ToDateTime(Console.ReadLine());

        bool conseguiuEditar = repositorio.Editar(idSelecionado, novoEquipamento);


        if (!conseguiuEditar)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Não foi possivel encontrar o equipamento informado.");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Aperte ENTER para voltar");
            Console.ReadLine();

        }

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O \"{idSelecionado}\" foi editado com sucesso!.");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Aperte ENTER para voltar");
        Console.ReadLine();

    }

    public void ExcluirEquimentos()
    {
        Equipamento?[] equipamentos = repositorio.SelecionarTodos();

        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Excluir Equipamento");

        Console.WriteLine("{0,-7} | {1,-15} | {2,-15} | {3,-22} | {4,-10}",
                   "ID", "NOME", "FABRICANTE", "PREÇO DE AQUISIÇÃO", "DATA DE FABRICAÇÃO");


        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento? e = equipamentos[i];

            if (e == null)
            {
                continue;
            }

            Console.WriteLine("{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
            e.id, e.nome, e.fabricante, e.precoAquisicao.ToString("C2"), e.dataFabricacao.ToShortDateString());
        }

        string? idSelecionado;
        do
        {
            Console.Write("Digite o ID do equipamento que deseja excluir: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrEmpty(idSelecionado) && idSelecionado.Length == 7)
                break;

        } while (true);

        bool conseguiuExcluir = repositorio.Excluir(idSelecionado);

        if (conseguiuExcluir)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"O \"{idSelecionado}\" foi excluido com sucesso!.");
            Console.WriteLine("---------------------------------");
        }
        else
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Não foi possivel encontrar o registro do equipamento.");
            Console.WriteLine("---------------------------------");
        }

        Console.WriteLine("Aperte ENTER para voltar");
        Console.ReadLine();

    }

    public void VisualizarEquipamentos()
    {

        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Visualizar equipamentos");

        Console.WriteLine("{0,-7} | {1,-15} | {2,-15} | {3,-22} | {4,-10}",
        "ID", "NOME", "FABRICANTE", "PREÇO DE AQUISIÇÃO", "DATA DE FABRICAÇÃO");

        Equipamento?[] equipamentos = repositorio.SelecionarTodos();

        for (int i = 0; i < repositorio.equipamentos.Length; i++)
        {
            Equipamento? e = equipamentos[i];

            if (e == null)
            {
                continue;
            }

            Console.WriteLine("{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
            e.id, e.nome, e.fabricante, e.precoAquisicao.ToString("C2"), e.dataFabricacao.ToShortDateString());
        }

        Console.WriteLine("Aperte ENTER para voltar");
        Console.ReadLine();

    }
}