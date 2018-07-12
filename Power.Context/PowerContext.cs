using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Power.BO;
using System;

namespace Power.Context
{
    public class PowerContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public PowerContext(DbContextOptions<PowerContext> options)
    : base(options)
        { }

        public DbSet<Program> Programs { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<TrainingItemImage> Images { get; set; }
}
}
