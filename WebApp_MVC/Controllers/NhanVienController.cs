using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp_MVC.Extensions;
using WebApp_MVC.Models;

namespace WebApp_MVC.Controllers
{
    public class NhanVienController : Controller
    {
        private readonly AppDbContext _context;

        public NhanVienController(AppDbContext context)
        {
            // Khởi tạo DBcontext luôn
           // _context = new AppDbContext();
           // DI
           _context = context;
        }

        // GET: NhanVien
        public async Task<IActionResult> Index()
        {
              return _context.NhanViens != null ? 
                          View(await _context.NhanViens.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.NhanViens'  is null.");
        }

        // GET: NhanVien/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.NhanViens == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // GET: NhanVien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NhanVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ten,Tuoi,Role,Email,Luong,TrangThai")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                nhanVien.Id = Guid.NewGuid();
                _context.Add(nhanVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhanVien);
        }

        // GET: NhanVien/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.NhanViens == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens.FindAsync(id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            HttpContext.Session.Set<NhanVien>("nhanviencu", nhanVien);

            return View(nhanVien);
        }

        // POST: NhanVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Ten,Tuoi,Role,Email,Luong,TrangThai")] NhanVien nhanVien)
        {
            if (id != nhanVien.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienExists(nhanVien.Id))
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
            return View(nhanVien);
        }

        public IActionResult RollBack(Guid id)
        {
            var nvc = HttpContext.Session.Get<NhanVien>("nhanviencu");

            if(nvc != null)
            {
                if(nvc.Id == id)
                {
                    _context.NhanViens.Update(nvc);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        // GET: NhanVien/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.NhanViens == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // POST: NhanVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.NhanViens == null)
            {
                return Problem("Entity set 'AppDbContext.NhanViens'  is null.");
            }
            var nhanVien = await _context.NhanViens.FindAsync(id);
            if (nhanVien != null)
            {
                _context.NhanViens.Remove(nhanVien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienExists(Guid id)
        {
          return (_context.NhanViens?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
