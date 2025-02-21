namespace Pokeliga.Api.Model
{
    public class PlayerHistoryResponse
    {
        public string PlayerNome { get; set; }
        public int TotalVitorias { get; set; }
        public int TotalDerrotas { get; set; }
        public int TotalEmpates { get; set; }
        public int TotalPartidas { get; set; }
        public string PlayerMaisPerdeuNome { get; set; }
        public int TotalDerrotasParaEssePlayer { get; set; }
        public string PlayerMaisGanhouNome { get; set; }
        public int TotalVitoriasDessePlayer { get; set; }
    }


}
