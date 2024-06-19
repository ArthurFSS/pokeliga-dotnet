using Pokeliga.Api.Entities.Enun;

namespace Pokeliga.Api.Model
{
    public class StandinsResponse
    {
        public int Id { get; set; }
        public int Place { get; set; }
        public ECategoria Categoria { get; set; }
        public DateTime Data { get; set; }
        public int IdLiga { get; set; }
        public int IdPokemon { get; set; }
        public int Vitorias { get; set; }
        public int Derrotas { get; set; }
        public int Empates { get; set; }
        public int Pontos => Vitorias * 3 + Empates;
        public string Nome { get; set; } = string.Empty;
    }

    public class StandinsEvento
    {
        public List<StandinsResponse> Standins { get; set; }
        public string Categoria { get; set; }
        public DateTime Data => Standins.FirstOrDefault().Data;
        public int Participantes => Standins.Count;
        public string Vencedor => Standins.FirstOrDefault(x => x.Place == 1).Nome;
    }
}
