using BookLibrary.aspnetcore.Data;
using BookLibrary.aspnetcore.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.aspnetcore.API.Controllers
{
    [Route("api/[controller]")]
    public class SecurityController : Controller
    {
        private readonly BookLibraryContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SecurityController(BookLibraryContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // POST api/security/CreateAsync
        [HttpPost]
        public async Task<IdentityResult> CreateAsync([FromBody]ApplicationUser user)
        {
            return await _userManager.CreateAsync(user, user.Password);
        }
   
}
}
