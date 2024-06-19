using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pokeliga.Api.Entities;
using Pokeliga.Api.Model;

namespace Pokeliga.Api.Infra.Mapping
{
    public class StandinsMapping : IEntityTypeConfiguration<Standins>
    {
        public void Configure(EntityTypeBuilder<Standins> builder)
        {
            builder.ToTable("Standins");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Place)
                            .IsRequired(true);

            builder.Property(x => x.Categoria)
                            .IsRequired(true);

            builder.Property(x => x.Data)
                            .IsRequired(true);

            builder.Property(x => x.IdLiga)
                            .IsRequired(true);

            builder.Property(x => x.IdPokemon)
                            .IsRequired(true);

            builder.Property(x => x.Vitorias)
                           .IsRequired(true);

            builder.Property(x => x.Empates)
                           .IsRequired(true);

            builder.Property(x => x.Derrotas)
                           .IsRequired(true);

            builder.HasOne<Ligas>()
                            .WithMany()
                            .HasForeignKey(x => x.IdLiga)
                            .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
