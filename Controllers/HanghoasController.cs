using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyBanHang.Models;

namespace QuanLyBanHang.Controllers
{
    public class HanghoasController : Controller
    {
        private readonly QlbhContext _context;

        public HanghoasController(QlbhContext context)
        {
            _context = context;
        }

        // GET: Hanghoas
        public async Task<IActionResult> Index()
        {
            var qlbhContext = _context.Hanghoas.Include(h => h.MaloaiNavigation).Include(h => h.MansxNavigation);
            return View(await qlbhContext.ToListAsync());
        }

        // GET: Hanghoas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Hanghoas == null)
            {
                return NotFound();
            }

            var hanghoa = await _context.Hanghoas
                .Include(h => h.MaloaiNavigation)
                .Include(h => h.MansxNavigation)
                .FirstOrDefaultAsync(m => m.Mahang == id);
            if (hanghoa == null)
            {
                return NotFound();
            }

            return View(hanghoa);
        }

        // GET: Hanghoas/Create
        public IActionResult Create()
        {
            ViewData["Maloai"] = new SelectList(_context.Loaihanghoas, "Maloai", "Maloai");
            ViewData["Mansx"] = new SelectList(_context.Nhasanxuats, "Mansx", "Mansx");
            return View();
        }

        // POST: Hanghoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mahang,Tenhang,Donvitinh,Dongia,Hinh,Maloai,Mansx")] Hanghoa hanghoa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hanghoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Maloai"] = new SelectList(_context.Loaihanghoas, "Maloai", "Maloai", hanghoa.Maloai);
            ViewData["Mansx"] = new SelectList(_context.Nhasanxuats, "Mansx", "Mansx", hanghoa.Mansx);
            return View(hanghoa);
        }

        // GET: Hanghoas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Hanghoas == null)
            {
                return NotFound();
            }

            var hanghoa = await _context.Hanghoas.FindAsync(id);
            if (hanghoa == null)
            {
                return NotFound();
            }
            ViewData["Maloai"] = new SelectList(_context.Loaihanghoas, "Maloai", "Maloai", hanghoa.Maloai);
            ViewData["Mansx"] = new SelectList(_context.Nhasanxuats, "Mansx", "Mansx", hanghoa.Mansx);
            return View(hanghoa);
        }

        // POST: Hanghoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Mahang,Tenhang,Donvitinh,Dongia,Hinh,Maloai,Mansx")] Hanghoa hanghoa)
        {
            if (id != hanghoa.Mahang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hanghoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HanghoaExists(hanghoa.Mahang))
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
            ViewData["Maloai"] = new SelectList(_context.Loaihanghoas, "Maloai", "Maloai", hanghoa.Maloai);
            ViewData["Mansx"] = new SelectList(_context.Nhasanxuats, "Mansx", "Mansx", hanghoa.Mansx);
            return View(hanghoa);
        }

        // GET: Hanghoas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Hanghoas == null)
            {
                return NotFound();
            }

            var hanghoa = await _context.Hanghoas
                .Include(h => h.MaloaiNavigation)
                .Include(h => h.MansxNavigation)
                .FirstOrDefaultAsync(m => m.Mahang == id);
            if (hanghoa == null)
            {
                return NotFound();
            }

            return View(hanghoa);
        }

        // POST: Hanghoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Hanghoas == null)
            {
                return Problem("Entity set 'QlbhContext.Hanghoas'  is null.");
            }
            var hanghoa = await _context.Hanghoas.FindAsync(id);
            if (hanghoa != null)
            {
                _context.Hanghoas.Remove(hanghoa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HanghoaExists(string id)
        {
          return (_context.Hanghoas?.Any(e => e.Mahang == id)).GetValueOrDefault();
        }
    }
}
