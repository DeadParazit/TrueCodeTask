using Microsoft.EntityFrameworkCore;
using TrueCodeUlanYeskendirovTask.Core.Models;

namespace TrueCodeUlanYeskendirovTask.Repository
{
    public class TrueCodeDbContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Priority> Priorities { get; set; }

        public TrueCodeDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Priority>().HasKey(p => p.Level);

            base.OnModelCreating(modelBuilder);
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Mobile.db");
        }
    }
}
