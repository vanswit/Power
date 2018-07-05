using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Power.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power.Context
{
    public class ProgramDbo
    {
        private DbContextOptionsBuilder<PowerContext> options;

        public ProgramDbo(DbContextOptionsBuilder<PowerContext> options) {
            this.options = options;
        }

        public int Add(Program p)
        {
            using (var context = new PowerContext(options.Options))
            {
                context.Programs.Add(p);

                return context.SaveChanges();
            }
        }


    }
}
