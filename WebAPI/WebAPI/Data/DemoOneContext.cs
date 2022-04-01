using Microsoft.EntityFrameworkCore;
using WebAPI.Data.Entities;

namespace WebAPI.Data
{
    public class DemoOneContext : DbContext
    {
        public DbSet<Person>? People { get; set; }
        public DemoOneContext()
        {

        }

        public DemoOneContext(DbContextOptions<DemoOneContext> options)
            : base(options)
        {

        }

    }
}