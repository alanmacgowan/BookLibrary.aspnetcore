using BookLibrary.aspnetcore.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.aspnetcore.API.Controllers
{
    [Route("api/[controller]")]
    public class DBController : Controller
    {
        private readonly BookLibraryContext _context;

        public DBController(BookLibraryContext context)
        {
            _context = context;
        }

        // GET api/db
        [HttpGet]
        public bool InitDB()
        {
            DbInitializer.Initialize(_context);
            return true;
        }

    }
}
