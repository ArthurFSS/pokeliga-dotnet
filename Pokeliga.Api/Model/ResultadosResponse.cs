using Pokeliga.Api.Entities;

namespace Pokeliga.Api.Model
{
    public class ResultadosResponse
    {
        public int Posicao { get; set; }
        public int Id { get; set; }
        public required string Nome { get; set; }
        public int IdPokemon { get; set; }
        public DateTime Data { get; set; }
        public int Pontos { get; set; }
        public int IdLiga { get; set; }
        public List<Standins>? History {get;set;}
    }

}
