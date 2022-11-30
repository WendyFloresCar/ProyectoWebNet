using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Data;

namespace ProyectoBase.Controllers
{
    public class TrabajadorController : Controller
    {
        private readonly ProyectoDbContext _context;

        public TrabajadorController(ProyectoDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var trabajadores = await _context.Trabajador.ToListAsync();
            return View(trabajadores);
        }
    }
}