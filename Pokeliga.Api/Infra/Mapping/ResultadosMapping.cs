using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pokeliga.Api.Entities;

namespace Pokeliga.Api.Infra.Mapping
{
    public class ResultadosMapping : IEntityTypeConfiguration<Resultados>
    {
        public void Configure(EntityTypeBuilder<Resultados> builder)
        {
            builder.ToTable("Resultados");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                            .IsRequired(true);

            builder.Property(x => x.IdPokemon)
                            .IsRequired(true);

            builder.Property(x => x.Data)
                            .IsRequired(true);

            builder.Property(x => x.Pontos)
                            .IsRequired(true);

            builder.Property(x => x.IdLiga)
                            .IsRequired(true);

            builder.HasOne<Ligas>()
                            .WithMany()
                            .HasForeignKey(x => x.IdLiga)
                            .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
