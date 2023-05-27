using FullStack.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FullStack.API.Data
{
    public class FullStackDbContext : DbContext
    {
        public FullStackDbContext(DbContextOptions<FullStackDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<EmployeeCourse> EmployeeCourses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeCourse>().HasKey(ec => new { ec.EmployeeId, ec.CourseId });

            modelBuilder.Entity<EmployeeCourse>()
                .HasOne(e => e.Employee)
                .WithMany(ec => ec.EmployeeCourses)
                .HasForeignKey(e => e.EmployeeId);

            modelBuilder.Entity<EmployeeCourse>()
                .HasOne(c => c.Course)
                .WithMany(ec => ec.EmployeeCourses)
                .HasForeignKey(c => c.CourseId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
