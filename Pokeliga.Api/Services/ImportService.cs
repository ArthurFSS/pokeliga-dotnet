using Microsoft.EntityFrameworkCore;
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

            var existingIdPokemons = await _context.Players
                .Where(p => request.Select(r => r.IdPokemon).Contains(p.IdPokemon))
                .Select(p => p.IdPokemon)
                .ToListAsync();

            var players = new List<Players>();

            foreach (var item in request)
            {
                if (!existingIdPokemons.Contains(item.IdPokemon))
                {
                    var player = new Players(item);
                    players.Add(player);
                }
            }

            _context.Players.AddRange(players);
            await _context.SaveChangesAsync();
        }

        public async Task ImportarStandins(List<StandinImportRequest> request)
        {
            var standins = new List<Standins>();

            foreach (var item in request)
            {
                var partidas = await _context.Partidas.Where(x => (x.Player1 == item.IdPokemon || x.Player2 == item.IdPokemon) && x.Data == item.Data).ToListAsync();
                var standin = new Standins(item);

                foreach (var partida in partidas)
                {
                    if ((partida.Player1 == item.IdPokemon && partida.Outcome == 1) || (partida.Player2 == item.IdPokemon && partida.Outcome == 2) || (partida.Outcome == 5))
                        standin.Vitorias = standin.Vitorias + 1;

                    if ((partida.Player1 == item.IdPokemon && partida.Outcome == 2) || (partida.Player2 == item.IdPokemon && partida.Outcome == 1))
                        standin.Derrotas = standin.Derrotas + 1;

                    if (partida.Outcome == 3)
                        standin.Empates = standin.Empates + 1;
                }

                standins.Add(standin);
            }

            _context.Standins.AddRange(standins);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarLiga(DateTime data, int idLiga)
        {
            var standins = await _context.Standins.Where(x => x.Data == data).ToListAsync();
            var ids = standins.Select(x => x.IdPokemon);
            var resultados = await _context.Resultados.Where(x => x.IdLiga == idLiga && ids.Contains(x.IdPokemon)).ToListAsync();
            var players = await _context.Players.Where(x => ids.Contains(x.IdPokemon)).ToListAsync();

            int pontosPorPresenca = 3;

            foreach (var item in standins)
            {
                var resultado = resultados.FirstOrDefault(x => x.IdPokemon == item.IdPokemon);

                if (resultado != null)
                {
                    resultado.Pontos = resultado.Pontos + item.Pontos + pontosPorPresenca;
                }
                else
                {
                    var player = players.FirstOrDefault(x => x.IdPokemon == item.IdPokemon);
                    var nome = player?.FirstName + " " + player?.LastName;

                    var novoResultado = new Resultados
                    {
                        IdLiga = idLiga,
                        Nome = nome,
                        Data = data,
                        IdPokemon = item.IdPokemon,
                        Pontos = item.Pontos + pontosPorPresenca
                    };
                    _context.Resultados.Add(novoResultado);
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
