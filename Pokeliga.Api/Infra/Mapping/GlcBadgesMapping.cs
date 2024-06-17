using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pokeliga.Api.Entities;

namespace Pokeliga.Api.Infra.Mapping
{
    public class GlcBadgesMapping : IEntityTypeConfiguration<GlcBadges>
    {
        public void Configure(EntityTypeBuilder<GlcBadges> builder)
        {
            builder.ToTable("GlcBadges");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdPokemon)
                            .IsRequired(true);

            builder.Property(x => x.LastWinDate)
                            .IsRequired(true);

            builder.Property(x => x.Badge1)
                            .IsRequired(true);

            builder.Property(x => x.Badge2)
                            .IsRequired(true);

            builder.Property(x => x.Badge3)
                            .IsRequired(true);

            builder.Property(x => x.Badge4)
                            .IsRequired(true);

            builder.Property(x => x.Badge5)
                            .IsRequired(true);

            builder.Property(x => x.Badge6)
                            .IsRequired(true);

            builder.Property(x => x.Badge7)
                            .IsRequired(true);

            builder.Property(x => x.Badge8)
                            .IsRequired(true);

            builder.Property(x => x.Badge9)
                            .IsRequired(true);

            builder.Property(x => x.Badge10)
                            .IsRequired(true);
        }
    }

}
