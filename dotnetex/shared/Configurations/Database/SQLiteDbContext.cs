using System;
using Microsoft.EntityFrameworkCore;
using modules.users.Models;

namespace shared.Configurations.Database
{
    public class SQLiteDbContext : DbContext
    {
        public SQLiteDbContext() { }

        public SQLiteDbContext(DbContextOptions<SQLiteDbContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Users>().HasIndex(u => u.email).IsUnique();
            modelBuilder.Entity<Users>().Property(u => u.birthday).HasDefaultValue(DateTime.Now);
        }

    }
}