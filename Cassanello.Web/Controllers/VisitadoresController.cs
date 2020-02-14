using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cassanello.Web.Datos;
using Cassanello.Web.Datos.Entidades;

namespace Cassanello.Web.Controllers
{
    public class VisitadoresController : Controller
    {
        private readonly DataContext _context;

        public VisitadoresController(DataContext context)
        {
            _context = context;
        }

        // GET: Visitadores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Visitadores.ToListAsync());
        }

        // GET: Visitadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitador = await _context.Visitadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitador == null)
            {
                return NotFound();
            }

            return View(visitador);
        }

        // GET: Visitadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Visitadores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Document,FirstName,LastName,CellPhone")] Visitador visitador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visitador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(visitador);
        }

        // GET: Visitadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitador = await _context.Visitadores.FindAsync(id);
            if (visitador == null)
            {
                return NotFound();
            }
            return View(visitador);
        }

        // POST: Visitadores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Document,FirstName,LastName,CellPhone")] Visitador visitador)
        {
            if (id != visitador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitadorExists(visitador.Id))
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
            return View(visitador);
        }

        // GET: Visitadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitador = await _context.Visitadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitador == null)
            {
                return NotFound();
            }

            return View(visitador);
        }

        // POST: Visitadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visitador = await _context.Visitadores.FindAsync(id);
            _context.Visitadores.Remove(visitador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitadorExists(int id)
        {
            return _context.Visitadores.Any(e => e.Id == id);
        }
    }
}
