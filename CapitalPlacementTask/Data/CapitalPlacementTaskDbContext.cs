using CapitalPlacementTask.Models;
using Microsoft.EntityFrameworkCore;

namespace CapitalPlacementTask.Data
{
    public class CapitalPlacementTaskDbContext : DbContext
    {
        public CapitalPlacementTaskDbContext(DbContextOptions<CapitalPlacementTaskDbContext> options) : base(options)
        {
        }
        public DbSet<ProgramDetail> ProgramDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
