using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using appDash.Data;


namespace appDash.Controllers
{



public class BlogPublicController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlogPublicController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Blog
        public async Task<IActionResult> Index()
        {
              return _context.Blog != null ? 
                          View(await _context.Blog.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Blog'  is null.");
        }

        // GET: Blog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Blog == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }
    }
}