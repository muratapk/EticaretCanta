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
    public class PicturesController : Controller
    {
        private readonly Baglanti _context;

        public PicturesController(Baglanti context)
        {
            _context = context;
        }

        // GET: Pictures
        public async Task<IActionResult> Index()
        {
            var baglanti = _context.Pictures.Include(p => p.Products);
            return View(await baglanti.ToListAsync());
        }

        // GET: Pictures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pictures = await _context.Pictures
                .Include(p => p.Products)
                .FirstOrDefaultAsync(m => m.Picture_Id == id);
            if (pictures == null)
            {
                return NotFound();
            }

            return View(pictures);
        }

        // GET: Pictures/Create
        public IActionResult Create()
        {
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Id");
            return View();
        }

        // POST: Pictures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Picture_Id,Name,Product_Id")] Pictures pictures,IFormFile ImageUpload)
        {
            if (ImageUpload == null || ImageUpload.Length > 500000)
            {
                return NotFound();
            }
            else
            {
                var uzanti = Path.GetExtension(ImageUpload.FileName);
                //dosya uzantısını al ali.jpg  .jpg dosyasın alacak
                string isimyeni = Guid.NewGuid().ToString() + uzanti;
                //yüklenen dosyaya yeni isim oluşturdum
                string yol = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/ImageUpload/" + isimyeni);
                using (var stream = new FileStream(yol, FileMode.Create))
                {
                    ImageUpload.CopyTo(stream);
                }
                pictures.Name = isimyeni;
            }








            if (ModelState.IsValid)
            {
                _context.Add(pictures);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Id", pictures.Product_Id);
            return View(pictures);
        }

        // GET: Pictures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pictures = await _context.Pictures.FindAsync(id);
            if (pictures == null)
            {
                return NotFound();
            }
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Id", pictures.Product_Id);
            return View(pictures);
        }

        // POST: Pictures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Picture_Id,Name,Product_Id")] Pictures pictures,IFormFile ImageUpload)
        {

            if(ImageUpload==null && ImageUpload.FileName.Length>500000)
            {
                return NotFound();
            }
            else
            {
                var uzanti = Path.GetExtension(ImageUpload.FileName);
                //dosya uzantısını al ali.jpg  .jpg dosyasın alacak
                string isimyeni=Guid.NewGuid().ToString() + uzanti;
                //yüklenen dosyaya yeni isim oluşturdum
                string yol=Path.Combine(Directory.GetCurrentDirectory()+"/wwwroot/ImageUpload/"+isimyeni);
                using (var stream =new FileStream(yol, FileMode.Create))
                {
                    ImageUpload.CopyTo(stream);
                }
                pictures.Name=isimyeni;
            }


            if (id != pictures.Picture_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pictures);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PicturesExists(pictures.Picture_Id))
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
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Id", pictures.Product_Id);
            return View(pictures);
        }

        // GET: Pictures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pictures = await _context.Pictures
                .Include(p => p.Products)
                .FirstOrDefaultAsync(m => m.Picture_Id == id);
            if (pictures == null)
            {
                return NotFound();
            }

            return View(pictures);
        }

        // POST: Pictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pictures = await _context.Pictures.FindAsync(id);
            if (pictures != null)
            {
                _context.Pictures.Remove(pictures);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PicturesExists(int id)
        {
            return _context.Pictures.Any(e => e.Picture_Id == id);
        }
    }
}
