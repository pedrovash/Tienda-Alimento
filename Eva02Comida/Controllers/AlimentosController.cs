using Eva02Comida.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Eva02Comida.Controllers
{
    public class AlimentosController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public AlimentosController(AppDbContext context, IWebHostEnvironment environment)

        {
            _context = context;
            _environment = environment;
        }
        public IActionResult Index()
        {
            var Alimentos = _context.tblAlimentos
               .Include(a => a.Marca).Include(a => a.Edad)
               .Include(a => a.Especie).Include(a => a.Formato).ToList();
            return View(Alimentos);
        }


        
        public IActionResult CrearAlimento()
        {
            ViewData["Marcas"] = new SelectList(_context.tblMarcas.ToList(), "Id", "Name");
            ViewData["Edades"] = new SelectList(_context.tblEdades.ToList(), "Id", "Name");
            ViewData["Especies"] = new SelectList(_context.tblEspecies.ToList(), "Id", "Name");
            ViewData["Formatos"] = new SelectList(_context.tblFormatos.ToList(), "Id", "Name");
;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CrearAlimento(Alimento A)
        {
            if (ModelState.IsValid)
            {
                if (A.ImagenFile == null) A.imagenUrl = "nodisponible.png";
                else
                {
                    string wwwRootPath = _environment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(A.ImagenFile.FileName);
                    string extension = Path.GetExtension(A.ImagenFile.FileName);
                    A.imagenUrl = fileName + DateTime.Now.ToString("ddMMyyyyHHmmss") + extension; 

                    string path = Path.Combine(wwwRootPath + "/img/" + A.imagenUrl);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await A.ImagenFile.CopyToAsync(fileStream);
                    }
                }
                _context.Add(A);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(A);
            }

        }


        [HttpGet]
        public IActionResult Editar(int IdAlimento)
        {
            ViewData["Marcas"] = new SelectList(_context.tblMarcas.ToList(), "Id", "Name");
            ViewData["Edades"] = new SelectList(_context.tblEdades.ToList(), "Id", "Name");
            ViewData["Especies"] = new SelectList(_context.tblEspecies.ToList(), "Id", "Name");
            ViewData["Formatos"] = new SelectList(_context.tblFormatos.ToList(), "Id", "Name");
            var Alimento = _context.tblAlimentos.FirstOrDefault(a => a.Id == IdAlimento);
            if (Alimento == null) return NotFound();
            else
            {
                return View(Alimento);
            }


        }
        [HttpPost]
        public async Task<IActionResult> Editar(Alimento A)
        {
            if (ModelState.IsValid)
            {
                if (A.ImagenFile == null) A.imagenUrl = "nodisponible.png";
                else
                {
                    string wwwRootPath = _environment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(A.ImagenFile.FileName);
                    string extension = Path.GetExtension(A.ImagenFile.FileName);
                    A.imagenUrl = fileName + DateTime.Now.ToString("ddMMyyyyHHmmss") + extension; //foto08062022131545.png 

                    string path = Path.Combine(wwwRootPath + "/img/" + A.imagenUrl);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await A.ImagenFile.CopyToAsync(fileStream);
                    }
                }
                _context.Update(A);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(A);
        }



        [HttpGet]
        public IActionResult Eliminar(int IdAlimento)
        {
            var Alimento = _context.tblAlimentos.FirstOrDefault(a => a.Id == IdAlimento);
            if (Alimento == null) return NotFound();
            else
            {
                return View(Alimento);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Eliminar(Alimento A)
        {
            _context.Remove(A);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
