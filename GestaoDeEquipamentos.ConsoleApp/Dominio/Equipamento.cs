using System;
using System.Security.Cryptography.X509Certificates;

namespace GestaoDeEquipamentos.ConsoleApp.dominio;

public class Equipamento
{
    public string id;
    public string nome;
    public string fabricante;
    public decimal precoAquisicao;
    public DateTime dataFabricacao;
}
