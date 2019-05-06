using Microsoft.EntityFrameworkCore;
using VasilyTest.Models;

namespace VasilyTest.DataAccess.Db
{
    public class VasilyTestDbContext : DbContext
    {
        public VasilyTestDbContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<TestDbModel> TestDbModel { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
