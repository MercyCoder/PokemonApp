using System;
using Microsoft.EntityFrameworkCore;

namespace PokemonApp.Models
{
    public class PokeContext : DbContext
    {
        public PokeContext(DbContextOptions<PokeContext> options) : base(options)
        {
        }

        public DbSet<Trainer> Trainer { get; set; }
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<Catch> Catch { get; set; }
    }
}
