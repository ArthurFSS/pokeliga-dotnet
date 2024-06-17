using Pokeliga.Api.Model;

namespace Pokeliga.Api.Entities
{
    public class Partidas
    {
        public Partidas()
        {
            
        }

        public Partidas(PartidaImportRequest partidaRequest)
        {
            RoundNumber = partidaRequest.RoundNumber;
            Player1 = partidaRequest.Player1;
            Player2 = partidaRequest.Player2;
            Outcome = partidaRequest.Outcome;
            Data = partidaRequest.Data;
            IdLiga = partidaRequest.IdLiga;
        }

        public int Id { get; set; }
        public int RoundNumber { get; set; }
        public int Player1 {  get; set; }
        public int Player2 { get; set; }
        public int Outcome { get; set; }
        public DateTime Data {  get; set; }
        public int IdLiga { get; set; }
    }


}
