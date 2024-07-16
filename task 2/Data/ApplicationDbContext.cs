using Microsoft.EntityFrameworkCore;
using task_2.Models;



namespace task_2.Data
{
    public class ApplicationDbContext:DbContext

    {
        public ApplicationDbContext(DbContextOptions options): base (options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<StudentCourses> StudentCourses { get;set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructors> Instructors { get; set; }


    }
}
