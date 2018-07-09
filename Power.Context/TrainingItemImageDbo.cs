using Microsoft.EntityFrameworkCore;
using Power.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power.Context
{
    public class TrainingItemImageDbo
    {
        private DbContextOptionsBuilder<PowerContext> options;

        public TrainingItemImageDbo(DbContextOptionsBuilder<PowerContext> options)
        {
            this.options = options;
        }

        public int Add(TrainingItemImage t)
        {
            using (var context = new PowerContext(options.Options))
            {
                context.Images.Add(t);

                return context.SaveChanges();
            }
        }

        public TrainingItemImage GetImage(int id)
        {
            using (var context = new PowerContext(options.Options))
            {
                return context.Images.SingleOrDefault(p => p.Id == id);
            }
        }
    }
}
