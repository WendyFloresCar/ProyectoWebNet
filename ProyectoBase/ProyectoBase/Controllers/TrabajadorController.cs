using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Data;
using ProyectoBase.Models.Clases;
using ProyectoBase.Models.Entidades;

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
            var trabajadores = await _context.Trabajador.Include(t => t.Empresa).ToListAsync();
            return View(trabajadores);
        }

        public async Task<IActionResult> Create(int id)
        {
            //combo Tipo de Documento
            var combo = new List<Combo>();
            combo.Add(new Combo { codigo = "DNI", descripcion = "DNI" });
            combo.Add(new Combo { codigo = "CXE", descripcion = "CARNET DE EXTRANJERÍA" });
            ViewData["cmbTipoDocumento"] = new SelectList(combo.OrderBy(t => t.descripcion), "codigo", "descripcion");

            //combo Empresas
            var empresas = _context.Empresa.ToList();
            ViewData["cmbEmpresas"] = new SelectList(empresas.OrderBy(t => t.razonSocial), "idEmpresa", "razonSocial");

            var trabajador = new Trabajador();
            if (id != 0)
            {
                trabajador = await _context.Trabajador.FindAsync(id);
            }
            else
            {
                trabajador.fechaNacimiento = DateTime.Now.Date;
                trabajador.estadoCivil = "S";
            }
            return PartialView(trabajador);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Trabajador model)
        {
            if (model.idTrabajador != 0)
            {
                //editar
                _context.Update(model);
            }
            else
            {
                //crear
                model.estado = true;
                model.fechaCreacion = DateTime.Now.Date;
                model.horaCreacion = DateTime.Now.TimeOfDay;
                _context.Add(model);
            }
            await _context.SaveChangesAsync();
            return Json(true);
        }
    }
}