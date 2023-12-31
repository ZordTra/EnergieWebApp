﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EnergieWebApp.Data;
using EnergieWebApp.Models;
using EnergieWebApp.Modelview;
using System.Dynamic;

namespace EnergieWebApp.Controllers
{
    public class HouseholdsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HouseholdsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Households
        public async Task<IActionResult> Index()
        {
              return _context.Households != null ? 
                          View(await _context.Households.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Households'  is null.");
        }

        // GET: Households/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            // Fetch a list of devices from your data source
            var devices = _context.Devices.ToList();
            Household household = _context.Households.ToList().Where(h => h.Id == id).First();

            // Pass the list of devices to the view
            dynamic model = new ExpandoObject();
            model.Household = household;
            model.Devices = devices.Where(d => d.HouseholdId == id).ToList();
            
            return View(model);
        }

        // GET: Households/Create
        public IActionResult Create()
        {
            // Fetch a list of devices from your data source
            var devices = _context.Devices.ToList();

            // Pass the list of devices to the view
            ViewBag.Devices = new SelectList(devices, "Id", "Name");

            return View();
        }

        // POST: Households/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("Id,Name,Devices")] Household household)
        public async Task<IActionResult> Create(Household household)
        {
            if (ModelState.IsValid)
            {
                _context.Add(household);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(household);
        }

        // GET: Households/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Households == null)
            {
                return NotFound();
            }

            var household = await _context.Households.FindAsync(id);
            if (household == null)
            {
                return NotFound();
            }
            // Fetch a list of devices from your data source
            var devices = _context.Devices.ToList();

            // Pass the list of devices to the view
            dynamic model = new ExpandoObject();
            model.Household = household;
            model.Devices = devices;  
            return View(model);
        }

        // POST: Households/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Household household)
        {
            if (id != household.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(household);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HouseholdExists(household.Id))
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
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    // Log or print the validation errors
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            return View(household);
        }

        // GET: Households/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Households == null)
            {
                return NotFound();
            }

            var household = await _context.Households
                .FirstOrDefaultAsync(m => m.Id == id);
            if (household == null)
            {
                return NotFound();
            }

            return View(household);
        }

        // POST: Households/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Households == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Households'  is null.");
            }
            var household = await _context.Households.FindAsync(id);
            if (household != null)
            {
                _context.Households.Remove(household);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HouseholdExists(int id)
        {
          return (_context.Households?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
