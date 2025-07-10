using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoMVC.Data;
using DemoMVC.Models;

namespace DemoMVC.Controllers
{
    public class EmloyeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmloyeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Emloyee
        public async Task<IActionResult> Index()
        {
            return View(await _context.Emloyees.ToListAsync());
        }

        // GET: Emloyee/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emloyee = await _context.Emloyees
                .FirstOrDefaultAsync(m => m.EmloyeeId == id);
            if (emloyee == null)
            {
                return NotFound();
            }

            return View(emloyee);
        }

        // GET: Emloyee/Create
        public IActionResult Create()
        {
            // Tải danh sách mã nhân viên ra bộ nhớ, xử lý bằng LINQ thường (C#)
            var lastNumber = _context.Emloyees
            .Where(e => e.EmloyeeId.StartsWith("PS") && e.EmloyeeId.Length == 5)
            .AsEnumerable() // chuyển từ LINQ to SQL -> LINQ to Object
            .Select(e =>
            {
                bool success = int.TryParse(e.EmloyeeId.Substring(2), out int num);
                return success ? num : 0;
            })
            .DefaultIfEmpty(0)
            .Max();

            string newID = "PS" + (lastNumber + 1).ToString("D3");

            var emloyee = new Emloyee
            {
                EmloyeeId = newID
            };

        return View(emloyee);
}


        // POST: Emloyee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmloyeeId,FullName,Address")] Emloyee emloyee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emloyee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emloyee);
        }

        // GET: Emloyee/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emloyee = await _context.Emloyees.FindAsync(id);
            if (emloyee == null)
            {
                return NotFound();
            }
            return View(emloyee);
        }

        // POST: Emloyee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EmloyeeId,FullName,Address")] Emloyee emloyee)
        {
            if (id != emloyee.EmloyeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emloyee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmloyeeExists(emloyee.EmloyeeId))
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
            return View(emloyee);
        }

        // GET: Emloyee/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emloyee = await _context.Emloyees
                .FirstOrDefaultAsync(m => m.EmloyeeId == id);
            if (emloyee == null)
            {
                return NotFound();
            }

            return View(emloyee);
        }

        // POST: Emloyee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var emloyee = await _context.Emloyees.FindAsync(id);
            if (emloyee != null)
            {
                _context.Emloyees.Remove(emloyee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmloyeeExists(string id)
        {
            return _context.Emloyees.Any(e => e.EmloyeeId == id);
        }
    }
}
