using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Raspberry.Models;

namespace Raspberry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScannersController : ControllerBase
    {
        private readonly ScanContext _context;

        public ScannersController(ScanContext context)
        {
            _context = context;
        }

        // GET: api/Scanners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scanner>>> GetScanners()
        {
            if (_context.Scanners == null)
            {
                return NotFound();
            }
            return await _context.Scanners.ToListAsync();
        }

        // GET: api/Scanners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Scanner>> GetScanner(int id)
        {
            if (_context.Scanners == null)
            {
                return NotFound();
            }
            var scanner = await _context.Scanners.FindAsync(id);

            if (scanner == null)
            {
                return NotFound();
            }

            return scanner;
        }

        // PUT: api/Scanners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScanner(int id, Scanner scanner)
        {
            if (id != scanner.id)
            {
                return BadRequest();
            }

            _context.Entry(scanner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScannerExists(id))
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

        // POST: api/Scanners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Scanner>> PostTodoItem(Scanner scanner)
        {
            _context.Scanners.Add(scanner);
            await _context.SaveChangesAsync();

            //    return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetScanner), new { id = scanner.id }, scanner);
        }
        //public async Task<ActionResult<Scanner>> PostScanner(Scanner scanner)
        //{
        //    if (_context.Scanners == null)
        //    {
        //        return Problem("Entity set 'ScanContext.Scanners'  is null.");
        //    }
        //    _context.Scanners.Add(scanner);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetScanner", new { scanner.id }, scanner);
        //}

        // DELETE: api/Scanners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScanner(int id)
        {
            if (_context.Scanners == null)
            {
                return NotFound();
            }
            var scanner = await _context.Scanners.FindAsync(id);
            if (scanner == null)
            {
                return NotFound();
            }

            _context.Scanners.Remove(scanner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScannerExists(int id)
        {
            return (_context.Scanners?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
