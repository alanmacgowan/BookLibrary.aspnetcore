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
    public class PublishersController : Controller
    {
        private readonly BookLibraryContext _context;

        public PublishersController(BookLibraryContext context)
        {
            _context = context;
        }

        // GET api/publishers
        [HttpGet]
        public async Task<IEnumerable<Publisher>> GetAll()
        {
            var publishers = _context.Publishers
                                             .AsNoTracking();

            return await publishers.ToListAsync();
        }

        // GET api/publishers/5
        [HttpGet("{id}")]
        public async Task<Publisher> Get(int id)
        {
            var publisher = await _context.Publishers
                               .AsNoTracking()
                               .SingleOrDefaultAsync(m => m.ID == id);

            return publisher;
        }

        // POST api/publishers
        [HttpPost]
        public async Task<int> Post([FromBody]Publisher publisher)
        {
            _context.Add(publisher);
            return await _context.SaveChangesAsync();
        }

        // PUT api/publishers/5
        [HttpPut("{id}")]
        public async Task<int> Put(int id, [FromBody]Publisher publisher)
        {
            _context.Update(publisher);
            return await _context.SaveChangesAsync();
        }

        // DELETE api/publishers/5
        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
            var publisher = _context.Publishers.SingleOrDefault(m => m.ID == id);
            _context.Publishers.Remove(publisher);
            return await _context.SaveChangesAsync();
        }

        [HttpGet("count")]
        public async Task<int> GetCount()
        {
            var count = await _context.Publishers.CountAsync();

            return count;
        }

    }
}
