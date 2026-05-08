using System.Data.Entity;

namespace Project2.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
