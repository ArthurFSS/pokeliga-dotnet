using Pokeliga.Api.Model;
namespace Pokeliga.Api.Entities
{
    public class Players
    {
        public Players()
        {
            
        }

        public Players(PlayersImportRequest request)
        {
            IdPokemon = request.IdPokemon;
            FirstName = request.FirstName?.ToUpper();
            LastName = request.LastName?.ToUpper();
            Birthdate  = request.Birthdate;
        }

        public int Id { get; set; }
        public int IdPokemon { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string? Email { get; set; }
    }
}
