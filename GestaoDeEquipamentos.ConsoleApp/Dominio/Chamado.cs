using System;
using GestaoDeEquipamentos.ConsoleApp.dominio;

namespace GestaoDeEquipamentos.ConsoleApp.Dominio.Chamado;

public class Chamado
{
    public string id;
    public string titulo;
    public string descricao;
    public DateTime DataAbertura;
    internal Equipamento equipamento;
    internal DateTime dataAbertura;
    
    public int ObterDiasDecorridos()
    {
        TimeSpan diferencaTempo = DateTime.Now.Subtract(dataAbertura);

        return diferencaTempo.Days;
    }
}