using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp_MVC.Models;
using WebApp_MVC.Repositories.Interface;
using WebApp_MVC.Repositories.Repository;

namespace WebApp_MVC.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly ISanPhamRepo _repo;
        private readonly IDanhMucRepo _repoDM;

        public SanPhamController()
        {
            _repo = new SanPhamRepo();
            _repoDM = new DanhMucRepo();
        }

        // GET: SanPham
        public  IActionResult Index()
        {
            var appDbContext = _repo.GetAll();
            return View(appDbContext);
        }

        // GET: SanPham/Details/5
        public IActionResult Details(Guid? id)
        {
            var sps = _repo.GetAll();
            if (id == null || sps == null)
            {
                return NotFound();
            }

            var sanPham = _repo.GetByID(id ?? Guid.Empty);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: SanPham/Create
        public IActionResult Create()
        {
            ViewData["IDDanhMuc"] = new SelectList(_repoDM.GetAll(), "ID", "TenDanhMuc");
            return View();
        }

        // POST: SanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                sanPham.ID = Guid.NewGuid();
                _repo.Add(sanPham);
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDDanhMuc"] = new SelectList(_repoDM.GetAll(), "ID", "TenDanhMuc", sanPham.IDDanhMuc);
            return View(sanPham);
        }

        // GET: SanPham/Edit/5
        public IActionResult Edit(Guid? id)
        {
            var sps = _repo.GetAll();
            if (id == null || sps == null)
            {
                return NotFound();
            }

            var sanPham = _repo.GetByID(id ?? Guid.Empty);
            if (sanPham == null)
            {
                return NotFound();
            }
            ViewData["IDDanhMuc"] = new SelectList(_repoDM.GetAll(), "ID", "TenDanhMuc", sanPham.IDDanhMuc);
            return View(sanPham);
        }

        // POST: SanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, SanPham sanPham)
        {
            if (id != sanPham.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repo.Update(sanPham);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanPham.ID))
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
            ViewData["IDDanhMuc"] = new SelectList(_repoDM.GetAll(), "ID", "TenDanhMuc", sanPham.IDDanhMuc);
            return View(sanPham);
        }

        // GET: SanPham/Delete/5
        public IActionResult Delete(Guid? id)
        {
            var sps = _repo.GetAll();
            if (id == null || sps == null)
            {
                return NotFound();
            }

            var sanPham = _repo.GetByID(id ?? Guid.Empty);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var sps = _repo.GetAll();
            if (sps == null)
            {
                return Problem("Entity set 'AppDbContext.SanPhams'  is null.");
            }
            var result = _repo.Delete(id);
            if (result == false)
            {
                return Problem($"Delete IdSanPham: {id} problem.");
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamExists(Guid id)
        {
          return _repo.GetAll().Any(e => e.ID == id);
        }
    }
}
