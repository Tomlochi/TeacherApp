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
    public class AdminPanelController : Controller
    {
        private readonly TeacherAppContext _context;

        public AdminPanelController(TeacherAppContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        // GET: Admin/Login
        public IActionResult AdminPanelLogin()
        {
            return View();
        }
        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Reset()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }

        // POST: AdminPanel/Dashboard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public bool AdminPanelLogin(string username, string password)
        {
            Person p = (from Person in _context.Persons
                        where Person.Email == username && Person.Password == password
                        select Person).FirstOrDefault();
            return p != null;
        }

        // GET: Teachers/Create
        public IActionResult CreateTeacher()
        {
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTeacher([Bind("ID,FirstName,LastName,Password,Phone,Gender,Email,Address,DateOfBirth,Degree,Institution,ActiveSince,Enrolled,Graduated,Rating,About,LessonPrice,ImagePath")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }



        // GET: Courses/Create
        public IActionResult CreateCourse()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCourse([Bind("CourseID,CourseName,Credits")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }



















    }

}