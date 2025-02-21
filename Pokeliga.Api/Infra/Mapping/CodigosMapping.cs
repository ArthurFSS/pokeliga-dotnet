using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pokeliga.Api.Entities;

namespace Pokeliga.Api.Infra.Mapping
{
    public class CodigosMapping : IEntityTypeConfiguration<Codigos>
    {
        public void Configure(EntityTypeBuilder<Codigos> builder)
        {
            builder.ToTable("Codigos");
            builder.HasKey(x => x.Codigo);

            builder.Property(x => x.Codigo)
                            .IsRequired(true);

            builder.Property(x => x.Colecao)
                            .IsRequired(true);

            builder.Property(x => x.DataInclusao)
                            .IsRequired(true);

            builder.Property(x => x.Usado);

            builder.Property(x => x.DataVenda);

            builder.Property(x => x.EmailVenda);

        }
    }
}
