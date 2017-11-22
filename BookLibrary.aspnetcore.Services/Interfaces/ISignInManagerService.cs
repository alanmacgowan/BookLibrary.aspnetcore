using BookLibrary.aspnetcore.Domain;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookLibrary.aspnetcore.Services.Interfaces
{
    public interface ISignInManagerService<TUser> where TUser : ApplicationUser
    {
        Task<bool> IsSignedIn(ClaimsPrincipal principal);

        Task<SignInResult> PasswordSignInAsync(TUser user);

        Task<TUser> GetTwoFactorAuthenticationUserAsync();

        Task<SignInResult> TwoFactorAuthenticatorSignInAsync(string code, bool isPersistent = false, bool rememberClient = false);

        Task<SignInResult> TwoFactorRecoveryCodeSignInAsync(string recoveryCode);

        Task SignInAsync(TUser user, bool isPersistent = false, string authenticationMethod = null);

        Task SignOutAsync();

        AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string redirectUrl, string userId = null);

        Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent, bool bypassTwoFactor);
    }
}
