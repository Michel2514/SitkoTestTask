using Microsoft.EntityFrameworkCore;

namespace SitkoTestTask.Data
{
    public class TestDbContext : DbContext
    {
        public DbSet<TODOList> TODOLists { get; set; }

        public TestDbContext(DbContextOptions<TestDbContext> options)
        :base(options)
        { }
    }
}
