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
    public class MinhaEmpresasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MinhaEmpresasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MinhaEmpresas
        public async Task<IActionResult> Index()
        {
            return View(await _context.minhaEmpresas.ToListAsync());
        }

        // GET: MinhaEmpresas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var minhaEmpresa = await _context.minhaEmpresas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (minhaEmpresa == null)
            {
                return NotFound();
            }

            return View(minhaEmpresa);
        }

        // GET: MinhaEmpresas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MinhaEmpresas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome_empresa,Email_empresa,Telefone_empresa,Celular_empresa,Endereco_empresa,NUIT_empresa,Nome_responsavel,Email_responsavel")] MinhaEmpresa minhaEmpresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(minhaEmpresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(minhaEmpresa);
        }

        // GET: MinhaEmpresas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var minhaEmpresa = await _context.minhaEmpresas.FindAsync(id);
            if (minhaEmpresa == null)
            {
                return NotFound();
            }
            return View(minhaEmpresa);
        }

        // POST: MinhaEmpresas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome_empresa,Email_empresa,Telefone_empresa,Celular_empresa,Endereco_empresa,NUIT_empresa,Nome_responsavel,Email_responsavel")] MinhaEmpresa minhaEmpresa)
        {
            if (id != minhaEmpresa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(minhaEmpresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MinhaEmpresaExists(minhaEmpresa.Id))
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
            return View(minhaEmpresa);
        }

        // GET: MinhaEmpresas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var minhaEmpresa = await _context.minhaEmpresas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (minhaEmpresa == null)
            {
                return NotFound();
            }

            return View(minhaEmpresa);
        }

        // POST: MinhaEmpresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var minhaEmpresa = await _context.minhaEmpresas.FindAsync(id);
            if (minhaEmpresa != null)
            {
                _context.minhaEmpresas.Remove(minhaEmpresa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MinhaEmpresaExists(int id)
        {
            return _context.minhaEmpresas.Any(e => e.Id == id);
        }
    }
}
