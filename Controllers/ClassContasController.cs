using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Acounting_basic.Data;
using Acounting_basic.Models;

namespace Acounting_basic.Controllers
{
    public class ClassContasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClassContasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClassContas
        public async Task<IActionResult> Index()
        {
            return View(await _context.classes.ToListAsync());
        }

        // GET: ClassContas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classConta = await _context.classes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classConta == null)
            {
                return NotFound();
            }

            return View(classConta);
        }

        // GET: ClassContas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClassContas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,num_ordem,Descricao")] ClassConta classConta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classConta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classConta);
        }

        // GET: ClassContas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classConta = await _context.classes.FindAsync(id);
            if (classConta == null)
            {
                return NotFound();
            }
            return View(classConta);
        }

        // POST: ClassContas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,num_ordem,Descricao")] ClassConta classConta)
        {
            if (id != classConta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classConta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassContaExists(classConta.Id))
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
            return View(classConta);
        }

        // GET: ClassContas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classConta = await _context.classes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classConta == null)
            {
                return NotFound();
            }

            return View(classConta);
        }

        // POST: ClassContas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classConta = await _context.classes.FindAsync(id);
            if (classConta != null)
            {
                _context.classes.Remove(classConta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassContaExists(int id)
        {
            return _context.classes.Any(e => e.Id == id);
        }
    }
}
