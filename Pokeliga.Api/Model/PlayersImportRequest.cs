namespace Pokeliga.Api.Model
{
    public class PlayersImportRequest
    {
        public int IdPokemon { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
