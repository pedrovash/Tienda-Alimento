using Eva02Comida.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eva02Comida.Controllers
{
    public class MarcasController : Controller
    {
        private readonly AppDbContext _context;

        public MarcasController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var marcas = _context.tblMarcas.ToList();
            return View(marcas);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Marca M)
        {
            if (M == null) return View();
            if (ModelState.IsValid)
            {
                _context.Add(M);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        
        public IActionResult Editar(int IdMarca)
        {
            var Marca = _context.tblMarcas.FirstOrDefault(m => m.Id == IdMarca);
            if (Marca == null) return NotFound();
            else
            {
                return View(Marca);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Marca Marca)
        {
            if (ModelState.IsValid)
            {
                _context.Update(Marca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Marca);
        }



        [HttpGet]

        public IActionResult Eliminar(int IdMarca)
        {
            var Marca = _context.tblMarcas.FirstOrDefault(m =>m.Id == IdMarca);
            if(Marca == null) return NotFound();
            else
            {
                return View(Marca);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Eliminar(Marca Marca)
        {
            _context.Remove(Marca);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
