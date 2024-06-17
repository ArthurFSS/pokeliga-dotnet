namespace Pokeliga.Api.Entities
{
    public class Resultados
    {
        public int Id { get; set; }
        public required string Nome {  get; set; }
        public int IdPokemon { get; set; }
        public DateTime Data {  get; set; }
        public int Pontos { get; set; }
        public int IdLiga { get; set; }
    }
}
