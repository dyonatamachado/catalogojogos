using CatalogoDeJogos.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogoDeJogos.Persistence
{
    public class GamesContext : DbContext
    {
        public GamesContext(DbContextOptions<GamesContext> options) : base(options)
        {
            
        }

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(e => 
            {
                e.HasKey(g => g.Id);
            });
        }
    }
}