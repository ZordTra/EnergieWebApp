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
    public class TypeDevicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TypeDevicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TypeDevices
        public async Task<IActionResult> Index()
        {
              return _context.TypeDevices != null ? 
                          View(await _context.TypeDevices.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TypeDevices'  is null.");
        }

        // GET: TypeDevices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TypeDevices == null)
            {
                return NotFound();
            }

            var typeDevice = await _context.TypeDevices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeDevice == null)
            {
                return NotFound();
            }

            return View(typeDevice);
        }

        // GET: TypeDevices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeDevices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] TypeDevice typeDevice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeDevice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeDevice);
        }

        // GET: TypeDevices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TypeDevices == null)
            {
                return NotFound();
            }

            var typeDevice = await _context.TypeDevices.FindAsync(id);
            if (typeDevice == null)
            {
                return NotFound();
            }
            return View(typeDevice);
        }

        // POST: TypeDevices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] TypeDevice typeDevice)
        {
            if (id != typeDevice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeDevice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeDeviceExists(typeDevice.Id))
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
            return View(typeDevice);
        }

        // GET: TypeDevices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypeDevices == null)
            {
                return NotFound();
            }

            var typeDevice = await _context.TypeDevices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeDevice == null)
            {
                return NotFound();
            }

            return View(typeDevice);
        }

        // POST: TypeDevices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypeDevices == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TypeDevices'  is null.");
            }
            var typeDevice = await _context.TypeDevices.FindAsync(id);
            if (typeDevice != null)
            {
                _context.TypeDevices.Remove(typeDevice);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeDeviceExists(int id)
        {
          return (_context.TypeDevices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
