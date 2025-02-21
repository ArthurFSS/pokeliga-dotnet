namespace Pokeliga.Api.Model
{
    public class PlayerHistoryResponse
    {
        public string PlayerNome { get; set; }
        public int TotalVitorias { get; set; }
        public int TotalDerrotas { get; set; }
        public int TotalEmpates { get; set; }
        public int TotalPartidas { get; set; }
        public List<string> PlayersMaisPerderamNomes { get; set; } = new List<string>();
        public int TotalDerrotasParaEssesPlayers { get; set; }
        public List<string> PlayersMaisGanharamNomes { get; set; } = new List<string>();
        public int TotalVitoriasDessePlayers { get; set; }
    }
}
