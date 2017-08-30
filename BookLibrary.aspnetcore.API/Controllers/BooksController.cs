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
        public IEnumerable<Book> GetAll()
        {
            var bookLibraryContext = _context.Books
                                             .Include(b => b.Author)
                                             .Include(b => b.Publisher)
                                             .AsNoTracking();

            return bookLibraryContext.ToList();
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            var book = _context.Books
                    .Include(b => b.Author)
                    .Include(b => b.Publisher)
                    .AsNoTracking()
                    .SingleOrDefault(m => m.ID == id);

            return book;
        }

        // POST api/books
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
