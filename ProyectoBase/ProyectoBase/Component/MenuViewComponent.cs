using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Data;

namespace ProyectoBase.Component
{
    public class MenusViewComponent : ViewComponent
    {
        private readonly ProyectoDbContext _context;

        public MenusViewComponent(ProyectoDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var perfiles = await _context.perfiles.ToListAsync();

            //admin
            var perfilUsuarioAdmin = perfiles.Where(t => t.descripcion.Equals("userStandard")).FirstOrDefault();
            return View(perfilUsuarioAdmin);
        }
    }
}