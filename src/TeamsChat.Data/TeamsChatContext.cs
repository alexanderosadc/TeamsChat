using Microsoft.EntityFrameworkCore;

namespace TeamsChat.Data
{
    public class TeamsChatContext : DbContext
    {
        public TeamsChatContext(DbContextOptions<TeamsChatContext> options) : base(options) { }

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
