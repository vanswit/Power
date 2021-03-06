﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power.BO
{
    public interface ITrainingItem
    {
        int Id { get; set; }
        string Name { get; set; }
        TrainingItemImage Image { get; set; }
        string Content { get; set; }
        decimal Price { get; set; }
    }
}
