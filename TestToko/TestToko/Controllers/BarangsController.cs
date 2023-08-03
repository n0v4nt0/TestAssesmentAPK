using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestToko.Models;

namespace TestToko.Controllers
{
    public class BarangsController : Controller
    {
        private readonly BarangContext _context;

        public BarangsController(BarangContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Barang.ToListAsync());
        }

        public async Task<IActionResult> Detail(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Barang
                .FirstOrDefaultAsync(m => m.IdBarang == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBarang,NamaBarang,HargaBarang,QtyBarang")] Barang products)
        {
            if (ModelState.IsValid)
            {
                products.Operator = TempData["OperatorName"].ToString();
                _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(products);
        }

        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Barang.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdBarang,NamaBarang,HargaBarang,QtyBarang,Operator")] Barang products)
        {
            if (id != products.IdBarang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    products.Operator = TempData["OperatorName"].ToString();
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.IdBarang))
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
            return View(products);
        }

        public async Task<IActionResult> Delete(String? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Barang
                .FirstOrDefaultAsync(m => m.IdBarang == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var products = await _context.Barang.FindAsync(id);
            _context.Barang.Remove(products);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(String id)
        {
            return _context.Barang.Any(e => e.IdBarang == id);
        }
    }
}