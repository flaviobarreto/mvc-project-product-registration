using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cadastro.Infrastructure.Data.Common;
using Cadastro.ViewModels;

namespace Cadastro.Controllers
{
    public class ProductsController : Controller
    {
        private readonly RegisterContext _context;

        public ProductsController(RegisterContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductViewModels.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productViewModels = await _context.ProductViewModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productViewModels == null)
            {
                return NotFound();
            }

            return View(productViewModels);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Produto,Valor,Status")] ProductViewModels productViewModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productViewModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productViewModels);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productViewModels = await _context.ProductViewModels.FindAsync(id);
            if (productViewModels == null)
            {
                return NotFound();
            }
            return View(productViewModels);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Produto,Valor,Status")] ProductViewModels productViewModels)
        {
            if (id != productViewModels.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productViewModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductViewModelsExists(productViewModels.Id))
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
            return View(productViewModels);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productViewModels = await _context.ProductViewModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productViewModels == null)
            {
                return NotFound();
            }

            return View(productViewModels);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productViewModels = await _context.ProductViewModels.FindAsync(id);
            _context.ProductViewModels.Remove(productViewModels);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductViewModelsExists(int id)
        {
            return _context.ProductViewModels.Any(e => e.Id == id);
        }
    }
}
