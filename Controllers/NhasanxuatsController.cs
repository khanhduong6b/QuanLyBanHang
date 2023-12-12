using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QuanLyBanHang.Models;

namespace QuanLyBanHang.Controllers
{
    public class NhasanxuatsController : Controller
    {
        private readonly QlbhContext _context;

        public NhasanxuatsController(QlbhContext context)
        {
            _context = context;
        }

        // GET: Nhasanxuats
        public async Task<IActionResult> Index()
        {
              return _context.Nhasanxuats != null ? 
                          View(await _context.Nhasanxuats.ToListAsync()) :
                          Problem("Entity set 'QlbhContext.Nhasanxuats'  is null.");
        }

        // GET: Nhasanxuats/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Nhasanxuats == null)
            {
                return NotFound();
            }

            var nhasanxuat = await _context.Nhasanxuats
                .FirstOrDefaultAsync(m => m.Mansx == id);
            if (nhasanxuat == null)
            {
                return NotFound();
            }

            return View(nhasanxuat);
        }

        // GET: Nhasanxuats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nhasanxuats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mansx,Tennsx,Diachi")] Nhasanxuat nhasanxuat)
        {


            if (ModelState.IsValid)
            {
                if (_context.Nhasanxuats.Find(nhasanxuat.Mansx) != null)
                {
                    ModelState.AddModelError("Mansx", "Mã nhà sản xuất bị trùng");
                }
                else
                {
                    _context.Add(nhasanxuat);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(nhasanxuat);
        }

        // GET: Nhasanxuats/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Nhasanxuats == null)
            {
                return NotFound();
            }

            var nhasanxuat = await _context.Nhasanxuats.FindAsync(id);
            if (nhasanxuat == null)
            {
                return NotFound();
            }
            return View(nhasanxuat);
        }

        // POST: Nhasanxuats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Mansx,Tennsx,Diachi")] Nhasanxuat nhasanxuat)
        {
            if (id != nhasanxuat.Mansx)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhasanxuat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhasanxuatExists(nhasanxuat.Mansx))
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
            return View(nhasanxuat);
        }

        // GET: Nhasanxuats/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            var a = _context.Hanghoas.Where(k => k.Mansx == id).ToList().Count;

            if (id == null || _context.Nhasanxuats == null)
            {
                return NotFound();
            }

            var nhasanxuat = await _context.Nhasanxuats
                .FirstOrDefaultAsync(m => m.Mansx == id);
            if (nhasanxuat == null)
            {
                return NotFound();
            }
            if (a <= 0)
                ViewBag.flagDelete = true;
            else
                ViewBag.flagDelete = false;

            return View(nhasanxuat);

        }

        // POST: Nhasanxuats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {

            if (_context.Nhasanxuats == null)
            {
                return Problem("Entity set 'QlbhContext.Nhasanxuats'  is null.");
            }
            var nhasanxuat = await _context.Nhasanxuats.FindAsync(id);

            if (nhasanxuat != null)
            {
                if (ModelState.IsValid)
                {
                    _context.Nhasanxuats.Remove(nhasanxuat);


                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(nhasanxuat);
        }

        private bool NhasanxuatExists(string id)
        {
          return (_context.Nhasanxuats?.Any(e => e.Mansx == id)).GetValueOrDefault();
        }
    }
}
