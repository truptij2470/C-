using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationTrupi.Models;

namespace WebApplicationTrupi.Controllers
{
    public class BookstablesController : Controller
    {
        private readonly BooksContext _context;

        public BookstablesController(BooksContext context)
        {
            _context = context;
        }

        // GET: Bookstables
        public async Task<IActionResult> Index()
        {
              return _context.Bookstables != null ? 
                          View(await _context.Bookstables.ToListAsync()) :
                          Problem("Entity set 'BooksContext.Bookstables'  is null.");
        }

        // GET: Bookstables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bookstables == null)
            {
                return NotFound();
            }

            var bookstable = await _context.Bookstables
                .FirstOrDefaultAsync(m => m.Bookid == id);
            if (bookstable == null)
            {
                return NotFound();
            }

            return View(bookstable);
        }

        // GET: Bookstables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bookstables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Bookid,Bookname,Bookauthor,Bookprice")] Bookstable bookstable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookstable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookstable);
        }

        // GET: Bookstables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bookstables == null)
            {
                return NotFound();
            }

            var bookstable = await _context.Bookstables.FindAsync(id);
            if (bookstable == null)
            {
                return NotFound();
            }
            return View(bookstable);
        }

        // POST: Bookstables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Bookid,Bookname,Bookauthor,Bookprice")] Bookstable bookstable)
        {
            if (id != bookstable.Bookid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookstable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookstableExists(bookstable.Bookid))
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
            return View(bookstable);
        }

        // GET: Bookstables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bookstables == null)
            {
                return NotFound();
            }

            var bookstable = await _context.Bookstables
                .FirstOrDefaultAsync(m => m.Bookid == id);
            if (bookstable == null)
            {
                return NotFound();
            }

            return View(bookstable);
        }

        // POST: Bookstables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bookstables == null)
            {
                return Problem("Entity set 'BooksContext.Bookstables'  is null.");
            }
            var bookstable = await _context.Bookstables.FindAsync(id);
            if (bookstable != null)
            {
                _context.Bookstables.Remove(bookstable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookstableExists(int id)
        {
          return (_context.Bookstables?.Any(e => e.Bookid == id)).GetValueOrDefault();
        }
    }
}
