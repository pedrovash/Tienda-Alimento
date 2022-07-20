using Eva02Comida.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eva02Comida.Controllers
{
    public class EspeciesController : Controller
    {
        public readonly AppDbContext _context;

        public EspeciesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var especies = _context.tblEspecies.ToList();
            return View(especies);
        }

         [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Especie Es)
        {
            if (Es == null) return View();
            if (ModelState.IsValid)
            {
                _context.Add(Es);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        [HttpGet]
        public IActionResult Editar(int IdEspecie)
        {
            var Especie = _context.tblEspecies.FirstOrDefault(es => es.Id == IdEspecie);
            if (Especie == null) return NotFound();
            else
            {
                return View(Especie);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Editar(Especie Especie)
        {
            if (ModelState.IsValid)
            {
                _context.Update(Especie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Especie);
        }

        [HttpGet]
        public IActionResult Eliminar(int IdEspecie)
        {
            var Especie = _context.tblEspecies.FirstOrDefault(es => es.Id == IdEspecie);
            if (Especie == null) return NotFound();
            else
            {
                return View(Especie);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(Especie Especie)
        {
            _context.Remove(Especie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
