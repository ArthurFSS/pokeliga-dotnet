using Google.Apis.Auth;
using Microsoft.AspNetCore.Mvc;
using Pokeliga.Api.Interfaces;
using Pokeliga.Api.Model;
using Pokeliga.Api.Services;

namespace Pokeliga.Api.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] GoogleTokenModel tokenModel)
        {

         var validPayload = await VerifyGoogleTokenAsync(tokenModel.Token);

         var login =  await _userService.Login(validPayload.Email);
            if (login)
            return Ok(new { mensagem = "Usuario Logado com sucesso" });
            
         return Created();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] GoogleTokenModel tokenModel)
        {
            var validPayload = await VerifyGoogleTokenAsync(tokenModel.Token);
          
            var login = await _userService.CreateUser(validPayload, tokenModel.idPokemon, tokenModel.birthDate);

            if (!login)
                return BadRequest(new { mensagem = "Não foi possivel cadastrar jogador" });

            return Ok(new { mensagem = "Usuario Criado com sucesso" });
        }

        private async Task<GoogleJsonWebSignature.Payload> VerifyGoogleTokenAsync(string idToken)
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, new GoogleJsonWebSignature.ValidationSettings());
            return payload;
        }

        public class GoogleTokenModel
        {
            public string Token { get; set; }
            public DateTime birthDate { get; set; }
            public int idPokemon { get; set; }
        }
    }
}
