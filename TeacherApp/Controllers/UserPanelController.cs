using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TeacherApp.Models;

namespace TeacherApp.Controllers
{
    public class UserPanelController : Controller
    {
        private readonly TeacherAppContext _context;

        public UserPanelController(TeacherAppContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult UserLogin()
        {
            return View();
        }



        [HttpPost]
        public int UserLogin(string username, string password)
        {
            Person p = (from Person in _context.Persons
                                   where Person.Email == username && Person.Password == password
                                   select Person).FirstOrDefault();

            if (p != null)
            {
                return p.ID;
            }
            return 0;
        }

        public IActionResult UserSignUp()
        {
            return View();
        }

        public IActionResult SearchBestOffer()
        {
            return View();
        }

        //[HttpPost]
        //public JsonResult SearchBestOffer(string courseName)
        //{
        //    // join query - the join is represented in teacherCourse model defention iteself
        //    var c = from teacherCourse in _context.TeachersCourses
        //            where teacherCourse.Course.CourseName.ToLower() == courseName.ToLower()
        //            orderby teacherCourse.Teacher.LessonPrice ascending
        //            select new
        //            {
        //                teacher = teacherCourse.Teacher.FullName(),
        //                price = teacherCourse.Teacher.LessonPrice,
        //                rating = teacherCourse.Teacher.Rating
        //            };
        //    if (c == null)
        //    {
        //        return null;
        //    }
        //    return Json(c.ToList());
        //}
        [HttpPost]
        public IActionResult SearchBestOffer(string courseName)
        {
            List<Dictionary<string, string>> results = new List<Dictionary<string, string>>();
            ViewData["courseName"] = courseName;
            ViewBag.results = results;
            if (courseName == null) { return View(); }
            // join query - the join is represented in teacherCourse model defention iteself
            var c = from teacherCourse in _context.TeachersCourses
                    where teacherCourse.Course.CourseName.ToLower() == courseName.ToLower()
                    orderby teacherCourse.Teacher.LessonPrice ascending
                    select new
                    {
                        teacher = teacherCourse.Teacher.FullName(),
                        price = teacherCourse.Teacher.LessonPrice,
                        rating = teacherCourse.Teacher.Rating,
                    };
            if (c == null) { return View(); }
            foreach (var result in c)
            {
                results.Add(new Dictionary<string, string>() { { "teacher", result.teacher },{ "price", result.price.ToString() }, { "rating", result.rating.ToString() } });
                //results.Add("teacher", result.teacher);
                //results.Add("price", result.price.ToString());
                //results.Add("rating", result.rating.ToString());
            };
            return View();
        }

        public IActionResult UserDashboard()
        {
                return View();
        }


        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserSignUp([Bind("ID,FirstName,LastName,Password,Phone,Gender,Email,Address,DateOfBirth,Degree,Institution")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }


        // GET: Reviews/Create
        public IActionResult CreateReview()
        {
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReview([Bind("ReviewID,Published,Rating,TeacherID,ReviewContent")] Review review)
        {
            if (ModelState.IsValid)
            {
                _context.Add(review);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(review);
        }


        // GET: People
        public async Task<IActionResult> PersonIndex()
        {
            return View(await _context.Persons.ToListAsync());
        }

        // GET: People/Details/5
        public async Task<IActionResult> PersonDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons
                .SingleOrDefaultAsync(m => m.ID == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }


        // GET: People/Edit/5
        public async Task<IActionResult> EditPerson(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons.SingleOrDefaultAsync(m => m.ID == id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPerson(int id, [Bind("ID,FirstName,LastName,Password,Phone,Gender,Email,Address,DateOfBirth,IsAdmin")] Person person)
        {
            if (id != person.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.ID))
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
            return View(person);
        }

        // GET: People/Delete/5
        public async Task<IActionResult> DeletePerson(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons
                .SingleOrDefaultAsync(m => m.ID == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.Persons.SingleOrDefaultAsync(m => m.ID == id);
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(int id)
        {
            return _context.Persons.Any(e => e.ID == id);
        }

        public async Task<IActionResult> userTeacherIndex(string searchString)
        {

            var teachers = from teacher in _context.Teachers
                           select teacher;

            if (!String.IsNullOrEmpty(searchString))
            {
                teachers = teachers.Where(t => t.FullName().Contains(searchString));
            }

            return View(await teachers.ToListAsync());

        }
    }
}