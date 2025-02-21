using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using Pokeliga.Api.Entities;
using Pokeliga.Api.Model;

namespace Pokeliga.Api.Infra.Mapping
{
    public class LigasMapping : IEntityTypeConfiguration<Ligas>
    {
        public void Configure(EntityTypeBuilder<Ligas> builder)
        {
            builder.ToTable("Ligas");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                            .IsRequired(true);

            builder.Property(x => x.Tipo)
                            .IsRequired(true);

            builder.Property(x => x.Finalizada);

            builder.Property(x => x.DataInicio)
                           .IsRequired(true);

            builder.Property(x => x.DataFim);

            builder.Property(x => x.Organizador)
                           .IsRequired(true);

            builder.Property(x => x.IdOrganizador)
                           .IsRequired(true);
            builder.Property(x => x.ValorCaixaIndividual)
                          .IsRequired(true);
        }
    }
}
