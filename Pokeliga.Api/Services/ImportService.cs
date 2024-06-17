using Pokeliga.Api.Entities;
using Pokeliga.Api.Infra;
using Pokeliga.Api.Interfaces;
using Pokeliga.Api.Model;

namespace Pokeliga.Api.Services
{
    public class ImportService : IImportService
    {
        private readonly AppDbContext _context;

        public ImportService(AppDbContext context)
        {
            _context = context;
        }

        public async Task ImportarPartidas(List<PartidaImportRequest> request)
        {
            var partidas = new List<Partidas>();

            foreach (var item in request)
            {
                var partida = new Partidas(item);
                partidas.Add(partida);
            }

            _context.Partidas.AddRange(partidas);
            await _context.SaveChangesAsync();
        }


        public async Task ImportarJogadores(List<PlayersImportRequest> request)
        {
            var players = new List<Players>();

            foreach (var item in request)
            {
                var player = new Players(item);
                players.Add(player);
            }

            _context.Players.AddRange(players);
            await _context.SaveChangesAsync();
        }

        public async Task ImportarStandins(List<StandinImportRequest> request)
        {
            var standins = new List<Standins>();

            foreach (var item in request)
            {
                var standin = new Standins(item);
                standins.Add(standin);
            }

            _context.Standins.AddRange(standins);
            await _context.SaveChangesAsync();
        }

    }
}
