using Eva02Comida.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eva02Comida.Controllers
{
    public class FormatosController : Controller
    {
        public readonly AppDbContext _context;

        public FormatosController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var Formatos = _context.tblFormatos.ToList();
            return View(Formatos);
        }




         [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Crear(Formato Formato)
        {
            if (Formato == null) return View();

            if (ModelState.IsValid)
            {
                _context.Add(Formato);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(Formato);
        }


        [HttpGet]
        public IActionResult Editar(int IdFormato)
        {
            var Formato = _context.tblFormatos.FirstOrDefault(f => f.Id == IdFormato);
            if (Formato == null) return NotFound();
            else
            {
                return View(Formato);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Editar(Formato Formato)
        {
            if (ModelState.IsValid)
            {
                _context.Update(Formato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Formato);
        }


        [HttpGet]
        public IActionResult Eliminar(int IdFormato)
        {
            var Formato = _context.tblFormatos.FirstOrDefault(f => f.Id == IdFormato);
            if (Formato == null) return NotFound();
            else
            {
                return View(Formato);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(Formato Formato)
        {
            _context.Remove(Formato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
