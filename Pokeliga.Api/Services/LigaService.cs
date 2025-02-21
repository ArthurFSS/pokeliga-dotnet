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
    }
}
