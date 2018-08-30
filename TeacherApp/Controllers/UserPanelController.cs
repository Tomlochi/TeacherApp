using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public bool UserLogin(string username, string password)
        {
            Person p = (from Person in _context.Persons
                                   where Person.Email == username && Person.Password == password
                                   select Person).FirstOrDefault();
            return p != null;
        }


        //[HttpPost]
        //public IActionResult UserLogin(string email, string password)
        //{
        //    var authResult = (from user in _context.Persons where (user.Email == email && user.Password == password) select user).ToList();
        //    bool existUser = authResult.ToList().Any(user => user.Email == email);
        //    bool existPass = authResult.ToList().Any(user => user.Password == password);
        //    if (existUser && existPass)
        //    {
        //        return Redirect("/Home/Index");
        //    }
        //    else
        //    {
        //        ViewBag.Message = "invalid user or password!";
        //        return View();
        //    }
        //}


        public IActionResult UserSignUp()
        {
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

    }
}