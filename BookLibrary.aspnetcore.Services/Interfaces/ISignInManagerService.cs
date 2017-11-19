using BookLibrary.aspnetcore.Domain;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookLibrary.aspnetcore.Services.Interfaces
{
    public interface ISignInManagerService<TUser> where TUser : ApplicationUser
    {
        Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);

        Task<TUser> GetTwoFactorAuthenticationUserAsync();

        Task<SignInResult> TwoFactorAuthenticatorSignInAsync(string code, bool isPersistent, bool rememberClient);

        Task<SignInResult> TwoFactorRecoveryCodeSignInAsync(string recoveryCode);

        Task SignInAsync(TUser user, bool isPersistent, string authenticationMethod = null);

        Task SignOutAsync();

        AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string redirectUrl, string userId = null);

       // Task<ExternalLoginInfo> GetExternalLoginInfoAsync(string expectedXsrf = null);

        Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent, bool bypassTwoFactor);
    }
}
