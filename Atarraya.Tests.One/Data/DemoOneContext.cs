using Microsoft.EntityFrameworkCore;
using Atarraya.Tests.One.Data.Entities;

namespace Atarraya.Tests.One.Data
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