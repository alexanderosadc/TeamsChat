using Microsoft.EntityFrameworkCore;
using TeamsChat.DataObjects;

namespace TeamsChat.Data
{
    public class TeamsChatContext : DbContext
    {
        public TeamsChatContext() { }
        public TeamsChatContext(DbContextOptions<TeamsChatContext> options) : base(options) { }

        public virtual DbSet<AttachedFile> AttachedFiles { get; set; }
        public virtual DbSet<MessageGroup> MessageGroups { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
