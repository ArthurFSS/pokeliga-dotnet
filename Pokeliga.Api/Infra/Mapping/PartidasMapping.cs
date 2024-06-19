using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pokeliga.Api.Entities;
using Pokeliga.Api.Model;

namespace Pokeliga.Api.Infra.Mapping
{
    public class PartidasMapping : IEntityTypeConfiguration<Partidas>
    {
        public void Configure(EntityTypeBuilder<Partidas> builder)
        {
            builder.ToTable("Partidas");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.RoundNumber)
                            .IsRequired(true);

            builder.Property(x => x.Player1)
                            .IsRequired(true);

            builder.Property(x => x.Player2)
                            .IsRequired(true);

            builder.Property(x => x.Outcome)
                            .IsRequired(true);

            builder.Property(x => x.Data)
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
