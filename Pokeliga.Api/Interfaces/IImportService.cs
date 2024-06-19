using Microsoft.AspNetCore.Mvc;
using Pokeliga.Api.Model;

namespace Pokeliga.Api.Interfaces
{
    public interface IImportService
    {
        Task ImportarPartidas(List<PartidaImportRequest> request);
        Task ImportarJogadores(List<PlayersImportRequest> request);
        Task ImportarStandins(List<StandinImportRequest> request);
        Task AtualizarLiga(DateTime data, int idLiga);
    }
}
