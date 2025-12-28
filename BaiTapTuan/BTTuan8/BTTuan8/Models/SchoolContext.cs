using System.Data.Entity;

namespace BTTuan8.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext()
            : base("name=SchoolContext")
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
