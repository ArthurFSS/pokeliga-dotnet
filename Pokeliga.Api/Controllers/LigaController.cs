using Microsoft.AspNetCore.Mvc;
using Pokeliga.Api.Entities;
using Pokeliga.Api.Interfaces;
using Pokeliga.Api.Model;

namespace Pokeliga.Api.Controllers
{
    [ApiController]
    [Route("liga")]
    public class LigaController : ControllerBase
    {
        private readonly ILigaService _ligaService;

        public LigaController(ILigaService ligaService)
        {
            _ligaService = ligaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LigasResponse>>> GetLigas()
        {
            var ligas = await _ligaService.GetLigasAsync();
            var ligasResponse = new List<LigasResponse>();

            foreach (var item in ligas)
            {
                var ligaResponse = new LigasResponse {
                    Descricao = item.Descricao,
                    Organizador = item.Organizador,
                    DataFim = item.DataFim,
                    DataInicio = item.DataInicio,
                    Finalizada = item.Finalizada,
                    Id = item.Id,
                    IdOrganizador = item.IdOrganizador,
                    Tipo = item.Tipo,
                };

                ligasResponse.Add(ligaResponse);
            }

            return Ok(ligasResponse);
        }

        [HttpGet("ativas")]
        public async Task<ActionResult<IEnumerable<Ligas>>> GetLigasAtivas()
        {
            var ligas = await _ligaService.GetLigasAsync(true);
            return Ok(ligas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ResultadosResponse>>> GetResultados(int id)
        {
            var resultados = await _ligaService.GetResultadoAsync(id);
            return Ok(resultados);
        }

        [HttpGet("standins/{id}")]
        public async Task<ActionResult<IEnumerable<Standins>>> GetStandins(int id)
        {
            var standins = await _ligaService.GetStandinsAsync(id);
            return Ok(standins);
        }
    }
}
