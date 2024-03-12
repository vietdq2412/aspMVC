using aspMVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace aspMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {                               

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; } = default!;
        public DbSet<Classes> Classes { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Subject>().HasData(new Subject { Id = 1, Name = "Subject 1" });
            modelBuilder.Entity<Subject>().HasData(new Subject { Id = 2, Name = "Subject 2" });
            modelBuilder.Entity<Subject>().HasData(new Subject { Id = 3, Name = "Subject 3" });
            
            modelBuilder.Entity<Student>().HasData(new Student { Id = 1, Name = "Student 1", Email = "email1 "});
            modelBuilder.Entity<Student>().HasData(new Student { Id = 2, Name = "Student 2", Email = "email12 "});
            modelBuilder.Entity<Student>().HasData(new Student { Id = 3, Name = "Student 3", Email = "email13 "});
        
        
        }
    }
}
