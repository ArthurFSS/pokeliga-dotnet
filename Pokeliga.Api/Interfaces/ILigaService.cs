using Pokeliga.Api.Entities;

namespace Pokeliga.Api.Interfaces
{
    public interface ILigaService
    {
        Task<IEnumerable<Ligas>> GetLigasAsync();
        Task<IEnumerable<Ligas>> GetLigasAsync(bool ativa, int idLoja = 0);
        Task<IEnumerable<Resultados>> GetResultadoAsync(int idLiga);
    }
}
