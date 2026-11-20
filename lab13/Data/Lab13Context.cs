using lab13.Models;
using Microsoft.EntityFrameworkCore;

namespace lab13.Data
{
    public class Lab13Context : DbContext
    {
        public Lab13Context(DbContextOptions<Lab13Context> options) : base(options)
        {
        }

        public DbSet<Grade> Grades { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
    }
}