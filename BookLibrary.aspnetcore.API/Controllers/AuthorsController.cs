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
            return await _context.Authors
                                  .Include(b => b.Books)
                                  .AsNoTracking()
                                  .ToListAsync();
        }

        // GET api/authors/5
        [HttpGet("{id}")]
        public async Task<Author> Get(int id)
        {
            return await _context.Authors
                                 .Include(b => b.Books)
                                 .AsNoTracking()
                                 .SingleOrDefaultAsync(m => m.ID == id);
        }

        // POST api/authors
        [HttpPost]
        public async Task<int> Post([FromBody]Author author)
        {
            _context.Add(author);
            return await _context.SaveChangesAsync();
        }

        // PUT api/authors/5
        [HttpPut("{id}")]
        public async Task<int> Put(int id, [FromBody]Author author)
        {
            _context.Update(author);
            return await _context.SaveChangesAsync();
        }

        // DELETE api/authors/5
        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
            var author = _context.Authors.SingleOrDefault(m => m.ID == id);
            _context.Authors.Remove(author);
            return await _context.SaveChangesAsync();
        }

        [HttpGet("count")]
        public async Task<int> GetCount()
        {
            return await _context.Authors.CountAsync();
        }

    }
}
