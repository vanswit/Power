﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Power.Controllers
{
    public class ProgramController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}