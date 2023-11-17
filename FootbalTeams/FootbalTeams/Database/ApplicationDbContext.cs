using CatalogOfFootballPlayers.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogOfFootballPlayers.Database
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Player> Players { get; set; }
    }
}
