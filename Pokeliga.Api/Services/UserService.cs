using Google.Apis.Auth;
using Microsoft.EntityFrameworkCore;
using Pokeliga.Api.Entities;
using Pokeliga.Api.Infra;
using Pokeliga.Api.Interfaces;

namespace Pokeliga.Api.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Login(string email)
        {
            var user = await _context.Players.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
                return false;

            return true;
        }

        public async Task<bool> CreateUser(GoogleJsonWebSignature.Payload payload, int iDPokemon, DateTime birthDate)
        {
            var user = await _context.Players.FirstOrDefaultAsync(x => x.IdPokemon == iDPokemon && x.Birthdate.Date == birthDate.Date);

            if (user == null)
                return false;
           
            user.Email = payload.Email;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
