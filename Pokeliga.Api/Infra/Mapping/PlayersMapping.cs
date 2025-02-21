using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pokeliga.Api.Entities;

namespace Pokeliga.Api.Infra.Mapping
{
    public class PlayersMapping : IEntityTypeConfiguration<Players>
    {
        public void Configure(EntityTypeBuilder<Players> builder)
        {
            builder.ToTable("Players");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdPokemon)
                            .IsRequired(true);

            builder.Property(x => x.FirstName)
                            .IsRequired(true);

            builder.Property(x => x.LastName)
                            .IsRequired(true);

            builder.Property(x => x.Birthdate)
                            .IsRequired(true);

            builder.Property(x => x.Email);
        }
    }

}
