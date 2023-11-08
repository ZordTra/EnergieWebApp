using EnergieWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnergieWebApp.Models;
using System.Diagnostics;

namespace EnergieWebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Ongeldig()
        {
            return View();
        }
        public IActionResult Login(string Username, string Password)
        {
            Account? a = _context.Accounts
                .Where(acc => acc.Username == Username && acc.Password == Password).FirstOrDefault();



            

            if (a != null)
            {
                User? u = _context.Users.Where(u => u.AccountId == a.Id).FirstOrDefault();
                Admin? ad = _context.Admins.Where(u => u.AccountId == a.Id).FirstOrDefault();
                if (u != null)
                {
                    return RedirectToAction("User", "Home");
                }
                else if(ad != null) 
                {
                    return RedirectToAction("Admin", "Home");

                }
            }
            
            {
                return RedirectToAction("Error");
            }
        }
        public IActionResult Error()
        {
            ViewData["ErrorMessage"] = "We kunnen niet aanmelden bij uw account, probeer opnieuw";
    
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Create() 
        {
            return RedirectToAction("Create", "User");
        }
    }

}
