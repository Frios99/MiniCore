using Microsoft.EntityFrameworkCore;
using MiniCore_Francis.Models;

namespace MiniCore_Francis.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        // Models
        public DbSet<User> users { get; set; }
        public DbSet<Pass> passes { get; set; }
        public DbSet<MiniCore> minicores { get; set; }
    }
}
