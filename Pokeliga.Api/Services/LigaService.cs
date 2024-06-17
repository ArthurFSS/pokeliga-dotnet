using Microsoft.EntityFrameworkCore;
using Pokeliga.Api.Entities;
using Pokeliga.Api.Infra;
using Pokeliga.Api.Interfaces;

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

        public async Task<IEnumerable<Resultados>> GetResultadoAsync(int idLiga)
        {
            return await _context.Resultados.Where(x => x.IdLiga == idLiga).OrderBy(x => x.Pontos).ToListAsync();
        }

        public async Task<IEnumerable<Standins>> GetStandinsAsync(int idLiga)
        {
            return await _context.Standins.Where(x => x.IdLiga == idLiga).OrderBy(x => x.Place).ToListAsync();
        }

        public async Task<IEnumerable<GlcBadges>> GetLigaGlcAsync(int idLiga)
        {
            return await _context.GlcBadges.ToListAsync();
        }
    }
}
