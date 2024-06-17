using Microsoft.EntityFrameworkCore;
using Pokeliga.Api.Entities;
using System.Reflection;

namespace Pokeliga.Api.Infra
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Ligas> Ligas { get; set; } = null!;
        public DbSet<Partidas> Partidas { get; set; } = null!;
        public DbSet<Players> Players { get; set; } = null!;
        public DbSet<Resultados> Resultados { get; set; } = null!;
        public DbSet<Standins> Standins { get; set; } = null!;
        public DbSet<GlcBadges> GlcBadges { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
