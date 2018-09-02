using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeacherApp.Models;

namespace TeacherApp.Controllers
{
    public class TeachersController : Controller
    {
        private readonly TeacherAppContext _context;

        public TeachersController(TeacherAppContext context)
        {
            _context = context;
        }

        // GET: Teachers
        public async Task<IActionResult> Index(string searchString)
        {

            var teachers = from teacher in _context.Teachers
                            select teacher;

            if (!String.IsNullOrEmpty(searchString))
            {
                teachers = teachers.Where(t => t.FullName().Contains(searchString));
            }

            return View(await teachers.ToListAsync());

        }

        [HttpPost]
        public async Task<IActionResult> AddReview(int teacherID, string text, int rating)
        {
            if (Request.Cookies["userid"] == null)
            {
                return Json(new { status = "error", message = "Please sign in to submit a review" });
            }
            int personID;
            try
            {
                personID = Int32.Parse(Request.Cookies["userid"]);
            } catch (Exception e)
            {
                return Json(new { status = "error", message = "Failed to get user details. " + e.Message });
            }
            
            Teacher teacher = await _context.Teachers
                .SingleAsync(t => t.ID == teacherID);
            Person person = await _context.Persons
                .SingleAsync(p => p.ID == personID);

            var previousReview = from r in _context.Reviews
                                 where r.PersonID == person.ID
                                 where r.TeacherID == teacher.ID
                                 select r;
            // a review already exists for this user
            if (previousReview != null)
            {
                return Json(new { status="error", message="A review for " + teacher.FullName() + " Already exists from user"});
            }

            Review review = new Review
            {
                Published = DateTime.Now,
                Teacher = teacher,
                TeacherID = teacherID,
                Rating = rating,
                ReviewContent = text,
                Person = person,
                PersonID = personID
            };

            // will also add a new entry to Reviews table
            teacher.Reviews.Add(review);
            teacher.UpdateRating();
            _context.SaveChanges();
            return View(teacher);
        }

        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teachers
                .SingleOrDefaultAsync(m => m.ID == id);

            if (teacher == null)
            {
                return NotFound();
            }

            // load teacher reviews 
            _context.Entry(teacher)
                .Collection(t => t.Reviews)
                .Load();

            return View(teacher);
        }

        // GET: Teachers/Create
        public IActionResult Create()
        {
            return View();
        }       
        // GET: Teachers/AllTeachers
        public IActionResult AllTeachers()
        {
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Password,Phone,Gender,Email,Address,DateOfBirth,Degree,Institution,ActiveSince,Enrolled,Graduated,Rating,About,LessonPrice,ImagePath")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teachers.SingleOrDefaultAsync(m => m.ID == id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Password,Phone,Gender,Email,Address,DateOfBirth,Degree,Institution,ActiveSince,Enrolled,Graduated,Rating,About,LessonPrice,ImagePath")] Teacher teacher)
        {
            if (id != teacher.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(teacher.ID))
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
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teachers
                .SingleOrDefaultAsync(m => m.ID == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacher = await _context.Teachers.SingleOrDefaultAsync(m => m.ID == id);
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExists(int id)
        {
            return _context.Teachers.Any(e => e.ID == id);
        }
    }
}
