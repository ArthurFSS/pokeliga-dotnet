namespace Pokeliga.Api.Model
{
    public class PremiacaoResponse
    {
        public PremiacaoResponse(int total)
        {
            Total = total;

            Posicao1 = total * (30 / 100m);
            Posicao2 = total * (20 / 100m);
            Posicao3 = total * (15 / 100m);
            Posicao4 = total * (10 / 100m);
            Posicao5 = total * (5 / 100m);
            Posicao6 = total * (5 / 100m);
            Posicao7 = total * (5 / 100m);
            Posicao8 = total * (5 / 100m);
        }

        public int Total { get; set; }
        public decimal Posicao1 { get; set; }
        public decimal Posicao2 { get; set; }
        public decimal Posicao3 { get; set; }
        public decimal Posicao4 { get; set; }
        public decimal Posicao5 { get; set; }
        public decimal Posicao6 { get; set; }
        public decimal Posicao7 { get; set; }
        public decimal Posicao8 { get; set; }
    }
}
