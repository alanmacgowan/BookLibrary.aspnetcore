using BookLibrary.aspnetcore.Domain;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookLibrary.aspnetcore.Services.Interfaces
{
    public interface IUserManagerService<TUser> where TUser : ApplicationUser
    {
        string GetUserName(ClaimsPrincipal principal);

        string GetUserId(ClaimsPrincipal principal);

        Task<IdentityResult> CreateAsync(TUser user, string password);

        Task<string> GenerateEmailConfirmationTokenAsync(TUser user);

        Task<IdentityResult> CreateAsync(TUser user);

        Task<IdentityResult> AddLoginAsync(TUser user, UserLoginInfo login);

        Task<TUser> FindByIdAsync(string userId);

        Task<IdentityResult> ConfirmEmailAsync(TUser user, string token);

        Task<TUser> FindByEmailAsync(string email);

        Task<bool> IsEmailConfirmedAsync(TUser user);

        Task<string> GeneratePasswordResetTokenAsync(TUser user);

        Task<IdentityResult> ResetPasswordAsync(TUser user, string token, string newPassword);
    }
}
