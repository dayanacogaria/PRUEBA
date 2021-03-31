using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba_S.Context;
using Prueba_S.Models;

namespace Prueba_S.Controllers
{
    public class VentasController : Controller
    {
        private readonly DatabaseContext _context;

        public VentasController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            var venta = _context.Ventas
                .Include(c => c.Cliente)
                .Include(c => c.Producto)
                .AsNoTracking();

            return View(await venta.ToListAsync());
        }

        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .Include(c => c.Cliente)
                .Include(c => c.Producto)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.id == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        private void PopulateClientesDropDownList(object selectedClient = null)
        {
            var departmentsQuery = from d in _context.Clientes
                                   orderby d.NomCliente
                                   select d;
            ViewBag.ClientsID = new SelectList(departmentsQuery.AsNoTracking(), "CodCliente", "NomCliente", selectedClient);
        }
        private void PopulateProductoDropDownList(object selectedClient = null)
        {
            var departmentsQuery = from d in _context.Productos
                                   orderby d.NomProducto
                                   select d;
            ViewBag.ProductID = new SelectList(departmentsQuery.AsNoTracking(), "CodProducto", "NomProducto", selectedClient);
        }
        // GET: Ventas/Create
        public IActionResult Create()
        {

            

            PopulateClientesDropDownList();
            PopulateProductoDropDownList();
            return View();
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,fecha,ValorUnitario,ValorTotal,Cantidad")] Venta venta, List<Producto> productos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(venta);
        }

        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                 .Include(c => c.Cliente)
                 .Include(c => c.Producto)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.id == id);
            if (venta == null)
            {
                return NotFound();
            }
         
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,fecha,ValorUnitario,ValorTotal,Cantidad")] Venta venta)
        {
            if (id != venta.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaExists(venta.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .FirstOrDefaultAsync(m => m.id == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            _context.Ventas.Remove(venta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

   
        private bool VentaExists(int id)
        {
            return _context.Ventas.Any(e => e.id == id);
        }




    }
}
