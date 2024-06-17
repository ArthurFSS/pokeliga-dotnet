namespace Pokeliga.Api.Model
{
    public class PartidaImportRequest
    {
        public int RoundNumber { get; set; }
        public int Player1 { get; set; }
        public int Player2 { get; set; }
        public int Outcome { get; set; }
        public DateTime Data { get; set; }
        public int IdLiga { get; set; }
    }
}
