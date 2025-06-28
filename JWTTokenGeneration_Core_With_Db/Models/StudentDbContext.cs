using Microsoft.EntityFrameworkCore;
namespace JWTTokenGeneration_Core_With_Db.Models

{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
