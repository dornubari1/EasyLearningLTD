using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EasyLearningLTD.Data;
using EasyLearningLTD.Domain;
using Microsoft.AspNetCore.Authorization;

namespace EasyLearningLTD.Controllers
{
    public class TutorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TutorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.TutorRegistrationTable.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutorRegistrationDomain = await _context.TutorRegistrationTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tutorRegistrationDomain == null)
            {
                return NotFound();
            }

            return View(tutorRegistrationDomain);
        }

        [Authorize]
        [HttpGet]
        public IActionResult TutorRegistration()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TutorRegistration([Bind("Id,FirstName,LastName,Email,AvailableCourses,Availability,Password")] TutorRegistrationDomain tutorRegistrationDomain)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tutorRegistrationDomain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tutorRegistrationDomain);
        }

        // GET: Tutors/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutorRegistrationDomain = await _context.TutorRegistrationTable.FindAsync(id);
            if (tutorRegistrationDomain == null)
            {
                return NotFound();
            }
            return View(tutorRegistrationDomain);
        }

        // POST: Tutors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.

       
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,AvailableCourses,Availability,Password")] TutorRegistrationDomain tutorRegistrationDomain)
        {
            if (id != tutorRegistrationDomain.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tutorRegistrationDomain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TutorRegistrationDomainExists(tutorRegistrationDomain.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tutorRegistrationDomain);
        }

        // GET: Tutors/Delete/5
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutorRegistrationDomain = await _context.TutorRegistrationTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tutorRegistrationDomain == null)
            {
                return NotFound();
            }

            return View(tutorRegistrationDomain);
        }

        // POST: Tutors/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tutorRegistrationDomain = await _context.TutorRegistrationTable.FindAsync(id);
            _context.TutorRegistrationTable.Remove(tutorRegistrationDomain);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TutorRegistrationDomainExists(int id)
        {
            return _context.TutorRegistrationTable.Any(e => e.Id == id);
        }
    }
}
