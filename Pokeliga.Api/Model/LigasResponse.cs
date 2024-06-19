using Pokeliga.Api.Entities.Enun;

namespace Pokeliga.Api.Model
{
    public class LigasResponse
    {
        public int Id { get; set; }
        public required string Organizador { get; set; }
        public int IdOrganizador { get; set; }
        public required string Descricao { get; set; }
        public ETipoLiga Tipo { get; set; }
        public string TipoNome => Tipo.ToString();
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public bool Finalizada { get; set; }
    }
}
