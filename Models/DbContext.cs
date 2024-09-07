using Microsoft.EntityFrameworkCore;

namespace StudentCourses.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {

    }

    // Needed for Many-to-Many association entity
    // StudentCourse entity has 2 attributes as the primary key.
    // This code tells EF Core that StudentID and CourseID combine for the primary key
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentCourse>().HasKey(s => new {s.CourseID, s.StudentID});
    }

    public DbSet<Student> Students {get; set;}
    public DbSet<Course> Courses {get; set;}
    public DbSet<StudentCourse> StudentCourses {get; set;}
}