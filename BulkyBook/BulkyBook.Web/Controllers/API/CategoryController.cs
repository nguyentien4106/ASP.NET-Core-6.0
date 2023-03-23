using BulkyBook.Web.Data;
using BulkyBook.Web.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/category
        [HttpGet]
        public CategoryViewModel GetAll()
        {
            var result = new CategoryViewModel
            {
                Categories = _context.Categories
            };

            return result;
        }

        // GET: api/Category/id
        [HttpDelete("{id}")]
        public CategoryViewModel Delete(int? id)
        {
            if (id == null || id == 0) throw new EntryPointNotFoundException("Invalid id");

            var category = _context.Categories.Find(id);

            if (category == null) throw new EntryPointNotFoundException("Invalid id");

            _context.Categories.Remove(category);
            _context.SaveChanges();

            var result = new CategoryViewModel
            {
                Categories = _context.Categories
            };

            return result;
        }
    }
}
