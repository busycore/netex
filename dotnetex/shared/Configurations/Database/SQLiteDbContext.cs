using Microsoft.EntityFrameworkCore;
using modules.users.Models;

namespace shared.Configurations.Database
{
    public class SQLiteDbContext : DbContext
    {
        public SQLiteDbContext() { }

        public SQLiteDbContext(DbContextOptions<SQLiteDbContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
    }
}