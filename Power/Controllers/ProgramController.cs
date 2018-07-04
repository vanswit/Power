using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            var repo = new ProgramDbo();
            repo.Add(program);

            return RedirectToAction("Index");
        }

        public IActionResult AddProgram()
        {
            return View();
        }
    }
}