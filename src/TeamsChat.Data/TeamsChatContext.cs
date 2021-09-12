using Microsoft.EntityFrameworkCore;
using TeamsChat.DataObjects;

namespace TeamsChat.Data
{
    public class TeamsChatContext : DbContext
    {
        public TeamsChatContext() { }
        public TeamsChatContext(DbContextOptions<TeamsChatContext> options) : base(options) { }

        public virtual DbSet<TestData> TestData { get; set; }
        public virtual DbSet<AttachedFiles> AttachedFiles { get; set; }
        public virtual DbSet<MessageGroups> MessageGroups { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
