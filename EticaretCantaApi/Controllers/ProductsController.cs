using EticaretCantaApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace EticaretCantaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly Baglanti _context;

        public ProductsController(Baglanti context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable>>GetProduct()
        {
            return await _context.Products.Include(p => p.Category).Include(p => p.Sub_Category).ToListAsync();
        }
    }
}
