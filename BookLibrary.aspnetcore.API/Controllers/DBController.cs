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
    public class DBController : Controller
    {
        private readonly BookLibraryContext _context;

        public DBController(BookLibraryContext context)
        {
            _context = context;
        }

        // GET api/db
        [HttpGet]
        public async Task<bool> InitDB()
        {
            DbInitializer.Initialize(_context);
            return await Task.FromResult(true);
        }

    }
}
