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

    public class CustomerPublicController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerPublicController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CustomerPublic/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerPublic/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
    }
}
