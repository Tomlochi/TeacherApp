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


        public IActionResult AdminPanelLogin()
        {
            return View();
        }
        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var authResult = (from person in _context.Persons where (person.Email == username && person.Password == password) select person).ToList();
            bool existUser = authResult.ToList().Any(person => person.Email == username);
            bool existPass = authResult.ToList().Any(person => person.Password == password);
            if (existUser && existPass)
            {
                return Redirect("/Home/Index");
            }
            else
            {
                ViewBag.Message = "invalid user or password!";
                return View();
            }
        }

    }

}