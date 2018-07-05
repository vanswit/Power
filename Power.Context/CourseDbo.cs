using Microsoft.EntityFrameworkCore;
using Power.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power.Context
{
    public class CourseDbo
    {
        private DbContextOptionsBuilder<PowerContext> options;

        public CourseDbo(DbContextOptionsBuilder<PowerContext> options)
        {
            this.options = options;
        }

        public int Add(Course c)
        {
            using (var context = new PowerContext(options.Options))
            {
                context.Courses.Add(c);

                return context.SaveChanges();
            }
        }
    }
}
