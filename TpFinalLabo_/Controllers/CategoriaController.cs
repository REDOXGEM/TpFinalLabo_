using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using TpFinalLabo_.Data;
using TpFinalLabo_.Models;

namespace TpFinalLabo_.Controllers
{
   
        public class CategoriaController : Controller
        {
            private readonly ApplicationDbContext _context;

            public CategoriaController(ApplicationDbContext context)
            {
                _context = context;
            }


            public async Task<IActionResult> Lista()
            {
                return View(await _context.Categorias.ToListAsync());
            }

            public async Task<IActionResult> Detalles(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var categoria = await _context.Categorias
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (categoria == null)
                {
                    return NotFound();
                }

                return View(categoria);
            }

            public IActionResult Crear()
            {
                return View();
            }




            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Crear([Bind("Id,Nombre")] Categoria categoria)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(categoria);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Lista));
                }
                return View(categoria);
            }


            public async Task<IActionResult> Editar(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var categoria = await _context.Categorias.FindAsync(id);
                if (categoria == null)
                {
                    return NotFound();
                }
                return View(categoria);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Editar(int id, [Bind("Id,Nombre")] Categoria categoria)
            {
                if (id != categoria.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(categoria);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!categoriaExists(categoria.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Lista));
                }
                return View(categoria);
            }

            [HttpGet]
            public async Task<IActionResult> Eliminar(int? id)
            {
                var categoria = await _context.Categorias.FirstAsync(e => e.Id == id);
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Lista));
            }




            private bool categoriaExists(int id)
            {
                return _context.Categorias.Any(e => e.Id == id);
            }
        }
    }

