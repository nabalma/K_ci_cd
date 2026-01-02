using Microsoft.EntityFrameworkCore;
using Kolyya.Api.Models;

namespace Kolyya.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<SampleItem> SampleItems => Set<SampleItem>();
    }
}
