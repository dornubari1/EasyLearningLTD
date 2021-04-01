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
        public IActionResult Courses()
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
            //if (SearchTerm == default)
            //{
            //    return View(await _context.CourseTable.ToListAsync());
            //}             

            return View("CourseCard", await _context.CourseTable.Where(c=>c.CourseTitle.Contains(SearchTerm)).ToListAsync());
        }
    }
}
