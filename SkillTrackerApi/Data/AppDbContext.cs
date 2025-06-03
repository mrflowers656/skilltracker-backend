using Microsoft.EntityFrameworkCore;
using SkillTrackerApi.Models;

namespace SkillTrackerApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "C#", Level = 4, Category = "Backend" },
                new Skill { Id = 2, Name = "React", Level = 3, Category = "Frontend" },
                new Skill { Id = 3, Name = "SQL", Level = 4, Category = "Database" }
            );
        }
    }
}