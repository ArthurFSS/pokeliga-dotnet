using Pokeliga.Api.Entities.Enun;

namespace Pokeliga.Api.Model
{
    public class StandinImportRequest
    {
        public int Id { get; set; }
        public int Place { get; set; }
        public ECategoria Categoria { get; set; }
        public DateTime Data { get; set; }
        public int IdLiga { get; set; }
        public int IdPokemon { get; set; }
    }
}
