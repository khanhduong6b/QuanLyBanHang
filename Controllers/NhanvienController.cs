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
    public class NhanvienController : Controller
    {
        private readonly QlbhContext _context;

        public NhanvienController(QlbhContext context)
        {
            _context = context;
        }

        // GET: Nhanvien
        public async Task<IActionResult> Index()
        {
              return _context.Nhanviens != null ? 
                          View(await _context.Nhanviens.ToListAsync()) :
                          Problem("Entity set 'QlbhContext.Nhanviens'  is null.");
        }

        // GET: Nhanvien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Nhanviens == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanviens
                .FirstOrDefaultAsync(m => m.Manv == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // GET: Nhanvien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nhanvien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Manv,Tennv,Ngaysinh,Phai,Diachi,Password")] Nhanvien nhanvien)
        {
            if (ModelState.IsValid)
            {
                if (!NhanvienExists(nhanvien.Manv))
                {
                    _context.Add(nhanvien);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else ModelState.AddModelError("Manv", "Mã nhân viên bị trùng");
            }
            return View(nhanvien);
        }

        // GET: Nhanvien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Nhanviens == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanviens.FindAsync(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            return View(nhanvien);
        }

        // POST: Nhanvien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Manv,Tennv,Ngaysinh,Phai,Diachi,Password")] Nhanvien nhanvien)
        {
            if (id != nhanvien.Manv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanvien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanvienExists(nhanvien.Manv))
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
            return View(nhanvien);
        }

        // GET: Nhanvien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            var a = _context.Phieugiaohangs.Where(k => k.Manv == id).ToList().Count;
            if (id == null || _context.Nhanviens == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanviens
                .FirstOrDefaultAsync(m => m.Manv == id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            if (a <= 0)
                ViewBag.flagDelete = true;
            else
                ViewBag.flagDelete = false;
            return View(nhanvien);
        }

        // POST: Nhanvien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Nhanviens == null)
            {
                return Problem("Entity set 'QlbhContext.Nhanviens'  is null.");
            }
            var nhanvien = await _context.Nhanviens.FindAsync(id);
            if (nhanvien != null)
            {
                _context.Nhanviens.Remove(nhanvien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanvienExists(string id)
        {
          return (_context.Nhanviens?.Any(e => e.Manv == id)).GetValueOrDefault();
        }
    }
}
