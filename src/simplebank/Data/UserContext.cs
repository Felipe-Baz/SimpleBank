using Microsoft.EntityFrameworkCore;
using simplebank.Model;

namespace simplebank.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

    }
}