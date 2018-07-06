using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power.BO
{
    public class Course : ITrainingItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public TrainingItemImage Image { get; set; }
        public decimal Price { get; set; }
    }
}
