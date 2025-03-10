using Microsoft.EntityFrameworkCore;

namespace UavApi.Data
{
    public class UavDbContext : DbContext
    {
        public UavDbContext(DbContextOptions<UavDbContext> options) : base(options) { }

        public DbSet<Uav> Uavs { get; set; }
        public DbSet<Threat> Threats { get; set; }
    }
}
