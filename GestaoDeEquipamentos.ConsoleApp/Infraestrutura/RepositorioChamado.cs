using System;
using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp.dominio;
using GestaoDeEquipamentos.ConsoleApp.Dominio.Chamado;

namespace GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

public class RepositorioChamado
{
    public Chamado?[] chamados = new Chamado[100];

    public void Cadastrar(Chamado NovoChamado)
    {
        NovoChamado.id = Convert
                   .ToHexString(RandomNumberGenerator.GetBytes(20))
                   .ToLower()
                   .Substring(0, 7);

        for (int i = 0; i < chamados.Length; i++)
        {
            Chamado? c = chamados[i];

            if (c == null)
            {
                chamados[i] = NovoChamado;
                break;
            }
        }
    }

    public Chamado?[] SelecionarTodos()
    {
        return chamados;
    }
}
