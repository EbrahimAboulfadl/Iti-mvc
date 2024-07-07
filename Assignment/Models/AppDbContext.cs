using Assignment.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Assignment.Models
{

    public class AppDbContext :DbContext
    {
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainee> Trainees { get; set; }    
        public DbSet<CourseResult> CourseResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=. ;Initial Catalog = ITIMVCAssignment; Integrated Security = True");
        }

    }
}
