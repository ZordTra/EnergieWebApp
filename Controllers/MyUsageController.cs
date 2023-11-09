using EnergieWebApp.Data;
using EnergieWebApp.Models;
using EnergieWebApp.Modelview;
using Microsoft.AspNetCore.Mvc;

namespace EnergieWebApp.Controllers
{
    public class MyUsageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyUsageController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int accID)
        {


            User u = _context.Users.Where(u => u.AccountId == accID).FirstOrDefault();
            List<DayData> DayDatas = _context.DayDatas.Where(x => x.Account.Id == u.Id).OrderBy(x => x.Date).ToList();
            
            
            DateTime weekAgo = DateTime.Now.AddDays(-7);
            List<DayData> DayDatasWeek = _context.DayDatas.Where(x => x.Account.Id == u.Id && x.Date >= weekAgo).OrderBy(x => x.Date).ToList();
            int? weekAverage = null;
            
            if (DayDatasWeek.Count > 0)
            {
                foreach (DayData dayData in DayDatasWeek)
                {
                    weekAverage = (weekAverage ?? 0) + dayData.Kwh;
                }
                weekAverage = weekAverage / DayDatasWeek.Count;
            }


            MyUsageViewModel model = new MyUsageViewModel()
            {
                accID = accID,
                DayDatas = DayDatas,
                AverageKwh = weekAverage,
            };
            return View(model);
        }
    }
}
