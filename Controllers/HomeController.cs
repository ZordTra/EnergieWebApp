using EnergieWebApp.Data;
using EnergieWebApp.Models;
using EnergieWebApp.Modelview;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EnergieWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

        }

        public IActionResult User(User user)
        {
            List<(String name, Double? score)> scores = new List<(string name, double? score)>();
            List<User> Users = _context.Users.ToList();
            DateTime weekAgo = DateTime.Now.AddDays(-7);
            foreach (User u in Users)
            {
                List<DayData> DayDatasWeek = _context.DayDatas.Where(x => x.Account.Id == u.Id && x.Date >= weekAgo).OrderBy(x => x.Date).ToList();
                double? weekAverage = null;
                if (DayDatasWeek.Count > 0)
                {
                    foreach (DayData dayData in DayDatasWeek)
                    {
                        weekAverage = (weekAverage ?? 0) + dayData.Kwh;
                    }
                    weekAverage = weekAverage / DayDatasWeek.Count;
                }

                scores.Add((u.Name, weekAverage));

            }

            UserHomeViewModel m = new UserHomeViewModel()
            {
                User = user,
                Scores = scores
            };
            return View(m);
        }

        public IActionResult Admin()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}