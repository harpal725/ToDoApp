using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Book.Context;
using Book.Model;

namespace Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookStoresController : ControllerBase
    {
        private readonly Dbcontexts _context;

        public BookStoresController(Dbcontexts context)
        {
            _context = context;
        }

        // GET: api/BookStores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookStore>>> Getbooks()
        {
            return await _context.books.ToListAsync();
        }

        // GET: api/BookStores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookStore>> GetBookStore(int id)
        {
            var bookStore = await _context.books.FindAsync(id);

            if (bookStore == null)
            {
                return NotFound();
            }

            return bookStore;
        }

        // PUT: api/BookStores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookStore(int id, BookStore bookStore)
        {
            if (id != bookStore.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookStore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookStoreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BookStores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookStore>> PostBookStore(BookStore bookStore)
        {
            _context.books.Add(bookStore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookStore", new { id = bookStore.Id }, bookStore);
        }

        // DELETE: api/BookStores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookStore(int id)
        {
            var bookStore = await _context.books.FindAsync(id);
            if (bookStore == null)
            {
                return NotFound();
            }

            _context.books.Remove(bookStore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookStoreExists(int id)
        {
            return _context.books.Any(e => e.Id == id);
        }
    }
}
