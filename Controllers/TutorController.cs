using EasyLearningLTD.Data;
using EasyLearningLTD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyLearningLTD.Controllers
{
    public class TutorController : Controller
    {
        private readonly ApplicationDbContext _contextDb;

        public TutorController(ApplicationDbContext ratingDb)
        {
            _contextDb = ratingDb;
        }



        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult TutorRating()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult TutorRating(TutorRatingModel model)
        {
            _contextDb.TutorRatingTable.Add(model.ToTutorRatingDomain());
            _contextDb.SaveChanges();
            return View();
        }

    }
}
