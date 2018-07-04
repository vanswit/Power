using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
