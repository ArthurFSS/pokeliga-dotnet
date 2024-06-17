using Microsoft.AspNetCore.Mvc;
using Pokeliga.Api.Entities;
using Pokeliga.Api.Interfaces;
using Pokeliga.Api.Model;

namespace Pokeliga.Api.Controllers
{
    [ApiController]
    [Route("import")]
    public class ImportController : ControllerBase
    {
            private readonly IImportService _importService;

            public ImportController(IImportService importService)
            {
                _importService = importService;
            }

        [HttpPost("partidas")]
        public async Task<IActionResult> ImportarPartidas([FromBody] List<PartidaImportRequest> request)
        {
            await _importService.ImportarPartidas(request);
            return Ok(new { mensagem = "Importação de partidas realizada com sucesso!" });
        }

        [HttpPost("players")]
        public async Task<IActionResult> ImportarPlayers([FromBody] List<PlayersImportRequest> request)
        {
            await _importService.ImportarJogadores(request);
            return Ok(new { mensagem = "Importação de players realizada com sucesso!" });
        }

        [HttpPost("standins")]
        public async Task<IActionResult> ImportarStandins([FromBody] List<StandinImportRequest> request)
        {
            await _importService.ImportarStandins(request);
            return Ok(new { mensagem = "Importação de standins realizada com sucesso!" });
        }
    }
}

