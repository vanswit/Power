using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Power.Models;

namespace Power.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult Purchase(ProgramModel model)
        {
            return View();
        }
    }
}