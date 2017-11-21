using System.Threading.Tasks;
using BookLibrary.aspnetcore.Domain;
using BookLibrary.aspnetcore.Services.Interfaces;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Net.Http;
using System;
using System.Security.Claims;

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

        public async Task SignInAsync(TUser user, bool isPersistent = false, string authenticationMethod = null)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                await client.PostAsJsonAsync(_apiName + "SignInAsync", user);
            }
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

        public async Task<bool> IsSignedIn(ClaimsPrincipal principal)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                var response = await client.PostAsJsonAsync(_apiName + "IsSignedIn", principal);
                return response.IsSuccessStatusCode ? await response.Content.ReadAsAsync<bool>() : false;
            }
        }
    }
}
