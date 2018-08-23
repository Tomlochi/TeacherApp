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


        public ActionResult AdminPanelLogin()
        {
            return View();
        }


    }
   
}