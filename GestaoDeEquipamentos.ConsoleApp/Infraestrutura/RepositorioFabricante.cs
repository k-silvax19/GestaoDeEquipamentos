using System;

namespace GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp.Dominio;

public class RepositorioFabricante
{
    public Fabricantes?[] fabricantes = new Fabricantes[100];

    public void Cadastrar(Fabricantes novoFabricante)
    {
        novoFabricante.idFabricante = Convert
            .ToHexString(RandomNumberGenerator.GetBytes(20))
            .ToLower()
            .Substring(0, 7);

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricantes? F = fabricantes[i];

            if (F == null)
            {
                fabricantes[i] = novoFabricante;
                break;
            }
        }
    }

        public bool Editar(string idSelecionado, Fabricantes novoEquipamento)
        {
            Fabricantes? fabricanteSelecionado = SelecionarPorId(idSelecionado);

            if (fabricanteSelecionado == null)
                return false;

            fabricanteSelecionado.nomeFabricante = novoEquipamento.nomeFabricante;
            fabricanteSelecionado.email = novoEquipamento.email;
            fabricanteSelecionado.telefone = novoEquipamento.telefone;
            return true;
        }

        public bool Excluir(string idSelecionado)
        {
            for (int i = 0; i < fabricantes.Length; i++)
            {
                Fabricantes f = fabricantes[i];

                if (f == null)
                    continue;

                if (f.idFabricante == idSelecionado)
                {
                    fabricantes[i] = null;
                    return true;
                }
            }

            return false;
        }
  
        public Fabricantes? SelecionarPorId(string idSelecionado)
        {
            Fabricantes? equipamentoSelecionado = null;

            for (int i = 0; i < fabricantes.Length; i++)
            {
                Fabricantes? F = fabricantes[i];

                if (F == null)
                    continue;

                if (F.idFabricante == idSelecionado)
                {
                    equipamentoSelecionado = F;
                    break;
                }
            }

            return equipamentoSelecionado;
        }
   
    public Fabricantes?[] SelecionarTodos()
    {
        return fabricantes;
    }
}
