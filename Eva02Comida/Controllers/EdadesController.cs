using Eva02Comida.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eva02Comida.Controllers
{
    public class EdadesController : Controller
    {
        private readonly AppDbContext _context;

        public EdadesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var edades = _context.tblEdades.ToList();
            return View(edades);
        }


        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Edad E)
        {
            if (E == null) return View();
            if (ModelState.IsValid)
            {
                _context.Add(E);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }



        [HttpGet]
        public IActionResult Editar(int IdEdad)
        {
            var Edad = _context.tblEdades.FirstOrDefault(e => e.Id == IdEdad);
            if (Edad == null) return NotFound();
            else
            {
                return View(Edad);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Editar(Edad Edad)
        {
            if (ModelState.IsValid)
            {
                _context.Update(Edad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Edad);
        }



        [HttpGet]
        public IActionResult Eliminar(int IdEdad)
        {
            var Edad = _context.tblEdades.FirstOrDefault(e => e.Id == IdEdad);
            if (Edad == null) return NotFound();
            else
            {
                return View(Edad);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Eliminar(Edad Edad)
        {
            _context.Remove(Edad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
