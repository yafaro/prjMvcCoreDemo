using Microsoft.EntityFrameworkCore;

namespace prjMvcCoreDemo.Models
{
    public class ApplicationDbContext:dbDemoContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Post> posts { get; set; }
        public DbSet<TCustomer> tCustomer { get; set; }
    }
}
