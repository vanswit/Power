using Power.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Power.Models
{
    public class ProgramIndexModel
    {
        public IEnumerable<ITrainingItem> items { get; set; }
        public AppUser user { get; set; }
    }
}
