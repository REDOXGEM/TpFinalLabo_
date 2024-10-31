using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TpFinalLabo_.Models;
using TpFinalLabo_.Data;
using System.Diagnostics;

namespace TpFinalLabo_.Controllers
{

    public class PedidoController : Controller
    {
        private readonly ApplicationDbContext _context;


        public PedidoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Lista()
        {
            var appDbContext = _context.Pedidos.Include(e => e.cliente)
                                               .Include(e => e.producto);
            return View(await appDbContext.ToListAsync());
        }

        public async Task<IActionResult> Detalles(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(e => e.cliente)
                .Include(e => e.producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }
          
            return View(pedido);
        }

        public IActionResult Crear()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Nombre");
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("IdCliente,IdProducto,Cantidad,Calle,Altura,Localidad,Provincia,Fecha,Estado")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "Pedido registrado correctamente.";
                return RedirectToAction(nameof(Lista));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Nombre", pedido.Idcliente);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Nombre", pedido.Idproducto);
            return View(pedido);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Nombre", pedido.Idcliente);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Nombre", pedido.Idproducto);
            return View(pedido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,Cantidad,Calle,Altura,Localidad,Provincia,Fecha,Estado,IdCliente,IdProducto")] Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!pedidoExists(pedido.Id))
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

            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Nombre", pedido.Idcliente);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Nombre", pedido.Idproducto);
            return View(pedido);
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int? id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        private bool pedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.Id == id);
        }
    }
}
