using Microsoft.EntityFrameworkCore;

namespace Raspberry.Models
{
    public class ScanContext : DbContext
    {
        public ScanContext(DbContextOptions<ScanContext> options)
            : base(options)
        {
        }
        public DbSet<Scanner> Scanners { get; set; } = null;
    }
}
