using Microsoft.EntityFrameworkCore;
using CourseManager.Entities;
using Microsoft.Extensions.Options;
using CourseManager;

namespace CourseManager
{
    public class CourseManagerDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Teacher> Teachers { get; set; } = null!;

        public CourseManagerDbContext(DbContextOptions<CourseManagerDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
                new { Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), Name = "Mathematics" },
                new { Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), Name = "History" }
            );

            modelBuilder.Entity<Teacher>().HasData(
                new { Id = Guid.Parse("1b61c5e4-50d3-4a49-9d31-8b6d40c72a2e"), Name = "John Doe", teacherId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35") },
                new { Id = Guid.Parse("e7e4b2a2-6547-47d0-a04e-0cd3b2678a0f"), Name = "Jane Smith", teacherId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96") }
            );
        }
    }
}
