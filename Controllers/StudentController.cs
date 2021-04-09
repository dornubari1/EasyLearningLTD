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
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ApplicationDbContext _contextDb;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StudentRegistration()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Courses() //to add couses to database
        {
            return View();
        }

        [HttpPost]
        [HttpPost]
        public IActionResult Courses(CoursesModel model)
        {
            _context.CourseTable.Add(model.ToCoursesDomain());
            _context.SaveChanges();
            return View();
        }

        [Authorize]
        public async Task<IActionResult> CourseCard()
        {
            return View(await _context.CourseTable.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> SearchResult( string SearchTerm)
        {
            if (SearchTerm == null)
            {
                return View("CourseCard", await _context.CourseTable.ToListAsync());
            }

            return View("CourseCard", await _context.CourseTable.Where(c => c.CourseTitle.Contains(SearchTerm)).ToListAsync());
        }


        //[HttpGet]
        //public async Task<IActionResult> AddToCart(int? id)
        //{

        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var courseID = await _context.CourseTable.FindAsync(id);

       
        //    return View();

        //    //return View(await _context.CourseTable.ToListAsync());
        //}

        //[HttpPost]
        public async Task<IActionResult> AddToCart(int? id, AddToCartModel model)
        {
            if (id == null)
            {
                return View();
            }
            var addToCartModel = await _context.CourseTable.FindAsync(id);

            model.Id = addToCartModel.Id;
            model.CourseTitle = addToCartModel.CourseTitle;
            model.Price = addToCartModel.Price;
            model.Status = addToCartModel.Status;
            model.Quantity += 1;

            List<AddToCartModel> addToCarts = new List<AddToCartModel>
            {
                model
            };


            return View(addToCarts);

        }

       
    }
}
