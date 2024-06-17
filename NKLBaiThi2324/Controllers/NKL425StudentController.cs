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
    public class NKL425StudentController : Controller
    {
        private readonly LTQDD _context;

        public NKL425StudentController(LTQDD context)
        {
            _context = context;
        }

        // GET: NKL425Student
        public async Task<IActionResult> Index()
        {
            return View(await _context.NKL425Student.ToListAsync());
        }

        // GET: NKL425Student/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nKL425Student = await _context.NKL425Student
                .FirstOrDefaultAsync(m => m.MASinhVien == id);
            if (nKL425Student == null)
            {
                return NotFound();
            }

            return View(nKL425Student);
        }

        // GET: NKL425Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NKL425Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MASinhVien,TenSinhVien,GioiTinh")] NKL425Student nKL425Student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nKL425Student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nKL425Student);
        }

        // GET: NKL425Student/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nKL425Student = await _context.NKL425Student.FindAsync(id);
            if (nKL425Student == null)
            {
                return NotFound();
            }
            return View(nKL425Student);
        }

        // POST: NKL425Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MASinhVien,TenSinhVien,GioiTinh")] NKL425Student nKL425Student)
        {
            if (id != nKL425Student.MASinhVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nKL425Student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NKL425StudentExists(nKL425Student.MASinhVien))
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
            return View(nKL425Student);
        }

        // GET: NKL425Student/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nKL425Student = await _context.NKL425Student
                .FirstOrDefaultAsync(m => m.MASinhVien == id);
            if (nKL425Student == null)
            {
                return NotFound();
            }

            return View(nKL425Student);
        }

        // POST: NKL425Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var nKL425Student = await _context.NKL425Student.FindAsync(id);
            if (nKL425Student != null)
            {
                _context.NKL425Student.Remove(nKL425Student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NKL425StudentExists(string id)
        {
            return _context.NKL425Student.Any(e => e.MASinhVien == id);
        }
    }
}
