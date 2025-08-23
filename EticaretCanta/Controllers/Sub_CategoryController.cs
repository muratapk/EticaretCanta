using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EticaretCanta.Data;
using EticaretCanta.Models;

namespace EticaretCanta.Controllers
{
    public class Sub_CategoryController : Controller
    {
        private readonly Baglanti _context;

        public Sub_CategoryController(Baglanti context)
        {
            _context = context;
        }

        // GET: Sub_Category
        public async Task<IActionResult> Index()
        {
            var baglanti = _context.Sub_Categories.Include(s => s.Category);
            return View(await baglanti.ToListAsync());
        }

        // GET: Sub_Category/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sub_Category = await _context.Sub_Categories
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.Sub_Category_Id == id);
            if (sub_Category == null)
            {
                return NotFound();
            }

            return View(sub_Category);
        }

        // GET: Sub_Category/Create
        public IActionResult Create()
        {
            ViewData["Category_Id"] = new SelectList(_context.Categories, "Category_Id", "Category_Name");
            return View();
        }

        // POST: Sub_Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sub_Category_Id,Sub_Category_Name,Category_Id")] Sub_Category sub_Category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sub_Category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Category_Id"] = new SelectList(_context.Categories, "Category_Id", "Category_Name", sub_Category.Category_Id);
            return View(sub_Category);
        }

        // GET: Sub_Category/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sub_Category = await _context.Sub_Categories.FindAsync(id);
            if (sub_Category == null)
            {
                return NotFound();
            }
            ViewData["Category_Id"] = new SelectList(_context.Categories, "Category_Id", "Category_Name", sub_Category.Category_Id);
            return View(sub_Category);
        }

        // POST: Sub_Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Sub_Category_Id,Sub_Category_Name,Category_Id")] Sub_Category sub_Category)
        {
            if (id != sub_Category.Sub_Category_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sub_Category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Sub_CategoryExists(sub_Category.Sub_Category_Id))
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
            ViewData["Category_Id"] = new SelectList(_context.Categories, "Category_Id", "Category_Name", sub_Category.Category_Id);
            return View(sub_Category);
        }

        // GET: Sub_Category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sub_Category = await _context.Sub_Categories
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.Sub_Category_Id == id);
            if (sub_Category == null)
            {
                return NotFound();
            }

            return View(sub_Category);
        }

        // POST: Sub_Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sub_Category = await _context.Sub_Categories.FindAsync(id);
            if (sub_Category != null)
            {
                _context.Sub_Categories.Remove(sub_Category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Sub_CategoryExists(int id)
        {
            return _context.Sub_Categories.Any(e => e.Sub_Category_Id == id);
        }
    }
}
