using Google.Apis.Auth;

namespace Pokeliga.Api.Interfaces
{
    public interface IUserService
    {
        Task<bool> Login(string email);
        Task<bool> CreateUser(GoogleJsonWebSignature.Payload payload, int iDPokemon, DateTime birthDate);
    }
}
