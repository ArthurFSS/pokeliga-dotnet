using Microsoft.EntityFrameworkCore;
using Pokeliga.Api.Entities;
using Pokeliga.Api.Infra;
using Pokeliga.Api.Interfaces;
using Pokeliga.Api.Model;

namespace Pokeliga.Api.Services
{
    public class LigaService : ILigaService
    {
        private readonly AppDbContext _context;

        public LigaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ligas>> GetLigasAsync()
        {
            return await _context.Ligas.OrderByDescending(x => x.DataInicio).ToListAsync();
        }

        public async Task<IEnumerable<Ligas>> GetLigasAsync(bool ativa, int idLoja = 0)
        {
            return await _context.Ligas.Where(x => x.Finalizada == ativa).OrderByDescending(x => x.DataInicio).ToListAsync();
        }

        public async Task<IEnumerable<ResultadosResponse>> GetResultadoAsync(int idLiga)
        {
            List<Resultados> resultados = await _context.Resultados
                .Where(x => x.IdLiga == idLiga)
                .OrderByDescending(x => x.Pontos)
                .ToListAsync();

            var standins = _context.Standins.Where(x => x.IdLiga == idLiga);
            
            var resultadosResponse = resultados
                .Select((resultado, index) => new ResultadosResponse
                {
                    Posicao = index + 1,
                    Id = resultado.Id,
                    Nome = resultado.Nome,
                    IdPokemon = resultado.IdPokemon,
                    Data = resultado.Data,
                    Pontos = resultado.Pontos,
                    IdLiga = resultado.IdLiga,
                    History = standins.Where(x => x.IdPokemon == resultado.IdPokemon).ToList(),
                })
                .ToList();

            return resultadosResponse;
        }

        public async Task<IEnumerable<StandinsEvento>> GetStandinsAsync(int idLiga)
        {
            var standins = await _context.Standins
                .Where(x => x.IdLiga == idLiga)
                .OrderBy(x => x.Place)
                .ToListAsync();

            var ids = standins.Select(x => x.IdPokemon);

            var players = await _context.Players
                .Where(x => ids.Contains(x.IdPokemon))
                .ToListAsync();

            var standinsAgrupados = standins
                                    .GroupBy(x => new { x.Categoria, x.Data })
                                    .ToList();

            var standinsEventoList = new List<StandinsEvento>();

            foreach (var grupo in standinsAgrupados)
            {
                var responses = new List<StandinsResponse>();

                foreach (var item in grupo)
                {
                    var player = players.FirstOrDefault(x => x.IdPokemon == item.IdPokemon);

                    var response = new StandinsResponse
                    {
                        Id = item.Id,
                        Categoria = item.Categoria,
                        Data = item.Data,
                        Derrotas = item.Derrotas,
                        Empates = item.Empates,
                        IdLiga = item.IdLiga,
                        IdPokemon = item.IdPokemon,
                        Nome = player?.FirstName + " " + player?.LastName,
                        Place = item.Place,
                        Vitorias = item.Vitorias,
                    };
                    responses.Add(response);
                }

                var standinsEvento = new StandinsEvento
                {
                    Categoria = grupo.FirstOrDefault().Categoria.ToString(),
                    Standins = responses
                };

                standinsEventoList.Add(standinsEvento);
            }

            return standinsEventoList.OrderByDescending(x => x.Data);
        }

        public async Task<IEnumerable<GlcBadges>> GetLigaGlcAsync(int idLiga)
        {
            return await _context.GlcBadges.ToListAsync();
        }

        public async Task<PremiacaoResponse> GetCaixa(int idLiga)
        {
            var quantidadeJogadores = _context.Standins.Where(x => x.IdLiga == idLiga).Count();
       
            var valor = (await _context.Ligas.FirstOrDefaultAsync(x => x.Id == idLiga)).ValorCaixaIndividual;

            var total = quantidadeJogadores * valor;

            return new PremiacaoResponse(total);
        }

        public async Task<PlayerHistoryResponse> GetPlayerHistory(int pokeId)
        {
            // Obter o nome do jogador pesquisado
            var playerBuscado = await _context.Players
                .FirstOrDefaultAsync(p => p.IdPokemon == pokeId);

            var resultados = await _context.Partidas
                .Where(x => x.Player1 == pokeId || x.Player2 == pokeId)
                .ToListAsync();

            var totalPartidas = resultados.Count;

            var totalVitorias = resultados.Count(x =>
                (x.Player1 == pokeId && x.Outcome == 1) ||
                (x.Player2 == pokeId && x.Outcome == 2)
            );

            var totalDerrotas = resultados.Count(x =>
                (x.Player1 == pokeId && x.Outcome == 2) ||
                (x.Player2 == pokeId && x.Outcome == 1)
            );

            var totalEmpates = resultados.Count(x => x.Outcome == 3);

            // Jogadores que mais perderam para ele (Ele venceu)
            var playersMaisPerderam = resultados
                .Where(x =>
                    (x.Player1 == pokeId && x.Outcome == 1) ||
                    (x.Player2 == pokeId && x.Outcome == 2)
                )
                .Select(x => x.Player1 == pokeId ? x.Player2 : x.Player1)
                .GroupBy(player => player)
                .Select(g => new { Player = g.Key, Derrotas = g.Count() })
                .OrderByDescending(x => x.Derrotas)
                .ToList();

            var maxDerrotas = playersMaisPerderam.FirstOrDefault()?.Derrotas ?? 0;
            var playersMaisPerderamEmpatados = playersMaisPerderam
                .Where(x => x.Derrotas == maxDerrotas)
                .ToList();

            var playersMaisPerderamNomes = await _context.Players
                .Where(p => playersMaisPerderamEmpatados.Select(x => x.Player).Contains(p.IdPokemon))
                .Select(p => $"{p.FirstName} {p.LastName}")
                .ToListAsync();

            // Jogadores que mais ganharam dele (Ele perdeu)
            var playersMaisGanharam = resultados
                .Where(x =>
                    (x.Player1 == pokeId && x.Outcome == 2) ||
                    (x.Player2 == pokeId && x.Outcome == 1)
                )
                .Select(x => x.Player1 == pokeId ? x.Player2 : x.Player1)
                .GroupBy(player => player)
                .Select(g => new { Player = g.Key, Vitorias = g.Count() })
                .OrderByDescending(x => x.Vitorias)
                .ToList();

            var maxVitorias = playersMaisGanharam.FirstOrDefault()?.Vitorias ?? 0;
            var playersMaisGanharamEmpatados = playersMaisGanharam
                .Where(x => x.Vitorias == maxVitorias)
                .ToList();

            var playersMaisGanharamNomes = await _context.Players
                .Where(p => playersMaisGanharamEmpatados.Select(x => x.Player).Contains(p.IdPokemon))
                .Select(p => $"{p.FirstName} {p.LastName}")
                .ToListAsync();

            return new PlayerHistoryResponse
            {
                PlayerNome = playerBuscado != null ? $"{playerBuscado.FirstName} {playerBuscado.LastName}" : "Desconhecido",
                TotalVitorias = totalVitorias,
                TotalDerrotas = totalDerrotas,
                TotalEmpates = totalEmpates,
                TotalPartidas = totalPartidas,
                PlayersMaisPerderamNomes = playersMaisPerderamNomes,
                TotalDerrotasParaEssesPlayers = maxDerrotas,
                PlayersMaisGanharamNomes = playersMaisGanharamNomes,
                TotalVitoriasDessePlayers = maxVitorias
            };
        }




    }
}
