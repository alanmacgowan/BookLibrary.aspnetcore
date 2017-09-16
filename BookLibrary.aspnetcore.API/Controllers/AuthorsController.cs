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
    public class AuthorsController : Controller
    {
        private readonly BookLibraryContext _context;

        public AuthorsController(BookLibraryContext context)
        {
            _context = context;
        }

        // GET api/authors
        [HttpGet]
        public async Task<IEnumerable<Author>> GetAll()
        {
            var authors = _context.Authors
                                             .Include(b => b.Books)
                                             .AsNoTracking();

            return await authors.ToListAsync();
        }

        // GET api/authors/5
        [HttpGet("{id}")]
        public async Task<Author> Get(int id)
        {
            var author = await _context.Authors
                               .Include(b => b.Books)
                               .AsNoTracking()
                               .SingleOrDefaultAsync(m => m.ID == id);

            return author;
        }

        // POST api/authors
        [HttpPost]
        public void Post([FromBody]Author author)
        {
            _context.Add(author);
            _context.SaveChanges();
        }

        // PUT api/authors/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Author author)
        {
            _context.Update(author);
            _context.SaveChanges();
        }

        // DELETE api/authors/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var author = _context.Authors.SingleOrDefault(m => m.ID == id);
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }

        [HttpGet("count")]
        public async Task<int> GetCount()
        {
            var count = await _context.Authors.CountAsync();

            return count;
        }

    }
}
