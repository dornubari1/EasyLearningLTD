using EasyLearningLTD.Data;
using EasyLearningLTD.Domain;
using EasyLearningLTD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyLearningLTD.Controllers
{
    public class RatingController : Controller
    {
        private readonly ApplicationDbContext _contextDb;

        public RatingController(ApplicationDbContext ratingDb)
        {
            _contextDb = ratingDb;
        }

        public IActionResult ThankYou()
        {

            return View();
        }

        public async Task<IActionResult> Index()
        {

            return View(await _contextDb.TutorRatingTable.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> TutorRating(int? id)
        {


            var tutorID = await _contextDb.TutorRatingTable.FindAsync(id);

            return View(tutorID);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TutorRating(int tutorID, TutorRatingModel model)
        {
            var tutorRatingModel = _contextDb.TutorRatingTable.Find(tutorID);

            if (tutorRatingModel == null)
            {
                _contextDb.TutorRatingTable.Add(model.ToTutorRatingDomain());
                await _contextDb.SaveChangesAsync();
                return RedirectToAction(nameof(ThankYou));
            }
            else
            {
                tutorRatingModel.Helpfulness = (model.Helpfulness + tutorRatingModel.Helpfulness)/2;
                tutorRatingModel.Quality = (model.Quality + tutorRatingModel.Quality)/2;
                tutorRatingModel.Professionalism = (model.Professionalism + tutorRatingModel.Professionalism)/2;
                tutorRatingModel.Workload = (model.Workload + tutorRatingModel.Workload)/2;
                tutorRatingModel.OverAllRating = (model.OverAllRating + tutorRatingModel.OverAllRating)/2;

                _contextDb.SaveChanges();
     
                return RedirectToAction(nameof(ThankYou));

            }
        }


        [Authorize]
        public async Task<IActionResult> DisplayRating()
        {
            return View(await _contextDb.TutorRatingTable.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> SearchResult(string SearchTerm, string LastName)
        {
            if (SearchTerm == null)
            {
                return View("DisplayRating", await _contextDb.TutorRatingTable.ToListAsync());
            }

            return View("DisplayRating", await _contextDb.TutorRatingTable.Where(c => c.FirstName.Contains(SearchTerm)).ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> DisplayRatingDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutorRatingDomain = await _contextDb.TutorRatingTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tutorRatingDomain == null)
            {
                return NotFound();
            }

            return View(tutorRatingDomain);
        }

    }

    


}
