using Microsoft.EntityFrameworkCore;

namespace StudentAPI.Models
{
    public class StudentManagementDBContext : DbContext
    {
        public StudentManagementDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Student> Students { get; set; }
    }
}
