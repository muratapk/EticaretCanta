using EticaretCantaApi.Data;
using EticaretCantaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace EticaretCantaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly Baglanti _context;

        public CategoryController(Baglanti context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable>>GetCategory()
        {
            return await _context.Categories.ToListAsync();
        }
        [HttpGet("id")]
        public async Task<ActionResult<Categories>>GetCategory(int id)
        {
            return await _context.Categories.FindAsync(id);
        }
        [HttpDelete("id")]
        public async Task<ActionResult<Categories>> DeleteCategory(int id)
        {
            var result = _context.Categories.Where(p => p.Category_Id == id).FirstOrDefault();
            if(result!=null)
            {
                _context.Categories.Remove(result);
                _context.SaveChanges();
            }

            return result;
        }
        [HttpPut("id")]
        public async Task<ActionResult<Categories>> PutCategory(int id,Categories categories)
        {
            var result = _context.Categories.Where(p => p.Category_Id == id).FirstOrDefault();
            if (result != null)
            {
                result.Category_Name = categories.Category_Name;
               
                _context.SaveChanges();
            }

            return result;
        }
        [HttpPost("id")]
        public async Task<ActionResult> AddCategory([FromBody]Categories categories)
        {
             _context.Categories.Add(categories);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategory), new { Id = categories.Category_Id }, categories);
        }
    }
}
