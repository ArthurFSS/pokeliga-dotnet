using Microsoft.AspNetCore.Mvc;
using Pokeliga.Api.Entities;
using Pokeliga.Api.Interfaces;

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
        public async Task<ActionResult<IEnumerable<Ligas>>> GetLigas()
        {
            var ligas = await _ligaService.GetLigasAsync();
            return Ok(ligas);
        }

        [HttpGet("ativas")]
        public async Task<ActionResult<IEnumerable<Ligas>>> GetLigasAtivas()
        {
            var ligas = await _ligaService.GetLigasAsync(true);
            return Ok(ligas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Resultados>>> GetResultados(int id)
        {
            var resultados = await _ligaService.GetResultadoAsync(id);
            return Ok(resultados);
        }
    }
}
