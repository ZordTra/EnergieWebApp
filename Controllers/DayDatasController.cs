using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EnergieWebApp.Data;
using EnergieWebApp.Models;

namespace EnergieWebApp.Controllers
{
    public class DayDatasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DayDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DayDatas
        public async Task<IActionResult> Index()
        {
              return _context.DayDatas != null ? 
                          View(await _context.DayDatas.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.DayDatas'  is null.");
        }

        // GET: DayDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DayDatas == null)
            {
                return NotFound();
            }

            var dayData = await _context.DayDatas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dayData == null)
            {
                return NotFound();
            }

            return View(dayData);
        }

        // GET: DayDatas/Create
        public IActionResult Create(int accID)
        {
            CreateDayDataModel m = new CreateDayDataModel();
            m.accID = accID;
            return View(m);
        }

        // POST: DayDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("accID,Date,Kwh")] CreateDayDataModel dayData)
        {
            
            if (ModelState.IsValid)
            {

                User user = _context.Users.Where(x => x.AccountId == dayData.accID).FirstOrDefault();
                DayData day = new DayData
                {
                    Account = user,
                    Kwh = dayData.Kwh,
                    Date = dayData.Date

                };
                _context.Add(day);
                await _context.SaveChangesAsync();
                return RedirectToAction("Close");
            }

            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    // Log or print the validation errors
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            CreateDayDataModel m = new CreateDayDataModel();
            m.accID = dayData.accID;
            return View(m);
        }

        // GET: DayDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DayDatas == null)
            {
                return NotFound();
            }

            var dayData = await _context.DayDatas.FindAsync(id);
            if (dayData == null)
            {
                return NotFound();
            }
            return View(dayData);
        }

        // POST: DayDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Kwh")] DayData dayData)
        {
            if (id != dayData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dayData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DayDataExists(dayData.Id))
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
            return View(dayData);
        }

        // GET: DayDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DayDatas == null)
            {
                return NotFound();
            }

            var dayData = await _context.DayDatas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dayData == null)
            {
                return NotFound();
            }

            return View(dayData);
        }

        // POST: DayDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DayDatas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DayDatas'  is null.");
            }
            var dayData = await _context.DayDatas.FindAsync(id);
            if (dayData != null)
            {
                _context.DayDatas.Remove(dayData);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DayDataExists(int id)
        {
          return (_context.DayDatas?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public ActionResult Close()
        {
            return View();

        }
    }
}
