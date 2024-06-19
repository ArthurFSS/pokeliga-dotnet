using Pokeliga.Api.Entities.Enun;
using Pokeliga.Api.Model;

namespace Pokeliga.Api.Entities
{
    public class Standins
    {
        public Standins()
        {
            
        }

        public Standins(StandinImportRequest request)
        {
            Place = request.Place;
            Categoria = request.Categoria;
            Data = request.Data;
            IdLiga = request.IdLiga;
            IdPokemon = request.IdPokemon;
        }

        public int Id { get; set; }
        public int Place {  get; set; }
        public ECategoria Categoria { get; set; }
        public DateTime Data {  get; set; }
        public int IdLiga { get; set; }
        public int IdPokemon {  get; set; }
        public int Vitorias { get; set; }
        public int Derrotas { get; set; }
        public int Empates { get; set; }
        public int Pontos => (this.Vitorias * 3) + this.Empates; 
    }
}
