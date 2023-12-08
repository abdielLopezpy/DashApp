using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using appDash.Data;
using appDash.Models;

namespace appDash.Controllers
{
    public class EmployeeAttendanceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeAttendanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeAttendance
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EmployeeAttendances.Include(e => e.Employee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EmployeeAttendance/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmployeeAttendances == null)
            {
                return NotFound();
            }

            var employeeAttendance = await _context.EmployeeAttendances
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeAttendance == null)
            {
                return NotFound();
            }

            return View(employeeAttendance);
        }

        // GET: EmployeeAttendance/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name");
            return View();
        }

        // POST: EmployeeAttendance/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,EntryTime,ExitTime")] EmployeeAttendance employeeAttendance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeAttendance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", employeeAttendance.EmployeeId);
            return View(employeeAttendance);
        }

        // GET: EmployeeAttendance/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmployeeAttendances == null)
            {
                return NotFound();
            }

            var employeeAttendance = await _context.EmployeeAttendances.FindAsync(id);
            if (employeeAttendance == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", employeeAttendance.EmployeeId);
            return View(employeeAttendance);
        }

        // POST: EmployeeAttendance/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,EntryTime,ExitTime")] EmployeeAttendance employeeAttendance)
        {
            if (id != employeeAttendance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeAttendance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeAttendanceExists(employeeAttendance.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", employeeAttendance.EmployeeId);
            return View(employeeAttendance);
        }

        // GET: EmployeeAttendance/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmployeeAttendances == null)
            {
                return NotFound();
            }

            var employeeAttendance = await _context.EmployeeAttendances
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeAttendance == null)
            {
                return NotFound();
            }

            return View(employeeAttendance);
        }

        // POST: EmployeeAttendance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmployeeAttendances == null)
            {
                return Problem("Entity set 'ApplicationDbContext.EmployeeAttendances'  is null.");
            }
            var employeeAttendance = await _context.EmployeeAttendances.FindAsync(id);
            if (employeeAttendance != null)
            {
                _context.EmployeeAttendances.Remove(employeeAttendance);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeAttendanceExists(int id)
        {
          return (_context.EmployeeAttendances?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
