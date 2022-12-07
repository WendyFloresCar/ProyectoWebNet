using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Data;
using ProyectoBase.Models.Clases;
using ProyectoBase.Models.Entidades;
using ProyectoBase.Models.Entidades.SP;

namespace ProyectoBase.Controllers
{
    public class TrabajadorController : Controller
    {
        private readonly ProyectoDbContext _context;

        public TrabajadorController(ProyectoDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index2(int idEmpresa, string estadoCivil, DateTime? fechaInicio, DateTime? fechaFinal)
        {
            if (fechaInicio == null || fechaFinal == null)
            {
                fechaInicio = DateTime.Now.Date.AddMonths(-1);
                fechaFinal = DateTime.Now.Date.AddMonths(1);
                ViewBag.fechaInicio = fechaInicio;
                ViewBag.fechaFinal = fechaFinal;
            }
            else
            {
                ViewBag.fechaInicio = fechaInicio;
                ViewBag.fechaFinal = fechaFinal;
            }
            //Empresas
            var empresas = _context.Empresa.ToList();
            empresas.Add(new Empresa { idEmpresa = 0, razonSocial = " Seleccione" });
            ViewData["cmbEmpresas"] = new SelectList(empresas.OrderBy(t => t.razonSocial), "idEmpresa", "razonSocial", idEmpresa);

            //Estado Civil
            var combo = new List<Combo>();
            combo.Add(new Combo { codigo = "", descripcion = " Seleccione" });
            combo.Add(new Combo { codigo = "S", descripcion = "Soltero" });
            combo.Add(new Combo { codigo = "C", descripcion = "Casado" });
            combo.Add(new Combo { codigo = "V", descripcion = "Viudo" });
            ViewData["cmbEstadoCivil"] = new SelectList(combo.OrderBy(t => t.descripcion), "codigo", "descripcion", estadoCivil);

            var trabajadores = await _context.sp_trabajador.FromSqlRaw("sp_trabajador @p0,@p1,@p2,@p3", idEmpresa, estadoCivil, fechaInicio.Value.ToString("yyyy-MM-dd"), fechaFinal.Value.ToString("yyyy-MM-dd")).ToListAsync();
            return View(trabajadores);
        }

        public async Task<IActionResult> Index()
        {
            var trabajadores = await _context.Trabajador.Include(t => t.Empresa).ToListAsync();
            return View(trabajadores);
        }

        public async Task<IActionResult> Create(int id)
        {
            var trabajador = new Trabajador();
            var areasList = new List<Area>();
            if (id != 0)
            {
                //Actualizar
                trabajador = await _context.Trabajador.FindAsync(id);
                if (trabajador.idSede != null)
                {
                    areasList = await _context.Area.Where(t => t.idSede.Equals(trabajador.idSede)).ToListAsync();
                }
            }
            else
            {
                trabajador.fechaNacimiento = DateTime.Now.Date;
                trabajador.estadoCivil = "S";
            }

            //combo Tipo de Documento
            var combo = new List<Combo>();
            combo.Add(new Combo { codigo = "DNI", descripcion = "DNI" });
            combo.Add(new Combo { codigo = "CXE", descripcion = "CARNET DE EXTRANJERÍA" });
            ViewData["cmbTipoDocumento"] = new SelectList(combo.OrderBy(t => t.descripcion), "codigo", "descripcion");

            //combo Empresas
            var empresas = _context.Empresa.ToList();
            ViewData["cmbEmpresas"] = new SelectList(empresas.OrderBy(t => t.razonSocial), "idEmpresa", "razonSocial");

            //combo Sede
            var sede = _context.Sede.ToList();
            sede.Add(new Sede { idSede = 0, descripcion = " Seleccione" });
            ViewData["cmbSede"] = new SelectList(sede.OrderBy(t => t.descripcion), "idSede", "descripcion", trabajador.idSede);

            //combo Area
            var area = areasList;
            area.Add(new Area { idArea = 0, descripcion = " Seleccione" });
            ViewData["cmbArea"] = new SelectList(area.OrderBy(t => t.descripcion), "idArea", "descripcion", trabajador.idArea);
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

        public async Task<IActionResult> ListAreas(int id)
        {
            var areas = _context.Area.Where(t => t.idSede.Equals(id)).ToList();
            areas.Add(new Area { idArea = 0, descripcion = " Seleccione" });
            return Json(areas);
        }
    }
}