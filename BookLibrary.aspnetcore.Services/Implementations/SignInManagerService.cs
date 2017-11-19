using System.Threading.Tasks;
using BookLibrary.aspnetcore.Domain;
using BookLibrary.aspnetcore.Services.Interfaces;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Identity;

namespace BookLibrary.aspnetcore.Services.Implementations
{
    public class SignInManagerService<TUser> : ISignInManagerService<TUser> where TUser : ApplicationUser
    {
        private string _baseUrl;
        private string _apiName;

        public SignInManagerService(string baseUrl, string apiName)
        {
            _baseUrl = baseUrl;
            _apiName = apiName;
        }

        public AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string redirectUrl, string userId = null)
        {
            throw new System.NotImplementedException();
        }

        public Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent, bool bypassTwoFactor)
        {
            throw new System.NotImplementedException();
        }

        public Task<TUser> GetTwoFactorAuthenticationUserAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            throw new System.NotImplementedException();
        }

        public Task SignInAsync(TUser user, bool isPersistent, string authenticationMethod = null)
        {
            throw new System.NotImplementedException();
        }

        public Task SignOutAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<SignInResult> TwoFactorAuthenticatorSignInAsync(string code, bool isPersistent, bool rememberClient)
        {
            throw new System.NotImplementedException();
        }

        public Task<SignInResult> TwoFactorRecoveryCodeSignInAsync(string recoveryCode)
        {
            throw new System.NotImplementedException();
        }
    }
}
