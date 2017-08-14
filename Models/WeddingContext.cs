using Microsoft.EntityFrameworkCore;

namespace wedding_planner.Models
{
    public class WeddingContext: DbContext
    {
        public WeddingContext(DbContextOptions<WeddingContext> options) : base(options) { }

        public DbSet<User> user {get;set;}

        public DbSet<Wedding> wedding {get; set;}
        public DbSet<Invite> invite {get; set;}
    }

}