using Microsoft.EntityFrameworkCore;
using Power.BO;

namespace Power.Context
{
    public class PowerContext : DbContext
    {
        public PowerContext(DbContextOptions<PowerContext> options)
    : base(options)
        { }

        public DbSet<Program> Programs { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<TrainingItemImage> Images { get; set; }
}
}
