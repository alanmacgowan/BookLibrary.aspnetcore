using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookLibrary.aspnetcore.Data;
using Microsoft.EntityFrameworkCore;
using BookLibrary.aspnetcore.Domain;

namespace BookLibrary.aspnetcore.API.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly BookLibraryContext _context;

        public BooksController(BookLibraryContext context)
        {
            _context = context;
        }

        // GET api/books
        [HttpGet]
        public async Task<IEnumerable<Book>> GetAll()
        {
            var books = _context.Books
                                .Include(b => b.Author)
                                .Include(b => b.Publisher)
                                .AsNoTracking();

            return await books.ToListAsync();
        }

        [HttpGet("count")]
        public async Task<int> GetCount()
        {
            var count = await _context.Books.CountAsync();

            return count;
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public async Task<Book> Get(int id)
        {
            var book = await _context.Books
                                     .Include(b => b.Author)
                                     .Include(b => b.Publisher)
                                     .AsNoTracking()
                                     .SingleOrDefaultAsync(m => m.ID == id);

            return book;
        }

        // POST api/books
        [HttpPost]
        public async Task<int> Post([FromBody]Book book)
        {
            _context.Add(book);
            return await _context.SaveChangesAsync();
        }

        // PUT api/books/book
        [HttpPut("{book}")]
        public async Task<int> Put(int id, [FromBody]Book book)
        {
            _context.Update(book);
            return await _context.SaveChangesAsync();
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
            var book = _context.Books.SingleOrDefault(m => m.ID == id);
            _context.Books.Remove(book);
            return await _context.SaveChangesAsync();
        }
    }
}
