namespace Pokeliga.Api.Entities
{
    public class Codigos
    {
        public string Codigo { get; set; } = string.Empty;
        public string Colecao { get; set; } = string.Empty;
        public bool Usado { get; set; } = false;
        public DateTime? DataInclusao { get; set; } = DateTime.Now;
        public DateTime? DataVenda { get; set; }
        public string? EmailVenda { get; set; }
    }
}
