using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnergieWebApp.Data;
using EnergieWebApp.Models;

namespace EnergieWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayDatasApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DayDatasApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DayDatasApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DayData>>> GetDayDatas()
        {
          if (_context.DayDatas == null)
          {
              return NotFound();
          }
            return await _context.DayDatas.ToListAsync();
        }

        // GET: api/DayDatasApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DayData>> GetDayData(int id)
        {
          if (_context.DayDatas == null)
          {
              return NotFound();
          }
            var dayData = await _context.DayDatas.FindAsync(id);

            if (dayData == null)
            {
                return NotFound();
            }

            return dayData;
        }

        // PUT: api/DayDatasApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDayData(int id, DayData dayData)
        {
            if (id != dayData.Id)
            {
                return BadRequest();
            }

            _context.Entry(dayData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DayDataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DayDatasApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DayData>> PostDayData(DayData dayData)
        {
          if (_context.DayDatas == null)
          {
              return Problem("Entity set 'ApplicationDbContext.DayDatas'  is null.");
          }
            _context.DayDatas.Add(dayData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDayData", new { id = dayData.Id }, dayData);
        }

        // DELETE: api/DayDatasApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDayData(int id)
        {
            if (_context.DayDatas == null)
            {
                return NotFound();
            }
            var dayData = await _context.DayDatas.FindAsync(id);
            if (dayData == null)
            {
                return NotFound();
            }

            _context.DayDatas.Remove(dayData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DayDataExists(int id)
        {
            return (_context.DayDatas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
