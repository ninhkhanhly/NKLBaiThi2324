using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NKLBaiThi2324.Models;

namespace NKLBaiThi2324.Controllers
{
    public class NKL425EmployeeController : Controller
    {
        private readonly LTQDD _context;

        public NKL425EmployeeController(LTQDD context)
        {
            _context = context;
        }

        // GET: NKL425Employee
        public async Task<IActionResult> Index()
        {
            return View(await _context.NKL425Employee.ToListAsync());
        }

        // GET: NKL425Employee/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nKL425Employee = await _context.NKL425Employee
                .FirstOrDefaultAsync(m => m.CCCD == id);
            if (nKL425Employee == null)
            {
                return NotFound();
            }

            return View(nKL425Employee);
        }

        // GET: NKL425Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NKL425Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CCCD,TenSinhVien,GioiTinh")] NKL425Employee nKL425Employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nKL425Employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nKL425Employee);
        }

        // GET: NKL425Employee/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nKL425Employee = await _context.NKL425Employee.FindAsync(id);
            if (nKL425Employee == null)
            {
                return NotFound();
            }
            return View(nKL425Employee);
        }

        // POST: NKL425Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CCCD,TenSinhVien,GioiTinh")] NKL425Employee nKL425Employee)
        {
            if (id != nKL425Employee.CCCD)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nKL425Employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NKL425EmployeeExists(nKL425Employee.CCCD))
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
            return View(nKL425Employee);
        }

        // GET: NKL425Employee/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nKL425Employee = await _context.NKL425Employee
                .FirstOrDefaultAsync(m => m.CCCD == id);
            if (nKL425Employee == null)
            {
                return NotFound();
            }

            return View(nKL425Employee);
        }

        // POST: NKL425Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var nKL425Employee = await _context.NKL425Employee.FindAsync(id);
            if (nKL425Employee != null)
            {
                _context.NKL425Employee.Remove(nKL425Employee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NKL425EmployeeExists(string id)
        {
            return _context.NKL425Employee.Any(e => e.CCCD == id);
        }
    }
}
