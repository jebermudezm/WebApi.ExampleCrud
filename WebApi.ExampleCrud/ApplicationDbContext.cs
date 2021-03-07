using Microsoft.EntityFrameworkCore;
using WebApi.ExampleCrud.Model;

namespace WebApi.ExampleCrud
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public ApplicationDbContext()
        {

        }
        public DbSet<Car> Cars { get; set; }
    }
}
