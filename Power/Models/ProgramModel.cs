using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Power.Models
{
    public class ProgramModel
    {
        public string ImagePath { get; set; }
        public Power.BO.Program Program { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
