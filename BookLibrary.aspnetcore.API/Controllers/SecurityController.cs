using BookLibrary.aspnetcore.Data;
using BookLibrary.aspnetcore.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookLibrary.aspnetcore.API.Controllers
{
    [Route("api/[controller]")]
    public class SecurityController : Controller
    {
        private readonly BookLibraryContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public SecurityController(BookLibraryContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // POST api/security/CreateAsync
        [HttpPost("CreateAsync")]
        public async Task<IdentityResult> CreateAsync([FromBody]ApplicationUser user)
        {
            return await _userManager.CreateAsync(user, user.Password);
        }

        [HttpPost("GenerateEmailConfirmationTokenAsync")]
        public async Task<string> GenerateEmailConfirmationTokenAsync([FromBody]ApplicationUser user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        [HttpPost("SignInAsync")]
        public async Task SignInAsync([FromBody]ApplicationUser user)
        {
            await _signInManager.SignInAsync(user, user.IsPersisted);
        }

        [HttpPost("GetUserName")]
        public async Task<string> GetUserName([FromBody]ClaimsPrincipal principal)
        {
            var result = principal == null ? string.Empty : _userManager.GetUserName(principal);
            return await Task.FromResult(result);
        }

        [HttpPost("IsSignedIn")]
        public async Task<bool> IsSignedIn([FromBody]ClaimsPrincipal principal)
        {

            //var result = principal == null ? false : _signInManager.IsSignedIn(principal);
            return await Task.FromResult(false);
        }
    }
}
