using Microsoft.EntityFrameworkCore;

namespace TriviaProject.Models
{
    public class TriviaContext : DbContext
    {
        public TriviaContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}