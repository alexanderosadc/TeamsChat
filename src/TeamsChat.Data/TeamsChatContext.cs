using Microsoft.EntityFrameworkCore;
using TeamsChat.DataObjects;
namespace TeamsChat.Data
{
    public class TeamsChatContext : DbContext
    {
        
        public TeamsChatContext(DbContextOptions<TeamsChatContext> options) : base(options) { }

        public DbSet<AttachedFiles> AttachedFiles { get; set; }

        //public virtual DbSet<AttachedFiles> AttachedFiles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
