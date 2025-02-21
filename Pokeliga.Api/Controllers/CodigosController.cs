using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pokeliga.Api.Entities;
using Pokeliga.Api.Infra;
using Pokeliga.Api.Model.Codigos;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace Pokeliga.Api.Controllers
{
    [ApiController]
    [Route("codigos")]
    public class CodigosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CodigosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost()]
        public async Task<IActionResult> SalvarCodigo([FromBody] Codigos request)
        {
            var existe = _context.Codigos.Any(c => c.Codigo == request.Codigo);

            if (!existe)
            {
                try
                {
                    _context.Codigos.Add(request);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return Ok(new { mensagem = ex.Message });
                }

                return Ok(new { mensagem = "Codigo salvo com sucesso!" });
            }

            return BadRequest(new { mensagem = "Código já existe no banco de dados." });
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<CodigosResponse>>> BuscarCodigosAtivos()
        {
            var response = await _context.Codigos
                                .Where(x => x.Usado == false)
                                .GroupBy(x => x.Colecao)
                                .Select(g => new CodigosResponse
                                 {
                                     Colecao = g.Key,
                                     Quantidade = g.Count()
                                 })
                                .ToListAsync();

            return Ok(response);
        }

        [HttpGet("historico")]
        public async Task<ActionResult<IEnumerable<CodigosResponse>>> BuscarHistorico()
        {
            return Ok();
        }

        [HttpPost("EnviarCodigos")]
        public async Task<IActionResult> EnviarCodigos([FromBody] EnviarCodigosRequest request)
        {
            var codigos = await _context.Codigos
                .Where(c => c.Colecao == request.Colecao && c.Usado == false)
                .Take(request.Quantidade)
                .ToListAsync();

            if (codigos.Count < request.Quantidade)
            {
                return BadRequest(new { mensagem = "Quantidade insuficiente" });
            }

            try
            {
                // Construir a mensagem de e-mail com os códigos
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Aqui estão seus códigos de {request.Colecao} :<br>");

                foreach (var codigo in codigos)
                {
                    sb.AppendLine(codigo.Codigo + "<br>");
                }

                string mensagem = sb.ToString();

                // Configurar e enviar o e-mail
                using (MailMessage mailMessage = new MailMessage("pokecodigosvenda@gmail.com", request.Email))
                {
                    mailMessage.Subject = "Pokeloja - Códigos Pokemon";
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Body = $"<p>{mensagem}</p>";
                    mailMessage.SubjectEncoding = Encoding.UTF8;
                    mailMessage.BodyEncoding = Encoding.UTF8;

                    using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = new NetworkCredential("pokecodigosvenda@gmail.com", "ndzo evfb jojr mdyb");
                        smtpClient.EnableSsl = true;

                        smtpClient.Send(mailMessage);
                    }
                }

                foreach (var codigo in codigos){
                    codigo.Usado = true;
                }
                
                await _context.SaveChangesAsync();
                return Ok(new { mensagem = "Códigos enviados com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao enviar e-mail", error = ex.Message });
            }
        }
    }
}
