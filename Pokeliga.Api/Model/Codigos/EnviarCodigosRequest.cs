namespace Pokeliga.Api.Model.Codigos
{
    public class EnviarCodigosRequest
    {
        public int Quantidade { get; set; }
        public string? Colecao { get; set; }
        public string? Email { get; set; }
    }
}
