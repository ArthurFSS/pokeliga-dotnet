using Pokeliga.Api.Entities;
using Pokeliga.Api.Model;

namespace Pokeliga.Api.Interfaces
{
    public interface ILigaService
    {
        Task<IEnumerable<Ligas>> GetLigasAsync();
        Task<IEnumerable<Ligas>> GetLigasAsync(bool ativa, int idLoja = 0);
        Task<IEnumerable<ResultadosResponse>> GetResultadoAsync(int idLiga);
        Task<IEnumerable<StandinsEvento>> GetStandinsAsync(int idLiga);
        Task<PremiacaoResponse> GetCaixa(int idLiga);
        Task<PlayerHistoryResponse> GetPlayerHistory(int pokeId);
    }
}
