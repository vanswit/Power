﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Power.BO;
using Power.Context;
using Power.Models;

namespace Power.Controllers
{
    public class ProgramController : Controller
    {
        IHostingEnvironment _env;
        public ProgramController(IHostingEnvironment env)
        {
            _env = env;
        }

        public IActionResult Index()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PowerContext>();

            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PowerDB;Trusted_Connection=True;ConnectRetryCount=0");

            var repo = new ProgramDbo(optionsBuilder);

            IEnumerable<ITrainingItem> programs = repo.GetAll();

            return View(programs);
        }

        [HttpPost]
        public IActionResult AddProgram(ProgramModel programModel)
        {
            string[] pathParts = programModel.ImagePath.Split("\\");

            var fileName = pathParts.Last();

            var imagePath = _env.WebRootPath + "\\images\\" + fileName;

            var fileInfo = new FileInfo(programModel.ImagePath);

            fileInfo.CopyTo(imagePath);

            var optionsBuilder = new DbContextOptionsBuilder<PowerContext>();

            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PowerDB;Trusted_Connection=True;ConnectRetryCount=0");

            var trainingItemImage = new TrainingItemImage();

            trainingItemImage.FilePath = imagePath;

            var imageRepo = new TrainingItemImageDbo(optionsBuilder);

            programModel.Program.Image = trainingItemImage;

            var programRepo = new ProgramDbo(optionsBuilder);
            programRepo.Add(programModel.Program);

            return RedirectToAction("Index");
        }

        public IActionResult AddProgram()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var program = new Power.BO.Program();

            var optionsBuilder = new DbContextOptionsBuilder<PowerContext>();

            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PowerDB;Trusted_Connection=True;ConnectRetryCount=0");

            var repo = new ProgramDbo(optionsBuilder);

            program = repo.GetProgram(id);

            return View(program);
        }
    }
}