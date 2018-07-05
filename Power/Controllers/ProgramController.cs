using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Power.BO;
using Power.Context;

namespace Power.Controllers
{
    public class ProgramController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProgram(Power.BO.Program program)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PowerContext>();

            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PowerDB;Trusted_Connection=True;ConnectRetryCount=0");

            var repo = new ProgramDbo(optionsBuilder);
            repo.Add(program);

            return RedirectToAction("Index");
        }

        public IActionResult AddProgram()
        {
            return View();
        }
    }
}