using Mariala.Areas.Admin.ViewModels;
using Mariala.DAL;
using Mariala.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mariala.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;
        private const int LIMIT = 5;
        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int page= 1)
        {
            if (page < 1) return BadRequest();
            int count = await _context.Employees.CountAsync();
            int totalPages = (int) Math.Ceiling((decimal) count / LIMIT);
            IEnumerable<Employee> employees = await _context.Employees.Skip((page - 1) * LIMIT).Take(LIMIT).ToListAsync();

            return View( new PaginationVM<Employee> { CurrentPage = page, TotalPages = totalPages, Items = employees});
        }

        public async Task<IActionResult> Create()
        {
            return View( new );
        }

        
    }
}
