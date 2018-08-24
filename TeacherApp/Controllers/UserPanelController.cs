﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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


        public ActionResult UserLogin()
        {
            return View();
        }

        public IActionResult UserSignUp()
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